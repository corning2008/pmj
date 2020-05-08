using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
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
        /// 发送字节数组
        /// </summary>
        /// <param name="dataList"></param>
        public void Write(byte[] dataList)
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
