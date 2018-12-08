using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_order_orderedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//订单ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":


                    break;
                case "Edit":
                    this.bind_date(id);// 赋值操作信息
                    break;
            }

        }
    }
    public void bind_date(int _id)
    {
        Cms.BLL.wx_msg bll = new Cms.BLL.wx_msg();
        DataTable dt = bll.GetList("id="+_id).Tables[0];
        if (dt.Rows.Count > 0)
        {
            tborderNumber.Text = dt.Rows[0]["orderNumber"].ToString();
            tbinfo.Value = dt.Rows[0]["info"].ToString();
          
        }
    }
 

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Cms.BLL.wx_msg bll = new Cms.BLL.wx_msg();
        Cms.Model.wx_msg bml = new Cms.Model.wx_msg();
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");
        bool bl = false;
        if (action == "add")
        {
            bml.orderNumber =tborderNumber.Text.Trim();
            bml.info = tbinfo.Value;
            bml.updatetime = DateTime.Now;
            bl = bll.Add(bml) > 0 ? true : false ;
        }
        else {
            bml = new Cms.BLL.wx_msg().GetModel(id);
            bml.orderNumber = tborderNumber.Text.Trim();
            bml.info = tbinfo.Value;
            bl = bll.Update(bml);
        }
        if (bl)
        {
            //ShowConfirm("是否继续添加？", "msgedit.aspx?action=add", "msglist.aspx");
            JscriptMsg("提交成功！", "msglist.aspx", "Success");
        }
        else
        {
            JscriptMsg("提交失败！", "msgedit.aspx?action=Edit?id="+id, "Error");
        }
    }

    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }

    public static void ShowConfirm(string strMsg, string strUrl_Yes, string strUrl_No)
    {
        System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) {  window.location.href='" + strUrl_Yes +
                          "' } else {window.location.href='" + strUrl_No + "' };</script>");
    }    
}