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
