using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAMS.Common;
using DAMS.Core.ClassFactory;
using DAMS.Interface;

namespace DAMS.UI.Views
{
    public partial class RegisterForm : Form
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
        public RegisterForm()
        {
            InitializeComponent();

            var computerCode = RegistrationHelper.getMNum();

            this.ComTextBox.Text = computerCode;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerCode = this.RegTextBox.Text;
            if (string.IsNullOrEmpty(registerCode))
            {
                this.titlelabel.Visible = true;
                this.titlelabel.Text = "*请输入注册码";
                return;
            }

            if (registerCode != RegistrationHelper.getRNum())
            {
                this.titlelabel.Visible = true;
                this.titlelabel.Text = "*注册码错误，请重新输入";
                return;
            }

            deviceService.SaveRegister();
            DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
