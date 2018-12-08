using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Data;
using System.Text;

public partial class Admin_sms_smsEdit : System.Web.UI.Page
{
    protected string classid;
    public class Person
    {

        public string rescode { get; set; }

        public string message { get; set; }

    }
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
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//文章ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":


                    break;
                case "edit":
                    this.DataBind(id);//赋值操作

                    break;
            }
        }
    }

    //赋值操作
    public void DataBind(int articleId)
    {

        DataSet ds = new Cms.BLL.C_sms().GetList("id=" + articleId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            this.Title.Text = dr["name"].ToString();//标题
            this.englishtitle.Text = dr["telphone"].ToString();//英文标题
            this.seoDescription.Text = dr["content"].ToString();//SEO描述



        }

    }
    #region 添加栏目=================================
    public void DataAdd()
    {
        Cms.BLL.C_sms bll = new Cms.BLL.C_sms();
        Cms.Model.C_sms model = new Cms.Model.C_sms();
        model.name = this.Title.Text.Trim();//名字
        model.telphone = this.englishtitle.Text;//手机号码
        model.content = this.seoDescription.Text.Trim();//内容
        model.state = 0;
        model.updateTime = Convert.ToDateTime(Cms.Common.ManagementInfo.GetTime());//时间
        int result = bll.Add(model);
        if (result > 0)
        {
            string strUTF8 = model.content;//System.Web.HttpUtility.UrlEncode(model.content, Encoding.UTF8);
            string smsresult = adminUser.Sms(model.telphone, strUTF8);
            
            Person p =Cms.Common.Utils.JsonDeserialize<Person>(smsresult);

            if (p.rescode=="0")
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), model.telphone); //记录日志
                int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_sms set state=1 where id=" + result);


                JscriptMsg("发送信息成功！", "smslist.aspx", "Success");
            }
            else
            {
                Response.Write(smsresult);
                JscriptMsg("发送信息失败！", "smsEdit.aspx", "Error");
            }
        }
        else
        {
            JscriptMsg("发送信息失败！", "smsEdit.aspx", "Error");
        }



    }
    #endregion

    #region 修改栏目=================================
    public void DataUpdate(int articleId)
    {
        Cms.BLL.C_sms bll = new Cms.BLL.C_sms();
        Cms.Model.C_sms model = new Cms.Model.C_sms();
        model.id = articleId;//ID
        model.name = this.Title.Text.Trim();//名字
        model.telphone = this.englishtitle.Text;//手机号码
        model.content = this.seoDescription.Text.Trim();//内容
        model.state = 0;
        model.updateTime = Convert.ToDateTime(Cms.Common.ManagementInfo.GetTime());//时间
        if (bll.Update(model))
        {
            string strUTF8 = model.content;//System.Web.HttpUtility.UrlEncode(model.content, Encoding.UTF8);
            string smsresult = adminUser.Sms(model.telphone, strUTF8);
            Person p = Cms.Common.Utils.JsonDeserialize<Person>(smsresult);

            if (p.rescode == "0")
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.telphone); //记录日志
                int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_sms set state=1 where id=" + articleId);
                JscriptMsg("发送信息成功！", "smslist.aspx", "Success");
            }
            else
            {
                //Response.Write(smsresult);
                JscriptMsg("发送信息失败！", "smsEdit.aspx?action=edit&id=" + articleId, "Error");
            }
        }
        else
        {
            JscriptMsg("发送信息失败！", "smsEdit.aspx?action=edit&id=" + articleId, "Error");
        }
    }
    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//栏目ID
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
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
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
}