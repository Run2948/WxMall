using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Data;

public partial class Admin_message_adtypeEdit : System.Web.UI.Page
{
    Cms.BLL.C_adtype blladtype = new Cms.BLL.C_adtype();
    Cms.Model.C_adtype Modeladtype = new Cms.Model.C_adtype();
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
    #region 读取数据===================================
    public void DataBind(int id)
    {

        DataSet ds = blladtype.GetList("id=" + id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            this.name.Text = dr["name"].ToString();//名称
            this.isHidden.SelectedValue = dr["ishidden"].ToString();
            this.ordernum.Text = dr["ordernum"].ToString();

            this.note.Text = dr["note"].ToString();


        }

    }
    #endregion

    #region 添加==============================
    public void DataAdd()
    {
        Modeladtype.name = this.name.Text;//名称

      

        Modeladtype.ishidden = Convert.ToInt32(this.isHidden.SelectedValue);
        Modeladtype.ordernum = Convert.ToInt32(this.ordernum.Text);

        Modeladtype.note = this.note.Text;
     
        int result = blladtype.Add(Modeladtype);
        if (result > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), Modeladtype.name); //记录日志
            JscriptMsg("提交信息成功！", "adtypelist.aspx", "Success");
        }
        else
        {
            JscriptMsg("提交信息失败！", "adtypeEdit.aspx", "Error");
        }
    }
    #endregion

    #region 修改=========================================
    public void DataUpdate(int id)
    {
        Modeladtype.id = id;
        Modeladtype.name = this.name.Text;//名称
       

        Modeladtype.ishidden = Convert.ToInt32(this.isHidden.SelectedValue);
        Modeladtype.ordernum = Convert.ToInt32(this.ordernum.Text);

        Modeladtype.note = this.note.Text;
       
        if (blladtype.Update(Modeladtype))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), Modeladtype.name); //记录日志
            JscriptMsg("提交信息成功！", "adtypelist.aspx", "Success");
        }
        else
        {
            JscriptMsg("提交信息失败！", "adtypeEdit.aspx", "Error");
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

    #region 保存=======================================
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