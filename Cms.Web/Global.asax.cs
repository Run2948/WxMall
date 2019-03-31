using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Cms.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //在应用程序启动时运行的代码

            //HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];
            //if (cookie != null)
            //{
            //    Application["adminname"] = (string)cookie.Values["adminname"];
            //}
            //else if (System.Web.HttpContext.Current.Session["adminname"] != null)
            //{
            //    Application["adminname"] = (string)Session["adminname"];
            //}
            //else
            //{
            //    Response.Redirect("/admin/login.aspx");
            //}
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //在新会话启动时运行的代码
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //在出现未处理的错误时运行的代码
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式 
            //设置为 StateServer 或 SQLServer，则不会引发该事件。
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //在应用程序关闭时运行的代码
            //wxuser.setstatistics("", "微信消息", "999", 1, 1);
        }
    }
}