using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAMS.Common;
using DAMS.Core.ClassFactory;
using DAMS.Interface;
using DAMS.Models;
using DAMS.UI.Common;

namespace DAMS.UI.Views.Controls.Setting
{
    public partial class UserInfoControl : UserControl
    {
        private bool isInfo;
        private List<Roles> _roles;

        private IUserService userService = Assembler<IUserService>.Create();
        public UserInfoControl()
        {
            InitializeComponent();

            this.UserIdTextBox.AutoSize = false;
            this.OldPWTextBox.AutoSize = false;
            this.UserNameTextBox.AutoSize = false;
            this.NewPW2TextBox.AutoSize = false;
            this.NewPWTextBox.AutoSize = false;
            this.departmentTextBox.AutoSize = false;
            this.CreatedTimeTextBox.AutoSize = false;

            this.UserIdTextBox.Height = 18;
            this.OldPWTextBox.Height = 18;
            this.UserNameTextBox.Height = 18;
            this.NewPW2TextBox.Height = 18;
            this.NewPWTextBox.Height = 18;
            this.departmentTextBox.Height = 18;
            this.CreatedTimeTextBox.Height = 18;

            var id = 0;
            var user = LoginUser.CurrentUser;
            this._roles = userService.GetAllRolese();
            for(var i = 0; i < this._roles.Count; i++)
            {
                var role = this._roles[i];
                if (role.RoleId == user.RoleId)
                    id = i;
                this.ManaRootComboBox.Items.Add(role.RoleName);
            }
            this.ManaRootComboBox.SelectedIndex = id;

            this.UserIdTextBox.Text = user.UserId;
            this.UserNameTextBox.Text = user.UserName;
            this.GenderComboBox.SelectedIndex = user.Gender == 0 ? 0 : 1;
            this.CreatedTimeTextBox.Text = user.CreatedTime.ToString("yyyy-MM-dd");

            //默认个人信息
            this.UserInfoButton.Enabled = false;
            this.ChangeButton.Enabled = true;
            this.isInfo = true;

            this.ShowUserInfo();
            this.HidenChangePW();
        }

        
        private void ShowUserInfo()
        {
            this.UserIdTextBox.Visible = true;
            this.UserNameTextBox.Visible = true;
            this.ManaRootComboBox.Visible = true;
            this.departmentTextBox.Visible = true;
            this.GenderComboBox.Visible = true;
            this.CreatedTimeTextBox.Visible = true;

            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
        }

        private void HidenUserInfo()
        {
            this.UserIdTextBox.Visible = false;
            this.UserNameTextBox.Visible = false;
            this.ManaRootComboBox.Visible = false;
            this.departmentTextBox.Visible = false;
            this.GenderComboBox.Visible = false;
            this.CreatedTimeTextBox.Visible = false;

            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.Warn1label.Visible = false;
            this.Warn2label.Visible = false;
            this.Warn3label.Visible = false;
        }

        private void ShowChangePW()
        {
            this.OldPWTextBox.Visible = true;
            this.NewPWTextBox.Visible = true;
            this.NewPW2TextBox.Visible = true;

            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label9.Visible = true;
        }

        private void HidenChangePW()
        {
            this.OldPWTextBox.Visible = false;
            this.NewPWTextBox.Visible = false;
            this.NewPW2TextBox.Visible = false;

            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.Warn1label.Visible = false;
            this.Warn2label.Visible = false;
            this.Warn3label.Visible = false;
        }

        private void UserInfoButton_Click(object sender, EventArgs e)
        {
            this.UserInfoButton.Enabled = false;
            this.ChangeButton.Enabled = true;
            this.isInfo = true;

            this.ShowUserInfo();
            this.HidenChangePW();

        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            this.UserInfoButton.Enabled = true;
            this.ChangeButton.Enabled = false;
            this.isInfo = false;

            this.HidenUserInfo();
            this.ShowChangePW();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.isInfo)
            {
                this.SaveUserInfo();
            }
            else
            {
                this.SaveNewPassWord();
            }
        }

        private bool SaveUserInfo()
        {
            var userId = this.UserIdTextBox.Text;
            var userName = this.UserNameTextBox.Text;
            var roleName = this.ManaRootComboBox.Text;
            var gender = this.GenderComboBox.Text;

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("请填写用户名信息");
            }

            var role = this._roles.FirstOrDefault(x => x.RoleName == roleName);
            var roleId = 1;
            if (role != null) roleId = role.RoleId;

            var user = new Users
            {
                UserId = userId,
                UserName = userName,
                RoleId = roleId,
                Gender = gender == "男" ? 0 :1
            };

            var result = userService.SaveUserByUserId(user);
            if (result)
            {
                LoginUser.CurrentUser.UserName = user.UserName;
                LoginUser.CurrentUser.RoleId = user.RoleId;
                LoginUser.CurrentUser.Gender = user.Gender;
                MessageBox.Show("个人信息修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("个人信息修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result;
        }

        private bool SaveNewPassWord()
        {
            this.Warn1label.Visible = false;
            this.Warn2label.Visible = false;
            this.Warn3label.Visible = false;

            var userId = this.UserIdTextBox.Text;
            var oldpw = this.OldPWTextBox.Text;
            var newpw = this.NewPWTextBox.Text;
            var newpw2 = this.NewPW2TextBox.Text;

            var flag = false;
            if (string.IsNullOrEmpty(oldpw))
            {
                flag = true;
                this.Warn1label.Text = "*请输入旧密码";
                this.Warn1label.Visible = true;
            }
            if (string.IsNullOrEmpty(newpw))
            {
                flag = true;
                this.Warn3label.Text = "*请输入新密码";
                this.Warn3label.Visible = true;
            }
            if (string.IsNullOrEmpty(newpw2))
            {
                flag = true;
                this.Warn2label.Text = "*请再次输入新密码";
                this.Warn2label.Visible = true;
            }
            if (flag) return false;

            var user = userService.GetUserByUserId(userId, MD5Helper.GenerateMD5(oldpw));
            if (user == null)
            {
                this.Warn1label.Text = "*旧密码输入不正确";
                this.Warn1label.Visible = true;
                return false;
            }

            if (newpw != newpw2)
            {
                this.Warn2label.Text = "*新密码输入不一致";
                this.Warn2label.Visible = true;
                return false;
            }

            var result = userService.SaveChangePassword(userId, MD5Helper.GenerateMD5(newpw));
            if (result)
            {
                MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("密码修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result;
        }
    }
}
