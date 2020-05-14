using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmj
{
    /// <summary>
    /// 接收到的数据进行解析类
    /// </summary>
    public class DataResult
    {
        private byte[] _dataBytes;

        public DataResult(byte[] dataBytes)
        {
            this._dataBytes = dataBytes;
        }

        /// <summary>
        /// 获取功能号  21:打印返回 20:下发动态打印
        /// </summary>
        /// <returns></returns>
        public byte GetFunctionId()
        {
            return _dataBytes[3];
        }

        /// <summary>
        /// 解析收到数据长度(不包含FA)
        /// </summary>
        /// <returns></returns>
        public ushort GetLength()
        {
            return BitConverter.ToUInt16(_dataBytes.Skip(1).Take(2).ToArray(), 0);
        }

        /// <summary>
        /// 返回的数据
        /// </summary>
        /// <returns></returns>
        public byte[] GetData()
        {
            return _dataBytes.Skip(4).Take(GetLength()-5).ToArray();
        }
    }
}
