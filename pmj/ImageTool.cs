using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace pmj
{
    public class ImageTool
    {
        /// <summary>
        /// 把图片转化成灰度图
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Bitmap GetGrayPic(string fileName)
        {
           
            Bitmap ImageBaseOriginal = new Bitmap(fileName);
            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(ImageBaseOriginal);
           
             mat = mat.CvtColor(ColorConversionCodes.BGR2GRAY);
            
            //mat = mat.CvtColor(ColorConversionCodes.BGRA2YUV_IYUV);
            var newBitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
            mat.Dispose();
            ImageBaseOriginal.Dispose();
            Console.WriteLine("转化完成");
            return newBitmap;
        }

        /// <summary>
        /// 对图片进行裁剪
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap GetCutPic(Bitmap bitMap, int left, int top, int width, int height)
        {
            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitMap);
            var rect = new Rect(left,top,width,height);
            var newMat = new Mat(mat,rect);
            var newBitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(newMat);
            newMat.Dispose();
            mat.Dispose();
            return newBitmap;
        }
    }
}
