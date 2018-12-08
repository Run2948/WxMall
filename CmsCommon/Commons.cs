using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace Cms.Common
{
    public class Commons
    {
        #region  获取网站目录的物理路径

        /// <summary>
        /// 获取网站根目录的物理路径
        /// </summary>
        /// <returns>物理路径</returns>
        public static string GetMapPath()
        {
            string AppPath = "";

            HttpContext HttpCurrent = HttpContext.Current;

            if (HttpCurrent != null)
            {
                AppPath = HttpCurrent.Server.MapPath("~");
            }
            else //非web程序引用
            {
                AppPath = AppDomain.CurrentDomain.BaseDirectory;

                if (Regex.Match(AppPath, @"\\$", RegexOptions.Compiled).Success)
                {
                    AppPath = AppPath.Substring(0, AppPath.Length - 1);
                }
            }
            return AppPath;
        }

        /// <summary>
        /// 获取指定目录(或Url)的物理路径
        /// </summary>
        /// <param name="path">指定的路径</param>
        /// <returns>物理路径</returns>
        public static string GetMapPath(string path)
        {
            if (path.IndexOf("://") > -1)
            {
                return path;
            }

            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(path);
            }
            else //非web程序引用
            {
                path = path.Replace("/", "\\");
                if (path.StartsWith("\\"))
                {
                    path = path.Substring(path.IndexOf('\\', 1)).TrimStart('\\');
                }
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }
        }

        #endregion

        #region 获取网站根目录的URL

        /// <summary>
        /// 获取网站的根目录的URL
        /// </summary>
        /// <returns></returns>
        public static string GetRootURI()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;

            if (HttpCurrent != null)
            {
                Req = HttpCurrent.Request;

                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);

                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                {
                    //直接安装在   Web   站点   
                    AppPath = UrlAuthority;
                }
                else
                {
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + Req.ApplicationPath;
                }
            }
            return AppPath;
        }

        /// <summary>
        /// 获取网站的根目录的URL
        /// </summary>
        /// <param name="Req"></param>
        /// <returns></returns>
        public static string GetRootURI(HttpRequest Req)
        {
            string AppPath = "";
            if (Req != null)
            {
                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                {
                    //直接安装在   Web   站点   
                    AppPath = UrlAuthority;
                }
                else
                {
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + Req.ApplicationPath;
                }
            }
            return AppPath;
        }

        #endregion

        #region 读取xml格式文本指定节点的文本
        /// <summary>
        /// 读取xml格式文本指定节点的文本
        /// </summary>
        /// <param name="node">节点XPath</param>
        /// <param name="xmlText">xml文本</param>
        /// <returns></returns>
        public static string ReadXmlTextNode(string node, string xmlText)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlText);
                XmlNode xn = doc.SelectSingleNode(node);
                value = xn.InnerText;
            }
            catch { }
            return value;
        }
        #endregion

        #region 验证是否是手机号码
        /// <summary>
        /// 验证是否是手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMobile(string str)
        {
            return !string.IsNullOrEmpty(str) && new Regex("^(13|15|17|18)\\d{9}$").IsMatch(str);
        }

        /// <summary>
        /// 验证是否是移动的手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChinaMobile(string str)
        {
            return !string.IsNullOrEmpty(str) && new Regex("^(13[4-9]|15[0-2|7-9]|18[7|8])\\d{8}$").IsMatch(str);
        }


        /// <summary>
        /// 验证是否是联通的手机号码
        /// </summary>
        public static bool IsUnicomMobile(string str)
        {
            return !string.IsNullOrEmpty(str) && new Regex("^(13[0-2]|15[3|5|6]|186)\\d{8}$").IsMatch(str);
        }

        /// <summary>
        /// 判断是否CMWAP用户
        /// </summary>
        /// <returns>是否CMWAP用户</returns>
        public static bool IsCMWAP()
        {
            string sCMWAP = HttpContext.Current.Request.ServerVariables["HTTP_X_UP_BEAR_TYPE"];
            if (!string.IsNullOrEmpty(sCMWAP) && sCMWAP.ToUpper() == "GPRS/EDGE")
                return true;
            else
                return false;
        }
        #endregion
    }
}
