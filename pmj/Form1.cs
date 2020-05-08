using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载串口
            var serialPortList = GetSerialPortList();
            comboBoxPmj.DataSource = serialPortList;
        }

        private List<String> GetSerialPortList()
        {
            var list = new List<String>();
            foreach (var name in SerialPort.GetPortNames())
            {
                list.Add(name);
            }

            return list;
        }

        private PmjSerialPort _pmjSerialPort;

        private void btnOpenPortPmj_Click(object sender, EventArgs e)
        {
            try
            {
                //首先关闭原来的串口
                _pmjSerialPort?.Close();
                _pmjSerialPort = new PmjSerialPort(comboBoxPmj.Text,new PmjDataRecv());
                //打开串口
                if (_pmjSerialPort.Open())
                {
                    Console.WriteLine("打开串口成功");
                }
                else
                {
                    Console.WriteLine("打开串口失败");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //关闭串口
                _pmjSerialPort?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                _pmjSerialPort.Write(CommandFactory.GetDynamicInsert(EnumInsertMode.文本,"1234abc"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
