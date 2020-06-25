namespace DAMS.UI.Views.Controls
{
    partial class SettingControl
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("执法仪设置");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("采集站设置");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("部门管理");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("用户管理");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("日志查询");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingControl));
            this.setPanelMenu = new System.Windows.Forms.Panel();
            this.menuTree = new System.Windows.Forms.TreeView();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.setPanelContent = new System.Windows.Forms.Panel();
            this.setPanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // setPanelMenu
            // 
            this.setPanelMenu.Controls.Add(this.menuTree);
            this.setPanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.setPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.setPanelMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.setPanelMenu.Name = "setPanelMenu";
            this.setPanelMenu.Size = new System.Drawing.Size(300, 815);
            this.setPanelMenu.TabIndex = 0;
            // 
            // menuTree
            // 
            this.menuTree.BackColor = System.Drawing.SystemColors.Menu;
            this.menuTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.menuTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuTree.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.menuTree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuTree.ImageIndex = 0;
            this.menuTree.ImageList = this.treeImageList;
            this.menuTree.ItemHeight = 25;
            this.menuTree.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.menuTree.Location = new System.Drawing.Point(0, 0);
            this.menuTree.Margin = new System.Windows.Forms.Padding(0);
            this.menuTree.Name = "menuTree";
            treeNode1.ImageKey = "Down_Open_24.png";
            treeNode1.Name = "node1";
            treeNode1.SelectedImageKey = "Right_Close_24.png";
            treeNode1.Text = "执法仪设置";
            treeNode2.ImageKey = "Down_Open_24.png";
            treeNode2.Name = "Node2";
            treeNode2.SelectedImageKey = "Right_Close_24.png";
            treeNode2.Text = "采集站设置";
            treeNode3.ImageKey = "Down_Open_24.png";
            treeNode3.Name = "node3";
            treeNode3.SelectedImageKey = "Right_Close_24.png";
            treeNode3.Text = "部门管理";
            treeNode4.ImageKey = "Down_Open_24.png";
            treeNode4.Name = "node4";
            treeNode4.SelectedImageKey = "Right_Close_24.png";
            treeNode4.Text = "用户管理";
            treeNode5.ImageKey = "Down_Open_24.png";
            treeNode5.Name = "node5";
            treeNode5.SelectedImageKey = "Right_Close_24.png";
            treeNode5.Text = "日志查询";
            this.menuTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.menuTree.SelectedImageIndex = 0;
            this.menuTree.Size = new System.Drawing.Size(300, 815);
            this.menuTree.StateImageList = this.treeImageList;
            this.menuTree.TabIndex = 0;
            this.menuTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.menuTree_AfterSelect);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "Down_Open_24.png");
            this.treeImageList.Images.SetKeyName(1, "Right_Close_24.png");
            // 
            // setPanelContent
            // 
            this.setPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setPanelContent.Location = new System.Drawing.Point(300, 0);
            this.setPanelContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.setPanelContent.Name = "setPanelContent";
            this.setPanelContent.Padding = new System.Windows.Forms.Padding(3);
            this.setPanelContent.Size = new System.Drawing.Size(1194, 815);
            this.setPanelContent.TabIndex = 1;
            // 
            // SettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.setPanelContent);
            this.Controls.Add(this.setPanelMenu);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SettingControl";
            this.Size = new System.Drawing.Size(1494, 815);
            this.setPanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel setPanelMenu;
        private System.Windows.Forms.TreeView menuTree;
        private System.Windows.Forms.Panel setPanelContent;
        private System.Windows.Forms.ImageList treeImageList;
    }
}
