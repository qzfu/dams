using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using DAMS.Core.ClassFactory;
using DAMS.Interface;
using DAMS.Models;
using DAMS.Common;
using DAMS.UI.Common;

namespace DAMS.UI.Views
{
    public partial class LoginForm : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// 本地用户
        /// </summary>
        private List<Users> _userTable = null;
        private IUserService userService = Assembler<IUserService>.Create();
        #region 属性
        /// <summary>
        /// 登录ID
        /// </summary>
        public string LoginID { get; set; }

        /// <summary>
        /// 密码文本
        /// </summary>
        public string PasswordText { get; set; }
        #endregion

        #region 构造函数
        public LoginForm()
        {
            InitializeComponent();
        }
	    #endregion
        
        private void LoginForm_Load(object sender, EventArgs e)
        {
            InitData();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            _userTable = userService.GetUsers().Select(r => new Users()
            { 
                UserId= r.UserId,
                UserName=r.UserName,
                DeptId = r.DeptId,
                Enabled = r.Enabled,
                Gender = r.Gender,
                ImageUrl = r.ImageUrl,
                RoleId=r.RoleId
            }).ToList();
            if (_userTable.Any())
            {
                cmbLoginID.DataSource=_userTable;
                cmbLoginID.DisplayMember = "UserId";
                cmbLoginID.ValueMember = "UserId";
                if (_userTable.Any())
                {
                    cmbLoginID.SelectedValue = _userTable.FirstOrDefault().UserId;
                }
                else
                {
                    cmbLoginID.SelectedValue = null;
                    cmbLoginID.Text = null;
                }
            }
        }

        #region 用户名文本变更事件
        /// <summary>
        /// 用户名文本变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLoginID_TextChanged(object sender, EventArgs e)
        {
            ChangeLoginId();
        }
        #endregion

        #region 用户名选择项变更事件
        /// <summary>
        /// 用户名选择项变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLoginID_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ChangeLoginId();
        }
        #endregion

        #region 更换登录用户名
        /// <summary>
        /// 更换登录用户名
        /// </summary>
        private void ChangeLoginId()
        {
            if (_userTable != null)
            {
                var loginTxt = this.cmbLoginID.Text;
                var selectUser = _userTable.FirstOrDefault(x => x.UserName == loginTxt);

                if (selectUser != null)
                {
                    string pwd = selectUser.Password;

                    if (!string.IsNullOrEmpty(pwd))
                    {
                        this.txtPassword.Text = pwd;
                    }
                    else
                    {
                        this.txtPassword.Text = String.Empty;
                    }

                    this.ckbSavePwd.Checked = !String.IsNullOrWhiteSpace(this.txtPassword.Text);

                    return;
                }
            }

            this.txtPassword.Text = string.Empty;
            this.ckbSavePwd.Checked = false;
        }
        #endregion

        #region 保存登录账号和密码
        /// <summary>
        /// 保存登录账号和密码
        /// </summary>
        /// <param name="loginId">登录账号</param>
        /// <param name="password">登录密码</param>
        /// <param name="success">是否登录成功</param>
        private void SavePassword(string loginId, string password, bool success = true)
        {
            if (_userTable!=null)
            {
                var user = _userTable.FirstOrDefault(x => x.UserId == loginId);
                user.Password = password;
            }
        }
        #endregion

        #region 登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.btnLogin.Enabled = false;

            if (string.IsNullOrEmpty(cmbLoginID.Text))
            {
                ShowMessage("请输入用户名！", false);
                cmbLoginID.Focus();
                btnLogin.Enabled = true;
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowMessage("请输入密码！", false);
                txtPassword.Focus();
                btnLogin.Enabled = true;
                return;
            }

            ShowMessage("正在登录......");
            Thread.CurrentThread.Join(500);
            //DialogResult = DialogResult.OK;
            try
            {
                var loginId = cmbLoginID.Text;
                var password = this.txtPassword.Text;
                var user = userService.GetUserByUserId(loginId, MD5Helper.GenerateMD5(password));
                if (user == null)
                {
                    ShowMessage("用户名或密码不正确！");
                    this.btnLogin.Enabled = true;
                    return;
                }
                LoginUser.loginID = this.cmbLoginID.Text;
                LoginUser.CurrentUser = user;
                if (!String.IsNullOrWhiteSpace(password))
                {
                    password = ckbSavePwd.IsChecked ? this.txtPassword.Text : String.Empty;//密码加密
                }

                SavePassword(this.cmbLoginID.Text, password);//保存登录账号和密码

                LoginID = cmbLoginID.Text;
                PasswordText = txtPassword.Text;

                ShowMessage("已经完成登录认证......");

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                SavePassword(this.cmbLoginID.Text, String.Empty, false);//保存登录账号和密码
            }

            btnLogin.Enabled = true;
        }
        #endregion

        #region 退出登录界面
        private void btnExit_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.OK;
            Environment.Exit(0);
        }
        #endregion

        #region 显示消息
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="showPicPocc"></param>
        public void ShowMessage(string message, bool showPicPocc = true)
        {
            MethodInvoker handler = () =>
            {
                pnlLoginState.Visible = true;

                this.picPocc.Visible = showPicPocc;

                this.lblLoginPocc.Visible = true;

                this.lblLoginPocc.Text = message;

                Application.DoEvents();
            };

            this.Invoke(handler);
        }
        #endregion

        #region 加密
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Encrypt(string data)
        {
            return data.EncodeBase64();
        }
        #endregion

        #region 解密
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="edata"></param>
        /// <returns></returns>
        private string Decrypt(string edata)
        {
            return edata.DecodeBase64();
        }
        #endregion

    }
}
