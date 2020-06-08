namespace DAMS.UI.Views
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.cmbLoginID = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.btnLogin = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ckbSavePwd = new Telerik.WinControls.UI.RadCheckBox();
            this.pnlLoginState = new System.Windows.Forms.Panel();
            this.lblLoginPocc = new System.Windows.Forms.Label();
            this.picPocc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoginID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbSavePwd)).BeginInit();
            this.pnlLoginState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPocc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLoginID
            // 
            this.cmbLoginID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLoginID.DisplayMember = "LoginID";
            this.cmbLoginID.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmbLoginID.Location = new System.Drawing.Point(764, 393);
            this.cmbLoginID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLoginID.Name = "cmbLoginID";
            this.cmbLoginID.Size = new System.Drawing.Size(183, 29);
            this.cmbLoginID.TabIndex = 9;
            this.cmbLoginID.ValueMember = "LoginID";
            this.cmbLoginID.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmbLoginID_SelectedIndexChanged);
            this.cmbLoginID.TextChanged += new System.EventHandler(this.cmbLoginID_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPassword.Location = new System.Drawing.Point(764, 448);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.MaxLength = 18;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(183, 29);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.ThemeName = "Office2013Light";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Menu;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLogin.Location = new System.Drawing.Point(963, 393);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(96, 32);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "登录";
            this.btnLogin.ThemeName = "ControlDefault";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radLabel2.Location = new System.Drawing.Point(660, 396);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(94, 28);
            this.radLabel2.TabIndex = 14;
            this.radLabel2.Text = "用 户 名：";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(963, 448);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 32);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退出";
            this.btnExit.ThemeName = "Office2013Light";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radLabel1.Location = new System.Drawing.Point(658, 448);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(97, 28);
            this.radLabel1.TabIndex = 15;
            this.radLabel1.Text = "密      码：";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ckbSavePwd
            // 
            this.ckbSavePwd.BackColor = System.Drawing.Color.Transparent;
            this.ckbSavePwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbSavePwd.ForeColor = System.Drawing.Color.Black;
            this.ckbSavePwd.Location = new System.Drawing.Point(764, 486);
            this.ckbSavePwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckbSavePwd.Name = "ckbSavePwd";
            this.ckbSavePwd.Size = new System.Drawing.Size(97, 28);
            this.ckbSavePwd.TabIndex = 17;
            this.ckbSavePwd.Text = "记住密码";
            // 
            // pnlLoginState
            // 
            this.pnlLoginState.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlLoginState.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoginState.Controls.Add(this.lblLoginPocc);
            this.pnlLoginState.Controls.Add(this.picPocc);
            this.pnlLoginState.Location = new System.Drawing.Point(18, 541);
            this.pnlLoginState.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLoginState.Name = "pnlLoginState";
            this.pnlLoginState.Size = new System.Drawing.Size(1106, 39);
            this.pnlLoginState.TabIndex = 18;
            this.pnlLoginState.Visible = false;
            // 
            // lblLoginPocc
            // 
            this.lblLoginPocc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoginPocc.ForeColor = System.Drawing.Color.Orange;
            this.lblLoginPocc.Location = new System.Drawing.Point(30, 0);
            this.lblLoginPocc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoginPocc.Name = "lblLoginPocc";
            this.lblLoginPocc.Size = new System.Drawing.Size(1076, 39);
            this.lblLoginPocc.TabIndex = 0;
            this.lblLoginPocc.Text = "正在登录中......";
            this.lblLoginPocc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picPocc
            // 
            this.picPocc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picPocc.Dock = System.Windows.Forms.DockStyle.Left;
            this.picPocc.Image = global::DAMS.UI.Properties.Resources.Login_Loading;
            this.picPocc.Location = new System.Drawing.Point(0, 0);
            this.picPocc.Margin = new System.Windows.Forms.Padding(4);
            this.picPocc.Name = "picPocc";
            this.picPocc.Size = new System.Drawing.Size(30, 39);
            this.picPocc.TabIndex = 0;
            this.picPocc.TabStop = false;
            this.picPocc.WaitOnLoad = true;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1142, 585);
            this.Controls.Add(this.pnlLoginState);
            this.Controls.Add(this.ckbSavePwd);
            this.Controls.Add(this.cmbLoginID);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoginID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbSavePwd)).EndInit();
            this.pnlLoginState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPocc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cmbLoginID;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
        private Telerik.WinControls.UI.RadButton btnLogin;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadCheckBox ckbSavePwd;
        private System.Windows.Forms.Panel pnlLoginState;
        private System.Windows.Forms.Label lblLoginPocc;
        private System.Windows.Forms.PictureBox picPocc;
    }
}
