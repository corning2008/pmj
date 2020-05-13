using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ZXing;
using ZXing.QrCode;

namespace pmj
{
    public partial class Form1 : Form,ICutPicture,ITimeSetting,ISerialNumberSetting,ITextSetting,IQrcodeSetting,IBarcodeSetting
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Form1));

        public Form1()
        {
            InitializeComponent();
            Log.Info("Form1 init");
            Log.Error("test");
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
        public void GetCutPicture(string guid,PictureSettingParameter para)
        {
            this._id = guid;
            //查找是否存在这个组件
            var pmjData = _pmjDataList.FirstOrDefault(item => item.Id == guid);
            
            if (null == pmjData)
            {
                pmjData = new PmjData();
                pmjData.Id = guid;
                pmjData.DataType = EnumPmjData.图片;
                var pictureBox = new PictureBox();
                var bitmap = para.Bitmap;
                pmjData.Control = pictureBox;
                pmjData.DataSource = para;
                pictureBox.Image = bitmap;
                pictureBox.Width = bitmap.Width;
                pictureBox.Height = bitmap.Height;
                pictureBox.Name = pmjData.Id;
                pictureBox.DoubleClick += SetPmjDataClick;
                panelTest.Controls.Add(pictureBox);
                //设置可以移动
                SetItemEvent(pictureBox);
                _pmjDataList.Add(pmjData);
                
            }
            else
            {
                var pictureBox = pmjData.Control as PictureBox;
                pictureBox.Image = para.Bitmap;
                pictureBox.Width = para.Bitmap.Width;
                pictureBox.Height = para.Bitmap.Height;
                pmjData.DataSource = para;
                ResetLocation(pictureBox);
            }
          
        }


        private void SetPmjDataClick(object sender, EventArgs e)
        {
            var control = sender as Control;
            var name = (sender as Control).Name;
            this._id = name;
            var pmjData = _pmjDataList.First(item => item.Id == name);
            if (pmjData.DataType == EnumPmjData.图片)
            {
                var para = pmjData.DataSource as PictureSettingParameter;
                var userControl = para?.UserControl;
                if (null == userControl)
                {
                    return;
                }
                userControl.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(userControl);
                return;
            }

            if (pmjData.DataType == EnumPmjData.时间)
            {
                var para = pmjData.DataSource as TimeSettingParameter;
                var userControl = para?.UserControl;
                if (null == userControl)
                {
                    return;
                }
                userControl.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(userControl);
            }

            if (pmjData.DataType == EnumPmjData.序号)
            {
                var para = pmjData.DataSource as SerialNumberParameter;
                var userControll = para?.UserControl;
                if (null == userControll)
                {
                    return;
                }
                userControll.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(userControll);
                return;
            }

            if (pmjData.DataType == EnumPmjData.文本)
            {
                var para = pmjData.DataSource as TextSettingParameter;
                var userControll = para?.UserControl;
                if (null == userControll)
                {
                    return;
                }
                userControll.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(userControll);
                return;
            }
            //如果是二维码双击事件
            if (pmjData.DataType == EnumPmjData.二维码)
            {
                var para = pmjData.DataSource as QrcodeSettingParameter;
                var userControll = para?.UserControl;
                if (null == userControll)
                {
                    return;
                }
                userControll.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(userControll);
                return;
            }
            //条码
            if (pmjData.DataType == EnumPmjData.条码)
            {
                var para = pmjData.DataSource as BarcodeSettingParameter;
                var userControll = para?.UserControl;
                if (null == userControll)
                {
                    return;
                }
                userControll.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(userControll);
                return;
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

        private void btnWriteBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var pmjData in _pmjDataList)
                {
                    if (pmjData.DataType == EnumPmjData.图片)
                    {
                        var control = (pmjData.Control as PictureBox);
                        var bitmap = control.Image as Bitmap;
                        _pmjSerialPort.WriteImageBuffer(bitmap, control.Left, control.Top);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimeSetting_Click(object sender, EventArgs e)
        {
            try
            {
                panelSetting.Controls.Clear();
                var newPanel = new TimeSetting(this,new TimeSettingParameter(){Format = "yyyyMMdd",Size = 12});
                newPanel.Dock = DockStyle.Fill;
                panelSetting.Controls.Add(newPanel);
                newPanel.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Deal(string guid, TimeSettingParameter parameter)
        {
            this._id = guid;
            //查找是否存在这个组件
            var pmjData = _pmjDataList.FirstOrDefault(item => item.Id == guid);

            if (null == pmjData)
            {
                pmjData = new PmjData();
                pmjData.Id = guid;
                pmjData.DataType = EnumPmjData.时间;
                var label = new Label();
                pmjData.Control = label;
                label.Text = DateTime.Now.ToString(parameter.Format);
                label.AutoSize = true;
                label.Name = guid;
                label.Font = new Font(FontFamily.GenericMonospace,parameter.Size);
                label.DoubleClick += SetPmjDataClick;
                panelTest.Controls.Add(label);
                pmjData.DataSource = parameter;
                //设置可以移动
                SetItemEvent(label);
                _pmjDataList.Add(pmjData);

            }
            else
            {
                var label = pmjData.Control as Label;
                label.Text = DateTime.Now.ToString(parameter.Format);
                label.Font = new Font(FontFamily.GenericMonospace, parameter.Size);
                pmjData.DataSource = parameter;
                ResetLocation(label);
            }
        }

        private void btnSerialNumber_Click(object sender, EventArgs e)
        {
            try
            {
                panelSetting.Controls.Clear();
                var newPanel = new SerialNumberSetting(this, new SerialNumberParameter() { Format = "00", Size = 12 });
                newPanel.Dock = DockStyle.Fill;
                panelSetting.Controls.Add(newPanel);
                newPanel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SerialNumberDeal(string guid, SerialNumberParameter para)
        {
            try
            {
                Log.Info(para);
                this._id = guid;
                //查找是否存在这个组件
                var pmjData = _pmjDataList.FirstOrDefault(item => item.Id == guid);

                if (null == pmjData)
                {
                    pmjData = new PmjData();
                    pmjData.Id = guid;
                    pmjData.DataType = EnumPmjData.序号;
                    var label = new Label();
                    pmjData.Control = label;
                    label.Text = para.NumberInit.ToString(para.Format);
                    label.Name = guid;
                    label.AutoSize = true;
                    label.Font = new Font(FontFamily.GenericMonospace, para.Size);
                    label.DoubleClick += SetPmjDataClick;
                    panelTest.Controls.Add(label);
                    pmjData.DataSource = para;
                    //设置可以移动
                    SetItemEvent(label);
                    _pmjDataList.Add(pmjData);

                }
                else
                {
                    var label = pmjData.Control as Label;
                    label.Text = para.NumberInit.ToString(para.Format);
                    label.Font = new Font(FontFamily.GenericMonospace, para.Size);
                    pmjData.DataSource = para;
                    ResetLocation(label);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            try
            {
                var textSetting = new TextSetting(this);
                textSetting.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(textSetting);
                textSetting.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 处理文件编辑的动作
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="para"></param>
        public void DealTextSetting(string guid, TextSettingParameter para)
        {
            Log.Info(para);
            this._id = guid;
            //查找是否存在这个组件
            var pmjData = _pmjDataList.FirstOrDefault(item => item.Id == guid);

            if (null == pmjData)
            {
                pmjData = new PmjData();
                pmjData.Id = guid;
                pmjData.DataType = EnumPmjData.文本;
                var label = new Label();
                pmjData.Control = label;
                label.Text = para.Content;
                label.Name = guid;
                label.AutoSize = true;
                label.Font = new Font(FontFamily.GenericMonospace, para.Size);
                label.DoubleClick += SetPmjDataClick;
                panelTest.Controls.Add(label);
                pmjData.DataSource = para;
                //设置可以移动
                SetItemEvent(label);
                _pmjDataList.Add(pmjData);

            }
            else
            {
                var label = pmjData.Control as Label;
                label.Text = para.Content;
                label.Font = new Font(FontFamily.GenericMonospace, para.Size);
                pmjData.DataSource = para;
                ResetLocation(label);
            }
        }

        private void btnQrcode_Click(object sender, EventArgs e)
        {
            try
            {
                var qrCodeSetting = new QrcodeSetting(this);
                qrCodeSetting.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(qrCodeSetting);
                qrCodeSetting.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 对二维码的编辑信息进行处理
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="para"></param>
        public void DealQrcodeSetting(string guid, QrcodeSettingParameter para)
        {
            try
            {
                
                this._id = guid;
                //查找是否存在这个组件
                var pmjData = _pmjDataList.FirstOrDefault(item => item.Id == guid);
                //生成bitmap图片
                var bitmap = GetQrcodeBitmap(para);
                Console.WriteLine($"二维码, width:{bitmap.Width}  height:{bitmap.Height}");
                if (null == pmjData)
                {
                    pmjData = new PmjData();
                    pmjData.Id = guid;
                    pmjData.DataType = EnumPmjData.二维码;
                    var picture = new PictureBox();
                    picture.Name = guid;
                    pmjData.Control = picture;
                    picture.Image = bitmap;
                    picture.Width = bitmap.Width;
                    picture.Height = bitmap.Height;
                    picture.DoubleClick += SetPmjDataClick;
                    panelTest.Controls.Add(picture);
                    pmjData.DataSource = para;
                    //设置可以移动
                    SetItemEvent(picture);
                    _pmjDataList.Add(pmjData);
                   
                }
                else
                {
                    var pic = pmjData.Control as PictureBox;
                    //销毁原来的bitmap数据
                    (pic.Image as Bitmap)?.Dispose();
                    pic.Image = bitmap;
                    pic.Width = bitmap.Width;
                    pic.Height = bitmap.Height;
                    //有可能会越界,如果越界的话,就直接重置top的数值
                    ResetLocation(pic);

                    pmjData.DataSource = para;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        private Bitmap GetBarcodeBitmap(BarcodeSettingParameter para)
        {
            QrCodeEncodingOptions option = new QrCodeEncodingOptions()
            {
                CharacterSet = "utf8bom",
                Width = 250,
                Height = para.PicSize
            };
            BarcodeWriter bw = new BarcodeWriter(){Options = option,Format = BarcodeFormat.CODABAR};
            return bw.Write(para.Content);
        }

        /// <summary>
        /// 生成二维码的图片
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        private Bitmap GetQrcodeBitmap(QrcodeSettingParameter para)
        {
           QrCodeEncodingOptions option = new QrCodeEncodingOptions()
           {
               CharacterSet = para.QrcodeType,
               Width = para.PicSize,
               Height = para.PicSize
           };
            BarcodeWriter bw = new BarcodeWriter(){Options = option,Format = BarcodeFormat.QR_CODE};
            return bw.Write(para.Content);
        }

        private void ResetLocation(Control control)
        {
            if (control.Top + control.Height > 100)
            {
                control.Top = 0;
            }
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                var qrCodeSetting = new BarcodeSetting(this);
                qrCodeSetting.Dock = DockStyle.Fill;
                panelSetting.Controls.Clear();
                panelSetting.Controls.Add(qrCodeSetting);
                qrCodeSetting.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DealBarcodeSetting(string guid, BarcodeSettingParameter para)
        {
            try
            {

                this._id = guid;
                //查找是否存在这个组件
                var pmjData = _pmjDataList.FirstOrDefault(item => item.Id == guid);
                //生成bitmap图片
                var bitmap = GetBarcodeBitmap(para);
                Console.WriteLine($"二维码, width:{bitmap.Width}  height:{bitmap.Height}");
                if (null == pmjData)
                {
                    pmjData = new PmjData();
                    pmjData.Id = guid;
                    pmjData.DataType = EnumPmjData.条码;
                    var picture = new PictureBox();
                    picture.Name = guid;
                    pmjData.Control = picture;
                    picture.Image = bitmap;
                    picture.Width = bitmap.Width;
                    picture.Height = bitmap.Height;
                    picture.DoubleClick += SetPmjDataClick;
                    panelTest.Controls.Add(picture);
                    pmjData.DataSource = para;
                    //设置可以移动
                    SetItemEvent(picture);
                    _pmjDataList.Add(pmjData);

                }
                else
                {
                    var pic = pmjData.Control as PictureBox;
                    //销毁原来的bitmap数据
                    (pic.Image as Bitmap)?.Dispose();
                    pic.Image = bitmap;
                    pic.Width = bitmap.Width;
                    pic.Height = bitmap.Height;
                    //有可能会越界,如果越界的话,就直接重置top的数值
                    ResetLocation(pic);

                    pmjData.DataSource = para;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
    }
}
