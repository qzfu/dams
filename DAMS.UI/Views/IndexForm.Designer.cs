namespace DAMS.UI.Views
{
    partial class IndexForm
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
            this.components = new System.ComponentModel.Container();
            this.titPanel = new System.Windows.Forms.Panel();
            this.labTime = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.labUserInfo = new System.Windows.Forms.Label();
            this.btnSystem = new System.Windows.Forms.Button();
            this.btnResource = new System.Windows.Forms.Button();
            this.titLab = new System.Windows.Forms.Label();
            this.systemTimer = new System.Windows.Forms.Timer(this.components);
            this.btmDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.mPanel = new Telerik.WinControls.UI.RadPanel();
            this.titPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btmDock)).BeginInit();
            this.btmDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // titPanel
            // 
            this.titPanel.BackgroundImage = global::DAMS.UI.Properties.Resources.tit_bg2;
            this.titPanel.Controls.Add(this.labTime);
            this.titPanel.Controls.Add(this.btnMin);
            this.titPanel.Controls.Add(this.labUserInfo);
            this.titPanel.Controls.Add(this.btnSystem);
            this.titPanel.Controls.Add(this.btnResource);
            this.titPanel.Controls.Add(this.titLab);
            this.titPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titPanel.Location = new System.Drawing.Point(0, 0);
            this.titPanel.Name = "titPanel";
            this.titPanel.Size = new System.Drawing.Size(996, 83);
            this.titPanel.TabIndex = 2;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.BackColor = System.Drawing.Color.Transparent;
            this.labTime.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labTime.ForeColor = System.Drawing.Color.White;
            this.labTime.Location = new System.Drawing.Point(808, 10);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(38, 16);
            this.labTime.TabIndex = 7;
            this.labTime.Text = "label1";
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = global::DAMS.UI.Properties.Resources.forb_16_lan;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Location = new System.Drawing.Point(950, 10);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(16, 16);
            this.btnMin.TabIndex = 6;
            this.btnMin.Text = "button1";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // labUserInfo
            // 
            this.labUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.labUserInfo.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserInfo.ForeColor = System.Drawing.Color.Transparent;
            this.labUserInfo.Image = global::DAMS.UI.Properties.Resources.UserManage;
            this.labUserInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labUserInfo.Location = new System.Drawing.Point(809, 41);
            this.labUserInfo.Margin = new System.Windows.Forms.Padding(0);
            this.labUserInfo.Name = "labUserInfo";
            this.labUserInfo.Size = new System.Drawing.Size(139, 30);
            this.labUserInfo.TabIndex = 5;
            this.labUserInfo.Text = "Admin,您好！";
            this.labUserInfo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnSystem
            // 
            this.btnSystem.AutoEllipsis = true;
            this.btnSystem.BackColor = System.Drawing.Color.Transparent;
            this.btnSystem.BackgroundImage = global::DAMS.UI.Properties.Resources.main_btn;
            this.btnSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSystem.FlatAppearance.BorderSize = 0;
            this.btnSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystem.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSystem.ForeColor = System.Drawing.Color.White;
            this.btnSystem.Image = global::DAMS.UI.Properties.Resources.res1;
            this.btnSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystem.Location = new System.Drawing.Point(644, 28);
            this.btnSystem.Margin = new System.Windows.Forms.Padding(0);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSystem.Size = new System.Drawing.Size(125, 46);
            this.btnSystem.TabIndex = 4;
            this.btnSystem.Text = "系统设置";
            this.btnSystem.UseVisualStyleBackColor = false;
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);
            // 
            // btnResource
            // 
            this.btnResource.AutoEllipsis = true;
            this.btnResource.BackColor = System.Drawing.Color.Transparent;
            this.btnResource.BackgroundImage = global::DAMS.UI.Properties.Resources.main_btn;
            this.btnResource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResource.FlatAppearance.BorderSize = 0;
            this.btnResource.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnResource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResource.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnResource.ForeColor = System.Drawing.Color.White;
            this.btnResource.Image = global::DAMS.UI.Properties.Resources.res1;
            this.btnResource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResource.Location = new System.Drawing.Point(491, 28);
            this.btnResource.Margin = new System.Windows.Forms.Padding(0);
            this.btnResource.Name = "btnResource";
            this.btnResource.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnResource.Size = new System.Drawing.Size(125, 46);
            this.btnResource.TabIndex = 3;
            this.btnResource.Text = "资源管理";
            this.btnResource.UseVisualStyleBackColor = false;
            this.btnResource.Click += new System.EventHandler(this.btnResource_Click);
            // 
            // titLab
            // 
            this.titLab.AutoSize = true;
            this.titLab.BackColor = System.Drawing.Color.Transparent;
            this.titLab.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.titLab.ForeColor = System.Drawing.Color.Transparent;
            this.titLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titLab.Location = new System.Drawing.Point(59, 24);
            this.titLab.Margin = new System.Windows.Forms.Padding(0);
            this.titLab.Name = "titLab";
            this.titLab.Size = new System.Drawing.Size(254, 31);
            this.titLab.TabIndex = 1;
            this.titLab.Text = "智能数据采集管理系统";
            this.titLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // systemTimer
            // 
            this.systemTimer.Enabled = true;
            this.systemTimer.Interval = 1000;
            this.systemTimer.Tick += new System.EventHandler(this.systemTimer_Tick);
            // 
            // btmDock
            // 
            this.btmDock.BackgroundImage = global::DAMS.UI.Properties.Resources.tit_bg1;
            this.btmDock.Controls.Add(this.documentContainer1);
            this.btmDock.IsCleanUpTarget = true;
            this.btmDock.Location = new System.Drawing.Point(0, 626);
            this.btmDock.MainDocumentContainer = this.documentContainer1;
            this.btmDock.Name = "btmDock";
            // 
            // 
            // 
            this.btmDock.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.btmDock.Size = new System.Drawing.Size(996, 31);
            this.btmDock.TabIndex = 3;
            this.btmDock.TabStop = false;
            this.btmDock.Text = "radDock1";
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // mPanel
            // 
            this.mPanel.Location = new System.Drawing.Point(0, 84);
            this.mPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mPanel.Name = "mPanel";
            this.mPanel.Padding = new System.Windows.Forms.Padding(15);
            this.mPanel.Size = new System.Drawing.Size(996, 543);
            this.mPanel.TabIndex = 1;
            // 
            // IndexForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(996, 658);
            this.ControlBox = false;
            this.Controls.Add(this.btmDock);
            this.Controls.Add(this.titPanel);
            this.Controls.Add(this.mPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndexForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IndexForm";
            this.Load += new System.EventHandler(this.IndexForm_Load);
            this.titPanel.ResumeLayout(false);
            this.titPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btmDock)).EndInit();
            this.btmDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titPanel;
        private System.Windows.Forms.Label titLab;
        private System.Windows.Forms.Button btnResource;
        private System.Windows.Forms.Label labUserInfo;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Timer systemTimer;
        private System.Windows.Forms.Label labTime;
        private Telerik.WinControls.UI.Docking.RadDock btmDock;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.RadPanel mPanel;

    }
}
