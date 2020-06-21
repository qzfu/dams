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
            this.chartBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // chartBrowser
            // 
            this.chartBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBrowser.Location = new System.Drawing.Point(0, 0);
            this.chartBrowser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartBrowser.MinimumSize = new System.Drawing.Size(30, 30);
            this.chartBrowser.Name = "chartBrowser";
            this.chartBrowser.Size = new System.Drawing.Size(1494, 814);
            this.chartBrowser.TabIndex = 0;
            this.chartBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chartBrowser);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(1494, 814);
            this.Load += new System.EventHandler(this.MainControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser chartBrowser;
    }
}
