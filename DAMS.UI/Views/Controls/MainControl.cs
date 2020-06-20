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

namespace DAMS.UI.Views.Controls
{
    //设置Com对外可访问
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class MainControl : UserControl
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
        public static UsbDevice MyUsbDevice;//USB设备
        private IDeviceNotifier deviceNotifier;//设备变化通知函数

        //当前程序根目录
        string dirRoot = System.Environment.CurrentDirectory;
        public MainControl()
        {
            InitializeComponent();
            //初始化浏览器
            this.initChartBrowser();
            this.chartBrowser.Navigate(dirRoot + @"\Views\Browser\main.html");

            deviceNotifier = DeviceNotifier.OpenDeviceNotifier();
            deviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;

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
        
        private void MainControl_Load(object sender, EventArgs e)
        {
            
            
        }

        private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            if (e.EventType == EventType.DeviceArrival)
            {
                //检查当前设备是否需要续传文件
                var myVID = e.Device.IdVendor;
                var myPID = e.Device.IdProduct;
                var serialNumber = e.Device.SerialNumber;

                DriveInfo[] allDrives = DriveInfo.GetDrives();
                DeviceControl device = new DeviceControl();
                foreach (DriveInfo d in allDrives)
                {
                    if (d.DriveType == DriveType.Removable)
                    {
                        var deviceName = d.Name;
                        var deviceRoot = d.RootDirectory;
                        var checkToken = device.CheckDeviceToken(deviceName, myVID, myPID, serialNumber);
                        if (checkToken < 0) continue;
                        device.CopyFilesTo(deviceRoot, myVID, myPID, serialNumber);
                    }
                }

            }
            else if (e.EventType == EventType.DeviceRemoveComplete)
            {
                //移除USB设备,渲染界面资源加载状态
            }
        }
    }
}
