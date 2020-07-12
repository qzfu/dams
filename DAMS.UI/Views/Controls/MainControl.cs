using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibUsbDotNet;  
using LibUsbDotNet.Main;  
using LibUsbDotNet.Info; 
using LibUsbDotNet.DeviceNotify;

using DAMS.Common;
using DAMS.Interface;
using DAMS.Core.ClassFactory;
using DAMS.UI.Common;
using System.Management;
using System.Threading;
using System.Diagnostics;

namespace DAMS.UI.Views.Controls
{
    //设置Com对外可访问
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class MainControl : UserControl
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
        public static UsbDevice MyUsbDevice;//USB设备
        private IDeviceNotifier deviceNotifier;//设备变化通知函数

        public delegate void AsynUpdateProgress(string deviceInfo, int percent);//声明一个更新资源加载进度的委托
        public delegate void AsynRemoveDevice(string deviceInfo);//声明一个清空资源采集站状态的委托

        //当前程序根目录
        string dirRoot = System.Environment.CurrentDirectory;
        Dictionary<string, bool> deviceDic;
        string[] diskArray;
        int driveNumber;
        DriveInfo[] allUsbDrives;
        public MainControl()
        {
            InitializeComponent();
            //初始化浏览器
            this.initChartBrowser();
            this.chartBrowser.Navigate(dirRoot + @"\Views\Browser\main.html");

            //若过了试用期并且未注册，则不进行U盘监听
            if (!deviceService.CheckEffective()) return;
            deviceDic = new Dictionary<string, bool>();
            deviceNotifier = DeviceNotifier.OpenDeviceNotifier();
            deviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;

            try
            {
                allUsbDrives = DriveInfo.GetDrives().Where(x => x.DriveType == DriveType.Removable).ToArray();
                //开启任务异步操作，避免多个采集站统计加载时界面假死
                Thread ts = new Thread(() =>
                {
                    var resourceIndex = 0;
                    var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDiskToPartition");
                    foreach (ManagementObject dm in searcher.Get())
                    {
                        var drive = getValueInQuotes(dm["Dependent"].ToString())+@"\";
                        diskArray = getValueInQuotes(dm["Antecedent"].ToString()).Split(',');
                        driveNumber = Convert.ToInt32(diskArray[0].Remove(0, 6).Trim());
                        var disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                        foreach (ManagementObject disk in disks.Get())
                        {
                            if (disk["Name"].ToString() == ("\\\\.\\PHYSICALDRIVE" + driveNumber.ToString()) & disk["InterfaceType"].ToString() == "USB")
                            {
                                DeviceControl device = new DeviceControl();
                                var serialNumber = parseSerialFromDeviceID(disk["PNPDeviceID"].ToString()).ToUpper();
                                DriveInfo d = allUsbDrives.FirstOrDefault(x => x.Name == drive);
                                if (d == null)
                                {
                                    continue;
                                }
                                var deviceName = d.Name;
                                var deviceRoot = d.RootDirectory;
                                var checkToken = device.CheckDeviceToken(deviceName, serialNumber);
                                if (checkToken < 0) continue;
                                if (resourceIndex==0)
                                {
                                    MessageUtil.ShowMessage("资源已就绪，开始采集...", EnumData.MessageType.Information, this);
                                    resourceIndex++;
                                }
                                device.SetProgressDelegate += HandleRefreshProgess;
                                Action<DirectoryInfo, string> copyAction = device.CopyFilesTo;
                                copyAction.BeginInvoke(deviceRoot, serialNumber, null, null);
                            }
                        }
                    }
                });
                ts.IsBackground = true;
                ts.Start();
            }
            catch 
            {
                MessageUtil.ShowMessage("资源识别失败，请重启程序！", EnumData.MessageType.Warning, this);
            }
        }
        private static string parseSerialFromDeviceID(string deviceId)
        {
            var splitDeviceId = deviceId.Split('\\');
            var arrayLen = splitDeviceId.Length - 1;
            var serialArray = splitDeviceId[arrayLen].Split('&');
            var serial = serialArray[0];
            return serial;
        }
        private static string getValueInQuotes(string inValue)
        {
            var posFoundStart = inValue.IndexOf("\"");
            var posFoundEnd = inValue.IndexOf("\"", posFoundStart + 1);
            var parsedValue = inValue.Substring(posFoundStart + 1, (posFoundEnd - posFoundStart) - 1);
            return parsedValue;
        }
        /// <summary>
        /// 初始化浏览器
        /// </summary>
        private void initChartBrowser()
        {
            //防止 WebBrowser 控件打开拖放到其上的文件。
            chartBrowser.AllowWebBrowserDrop = false;

            //防止 WebBrowser 控件在用户右击它时显示其快捷菜单.
            chartBrowser.IsWebBrowserContextMenuEnabled = false;

            //以防止 WebBrowser 控件响应快捷键。
            chartBrowser.WebBrowserShortcutsEnabled = false;

            //以防止 WebBrowser 控件显示脚本代码问题的错误信息。    
            chartBrowser.ScriptErrorsSuppressed = true;

            //（这个属性比较重要，可以通过这个属性，把WINFROM中的变量，传递到JS中，供内嵌的网页使用；但设置到的类型必须是COM可见的，所以要设置     [System.Runtime.InteropServices.ComVisibleAttribute(true)]，因为我的值设置为this,所以这个特性要加载窗体类上）
            chartBrowser.ObjectForScripting = this;
        }
        
