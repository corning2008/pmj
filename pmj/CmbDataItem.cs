using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace pmj
{
    public class CmbDataItemFactory
    {
        

        public void Test()
        {
            Console.WriteLine(1.ToString("00"));
        }


        public static List<CmbDataItem> GetFileList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem { Name = "文件1", Value = 0 });
            list.Add(new CmbDataItem { Name = "文件2", Value = 1 });
            list.Add(new CmbDataItem { Name = "文件3", Value = 2 });
            list.Add(new CmbDataItem { Name = "文件4", Value = 3 });
            return list;
        }

        public static List<CmbDataItem> GetBarcodeType()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "bcCode128A"});
            list.Add(new CmbDataItem() { Name = "bcCode128B" });
            list.Add(new CmbDataItem() { Name = "bcCode128C" });
            list.Add(new CmbDataItem() { Name = "bcCodeEAN13" });
            list.Add(new CmbDataItem() { Name = "bcCode93" });
            list.Add(new CmbDataItem() { Name = "bcCode93Extended" });
            list.Add(new CmbDataItem() { Name = "bcCodeMSI" });
            list.Add(new CmbDataItem() { Name = "bcCodePostNet" });
            list.Add(new CmbDataItem() { Name = "bcCodeCodeBar" });
            list.Add(new CmbDataItem() { Name = "bcCodeEAN8" });
            return list;
        }

        /// <summary>
        /// 二维码的类型
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetQrcodeType()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem() { Name = "utf8bom", Value = 40 });
            return list;
        }
        
        /// <summary>
        /// 生产的条码或者二维码的大小
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetSizeList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "小",Value = 40});
            list.Add(new CmbDataItem(){Name = "中",Value = 50});
            list.Add(new CmbDataItem(){Name = "大",Value = 70});
            return list;
        }

        /// <summary>
        /// 获取序列号的样式
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetSerialNumberFormatList()
        {
            var list = new List<CmbDataItem>();
            var sb = new StringBuilder("00");
            for (var i = 2; i <= 8; i++)
            {
                list.Add(new CmbDataItem(){Name = sb.ToString()});
                sb.Append("0");
            }
            return list;
        }

        /// <summary>
        /// 时间设置中样式
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetTimeStyleList()
        {
            var list = new List<CmbDataItem>();
           
            list.Add(new CmbDataItem(){Name = "yyyyMMdd",Value = 2});
            list.Add(new CmbDataItem() { Name = "yyyy/MM/dd", Value = 2 });
            list.Add(new CmbDataItem() { Name = "yyyy-MM-dd", Value = 2 });
            list.Add(new CmbDataItem() { Name = "yyyy年MM月dd", Value = 2 });
            list.Add(new CmbDataItem() { Name = "yyMMdd", Value = 2 });
            list.Add(new CmbDataItem() { Name = "yy/MM/dd", Value = 2 });
            list.Add(new CmbDataItem() { Name = "yy-MM-dd", Value = 2 });
            list.Add(new CmbDataItem() { Name = "yy年MM月dd", Value = 2 });
            return list;
        }

        /// <summary>
        /// 获取字号
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetFontSizeList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "10",Value = 0});
            list.Add(new CmbDataItem() { Name = "12", Value = 1 });
           
            list.Add(new CmbDataItem() { Name = "16", Value = 2 });
            list.Add(new CmbDataItem() { Name = "24", Value = 3 });
            list.Add(new CmbDataItem() { Name = "32", Value = 4 });
            list.Add(new CmbDataItem() { Name = "48", Value = 5 });
          
            return list;
        }

        /// <summary>
        /// 获取字体类型列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetFontList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "默认实线",Value = 1});
            list.Add(new CmbDataItem(){Name = "默认虚线",Value = 2});
            return list;
        }
    }

    /// <summary>
    /// CmbBox的列表
    /// </summary>
    public class CmbDataItem
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Value { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
