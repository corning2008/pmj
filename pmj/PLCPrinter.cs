﻿using System;
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
           
            //开始打印文件
            for(var i = 0; i < pageList.Count; i++)
            {
                PrintFile(pmjSerialPort, pLCSerialPort, pageList[i], i, 2000);
            }
           
        }

        private static void WaitStatus2(PLCSerialPort pLCSerialPort, int timeOut)
        {
            //初始化
            var timeOutIndex = 0;
            while (true)
            {
                timeOutIndex += 10;
                if (timeOutIndex > timeOut)
                {
                    throw new Exception("等待PLC的状态超时,请检查PLC");
                }
                //查询状态
                var status = pLCSerialPort.GetD10Status();
                //如果状态时2的话，就直接跳出
                if (2 == status)
                {
                    Console.WriteLine($"检查到PLC的状态是2");
                    break;
                }
                //如果是等于0的话，就设置100的状态为1
                if (0 == status)
                {
                    Console.WriteLine("plc状态是0,开始初始化命令设置");
                    pLCSerialPort.SetBitValue(100, 1);
                    //继续等待PLC初始化完成
                }
                Thread.Sleep(10);
            }
        }

        public static bool PrintFile(PmjSerialPort pmjSerialPort, PLCSerialPort plcSerialPort, int fileIndex,int index,int timeOut)
        {
             //设置打印的文件
            pmjSerialPort.SetParameter((ushort)(fileIndex));
            //设置打印机重启,现在修改了设备之后可能就不需要重启了,直接开始打印
            //plcSerialPort.SetBitValue(105, 1);
            //重新连接打印机
            //Thread.Sleep(500);
            //var indexSum = 0;
            //重新检测PLC的状态，知道获取到02状态
            //while (true)
            //{
            //    var status = plcSerialPort.GetD10Status();
            //    if(status == 2)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(200);
                
            //    indexSum += 200;
            //    if(indexSum > 3000)
            //    {
            //        throw new Exception("无法检测到02信号");
            //    }
            //}
            //重新连接
            //if (!pmjSerialPort.ReConnectPrinter())
            //{
            //    throw new Exception("重启后无法重新连接打印机");
            //}
            Thread.Sleep(200);
            //初始化
            WaitStatus2(plcSerialPort, 10000);
            //通知plc开始执行打印的指令
            if (!plcSerialPort.SetBitValue(100 + index + 1, 1))
            {
                throw new Exception("写入PLC指令失败");
            }
            //开始执行打印
            pmjSerialPort.Print();
            //初始化
            WaitStatus2(plcSerialPort, 10000);
            //打印完成之后，写入M20X指令
            if (!plcSerialPort.SetBitValue(200 + index + 1, 1))
            {
                throw new Exception("写入PLC状态指令失败");
            }
            Console.WriteLine($"成功打印第{fileIndex + 1}个文件");
            //打印完之后，等待200毫秒
            Thread.Sleep(200);
            return true;

        }
    }
}
