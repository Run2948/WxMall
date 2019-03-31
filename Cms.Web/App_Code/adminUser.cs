using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cms.Common;
using System.Data;

/// <summary>
///adminUser 的摘要说明
/// </summary>
public class adminUser : System.Web.UI.Page
{
	public adminUser()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    #region 判断管理员登录状态
    /// <summary>
    /// 判断登录状态
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public static Cms.Model.C_admin GetLoginState()
    {
        HttpCookie cookie = (HttpCookie)HttpContext.Current.Request.Cookies["admin"];
        string id = "";
        if (cookie != null)
        {
            id = Convert.ToString(cookie.Values["id"]);
        }
        else if (HttpContext.Current.Session["id"] != null)
        {
            id = Convert.ToString(HttpContext.Current.Session["id"]);
           
        }
        Cms.Model.C_admin model = adminUser.GetLoginState(id);
        return model;
    }
    public static Cms.Model.C_admin GetLoginState(string id)
    {
        Cms.Model.C_admin model = null;
        if (id == null || id.Length <= 0)
        {
            WebHint.ShowError("登录超时，请重新登录", "/admin/login.aspx", true, "Error");
        }
        else
        {
            model = new Cms.BLL.C_admin().GetModel(Convert.ToInt32(id));
        }
        return model;
       
    }

    
    #endregion

    

    #region 判断前台用户登录状态
    /// <summary>
    /// 判断登录状态
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public static Cms.Model.C_user GetuserLoginState()
    {
        HttpCookie cookie = (HttpCookie)HttpContext.Current.Request.Cookies["user"];
        string user_id = "";
        if (cookie != null)
        {
            user_id = Convert.ToString(cookie.Values["user_id"]);
        }
        Cms.Model.C_user model = adminUser.GetuserLoginState(user_id);
        return model;
    }
    public static Cms.Model.C_user GetuserLoginState(string user_id)
    {
        Cms.Model.C_user model = null;
        if (user_id == null || user_id.Length <= 0)
        {
            WebHint.ShowError("登录超时，请重新登录", "/m/mine.aspx", true, "Error");
        }
        else
        {
            if (new Cms.BLL.C_user().Exists(Convert.ToInt32(user_id)))
            {
                model = new Cms.BLL.C_user().GetModel(Convert.ToInt32(user_id));
            }
            else
            {
                WebHint.ShowError("登录超时，请重新登录", "/m/mine.aspx", true, "Error");
            }
        }
        return model;
    }
    #endregion

    #region 安全退出============
    public static void LoginOut()
    {
       
       //HttpContext.Current.Session["user_id"] = null;
       //HttpContext.Current.Session.Remove("user_id");
       //HttpContext.Current.Session.Clear();
       HttpCookie cookie = (HttpCookie)HttpContext.Current.Request.Cookies["user"];
       if (cookie == null)
       {
           cookie = new HttpCookie("user");
       }
       cookie.Value = "";
       cookie.Expires = DateTime.Now.AddMinutes(-14400);
       HttpContext.Current.Response.AppendCookie(cookie);
       Utils.WriteCookie("user", "DBE", -14400);
       Utils.WriteCookie("user", "DBE", -14400);
       WebHint.ShowError("登录超时，请重新登录", "/shop/login.aspx", true, "Error");
    }
    #endregion

    #region 判断手机用户登录状态
    /// <summary>
    /// 判断手机登录状态
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public static string WapLoginState()
    {
        HttpCookie cookie = (HttpCookie)HttpContext.Current.Request.Cookies["user"];
        string userName = "";
        if (cookie != null)
        {
            userName = Convert.ToString(cookie.Values["userName"]);
        }
        else if (HttpContext.Current.Session["userName"] != null)
        {
            userName = Convert.ToString(HttpContext.Current.Session["userName"]);
        }
        string result = adminUser.WapLoginState(userName);
        return result;
    }
    public static string WapLoginState(string userName)
    {
        string result = "0";
        if (userName == null || userName.Length <= 0)
        {
            WebHint.ShowError("登录超时，请重新登录", "/Wap/wapuser/login.aspx", true, "Error");
            result = "1";
        }
        return result;
    }
    #endregion

    #region 写入后台管理日志===================================
    /// <summary>
    /// 写入管理日志
    /// </summary>
    public static bool AddAdminLog(string action_type, string remark)
    {

        Cms.Model.C_admin admin = adminUser.GetLoginState();
        int newId = new Cms.BLL.C_admin_log().Add(admin.id, admin.user_name, action_type, remark);
        if (newId > 0)
        {
            return true;
        }

        return false;
    }
    #endregion

    #region 写入后台管理日志===================================
    /// <summary>
    /// 写入管理日志
    /// </summary>
    public static bool AddUserLog(string action_type, string remark)
    {

        Cms.Model.C_user user = adminUser.GetuserLoginState();
        int newId = new Cms.BLL.C_admin_log().Add(user.id, user.username, action_type, remark);
        if (newId > 0)
        {
            return true;
        }

        return false;
    }
    #endregion

    #region JS提示============================================
    /// <summary>
    /// 添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    /// <summary>
    /// 带回传函数的添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    /// <param name="callback">JS回调函数</param>
    public void JscriptMsg(string msgtitle, string url, string msgcss, string callback)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\", " + callback + ")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 发送短信=============================================
    public static string Sms(string phone, string content)
    {
        string url = string.Format("http://sms.zhiqiyun.com/interface.api?sn=ZQY-HN-TEST&key=test123456&mobile={0}&content={1}", phone, content);
        try
        {
            System.Net.WebClient client = new System.Net.WebClient();
            string reply = Cms.Common.Utils.HttpGet(url);
            return reply;
        }
        catch (Exception ex) { throw ex; }
    }
    #endregion

    #region 权限=============================================
    public static bool setpurview(string classname, string type)
    {
        bool bl = false;
        if (adminUser.GetLoginState()!=null)
        {
            Cms.BLL.C_admin_role_value cvalue = new Cms.BLL.C_admin_role_value();
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];
            string username = admin.user_name;
            if (username == "admin")
            {
                bl = true;
            }
            else
            {
                string role_id = admin.role_id.ToString(); ;
                DataTable dt = cvalue.GetList("nav_name='" + classname + "' and role_id=" + role_id + "").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string actiontype = dt.Rows[0]["action_type"].ToString();
                    if (actiontype.IndexOf(type) > -1)
                    {
                        bl = true;
                    }
                }
            }
        }

        return bl;
    }
    #endregion
}