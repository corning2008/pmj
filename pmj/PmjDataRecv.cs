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

        public void DealData(byte[] dataList)
        {
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

        private void ParseData(DataResult dataResult)
        {
            //判断功能号,如果是0x21,并且内容是0x00就代表动态设置成功
            if (dataResult.GetFunctionId() == 0x21)
            {
                Console.WriteLine("打印完成");
                return;
            }
        }
    }
}
