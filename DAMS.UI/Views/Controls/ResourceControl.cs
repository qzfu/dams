using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAMS.Core.ClassFactory;
using DAMS.Core;
using DAMS.Models.DTO;
using DAMS.Interface;

namespace DAMS.UI.Views.Controls
{
    public partial class ResourceControl : UserControl
    {
        private List<ResourcesDTO> _dataSource = new List<ResourcesDTO>(); 
        public ResourceControl()
        {
            InitializeComponent();
            ResetQueryElement();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.ResetQueryElement();
        }

        private void ResetQueryElement()
        {
            this.QResourceType.Text = "";
            this.QDateType.SelectedIndex = 0;
            this.QBeginDate.Value = DateTime.Today.AddDays(-7);
            this.QEndDate.Value = DateTime.Today;
            this.QUserId.Text = "";
            this.QUserName.Text = "";
            this.QEquipmentNo.Text = "";
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            var queryItem = new ResourceQueryDTO
            {
                ResourceTypes = string.IsNullOrEmpty(this.QResourceType.Text) ? new List<string>() : this.QResourceType.Text.Split(',').ToList(),
                DateType = this.QDateType.Text,
                BeginDate = this.QBeginDate.Value,
                EndDate = this.QEndDate.Value,
                UserId = this.QUserId.Text,
                UserName = this.QUserId.Text,
                EquipmentNo = this.QEquipmentNo.Text
            };
            this._dataSource = Assembler<IResourceService>.Create().GetResourcesByQuery(queryItem);

            this.ManageGridPage.AutoGenerateColumns = false;
            this.ManageGridPage.DataSource = this._dataSource;
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            //this.ManageGridPage.EndEdit();

            var allChecked = true;

            for (int i = 0; i < this.ManageGridPage.Rows.Count; i++)
            {
                if (this.ManageGridPage.Rows[i].Cells[0].Value == "0" || this.ManageGridPage.Rows[i].Cells[0].Value == null || (bool)this.ManageGridPage.Rows[i].Cells[0].Value == false)
                {
                    allChecked = false;
                    break;
                }
            }

            if (allChecked)
            {
                this.UnSelectAll();
            }
            else
            {
                this.SelectAll();
            }

        }

        private void ManageGridPage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ManageGridPage.Columns[e.ColumnIndex].Name != "Player") return;

            var data =
                this._dataSource.FirstOrDefault(
                    x => x.ResourceId == (int) this.ManageGridPage.Rows[e.RowIndex].Cells[10].Value);

        }




        /// <summary>
        /// 全选
        /// </summary>
        private void SelectAll()
        {
            //结束列表的编辑状态,否则可能无法改变CheckBox的状态
            this.ManageGridPage.EndEdit();
            for (var i = 0; i < this.ManageGridPage.Rows.Count; i++)
            {
                this.ManageGridPage.Rows[i].Cells[0].Value = true;//设置为选中状态
            }
        }
        /// <summary>
        /// 取消全选
        /// </summary>
        private void UnSelectAll()
        {
            //结束列表的编辑状态,否则可能无法改变CheckBox的状态
            this.ManageGridPage.EndEdit();
            for (var i = 0; i < this.ManageGridPage.Rows.Count; i++)
            {
                this.ManageGridPage.Rows[i].Cells[0].Value = false;//设置为取消选中状态
            }
        }
    }
}
;