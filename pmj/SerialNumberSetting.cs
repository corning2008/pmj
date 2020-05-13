using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;

namespace pmj
{
  

    public partial class SerialNumberSetting : UserControl
    {
        private ISerialNumberSetting _serialNumberSetting;
        private SerialNumberParameter _parameter;
        private string _guid;
        private static ILog Log = LogManager.GetLogger(typeof(SerialNumberParameter));

        public SerialNumberSetting(ISerialNumberSetting iSerialNumberSetting,SerialNumberParameter parameter)
        {
            Log.Info($"传入的参数:{JsonConvert.SerializeObject(parameter)}");
            InitializeComponent();
            this._serialNumberSetting = iSerialNumberSetting;
            this._parameter = parameter;
            this._guid = Guid.NewGuid().ToString("N");
            cmbFormat.DataSource = CmbDataItemFactory.GetSerialNumberFormatList();
            cmbFontSize.DataSource = CmbDataItemFactory.GetFontSizeList();
            cmbStyle.DataSource = CmbDataItemFactory.GetFontList();
        }

        private void SerialNumberSetting_Load(object sender, EventArgs e)
        {
            
            numberInit.Value = _parameter.NumberInit;
            numberInterval.Value = _parameter.NumberInterval;
            numberRepeat.Value = _parameter.NumberRepeat;
        }


        public void Refresh()
        {
            _serialNumberSetting?.SerialNumberDeal(this._guid,GetParameter());
        }

        /// <summary>
        /// 查询设置的参数
        /// </summary>
        /// <returns></returns>
        private SerialNumberParameter GetParameter()
        {
            var parameter = new SerialNumberParameter();
            parameter.Format = (cmbFormat.SelectedItem as CmbDataItem)?.Name;
            parameter.Size = int.Parse((cmbFontSize.SelectedItem as CmbDataItem)?.Name??"0");
            parameter.NumberInit = (int) numberInit.Value;
            parameter.NumberInterval = (int) numberInterval.Value;
            parameter.NumberRepeat = (int) numberRepeat.Value;
            parameter.UserControl = this;
            return parameter;
        }

        private void cmbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormat.SelectedItem == null || cmbFontSize.SelectedItem == null || cmbStyle.SelectedItem == null)
                {
                    return;
                }
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    public interface ISerialNumberSetting
    {
        void SerialNumberDeal(string guid, SerialNumberParameter para);
    }
    /// <summary>
    /// 传输的数据
    /// </summary>
    public class SerialNumberParameter
    {
        /// <summary>
        /// 样式
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 初始值
        /// </summary>
        public int NumberInit { get; set; }

        /// <summary>
        /// 间隔
        /// </summary>
        public int NumberInterval { get; set; }

        /// <summary>
        /// 重复次数
        /// </summary>
        public int NumberRepeat { get; set; }

        public UserControl UserControl { get; set; }
    }
}
