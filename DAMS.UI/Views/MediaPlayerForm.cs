using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAMS.Common;
using DAMS.Core.ClassFactory;
using DAMS.Interface;

namespace DAMS.UI.Views
{
    public partial class MediaPlayerForm : Form
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
        public MediaPlayerForm()
        {
            InitializeComponent();
        }
        public MediaPlayerForm(string filepath)
        {
            InitializeComponent();

            //var path = CommonHelper.GetAppSettings("desdirectory");
            //var setRoot = deviceService.GetDownLoadUrl();
            ////获取配置路径
            //if (!string.IsNullOrEmpty(setRoot))
            //    path = setRoot;

            //var allpath = path + filepath;

            this.axWindowsMediaPlayer1.URL = filepath;
            this.axWindowsMediaPlayer1.Show();
            //this.axWindowsMediaPlayer1.Controls.
        }

        public void SettingAndShow(string path)
        {
            this.axWindowsMediaPlayer1.URL = path;
            this.axWindowsMediaPlayer1.Show();
        }
    }
}
