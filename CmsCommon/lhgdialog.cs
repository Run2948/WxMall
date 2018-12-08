using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
//+---------------------------------------------
//+Author：JiangLiang <donet520@163.com>
//+---------------------------------------------
//+Crporation：http://www.tryine.com
//+DateTime：2013-6-27 14:31:38
//+---------------------------------------------
namespace Cms.Common
{
    public class lhgdialog : System.Web.UI.Page
    {
        /// <summary>
        /// 弹出消息框(没有最大化和最小化)
        /// </summary>
        /// <param name="page">一般为this.page</param>
        /// <param name="title">弹出框标题</param>
        /// <param name="context">弹出框内容</param>
        /// <param name="icon">图标 正确:success.gif; 错误:error.gif; 提示确认:confirm.gif; sad:face-sad.png  happy：face-smile.png</param>
        public static void ShowInfo(Page page, string title, string context, string icon)
        {

            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            msg.Append(" $(function () {$.dialog({lock: true,ok:true,title: '" + title + "',content: '" + context + "',icon:'" + icon + "',max:false,min:false,fixed: true,});});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());
        }
        /// <summary>
        /// 创建一个右下角浮动的消息窗口
        /// </summary>
        /// <param name="page">一般为this.page</param>
        /// <param name="title">标题</param>
        /// <param name="context">内容</param>
        /// <param name="width">弹出框的宽度</param>
        /// <param name="height">弹出框的高度</param>
        public static void ShowSmallInfo(Page page, string title, string context, string width, string height)
        {

            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            msg.Append(" $(function () {$.dialog({id: 'msg',title: '" + title + "',content: '" + context + "',width:" + width + ",height:" + height + ",left: '100%',top: '100%',fixed: true,drag: false,resize: false});});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());
        }
        /// <summary>
        /// 弹出一个指定大小的层
        /// </summary>
        /// <param name="page">一般为this.page</param>
        /// <param name="title">标题</param>
        /// <param name="context">内容（可以为url：www.baidu.com）</param>
        /// <param name="width">弹出框的宽度</param>
        /// <param name="height">弹出框的高度</param>
        public static void ShowNewBox(Page page, string title, string context, string width, string height)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            msg.Append(" $(function () {$.dialog({lock: true,title: '" + title + "',content: '" + context + "',width:" + width + ",height:" + height + ",fixed: true,max:false,min:false});});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());
        }
        /// <summary>
        /// 弹出警告消息框
        /// </summary>
        /// <param name="page">一般为this.page</param>
        /// <param name="context">内容（可以为url：www.baidu.com）</param>
        public static void Alter(Page page, string context)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            msg.Append(" $(function (){$.dialog.alert('" + context + "');});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());
        }
        /// <summary>
        /// 加载提示
        /// </summary>
        /// <param name="page">一般为this.page</param>
        /// <param name="context">加载时提示内容</param>
        /// <param name="time">等待时间</param>
        /// <param name="endcontext">加载完提示内容</param>
        public static void Tips(Page page, string context, int time, string endcontext)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            msg.Append(" $(function (){ $.dialog.tips('" + context + "'," + time + ",'loading.gif');});");
            msg.Append("setTimeout(function(){");
            msg.Append("$.dialog.tips('" + endcontext + "',3,'tips.gif');");
            msg.Append("}, 5000 );");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());
        }
        /// <summary>
        /// 提示信息 ok
        /// </summary>
        /// <param name="page">一般为this.page</param>
        /// <param name="context">内容</param>
        public static void ShowOkTips(Page page, string context)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            msg.Append(" $(function (){$.dialog.tips('" + context + "',2,'success.gif');});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());
        }
        /// <summary>
        /// 提示信息 error
        /// </summary>
        /// <param name="page">一般为this.page</param>
        /// <param name="context">内容</param>
        public static void ShowErrorTips(Page page, string context)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            msg.Append(" $(function (){$.dialog.tips('" + context + "',2,'error.gif');});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());
        }
        /// <summary>
        /// 提示信息 info
        /// </summary>
        /// <param name="page">一般为this.page</param>
        /// <param name="context">内容</param>
        public static void ShowInfoTips(Page page, string context)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            msg.Append(" $(function (){$.dialog.tips('" + context + "',2);});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());
        }
        /// <summary>
        /// 弹出确认对话框
        /// </summary>
        /// <param name="page">this.page</param>
        /// <param name="context">提示内容</param>
        /// <param name="yurl">点击是跳转到页面</param>
        /// <param name="nurl">点击否跳转到的页面</param>
        public static void ShowconfirmTips(Page page, string context, string yurl, string nurl)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            // msg.Append("$(function () {");
            msg.Append(" $.dialog.confirm('" + context + "？', function(){");
            msg.Append("window.location.href ='" + yurl + "';");
            msg.Append(" }, function(){");
            msg.Append("window.location.href ='" + nurl + "';");
            msg.Append("  });");
            //msg.Append("});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());

        }
        /// <summary>
        /// 弹出确认对话框
        /// </summary>
        /// <param name="page">this.page</param>
        /// <param name="context">提示内容</param>
        /// <param name="yurl">点击是跳转到页面</param>
        /// <param name="nurl">点击否跳转到的页面</param>
        public static void ShowJumpTips(Page page, string context, string yurl, string nurl)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<script type=\"text/javascript\">");
            // msg.Append("$(function () {");
            msg.Append(" $.dialog.confirm('" + context + "？', function(){");
            msg.Append("window.location.href ='" + yurl + "';");
            msg.Append(" }, function(){");
            msg.Append("window.location.href ='" + nurl + "';");
            msg.Append("  });");
            //msg.Append("});");
            msg.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", msg.ToString());

        }
    }
}
