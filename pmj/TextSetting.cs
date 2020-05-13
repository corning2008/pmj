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
    /// <summary>
    /// 对文本进行设置
    /// </summary>
    public partial class TextSetting : UserControl
    {
        private readonly string _guid;
        private readonly ITextSetting _iTextSetting;

        public TextSetting(ITextSetting iTextSetting)
        {
            InitializeComponent();
            cmbFontSize.DataSource = CmbDataItemFactory.GetFontSizeList();
            cmbFont.DataSource = CmbDataItemFactory.GetFontList();
            this._guid = Guid.NewGuid().ToString("N");
            this._iTextSetting = iTextSetting;
        }



        private void TextSetting_Load(object sender, EventArgs e)
        {

        }

        private TextSettingParameter GetParameter()
        {
            var para = new TextSettingParameter();
            para.Content = tbContent.Text;
            if (string.IsNullOrEmpty(para.Content))
            {
                para.Content = "文本内容不能为空";
            }
            para.Size = int.Parse((cmbFontSize.SelectedItem as CmbDataItem)?.Name ?? "0");
            para.UserControl = this;
            return para;
        }

        public void Refresh()
        {
            _iTextSetting?.DealTextSetting(_guid, GetParameter());
        }

        private void ValueChange(object sender, EventArgs e)
        {
            _iTextSetting?.DealTextSetting(_guid,GetParameter());
        }
    }


    public class TextSettingParameter
    {
        public UserControl UserControl { get; set; }
        /// <summary>
        /// 文本的内容
        /// </summary>
        public String Content { get; set; }


        public int Size { get; set; }
    }

    public interface ITextSetting
    {
        void DealTextSetting(string guid, TextSettingParameter para);
    }
}
