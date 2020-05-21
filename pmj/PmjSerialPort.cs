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
            var dataResult = WriteForResult(CommandFactory.GetCheckDeviceCommand(), 2000);
            if(null == dataResult)
            {
                printerName = "没有扫描到打印机";
                return false;
            }
            printerName = Encoding.Default.GetString(dataResult.GetData());
            return true;
        }
        

        public PmjSerialPort(string portName,IDataRecvPort dataRecvPort)
        {
            this._portName = portName;
            this._dataRecvPort = dataRecvPort;
          
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
            if (null != _port && _port.IsOpen)
            {
                _port.Close();
                _port = null;
            }
        }


    }
}
