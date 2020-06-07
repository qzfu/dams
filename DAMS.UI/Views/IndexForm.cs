using DAMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace DAMS.UI.Views
{
    public partial class IndexForm : Telerik.WinControls.UI.RadForm
    {
        bool isCopy = false;
        bool isCopyEnd = false;
        string targetdir = null; 
        public IndexForm()
        {
            InitializeComponent();
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
                                    if (!isCopyEnd)
                                    {
                                        isCopy = true;
                                        CommonHelper.CopyFiles(drive.RootDirectory);
                                    }
                                    break;
                                }
                            }
                            break;
                        case ConstConfig.DBT_DEVICEREMOVECOMPLETE:   //U盘卸载  
                            isCopy = false;
                            isCopyEnd = false;
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
    }
}
