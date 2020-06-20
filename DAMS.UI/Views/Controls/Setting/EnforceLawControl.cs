﻿using System;
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
    public partial class EnforceLawControl : UserControl
    {
        public EnforceLawControl()
        {
            InitializeComponent();
        }

        private void LawButton_Click(object sender, EventArgs e)
        {
            this.LawButton.Enabled = false;
            this.CollectButton.Enabled = true;

            this.panel1.Controls.Clear();

            LawControl resControl = new LawControl();
            resControl.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(resControl);
        }
    }
}
