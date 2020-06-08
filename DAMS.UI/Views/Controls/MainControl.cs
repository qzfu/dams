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
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
            this.mianList.Clear(); 
            bindListView();
        }
        private void bindListView() 
        {
            var maxListCount = 16;
            var imageLists = this.resImageList.Images;
            for (int i = 0; i < maxListCount; i++)
            {
                mianList.Items.Add((i+1).ToString(), i);
                mianList.Items[i].ImageIndex = 0;
                mianList.Items[i].Name = imageLists[0].ToString();
            }
        }
    }
}
