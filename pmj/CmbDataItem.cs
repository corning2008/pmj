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
        /// <summary>
        /// 获取保留参数列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetRetainParameterList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "1"});
            list.Add(new CmbDataItem(){Name = "2"});
            return list;
        }

        /// <summary>
        /// 获取脉冲宽度列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetPulseWidthList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "1.6us",Value=0});
            list.Add(new CmbDataItem() { Name = "1.8us",Value=1 });
            list.Add(new CmbDataItem() { Name = "2.0us",Value=2 });
            list.Add(new CmbDataItem() { Name = "2.2us",Value=3 });
            list.Add(new CmbDataItem() { Name = "2.4us",Value=4 });
            list.Add(new CmbDataItem() { Name = "2.6us",Value=5 });
            list.Add(new CmbDataItem() { Name = "2.8us",Value=6 });
            return list;
        }

        /// <summary>
        /// 获取闲置喷墨设置列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetLeaveTimeList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "闲喷无效",Value=0});
            list.Add(new CmbDataItem() { Name = "1分钟",Value=60 });
            list.Add(new CmbDataItem() { Name = "2分钟",Value=120 });
            list.Add(new CmbDataItem() { Name = "5分钟",Value=300 });
            list.Add(new CmbDataItem() { Name = "10分钟",Value=600 });
            list.Add(new CmbDataItem() { Name = "30分钟",Value=1800 });
            return list;
        }

        /// <summary>
        /// 文件列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetPaperList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "文件1",Value=0});
            list.Add(new CmbDataItem() { Name = "文件2",Value=1 });
            list.Add(new CmbDataItem() { Name = "文件3",Value=2 });
            list.Add(new CmbDataItem() { Name = "文件4",Value=3 });
            list.Add(new CmbDataItem() { Name = "文件1>2",Value=4 });
            list.Add(new CmbDataItem() { Name = "文件1>2>3",Value=5 });
            return list;
        }

        /// <summary>
        /// 获取关机的列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetShutdownList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "不自动关机",Value = 0});
            list.Add(new CmbDataItem() { Name = "5分钟", Value = 0 });
            list.Add(new CmbDataItem() { Name = "10分钟", Value = 0 });
            list.Add(new CmbDataItem() { Name = "30分钟", Value = 0 });
            return list;
        }

        /// <summary>
        /// 获取喷头列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetPrintList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "1.27右喷头",Value = 0});
            list.Add(new CmbDataItem(){Name = "1.27左喷头",Value = 1});
            list.Add(new CmbDataItem(){Name = "2.54宽喷头",Value = 2});
            return list;
        }

        /// <summary>
        /// 喷头电压列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetVList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "12.0V",Value = 0});
            list.Add(new CmbDataItem() { Name = "11.6V", Value = 1 });
            list.Add(new CmbDataItem() { Name = "11.2V", Value = 2 });
            list.Add(new CmbDataItem() { Name = "10.8V", Value = 3 });
            list.Add(new CmbDataItem() { Name = "10.4V", Value = 4 });
            list.Add(new CmbDataItem() { Name = "10.0V", Value = 5 });
            list.Add(new CmbDataItem() { Name = "9.6V", Value = 6 });
            list.Add(new CmbDataItem() { Name = "9.2V", Value = 7 });
            list.Add(new CmbDataItem() { Name = "8.8V", Value = 8 });
            list.Add(new CmbDataItem() { Name = "8.4V", Value = 9 });
            list.Add(new CmbDataItem() { Name = "8.0V", Value = 10 });
            return list;
        }

        /// <summary>
        /// 获取打印灰度列表
        /// </summary>
        /// <returns></returns>
        public static List<CmbDataItem> GetGrayList()
        {
            var list = new List<CmbDataItem>();
            list.Add(new CmbDataItem(){Name = "浅",Value = 1});
            list.Add(new CmbDataItem() { Name = "中", Value = 2 });
            list.Add(new CmbDataItem() { Name = "浓", Value = 3 });
            list.Add(new CmbDataItem() { Name = "特浓", Value = 4 });
            return list;
        }

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
            list.Add(new CmbDataItem(){Name = "小",Value = 30});
            list.Add(new CmbDataItem(){Name = "中",Value = 40});
            list.Add(new CmbDataItem(){Name = "大",Value = 50});
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
           
            list.Add(new CmbDataItem(){Name = "yyyyMMdd",ValueStr = "20YyMmDd"});
            list.Add(new CmbDataItem() { Name = "yyyy/MM/dd", ValueStr="20Yy/Mm/Dd" });
            list.Add(new CmbDataItem() { Name = "yyyy-MM-dd", ValueStr = "20Yy-Mm-Dd" });
            list.Add(new CmbDataItem() { Name = "yyyy年MM月dd日", ValueStr = "20Yy年Mm月Dd日" });
            list.Add(new CmbDataItem() { Name = "yyMMdd", ValueStr="YyMmDd" });
            list.Add(new CmbDataItem() { Name = "yy/MM/dd", ValueStr="Yy/Mm/Dd" });
            list.Add(new CmbDataItem() { Name = "yy-MM-dd", ValueStr="Yy-Mm-Dd" });
            list.Add(new CmbDataItem() { Name = "yy年MM月dd日", ValueStr="Yy年Mm月Dd日" });
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

        /// <summary>
        /// 字符串类型的数据
        /// </summary>
        public string ValueStr { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
