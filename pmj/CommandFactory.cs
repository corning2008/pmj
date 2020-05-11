using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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

    public class CommandFactory
    {

        public void Test1()
        {
            

            var command = GetPrintOnceCommand();
            foreach (var b in command)
            {
                Console.Write("{0:X2} ",b);
            }
        }


        public void Test2()
        {
            var command = GetCommand(0x01,Encoding.ASCII.GetBytes("123"));
            foreach (var b in command)
            {
                Console.Write("{0:X2} ", b);
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
        /// <returns></returns>

        public static byte[] GetDynamicInsert(EnumInsertMode insertMode, string content)
        {
            //获取头部
            byte[] header = GetInsertModeHeader(insertMode);
            //获取发送的文本
            var contentData = Encoding.ASCII.GetBytes(content);
            //获取长度
            var length = BitConverter.GetBytes((ushort) contentData.Length);
            //拼接数组
            var dataList =  header.Concat(length).Concat(contentData).ToArray();
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
            var crc16 = CRC.CRC16Ex(list.ToArray());
            list = list.Concat(crc16);
            return list.ToArray();
           
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
            //获取数据的长度
            var dataLength = BitConverter.ToUInt16(data.Skip(1).Take(2).ToArray(),0);
            if (dataLength != data.Length - 1)
            {
                return false;
            }

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
