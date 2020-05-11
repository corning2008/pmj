using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace pmj
{
    public class TestClass
    {
        public void Test()
        {
            var ZoomNumber = 1;
           Bitmap ImageBaseOriginal = new Bitmap("d:/test.bmp");
           
            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(ImageBaseOriginal);
            mat = mat.CvtColor(ColorConversionCodes.BGR2GRAY);
            OpenCvSharp.Size size = new OpenCvSharp.Size(ImageBaseOriginal.Width * ZoomNumber, ImageBaseOriginal.Height * ZoomNumber);
            Mat SizeMat = new Mat();
            Cv2.Resize(mat, SizeMat, size);
            //图片的裁剪
            var rect = new Rect(0,0,200,50);
            var newMat = new Mat(SizeMat,rect);
           
            var newBitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(newMat);
            newBitmap.Save("d:/test1.bmp");
            mat.Dispose();
            SizeMat.Dispose();
            newMat.Dispose();
            Console.WriteLine("转化完成");
        }


        public void Test2()
        {
            var bitmap = new Bitmap("d:/test1.bmp");
            Console.WriteLine($"{bitmap.Size.Width}--- {bitmap.Size.Height}");
            bitmap.Dispose();
        }
    }
}
