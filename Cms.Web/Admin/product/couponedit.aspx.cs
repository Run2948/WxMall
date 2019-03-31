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
    /// 分类绑定
    /// </summary>
    public void listbind()
    {
        Cms.BLL.C_article_category ccc = new Cms.BLL.C_article_category();
        DataTable dt = ccc.GetList("channel_id=7 order by sort_id asc").Tables[0];
        ddpid.DataSource = dt.DefaultView;
        ddpid.DataTextField = "title";
        ddpid.DataValueField = "id";
        ddpid.DataBind();

    }


    /// <summary>
    /// 赋值信息
    /// </summary>
    /// <param name="_id"></param>
    public void bind_date(int _id)
    {
        Cms.BLL.sc_Coupon bll = new Cms.BLL.sc_Coupon();
        Cms.Model.sc_Coupon model = bll.GetModel(_id);
        ddpid.SelectedValue = model.type_id.ToString();
        tbtilte.Text = model.cname;
        tbPrice.Text = model.cmoney.ToString();
        tbnumber.Text = model.number.ToString();
        photoUrl.Text = model.picurl;
        tbstime.Text = Convert.ToDateTime(model.stime).ToString("yyyy-MM-dd HH:mm:ss");
        tbetime.Text = Convert.ToDateTime(model.etime).ToString("yyyy-MM-dd HH:mm:ss");
        cbluserDegree.SelectedValue = model.peson.ToString();
        txtusedContent.InnerText = model.content.ToString();
    }


    #region 增加修改============================
    public void DataAdd()
    {
        Cms.BLL.sc_Coupon bll = new Cms.BLL.sc_Coupon();
        Cms.Model.sc_Coupon bml = new Cms.Model.sc_Coupon();
        string urlhot = Request.Url.Host.ToString();
        bml.type_id = int.Parse(ddpid.SelectedValue.ToString());
        bml.cname = tbtilte.Text.Trim();
        bml.cmoney = Convert.ToInt32(tbPrice.Text.Trim());
        bml.number = Convert.ToInt32(tbnumber.Text.Trim());
        bml.stime = DateTime.Parse(tbstime.Text);
        bml.etime = DateTime.Parse(tbetime.Text);
        bml.picurl = photoUrl.Text.Trim();
        bml.updatetime = DateTime.Now;
        bml.peson = Convert.ToInt32(cbluserDegree.SelectedValue);
        bml.content = txtusedContent.InnerText;
        int result = bll.Add(bml);
        if (result > 0)
        {
            
            if (bml.peson == 0)
            {
                DataTable dt = new Cms.BLL.C_user().GetList("").Tables[0];
                Cms.BLL.C_user_coupon bll_coupon = new Cms.BLL.C_user_coupon();
                Cms.Model.C_user_coupon model_coupon = new Cms.Model.C_user_coupon();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < bml.number; j++)
                        {
                            model_coupon.user_id = Convert.ToInt32(dt.Rows[i]["id"]);
                            model_coupon.article_id = bml.article_id;
                            model_coupon.coupon_id =Convert.ToInt32(result);
                            model_coupon.title = bml.cname;
                            model_coupon.picUrl = bml.picurl;
                            model_coupon.price = Convert.ToDecimal(bml.cmoney);
                            model_coupon.stime = bml.stime;
                            model_coupon.etime = bml.etime;
                            model_coupon.number = 1;
                            model_coupon.content = bml.content;
                            model_coupon.status = 0;
                            model_coupon.type_id = bml.type_id;
                            model_coupon.updatetime = DateTime.Now;
                            bll_coupon.Add(model_coupon);
                        }
                    }
                }
            }
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加优惠卷" + tbtilte.Text); //记录日志
            ShowConfirm("是否继续添加？", "couponedit.aspx?action=add", "couponlist.aspx");
        }


    }
    public void DataUpdate(int id)
    {
        Cms.BLL.sc_Coupon bll = new Cms.BLL.sc_Coupon();
        Cms.Model.sc_Coupon bml = bll.GetModel(id);
        bml.type_id = int.Parse(ddpid.SelectedValue.ToString());
        bml.cname = tbtilte.Text.Trim();
        bml.cmoney = Convert.ToInt32(tbPrice.Text.Trim());
        bml.number = Convert.ToInt32(tbnumber.Text.Trim());
        bml.stime = DateTime.Parse(tbstime.Text);
        bml.etime = DateTime.Parse(tbetime.Text);
        bml.picurl = photoUrl.Text.Trim();
        bml.peson = Convert.ToInt32(cbluserDegree.SelectedValue);
        bml.content = txtusedContent.InnerText;
        //bml.updatetime = DateTime.Now;
        if (bll.Update(bml))
        {

            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "修改优惠卷" + tbtilte.Text); //记录日志
            if (bml.peson == 0)
            {
                DataTable dt = new Cms.BLL.C_user().GetList("").Tables[0];
                Cms.BLL.C_user_coupon bll_coupon = new Cms.BLL.C_user_coupon();
                Cms.Model.C_user_coupon model_coupon = new Cms.Model.C_user_coupon();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < bml.number; j++)
                        {
                            model_coupon.user_id = Convert.ToInt32(dt.Rows[i]["id"]);
                            model_coupon.article_id = bml.article_id;
                            model_coupon.coupon_id = id;
                            model_coupon.title = bml.cname;
                            model_coupon.picUrl = bml.picurl;
                            model_coupon.price = Convert.ToDecimal(bml.cmoney);
                            model_coupon.stime = bml.stime;
                            model_coupon.etime = bml.etime;
                            model_coupon.number = 1;
                            model_coupon.content = bml.content;
                            model_coupon.status = 0;
                            model_coupon.updatetime = DateTime.Now;
                            bll_coupon.Add(model_coupon);
                        }
                    }
                }
            }
            JscriptMsg("提交成功！", "couponlist.aspx", "Success");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");
        switch (action)
        {
            case "add":
                this.DataAdd();
                break;
            case "edit":
                this.DataUpdate(id);
                break;
        }


    }
    #endregion

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