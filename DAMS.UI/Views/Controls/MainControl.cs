using System;
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
using LibUsbDotNet.Descriptors;  
using LibUsbDotNet.LibUsb;  
using LibUsbDotNet.WinUsb;  
using LibUsbDotNet.DeviceNotify;
using System.Collections.ObjectModel;
using DAMS.Common;
using DAMS.Interface;
using DAMS.Core.ClassFactory;

namespace DAMS.UI.Views.Controls
{
    public partial class MainControl : UserControl
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
		delegate void DeviceNotifyDelegate();
        const string serialNumber = "528137412080453A";
        const int myPID = 0x2222;  //产品ID
        const int myVID = 0x1111;  //供应商ID
        
        public static UsbDevice MyUsbDevice;//USB设备
        private IDeviceNotifier deviceNotifier;//设备变化通知函数
        public static UsbEndpointWriter writer = null;
        public static UsbEndpointReader reader = null;

        delegate void SetTextCallback(string text);//安全线程访问txtReadInt的值
        public static Boolean EnbaleCollect = true;//Convert.ToBoolean(CommonHelper.GetAppSettings("EnbaleCollect"));//是否使用中断接收
        delegate void AppendNotifyDelegate(string s);
        bool isCopy = false;
        bool isCopyEnd = false;
        string targetdir = null; 

        public MainControl()
        {
            InitializeComponent();
            //this.mianList.Clear(); 
            //bindListView();
        }
        private void bindListView() 
        {
            var maxListCount = 16;
            var imageLists = this.resImageList.Images;
            for (int i = 0; i < maxListCount; i++)
            {
                mianList.Items.Add((i+1).ToString(), i);
                mianList.Items[i].ImageIndex = 0;
                mianList.Items[i].Name = imageLists[0].ToString();
            }
        }
        
        private void MainControl_Load(object sender, EventArgs e)
        {
            deviceNotifier = DeviceNotifier.OpenDeviceNotifier();
            deviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;

            //writer = MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep03);
            //reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep02);

            //if (EnbaleCollect)
            //{
            //    reader.DataReceived += (OnRxEndPointData);
            //        reader.DataReceivedEnabled = true;
            //}
        }

