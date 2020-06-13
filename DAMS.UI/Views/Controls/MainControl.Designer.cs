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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.mianList = new System.Windows.Forms.ListView();
            this.resImageList = new System.Windows.Forms.ImageList(this.components);
            this.txtRead = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mianList
            // 
            this.mianList.BackgroundImageTiled = true;
            this.mianList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mianList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.mianList.LargeImageList = this.resImageList;
            this.mianList.Location = new System.Drawing.Point(0, 0);
            this.mianList.Margin = new System.Windows.Forms.Padding(20);
            this.mianList.Name = "mianList";
            this.mianList.Size = new System.Drawing.Size(996, 543);
            this.mianList.TabIndex = 0;
            this.mianList.UseCompatibleStateImageBehavior = false;
            // 
            // resImageList
            // 
            this.resImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("resImageList.ImageStream")));
            this.resImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.resImageList.Images.SetKeyName(0, "flat_home2.png");
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(90, 165);
            this.txtRead.Name = "txtRead";
            this.txtRead.Size = new System.Drawing.Size(339, 21);
            this.txtRead.TabIndex = 1;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtRead);
            this.Controls.Add(this.mianList);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(996, 543);
            this.Load += new System.EventHandler(this.MainControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView mianList;
        private System.Windows.Forms.ImageList resImageList;
        private System.Windows.Forms.TextBox txtRead;
    }
}
