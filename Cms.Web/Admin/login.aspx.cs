using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Common;

public partial class Admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 登录==================================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string userName = txtUserName.Text.Trim();//用户名
        string userPwd = txtPassword.Text.Trim();//密码

        if (userName.Equals("") || userPwd.Equals(""))
        {
            msgtip.InnerHtml = "请输入用户名或密码";
            return;
        }
        string sCode = "";
        if (Session["MsgCheckCode"] != null)
        {
            sCode = Session["MsgCheckCode"].ToString();
        }
        else
        {
            msgtip.InnerHtml = "请重新输入验证码!";
            return;

        }
        string rCode = this.SecureCode.Text.ToString().Trim();

        if (rCode != sCode)
        {
            msgtip.InnerHtml = "验证码不正确!";
            return;
        }
        Cms.BLL.C_admin bll = new Cms.BLL.C_admin();

        if (bll.ExistsUser(userName, userPwd))
        {
            DataSet ds = bll.GetList("user_name='" + userName + "' and password='" + userPwd + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //写入session
                Session["adminname"] = userName;//保存session 用户名
                Session["id"] = ds.Tables[0].Rows[0]["id"].ToString();//保存session 用户名ID
                Session["adminid"] = ds.Tables[0].Rows[0]["role_id"].ToString();//保存session 用户名角色ID
                Session["adminType"] = ds.Tables[0].Rows[0]["role_type"].ToString();//保存session 用户类型
                Session["adminPwd"] = userPwd;//保存session 用户密码

                //写入Cookie
                HttpCookie cookie = new HttpCookie("admin");//创建Cookie
                cookie["adminname"] = userName;//保存Cookie 用户名
                cookie["id"] = ds.Tables[0].Rows[0]["id"].ToString();//保存Cookie 用户名ID
                cookie["adminid"] = ds.Tables[0].Rows[0]["role_id"].ToString();//保存Cookie 用户名角色ID
                cookie["adminType"] = ds.Tables[0].Rows[0]["role_type"].ToString();//保存Cookie 用户类型
                cookie["adminPwd"] = userPwd;//保存Cookie 用户密码

                cookie.Expires = DateTime.Now.AddHours(14400);
                Response.Cookies.Add(cookie);

                adminUser.AddAdminLog(DTEnums.ActionEnum.Login.ToString(), userName); //记录日志
                this.Response.Redirect("index.aspx", true);
            }
            else
            {
                msgtip.InnerHtml = "用户名或密码有误，请重试！";
                return;
            }
        }
        else
        {
            msgtip.InnerHtml = "请输入正确的用户名和密码!";
            return;

        }
    }
    #endregion
}