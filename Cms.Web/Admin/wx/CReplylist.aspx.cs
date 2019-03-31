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
public partial class Admin_order_orderlist : System.Web.UI.Page
{
    
    Cms.BLL.wx_ConcernReply bllorder = new Cms.BLL.wx_ConcernReply();
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


    public void Bind()
    {
        string where = "select * from wx_ConcernReply  order by id desc";
        this.AspNetPager1.AlwaysShow = true;
        this.AspNetPager1.PageSize = 10;
        this.AspNetPager1.RecordCount = bllorder.GetRecordCount("");
        this.RepeaterDataBind(where);

    
        Cms.BLL.C_Column cm=new Cms.BLL.C_Column();
        string classname = cm.GetModel(81).className;
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

    public string typename(string type)
    {
        string str = "";
        if (type == "0")
        {
            str = "文本";
        }
        if (type == "1")
        {
            str = "图文";
        }
        if (type == "2")
        {
            str = "语音";
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
        string where = "select * from wx_ConcernReply  order by id desc";
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
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "微信：" + bllorder.GetModel(id).title); //记录日志
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
       // if (skeyword.Length > 0)
        {
           // string where = "select * from wx_ConcernReply  where title like '%" + skeyword + "%'  order by id desc";
        //    this.RepeaterDataBind(where.ToString());
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("CReplyedit.aspx?action=add");
    }

    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        
        string id = e.CommandArgument.ToString();

        Response.Redirect("CReplyedit.aspx?action=edit&id=" + id);
    }

    protected void lbopen_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        Cms.BLL.wx_ConcernReply bllarticle = new Cms.BLL.wx_ConcernReply();
        Cms.Model.wx_ConcernReply modelarticle = new Cms.Model.wx_ConcernReply();
        modelarticle = bllarticle.GetModel(int.Parse(id));
        bool bl = false;
        if (modelarticle != null)
        {
            int isRecommend = int.Parse(modelarticle.isopen.ToString());
            if (isRecommend == 1)
            {
                isRecommend = 0;
            }
            else
            {
                bl = true;
                isRecommend = 1;
                string strSql = "update wx_ConcernReply  set isopen=0 where id not in("+id+")";
                DbHelperSQL.ExecuteSql(strSql);
            }
            modelarticle.isopen = isRecommend;
            bllarticle.Update(modelarticle);
            Bind();
        }
        if (bl)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信开通成功：" + bllarticle.GetModel(int.Parse(id)).title); //记录日志
            JscriptMsg("开通成功！", "CReplylist.aspx", "Success");
        }
        else
        {
            JscriptMsg("取消开通！", "CReplylist.aspx", "Success");
        }
    }
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lbedit = e.Item.FindControl("lbedit") as LinkButton;
        LinkButton lbopen = e.Item.FindControl("lbopen") as LinkButton;

        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classname = cm.GetModel(81).className;
       
        bool blEdit = adminUser.setpurview(classname, "Edit");


        if (!blEdit)
        {
            lbedit.Visible = false;
            lbopen.Visible = false;
        }
        
    }
}