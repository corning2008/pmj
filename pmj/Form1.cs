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
                _pmjSerialPort.Write(CommandFactory.GetCheckDeviceCommand());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Point _mousePoint;
        private bool _mouseDown = false;

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mousePoint.X = e.X;
                _mousePoint.Y = e.Y;
                _mouseDown = true;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                int x = label1.Left + (e.X - _mousePoint.X);
                int y = label1.Top + (e.Y - _mousePoint.Y);
                label1.Location = new Point(x,y);
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "corningtest";
            label.Font = new Font(FontFamily.GenericMonospace, 15);
            label.BorderStyle = BorderStyle.Fixed3D;
            SetItemEvent(label);
            this.panelTest.Controls.Add(label);
        }

        private void SetItemEvent(Label label)
        {
            label.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _mousePoint.X = e.X;
                    _mousePoint.Y = e.Y;
                    _mouseDown = true;
                }
            };

            label.MouseMove += (sender, e) =>
            {
                if (_mouseDown)
                {
                    int x = label.Left + (e.X - _mousePoint.X);
                    int y = label.Top + (e.Y - _mousePoint.Y);
                    var right = x + label.Size.Width;
                    var bottom = y + label.Size.Height;
                    //需要判断label的范围不能超出panel
                    if (x >= 0 && y >= 0 && right <= panelTest.Width &&
                        bottom <= panelTest.Height)
                    {
                        label.Location = new Point(x, y);
                    }
                }
                
            };

            label.MouseUp += (sender, e) => { _mouseDown = false; };
        }

        private void panelTest_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.panelTest.CreateGraphics();
            //绘制中线7a686964616fe58685e5aeb931333330353563
            graphics.Clear(Color.LightYellow);
            float x1 = this.panelTest.Width / 2;
            float y1 = 0;
            float x2 = this.panelTest.Width / 2;
            float y2 = 10;
            //注意坐标系的定义
            graphics.DrawLine(new Pen(Color.Red, 2), x1, y1, x2, y2);
           
        }

        private void btnFindDevice_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _pmjSerialPort.WriteForResult(CommandFactory.GetCheckDeviceCommand(), 2000);
                var data = result.GetData();
                Console.WriteLine(data.Length);
                
                var pmjName = Encoding.ASCII.GetString(result.GetData());
                lbPmjStatus.Text = $"{pmjName}--已连接";
            }
            catch (Exception ex)
            {
                lbPmjStatus.Text = "未连接";
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrintOnce_Click(object sender, EventArgs e)
        {
            try
            {
                _pmjSerialPort.Write(CommandFactory.GetPrintOnceCommand());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
