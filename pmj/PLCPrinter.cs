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
        public static bool PrintFile(PmjSerialPort pmjSerialPort, PLCSerialPort plcSerialPort, int fileIndex,int timeOut)
        {
            var index = 0;
            
            while (true)
            {
                 Thread.Sleep(1);
                index++;
                if (index > timeOut)
                {
                    throw new Exception("打印时间超时");
                }
                //获取D10的状态
                var status = plcSerialPort.GetD10Status();
                if (0 == status)
                {
                    plcSerialPort.SetBitValue(100, 1);
                }

                if (2 == status)
                {
                    //通知plc开始执行打印的指令
                    var flag = plcSerialPort.SetBitValue(100 + fileIndex, 1);
                    if (!flag)
                    {
                        throw new Exception("写入PLC指令失败");
                    }
                    //开始执行打印
                    var dataResult = pmjSerialPort.Print();
                    //打印完成之后，写入M20X指令
                    if (!plcSerialPort.SetBitValue(200 + fileIndex, 1))
                    {
                        throw new Exception("写入PLC状态指令失败");
                    }
                }
            }
        }
    }
}
