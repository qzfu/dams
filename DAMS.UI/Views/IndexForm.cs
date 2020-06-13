using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using DAMS.Common;
using DAMS.UI.Common;
using DAMS.UI.Views.Controls;

namespace DAMS.UI.Views
{
    public partial class IndexForm : Telerik.WinControls.UI.RadForm
    {
        public IndexForm()
        {
            InitializeComponent();
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            this.labTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:ss");
            this.mPanel.Controls.Clear();
            MainControl mControl = new MainControl();
            mControl.Dock = DockStyle.Fill;
            this.mPanel.Controls.Add(mControl);
            var user = LoginUser.CurrentUser;
            if (user != null)
            {
                this.labUserInfo.Text = user.UserName + "，您好！";
            }
            else
            {
                this.labUserInfo.Text = "Admin，您好！";
            }
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            this.labTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:ss");
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnResource_Click(object sender, EventArgs e)
        {
            this.mPanel.Controls.Clear();
            ResourceControl resControl = new ResourceControl();
            resControl.Dock = DockStyle.Fill;
            this.mPanel.Controls.Add(resControl);
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            this.mPanel.Controls.Clear();
            SettingControl settings = new SettingControl();
            settings.Dock = DockStyle.Fill;
            this.mPanel.Controls.Add(settings);
        }


    }
}
