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
            var header = new byte[]{0x12,0x00};
            var dataLength = BitConverter.GetBytes((UInt16) Data.Length);
            var xBytes = BitConverter.GetBytes(X);
            var widthBytes = BitConverter.GetBytes(Width);
            var yBytes = BitConverter.GetBytes(Y);
            var heightBytes = BitConverter.GetBytes(Height);
            //反色2B
            var fanByte = BitConverter.GetBytes((UInt16) 00);
            return header.Concat(dataLength).Concat(xBytes).Concat(widthBytes).Concat(yBytes).Concat(heightBytes)
                .Concat(fanByte).Concat(Data).ToArray();
        }
    }

    public class CommandFactory
    {
        /// <summary>
        /// 查询系统设置的参数
        /// </summary>
        /// <returns></returns>
        public static byte[] GetPrintParameters()
        {
            return GetCommand(0x07, null);
        }


        /// <summary>
        /// 设置打印参数
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] getSetPrintParameters(byte[] content)
        {
            return GetCommand(0x06, content);
        }
        

        /// <summary>
        /// 查询系统的时间
        /// </summary>
        /// <returns></returns>
        public static byte[] GetDeviceTime()
        {
            return GetCommand(0x03, null);
        }

        /// <summary>
        /// 获取设置系统时间的命令
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static byte[] GetSetDeviceTime(DateTime dateTime)
        {
            var second = (byte) dateTime.Second;
            var min = (byte) dateTime.Minute;
            var hour = (byte) dateTime.Hour;
            var day = (byte) dateTime.Day;
            var week = (byte)dateTime.DayOfWeek;
            var month = (byte) dateTime.Month;
            var year = (byte) (dateTime.Year - 2000);
            var content = new byte[] {second, min, hour, day, week, month, year};
            return GetCommand(0x02, content);
        }

        /// <summary>
        /// 设置打印的参数 
        /// </summary>
        /// <param name="beginDelay"></param>
        /// <param name="numberCount"></param>
        /// <param name="colDelay"></param>
        /// <param name="pluseWidth"></param>
        /// <param name="grayScale"></param>
        /// <param name="vValue"></param>
        /// <param name="fileValue"></param>
        /// <param name="powerOffValue"></param>
        /// <param name="idleValue"></param>
        /// <returns></returns>
        public static byte[] GetSettingCommand(ushort beginDelay, ushort numberCount, ushort colDelay,
            ushort pluseWidth, ushort grayScale, ushort vValue, ushort fileValue, ushort powerOffValue,
            ushort idleValue)
        {

            //打印延迟
            var content = BitConverter.GetBytes(beginDelay);
            //列间延迟
            content = content.Concat(BitConverter.GetBytes(colDelay)).ToArray();
            //编码器基数
            content = content.Concat(BitConverter.GetBytes(numberCount)).ToArray();
            //脉冲宽度
            content = content.Concat(BitConverter.GetBytes(pluseWidth)).ToArray();
            //打印灰度
            content = content.Concat(BitConverter.GetBytes(grayScale)).ToArray();
            //grayDelay 未知
            content = content.Concat(BitConverter.GetBytes((ushort) 0)).ToArray();
            //打印电压
            content = content.Concat(BitConverter.GetBytes(vValue)).ToArray();
            //RorL 未知
            content = content.Concat(BitConverter.GetBytes((ushort) 0)).ToArray();
            //打印文件选择
            content = content.Concat(BitConverter.GetBytes(fileValue)).ToArray();
            //hp lut未知
            content = content.Concat(BitConverter.GetBytes((ushort) 1)).ToArray();
            //PttRasterize 
            content = content.Concat(BitConverter.GetBytes((ushort) 0)).ToArray();
            //自动关机
            content = content.Concat(BitConverter.GetBytes((ushort) powerOffValue)).ToArray();
            //闲喷
            content = content.Concat(BitConverter.GetBytes((ushort) idleValue)).ToArray();
            //NoUse[1]
            content = content.Concat(BitConverter.GetBytes((ushort) 0)).ToArray();

            return GetCommand(0x06, content);
        }

        public void Test1()
        {
            var dataList = new byte[] { 0x06, 0x00, 0x20, 0x00 };
            var crc = CRC.CRC16(dataList);
            Console.WriteLine(PmjSerialPort.GetHexString(crc));
        }


        /// <summary>
        /// 下载指令
        /// </summary>
        /// <param name="fileIndex">文件的序列号 0：第一个文件 。。。。3：第四个文件</param>
        /// <returns></returns>
        public static byte[] GetDownloadCommand(byte fileIndex)
        {
            return GetCommand(0x0A, new byte[] { fileIndex });
        }


        public void Test2()
        {
          
        }

        /// <summary>
        /// 结束下载的命令
        /// </summary>
        /// <param name="xBegin">x起点</param>
        /// <param name="xEnd">x的终点</param>
        /// <returns></returns>
        public static byte[] GetFinishDownloadCommand(ushort xBegin,ushort xEnd)
        {
            var xBeginBytes = BitConverter.GetBytes(xBegin);
            var xEndBytes = BitConverter.GetBytes(xEnd);
            var content = xBeginBytes.Concat(xEndBytes).ToArray();
            return GetCommand(0x0c, content);
        }

        /// <summary>
        /// 下发文本的命令
        /// </summary>
        /// <param name="left">left</param>
        /// <param name="top">top</param>
        /// <param name="content">下发文本的字节数组</param>
        /// <param name="fontSize">字体的index</param>
        /// <param name="distance">间距默认0x00</param>
        /// <param name="style2">样式默认0x00</param>
        /// <returns></returns>
        public static byte[] GetTextCommand(UInt16 left,UInt16 top,byte[] content,ushort fontSize,ushort distance=0x00,ushort style2=0x00)
        {
            var contentHeader = new byte[] { 0x74, 0x00 };
            var lengthBytes = BitConverter.GetBytes((ushort)content.Length);
            //字体大小
            var fontSizeBytes = BitConverter.GetBytes(fontSize);
            var leftBytes = BitConverter.GetBytes(left);
            var topBytes = BitConverter.GetBytes(top);
            var distanceBytes = BitConverter.GetBytes(distance);
            var style2Bytes = BitConverter.GetBytes(style2);
            var contentBytes = contentHeader.Concat(lengthBytes).Concat(fontSizeBytes).Concat(leftBytes).Concat(topBytes).Concat(distanceBytes).Concat(style2Bytes).Concat(content).ToArray();

            return GetCommand(0x0b, contentBytes);
        }

        /// <summary>
        /// 设置时间的命令
        /// </summary>
        /// <param name="format">时间的格式</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="space">间隔</param>
        /// <param name="style">样式</param>
        /// <returns></returns>
        public static byte[] GetTimeCommand(string format,ushort fontSize, ushort left, ushort top,byte[] timeOffset, ushort space = 0,ushort style=0)
        {
            Console.WriteLine($"时间的格式：{format}  字体大小：{fontSize}");
            var header = new byte[] {0x54, 0x00};
            //采用的字节个数
            var lengthStyle = BitConverter.GetBytes((ushort) Encoding.Default.GetBytes(format).Length);
            //字体
            var fongSizeBytes = BitConverter.GetBytes(fontSize);
            //x开始
            var xBytes = BitConverter.GetBytes(left);
            //y开始
            var yBytes = BitConverter.GetBytes(top);
            //间隔
            var spaceBytes = BitConverter.GetBytes(space);
            //格式
            var styleBytes = BitConverter.GetBytes(style);
            //偏移量
          
            //时间格式
            var timeBytes = Encoding.Default.GetBytes(format);
            
            var content = header.Concat(lengthStyle).Concat(fongSizeBytes)
                .Concat(xBytes).Concat(yBytes).Concat(spaceBytes).Concat(styleBytes).Concat(timeOffset)
                .Concat(timeBytes).ToArray();
            return GetCommand(0x0b, content);
        }

        public static List<byte[]> GetImageCommand(UInt16 left,UInt16 top, Bitmap bitmap)
        {
            var width = left + bitmap.Width > 2000 ? 2000 - left : bitmap.Width;
            var height = top + bitmap.Height > 50 ? 50 - top : bitmap.Height;
            //高度必须是8的倍数
            while (height % 8 != 0)
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
          
            try
            {
                for (var i = 0; i < width; i++)
                {
                    var heightList = new List<byte>();
                    for (var j = 0; j < height; j++)
                    {
                        var color = bitmap.GetPixel(i, j);

                        var value = color.B;
                        if (value == 255)
                        {
                            heightList.Add(0x00);
                        }
                        else
                        {
                            heightList.Add(0x01);
                        }
                        //如果高度正好8的话,就拼接成一个字节
                        if (heightList.Count == 8)
                        {
                            byteList.Add(GetContactByte(heightList));
                            heightList.Clear();
                        }
                        //如果高度不是8的倍数,并且到了最后一位就直接转化
                        if (j == height - 1 && heightList.Count > 0)
                        {
                            byteList.Add(GetContactByte(heightList));
                            break;
                        }
                    }

                    //
                    picWidth++;


                    //单个包的数量不能超过1000
                    if (byteList.Count > 200 || (i == width - 1 && byteList.Count > 0))
                    {
                        var bufferImage = new BufferImageData();
                        bufferImage.X = (UInt16)((left + i+1)-picWidth);
                        bufferImage.Y = (UInt16)top;
                        bufferImage.Width = (UInt16)picWidth;
                        bufferImage.Height = (UInt16)height;
                        bufferImage.Data = byteList.ToArray();
                        byteList.Clear();
                        picWidth = 0;
                        list.Add(GetCommandDownload(0x0b,new byte[] { 0x42,0x00},bufferImage.X,bufferImage.Y,bufferImage.Width,bufferImage.Height,bufferImage.Data));
                        Console.WriteLine($"添加分割数据  x:{bufferImage.X} width:{bufferImage.Width} y:{bufferImage.Y} height:{bufferImage.Height}");
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
                    var heightList = new List<byte>();
                    for (var j = 0; j < height; j++)
                    {
                        var color = bitmap.GetPixel(i, j);
         
                        var value = color.B;
                        if (value == 255)
                        {
                            heightList.Add(0x01);
                        }
                        else
                        {
                            heightList.Add(0x00);
                        }
                        //如果高度正好8的话,就拼接成一个字节
                        if (heightList.Count == 8)
                        {
                            byteList.Add(GetContactByte(heightList));
                            heightList.Clear();
                        }
                        //如果高度不是8的倍数,并且到了最后一位就直接转化
                        if (j == height - 1 && heightList.Count >0)
                        {
                            byteList.Add(GetContactByte(heightList));
                            break;
                        }
                    }

                    //
                    picWidth++;


                    //单个包的数量不能超过1000
                    if (byteList.Count > 200 || (i == width - 1 && byteList.Count > 0))
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
                        Console.WriteLine($"添加分割数据  x:{bufferImage.X} width:{bufferImage.Width} y:{bufferImage.Y} height:{bufferImage.Height}");
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

        private static byte GetContactByte(List<byte> heightList)
        {
            var byteValue = heightList.Last();
            for (var j = heightList.Count - 2; j >= 0; j--)
            {
                byteValue = (byte)(byteValue << 1);
                byteValue += heightList[j];
            }

            return byteValue;
        }


        private void Test3()
        {
          
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

        public static void PrintBytes(byte[] dataList)
        {
            var sb = new StringBuilder();
            foreach(var item in dataList)
            {
                sb.Append($"{item:X2} ");
            }
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 序列号设置命令
        /// </summary>
        /// <param name="strLength">序列号长度</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="left">left</param>
        /// <param name="top">top</param>
        /// <param name="interval">步进</param>
        /// <param name="initValue">初始数据</param>
        /// <param name="space">间隔</param>
        /// <param name="style">其他样式</param>
        /// <returns></returns>
        public static byte[] GetSerialNumberCommand(ushort strLength,ushort fontSize,ushort left, ushort top,ushort interval,UInt32 initValue,ushort space = 0,ushort style=0)
        {
            var contentHeader = new byte[] { 0x53, 0x00 };
            //序号的位数
            var lengthBytes = BitConverter.GetBytes(strLength);
            //字体
            var fontSizeByte = BitConverter.GetBytes(fontSize);
            //x开始
            var leftBytes = BitConverter.GetBytes(left);
            //y开始
            var topBytes = BitConverter.GetBytes(top);
            //间距
            var spanceBytes = BitConverter.GetBytes(space);
            //格式
            var styleBytes = BitConverter.GetBytes(style);
            //步进数值
            var intervalBytes = BitConverter.GetBytes(interval);
            //初始数据
            var initValueBytes = BitConverter.GetBytes(initValue);

            var content = contentHeader.Concat(lengthBytes).Concat(fontSizeByte).Concat(leftBytes).Concat(topBytes).Concat(spanceBytes)
                .Concat(styleBytes)
                .Concat(intervalBytes).Concat(initValueBytes).ToArray();
            return GetCommand(0x0b, content);
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
        /// 获取下载的位置信息
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private static byte[] GetLocationBytes(ushort left, ushort top,ushort width,ushort height)
        {
            //X起点
            var xBegin = BitConverter.GetBytes(left);
            //x宽度
            var xWidth = BitConverter.GetBytes(width);
            //y起点
            var yBegin = BitConverter.GetBytes(top);
            //y宽度
            var yHeight = BitConverter.GetBytes(height);
            //反色
            var fan = BitConverter.GetBytes((ushort)0);
            return xBegin.Concat(xWidth).Concat(yBegin).Concat(yHeight).Concat(fan).ToArray();
        }

        public static byte[] GetCommandDownload(byte functionId,byte[] contentHeader,ushort left,ushort top,ushort width,ushort height,byte[] content)
        {
         
            //获取消息的长度
            var lengthBytes = BitConverter.GetBytes((ushort)content.Length);
            var locatioBytes = GetLocationBytes(left, top, width, height);
          
            var contentCommand = contentHeader.Concat(lengthBytes).Concat(locatioBytes).Concat(content).ToArray();
            //合成整个命令
            return GetCommand(functionId, contentCommand);
        }

        /// <summary>
        /// 根据内容获取消息的头部，如果插入的是文本，头部就是0x74，0x00
        /// </summary>
        /// <param name="functionId"></param>
        /// <returns></returns>
        private static byte[] GetContentHeader(byte functionId)
        {
            //插入消息文本
            if(functionId == 0x0b)
            {
                return new byte[] { 0x74, 0x00 };
            }
            return new byte[] { 0x00, 0x00 };
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
            var crc16 = CRC.CRC16Ex(list.ToArray());
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
