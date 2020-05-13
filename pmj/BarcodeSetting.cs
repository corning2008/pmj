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
    public partial class BarcodeSetting : UserControl
    {
        private IBarcodeSetting _ibarCodeSetting;
        private string _guid;

        public BarcodeSetting(IBarcodeSetting iBarcodeSetting)
        {
            InitializeComponent();
            cmbSizeList.DataSource = CmbDataItemFactory.GetSizeList();
            cmbTypeList.DataSource = CmbDataItemFactory.GetBarcodeType();
            this._ibarCodeSetting = iBarcodeSetting;
            this._guid = Guid.NewGuid().ToString("N");
        }

        

        private void BarcodeSetting_Load(object sender, EventArgs e)
        {

        }

        public void Refresh()
        {
            _ibarCodeSetting?.DealBarcodeSetting(_guid, GetParameter());
        }

        private BarcodeSettingParameter GetParameter()
        {
            var para = new BarcodeSettingParameter();
            para.UserControl = this;
            para.Content = tbContent.Text;
            para.PicSize = (cmbSizeList.SelectedItem as CmbDataItem)?.Value??0;
            return para;
        }

        private void ValueChange(object sender, EventArgs e)
        {
            _ibarCodeSetting?.DealBarcodeSetting(_guid,GetParameter());
        }
    }

    public interface IBarcodeSetting
    {
        void DealBarcodeSetting(string guid, BarcodeSettingParameter para);
    }


    public class BarcodeSettingParameter
    {
        public string Content { get; set; }

        public int PicSize { get; set; }

        public UserControl UserControl { get; set; }
    }
}
