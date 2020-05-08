using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmj
{
    public class CommandFactory
    {

        public void Test1()
        {
            var command = GetCommand(0x21, new byte[] { 0x00 });
            foreach (var b in command)
            {
                Console.Write("{0:X2} ",b);
            }
        }

        /// <summary>
        /// 获取命令
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] GetCommand(byte functionId,byte[] content)
        {
            int index = 0;
            byte[] command = new byte[content.Length+6];
            command[index] = 0x7A;
            index++;
            //计算长度
            var lengthBytes = BitConverter.GetBytes((short)(command.Length - 1));
            Array.Copy(lengthBytes,0,command,1,lengthBytes.Length);
            index += lengthBytes.Length;
            //插入功能码
            command[index] = functionId;
            index++;
            //插入内容
            Array.Copy(content,0,command,index,content.Length);
            index += content.Length;
            //获取校验码
            var crc16 = CRC.CRC16(command.Skip(1).Take(index-1).ToArray());
            Array.Copy(crc16,0,command,index,crc16.Length);
            index += crc16.Length;
            return command;
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
