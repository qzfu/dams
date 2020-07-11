using System;
namespace DAMS.UI.Views.Controls
{
    partial class ResourceControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Telerik.WinControls.UI.RadCheckedListDataItem radCheckedListDataItem1 = new Telerik.WinControls.UI.RadCheckedListDataItem();
            Telerik.WinControls.UI.RadCheckedListDataItem radCheckedListDataItem2 = new Telerik.WinControls.UI.RadCheckedListDataItem();
            Telerik.WinControls.UI.RadCheckedListDataItem radCheckedListDataItem3 = new Telerik.WinControls.UI.RadCheckedListDataItem();
            this.ManageGridPage = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.object_e53cd9ac_f4fb_4c07_8ae9_8bd9a5fb7ca2 = new Telerik.WinControls.RootRadElement();
            this.QResourceType = new Telerik.WinControls.UI.RadCheckedDropDownList();
            this.QDateType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.QBeginDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.QEndDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.QUserId = new Telerik.WinControls.UI.RadTextBox();
            this.QUserName = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.QEquipmentNo = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CheckButton = new Telerik.WinControls.UI.RadButton();
            this.DeleteButton = new Telerik.WinControls.UI.RadButton();
            this.DownLoadButton = new Telerik.WinControls.UI.RadButton();
            this.ResetButton = new Telerik.WinControls.UI.RadButton();
            this.QueryButton = new Telerik.WinControls.UI.RadButton();
            this.label7 = new System.Windows.Forms.Label();
            this.CheckRecord = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ResourceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ResourceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ManageGridPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QResourceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUserId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QEquipmentNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownLoadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResetButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryButton)).BeginInit();
            this.SuspendLayout();
            // 
            // ManageGridPage
            // 
            this.ManageGridPage.AllowUserToAddRows = false;
            this.ManageGridPage.AllowUserToDeleteRows = false;
            this.ManageGridPage.AllowUserToResizeRows = false;
            this.ManageGridPage.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.ManageGridPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ManageGridPage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ManageGridPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManageGridPage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckRecord,
            this.ResourceType,
            this.UserId,
            this.EquipmentNo,
            this.UserName,
            this.DepartId,
            this.UploadTime,
            this.UploadTime1,
            this.FileName,
            this.Player,
            this.ResourceId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ManageGridPage.DefaultCellStyle = dataGridViewCellStyle2;
            this.ManageGridPage.GridColor = System.Drawing.Color.LavenderBlush;
            this.ManageGridPage.Location = new System.Drawing.Point(0, 138);
            this.ManageGridPage.Margin = new System.Windows.Forms.Padding(0);
            this.ManageGridPage.Name = "ManageGridPage";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ManageGridPage.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ManageGridPage.RowHeadersVisible = false;
            this.ManageGridPage.RowTemplate.Height = 23;
            this.ManageGridPage.Size = new System.Drawing.Size(1323, 525);
            this.ManageGridPage.TabIndex = 0;
            this.ManageGridPage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ManageGridPage_CellContentClick);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 20);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 15);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "文件类型";
            // 
            // object_e53cd9ac_f4fb_4c07_8ae9_8bd9a5fb7ca2
            // 
            this.object_e53cd9ac_f4fb_4c07_8ae9_8bd9a5fb7ca2.Name = "object_e53cd9ac_f4fb_4c07_8ae9_8bd9a5fb7ca2";
            this.object_e53cd9ac_f4fb_4c07_8ae9_8bd9a5fb7ca2.StretchHorizontally = true;
            this.object_e53cd9ac_f4fb_4c07_8ae9_8bd9a5fb7ca2.StretchVertically = true;
            // 
            // QResourceType
            // 
            this.QResourceType.DropDownAnimationEnabled = false;
            this.QResourceType.DropDownHeight = 110;
            radCheckedListDataItem1.Text = "视频";
            radCheckedListDataItem2.Text = "音频";
            radCheckedListDataItem3.Text = "文档";
            this.QResourceType.Items.Add(radCheckedListDataItem1);
            this.QResourceType.Items.Add(radCheckedListDataItem2);
            this.QResourceType.Items.Add(radCheckedListDataItem3);
            this.QResourceType.Location = new System.Drawing.Point(95, 15);
            this.QResourceType.Margin = new System.Windows.Forms.Padding(4);
            this.QResourceType.Name = "QResourceType";
            this.QResourceType.ShowCheckAllItems = true;
            this.QResourceType.Size = new System.Drawing.Size(161, 20);
            this.QResourceType.TabIndex = 2;
            ((Telerik.WinControls.UI.RadCheckedDropDownListElement)(this.QResourceType.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.UI.RadCheckedDropDownListElement)(this.QResourceType.GetChildAt(0))).CaseSensitive = false;
            // 
            // QDateType
            // 
            this.QDateType.FormattingEnabled = true;
            this.QDateType.Items.AddRange(new object[] {
            "拍摄时间",
            "上传时间"});
            this.QDateType.Location = new System.Drawing.Point(382, 15);
            this.QDateType.Margin = new System.Windows.Forms.Padding(4);
            this.QDateType.Name = "QDateType";
            this.QDateType.Size = new System.Drawing.Size(165, 23);
            this.QDateType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(567, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "从";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(744, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "到";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "人员编号";
            // 
            // QBeginDate
            // 
            this.QBeginDate.Location = new System.Drawing.Point(593, 16);
            this.QBeginDate.Margin = new System.Windows.Forms.Padding(4);
            this.QBeginDate.Name = "QBeginDate";
            this.QBeginDate.Size = new System.Drawing.Size(142, 24);
            this.QBeginDate.TabIndex = 10;
            this.QBeginDate.TabStop = false;
            this.QBeginDate.Text = "2020年6月6日";
            this.QBeginDate.Value = new System.DateTime(2020, 6, 6, 0, 0, 0, 0);
            // 
            // QEndDate
            // 
            this.QEndDate.Location = new System.Drawing.Point(775, 16);
            this.QEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.QEndDate.Name = "QEndDate";
            this.QEndDate.Size = new System.Drawing.Size(151, 24);
            this.QEndDate.TabIndex = 11;
            this.QEndDate.TabStop = false;
            this.QEndDate.Text = "2020年6月13日";
            this.QEndDate.Value = new System.DateTime(2020, 6, 13, 0, 0, 0, 0);
            // 
            // QUserId
            // 
            this.QUserId.Location = new System.Drawing.Point(95, 59);
            this.QUserId.Margin = new System.Windows.Forms.Padding(4);
            this.QUserId.Name = "QUserId";
            this.QUserId.Size = new System.Drawing.Size(161, 24);
            this.QUserId.TabIndex = 12;
            // 
            // QUserName
            // 
            this.QUserName.Location = new System.Drawing.Point(382, 62);
            this.QUserName.Margin = new System.Windows.Forms.Padding(4);
            this.QUserName.Name = "QUserName";
            this.QUserName.Size = new System.Drawing.Size(165, 24);
            this.QUserName.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "人员姓名";
            // 
            // QEquipmentNo
            // 
            this.QEquipmentNo.Location = new System.Drawing.Point(693, 65);
            this.QEquipmentNo.Margin = new System.Windows.Forms.Padding(4);
            this.QEquipmentNo.Name = "QEquipmentNo";
            this.QEquipmentNo.Size = new System.Drawing.Size(234, 24);
            this.QEquipmentNo.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(614, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "设备编号";
            // 
            // CheckButton
            // 
            this.CheckButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckButton.Location = new System.Drawing.Point(23, 104);
            this.CheckButton.Margin = new System.Windows.Forms.Padding(4);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(100, 30);
            this.CheckButton.TabIndex = 17;
            this.CheckButton.Text = "全选/反选";
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteButton.Location = new System.Drawing.Point(248, 104);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 30);
            this.DeleteButton.TabIndex = 18;
            this.DeleteButton.Text = "删除";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DownLoadButton
            // 
            this.DownLoadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DownLoadButton.Location = new System.Drawing.Point(395, 104);
            this.DownLoadButton.Margin = new System.Windows.Forms.Padding(4);
            this.DownLoadButton.Name = "DownLoadButton";
            this.DownLoadButton.Size = new System.Drawing.Size(100, 30);
            this.DownLoadButton.TabIndex = 19;
            this.DownLoadButton.Text = "下载";
            this.DownLoadButton.Visible = false;
            // 
            // ResetButton
            // 
            this.ResetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetButton.Location = new System.Drawing.Point(638, 104);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(4);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(100, 30);
            this.ResetButton.TabIndex = 20;
            this.ResetButton.Text = "重置";
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // QueryButton
            // 
            this.QueryButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QueryButton.Location = new System.Drawing.Point(827, 104);
            this.QueryButton.Margin = new System.Windows.Forms.Padding(4);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(100, 30);
            this.QueryButton.TabIndex = 21;
            this.QueryButton.Text = "搜索";
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 19);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "时间类型";
            // 
            // CheckRecord
            // 
            this.CheckRecord.FalseValue = "0";
            this.CheckRecord.Frozen = true;
            this.CheckRecord.HeaderText = "";
            this.CheckRecord.Name = "CheckRecord";
            this.CheckRecord.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckRecord.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CheckRecord.TrueValue = "1";
            this.CheckRecord.Width = 50;
            // 
            // ResourceType
            // 
            this.ResourceType.DataPropertyName = "ResourceName";
            this.ResourceType.HeaderText = "文件类型";
            this.ResourceType.Name = "ResourceType";
            this.ResourceType.ReadOnly = true;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "人员编号";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            // 
            // EquipmentNo
            // 
            this.EquipmentNo.DataPropertyName = "DeviceInfo";
            this.EquipmentNo.HeaderText = "设备编号";
            this.EquipmentNo.Name = "EquipmentNo";
            this.EquipmentNo.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "操作人员";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // DepartId
            // 
            this.DepartId.DataPropertyName = "DepartId";
            this.DepartId.HeaderText = "部门";
            this.DepartId.Name = "DepartId";
            this.DepartId.ReadOnly = true;
            // 
            // UploadTime
            // 
            this.UploadTime.DataPropertyName = "UploadTime";
            this.UploadTime.HeaderText = "拍摄时间";
            this.UploadTime.Name = "UploadTime";
            this.UploadTime.ReadOnly = true;
            // 
            // UploadTime1
            // 
            this.UploadTime1.DataPropertyName = "UploadTime";
            this.UploadTime1.HeaderText = "上传时间";
            this.UploadTime1.Name = "UploadTime1";
            this.UploadTime1.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "Alias";
            this.FileName.HeaderText = "文件别名";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 160;
            // 
            // Player
            // 
            this.Player.HeaderText = "播放";
            this.Player.Name = "Player";
            this.Player.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Player.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Player.Text = "播放";
            this.Player.ToolTipText = "播放视频";
            this.Player.UseColumnTextForButtonValue = true;
            this.Player.Width = 80;
            // 
            // ResourceId
            // 
            this.ResourceId.DataPropertyName = "ResourceId";
            this.ResourceId.HeaderText = "id";
            this.ResourceId.Name = "ResourceId";
            this.ResourceId.Visible = false;
            // 
            // ResourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.QueryButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.DownLoadButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.QEquipmentNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.QUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.QUserId);
            this.Controls.Add(this.QEndDate);
            this.Controls.Add(this.QBeginDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QDateType);
            this.Controls.Add(this.QResourceType);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ManageGridPage);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ResourceControl";
            this.Size = new System.Drawing.Size(1328, 679);
            ((System.ComponentModel.ISupportInitialize)(this.ManageGridPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QResourceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUserId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QEquipmentNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownLoadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResetButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ManageGridPage;
        private System.Windows.Forms.Label Label1;
        private Telerik.WinControls.RootRadElement object_e53cd9ac_f4fb_4c07_8ae9_8bd9a5fb7ca2;
        private Telerik.WinControls.UI.RadCheckedDropDownList QResourceType;
        private System.Windows.Forms.ComboBox QDateType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadDateTimePicker QBeginDate;
        private Telerik.WinControls.UI.RadDateTimePicker QEndDate;
        private Telerik.WinControls.UI.RadTextBox QUserId;
        private Telerik.WinControls.UI.RadTextBox QUserName;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadTextBox QEquipmentNo;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadButton CheckButton;
        private Telerik.WinControls.UI.RadButton DeleteButton;
        private Telerik.WinControls.UI.RadButton DownLoadButton;
        private Telerik.WinControls.UI.RadButton ResetButton;
        private Telerik.WinControls.UI.RadButton QueryButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResourceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewButtonColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResourceId;
    }
}
