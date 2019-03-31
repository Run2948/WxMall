using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

public partial class Admin_editor_plugins_filemanager_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Request.QueryString["url"];
        string fn = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
        string path = Server.MapPath("~" + url);
        //Response.Write(path);
        //if (SavePhotoFromUrl(path, url))
        {
            Response.ContentType = "image/jpeg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + fn + "\""); Response.TransmitFile(path);
        }
        //else Response.Write("文件件下载失败！");
        Response.End();//停止输出aspx页面中的html 
    }

    /// <summary>
        /// 从Url保存图片到本地
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public bool SavePhotoFromUrl(string FileName, string Url)
        {
            bool value = false;
            WebResponse response = null;
            Stream stream = null;

            try
            {
                WebRequest request = WebRequest.Create(Url);
                response = request.GetResponse();
                stream = response.GetResponseStream();

                
                value = SaveBinaryFile(response, FileName);
               

            }
            catch (Exception err)
            {
                string aa = err.ToString();
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private bool SaveBinaryFile(WebResponse response, string FileName)
        {
            bool Value = true;
            byte[] buffer = new byte[1024];

            try
            {
                if (!File.Exists(FileName))
                {

                    Stream outStream = System.IO.File.Create(FileName);
                    Stream inStream = response.GetResponseStream();

                    int l;
                    do
                    {
                        l = inStream.Read(buffer, 0, buffer.Length);
                        if (l > 0)
                            outStream.Write(buffer, 0, l);
                    }
                    while (l > 0);

                    outStream.Close();
                    inStream.Close();
                }
            }
            catch
            {
                Value = false;
            }

            return Value;
        }

    
 
}