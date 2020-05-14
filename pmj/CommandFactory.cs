using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmj
{
    public enum EnumInsertMode{
        文本,
        二维码,
        Code128A,
        Code128B,
        Code128C,
        ENA13
    }
    /// <summary>
    /// 写打印缓冲的数据
    /// </summary>
    public class BufferImageData
    {
        /// <summary>
        /// x开始
        /// </summary>
        public UInt16 X;
        /// <summary>
        /// y开始点
        /// </summary>
        public UInt16 Y;
        /// <summary>
        /// 宽度
        /// </summary>
        public UInt16 Width;
        /// <summary>
        /// 高度
        /// </summary>
        public UInt16 Height;
        /// <summary>
        /// 点阵数据
        /// </summary>
        public byte[] Data;

        public override string ToString()
        {
            return $"X:{X} Y:{Y} Width:{Width} Height:{Height} Data.Length:{Data.Length}"; 
        }


        public byte[] GetContentData()
        {
            var header = Encoding.ASCII.GetBytes("B");
            var dataLength = BitConverter.GetBytes((UInt16) Data.Length);
            var xBytes = BitConverter.GetBytes(X);
            var widthBytes = BitConverter.GetBytes(Width);
            var yBytes = BitConverter.GetBytes(Y);
            var heightBytes = BitConverter.GetBytes(Height);
            //反色2B
            var fanByte = BitConverter.GetBytes((UInt16) 100);
            return header.Concat(dataLength).Concat(xBytes).Concat(widthBytes).Concat(yBytes).Concat(heightBytes)
                .Concat(fanByte).Concat(Data).ToArray();
        }
    }

    public class CommandFactory
    {

        public void Test1()
        {
            var dataList = new byte[] { 0x06, 0x00, 0x20, 0x00 };
            var crc = CRC.CRC16(dataList);
            Console.WriteLine(PmjSerialPort.GetHexString(crc));
        }


        public void Test2()
        {
            var command = GetCommand(0x01,Encoding.ASCII.GetBytes("123"));
            foreach (var b in command)
            {
                Console.Write("{0:X2} ", b);
            }
        }


        public static List<byte[]> GetImageBufferCommand(Bitmap bitmap, int left, int top)
        {
            var width = left+bitmap.Width>2000? 2000-left: bitmap.Width;
            var height = top + bitmap.Height > 100 ? 100 - top : bitmap.Height;
            //高度必须是8的倍数
            while (height%8!=0)
            {
                height--;
            }

            if (height == 0)
            {
                return null;
            }

            var list = new List<byte[]>();
            var byteList = new List<byte>();
            var picWidth = 0;
           // var lockBitmap = new LockBitmap(bitmap);
           // lockBitmap.LockBits();
            try
            {
                for (var i = 0; i < width; i++)
                {
                    for (var j = 0; j < height; j++)
                    {
                        var color = bitmap.GetPixel(i, j);
                       // var value = (byte) (0.229 * color.R + 0.587 * color.G + 0.144 * color.B);
             //           var newVaue = lockBitmap.GetPixel(i, j);
                        byteList.Add(color.B);
                    }

                    //
                    picWidth++;


                    //单个包的数量不能超过1000
                    if (byteList.Count > 100 || (i == width - 1 && byteList.Count > 0))
                    {
                        var bufferImage = new BufferImageData();
                        bufferImage.X = (UInt16) (left + i);
                        bufferImage.Y = (UInt16) top;
                        bufferImage.Width = (UInt16) picWidth;
                        bufferImage.Height = (UInt16) height;
                        bufferImage.Data = byteList.ToArray();
                        byteList.Clear();
                        picWidth = 0;
                        list.Add(GetCommand(0x22, bufferImage.GetContentData()));
                        Console.WriteLine("添加分割数据");
                        Console.WriteLine(bufferImage.ToString());

                    }
                }


                return list;
            }
            finally
            {
               // lockBitmap.UnlockBits();
            }
        }
        

        /// <summary>
        /// 执行一次打印的命令
        /// </summary>
        /// <returns></returns>
        public static byte[] GetPrintOnceCommand()
        {
            return GetCommand(0x30, null);
        }

        /// <summary>
        /// 执行清洗碰头的操作
        /// </summary>
        /// <param name="timer">清洗碰头的次数</param>
        /// <returns></returns>
        public static byte[] GetCleanPrinter(ushort timer)
        {
            var bytes = BitConverter.GetBytes(timer);
            return GetCommand(0x40, bytes);
        }

        /// <summary>
        /// 检测是否存在打印设备的命令
        /// </summary>
        /// <returns></returns>
        public static byte[] GetCheckDeviceCommand()
        {
            return GetCommand(0x01, null);
        }

        /// <summary>
        /// 获取动态插入的命令
        /// </summary>
        /// <param name="insertMode">动态插入模式</param>
        /// <param name="content">插入的内容</param>
        /// <param name="index">小红点的位置</param>
        /// <returns></returns>

        public static byte[] GetDynamicInsert(EnumInsertMode insertMode, string content,ushort index)
        {
            //获取头部
            byte[] header = GetInsertModeHeader(insertMode);
            //获取发送的文本
            var contentData = Encoding.ASCII.GetBytes(content);
            //获取长度
            var length = new byte[] { (byte)contentData.Length };
            //小红点的位置
            var indexBytes = BitConverter.GetBytes(index);
            //拼接数组
            var dataList =  header.Concat(length).Concat(new byte[] { (byte)index}).Concat(contentData).ToArray();
            return GetCommand(0x20, dataList);
        }

        private static byte[] GetInsertModeHeader(EnumInsertMode insertMode)
        {
            if (insertMode == EnumInsertMode.文本)
            {
                return new byte[]{0x74};
            }
            if (insertMode == EnumInsertMode.二维码)
            {
                return Encoding.ASCII.GetBytes("Q");
            }
            if (insertMode == EnumInsertMode.Code128A)
            {
                return Encoding.ASCII.GetBytes("A");
            }

            if (insertMode == EnumInsertMode.Code128B)
            {
                return Encoding.ASCII.GetBytes("B");
            }

            if (insertMode == EnumInsertMode.Code128C)
            {
                return Encoding.ASCII.GetBytes("C");
            }

            if (insertMode == EnumInsertMode.ENA13)
            {
                return Encoding.ASCII.GetBytes("E");
            }
            throw new Exception("不存在输入模式");
        }

        /// <summary>
        /// 获取命令
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] GetCommand(byte functionId,byte[] content)
        {
            //头部字节
            var header = new byte[] {0xFA};
            //功能码
            var functionList = new byte[] { functionId};
            //计算长度
            var length = 5 + (content?.Length ?? 0);
            var lengthBytes = BitConverter.GetBytes((ushort)length);
            var list = header.Concat(lengthBytes).Concat(functionList);
            if (content != null)
            {
                list = list.Concat(content);
            }
            //计算校验码
            var crc16 = CRC.CRC16(list.ToArray());
            list = list.Concat(crc16);
            return list.ToArray();
           
        }


        public byte[] GetMyTest()
        {
            var header = new byte[] { 0x7a };

            var list = new byte[] { 0x42};
            return list;
        }


        /// <summary>
        /// 检测接收到的数据是否合法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool ValidateData(byte[] data)
        {
            //如果长度不对就抛弃
            if (data.Length < 6)
            {
                return false;
            }
            //如果首字母不是0xFA就抛弃
            if (data[0] != 0xFA)
            {
                return false;
            }
            //获取数据的长度(这儿先不做校验，因为比较混乱)
            var dataLength = BitConverter.ToUInt16(data.Skip(1).Take(2).ToArray(),0);
            //if (dataLength != data.Length - 1)
            //{
            //    return false;
            //}

            return true;
        }

        public void Test()
        {
            short content = 1;
            byte[] list = BitConverter.GetBytes(content);
            foreach (var b in list)
            {
                Console.WriteLine("{0:X2}",b);
            }
        }
    }
}
