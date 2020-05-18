using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmj
{
    public partial class ParameterSetting : UserControl
    {
        public ParameterSetting()
        {
            InitializeComponent();
        }

        private void btnGetSystemTime_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ParameterSetting_Load(object sender, EventArgs e)
        {
            //灰度
            cmbGrayList.DataSource = CmbDataItemFactory.GetGrayList();
            //喷头电压
            cmbVList.DataSource = CmbDataItemFactory.GetVList();
            //喷头选择
            cmbPrintList.DataSource = CmbDataItemFactory.GetPrintList();
            //自动关机
            cmbShutdownList.DataSource = CmbDataItemFactory.GetShutdownList();
            //打印文件
            cmbFileList.DataSource = CmbDataItemFactory.GetPaperList();
            //闲置设置
            cmbLeaveTime.DataSource = CmbDataItemFactory.GetLeaveTimeList();
            //脉冲宽度
            cmbPulseWidth.DataSource = CmbDataItemFactory.GetPulseWidthList();
            //保留参数
            cmbParameter2.DataSource = CmbDataItemFactory.GetRetainParameterList();
        }
    }
}
