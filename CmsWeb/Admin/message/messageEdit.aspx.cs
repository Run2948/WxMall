using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Common;

public partial class Admin_message_messageEdit : System.Web.UI.Page
{
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
                Application["adminname"] = (string)cookie.Values["adminname"];
            }
            else if (Session["adminname"] != null)
            {
                Application["adminname"] = (string)Session["adminname"];
            }

            int messageid = Convert.ToInt32(this.Request.QueryString["messageid"] ?? "0");//留言ID
           
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":
                  

                    break;
                case "edit":
                    this.DataBind(messageid);//绑定文章信息
                   
                    break;
            }
        }
    }

    #region 读取数据=======================================
    public void DataBind(int messageid)
    {
        Cms.BLL.C_message bllmessage = new Cms.BLL.C_message();
        DataSet ds = bllmessage.GetList("messageid=" + messageid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            this.Name.Text = dr["Name"].ToString();//联系人
            this.UnitName.Text = dr["UnitName"].ToString();//单位名称
            this.PhoneNum.Text = dr["PhoneNum"].ToString();
            this.telNum.Text = dr["telNum"].ToString();
            this.email.Text = dr["email"].ToString();
            this.title.Text = dr["title"].ToString();

            this.strcontent.Text = dr["content"].ToString();
            this.userName.Text = dr["userName"].ToString() == "" ? "匿名用户" : dr["userName"].ToString();
            this.updateTime.Text = dr["updateTime"].ToString();
            this.replay.Text = dr["replay"].ToString();
            this.re_updateTime.Text = dr["re_updateTime"].ToString();  

        }

    }
    #endregion

    #region 保存===================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int messageid = Convert.ToInt32(this.Request.QueryString["messageid"] ?? "0");//留言ID

        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        string replay = this.replay.Text;
        string re_updateTime = DateTime.Now.ToShortDateString();
      int result= Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_message set replay='" + replay + "',re_updateTime='" + re_updateTime + "' where messageid='" + messageid + "'");
      if (result > 0)
      {
          adminUser.AddAdminLog(DTEnums.ActionEnum.Reply.ToString(), replay); //记录日志

          JscriptMsg("提交信息成功！", "messagelist.aspx" , "Success");
      }
      else
      {
          JscriptMsg("提交信息失败！", "messageEdit.aspx", "Error");
      }
    }
    #endregion

    #region 提示框=======================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}