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
using DAMS.Interface;

namespace DAMS.UI.Views.Controls.Setting
{
    public partial class CollectControl : UserControl
    {
        private IResourceService setService = Assembler<IResourceService>.Create();
        public CollectControl()
        {
            InitializeComponent();

            this.SIzeList.SelectedIndex = 0;
            this.radDropDownList2.SelectedIndex = 0;
            this.radDropDownList3.SelectedIndex = 0;
            this.radDropDownList4.SelectedIndex = 0;
            this.radDropDownList5.SelectedIndex = 0;

            this.GetSettingData();
        }

        private void GetSettingData()
        {
            var data = setService.GetWinSize();
            if (data != null)
            {
                this.SIzeList.Text = data.ItemText;
            }

            data = setService.GetIndexCount();
            if (data != null)
            {
                this.AmountTextBox.Text = data.ItemText;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.SaveSettingData();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            this.SaveSettingData();
            Environment.Exit(0);
        }

        private void SaveSettingData()
        {
            try
            {
                var text = this.SIzeList.Text;
                var sizes = text.Split('×').ToList();
                if (string.IsNullOrEmpty(text) || sizes.Count != 2)
                {
                    MessageBox.Show("请选择分辨率!");
                }

                var width = Convert.ToInt32(sizes[0]);
                var height = Convert.ToInt32(sizes[1]);

                setService.SetWinSize(width + "," + height, text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("分辨率长高必须是数字!");
                throw ex;
            }


            try
            {
                var text = this.AmountTextBox.Text;
                var count = Convert.ToInt32(text);
                if (string.IsNullOrEmpty(text) || count <= 0)
                {
                    MessageBox.Show("请填写大于0的数字!");
                }

                setService.SetIndexCount(count.ToString(), text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请填写大于0的数字!");
                throw ex;
            }

            MessageBox.Show("保存成功!");
        }

    }
}
