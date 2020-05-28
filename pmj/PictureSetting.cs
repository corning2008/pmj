using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace pmj
{
    public partial class PictureSetting : UserControl
    {
        private string _filePath = null;
        
        public PictureSetting(string guid,Bitmap bitmap,ICutPicture iCutPicture,string filePath)
        {
            InitializeComponent();
            this.bitmap = bitmap;
            this._filePath = filePath;
            panelBack.Width = bitmap.Width;
            panelBack.Height = bitmap.Height;

            picBitmap.Image = bitmap;
            picBitmap.Size = new Size(bitmap.Width,bitmap.Height);
            picBitmap.Left = 0;
            picBitmap.Top = 0;
            //设置选中区域的最大和最小
            picWidth.Maximum = bitmap.Width;
            picHeight.Maximum = bitmap.Height > 100 ? 100 : bitmap.Height;
            picWidth.Value = 32;
            picHeight.Value = 32;
            //设置控件可移动
            SetItemEvent(btnSize);
            SetBtn();
            btnSize.Left = 0;
            btnSize.Top = 0;
            btnSize.Width = 32;
            btnSize.Height = 32;
            this._iCutPicture = iCutPicture;
            this._guid = guid;

            var newBitmap = ImageTool.GetCutPic(bitmap, btnSize.Left, btnSize.Top, btnSize.Width, btnSize.Height);
            _iCutPicture?.GetCutPicture(guid,new PictureSettingParameter(){Bitmap = newBitmap,UserControl = this});
        }


        

        public void SetBtn()
        {
            var btn = btnSize;
            btn.FlatStyle = FlatStyle.Flat;//样式
            btn.ForeColor = Color.Transparent;//前景
            btn.BackColor = Color.Transparent;//去背景
            btn.FlatAppearance.BorderSize = 1;//去边线
            btn.FlatAppearance.BorderColor = Color.Red;
            btn.Text = "";

        }


        private bool _mouseDown = false;
        private Point _mousePoint;
        private ICutPicture _iCutPicture;
        private Bitmap bitmap;
        private string _guid;


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



        private void picWidth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnSize.Width = (int) picWidth.Value;
                var newBitmap = ImageTool.GetCutPic(bitmap, btnSize.Left, btnSize.Top, btnSize.Width, btnSize.Height);
                _iCutPicture?.GetCutPicture(_guid,
                    new PictureSettingParameter() {Bitmap = newBitmap, UserControl = this});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picHeight_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnSize.Height = (int) picHeight.Value;
                var newBitmap = ImageTool.GetCutPic(bitmap, btnSize.Left, btnSize.Top, btnSize.Width, btnSize.Height);
                _iCutPicture?.GetCutPicture(_guid,
                    new PictureSettingParameter() {Bitmap = newBitmap, UserControl = this});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void btnSize_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                var newBitmap = ImageTool.GetCutPic(bitmap, btnSize.Left, btnSize.Top, btnSize.Width, btnSize.Height);
                _iCutPicture?.GetCutPicture(_guid, new PictureSettingParameter(){Bitmap = newBitmap,UserControl = this});
            }
        }

        private void panelPicSetting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numberScale_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                var value = numberScale.Value;
                var scale = value / 100m;
                //获取新的图片
                var newBitmap = ImageTool.GetGrayPic(this._filePath, scale);
                //删除原来的图片
                if(null != this.bitmap)
                {
                    bitmap.Dispose();
                }
                //
                picBitmap.Image = newBitmap;
                picBitmap.Width = newBitmap.Width;
                picBitmap.Height = newBitmap.Height;
                panelBack.Height = picBitmap.Height;
                panelBack.Width = picBitmap.Width;
                this.bitmap = newBitmap;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }


    public interface ICutPicture
    {
        void GetCutPicture(string guid,PictureSettingParameter para);
    }

    public class PictureSettingParameter
    {
        /// <summary>
        /// 裁剪的图片
        /// </summary>
        public Bitmap Bitmap { get; set; }

        /// <summary>
        /// 编辑控件
        /// </summary>
        public UserControl UserControl { get; set; }
    }
}
