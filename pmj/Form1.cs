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
    public partial class Form1 : Form,ICutPicture
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

        private List<PmjData> _pmjDataList = new List<PmjData>();
        private string _id;

        private void btnAddText_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "corningtest";
            label.Font = new Font(FontFamily.GenericMonospace, 15);
            label.BorderStyle = BorderStyle.Fixed3D;
            SetItemEvent(label);
            this.panelTest.Controls.Add(label);
        }

        private void SetItemEvent(Control label)
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
                    var control = label.Parent;
                    //需要判断label的范围不能超出panel
                    if (x >= 0 && y >= 0 && right <= control.Width &&
                        bottom <= control.Height)
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
            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            for (var i = 0; i < this.panelTest.Width; i++)
            {
                
                if (i % 5 == 0)
                {
                    //注意坐标系的定义
                    graphics.DrawLine(new Pen(Color.Red, 2), i, 0, i, 5);
                  
                }

                if (i % 100 == 0)
                {
                    graphics.DrawString(i.ToString(), drawFont, drawBrush, new PointF(i, 9));
                }
            }
            //计算有坐标
            for (var j = 0; j < this.panelTest.Height; j++)
            {
                if (j % 5 == 0)
                {
                    //注意坐标系的定义
                    graphics.DrawLine(new Pen(Color.Red, 2), 0, j, 5, j);

                }

                if (j % 50 == 0 && j!=0)
                {
                    graphics.DrawString(j.ToString(), drawFont, drawBrush, new PointF(9, j));
                }
            }
           
           
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

        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog();
                dialog.Filter = "bmp图片|*.bmp";
                var flag = dialog.ShowDialog();
                if (flag == DialogResult.OK)
                {
                    var filePath = dialog.FileName;
                    Console.WriteLine(filePath);
                    //加载图片设置的类
                    this.panelSetting.Controls.Clear();
                    var pictureSetting = new PictureSetting(Guid.NewGuid().ToString("N"),ImageTool.GetGrayPic(filePath),this);
                    pictureSetting.Dock = DockStyle.Fill;
                    this.panelSetting.Controls.Add(pictureSetting);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 裁剪到的图片
        /// </summary>
        /// <param name="bitmap"></param>
        public void GetCutPicture(Bitmap bitmap,Bitmap srcBitmap,int left,int top,string guid)
        {
            this._id = guid;
            //查找是否存在这个组件
            var pmjData = _pmjDataList.FirstOrDefault(item => item.Id == guid);
           
            if (null == pmjData)
            {
                pmjData = new PmjData();
                pmjData.Id = guid;
                pmjData.DateType = EnumPmjData.图片;
                var pictureBox = new PictureBox();
                pmjData.Control = pictureBox;
                pictureBox.Image = bitmap;
                pictureBox.Width = bitmap.Width;
                pictureBox.Height = bitmap.Height;
                pictureBox.Name = pmjData.Id;
                pictureBox.DoubleClick += SetPmjDataClick;
                panelTest.Controls.Add(pictureBox);
                pmjData.Bitmap = srcBitmap;
                pmjData.Left = left;
                pmjData.Top = top;
                //设置可以移动
                SetItemEvent(pictureBox);
                _pmjDataList.Add(pmjData);
                
            }
            else
            {
                var pictureBox = pmjData.Control as PictureBox;
                pictureBox.Image = bitmap;
                pictureBox.Width = bitmap.Width;
                pictureBox.Height = bitmap.Height;
                pmjData.Left = left;
                pmjData.Top = top;
            }
          
        }

        private void SetPmjDataClick(object sender, EventArgs e)
        {
            var control = sender as Control;
            var name = (sender as Control).Name;
            this._id = name;
            var pmjData = _pmjDataList.First(item => item.Id == name);
            if (pmjData.DateType == EnumPmjData.图片)
            {
                var pictureSetting = new PictureSetting(pmjData.Id,pmjData.Bitmap,this,control.Width,control.Height,pmjData.Left,pmjData.Top);
                pictureSetting.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(pictureSetting);
            }
        }

        private void btnPmjDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_id))
                {
                    MessageBox.Show("请选择要删除的组件");
                    return;
                }

                var pmjData = _pmjDataList.FirstOrDefault(item => item.Id == _id);
              
                if (pmjData != null)
                {
                    //从序列中删除元素
                    _pmjDataList.Remove(pmjData);
                    pmjData.Bitmap?.Dispose();
                    this.panelTest.Controls.Remove(pmjData.Control);
                    pmjData.Control.Dispose();
                    //重新加载配置页面
                    var lastData = _pmjDataList.LastOrDefault();
                    if (null == lastData)
                    {
                        panelSetting.Controls.Clear();
                        return;
                    }
                    //重新加载配置元素
                    SetPmjDataClick(lastData.Control,null);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
