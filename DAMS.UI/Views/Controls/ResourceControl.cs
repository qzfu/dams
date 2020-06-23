using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private MediaPlayerForm mediaPlayer;

        private List<ResourcesDTO> _dataSource = new List<ResourcesDTO>(); 
        public ResourceControl()
        {
            InitializeComponent();
            ResetQueryElement();
          
        }

        /// <summary>
        /// 重置按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.ResetQueryElement();
        }

        /// <summary>
        /// 重置查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 查询按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 全选/反选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckButton_Click(object sender, EventArgs e)
        {
            //this.ManageGridPage.EndEdit();

            var allChecked = true;

            for (int i = 0; i < this.ManageGridPage.Rows.Count; i++)
            {
                if (this.ManageGridPage.Rows[i].Cells[0].Value == "0")
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

        /// <summary>
        /// 博凡按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageGridPage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ManageGridPage.Columns[e.ColumnIndex].Name != "Player") return;

            var data =
                this._dataSource.FirstOrDefault(
                    x => x.ResourceId == (int) this.ManageGridPage.Rows[e.RowIndex].Cells[10].Value);


            if (string.IsNullOrEmpty(data.Extension) || !_resourceTypes.Any(x => x.Contains(data.Extension)))
            {
                MessageBox.Show("无法播放此文件！");
                return;
            }
            
            if (data.ResourceType != (int) DAMS.Common.EnumData.ResourceType.Video &&
                data.ResourceType != (int)DAMS.Common.EnumData.ResourceType.VoiceFrequency)
            {
                MessageBox.Show("无法播放此文件！");
                return;
            }

            if (mediaPlayer != null)
            {
                mediaPlayer.Dispose();
            }
            
            mediaPlayer = new MediaPlayerForm(data.FileName);
            mediaPlayer.Show(this);
            //Application.Run(mediaPlayer);
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
                this.ManageGridPage.Rows[i].Cells[0].Value = "1";//设置为选中状态
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
                this.ManageGridPage.Rows[i].Cells[0].Value = "0";//设置为取消选中状态
            }
        }

        /// <summary>
        /// 获取选中行数据
        /// </summary>
        private List<ResourcesDTO> GetSelectData()
        {
            var result = new List<ResourcesDTO>();
            for (var i = 0; i < this.ManageGridPage.Rows.Count; i++)
            {
                if (this.ManageGridPage.Rows[i].Cells[0].Value == "1")
                {
                    int resourceId = (int)this.ManageGridPage.Rows[i].Cells[10].Value;
                    var tempData = this._dataSource.FirstOrDefault(x => x.ResourceId == resourceId);
                    if (tempData != null)
                    {
                        result.Add(tempData);
                    }
                }
            }
            return result;
        }

        private List<string> _resourceTypes =
            @".asf、bai.wma、.wmv、.wm、.avi、.mpg、.mpeg、.m1v、.mp2、.mp3、.mpa、.mpe、.m3u、.mid、.midi、.rmi、
            .aif、.aifc、.aiff、.au、.snd、.wav、.cda、.ivf、.mov、.m4a、.mp4、.m4v、.mp4v、.3g2、.3gp2、.3gp、.3gpp、
            .aac、.adt、.adts、.m2ts、rmvb"
                .Split('、').ToList();


        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var datas = GetSelectData().ToList();
            var result = Assembler<IResourceService>.Create().DeleteReoucrceByIds(datas.Select(x => x.ResourceId).ToList());

            foreach (var data in datas)
            {
                if (File.Exists(data.FilePath))
                {
                    File.Delete(data.FilePath);
                }
            }

            //重新查询
            this.QueryButton_Click(sender, e);

            if (result)
            {
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("删除成功！");
            }
        }

    }
}
;