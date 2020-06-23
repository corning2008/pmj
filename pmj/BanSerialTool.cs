using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmj
{
    public class BanSerialTool
    {
        private void Test()
        {
            var value = "6216 6161 0400 0321697";
            Console.WriteLine(GetFormatString(value));
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="dataStr"></param>
        /// <returns></returns>
        public static string GetFormatString(string dataStr)
        {
            if (string.IsNullOrEmpty(dataStr))
            {
                return string.Empty;
            }
            var sbList = dataStr.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            foreach (var item in sbList)
            {
                sb.Append(item);
            }

            var value = sb.ToString();
            sb.Clear();
            
            for (var i = 0; i < value.Length; i += 4)
            {
                if (i + 4 < value.Length)
                {
                    sb.Append(value.Substring(i, 4));
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(value.Substring(i));
                }
               
            }

            return sb.ToString();
        }
    }
}
