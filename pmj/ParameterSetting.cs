using System;
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

        public ParameterSetting(PmjSerialPort pmjSerialPort)
        {
            InitializeComponent();
            this._pmjSerialPort = pmjSerialPort;
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
                //查询参数的命令
                var command = CommandFactory.GetPrintParameters();
                var result = _pmjSerialPort.WriteForResult(command,4000);
                if (null == result || null== result.GetData())
                {
                    MessageBox.Show("没有接受到应答数据");
                    return;
                }
                //开始解析数据
                ParseData(result.GetData());
                //读取参数成功
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ParseData(byte[] dataList)
        {
            //打印延迟
            var delayValue = BitConverter.ToUInt16(dataList, 0);
            this.numberDelay.Value = delayValue;
            //列间延迟
            var colDelay = BitConverter.ToUInt16(dataList, 2);
            this.numberColDelay.Value = colDelay;
            //编码器计数
            var colsMotos = BitConverter.ToUInt16(dataList, 4);
            this.numberCount.Value = colsMotos;
            //脉冲宽度
            var pluseWidth = BitConverter.ToUInt16(dataList, 6);
            SetCmboBoxValue(cmbPulseWidth, pluseWidth);
           //打印灰度
            var grayDelay = BitConverter.ToInt16(dataList, 8);
            SetCmboBoxValue(cmbGrayList, grayDelay);
            //打印电压
            var voltage = BitConverter.ToUInt16(dataList, 12);
            SetCmboBoxValue(cmbVList, voltage);
            //喷头的选择
            var printIndex = BitConverter.ToUInt16(dataList, 14);
            SetCmboBoxValue(cmbPrintList, printIndex);
            //打印文件
            var fileModel = BitConverter.ToUInt16(dataList, 16);
            SetCmboBoxValue(cmbFileList, fileModel);
            //自动关机设置
            var powerOff = BitConverter.ToUInt16(dataList, 22);
            //闲喷
            var idle = BitConverter.ToUInt16(dataList, 24);
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
    }
}
