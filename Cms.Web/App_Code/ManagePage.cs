using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ManagePage 的摘要说明
/// </summary>
public class ManagePage: System.Web.UI.Page
{

    protected internal Cms.Model.C_WebSiteconfig C_WebSiteconfig;

        //public ManagePage()
        //{
        //    this.Load += new EventHandler(ManagePage_Load);
        //    C_WebSiteconfig = new Cms.BLL.C_WebSiteconfig().loadConfig();
        //}

        private void ManagePage_Load(object sender, EventArgs e)
        {
            //判断管理员是否登录
            if (!IsAdminLogin())
            {
                Response.Write("<script>parent.location.href='/admin/login.aspx'</script>");
                Response.End();
            }
        }

        #region 管理员============================================
        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin()
        {
            //如果Session为Null
            if (Session["adminname"] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];
                string adminname = (string)cookie.Values["adminname"];
                string adminpwd = (string)cookie.Values["adminPwd"];
                if (adminname != "" && adminpwd != "")
                {
                    Cms.BLL.C_admin bll = new Cms.BLL.C_admin();
                    Cms.Model.C_admin model = bll.GetModel(adminname, adminpwd);
                    if (model != null)
                    {
                        Session["adminname"] = model;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得管理员信息
        /// </summary>
        public Cms.Model.C_admin GetAdminInfo()
        {
            if (IsAdminLogin())
            {
                Cms.Model.C_admin model = Session["adminname"] as Cms.Model.C_admin;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 检查管理员权限
        /// </summary>
        /// <param name="nav_name">菜单名称</param>
        /// <param name="action_type">操作类型</param>
        public void ChkAdminLevel(string nav_name, string action_type)
        {
            Cms.Model.C_admin model = GetAdminInfo();
            Cms.BLL.C_admin_role bll = new Cms.BLL.C_admin_role();
            bool result = bll.Exists(model.role_id);

            if (!result)
            {
                string msgbox = "parent.jsdialog(\"错误提示\", \"您没有管理该页面的权限，请勿非法进入！\", \"back\", \"Error\")";
                Response.Write("<script type=\"text/javascript\">" + msgbox + "</script>");
                Response.End();
            }
        }



        #endregion

}