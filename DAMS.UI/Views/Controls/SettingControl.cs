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

        public void menuTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)  
            {
                if(e.Node.Index==0)
                {
                    this.ShowEnforceLow();
                } 
                else if (e.Node.Index == 1)
                {
                    this.ShowCollections();
                }  
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

    }
}
