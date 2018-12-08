using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Data.SqlClient;
using Cms.DBUtility;

public partial class Admin_wx_wx_userList : System.Web.UI.Page
{
    protected int totalCount;
    protected int page;
    protected int pageSize;

    protected string keywords = string.Empty;
    Cms.Model.C_admin model = new Cms.Model.C_admin();
    public DataSet ds;
    public SqlDataAdapter dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.keywords = DTRequest.GetQueryString("keywords");

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

            Cms.BLL.wx_userinfo bll = new Cms.BLL.wx_userinfo();
            string where = "select * from wx_userinfo  order by updatetime desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bll.GetRecordCount("");
            this.RepeaterDataBind(where);

            bool blDelete = adminUser.setpurview("管理日志", "Delete");
            if (!blDelete)
            {
                btnDelete.Visible = false;
            }
        }
    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (nickname like  '%" + _keywords + "%' or language like '%" + _keywords + "%')");
        }

        return strTemp.ToString();
    }
    #endregion

    #region 数据读取======================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "wx_userinfo");
        this.rptList.DataSource = ds.Tables["wx_userinfo"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from wx_userinfo order by updatetime desc";
        this.RepeaterDataBind(where.ToString());

    }
    #endregion

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("wx_userList.aspx", "nickname={0}", txtKeywords.Text));
    }

    #region 批量删除=============================
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        Cms.BLL.wx_userinfo bll = new Cms.BLL.wx_userinfo();
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("Fielddocid") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                bll.Delete(id);
            }
        }
        JscriptMsg("删除信息成功！", "wx_userList.aspx", "Success");
    }
    #endregion

    //批量删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        Cms.BLL.C_admin_log bll = new Cms.BLL.C_admin_log();

        int sucCount = Cms.DBUtility.DbHelperSQL.ExecuteSql("delete from wx_userinfo where DATEDIFF(day, updatetime, getdate()) > 7");//修改
        adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除管理日志" + sucCount + "条"); //记录日志
        JscriptMsg("删除日志" + sucCount + "条", Utils.CombUrlTxt("wx_userList.aspx", "keywords={0}", this.keywords), "Success");
    }

    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}