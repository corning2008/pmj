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

        /// <summary>
        /// 获取时间的样式
        /// </summary>
        /// <returns></returns>
        public string GetTimeFormat()
        {
            return (cmbStyle.SelectedItem as CmbDataItem).ValueStr;
        }

        /// <summary>
        /// 获取时间的偏移量
        /// </summary>
        /// <returns></returns>
        public byte[] GetTimeOffSet()
        {
            var yearValue = (byte)this.yearOffset.Value;
            var monthValue = (byte)this.monthOffset.Value;
            var dayValue = (byte)this.dayOffset.Value;
            var hourValue = (byte)this.hourOffset.Value;
            return new byte[] {0x00,0x00,hourValue,dayValue,monthValue,yearValue };
        }

        /// <summary>
        /// 获取设置的字体的数据
        /// </summary>
        /// <returns></returns>
        public int GetFongValue()
        {
            return (cmbFontSize.SelectedItem as CmbDataItem).Value;
        }

        public TimeSetting(ITimeSetting timeSetting,TimeSettingParameter parameter)
        {
            InitializeComponent();
            //样式
            this._guid = Guid.NewGuid().ToString("N");
            this._timeSetting = timeSetting;
            this._format = parameter.Format;
            this._size = parameter.Size;
            cmbStyle.DataSource = CmbDataItemFactory.GetTimeStyleList();
            cmdFont.DataSource = CmbDataItemFactory.GetFontList();
            cmbFontSize.DataSource = CmbDataItemFactory.GetFontSizeList();
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
