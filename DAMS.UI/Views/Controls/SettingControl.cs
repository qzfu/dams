using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAMS.UI.Views.Controls
{
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();
        }

        public void menuTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)  
            {
                if(e.Node.Index==0)
                {  
                    this.setPanelContent.Controls.Clear();
                    EnforceLawControl resControl = new EnforceLawControl();
                    resControl.Dock = DockStyle.Fill;
                    this.setPanelContent.Controls.Add(resControl);
                }  
                
            }
        }
    }
}
