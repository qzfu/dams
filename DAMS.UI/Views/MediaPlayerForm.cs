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

namespace DAMS.UI.Views
{
    public partial class MediaPlayerForm : Form
    {
        public MediaPlayerForm()
        {
            InitializeComponent();
        }
        public MediaPlayerForm(string filepath)
        {
            InitializeComponent();

            var path = CommonHelper.GetAppSettings("desdirectory");

            var allpath = path + filepath;

            this.axWindowsMediaPlayer1.URL = allpath;
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
