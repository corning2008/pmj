﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmj
{


    public partial class ParameterSetting : UserControl
    {
        private PmjSerialPort _pmjSerialPort;
        private PLCSerialPort _plcSerialPort;
        private string _pmjPort;
        private string _plcPort;

        public ParameterSetting(PmjSerialPort pmjSerialPort,string pmjPort,PLCSerialPort pLCSerialPort,string plcPort)
        {
            InitializeComponent();
            this._pmjSerialPort = pmjSerialPort;
            this._plcSerialPort = pLCSerialPort;
            this._pmjPort = pmjPort;
            this._plcPort = plcPort;
        }

        private void btnGetSystemTime_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ParameterSetting_Load(object sender, EventArgs e)
        {
            //灰度
            cmbGrayList.DataSource = CmbDataItemFactory.GetGrayList();
            //喷头电压
            cmbVList.DataSource = CmbDataItemFactory.GetVList();
            //喷头选择
            cmbPrintList.DataSource = CmbDataItemFactory.GetPrintList();
            //自动关机
            cmbShutdownList.DataSource = CmbDataItemFactory.GetShutdownList();
            //打印文件
            cmbFileList.DataSource = CmbDataItemFactory.GetPaperList();
            //闲置设置
            cmbLeaveTime.DataSource = CmbDataItemFactory.GetLeaveTimeList();
            //脉冲宽度
            cmbPulseWidth.DataSource = CmbDataItemFactory.GetPulseWidthList();
            //保留参数
            cmbParameter2.DataSource = CmbDataItemFactory.GetRetainParameterList();
        }

        private void btnReadDeviceTime_Click(object sender, EventArgs e)
        {
            try
            {
                var command = CommandFactory.GetDeviceTime();
                var dataR = _pmjSerialPort.WriteForResult(command,4000);

                var data = dataR.GetData();
                var year = 2000 + data[6];
                var month = 0 + data[5];
                var day = 0 + data[3];
                var hour = 0 + data[2];
                var min = 0 + data[1];
                var second = 0 + data[0];
                var date = new DateTime(year, month, day, hour, min, second);
                this.tbTime.Text = date.ToString("yyyy/MM/dd HH:mm:ss");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //获取设置时间的命令
                var command = CommandFactory.GetSetDeviceTime(DateTime.Now);
                var flag = _pmjSerialPort.SendCommand(command, out DataResult result);
               
              
                MessageBox.Show("同步时间成功");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReadParameter_Click(object sender, EventArgs e)
        {
            try
            {
              
                _pmjSerialPort.ReadParameter();
                //开始解析数据
                ParseData();
                //读取参数成功
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ParseData()
        {
            //打印延迟
            var delayValue = Parameters.DelayValue;
            this.numberDelay.Value = delayValue;
            //列间延迟
            var colDelay = Parameters.ColDelay;
            this.numberColDelay.Value = colDelay;
            //编码器计数
            var colsMotos = Parameters.ColMoto;
            this.numberCount.Value = colsMotos;
            //脉冲宽度
            var pluseWidth = Parameters.PluseWidth;
            SetCmboBoxValue(cmbPulseWidth, pluseWidth);
           //打印灰度
            var grayDelay = Parameters.GrayDelay;
            SetCmboBoxValue(cmbGrayList, grayDelay);
            //打印电压
            var voltage = Parameters.Voltage;
            SetCmboBoxValue(cmbVList, voltage);
            //喷头的选择
            var printIndex = Parameters.PrintIndex;
            SetCmboBoxValue(cmbPrintList, printIndex);
            //打印文件
            var fileModel = Parameters.FileModel;
            SetCmboBoxValue(cmbFileList, fileModel);
        
            //闲喷
            var idle = Parameters.Idle;
            SetCmboBoxValue(cmbLeaveTime, idle);

        }

        private void SetCmboBoxValue(ComboBox combobox, int value)
        {
            var dataList = combobox.DataSource as List<CmbDataItem>;
            if(null == dataList)
            {
                return;
            }
            foreach(var item in dataList)
            {
                if(item.Value== value)
                {
                    combobox.SelectedItem = item;
                    break;
                }
            }

        }

        private void btnSettingParameter_Click(object sender, EventArgs e)
        {
            try
            {
                //设置打印延迟
                var numberDelayBytes = BitConverter.GetBytes((ushort) numberDelay.Value);
                //列间延迟
                var colDelayBytes = BitConverter.GetBytes((ushort) numberColDelay.Value);
                //编码器基数
                var numberCountBytes = BitConverter.GetBytes((ushort) numberCount.Value);
                //脉冲宽度
                var pulseWidthBytes =
                    BitConverter.GetBytes((ushort) (cmbPulseWidth.SelectedItem as CmbDataItem).Value);
                //打印灰度
                var grayScaleBytes = BitConverter.GetBytes((ushort) (cmbGrayList.SelectedItem as CmbDataItem).Value);
                //打印电压
                var vBytes = BitConverter.GetBytes((ushort) (cmbVList.SelectedItem as CmbDataItem).Value);
                //左右喷头选择
                var printBytes = BitConverter.GetBytes((ushort) (cmbPrintList.SelectedItem as CmbDataItem).Value);
                //打印文件选择
                var fileIndexBytes = BitConverter.GetBytes((ushort) (cmbFileList.SelectedItem as CmbDataItem).Value);
                //自动关机
                var powerOffBytes = new byte[] { 0x2c, 0x01 };/* BitConverter.GetBytes((ushort) (cmbShutdownList.SelectedItem as CmbDataItem).Value);*/
                //闲喷
                var idleBytes = BitConverter.GetBytes((ushort) (cmbLeaveTime.SelectedItem as CmbDataItem).Value);

                var content = numberDelayBytes.Concat(colDelayBytes).Concat(numberCountBytes).Concat(pulseWidthBytes)
                    .Concat(grayScaleBytes).Concat(new byte[] {0x55, 0x00}).Concat(vBytes)
                    .Concat(printBytes).Concat(fileIndexBytes).Concat(new byte[] {0x00, 0x00})
                    .Concat(new byte[] {0x00, 0x00}).Concat(powerOffBytes).Concat(idleBytes).ToArray();
                var command = CommandFactory.getSetPrintParameters(content);
                var flag = _pmjSerialPort.SendCommand(command, out DataResult result);
              

                MessageBox.Show("打印参数设置成功");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenPmj(this._pmjPort, out string printerName);
                MessageBox.Show("打开喷码机成功");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPlc_Click(object sender, EventArgs e)
        {
            try
            {
                OpenPlc(this._plcPort);
                MessageBox.Show("打开PLC串口成功");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 判断是否已经打开
        /// </summary>
        /// <param name="printerName"></param>
        /// <returns></returns>
        private bool OpenPmj(string portName,out string printerName)
        {
            if (string.IsNullOrEmpty(portName))
            {
                throw new Exception("喷码机端口不能为空");
            }
            //首先关闭原来的串口
            if (null != _pmjSerialPort)
            {
                var portName1 = _pmjSerialPort.GetPortName();
                //比较端口的名称，如果端口名称已经改变，就需要重新建立连接
                if (!portName.Equals(portName1))
                {
                    _pmjSerialPort.Close();
                    _pmjSerialPort = new PmjSerialPort(portName, new PmjDataRecv());
                }
            }
            //如果不存在的话，也需要重新建立
            if (null == _pmjSerialPort)
            {
                _pmjSerialPort = new PmjSerialPort(portName, new PmjDataRecv());
            }

            return _pmjSerialPort.HasPrinter(out printerName);
        }

        /// <summary>
        /// 打开PLC
        /// </summary>
        private void OpenPlc(string portName)
        {
            if (string.IsNullOrEmpty(portName))
            {
                throw new Exception("PLC端口不能为空");
            }
            if (null == _plcSerialPort)
            {
                _plcSerialPort = new PLCSerialPort(portName, null);
            }
            else
            {
                var portName1 = _plcSerialPort.GetPortName();
                if (!portName.Equals(portName1))
                {
                    //如果端口不通的话,就先关闭原来的port
                    _plcSerialPort.Close();
                    _plcSerialPort = new PLCSerialPort(portName, null);
                }
            }

            var flag = _plcSerialPort.Open();
            if (!flag)
            {
                throw new Exception("打开PLC失败");
            }
        }

        private void btnReadPLC_Click(object sender, EventArgs e)
        {
            try
            {
                
                number610.Value  = BitConverter.ToInt16(_plcSerialPort.GetByteStatus(610,2),0);
                number611.Value = BitConverter.ToInt16(_plcSerialPort.GetByteStatus(611,2),0);
                number612.Value = BitConverter.ToInt16(_plcSerialPort.GetByteStatus(612,2),0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSetPlc_Click(object sender, EventArgs e)
        {
            try
            {
                var value610 = BitConverter.GetBytes((short)number610.Value);
                _plcSerialPort.WriteDatasEx(610, value610, 500);
                var value611 = BitConverter.GetBytes((short)number611.Value);
                _plcSerialPort.WriteDatasEx(611, value611, 500);
                var value612 = BitConverter.GetBytes((short)number612.Value);
                _plcSerialPort.WriteDatasEx(612,value612, 500);
                //保存设置
                _plcSerialPort.SetBitValue(108, 1);
                MessageBox.Show("操作完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
