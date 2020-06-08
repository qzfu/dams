namespace DAMS.UI.Views.Controls
{
    partial class MainControl
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("resList", System.Windows.Forms.HorizontalAlignment.Left);
            this.mianList = new System.Windows.Forms.ListView();
            this.EquipmentId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // mianList
            // 
            this.mianList.BackgroundImage = global::DAMS.UI.Properties.Resources.flat_home2;
            this.mianList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EquipmentId});
            listViewGroup1.Header = "resList";
            listViewGroup1.Name = "resList";
            this.mianList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.mianList.Location = new System.Drawing.Point(0, 0);
            this.mianList.Margin = new System.Windows.Forms.Padding(20);
            this.mianList.Name = "mianList";
            this.mianList.Size = new System.Drawing.Size(996, 543);
            this.mianList.TabIndex = 0;
            this.mianList.UseCompatibleStateImageBehavior = false;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.mianList);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(996, 543);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView mianList;
        private System.Windows.Forms.ColumnHeader EquipmentId;
    }
}
