using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAMS.Core.ClassFactory;
using DAMS.Interface;
using Telerik.WinControls;
using DAMS.Common;
using DAMS.UI.Common;
using DAMS.UI.Views.Controls;

namespace DAMS.UI.Views
{
    public partial class IndexForm : Telerik.WinControls.UI.RadForm
    {
        private IResourceService setService = Assembler<IResourceService>.Create();
        private MainControl mControl;
        public IndexForm()
        {
            InitializeComponent();
            this.titPanel.MouseDown += this.IndexForm_MouseDown;
            this.titPanel.MouseMove += this.IndexForm_MouseMove;
            this.titPanel.MouseUp += this.IndexForm_MouseUp;
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            this.labTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:ss");
            this.mPanel.Controls.Clear();
            mControl = new MainControl();
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

            var data = setService.GetWinSize();
            if (data != null)
            {
                var sizes = data.ItemValue.Split(',').Select(x=> Convert.ToInt32(x)).ToList();
                this.ClientSize = new System.Drawing.Size(sizes[0], sizes[1]);
            }

            //第一次使用时保存记录
            setService.SetStartDate();
            //验证是否注册过
            if (setService.CheckRegistered())
            {
                this.RegisterButton.Visible = false;
            }
            //验证是否过了试用期
            if (!setService.CheckEffective())
            {
                this.warnlabel.Visible = true;
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

        private void homeBtn_Click(object sender, EventArgs e)
        {
            if (!setService.CheckEffective()) return;
            this.mPanel.Controls.Clear();
            this.mPanel.Controls.Add(mControl);
        }
        private void btnResource_Click(object sender, EventArgs e)
        {
            if (!setService.CheckEffective()) return;

            this.mPanel.Controls.Clear();
            ResourceControl resControl = new ResourceControl();
            resControl.Dock = DockStyle.Fill;
            this.mPanel.Controls.Add(resControl);
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            if (!setService.CheckEffective()) return;

            this.mPanel.Controls.Clear();
            SettingControl settings = new SettingControl();
            settings.Dock = DockStyle.Fill;
            this.mPanel.Controls.Add(settings);
        }

        private void loginOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                this.RegisterButton.Visible = false;
                this.warnlabel.Visible = false;

                //注册成功后
                //重新渲染画布，启动U盘监听机制
                this.mPanel.Controls.Clear();
                MainControl mainControl = new MainControl();
                mainControl.Dock = DockStyle.Fill;
                this.mPanel.Controls.Add(mainControl);
            }
        }

        private Point mouseOffset;        //记录鼠标指针的坐标
        private bool isMouseDown = false; //记录鼠标按键是否按下

        protected void IndexForm_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                 SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void IndexForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X + 5, mouseOffset.Y + 30);
                Location = mousePos;
            }
        }

        private void IndexForm_MouseUp(object sender, MouseEventArgs e)
        {
            // 修改鼠标状态isMouseDown的值
            // 确保只有鼠标左键按下并移动时，才移动窗体
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

    }
}
