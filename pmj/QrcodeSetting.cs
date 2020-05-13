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
    public partial class QrcodeSetting : UserControl
    {
        private string _guid;
        private IQrcodeSetting _iQrcodeSetting;

        public QrcodeSetting(IQrcodeSetting iQrcodeSetting)
        {
            InitializeComponent();
            cmbSizeList.DataSource = CmbDataItemFactory.GetSizeList();
            cmbTypeList.DataSource = CmbDataItemFactory.GetQrcodeType();
            this._guid = Guid.NewGuid().ToString("N");
            this._iQrcodeSetting = iQrcodeSetting;
        }


        private QrcodeSettingParameter GetParameter()
        {
            var para = new QrcodeSettingParameter();
            para.Content = tbContent.Text;
            if (string.IsNullOrEmpty(para.Content))
            {
                para.Content = "empty";
            }

            para.PicSize = (cmbSizeList.SelectedItem as CmbDataItem)?.Value ?? 0;
            para.QrcodeType = (cmbTypeList.SelectedItem as CmbDataItem)?.Name;
            para.UserControl = this;
            return para;
        }

        private void QrcodeSetting_Load(object sender, EventArgs e)
        {

        }

        public void Refresh()
        {
            _iQrcodeSetting?.DealQrcodeSetting(_guid, GetParameter());
        }

        private void ValueChange(object sender, EventArgs e)
        {
            _iQrcodeSetting?.DealQrcodeSetting(_guid,GetParameter());
        }
    }

    public interface IQrcodeSetting
    {
        void DealQrcodeSetting(string guid, QrcodeSettingParameter para);
    }


    public class QrcodeSettingParameter
    {
        /// <summary>
        /// 二维码的内容
        /// </summary>
        public string Content { get; set; }

        public int PicSize { get; set; }

        public string QrcodeType { get; set; }

        public UserControl UserControl { get; set; }
    }
}
