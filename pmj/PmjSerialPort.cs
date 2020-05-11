using System;
using System.Collections.Generic;
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
        

        public PmjSerialPort(string portName,IDataRecvPort dataRecvPort)
        {
            this._portName = portName;
            this._dataRecvPort = dataRecvPort;
          
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
                }
                else
                {
                    throw new Exception("请先打开串口");
                }
            }
          

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
        public void WriteHexString(string str)
        {
            if (null != _port && _port.IsOpen)
            {
                _port.WriteHexString(str);
            }
            else
            {
                throw new Exception("请先打开串口");
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
