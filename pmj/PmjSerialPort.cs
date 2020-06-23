using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GodSharp.SerialPort;

namespace pmj
{
    public interface IDataRecvPort
    {
        void DealData(byte[] dataList);
    }

    public class PmjSerialPort
    {
        private GodSerialPort _port = null;
        private string _portName;
        private IDataRecvPort _dataRecvPort;
        //发送命令返回的数据
        private byte[] _dataRecv = null;

        /// <summary>
        /// 判断端口是否已经打开
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            if (null == _port)
            {
                return false;
            }
            return _port.IsOpen;
        }

        /// <summary>
        /// 判断是否连接到打印机
        /// </summary>
        /// <returns></returns>
        public bool ReConnectPrinter()
        {
            this.Close();
            var openFlag = this.Open();
            if (!openFlag)
            {
                throw new Exception("打开打印机串口失败");
            }
            //如果串口正常，就检测是否存在打印机
            var dataResult = WriteForResult(CommandFactory.GetCheckDeviceCommand(), 100);
            if (null == dataResult)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否存在打印机
        /// </summary>
        /// <param name="printerName"></param>
        /// <returns></returns>
        public bool HasPrinter(out string printerName)
        {
            //首先判断串口是否已经打开
            if(null == _port || !_port.IsOpen)
            {
                //打开串口
                var flag = Open();
                if (!flag)
                {
                    throw new Exception("打开打印机串口失败");
                }
            }
            //如果串口正常，就检测是否存在打印机
            var dataResult = WriteForResult(CommandFactory.GetCheckDeviceCommand(), 100);
            if(null == dataResult)
            {
               throw new Exception("没有扫描到喷码机");
            }
            printerName = Encoding.Default.GetString(dataResult.GetData());
            return true;
        }
        

        public void ReadParameter()
        {
            //查询参数的命令
            var command = CommandFactory.GetPrintParameters();
            var result = WriteForResult(command, 4000);
            if (null == result || null == result.GetData())
            {

                throw new Exception("读取设备参数失败");
            }
            //开始解析数据
            ParseData(result.GetData());
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="fileModel">设置第几个文件进行打印，默认0：第一个文件， 3：第四个文件</param>
        public void SetParameter(ushort fileModel=0)
        {
            //第一步首先读取系统的参数
            ReadParameter();
            Parameters.FileModel = fileModel;

            //设置打印延迟
            var numberDelayBytes = BitConverter.GetBytes(Parameters.DelayValue);
            //列间延迟
            var colDelayBytes = BitConverter.GetBytes((ushort)Parameters.ColDelay);
            //编码器基数
            var numberCountBytes = BitConverter.GetBytes((ushort)Parameters.ColMoto);
            //脉冲宽度
            var pulseWidthBytes =
                BitConverter.GetBytes((ushort)Parameters.PluseWidth);
            //打印灰度
            var grayScaleBytes = BitConverter.GetBytes((ushort)Parameters.GrayDelay);
            //打印电压
            var vBytes = BitConverter.GetBytes((ushort)Parameters.Voltage);
            //左右喷头选择
            var printBytes = BitConverter.GetBytes((ushort)Parameters.PrintIndex);
            //打印文件选择
            var fileIndexBytes = BitConverter.GetBytes((ushort)Parameters.FileModel);
            //自动关机
            var powerOffBytes = new byte[] { 0x2c, 0x01 };/* BitConverter.GetBytes((ushort) (cmbShutdownList.SelectedItem as CmbDataItem).Value);*/
                                                          //闲喷
            var idleBytes = BitConverter.GetBytes((ushort)Parameters.Idle);

            var content = numberDelayBytes.Concat(colDelayBytes).Concat(numberCountBytes).Concat(pulseWidthBytes)
                .Concat(grayScaleBytes).Concat(new byte[] { 0x55, 0x00 }).Concat(vBytes)
                .Concat(printBytes).Concat(fileIndexBytes).Concat(new byte[] { 0x00, 0x00 })
                .Concat(new byte[] { 0x00, 0x00 }).Concat(powerOffBytes).Concat(idleBytes).ToArray();
            var command = CommandFactory.getSetPrintParameters(content);
            //发送命令
            SendCommand(command, out DataResult result);

        }


        private void ParseData(byte[] dataList)
        {
            //打印延迟
            var delayValue = BitConverter.ToUInt16(dataList, 0);
            Parameters.DelayValue = delayValue;
            //列间延迟
            var colDelay = BitConverter.ToUInt16(dataList, 2);
            Parameters.ColDelay = colDelay;
            //编码器计数
            var colsMotos = BitConverter.ToUInt16(dataList, 4);
            Parameters.ColMoto = colsMotos;
            //脉冲宽度
            var pluseWidth = BitConverter.ToUInt16(dataList, 6);
            Parameters.PluseWidth = pluseWidth;
            //打印灰度
            var grayDelay = BitConverter.ToInt16(dataList, 8);
            Parameters.GrayDelay = grayDelay;
            //打印电压
            var voltage = BitConverter.ToUInt16(dataList, 12);
            Parameters.Voltage = voltage;
            //喷头的选择
            var printIndex = BitConverter.ToUInt16(dataList, 14);
            Parameters.PrintIndex = printIndex;
            //打印文件
            var fileModel = BitConverter.ToUInt16(dataList, 16);
            Parameters.FileModel = fileModel;
            //自动关机设置
            var powerOff = BitConverter.ToUInt16(dataList, 22);
            //闲喷
            var idle = BitConverter.ToUInt16(dataList, 24);
            Parameters.Idle = idle;
            return;
        }

        public PmjSerialPort(string portName,IDataRecvPort dataRecvPort)
        {
            this._portName = portName;
            this._dataRecvPort = dataRecvPort;
          
        }

        /// <summary>
        /// 设置文本的命令
        /// </summary>
        /// <param name="fileIndex">0:第一个文件  3：第四个文件</param>
        /// <param name="text">文本的内容</param>
        /// <param name="fontModel">文本的类型0-5：</param>
        /// <param name="left">left距离</param>
        /// <param name="top">top距离</param>
        /// <param name="xEnd">最右边的距离</param>
        public void SendTextCommand(byte fileIndex,string text,int fontModel=3,ushort left=0,ushort top=25,ushort xEnd=400)
        {
            var commandDownload = CommandFactory.GetDownloadCommand((byte)fileIndex);
            var flag = SendCommand(commandDownload, out DataResult result);
            if (!flag)
            {
                throw new Exception("下发写入指令失败");
            }
            var commandText = CommandFactory.GetTextCommand((ushort)left, (ushort)top, Encoding.Default.GetBytes(text), (ushort)fontModel);
            var resultForSend = SendCommand(commandText, out DataResult resultF);
            if (!resultForSend)
            {
                throw new Exception("下发文本下载失败");
            }
            //结束写入
            var command = CommandFactory.GetFinishDownloadCommand(0, (ushort)xEnd);
            var flagEnd = SendCommand(command, out DataResult p);
            if (!flagEnd)
            {
                throw new Exception("下发结束下载命令失败");
            }
        }

        /// <summary>
        /// 设置银行的卡号
        /// </summary>
        /// <param name="bankNumber"></param>
        public void SendBankSerial(string bankNumber,string tbDate)
        {
            //设置第一个文件的内容
            SendTextCommand(0, bankNumber,4);
            Thread.Sleep(100);
            //设置第二个文件的内容
            SendTextCommand(1, tbDate, 3,150);
         
        }


        public void SendTimeCommand(byte fileIndex,ushort left=100 ,ushort top=25,string format= "Yy/Mm/Dd", ushort fontSize=1,ushort xEnd=250)
        {
            var commandDownload = CommandFactory.GetDownloadCommand((byte)fileIndex);
            var flag = SendCommand(commandDownload, out DataResult result);
            if (!flag)
            {
                throw new Exception("下发写入文件指令失败");
            }
            var timeOffset = GetTimeOffSet();
            var commandTime = CommandFactory.GetTimeCommand(format, (ushort)fontSize, (ushort)left, (ushort)top, timeOffset);
            var resultForSend = SendCommand(commandTime, out DataResult resultF);
            if (!resultForSend)
            {
                throw new Exception("下发时间设置命令失败");
            }
            //结束写入
            var command = CommandFactory.GetFinishDownloadCommand(0, (ushort)xEnd);
            var flagEnd = SendCommand(command, out DataResult p);
            if (!flagEnd)
            {
                throw new Exception("下发结束下载命令失败");
            }
        }

        /// <summary>
        /// 获取时间的偏移量
        /// </summary>
        /// <returns></returns>
        public byte[] GetTimeOffSet(byte yearOffset=0,byte monthOffset=0,byte dayOffset=0,byte hourOffset=0)
        {
            var yearValue = (byte)yearOffset;
            var monthValue = (byte)monthOffset;
            var dayValue = (byte)dayOffset;
            var hourValue = (byte)hourOffset;
            return new byte[] { 0x00, 0x00, hourValue, dayValue, monthValue, yearValue };
        }



        /// <summary>
        /// 打印文件，如果收到数据就代表打印完成
        /// </summary>
        public DataResult Print()
        {
            var command = CommandFactory.GetPrintOnceCommand();
            return WriteForResult(command, 2000);
        }

        /// <summary>
        /// 获取串口的名称
        /// </summary>
        /// <returns></returns>
        public string GetPortName()
        {
            return _portName;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public bool Open()
        {
            if (null == _port)
            {
                _port = new GodSerialPort(this._portName, 115200, Parity.Odd, 8, StopBits.One, Handshake.None);
                _port.UseDataReceived(true, (sp, bytes) =>
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var b in bytes)
                    {
                        sb.Append($"{b:X2} ");
                    }
                    Console.WriteLine($"recv data:{sb.ToString()}");
                    //如果接受到数据,就提交给接口处理
                    _dataRecv = bytes;
                    _dataRecvPort?.DealData(bytes);
                });
            }
            if (_port.IsOpen)
            {
                return true;
            }
            //打开串口,并进行监听
            return _port.Open();
            
        }

        /// <summary>
        /// 写入缓冲数据
        /// </summary>
        /// <param name="bitmap">图片</param>
        /// <param name="left">x起点</param>
        /// <param name="top">y起点</param>
        /// <returns></returns>
        public bool WriteImageBuffer(Bitmap bitmap, int left, int top)
        {
            var commandList = CommandFactory.GetImageCommand((ushort)left, (ushort)top,bitmap);
            if (null == commandList || commandList.Count == 0)
            {
                throw new Exception("没有获取到缓冲数据");
            }

            foreach (var bytese in commandList)
            {
                var dataResult = WriteForResult(bytese, 4000);
                var data = dataResult.GetData();
                if (data == null || data.Length == 0)
                {
                    throw new Exception("图片下发没有接受到应答数据");
                }

                if (data[0] == 0x00)
                {
                    throw new Exception("图片下发命令失败");
                }
            }

            return true;
        }

        /// <summary>
        /// 用于进程间同步
        /// </summary>
        private readonly object _flag = new object();

        public DataResult WriteForResult(byte[] dataList,int timeOut)
        {
            if (!Monitor.TryEnter(_flag))
            {
                throw new Exception("串口正在执行命令,请稍后");
            }
            lock (_flag)
            {
                _dataRecv = null;
                if (null != _port && _port.IsOpen)
                {
                    _port.Write(dataList);
                    Console.WriteLine($"发送数据：{GetHexString(dataList)}");
                }
                else
                {
                    throw new Exception("请先打开串口");
                }

                var index = 1;
                while (index < timeOut)
                {
                    Thread.Sleep(1);
                    index++;
                    if (null != _dataRecv && _dataRecv.Length > 1)
                    {
                        var newBuffer = new byte[_dataRecv.Length];
                        Array.Copy(_dataRecv,0,newBuffer,0,_dataRecv.Length);
                        //接受到应答数据
                        Console.WriteLine($"接受到应答数据:{GetHexString(newBuffer)}");
                        //对接受到的数据进行解析
                        if (!CommandFactory.ValidateData(newBuffer))
                        {
                            throw new Exception("接受到的数据校验失败");
                        }
                        return new DataResult(newBuffer);
                    }
                }

                throw new Exception("执行命令超时");
            }
           
        }
        
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="command">命令的内容</param>
        /// <param name="result">返回的结果</param>
        /// <returns>true：执行成功 false： 执行失败</returns>
        public bool SendCommand(byte[] command ,out DataResult result)
        {
            result = WriteForResult(command, 3000);
            if(null == result)
            {
                Console.WriteLine("没有接受到应答数据");
                return false;
            }
            if(result.GetFunctionId()!= command[3])
            {
                Console.WriteLine("应答数据的功能码不对");
                return false;
            }
            var content = result.GetData();
            if(null == content || content.Length ==0)
            {
                return false;
            }
            if(content[0] != 0x01)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 发送字节数组
        /// </summary>
        /// <param name="dataList"></param>
        public void Write(byte[] dataList)
        {
            lock (_flag)
            {
                if (null != _port && _port.IsOpen)
                {
                    _port.Write(dataList);
                    //打印发送的数据
                    Console.WriteLine($"发送命令：{GetHexString(dataList)}");
                }
                else
                {
                    throw new Exception("请先打开串口");
                }
            }
          

        }


        public static string GetHexString(byte[] dataList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in dataList)
            {
                sb.Append($"{item:X2} ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 发送Ascii字符串
        /// </summary>
        /// <param name="str"></param>
        public void WriteAsciiString(string str)
        {
            if (null != _port && _port.IsOpen)
            {
                _port.WriteAsciiString(str);
            }
            else
            {
                throw new Exception("请先打开串口");
            }

        }
        /// <summary>
        /// 发送Hex字符串,比如7E 48 53 44
        /// </summary>
        /// <param name="str"></param>
        public DataResult WriteHexString(string str,int timeOut)
        {
            if (!Monitor.TryEnter(_flag))
            {
                throw new Exception("串口正在执行命令,请稍后");
            }
            lock (_flag)
            {
                _dataRecv = null;
                if (null != _port && _port.IsOpen)
                {
                    _port.WriteHexString(str);
                    Console.WriteLine($"发送数据：{str}");
                }
                else
                {
                    throw new Exception("请先打开串口");
                }

                var index = 1;
                while (index < timeOut)
                {
                    Thread.Sleep(1);
                    index++;
                    if (null != _dataRecv && _dataRecv.Length > 1)
                    {
                        var newBuffer = new byte[_dataRecv.Length];
                        Array.Copy(_dataRecv, 0, newBuffer, 0, _dataRecv.Length);
                        //接受到应答数据
                        Console.WriteLine($"接受到应答数据:{GetHexString(newBuffer)}");
                        //对接受到的数据进行解析
                        if (!CommandFactory.ValidateData(newBuffer))
                        {
                            throw new Exception("接受到的数据校验失败");
                        }
                        return new DataResult(newBuffer);
                    }
                }

                throw new Exception("执行命令超时");
            }
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            if (null != _port)
            {
                _port.Close();
                _port = null;
            }
        }


    }
}
