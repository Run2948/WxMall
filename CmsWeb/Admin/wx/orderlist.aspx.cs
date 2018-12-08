using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Cms.DBUtility;
public partial class Admin_order_orderlist : System.Web.UI.Page
{
    public string classid = "";
    Cms.BLL.wx_log bllorder = new Cms.BLL.wx_log();
    Cms.BLL.C_article ccolumn = new Cms.BLL.C_article();
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
            }
            else if (Session["adminname"] != null)
            {
                Application["adminname"] = (string)Session["adminname"];
            }
            string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
            classid = strparentId;//


            string where = "select * from wx_log  order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bllorder.GetRecordCount("");
            this.RepeaterDataBind(where);

        }
    }

    public string showname(int proid)
    {
        string str = "";
        DataTable dt = ccolumn.GetList("articleId=" + proid + "").Tables[0];
        if (dt.Rows.Count > 0)
        {
            str =dt.Rows[0]["title"].ToString();
        }
        return str;
    }

    /// <summary>
    /// 数据读取
    /// </summary>
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_order");
        this.rptList.DataSource = ds.Tables["C_order"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int classid = Convert.ToInt32(this.Request.QueryString["parentId"] ?? "0");//栏目ID
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from wx_log  order by id desc";
        this.RepeaterDataBind(where.ToString());

    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("chkId") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("hidId") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                bllorder.Delete(id);
                
            }
        }
        JscriptMsg("删除信息成功！", "orderlist.aspx?parentId=" + strparentId, "Success");
    }
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string skeyword = txtKeywords.Text.Trim();
        if (skeyword.Length > 0)
        {
            string where = "select * from wx_log  where title like '%" + skeyword + "%'  order by id desc";
            this.RepeaterDataBind(where.ToString());
        }
    }
}