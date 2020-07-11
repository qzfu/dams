using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAMS.UI.Views.Controls.Setting;

namespace DAMS.UI.Views.Controls
{
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();
            menuTree.SelectedNode = menuTree.Nodes[0];
            this.ShowEnforceLow();
        }

        public SettingControl(int i)
        {
            if (i < 0 || i > 2)
            {
                i = 0;
            }
            InitializeComponent();
            menuTree.SelectedNode = menuTree.Nodes[i];
            this.SelectedNode(i);
            //this.ShowEnforceLow();
        }

        public void menuTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)  
            {
                this.SelectedNode(e.Node.Index);

                //if(e.Node.Index==0)
                //{
                //    this.ShowEnforceLow();
                //} 
                //else if (e.Node.Index == 1)
                //{
                //    this.ShowCollections();
                //}
                //else if (e.Node.Index == 2)
                //{
                //    this.UserInfoCollections();
                //}  
            }
        }

        private void SelectedNode(int index)
        {
            if (index == 0)
            {
                this.ShowEnforceLow();
            }
            else if (index == 1)
            {
                this.ShowCollections();
            }
            else if (index == 2)
            {
                this.UserInfoCollections();
            }  
        }

        /// <summary>
        /// 执法仪
        /// </summary>
        private void ShowEnforceLow()
        {
            this.setPanelContent.Controls.Clear();
            EnforceLawControl resControl = new EnforceLawControl();
            resControl.Dock = DockStyle.Fill;
            this.setPanelContent.Controls.Add(resControl);
        }

        /// <summary>
        /// 采集站
        /// </summary>
        private void ShowCollections()
        {
            this.setPanelContent.Controls.Clear();
            ConnectControl resControl = new ConnectControl();
            resControl.Dock = DockStyle.Fill;
            this.setPanelContent.Controls.Add(resControl);
        }

        /// <summary>
        /// 个人信息
        /// </summary>
        private void UserInfoCollections()
        {
            this.setPanelContent.Controls.Clear();
            UserInfoControl resControl = new UserInfoControl();
            resControl.Dock = DockStyle.Fill;
            this.setPanelContent.Controls.Add(resControl);
        }
    }
}
