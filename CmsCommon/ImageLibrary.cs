using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Web;  

namespace Cms.Common
{
    /// <summary>  
    /// 图像处理类  
    /// </summary>  
    public class ImageLibrary
    {
        /// <summary>  
        /// 两张图片的对比结果  
        /// </summary>  
        public enum CompareResult
        {
            ciCompareOk,
            ciPixelMismatch,
            ciSizeMismatch
        };


        /// <summary>  
        /// 对比两张图片  
        /// </summary>  
        /// <param name="bmp1">The first bitmap image</param>  
        /// <param name="bmp2">The second bitmap image</param>  
        /// <returns>CompareResult</returns>  
        public static CompareResult CompareTwoImages(Bitmap bmp1, Bitmap bmp2)
        {
            CompareResult cr = CompareResult.ciCompareOk;

            //Test to see if we have the same size of image  
            if (bmp1.Size != bmp2.Size)
            {
                cr = CompareResult.ciSizeMismatch;
            }
            else
            {
                //Convert each image to a byte array  
                System.Drawing.ImageConverter ic =
                       new System.Drawing.ImageConverter();
                byte[] btImage1 = new byte[1];
                btImage1 = (byte[])ic.ConvertTo(bmp1, btImage1.GetType());
                byte[] btImage2 = new byte[1];
                btImage2 = (byte[])ic.ConvertTo(bmp2, btImage2.GetType());

                //Compute a hash for each image  
                SHA256Managed shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);

                //Compare the hash values  
                for (int i = 0; i < hash1.Length && i < hash2.Length
                                  && cr == CompareResult.ciCompareOk; i++)
                {
                    if (hash1[i] != hash2[i])
                        cr = CompareResult.ciPixelMismatch;
                }
            }
            return cr;
        }

        public enum ScaleMode
        {
            /// <summary>  
            /// 指定高宽缩放（可能变形）  
            /// </summary>  
            HW,
            /// <summary>  
            /// 指定宽，高按比例  
            /// </summary>  
            W,
            /// <summary>  
            /// 指定高，宽按比例  
            /// </summary>  
            H,
            /// <summary>  
            /// 指定高宽裁减（不变形）  
            /// </summary>  
            Cut
        };

        /// <summary>  
        /// Resizes the image by a percentage  
        /// </summary>  
        /// <param name="imgPhoto">The img photo.</param>  
        /// <param name="Percent">The percentage</param>  
        /// <returns></returns>  
        // http://www.codeproject.com/csharp/imageresize.asp  
        public static Image ResizeImageByPercent(Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                    imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }


        /// <summary>  
        /// 缩放、裁切图片  
        /// </summary>  
        /// <param name="originalImage"></param>  
        /// <param name="width"></param>  
        /// <param name="height"></param>  
        /// <param name="mode"></param>  
        /// <returns></returns>  
        public static Image ResizeImageToAFixedSize(Image originalImage, int width, int height, ScaleMode mode)
        {
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case ScaleMode.HW:
                    break;
                case ScaleMode.W:
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case ScaleMode.H:
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case ScaleMode.Cut:
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片  
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画布  
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置画布的描绘质量  
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //清空画布并以透明背景色填充  
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分  
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            g.Dispose();

            return bitmap;
        }

    } 
}
