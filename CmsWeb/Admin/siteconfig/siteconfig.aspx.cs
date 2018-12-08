using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Common;
public partial class Admin_siteconfig_siteconfig : System.Web.UI.Page
{
    Cms.BLL.C_WebSiteconfig bllsite = new Cms.BLL.C_WebSiteconfig();
    Cms.Model.C_WebSiteconfig modelsite = new Cms.Model.C_WebSiteconfig();
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
            this.DataBind();//绑定信息

        }

    }
    #region 读取数据=========================================
    public void DataBind()
    {
        Cms.Model.C_WebSiteconfig site = new Cms.BLL.C_WebSiteconfig().GetModel(1);
        webName.Text = site.webName.ToString();
        weburl.Text = site.weburl.ToString();
        title.Text = site.title.ToString();

        keyword.Text = site.keyword.ToString();
        Description.Text = site.Description.ToString();
        upload.Text = site.upload.ToString();
        Copyright.Text = site.Copyright.ToString();
        txttel.Text = site.tel;
        txtqq.Text = site.qq;
        txtlogo.Value = site.logo;
        txtmLogo.Value = site.mLogo;

        IcpRecord.Text = site.IcpRecord.ToString();
        adress.Text = site.adress.ToString();
        telphone.Text = site.telphone.ToString();
        mobiephone.Text = site.mobiephone.ToString();

        fax.Text = site.fax.ToString();
        email.Text = site.email.ToString();
        contactperson.Text = site.contactperson.ToString();
        TextBox1.Text = site.textParam1.ToString();
    }
    #endregion

    #region 保存===================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        modelsite.siteid = 1;
        modelsite.webName = webName.Text;
        modelsite.weburl = weburl.Text;
        modelsite.title = title.Text;

        modelsite.keyword = keyword.Text;
        modelsite.Description = Description.Text;
        modelsite.upload = upload.Text;
        modelsite.Copyright = Copyright.Text;

        modelsite.IcpRecord = IcpRecord.Text;
        modelsite.adress = adress.Text;
        modelsite.telphone = telphone.Text;
        modelsite.mobiephone = mobiephone.Text;

        modelsite.tel = txttel.Text;
        modelsite.qq = txtqq.Text;
        modelsite.logo = txtlogo.Value;
        modelsite.mLogo = txtmLogo.Value;

        modelsite.fax = fax.Text;
        modelsite.email = email.Text;
        modelsite.contactperson = contactperson.Text;
        modelsite.textParam1 = TextBox1.Text;
        if (bllsite.Update(modelsite))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), modelsite.title); //记录日志
            JscriptMsg("提交信息成功！", "siteconfig.aspx", "Success");
        }
        else
        {
            JscriptMsg("提交信息失败！", "siteconfig.aspx", "Error");
        }
    }
    #endregion

    #region 提示框==================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}