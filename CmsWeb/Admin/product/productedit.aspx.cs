using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using Cms.DBUtility;
using System.IO;
using System.Net;
using System.Text;
using Cms.Common;
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
            listbind();
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//订单ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    this.bind_date(id);// 赋值操作信息
                    break;
            }

        }
    }

    /// <summary>
    /// 绑定类别
    /// </summary>
    public void listbind()
    {
        Cms.BLL.C_article_category ccc = new Cms.BLL.C_article_category();
        DataTable dt = ccc.GetList("channel_id=1 order by sort_id asc").Tables[0];
        ddpid.DataSource = dt.DefaultView;
        ddpid.DataTextField = "title";
        ddpid.DataValueField = "id";
        ddpid.DataBind();
        dt = ccc.GetList("channel_id=5 order by sort_id asc").Tables[0];
        ddcz.DataSource = dt.DefaultView;
        ddcz.DataTextField = "title";
        ddcz.DataValueField = "id";
        ddcz.DataBind();
    }


    /// <summary>
    /// 绑定内容
    /// </summary>
    /// <param name="_id"></param>
    public void bind_date(int _id)
    {
        Cms.BLL.sc_Product bll = new Cms.BLL.sc_Product();
        DataTable dt = bll.GetList("id="+_id).Tables[0];
        if (dt.Rows.Count > 0)
        {
            ddpid.SelectedValue = dt.Rows[0]["pid"].ToString();
            ddcz.SelectedValue = dt.Rows[0]["Material"].ToString();
            tbtilte.Text = dt.Rows[0]["pname"].ToString();
            tbPrice.Text = Convert.ToDecimal(dt.Rows[0]["Price"]).ToString("0.00");
            tbmarketpice.Text = Convert.ToDecimal(dt.Rows[0]["marketpice"]).ToString("0.00");
            photoUrl.Text = dt.Rows[0]["picurl"].ToString();
            tbstock.Text = dt.Rows[0]["stock"].ToString();
            tbintegral.Text = dt.Rows[0]["integral"].ToString();
            tbinfo.Value = dt.Rows[0]["content"].ToString();
            tbProperty.Text = dt.Rows[0]["Property"].ToString();
            isjf.SelectedValue = dt.Rows[0]["isjf"].ToString();
        }
      
    }
 

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Cms.BLL.sc_Product bll = new Cms.BLL.sc_Product();
        Cms.Model.sc_Product bml = new Cms.Model.sc_Product();
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");
        bool bl = false;
        bool bls = true;
        
        string urlhot = Request.Url.Host.ToString();
        if (action == "add")
        {
            bml.pid = int.Parse(ddpid.SelectedValue.ToString());
            bml.Material = ddcz.SelectedValue.ToString();
            bml.pname = tbtilte.Text.Trim();
            bml.Price = Convert.ToDecimal(tbPrice.Text.Trim());
            bml.marketpice = Convert.ToDecimal(tbmarketpice.Text.Trim());
            bml.Property = tbProperty.Text;
            bml.isjf = int.Parse(isjf.SelectedValue.ToString());
            bml.picurl = photoUrl.Text.Trim();
            bml.stock = int.Parse(tbstock.Text.Trim());
            bml.integral =int.Parse(tbintegral.Text.Trim());
            bml.content = tbinfo.Value;
            bml.updatetime = DateTime.Now;
         
            bl = bll.Add(bml) > 0 ? true : false ;
        }
        else {
            bml = bll.GetModel(id);
            bml.pid = int.Parse(ddpid.SelectedValue.ToString());
            bml.Material = ddcz.SelectedValue.ToString();
            bml.pname = tbtilte.Text.Trim();
            bml.Price = Convert.ToDecimal(tbPrice.Text.Trim());
            bml.marketpice = Convert.ToDecimal(tbmarketpice.Text.Trim());
            bml.Property = tbProperty.Text;
            bml.isjf = int.Parse(isjf.SelectedValue.ToString());
            bml.picurl = photoUrl.Text.Trim();
            bml.stock = int.Parse(tbstock.Text.Trim());
            bml.integral = int.Parse(tbintegral.Text.Trim());
            bml.content = tbinfo.Value;
            bml.updatetime = DateTime.Now;
            bl = bll.Update(bml);
        }
        if (bl && bls)
        {
            if (action == "add")
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加产品"+tbtilte.Text); //记录日志
                ShowConfirm("是否继续添加？", "productedit.aspx?action=add", "productlist.aspx");
            }
            else
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "修改产品" + tbtilte.Text); //记录日志
                JscriptMsg("提交成功！", "productlist.aspx", "Success");
            }
        }
        else
        {
            JscriptMsg("提交失败！", "productedit.aspx?action=edit?id=" + id, "Error");
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