        private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            if (e.EventType == EventType.DeviceArrival)
            {
                //检查当前设备是否需要续传文件
                if (e.Device == null)
                {
                    return;
                }
                //已存在同步资源的采集站，跳过
                var serialNumber = e.Device.SerialNumber.ToUpper();
                if (deviceDic.ContainsKey(serialNumber) && deviceDic[serialNumber])
                {
                    return;
                }
                if (!deviceDic.ContainsKey(serialNumber))
                {
                    deviceDic.Add(serialNumber, true);
                }
                else
                {
                    deviceDic[serialNumber] = true;
                }

                //开启任务异步操作，避免多个采集站统计加载时界面假死
                Thread ts = new Thread(() =>
                {
                    MessageUtil.ShowMessage("正在识别资源，请等待...", EnumData.MessageType.Information, this);
                    var collected = false;
                    while (!collected)
                    {
                        //每个3秒检测U盘设备
                        Thread.Sleep(3000);
                        DriveInfo[] allDrives = DriveInfo.GetDrives().Where(x => x.DriveType == DriveType.Removable).ToArray();
                        DeviceControl device = new DeviceControl();
                        foreach (DriveInfo d in allDrives)
                        {
                            var deviceName = d.Name;
                            var deviceRoot = d.RootDirectory;
                            var checkToken = device.CheckDeviceToken(deviceName, serialNumber);
                            if (checkToken < 0) continue;
                            device.SetProgressDelegate += HandleRefreshProgess;
                            Action<DirectoryInfo, string> copyAction = device.CopyFilesTo;
                            copyAction.BeginInvoke(deviceRoot, serialNumber, null, null);
                            collected = true;
                            break;
                        }
                    }
                });
                ts.IsBackground = true;
                ts.Start();
            }
            else if (e.EventType == EventType.DeviceRemoveComplete)
            {
                //移除USB设备,渲染界面资源加载状态
                if (e.Device == null)
                {
                    return;
                }
                //检测采集站同步资源状态
                var serialNumber = e.Device.SerialNumber.ToUpper();
                if (deviceDic.ContainsKey(serialNumber) && deviceDic[serialNumber])
                {
                    deviceDic[serialNumber] = false;
                }
                //开启任务异步操作，避免界面假死
                var exit = new Thread(() =>
                {
                    Thread.Sleep(3000);
                    HandleRemoveDevice(serialNumber);
                });
                exit.IsBackground = true;
                exit.Start();
            }
        }
        //更新资源加载进度
        private void HandleRefreshProgess(string deviceInfo, int percent)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateProgress(delegate(string info, int per)
                {
                    HtmlDocument doc = chartBrowser.Document;
                    Object[] objArray = new Object[2];
                    objArray[0] = (Object)info;
                    objArray[1] = (Object)per;
                    doc.InvokeScript("refreshProgess", objArray);
                }), deviceInfo, percent);
            }
            else
            {
                HtmlDocument doc = chartBrowser.Document;
                Object[] objArray = new Object[2];
                objArray[0] = (Object)deviceInfo;
                objArray[1] = (Object)percent;
                doc.InvokeScript("refreshProgess", objArray);
            }
        }
        //清空资源采集站状态
        private void HandleRemoveDevice(string deviceInfo)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynRemoveDevice(delegate(string info)
                {
                    HtmlDocument doc = chartBrowser.Document;
                    Object[] objArray = new Object[1];
                    objArray[0] = (Object)info;
                    doc.InvokeScript("removeDevice", objArray);
                }), deviceInfo);
            }
            else
            {
                HtmlDocument doc = chartBrowser.Document;
                Object[] objArray = new Object[1];
                objArray[0] = (Object)deviceInfo;
                doc.InvokeScript("removeDevice", objArray);
            }
        }
    }
}
