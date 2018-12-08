using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Data;

public partial class Admin_message_adedit : System.Web.UI.Page
{
    Cms.BLL.C_ad bllad = new Cms.BLL.C_ad();
    Cms.Model.C_ad Modelad = new Cms.Model.C_ad();
    Cms.BLL.C_adtype blladtype = new Cms.BLL.C_adtype();
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

            bindadtype();//绑定广告分类

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

    #region 绑定广告分类=========================
    public void bindadtype()
    {
       
        DataSet ds = blladtype.GetList("");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = ds.Tables[0].Rows[i]["name"].ToString();
                item.Value = ds.Tables[0].Rows[i]["id"].ToString();
                adtype.Items.Add(item);
            }
            //adtype.Items.Insert(0, new ListItem("--请选择--", ""));
        }
    }
    #endregion

    #region 读取数据==============================
    public void DataBind(int id)
    {

        DataSet ds = bllad.GetList("id=" + id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            this.name.Text = dr["name"].ToString();//名称
            this.linkUrl.Text = dr["linkUrl"].ToString();//
            this.photoUrl.Value = dr["picUrl"].ToString();
            this.picurl.Src = dr["picUrl"].ToString();
            this.isHidden.SelectedValue = dr["ishidden"].ToString();
            this.ordernum.Text = dr["ordernum"].ToString();
            this.adtype.SelectedValue = dr["adtype"].ToString();
            this.note.Text = dr["note"].ToString();


        }

    }
    #endregion

    #region 添加====================================
    public void DataAdd()
    {
        Modelad.name = this.name.Text;//名称
        Modelad.linkUrl = this.linkUrl.Text;//
        Modelad.picUrl = this.photoUrl.Value;

        Modelad.ishidden = Convert.ToInt32(this.isHidden.SelectedValue);
        Modelad.ordernum = Convert.ToInt32(this.ordernum.Text);

        Modelad.note = this.note.Text;
        Modelad.adtype = this.adtype.SelectedValue;
        Modelad.hits = 1;
        Modelad.updateTime = DateTime.Now;
        int result = bllad.Add(Modelad);
        if (result > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), Modelad.name); //记录日志
            JscriptMsg("提交信息成功！", "adlist.aspx", "Success");
        }
        else
        {
            JscriptMsg("提交信息失败！", "adedit.aspx", "Error");
        }
    }
    #endregion

    #region 修改===============================
    public void DataUpdate(int id)
    {
        Modelad.id = id;
        Modelad.name = this.name.Text;//名称
        Modelad.linkUrl = this.linkUrl.Text;//
        Modelad.picUrl = this.photoUrl.Value;

        Modelad.ishidden = Convert.ToInt32(this.isHidden.SelectedValue);
        Modelad.ordernum = Convert.ToInt32(this.ordernum.Text);

        Modelad.note = this.note.Text;
        Modelad.adtype = this.adtype.SelectedValue;
        Modelad.hits = 1;
        Modelad.updateTime = DateTime.Now;
        if (bllad.Update(Modelad))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), Modelad.name); //记录日志
            JscriptMsg("提交信息成功！", "adlist.aspx", "Success");
        }
        else
        {
            JscriptMsg("提交信息失败！", "adedit.aspx", "Error");
        }
    }
    #endregion

    #region 提示框============================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 保存=================================
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