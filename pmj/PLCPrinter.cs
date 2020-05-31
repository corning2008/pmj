using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pmj
{
    public class PLCPrinter
    {
        /// <summary>
        /// 开始打印数据
        /// </summary>
        /// <param name="pmjSerialPort"></param>
        /// <param name="pLCSerialPort"></param>
        /// <param name="pageList"></param>
        /// <param name="timeOut"></param>
        public static void PrintList(PmjSerialPort pmjSerialPort,PLCSerialPort pLCSerialPort, List<int> pageList,int timeOut)
        {
            //初始化
            var timeOutIndex = 0;
            while (true)
            {
                timeOutIndex++;
                if(timeOutIndex> timeOut)
                {
                    return;
                }
                //查询状态
                var status = pLCSerialPort.GetD10Status();
                if(0 == status)
                {
                    pLCSerialPort.SetBitValue(100, 1);
                    break;
                }
            }
            //开始打印文件
            for(var i = 0; i < pageList.Count; i++)
            {
                PrintFile(pmjSerialPort, pLCSerialPort, pageList[i], i, 2000);
            }
            //
        }

        public static bool PrintFile(PmjSerialPort pmjSerialPort, PLCSerialPort plcSerialPort, int fileIndex,int index,int timeOut)
        {
            var timeIndex = 0;
            //设置打印的文件
            pmjSerialPort.SetParameter((ushort)(fileIndex - 1));
            //设置打印机重启
            plcSerialPort.SetBitValue(200, 1);
            //重新连接打印机
            Thread.Sleep(100);
            //重新连接
            if (!pmjSerialPort.HasConnectPrinter())
            {
                throw new Exception("无法查询到打印机");
            }
            
            while (true)
            {
                Thread.Sleep(1);
                timeIndex++;
                if (timeIndex > timeOut)
                {
                    throw new Exception("打印时间超时");
                }
                var status = plcSerialPort.GetD10Status();
                if ((2+index) == status)
                {
                    //通知plc开始执行打印的指令
                    var flag = plcSerialPort.SetBitValue(100 + index+1, 1);
                    if (!flag)
                    {
                        throw new Exception("写入PLC指令失败");
                    }
                    //开始执行打印
                    var dataResult = pmjSerialPort.Print();
                    //打印完成之后，写入M20X指令
                    if (!plcSerialPort.SetBitValue(200 + index+1, 1))
                    {
                        throw new Exception("写入PLC状态指令失败");
                    }
                }
            }
        }
    }
}
