namespace DAMS.UI.Views.Controls.Setting
{
    partial class UserInfoControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Warn3label = new System.Windows.Forms.Label();
            this.Warn2label = new System.Windows.Forms.Label();
            this.Warn1label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SaveButton = new Telerik.WinControls.UI.RadButton();
            this.label6 = new System.Windows.Forms.Label();
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ManaRootComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeButton = new Telerik.WinControls.UI.RadButton();
            this.UserInfoButton = new Telerik.WinControls.UI.RadButton();
            this.UserIdTextBox = new System.Windows.Forms.TextBox();
            this.OldPWTextBox = new System.Windows.Forms.TextBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.NewPWTextBox = new System.Windows.Forms.TextBox();
            this.NewPW2TextBox = new System.Windows.Forms.TextBox();
            this.departmentTextBox = new System.Windows.Forms.TextBox();
            this.CreatedTimeTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserInfoButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CreatedTimeTextBox);
            this.panel1.Controls.Add(this.departmentTextBox);
            this.panel1.Controls.Add(this.NewPW2TextBox);
            this.panel1.Controls.Add(this.NewPWTextBox);
            this.panel1.Controls.Add(this.UserNameTextBox);
            this.panel1.Controls.Add(this.OldPWTextBox);
            this.panel1.Controls.Add(this.UserIdTextBox);
            this.panel1.Controls.Add(this.Warn3label);
            this.panel1.Controls.Add(this.Warn2label);
            this.panel1.Controls.Add(this.Warn1label);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.GenderComboBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ManaRootComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 631);
            this.panel1.TabIndex = 5;
            // 
            // Warn3label
            // 
            this.Warn3label.AutoSize = true;
            this.Warn3label.ForeColor = System.Drawing.Color.Red;
            this.Warn3label.Location = new System.Drawing.Point(513, 175);
            this.Warn3label.Name = "Warn3label";
            this.Warn3label.Size = new System.Drawing.Size(105, 15);
            this.Warn3label.TabIndex = 36;
            this.Warn3label.Text = "*请输入新密码";
            // 
            // Warn2label
            // 
            this.Warn2label.AutoSize = true;
            this.Warn2label.ForeColor = System.Drawing.Color.Red;
            this.Warn2label.Location = new System.Drawing.Point(513, 246);
            this.Warn2label.Name = "Warn2label";
            this.Warn2label.Size = new System.Drawing.Size(135, 15);
            this.Warn2label.TabIndex = 35;
            this.Warn2label.Text = "*新密码输入不一致";
            // 
            // Warn1label
            // 
            this.Warn1label.AutoSize = true;
            this.Warn1label.ForeColor = System.Drawing.Color.Red;
            this.Warn1label.Location = new System.Drawing.Point(513, 109);
            this.Warn1label.Name = "Warn1label";
            this.Warn1label.Size = new System.Drawing.Size(135, 15);
            this.Warn1label.TabIndex = 34;
            this.Warn1label.Text = "*原密码输入不正确";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(131, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 32;
            this.label9.Text = "确认新密码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(161, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "新密码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "原密码";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(317, 477);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(67, 30);
            this.SaveButton.TabIndex = 27;
            this.SaveButton.Text = "保存";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "创建时间";
            // 
            // GenderComboBox
            // 
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.Items.AddRange(new object[] {
            "男",
            "女"});
            this.GenderComboBox.Location = new System.Drawing.Point(231, 344);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(256, 23);
            this.GenderComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "性别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "部门";
            // 
            // ManaRootComboBox
            // 
            this.ManaRootComboBox.FormattingEnabled = true;
            this.ManaRootComboBox.Location = new System.Drawing.Point(231, 205);
            this.ManaRootComboBox.Name = "ManaRootComboBox";
            this.ManaRootComboBox.Size = new System.Drawing.Size(256, 23);
            this.ManaRootComboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "人员权限";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(194, 16);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(102, 30);
            this.ChangeButton.TabIndex = 4;
            this.ChangeButton.Text = "修改密码";
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // UserInfoButton
            // 
            this.UserInfoButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.UserInfoButton.Location = new System.Drawing.Point(77, 16);
            this.UserInfoButton.Name = "UserInfoButton";
            this.UserInfoButton.Size = new System.Drawing.Size(102, 30);
            this.UserInfoButton.TabIndex = 3;
            this.UserInfoButton.Text = "个人信息";
            this.UserInfoButton.Click += new System.EventHandler(this.UserInfoButton_Click);
            // 
            // UserIdTextBox
            // 
            this.UserIdTextBox.Enabled = false;
            this.UserIdTextBox.Location = new System.Drawing.Point(231, 70);
            this.UserIdTextBox.Name = "UserIdTextBox";
            this.UserIdTextBox.Size = new System.Drawing.Size(256, 25);
            this.UserIdTextBox.TabIndex = 37;
            // 
            // OldPWTextBox
            // 
            this.OldPWTextBox.Location = new System.Drawing.Point(231, 105);
            this.OldPWTextBox.Name = "OldPWTextBox";
            this.OldPWTextBox.PasswordChar = '*';
            this.OldPWTextBox.Size = new System.Drawing.Size(256, 25);
            this.OldPWTextBox.TabIndex = 38;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(231, 136);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(256, 25);
            this.UserNameTextBox.TabIndex = 39;
            // 
            // NewPWTextBox
            // 
            this.NewPWTextBox.Location = new System.Drawing.Point(231, 171);
            this.NewPWTextBox.Name = "NewPWTextBox";
            this.NewPWTextBox.PasswordChar = '*';
            this.NewPWTextBox.Size = new System.Drawing.Size(256, 25);
            this.NewPWTextBox.TabIndex = 40;
            // 
            // NewPW2TextBox
            // 
            this.NewPW2TextBox.Location = new System.Drawing.Point(231, 242);
            this.NewPW2TextBox.Name = "NewPW2TextBox";
            this.NewPW2TextBox.PasswordChar = '*';
            this.NewPW2TextBox.Size = new System.Drawing.Size(256, 25);
            this.NewPW2TextBox.TabIndex = 41;
            // 
            // departmentTextBox
            // 
            this.departmentTextBox.Enabled = false;
            this.departmentTextBox.Location = new System.Drawing.Point(231, 273);
            this.departmentTextBox.Name = "departmentTextBox";
            this.departmentTextBox.Size = new System.Drawing.Size(256, 25);
            this.departmentTextBox.TabIndex = 42;
            // 
            // CreatedTimeTextBox
            // 
            this.CreatedTimeTextBox.Enabled = false;
            this.CreatedTimeTextBox.Location = new System.Drawing.Point(231, 410);
            this.CreatedTimeTextBox.Name = "CreatedTimeTextBox";
            this.CreatedTimeTextBox.Size = new System.Drawing.Size(256, 25);
            this.CreatedTimeTextBox.TabIndex = 43;
            // 
            // UserInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.UserInfoButton);
            this.Name = "UserInfoControl";
            this.Size = new System.Drawing.Size(933, 700);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserInfoButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton ChangeButton;
        private Telerik.WinControls.UI.RadButton UserInfoButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ManaRootComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadButton SaveButton;
        private System.Windows.Forms.Label Warn2label;
        private System.Windows.Forms.Label Warn1label;
        private System.Windows.Forms.Label Warn3label;
        private System.Windows.Forms.TextBox UserIdTextBox;
        private System.Windows.Forms.TextBox OldPWTextBox;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox NewPWTextBox;
        private System.Windows.Forms.TextBox NewPW2TextBox;
        private System.Windows.Forms.TextBox departmentTextBox;
        private System.Windows.Forms.TextBox CreatedTimeTextBox;
    }
}
