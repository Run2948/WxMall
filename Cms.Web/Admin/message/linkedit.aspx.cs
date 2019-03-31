using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Data;
public partial class Admin_message_linkedit : System.Web.UI.Page
{
    Cms.BLL.C_link blllink = new Cms.BLL.C_link();
    Cms.Model.C_link Modellink = new Cms.Model.C_link();
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

            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//信息ID
            string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
          
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    this.DataBind(id);//绑定文章信息
                    break;
            }
        }
    }


    #region 读取数据===============================================
    public void DataBind(int id)
    {
       
        DataSet ds = blllink.GetList("id=" + id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            this.name.Text = dr["name"].ToString();//名称
            this.linkUrl.Text = dr["linkUrl"].ToString();//
            this.photoUrl.Value = dr["picUrl"].ToString();
            this.picurl.Src = dr["picUrl"].ToString();
            this.isHidden.SelectedValue = dr["ishidden"].ToString();
            this.ordernum.Text = dr["ordernum"].ToString();

            this.note.Text = dr["note"].ToString();

            this.e_name.Text = dr["e_name"].ToString();
            this.e_content.Text = dr["e_content"].ToString();
           

        }

    }
    #endregion

    #region 添加===========================================
    public void DataAdd()
    {
     Modellink.name=this.name.Text;//名称
     Modellink.linkUrl = this.linkUrl.Text ;//
     Modellink.picUrl = this.photoUrl.Value;

     Modellink.ishidden =Convert.ToInt32(this.isHidden.SelectedValue);
     Modellink.ordernum = Convert.ToInt32(this.ordernum.Text) ;

     Modellink.note = this.note.Text ;
     Modellink.linktype = "";
     Modellink.hits = 1;
     Modellink.updateTime = DateTime.Now;

     Modellink.e_name = this.e_name.Text;
     Modellink.e_content = this.e_content.Text;
     int result = blllink.Add(Modellink);
     if (result > 0)
     {
         adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), Modellink.name); //记录日志
         JscriptMsg("提交信息成功！", "linklist.aspx", "Success");
     }
     else
     {
         JscriptMsg("提交信息失败！", "linkedit.aspx", "Error");
     }
    }
    #endregion

    #region 修改============================================== 
    public void DataUpdate(int id)
    {
        Modellink.id = id;
        Modellink.name = this.name.Text;//名称
        Modellink.linkUrl = this.linkUrl.Text;//
        Modellink.picUrl = this.photoUrl.Value;

        Modellink.ishidden = Convert.ToInt32(this.isHidden.SelectedValue);
        Modellink.ordernum = Convert.ToInt32(this.ordernum.Text);

        Modellink.note = this.note.Text;
        Modellink.linktype = "";
        Modellink.hits = 1;
        Modellink.updateTime = DateTime.Now;
        Modellink.e_name = this.e_name.Text;
        Modellink.e_content = this.e_content.Text;
        if (blllink.Update(Modellink))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), Modellink.name); //记录日志
            JscriptMsg("提交信息成功！", "linklist.aspx", "Success");
        }
        else
        {
            JscriptMsg("提交信息失败！", "linkedit.aspx", "Error");
        }
    }
    #endregion

    #region 提示框===============================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 保存==========================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//信息id
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
    #endregion
}