        private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            if (e.EventType == EventType.DeviceArrival)
            {

                //检查当前设备是否需要续传文件
                var myPID = e.Device.IdProduct.ToString();
                var myVID = e.Device.IdVendor.ToString();
                //var deviceRecord = deviceService.GetDeviceRecords((int)myPID, (int)myVID);
                //if (deviceRecord == null)
                //{
                //    //发现目标设备并打开该设备
                //    FindAndOpenUSB((int)myPID, (int)myVID);
                //}
                //else
                //{

                //}
            }
            else if (e.EventType == EventType.DeviceRemoveComplete)
            {
                //看看目前移除的USB设备是不是目标设备
                if (e.Device.IdProduct == myPID && e.Device.IdVendor == myVID)
                {
                    CloseUSB();
                }
                else
                {

                }
            }
        }
        /// <summary>
        /// 初始化U盘设备
        /// </summary>
        /// <param name="PID"></param>
        /// <param name="VID"></param>
        /// <returns></returns>
        private void FindAndOpenUSB(int PID, int VID)
        {
            //UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(PID, VID);
            //UsbRegistry myUsbRegistry = UsbGlobals.AllDevices.Find(MyUsbFinder);

            //if (ReferenceEquals(myUsbRegistry, null))
            //{
            //    return false;
            //}
            //// Open this usb device.
            //if (!myUsbRegistry.Open(out MyUsbDevice))
            //{
            //    return false;
            //}

            //MyUsbDevice.SetConfiguration(1);

            //((LibUsbDevice)MyUsbDevice).ClaimInterface(0);

            ////ShowMsg(string.Format("Find Device:{0}", myUsbRegistry[SPDRP.DeviceDesc]));
            //return true;
            ErrorCode ec = ErrorCode.None;

            UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(PID, VID);
            MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);

            // If the device is open and ready
            if (MyUsbDevice == null) throw new Exception("Device Not Found.");

            // If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
            // it exposes an IUsbDevice interface. If not (WinUSB) the 
            // 'wholeUsbDevice' variable will be null indicating this is 
            // an interface of a device; it does not require or support 
            // configuration and interface selection.
            IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
            if (!ReferenceEquals(wholeUsbDevice, null))
            {
                // This is a "whole" USB device. Before it can be used, 
                // the desired configuration and interface must be selected.

                // Select config #1
                wholeUsbDevice.SetConfiguration(1);

                // Claim interface #0.
                wholeUsbDevice.ClaimInterface(0);
            }

            // open read endpoint 1.
            UsbEndpointReader reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);
            byte[] readBuffer = new byte[1024];
            while (ec == ErrorCode.None)
            {
                int bytesRead;

                // If the device hasn't sent data in the last 5 seconds,
                // a timeout error (ec = IoTimedOut) will occur. 
                ec = reader.Read(readBuffer, 5000, out bytesRead);

                if (bytesRead == 0) throw new Exception(string.Format("{0}:No more bytes!", ec));
                txtRead.Text = string.Format("{0} bytes read", bytesRead);

                // Write that output to the console.
                txtRead.Text = Encoding.Default.GetString(readBuffer, 0, bytesRead);
            }
        }
        //关闭USB设备
        public void CloseUSB()
        {
            if (!ReferenceEquals(reader, null))
                reader.Dispose();
            if (!ReferenceEquals(writer, null))
                writer.Dispose();
            if (!ReferenceEquals(MyUsbDevice, null))
                MyUsbDevice.Close();
        }
        ////获得上次错误信息
        //public string GetLastError()
        //{
        //    return UsbGlobals.LastErrorString;
        //}

        //USB中断接收函数
        private void OnRxEndPointData(object sender, EndpointDataEventArgs e)
        {
            //txtReadInt.Text = Encoding.Default.GetString(e.Buffer, 0, e.Count);
            //MessageBox.Show(Encoding.Default.GetString(e.Buffer, 0, e.Count));
            SetText(Encoding.Default.GetString(e.Buffer, 0, e.Count));
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ErrorCode ec = ErrorCode.None;

            byte[] readBuffer = new byte[1024];
            int bytesRead;
            try
            {
                ec = reader.Read(readBuffer, 100, out bytesRead);
                if (bytesRead == 0)
                    throw new Exception("No more bytes!");
                txtRead.Text = Encoding.Default.GetString(readBuffer, 0, bytesRead);
            }
            catch (Exception ex)
            {
                //ShowMsg("Error:" + ex.Message);
            }
            finally
            {

            }
        }
        //线程安全访问txtReadInt
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtRead.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtRead.Text = text;
            }
        }


        //protected override void WndProc(ref Message m)
        //{
        //    try
        //    {
        //        if (m.Msg == ConstConfig.WM_DEVICECHANGE)
        //        {
        //            switch (m.WParam.ToInt32())
        //            {
        //                case ConstConfig.WM_DEVICECHANGE:
        //                    break;
        //                //监听U盘移动硬盘插入
        //                case ConstConfig.DBT_DEVICEARRIVAL:
        //                    DriveInfo[] s = DriveInfo.GetDrives();
        //                    foreach (DriveInfo drive in s)
        //                    {
        //                        if (drive.DriveType == DriveType.Removable)
        //                        {
        //                            if (!isCopyEnd)
        //                            {
        //                                isCopy = true;
        //                                CommonHelper.CopyFiles(drive.RootDirectory);
        //                            }
        //                            break;
        //                        }
        //                    }
        //                    break;
        //                case ConstConfig.DBT_DEVICEREMOVECOMPLETE:   //U盘卸载  
        //                    isCopy = false;
        //                    isCopyEnd = false;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    base.WndProc(ref m);
        //}


        //public void ReadUSB()
        //{
        //    //转储所有的设备和描述符
        //    UsbRegDeviceList allDevices = UsbDevice.AllDevices;
        //    foreach (UsbRegistry usbRegistry in allDevices)
        //    {
        //        if (usbRegistry.Open(out MyUsbDevice))
        //        {
        //            //WriteToRichTextBox(MyUsbDevice.Info.ToString());//设备描述符
        //            for (int iConfig = 0; iConfig < MyUsbDevice.Configs.Count; iConfig++)
        //            {
        //                UsbConfigInfo configInfo = MyUsbDevice.Configs[iConfig];
        //                //WriteToRichTextBox(configInfo.ToString());//配置描述符

        //                ReadOnlyCollection<UsbInterfaceInfo> interfaceList = configInfo.InterfaceInfoList;
        //                for (int iInterface = 0; iInterface < interfaceList.Count; iInterface++)
        //                {
        //                    UsbInterfaceInfo interfaceInfo = interfaceList[iInterface];
        //                    //WriteToRichTextBox("interfaceList" + interfaceList.ToString());//接口描述符

        //                    ReadOnlyCollection<UsbEndpointInfo> endpointList = interfaceInfo.EndpointInfoList;
        //                    for (int iEndpoint = 0; iEndpoint < endpointList.Count; iEndpoint++)
        //                    {
        //                        //WriteToRichTextBox("endpointList" + endpointList[iEndpoint].ToString());//端点描述符
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    UsbDevice.Exit();
        //}

        //#region USB
        ///// <summary>
        ///// 初始化
        ///// </summary>
        ///// <param name="PID">设备PID</param>
        ///// <param name="VID">设备VID</param>
        ///// <returns></returns>
        //private bool FindAndOpenUSB(int PID, int VID)
        //{
        //    UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(PID, VID);
        //    UsbRegistry myUsbRegistry = UsbGlobals.AllDevices.Find(MyUsbFinder);

        //    if (ReferenceEquals(myUsbRegistry, null))
        //    {
        //        return false;
        //    }
        //    // Open this usb device.
        //    if (!myUsbRegistry.Open(out MyUsbDevice))
        //    {
        //        return false;
        //    }

        //    MyUsbDevice.SetConfiguration(1);

        //    ((LibUsbDevice)MyUsbDevice).ClaimInterface(0);

        //    ShowMsg(string.Format("Find Device:{0}", myUsbRegistry[SPDRP.DeviceDesc]));
        //    return true;
        //}
        ////关闭USB设备
        //public void CloseUSB()
        //{
        //    if (!ReferenceEquals(reader, null))
        //        reader.Dispose();
        //    if (!ReferenceEquals(writer, null))
        //        writer.Dispose();
        //    if (!ReferenceEquals(MyUsbDevice, null))
        //        MyUsbDevice.Close();
        //}
        ////获得上次错误信息
        //public string GetLastError()
        //{
        //    return UsbGlobals.LastErrorString;
        //}
        ////设备变化消息相应函数
        //private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        //{
        //    if (e.EventType == EventType.DeviceArrival)
        //    {
        //        ShowMsg(string.Format("发现有新USB设备连接，PID = 0x{0:X},VID = 0x{1:X}.\r\n设备的详细信息{2}", e.Device.IdProduct, e.Device.IdVendor, e.Device.ToString()));
        //        //看看目前新连接的USB设备是不是目标设备
        //        if (e.Device.IdProduct == myPID && e.Device.IdVendor == myVID)
        //        {
        //            ShowMsg("该USB设备是目标设备");
        //            //发现目标设备并打开该设备
        //            FindAndOpenUSB(myPID, myVID);
        //        }
        //        else
        //        {
        //            ShowMsg("该USB设备不是目标设备\r\n");
        //        }
        //    }
        //    else if (e.EventType == EventType.DeviceRemoveComplete)
        //    {

        //        ShowMsg(string.Format("发现有USB设备移除，PID = 0x{0:X}, VID = 0x{1:X}\r\n设备的详细信息{2}", e.Device.IdProduct, e.Device.IdVendor, e.Device.ToString()));
        //        //看看目前移除的USB设备是不是目标设备
        //        if (e.Device.IdProduct == myPID && e.Device.IdVendor == myVID)
        //        {
        //            ShowMsg(string.Format("移除的USB设备是目标设备\r\n"));
        //            CloseUSB();
        //        }
        //        else
        //        {
        //            ShowMsg(string.Format("移除的USB设备不是目标设备\r\n"));
        //        }
        //    }
        //}
        ////USB中断接收函数
        //private void OnRxEndPointData(object sender, EndpointDataEventArgs e)
        //{
        //    //txtReadInt.Text = Encoding.Default.GetString(e.Buffer, 0, e.Count);
        //    //MessageBox.Show(Encoding.Default.GetString(e.Buffer, 0, e.Count));
        //    SetText(Encoding.Default.GetString(e.Buffer, 0, e.Count));
        //}

        //#endregion
        ////线程安全访问txtReadInt
        //private void SetText(string text)
        //{
        //    // InvokeRequired required compares the thread ID of the
        //    // calling thread to the thread ID of the creating thread.
        //    // If these threads are different, it returns true.
        //    if (this.txtReadInt.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetText);
        //        this.Invoke(d, new object[] { text });
        //    }
        //    else
        //    {
        //        this.txtReadInt.Text = text;
        //    }
        //}
    }
}
