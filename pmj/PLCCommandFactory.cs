﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace pmj
{
    public class PLCCommandFactory
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="address">读取的地址</param>
        /// <param name="length">读取的长度</param>
        /// <returns></returns>
        public static byte[] GetReadCommand(int address, int length)
        {
            var commandid = new byte[] {0x30};
            var addressBytes = Encoding.ASCII.GetBytes((address * 2 + Convert.ToUInt32("1000", 16)).ToString("X4"));
            var lengthBytes = Encoding.ASCII.GetBytes(length.ToString("X2"));
            return GetCommand(commandid, addressBytes, lengthBytes);
        }

        /// <summary>
        /// 进行未操作
        /// </summary>
        /// <param name="address"></param>
        /// <param name="reset"></param>
        /// <returns></returns>
        public static byte[] SetBitCommand(int address,bool reset)
        {
            byte command = 0x37;
            if (reset)
            {
                command = 0x38;
            }
            var addressBytes = Encoding.ASCII.GetBytes((address/8 + Convert.ToUInt32("100", 16)).ToString("X4"));
            return GetCommand(new byte[] {command}, addressBytes, null);
        }

        /// <summary>
        /// 对接受到的数据进行校验
        /// </summary>
        /// <param name="dataBytes"></param>
        /// <returns></returns>
        public static bool ValidateData(byte[] dataBytes)
        {
            if (dataBytes.Length <= 2)
            {
                return true;
            }
            var dataSum = new byte[dataBytes.Length - 3];
            Array.Copy(dataBytes,1,dataSum,0,dataSum.Length);
            var sum = GetSum(dataSum);
            if (sum[0] == dataBytes[dataBytes.Length - 2] && sum[1] == dataBytes[dataBytes.Length - 1])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 写入指令
        /// </summary>
        /// <param name="address"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public static byte[] GetWriteCommand(int address, byte[] dataList)
        {
            if (dataList.Length % 2 != 0)
            {
                throw new Exception("字节数据必须是2的倍数");
            }
            var commandid = new byte[] {0x31};
            var addressBytes = Encoding.ASCII.GetBytes((address * 2 + Convert.ToUInt32("1000", 16)).ToString("X4"));
            var lengthBytes = Encoding.ASCII.GetBytes(dataList.Length.ToString("X2"));
            var sb = new StringBuilder();
            for (var i = 0; i < dataList.Length / 2; i++)
            {
                sb.Append(dataList[2 * i + 1].ToString("X2"));
                sb.Append(dataList[2 * i].ToString("X2"));
            }

            var dataBytes = Encoding.ASCII.GetBytes(sb.ToString());
            return GetCommand(commandid, addressBytes, lengthBytes.Concat(dataBytes).ToArray());
        }

        public static byte[] GetCommand(byte[] commandId,byte[] address,byte[] bytes)
        {
            var stx = new byte[] {0x02};
            var etx = new byte[] {0x03};
            var command = stx.Concat(commandId).Concat(address).ToArray();
            if (null != bytes)
            {
                command = commandId.Concat(bytes).ToArray();
            }
            command = command.Concat(etx).ToArray();
            var sum = GetSum(command);
            return command.Concat(sum).ToArray();
        }

        private static byte[] GetSum(byte[] command)
        {
            var sum = 0;
            for (var i = 1; i < command.Length; i++)
            {
                sum += command[i];
            }
            Console.WriteLine("sum:"+sum);
            return Encoding.ASCII.GetBytes((BitConverter.GetBytes(sum)[0]).ToString("X2"));
        }


        private void Test()
        {
          
        }
    }
}
