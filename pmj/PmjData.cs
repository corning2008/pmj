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
        /// 数据
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        ///原来的Bitmap图片
        /// </summary>
        public Bitmap Bitmap { get; set; }

        /// <summary>
        /// 剪切图片的Left
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// 剪切图片的TOP
        /// </summary>
        public int Top { get; set; }
    }
}
