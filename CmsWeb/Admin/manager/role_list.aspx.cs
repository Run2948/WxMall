using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Cms.DBUtility;
using Cms.Common;

public partial class Admin_manager_role_list : System.Web.UI.Page
{
    public string classid = "";
    Cms.BLL.C_admin_role blladmin_role = new Cms.BLL.C_admin_role();
    public DataSet ds;
    public SqlDataAdapter dr;
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
                Application["adminType"] = (string)cookie.Values["adminType"];
            }
            else if (Session["adminname"] != null)
            {
                Application["adminname"] = (string)Session["adminname"];
                Application["adminType"] = (string)Session["adminType"];
            }
            string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
            classid = strparentId;//


            string where = "select * from C_admin_role where role_type>=" + Convert.ToInt32(Application["adminType"]) + " order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = blladmin_role.GetRecordCount("");
            this.RepeaterDataBind(where);

            bool bladd = adminUser.setpurview("角色管理", "add");

            bool blDelete = adminUser.setpurview("角色管理", "Delete");

            if (!bladd)
            {
                btnadd.Visible = false;
            }
            if (!blDelete)
            {
                btnDelete.Visible = false;
            }
        }
    }

    #region 返回角色类型名称=========================
    protected string GetTypeName(int role_type)
    {
        string str = "";
        switch (role_type)
        {
            case 1:
                str = "超级用户";
                break;
            default:
                str = "系统用户";
                break;
        }
        return str;
    }
    #endregion

    #region 数据读取======================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_admin_role");
        this.rptList.DataSource = ds.Tables["C_admin_role"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int classid = Convert.ToInt32(this.Request.QueryString["parentId"] ?? "0");//栏目ID
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_admin_role where role_type>=" + Convert.ToInt32(Application["adminType"]) + " order by id desc";
        this.RepeaterDataBind(where.ToString());

    }
    #endregion

    #region 删除===================================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("Fielddocid") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                blladmin_role.Delete(id);
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), blladmin_role.GetModel(id).role_name); //记录日志
            }
        }
        JscriptMsg("删除信息成功！", "role_list.aspx", "Success");
    }
    #endregion

    #region 提示框==================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 搜索===============================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
        classid = strparentId;//
        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr = "select * from C_admin_role where name like '%" + Keywords + "%' order by id desc";
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("role_edit.aspx?action=add");
    }

    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        string cid = e.CommandArgument.ToString();
        Response.Redirect("role_edit.aspx?action=edit&id=" + cid + "");
    }
    protected void rptList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LinkButton edit = (LinkButton)e.Item.FindControl("lbedit");
            bool blEdit = adminUser.setpurview("角色管理", "Edit");

            if (!blEdit)
            {
                edit.Visible = false;
            }
        }
    }
}