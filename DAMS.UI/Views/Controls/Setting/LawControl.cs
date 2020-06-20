using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAMS.UI.Views.Controls.Setting
{
    public partial class LawControl : UserControl
    {
        public LawControl()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Pen pen = new Pen(SystemColors.ControlDark);
            pen.DashStyle = DashStyle.Dot;
            e.Graphics.DrawLine(pen, 0, 0, 0, pnl.Height - 0);
            e.Graphics.DrawLine(pen, 0, 0, pnl.Width - 0, 0);
            e.Graphics.DrawLine(pen, pnl.Width - 1, pnl.Height - 1, 0, pnl.Height - 1);
            e.Graphics.DrawLine(pen, pnl.Width - 1, pnl.Height - 1, pnl.Width - 1, 0);
        }
    }
}
