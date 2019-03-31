using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
///ThumNail 的摘要说明
/// </summary>
public class ThumNail
{
	public ThumNail()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="orginalImagePat">原图片地址</param>
    /// <param name="thumNailPath">缩略图地址</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="model">生成缩略的模式</param>
    public static void MakeThumNail(string originalImagePath, string thumNailPath, int width, int height, string model)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int thumWidth = width;      //缩略图的宽度
        int thumHeight = height;    //缩略图的高度

        int x = 0;
        int y = 0;

        int originalWidth = originalImage.Width;    //原始图片的宽度
        int originalHeight = originalImage.Height;  //原始图片的高度

        switch (model)
        {
            case "HW":      //指定高宽缩放,可能变形
                break;
            case "W":       //指定宽度,高度按照比例缩放
                thumHeight = originalImage.Height * width / originalImage.Width;
                break;
            case "H":       //指定高度,宽度按照等比例缩放
                thumWidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut":
                if ((double)originalImage.Width / (double)originalImage.Height > (double)thumWidth / (double)thumHeight)
                {
                    originalHeight = originalImage.Height;
                    originalWidth = originalImage.Height * thumWidth / thumHeight;
                    y = 0;
                    x = (originalImage.Width - originalWidth) / 2;
                }
                else
                {
                    originalWidth = originalImage.Width;
                    originalHeight = originalWidth * height / thumWidth;
                    x = 0;
                    y = (originalImage.Height - originalHeight) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(thumWidth, thumHeight);

        //新建一个画板
        System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量查值法
        graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量，低速度呈现平滑程度
        graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        graphic.Clear(System.Drawing.Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        graphic.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, thumWidth, thumHeight), new System.Drawing.Rectangle(x, y, originalWidth, originalHeight), System.Drawing.GraphicsUnit.Pixel);

        try
        {
            bitmap.Save(thumNailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            graphic.Dispose();
        }

    }

    /// <summary>
    /// 在图片上添加文字水印
    /// </summary>
    /// <param name="path">要添加水印的图片路径</param>
    /// <param name="syPath">生成的水印图片存放的位置</param>
    public static void AddWaterWord(Stream path, string syPath,float x,float y,string syWord)
    {
       
        System.Drawing.Image image = System.Drawing.Image.FromStream(path);

        //新建一个画板
        System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(image);
        graphic.DrawImage(image, 0, 0, image.Width, image.Height);

        //设置字体
        System.Drawing.Font f = new System.Drawing.Font("PingFang SC", 28);

        //设置字体颜色
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        graphic.DrawString(syWord, f, b, x, y);
        graphic.Dispose();

        //保存文字水印图片
        image.Save(syPath);
        image.Dispose();

    }

    /// <summary>
    /// 在图片上添加图片水印
    /// </summary>
    /// <param name="path">原服务器上的图片路径</param>
    /// <param name="syPicPath">水印图片的路径</param>
    /// <param name="waterPicPath">生成的水印图片存放路径</param>
    public static void AddWaterPic(Stream path, Stream syPicPath, string waterPicPath,int x,int y,int width,int height)
    {
        System.Drawing.Image image = System.Drawing.Image.FromStream(path);
        System.Drawing.Image waterImage = System.Drawing.Image.FromStream(syPicPath);
        System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(image);
        graphic.DrawImage(waterImage, new System.Drawing.Rectangle(x, y, width, height), 0, 0, waterImage.Width, waterImage.Height, System.Drawing.GraphicsUnit.Pixel);
        graphic.Dispose();

        image.Save(waterPicPath);
        image.Dispose();
    }
}