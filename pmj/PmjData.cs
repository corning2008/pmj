using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmj
{
    public enum EnumPmjData
    {
        文本,
        时间,
        序号,
        图片,
        二维码,
        条码
    }

    /// <summary>
    /// 这个类主要用来保存用户编辑的数据
    /// </summary>
    public class PmjData
    {
        /// <summary>
        /// 控件的ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 数据的类型
        /// </summary>
        public EnumPmjData DateType { get; set; }


        public Control Control { get; set; }

        /// <summary>
        /// 附件的控件的信息
        /// </summary>
        public Object DataSource { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Data { get; set; }

      
        

    
    }
}
