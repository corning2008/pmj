using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmj
{
    /// <summary>
    /// 打印机的相关参数
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// 延迟参数
        /// </summary>
        public static ushort DelayValue { get; internal set; }
        /// <summary>
        /// 列间延迟
        /// </summary>
        public static ushort ColDelay { get; internal set; }
        /// <summary>
        /// 编码器计数
        /// </summary>
        public static ushort ColMoto { get; internal set; }
        /// <summary>
        /// 脉冲宽度
        /// </summary>
        public static ushort PluseWidth { get; internal set; }

        /// <summary>
        /// 打印灰度
        /// </summary>
        public static short GrayDelay { get; internal set; }
        /// <summary>
        /// 打印电压
        /// </summary>
        public static ushort Voltage { get; internal set; }
        /// <summary>
        /// 喷头的选择
        /// </summary>
        public static ushort PrintIndex { get; internal set; }
        /// <summary>
        /// 打印的文件选择
        /// </summary>
        public static ushort FileModel { get; internal set; }
        public static ushort Idle { get; internal set; }
    }
}
