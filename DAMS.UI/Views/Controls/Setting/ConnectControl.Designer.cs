namespace DAMS.UI.Views.Controls.Setting
{
    partial class ConnectControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.radioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.ipl = new System.Windows.Forms.Label();
            this.ServerIP = new Telerik.WinControls.UI.RadTextBox();
            this.ServerName = new Telerik.WinControls.UI.RadTextBox();
            this.namel = new System.Windows.Forms.Label();
            this.ServerUserName = new Telerik.WinControls.UI.RadTextBox();
            this.usernamel = new System.Windows.Forms.Label();
            this.ServerPassWord = new Telerik.WinControls.UI.RadTextBox();
            this.passwordl = new System.Windows.Forms.Label();
            this.TestButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPassWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestButton)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(214, 43);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(80, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "单机运行";
            this.radioButton1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radioButton1_ToggleStateChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(364, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(169, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "连接本系统服务器运行";
            this.radioButton2.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radioButton2_ToggleStateChanged);
            // 
            // ipl
            // 
            this.ipl.AutoSize = true;
            this.ipl.Location = new System.Drawing.Point(92, 149);
            this.ipl.Name = "ipl";
            this.ipl.Size = new System.Drawing.Size(97, 15);
            this.ipl.TabIndex = 2;
            this.ipl.Text = "数据库服务器";
            // 
            // ServerIP
            // 
            this.ServerIP.Location = new System.Drawing.Point(214, 145);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(314, 24);
            this.ServerIP.TabIndex = 3;
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(214, 210);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(314, 24);
            this.ServerName.TabIndex = 5;
            // 
            // namel
            // 
            this.namel.AutoSize = true;
            this.namel.Location = new System.Drawing.Point(107, 214);
            this.namel.Name = "namel";
            this.namel.Size = new System.Drawing.Size(82, 15);
            this.namel.TabIndex = 4;
            this.namel.Text = "数据库名称";
            // 
            // ServerUserName
            // 
            this.ServerUserName.Location = new System.Drawing.Point(214, 283);
            this.ServerUserName.Name = "ServerUserName";
            this.ServerUserName.Size = new System.Drawing.Size(314, 24);
            this.ServerUserName.TabIndex = 7;
            // 
            // usernamel
            // 
            this.usernamel.AutoSize = true;
            this.usernamel.Location = new System.Drawing.Point(113, 287);
            this.usernamel.Name = "usernamel";
            this.usernamel.Size = new System.Drawing.Size(76, 15);
            this.usernamel.TabIndex = 6;
            this.usernamel.Text = "   用户名";
            // 
            // ServerPassWord
            // 
            this.ServerPassWord.Location = new System.Drawing.Point(214, 355);
            this.ServerPassWord.Name = "ServerPassWord";
            this.ServerPassWord.Size = new System.Drawing.Size(314, 24);
            this.ServerPassWord.TabIndex = 9;
            // 
            // passwordl
            // 
            this.passwordl.AutoSize = true;
            this.passwordl.Location = new System.Drawing.Point(128, 359);
            this.passwordl.Name = "passwordl";
            this.passwordl.Size = new System.Drawing.Size(61, 15);
            this.passwordl.TabIndex = 8;
            this.passwordl.Text = "   密码";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(230, 438);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(239, 30);
            this.TestButton.TabIndex = 10;
            this.TestButton.Text = "测试并启用数据库连接";
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // ConnectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.ServerPassWord);
            this.Controls.Add(this.passwordl);
            this.Controls.Add(this.ServerUserName);
            this.Controls.Add(this.usernamel);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.namel);
            this.Controls.Add(this.ServerIP);
            this.Controls.Add(this.ipl);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "ConnectControl";
            this.Size = new System.Drawing.Size(925, 635);
            ((System.ComponentModel.ISupportInitialize)(this.radioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPassWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRadioButton radioButton1;
        private Telerik.WinControls.UI.RadRadioButton radioButton2;
        private System.Windows.Forms.Label ipl;
        private Telerik.WinControls.UI.RadTextBox ServerIP;
        private Telerik.WinControls.UI.RadTextBox ServerName;
        private System.Windows.Forms.Label namel;
        private Telerik.WinControls.UI.RadTextBox ServerUserName;
        private System.Windows.Forms.Label usernamel;
        private Telerik.WinControls.UI.RadTextBox ServerPassWord;
        private System.Windows.Forms.Label passwordl;
        private Telerik.WinControls.UI.RadButton TestButton;
    }
}
