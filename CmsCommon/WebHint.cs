using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Common
{
    public class WebHint : System.Web.UI.Page
    {

        static public void ShowError(string msgtitle, string Url, bool returnUrl, string msgcss)
        {
            PageRender(msgtitle, Url, false, returnUrl, msgcss);
        }

        static internal void PageRender(string msgtitle, string Url, bool Succeed, bool returnUrl, string msgcss)
        {

            string msgbox = "jsdialog(\"提示\", \"" + msgtitle + "\",\"" + Url + "\", \"\", \"" + msgcss + "\")";
            System.Web.HttpContext.Current.Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r<head>\r");
            System.Web.HttpContext.Current.Response.Write("<title></title>\r");
            System.Web.HttpContext.Current.Response.Write("<link href=\"/Admin/skin/default/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r");
            System.Web.HttpContext.Current.Response.Write("<script src=\"/Admin/scripts/jquery/jquery-1.10.2.min.js\" language=\"javascript\" type=\"text/javascript\"></script>\r");
            System.Web.HttpContext.Current.Response.Write("<script src=\"/Admin/scripts/jquery/jquery.lazyload.min.js\" language=\"javascript\" type=\"text/javascript\"></script>\r");
            System.Web.HttpContext.Current.Response.Write("<script src=\"/Admin/scripts/lhgdialog/lhgdialog.js?skin=idialog\" language=\"javascript\" type=\"text/javascript\"></script>\r");
            System.Web.HttpContext.Current.Response.Write("<script src=\"/Admin/js/layout.js\" language=\"javascript\" type=\"text/javascript\"></script>\r");
            System.Web.HttpContext.Current.Response.Write("\r</head>\r");
            System.Web.HttpContext.Current.Response.Write("<body style=\"margin-top:80px;\" class=\"mainbody\">\r");
            System.Web.HttpContext.Current.Response.Write("<form id=\"form1\" name=\"form1\" method=\"post\" action=\"\">\r");
            System.Web.HttpContext.Current.Response.Write("<iframe id=\"mainframe\" name=\"mainframe\" frameborder=\"0\" src=\"\">\r");
            System.Web.HttpContext.Current.Response.Write("</iframe>\r");
            System.Web.HttpContext.Current.Response.Write("<script>parent.location.href='" + Url + "'</script>");
            //System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">" + msgbox + "</script>\r");
            System.Web.HttpContext.Current.Response.Write("</form>\r</body>\r");
            System.Web.HttpContext.Current.Response.Write("</html>\r");
            System.Web.HttpContext.Current.Response.End();

        }

    }
}
