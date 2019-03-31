using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Cms.DBUtility;

public partial class Admin_lottery_lotterylist : System.Web.UI.Page
{
    public string classid = "";
    public string classname = "";
    Cms.BLL.ws_Lottery blladmin = new Cms.BLL.ws_Lottery();
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
            string typeid = this.Request.QueryString["typeid"] ?? "";
            classid = strparentId;//


            string where = "select * from ws_Lottery where typeid=" + typeid + "  order by id desc ";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = blladmin.GetRecordCount("typeid=" + typeid + "");
            this.RepeaterDataBind(where);
            bool bladd = true;
            bool blDelete = true;
            if (typeid == "1")
            {
                classname = "大转盘抽奖";
                bladd = adminUser.setpurview("大转盘抽奖", "add");
                blDelete = adminUser.setpurview("大转盘抽奖", "Delete");
            }
            if (typeid == "2")
            {
                classname = "刮刮乐抽奖";
                bladd = adminUser.setpurview("刮刮乐抽奖", "add");
                blDelete = adminUser.setpurview("刮刮乐抽奖", "Delete");
            }
            if (typeid == "3")
            {
                classname = "随机抽奖";
                bladd = adminUser.setpurview("随机抽奖", "add");
                blDelete = adminUser.setpurview("随机抽奖", "Delete");
            }
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
  

    #region 数据读取===========================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_admin");
        this.rptList.DataSource = ds.Tables["C_admin"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        string typeid = this.Request.QueryString["typeid"] ?? "";
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from ws_Lottery where typeid=" + typeid + "  order by id desc ";
        this.RepeaterDataBind(where.ToString());

    }
    #endregion

    #region 删除====================================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string typeid = this.Request.QueryString["typeid"] ?? "";
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("hidId") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                blladmin.Delete(id);
            }
        }
        JscriptMsg("删除信息成功！", "lotterylist.aspx?typeid="+typeid, "Success");
    }
    #endregion

    #region 提示框====================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 搜索==================================================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string typeid = this.Request.QueryString["typeid"] ?? "";
        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr = "select * from ws_Lottery where  typeid=" + typeid + " and lname like '%" + Keywords + "%' order by id desc";
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    protected void btnadd_Click(object sender, EventArgs e)
    {
        string typeid = this.Request.QueryString["typeid"] ?? "";
        Response.Redirect("lotteryedit.aspx?action=add&typeid="+typeid);
    }
    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        string typeid = this.Request.QueryString["typeid"] ?? "";
        string cid = e.CommandArgument.ToString();
        Response.Redirect("lotteryedit.aspx?action=edit&id=" + cid + "&typeid=" + typeid);
    }

    protected void rptList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LinkButton edit = (LinkButton)e.Item.FindControl("lbedit");
            string typeid = this.Request.QueryString["typeid"] ?? "";
            bool blEdit = true;
            if (typeid == "1")
            {
                blEdit = adminUser.setpurview("大转盘抽奖", "Edit");
            }
            if (typeid == "2")
            {
                blEdit = adminUser.setpurview("刮刮乐抽奖", "Edit");
            }
            if (typeid == "3")
            {
                blEdit = adminUser.setpurview("随机抽奖", "Edit");
            }
            if (!blEdit)
            {
                edit.Visible = false;
            }
        }
    }
}