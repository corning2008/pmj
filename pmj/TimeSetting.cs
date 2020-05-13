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

    public interface ITimeSetting
    {
        void Deal(string guid,TimeSettingParameter parameter);
    }

    public partial class TimeSetting : UserControl
    {
        private string _guid;
        private ITimeSetting _timeSetting;
        private string _format;
        private int _size;

        public TimeSetting(ITimeSetting timeSetting,TimeSettingParameter parameter)
        {
            InitializeComponent();
            //样式
            this._guid = Guid.NewGuid().ToString("N");
            this._timeSetting = timeSetting;
            this._format = parameter.Format;
            this._size = parameter.Size;
            cmbStyle.DataSource = CmdDataItemFactory.GetTimeStyleList();
            cmdFont.DataSource = CmdDataItemFactory.GetFontList();
            cmbFontSize.DataSource = CmdDataItemFactory.GetFontSizeList();
        }

        private void TimeSetting_Load(object sender, EventArgs e)
        {
         
        }


        public void Init()
        {
            //发送通知消息
            _timeSetting?.Deal(_guid,new TimeSettingParameter(){Format = _format,Size = _size, UserControl =  this});
        }

        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RefreshData()) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool RefreshData()
        {
            if (null == cmbStyle.SelectedItem || cmbFontSize.SelectedItem == null)
            {
                return true;
            }

            var format = (cmbStyle.SelectedItem as CmbDataItem)?.Name;
            var size = int.Parse((cmbFontSize.SelectedItem as CmbDataItem)?.Name);
            _timeSetting?.Deal(_guid, new TimeSettingParameter() {Format = format, Size = size,UserControl = this});
            return false;
        }


        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


    public class TimeSettingParameter
    {
        /// <summary>
        /// 显示的样式
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 字体的大小
        /// </summary>
        public int Size { get; set; }

        public UserControl UserControl { get; set; }

    }
}
