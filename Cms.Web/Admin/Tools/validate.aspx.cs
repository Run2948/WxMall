using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

public partial class Tools_validate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            string str_ValidateCode = this.GetRandomstr(4);
            this.Session["MsgCheckCode"] = str_ValidateCode;
            this.CreateImage(str_ValidateCode);
        }
    }
    public void CreateImage(string str_ValidateCode)
    {
        int bmpWidth = str_ValidateCode.Length * 9;
        int bmpHight = 0x12;
        Random newRandom = new Random();
        Bitmap theBitmap = new Bitmap(bmpWidth, bmpHight);
        Graphics theGraphics = Graphics.FromImage(theBitmap);
        theGraphics.Clear(Color.White);
        Font theFont = new Font("Verdana", 9f);
        for (int int_index = 0; int_index < str_ValidateCode.Length; int_index++)
        {
            string str_char = str_ValidateCode.Substring(int_index, 1);
            Brush newBrush = new SolidBrush(this.GetRandomColor());
            Point thePos = new Point(int_index * 8, 2);
            theGraphics.DrawString(str_char, theFont, newBrush, (PointF)thePos);
        }
        MemoryStream ms = new MemoryStream();
        theBitmap.Save(ms, ImageFormat.Png);
        base.Response.ClearContent();
        base.Response.ContentType = "image/Png";
        base.Response.BinaryWrite(ms.ToArray());
        theGraphics.Dispose();
        theBitmap.Dispose();
        base.Response.End();
    }

    public Color GetRandomColor()
    {
        Random RandomNum_First = new Random();
        Thread.Sleep(RandomNum_First.Next(50));
        Random RandomNum_Sencond = new Random();
        int int_Red = RandomNum_First.Next(000);
        int int_Green = RandomNum_Sencond.Next(000);
        int int_Blue = ((int_Red + int_Green) > 400) ? 0 : ((400 - int_Red) - int_Green);
        int_Blue = (int_Blue > 0xff) ? 0xff : int_Blue;
        return Color.FromArgb(int_Red, int_Green, int_Blue);
    }

    public string GetRandomstr(int Num_Length)
    {
        string Randomstr = string.Empty;
        Random rand = new Random();
        for (int i = 0; i < Num_Length; i++)
        {
            Randomstr = Randomstr + rand.Next(10).ToString();
        }
        return Randomstr;
    }
}