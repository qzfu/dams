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
using DAMS.Core.ClassFactory;
using DAMS.Interface;
using DAMS.Models;

namespace DAMS.UI.Views.Controls.Setting
{
    public partial class LawControl : UserControl
    {
        private IEquipmentService equipmentService = Assembler<IEquipmentService>.Create();
        public LawControl()
        {
            InitializeComponent();
            this.QueryData();
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

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.QueryData();
        }

        public void QueryData()
        {
            var datas = equipmentService.GetEquipments();
            this.relationGridView.AutoGenerateColumns = false;
            this.relationGridView.DataSource = datas;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            var equipments = new List<Equipments>();
            for (int i = 0; i < this.relationGridView.Rows.Count; i++)
            {
                var equipment = new Equipments
                {
                    EquipmentNo = this.relationGridView.Rows[i].Cells[0].Value.ToString(),
                    Name = this.relationGridView.Rows[i].Cells[1].Value.ToString()
                };
                equipments.Add(equipment);
            }
            var result = equipmentService.SaveUserNames(equipments);
            if (result)
            {
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
