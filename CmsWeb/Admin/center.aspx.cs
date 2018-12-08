using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Data;

public partial class Admin_center : System.Web.UI.Page
{
    #region 加载===========================================
    Cms.BLL.C_WebSiteconfig bllsite = new Cms.BLL.C_WebSiteconfig();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //登录验证
          adminUser.GetLoginState();

            //登录信息
          HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];

          if (cookie != null)
          {
            Application["adminname"]=(string)cookie.Values["adminname"];
            Cms.BLL.C_admin_log bll = new Cms.BLL.C_admin_log();
            Cms.Model.C_admin_log model = new Cms.Model.C_admin_log();
            int admin_id =Convert.ToInt32((string)cookie.Values["adminid"]);
            DataSet ds = Cms.DBUtility.DbHelperSQL.ExecuteDataSet(CommandType.Text, "select top 2 * from C_admin_log where user_id=" + admin_id + " order by id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                litIP.Text = ds.Tables[0].Rows[0]["user_ip"].ToString();  //本次登录
                if (ds.Tables[0].Rows.Count == 2)
                {
                    litBackIP.Text = ds.Tables[0].Rows[1]["user_ip"].ToString(); //上一次登录
                    litBackTime.Text = ds.Tables[0].Rows[1]["add_time"].ToString();//上次登录时间
                }
            }
            
          }
          else if (Session["adminname"] != null)
          {
              Application["adminname"] = (string)Session["adminname"];
          }

              bindsite();//绑定网站信息
        }
    }
    #endregion

    #region 绑定网站信息=====================
    public void bindsite()
    {
        DataSet ds = bllsite.GetList("siteid=1");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            Application["webName"] = dr["webName"].ToString();
            Application["weburl"] = dr["weburl"].ToString();
            
            Application["Copyright"] = dr["Copyright"].ToString();
            Application["IcpRecord"] = dr["IcpRecord"].ToString();
            Application["adress"] = dr["adress"].ToString();
            Application["telphone"] = dr["telphone"].ToString();
            Application["fax"] = dr["fax"].ToString();
        }
    }
    #endregion
}