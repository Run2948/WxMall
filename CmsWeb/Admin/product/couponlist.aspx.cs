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

    Cms.BLL.sc_Coupon bllorder = new Cms.BLL.sc_Coupon();
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
           

            Bind();
           
           
        }
    }

    /// <summary>
    /// 绑定内容
    /// </summary>
    public void Bind()
    {
        string where = "select * from sc_Coupon  order by id desc";
        this.AspNetPager1.AlwaysShow = true;
        this.AspNetPager1.PageSize = 10;
        this.AspNetPager1.RecordCount = bllorder.GetRecordCount("");
        this.RepeaterDataBind(where);

    
        Cms.BLL.C_Column cm=new Cms.BLL.C_Column();
        string classname = cm.GetModel(86).className;
        bool bladd = adminUser.setpurview(classname, "add");
        bool blEdit = adminUser.setpurview(classname, "Edit");
        bool blDelete = adminUser.setpurview(classname, "Delete");

        if (!bladd)
        {
            btnadd.Visible = false;
        }
        if (!blDelete)
        {
            btnDelete.Visible = false;
        }
    
    }

    /// <summary>
    /// 返回类别名称
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public string typename(string type)
    {
        string str = "";
        Cms.BLL.C_article_category ccc = new Cms.BLL.C_article_category();
        DataTable dt = ccc.GetList("id="+Convert.ToInt32(type)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            str = dt.Rows[0]["title"].ToString();
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
        string where = "select * from sc_Coupon  order by id desc";
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
        JscriptMsg("删除信息成功！", "couponlist.aspx?parentId=" + strparentId, "Success");
    }
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }

    /// <summary>
    /// 搜索内容
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string skeyword = txtKeywords.Text.Trim();
       // if (skeyword.Length > 0)
        {
            string where = "select * from sc_Coupon  where cname like '%" + skeyword + "%'  order by id desc";
            this.RepeaterDataBind(where.ToString());
        }
    }

    /// <summary>
    /// 添加信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("couponedit.aspx?action=add");
    }


    /// <summary>
    /// 编辑信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        
        string id = e.CommandArgument.ToString();

        Response.Redirect("couponedit.aspx?action=edit&id=" + id);
    }

  
    /// <summary>
    /// 权限控制
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lbedit = e.Item.FindControl("lbedit") as LinkButton;
        

        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classname = cm.GetModel(86).className;
       
        bool blEdit = adminUser.setpurview(classname, "Edit");


        if (!blEdit)
        {
            lbedit.Visible = false;
           
        }
        
    }
}