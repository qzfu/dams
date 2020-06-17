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
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.WinUsb;
using LibUsbDotNet.Descriptors;
using System.Collections.ObjectModel;
using DAMS.Common;
using DAMS.Interface;
using DAMS.Core.ClassFactory;
using DAMS.UI.Common;
using System.Management;

namespace DAMS.UI.Views.Controls
{
    public partial class MainControl : UserControl
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
        public static UsbDevice MyUsbDevice;//USB设备
        private IDeviceNotifier deviceNotifier;//设备变化通知函数
        public static readonly byte TRANFER_ENDPOINT = UsbConstants.ENDPOINT_DIR_MASK;
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

        }

        private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            if (e.EventType == EventType.DeviceArrival)
            {
                //检查当前设备是否需要续传文件
                var myVID = e.Device.IdVendor;
                var myPID = e.Device.IdProduct;
                var serialNumber = e.Device.SerialNumber;
                var deviceRecord = deviceService.GetDeviceRecords(myPID, myVID);
                //新的设备接入
                if (deviceRecord == null)
                {
                    UsbDevice.ForceLibUsbWinBack = true;
                    UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(myVID, myPID);

                    //ManagementClass mc = new ManagementClass("Win32_DiskDrive"); 
                    //ManagementObjectCollection moc = mc.GetInstances();
                    //foreach (ManagementObject mo in moc)
                    //{
                    //    mo.ToString();
                    //    //propertyInfo = mo.Properties[PropertyName].Value.ToString();
                    //}
                    //MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);


                    UsbRegDeviceList regList = UsbDevice.AllDevices.FindAll(MyUsbFinder);
                    if (regList.Count == 0) throw new Exception("Device Not Found.");

                    UsbInterfaceInfo usbInterfaceInfo = null;
                    UsbEndpointInfo usbEndpointInfo = null;

                    //// Look through all conected devices with this vid and pid until
                    //// one is found that has and and endpoint that matches TRANFER_ENDPOINT.
                    ////
                    foreach (UsbRegistry regDevice in regList)
                    {
                        if (regDevice.Open(out MyUsbDevice))
                        {
                            if (MyUsbDevice.Configs.Count > 0)
                            {
                                // if TRANFER_ENDPOINT is 0x80 or 0x00, LookupEndpointInfo will return the 
                                // first read or write (respectively).
                                if (UsbEndpointBase.LookupEndpointInfo(MyUsbDevice.Configs[0], TRANFER_ENDPOINT,
                                    out usbInterfaceInfo, out usbEndpointInfo))
                                    break;

                                MyUsbDevice.Close();
                                MyUsbDevice = null;
                            }
                        }
                    }

                    //// If the device is open and ready
                    //if (MyUsbDevice == null) throw new Exception("Device Not Found.");

                    //// If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                    //// it exposes an IUsbDevice interface. If not (WinUSB) the 
                    //// 'wholeUsbDevice' variable will be null indicating this is 
                    //// an interface of a device; it does not require or support 
                    //// configuration and interface selection.
                    //IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                    //if (!ReferenceEquals(wholeUsbDevice, null))
                    //{
                    //    // This is a "whole" USB device. Before it can be used, 
                    //    // the desired configuration and interface must be selected.

                    //    // Select config #1
                    //    wholeUsbDevice.SetConfiguration(1);

                    //    // Claim interface #0.
                    //    wholeUsbDevice.ClaimInterface(usbInterfaceInfo.Descriptor.InterfaceID);
                    //}

                    //// open read endpoint.
                    //UsbEndpointReader reader = MyUsbDevice.OpenEndpointReader(
                    //    (ReadEndpointID)usbEndpointInfo.Descriptor.EndpointID,
                    //    0,
                    //    (EndpointType)(usbEndpointInfo.Descriptor.Attributes & 0x3));

                    //if (ReferenceEquals(reader, null))
                    //{
                    //    throw new Exception("Failed locating read endpoint.");
                    //}

                    //reader.Reset();
                    
                    //DeviceControl deviceControl = new DeviceControl();
                    //deviceControl.CopyFilesTo(e.Device.Name, myVID, myPID, serialNumber);
                }
                else
                {

                }
            }
            //else if (e.EventType == EventType.DeviceRemoveComplete)
            //{
            //    //看看目前移除的USB设备是不是目标设备
            //    if (e.Device.IdProduct == myPID && e.Device.IdVendor == myVID)
            //    {
            //        CloseUSB();
            //    }
            //    else
            //    {

            //    }
            //}
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == ConstConfig.WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case ConstConfig.WM_DEVICECHANGE:
                            break;
                        //监听U盘移动硬盘插入
                        case ConstConfig.DBT_DEVICEARRIVAL:
                            DriveInfo[] s = DriveInfo.GetDrives();
                            foreach (DriveInfo drive in s)
                            {
                                if (drive.DriveType == DriveType.Removable)
                                {
                                    //CommonHelper.CopyFiles(drive.RootDirectory);
                                    break;
                                }
                            }
                            break;
                        case ConstConfig.DBT_DEVICEREMOVECOMPLETE:   //U盘卸载  
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.WndProc(ref m);
        }


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
