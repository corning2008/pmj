using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GodSharp.SerialPort;
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
            //加载文件列表
            var fileList = CmbDataItemFactory.GetFileList();
            cmbFileList.DataSource = fileList;
            //plc的文件列表
            comboPlcList.DataSource = GetSerialPortList1();
            //获取选中的端口,从配置文件中直接读取,如果不存在的话,就默认第一项
            SetPort();
        }

        private void SetPort()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //查询pmj的端口
            if (null == configuration.AppSettings.Settings["pmjport"])
            {
                comboBoxPmj.SelectedIndex = 0;
            }
            else
            {
                var selectPort = configuration.AppSettings.Settings["pmjport"].Value;
                comboBoxPmj.SelectedItem = selectPort;
            }
            //查询plc的端口
            if (null == configuration.AppSettings.Settings["plcport"])
            {
                comboPlcList.SelectedIndex = 0;
            }
            else
            {
                var selectPort = configuration.AppSettings.Settings["plcport"].Value;
                comboPlcList.SelectedItem = selectPort;
            }
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


        private List<string> GetSerialPortList1()
        {
            var list = new List<String>();
            foreach (var name in SerialPort.GetPortNames())
            {
                list.Add(name);
            }

            return list;
        }


        private PmjSerialPort _pmjSerialPort;
        //plc的串口
        private PLCSerialPort _plcSerialPort;

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
                //
                _plcSerialPort?.Close();
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
                    var right = x + label.Size.Width/1.1;
                    var bottom = y + label.Size.Height/1.1;
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

        /// <summary>
        /// 是否连接到PLC
        /// </summary>
        /// <returns></returns>
        private bool HasCheckPLC()
        {
           
            if (null != _plcSerialPort)
            {
                if (!_pmjSerialPort.GetPortName().Equals(comboPlcList.Text))
                {
                    _plcSerialPort.GetSerialPort().Close();
                    _plcSerialPort = null;
                }
                else
                {
                    if (_plcSerialPort.IsOpen())
                    {
                        return true;
                    }
                }
            }

            if (null == _plcSerialPort)
            {
                _plcSerialPort = new PLCSerialPort(comboPlcList.Text, null);
            }


            //判断是否应打开串口,如果没有打开的话,就打开串口服务
            if (!_plcSerialPort.IsOpen())
            {
                _plcSerialPort.Open();
            }

            return true;
        }

        /// <summary>
        /// 判断是否已经打开
        /// </summary>
        /// <param name="printerName"></param>
        /// <returns></returns>
        private bool OpenPmj(out string printerName)
        {
            //首先关闭原来的串口
            if(null != _pmjSerialPort)
            {
                var portName = _pmjSerialPort.GetPortName();
                //比较端口的名称，如果端口名称已经改变，就需要重新建立连接
                if (!portName.Equals(comboBoxPmj.Text))
                {
                    _pmjSerialPort.Close();
                    _pmjSerialPort = new PmjSerialPort(comboBoxPmj.Text, new PmjDataRecv());
                }
            }
            //如果不存在的话，也需要重新建立
            if(null == _pmjSerialPort)
            {
                _pmjSerialPort = new PmjSerialPort(comboBoxPmj.Text, new PmjDataRecv());
            }
           
            return _pmjSerialPort.HasPrinter(out printerName);
        }

        private void btnFindDevice_Click(object sender, EventArgs e)
        {
            try
            {


                var flag = OpenPmj(out string printerName);
                if (!flag)
                {
                    MessageBox.Show("没有扫描到打印机");
                    return;
                }
              
                lbPmjStatus.Text = $"{printerName}";
              
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
                //判断打印机是否存在
                var flag = OpenPmj(out string printerName);
                lbPmjStatus.Text = printerName;
                if (!flag)
                {
                    return;
                }
                var result = _pmjSerialPort.Print();
                if(null != result)
                {
                    MessageBox.Show("打印完成");
                }
                else
                {
                    MessageBox.Show("打印返回状态异常");
                }
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
                dialog.Filter = "(*.jpg;*.bmp;*.jpeg)|*.jpg;*.bmp;*.jpeg";
                var flag = dialog.ShowDialog();
                if (flag == DialogResult.OK)
                {
                    var filePath = dialog.FileName;
                    Console.WriteLine(filePath);
                    //加载图片设置的类
                    this.panelSetting.Controls.Clear();
                    var pictureSetting = new PictureSetting(Guid.NewGuid().ToString("N"),ImageTool.GetGrayPic(filePath,1),this,filePath);
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
                Console.WriteLine($"图片格式:{para.Bitmap.PixelFormat}");
                pmjData.Control = pictureBox;
                pmjData.DataSource = para;
                SetPictureBoxImage(pictureBox, bitmap);
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
                pictureBox?.Image.Dispose();
                SetPictureBoxImage(pictureBox, para.Bitmap);
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
                
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Margin = new Padding(0);
                label.Padding = new Padding(0);
                
                label.Name = guid;
                label.AutoSize = true;
                label.Font = new Font(FontFamily.GenericMonospace, para.Size,FontStyle.Regular,GraphicsUnit.Pixel);
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
                    //设置组件的图片
                    SetPictureBoxImage(picture, bitmap);
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
                    SetPictureBoxImage(pic, bitmap);
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
                Width = 50,
                Height = para.PicSize
            };
            BarcodeWriter bw = new BarcodeWriter(){Options = option,Format = BarcodeFormat.CODABAR};
            return ImageTool.ConvertBitmapTo8(bw.Write(para.Content));
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
            return ImageTool.ConvertBitmapTo8(bw.Write(para.Content));
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

        private void SetPictureBoxImage(PictureBox pictureBox,Bitmap bitmap)
        {
            pictureBox.Image = bitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = bitmap.Width * 2;
            pictureBox.Height = bitmap.Height * 2;
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
               
                Console.WriteLine($"二维码, width:{bitmap.Width}  height:{bitmap.Height} format:{bitmap.PixelFormat}");
                if (null == pmjData)
                {
                    pmjData = new PmjData();
                    pmjData.Id = guid;
                    pmjData.DataType = EnumPmjData.条码;
                    var picture = new PictureBox();
                    picture.Name = guid;
                    pmjData.Control = picture;
                    SetPictureBoxImage(picture, bitmap);
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
                    SetPictureBoxImage(pic, bitmap);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var content = "fa 1c 00 0b 74 00 09 00 00 00 00 00 00 00 00 00 00 00 c9 fa b2 fa c8 d5 c6 da 3a aa aa";
                var sb = new StringBuilder();
                for (var i = 0; i < content.Length; i += 2)
                {
                    sb.Append(content.Substring(i, 2));
                    //sb.Append(" ");
                }


                var result = _pmjSerialPort.WriteHexString(sb.ToString(),4000);
                var data = result.GetData();
                if(null != data && data.Length > 0)
                {
                    Console.WriteLine($"返回数据Content：{PmjSerialPort.GetHexString(data)}");
                }
                else
                {
                    Console.WriteLine("中间不存在内容");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTip_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                //执行下载之前，先扫描是否存在打印机， 如果存在就下发，如果不存在就提示用户
                if(null == _pmjSerialPort)
                {
                    _pmjSerialPort = new PmjSerialPort(comboBoxPmj.Text, new PmjDataRecv());
                }
                var flagPrinter = _pmjSerialPort.HasPrinter(out string printerName);
                lbPmjStatus.Text = printerName;
                if (!flagPrinter)
                {
                    MessageBox.Show("没有扫描到打印机");
                    return;
                }
                //判断下发对象是否存在
                if(_pmjDataList.Count == 0)
                {
                    MessageBox.Show("请编辑下发对象");
                    return;
                }
                //获取File的列表
                var cmbData = cmbFileList.SelectedItem as CmbDataItem;
             
                //下发下载的指令
                var commandDownload = CommandFactory.GetDownloadCommand((byte)cmbData.Value);
                var result = _pmjSerialPort.SendCommand(commandDownload,out DataResult dataResult);
               
                if(!result)
                {
                    MessageBox.Show("下发下载文件的命令执行失败");
                    return;
                }
                //
                foreach(var item in _pmjDataList)
                {
                    //下发文本
                    if(item.DataType == EnumPmjData.文本)
                    {
                        var label = item.Control as Label;
                        var settingPanel = (item.DataSource as TextSettingParameter).UserControl as TextSetting;
                        
                        var commandText = CommandFactory.GetTextCommand((ushort)(label.Left/2), (ushort)(label.Top/2), Encoding.Default.GetBytes(label.Text),(ushort)settingPanel.GetSelectFont().Value);
                        var resultForSend = _pmjSerialPort.SendCommand(commandText,out DataResult resultF);
                        if (!resultForSend)
                        {
                            MessageBox.Show("文本命令下发失败");
                            break;
                        }
                    }
                    //下发序列号
                    if (item.DataType == EnumPmjData.序号)
                    {
                        var lable = item.Control as Label;
                        var settingPanel =
                            (item.DataSource as SerialNumberParameter).UserControl as SerialNumberSetting;
                        var timeCommand = CommandFactory.GetSerialNumberCommand((ushort) lable.Text.Length,
                            (ushort) settingPanel.GetFontValue(), (ushort) (lable.Left/2), (ushort) (lable.Top/2),
                            (ushort) settingPanel.GetIntervalValue(), (uint)settingPanel.GetInitValue());
                        var resultForSend = _pmjSerialPort.SendCommand(timeCommand, out DataResult resultF);
                        if (!resultForSend)
                        {
                            MessageBox.Show("序列号命令下发失败");
                            break;
                        }
                    }
                    //下发设置的时间
                    if (item.DataType == EnumPmjData.时间)
                    {
                        var label = item.Control as Label;
                        var settingPanel = (item.DataSource as TimeSettingParameter).UserControl as TimeSetting;
                        var format = settingPanel.GetTimeFormat();
                        var fontSize = settingPanel.GetFongValue();
                        //获取时间的偏移量
                        var timeOffset = settingPanel.GetTimeOffSet();
                        var commandTime = CommandFactory.GetTimeCommand(format, (ushort) fontSize, (ushort)(label.Left/2), (ushort)(label.Top/2),timeOffset);
                        var resultForSend = _pmjSerialPort.SendCommand(commandTime, out DataResult resultF);
                        if (!resultForSend)
                        {
                            MessageBox.Show("时间命令下发失败");
                            break;
                        }
                    }
                    //图片
                    if (item.DataType == EnumPmjData.图片 || item.DataType == EnumPmjData.二维码 || item.DataType == EnumPmjData.条码)
                    {
                        var control = (item.Control as PictureBox);
                        var bitmap = control.Image as Bitmap;
                        Console.WriteLine($"图片大小 width:{bitmap.Width} height:{bitmap.Height}");
                        var flagImage = _pmjSerialPort.WriteImageBuffer(bitmap, control.Left/2, control.Top/2);
                        if (!flagImage)
                        {
                            MessageBox.Show("图片命令下发失败");
                            break;
                        }
                    }


                }
                //结束下载，首先获取x的最大的终点
                var xEnd = GetEndX();
                var command = CommandFactory.GetFinishDownloadCommand(0, (ushort)xEnd);
                var flag = _pmjSerialPort.SendCommand(command, out DataResult p);
                if (!flag)
                {
                    MessageBox.Show("结束下载命令下发失败");
                    return;
                }
                MessageBox.Show("下载文件成功");
                return;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取x的最大值
        /// </summary>
        /// <returns></returns>
        private int GetEndX()
        {
            var x = 0;
            foreach(var item in _pmjDataList)
            {
                if((int)(item.Control.Left/2)+item.Control.Width > x)
                {
                    x = (int)(item.Control.Left/2) + item.Control.Width;
                }
            }
            return x;
        }

        private void btnParameter_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new FormSetting(this._pmjSerialPort);
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCleanPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                _plcSerialPort.SetBitValue(100, 1);
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenPlc()
        {
            if (null == _plcSerialPort)
            {
                _plcSerialPort = new PLCSerialPort(comboPlcList.Text, null);
            }
            else
            {
                var portName = _plcSerialPort.GetPortName();
                if (!portName.Equals(comboPlcList.Text))
                {
                    //如果端口不通的话,就先关闭原来的port
                    _plcSerialPort.Close();
                    _plcSerialPort = new PLCSerialPort(comboPlcList.Text,null);
                }
            }

            var flag = _plcSerialPort.Open();
            if (!flag)
            {
                throw new Exception("打开PLC失败");
            }
        }

        private void btnOpenPlc_Click(object sender, EventArgs e)
        {
            try
            {
               OpenPlc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// plc 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlcPrint_Click(object sender, EventArgs e)
        {
            try
            {
               // OpenPlc();
               // OpenPmj(out string printName);
                //把内容下载到打印机中
                //if (string.IsNullOrEmpty(tbBankSerial.Text))
                //{
                //    MessageBox.Show("请输入银行卡号");
                //    return;
                //}
                //_pmjSerialPort.SendBankSerial(tbBankSerial.Text.Trim());
                var list = new List<int>();
                list.Add(0);
                list.Add(1);
                if (list.Count == 0)
                {
                    MessageBox.Show("请选择要打印的文件");
                    return;
                }
                //
                PLCPrinter.PrintList(_pmjSerialPort, _plcSerialPort, list, 2000);
                //保存配置的端口
                SavePort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Error(ex);
            }
        }

        private void SavePort()
        {
            //保存喷码机的端口
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (configuration.AppSettings.Settings["pmjport"] == null)
            {
                configuration.AppSettings.Settings.Add("pmjport",comboBoxPmj.Text);
            }
            else
            {
                configuration.AppSettings.Settings["pmjport"].Value = comboBoxPmj.Text;
            }
            //保存plc的端口
            if (configuration.AppSettings.Settings["plcport"] == null)
            {
                configuration.AppSettings.Settings.Add("plcport",comboPlcList.Text);
            }
            else
            {
                configuration.AppSettings.Settings["plcport"].Value = comboPlcList.Text;
            }

            configuration.Save(ConfigurationSaveMode.Modified);
            //重新加载配置文件
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            try
            {
              
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Invoke(Func<object> p)
        {
            throw new NotImplementedException();
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
               
                return;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            SavePort();
        }
    }
}
