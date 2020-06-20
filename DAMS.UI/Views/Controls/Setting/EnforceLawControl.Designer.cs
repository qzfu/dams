namespace DAMS.UI.Views.Controls
{
    partial class EnforceLawControl
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
            this.LawButton = new Telerik.WinControls.UI.RadButton();
            this.CollectButton = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LawButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectButton)).BeginInit();
            this.SuspendLayout();
            // 
            // LawButton
            // 
            this.LawButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LawButton.Location = new System.Drawing.Point(26, 19);
            this.LawButton.Name = "LawButton";
            this.LawButton.Size = new System.Drawing.Size(102, 30);
            this.LawButton.TabIndex = 0;
            this.LawButton.Text = "执法仪设置";
            this.LawButton.Click += new System.EventHandler(this.LawButton_Click);
            // 
            // CollectButton
            // 
            this.CollectButton.Location = new System.Drawing.Point(143, 19);
            this.CollectButton.Name = "CollectButton";
            this.CollectButton.Size = new System.Drawing.Size(102, 30);
            this.CollectButton.TabIndex = 1;
            this.CollectButton.Text = "采集站设置";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 485);
            this.panel1.TabIndex = 2;
            // 
            // EnforceLawControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CollectButton);
            this.Controls.Add(this.LawButton);
            this.Name = "EnforceLawControl";
            this.Size = new System.Drawing.Size(650, 544);
            ((System.ComponentModel.ISupportInitialize)(this.LawButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton LawButton;
        private Telerik.WinControls.UI.RadButton CollectButton;
        private System.Windows.Forms.Panel panel1;
    }
}
