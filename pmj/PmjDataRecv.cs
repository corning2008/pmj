using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmj
{
    /// <summary>
    /// 喷码返回数据的处理
    /// </summary>
    public class PmjDataRecv:IDataRecvPort
    {
        private static ILog Log = log4net.LogManager.GetLogger(typeof(PmjDataRecv));

        public void DealData(byte[] dataList)
        {
            Log.Info(GetHexString(dataList));
            //对接受到的数据进行解析
            if (!CommandFactory.ValidateData(dataList))
            {
                Console.WriteLine("接受到的数据校验失败");
                return;
            }
            var dataResult = new DataResult(dataList);
            //对数据进行分析
            ParseData(dataResult);
        }

        private string GetHexString(byte[] dataList)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in dataList)
            {
                sb.Append($"{item:X2} ");
            }
            return sb.ToString();
        }

        private void ParseData(DataResult dataResult)
        {
            
        }
    }
}
