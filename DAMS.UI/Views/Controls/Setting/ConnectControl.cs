using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAMS.Core.ClassFactory;
using DAMS.Interface;
using MySql.Data.MySqlClient;

namespace DAMS.UI.Views.Controls.Setting
{
    public partial class ConnectControl : UserControl
    {
        private IResourceService service = Assembler<IResourceService>.Create();
        public ConnectControl()
        {
            InitializeComponent();

            this.radioButton1.CheckState = CheckState.Checked;
            this.CheckFirst();
        }

        private void radioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //this.radioButton1.CheckState = CheckState.Checked;
            //this.radioButton2.CheckState = CheckState.Unchecked;
            this.CheckFirst();
        }

        private void CheckFirst()
        {
            this.ServerIP.Text = @"127.0.0.1";
            this.ServerName.Text = @"dams";
            this.ServerUserName.Text = @"root";
            this.ServerPassWord.Text = @"123456";

            this.ipl.Text = "数据库服务器";
            this.namel.Text = "数据库名称";
            this.usernamel.Text = "   用户名";
            this.passwordl.Text = "   密码";
        }

        private void radioButton2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //this.radioButton1.CheckState = CheckState.Unchecked;
            //this.radioButton2.CheckState = CheckState.Checked;

            this.ServerIP.Text = @"127.0.0.1";
            this.ServerName.Text = @"21";
            this.ServerUserName.Text = @"hw";
            this.ServerPassWord.Text = @"000000";


            this.ipl.Text = "服务器ip地址";
            this.namel.Text = "  上传端口";
            this.usernamel.Text = "   ftp账号";
            this.passwordl.Text = "ftp密码";
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            if( this.radioButton2.CheckState == CheckState.Checked)
            return;

            string database = this.ServerName.Text;
            string local = this.ServerIP.Text;
            string user = this.ServerUserName.Text;
            string password = this.ServerPassWord.Text;

            try
            {
                var connect = "database = " + database + ";server = " + local + ";UserId= " + user + ";Password = " +
                          password;
                var result = service.TestMySqlConnect(connect);
                //MySqlConnection myCon = new MySqlConnection(connect);

                //myCon.Open();

                if (result)
                {
                    MessageBox.Show("数据库连接成功！");
                }
                else
                {
                    MessageBox.Show("数据库连接失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！");
            }
        }
    }
}
