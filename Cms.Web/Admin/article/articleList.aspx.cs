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
public partial class Admin_article_articleList : System.Web.UI.Page
{
    public string classid = "";
    Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
    public DataSet ds;
    public SqlDataAdapter dr;
    protected string prolistview = string.Empty;
    protected string parentId = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.prolistview = Utils.GetCookie("article_list_view"); //显示方式
        classid = DTRequest.GetQueryString("classid"); //上级栏目ID
        
        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;
            setqx();//设置权限
            string where = "select * from C_article where parentId=" + Convert.ToInt32(classid) + " order by ordernumber desc,articleId desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bllarticle.GetRecordCount("parentId=" + Convert.ToInt32(classid) + "");
            this.RepeaterDataBind(where);

        }
    }

    #region 保存排序=================================================
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
            Cms.BLL.C_article bll = new Cms.BLL.C_article();
           
            Repeater rptList = new Repeater();
            switch (this.prolistview)
            {
                case "Txt":
                    rptList = this.rptList1;
                    break;
                default:
                    rptList = this.rptList2;
                    break;
            }
          
        
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("Fielddocid")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article set ordernumber=" + sortId + " where articleId='" + id + "'");//修改
            }

            JscriptMsg("保存排序成功！", "articleList.aspx?classid=" + classid, "Success");
        }
    #endregion

    #region 数据读取==================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_article");
        switch (this.prolistview)
        {
            case "Txt":
                this.rptList2.Visible = false;
                this.rptList1.DataSource = ds.Tables["C_article"];
                this.rptList1.DataBind();
                break;
            default:
                this.rptList1.Visible = false;
                this.rptList2.DataSource = ds.Tables["C_article"];
                this.rptList2.DataBind();
                break;
        }

    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int classid = Convert.ToInt32(this.Request.QueryString["classid"] ?? "0");//栏目ID
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_article where parentId=" + classid + " order by ordernumber desc,articleId desc";
        this.RepeaterDataBind(where.ToString());
       
    }

    public void rptList2_Bind(int strparentId)
    {
        Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
        Cms.Model.C_article modelarticle = new Cms.Model.C_article();
        DataSet ds = bllarticle.GetList("parentId=" + strparentId + "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            switch (this.prolistview)
            {
                case "Txt":
                    this.rptList2.Visible = false;
                    this.rptList1.DataSource = ds;
                    this.rptList1.DataBind();
                    break;
                default:
                    this.rptList1.Visible = false;
                    this.rptList2.DataSource = ds;
                    this.rptList2.DataBind();
                    break;
            }

        }
    }
    //设置文字列表显示
    protected void lbtnViewTxt_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("article_list_view", "Txt", 14400);
        Response.Redirect("articleList.aspx?classid=" + this.classid.ToString());

    }

    //设置图文列表显示
    protected void lbtnViewImg_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("article_list_view", "Img", 14400);
        Response.Redirect("articleList.aspx?classid=" + this.classid.ToString());

    }
    #endregion

    #region 批量删除=============================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
        Repeater rptList = new Repeater();
        switch (this.prolistview)
        {
            case "Txt":
                rptList = this.rptList1;
                break;
            default:
                rptList = this.rptList2;
                break;
        }
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("Fielddocid") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                bllarticle.Delete(id);
            }
        }
        JscriptMsg("删除信息成功！", "articleList.aspx?classid=" + classid, "Success");
    }
    #endregion

    #region 提示框=================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 搜索操作======================================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID
        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr="select * from C_article where parentId=" + classid + " and title like '%"+Keywords+"%' order by articleId desc";
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    #region 设置操作==============================================================
    protected void rptList2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("Fielddocid")).Value);
        Cms.BLL.C_article bll = new Cms.BLL.C_article();
        Cms.Model.C_article model =bll.GetModel(id);


        LinkButton lb = (LinkButton)e.Item.FindControl("lbedits");
        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classid = DTRequest.GetQueryString("classid");
        string classname = cm.GetModel(int.Parse(classid)).className;
        bool blEdit = adminUser.setpurview(classname, "Edit");
        if (!blEdit)
        {
            lb.Visible = false;
        }

        switch (e.CommandName)
        {
            case "lbtnIsMsg":
                if (model.is_msg == 1)
                    this.updateSate(id, "is_msg=0");
                else
                    this.updateSate(id, "is_msg=1");
                break;
            case "lbtnIsTop":
                if (model.isTop == 1)
                    this.updateSate(id, "isTop=0");
                else
                    this.updateSate(id, "isTop=1");
                break;
            case "lbtnIsRed":
                if (model.isRecommend == 1)
                    this.updateSate(id, "isRecommend=0");
                else
                    this.updateSate(id, "isRecommend=1");
                break;
            case "lbtnIsHot":
                if (model.isHot == 1)
                    this.updateSate(id, "isHot=0");
                else
                    this.updateSate(id, "isHot=1");
                break;
            case "lbtnIsSlide":
                if (model.is_slide == 1)
                    this.updateSate(id, "is_slide=0");
                else
                    this.updateSate(id, "is_slide=1");
                break;
        }
    }
    public void updateSate(int id, string state)
    {
        string classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID
        int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article set " + state + " where articleId='" + id + "'");//修改
        JscriptMsg("修改成功！", "articleList.aspx?classid=" + classid, "Success");
    }
    #endregion

    #region 设置操作==============================================================
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("Fielddocid")).Value);
       
        Cms.BLL.C_article bll = new Cms.BLL.C_article();
        Cms.Model.C_article model = bll.GetModel(id);

        LinkButton lb = (LinkButton)e.Item.FindControl("lbedit");
        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classid = DTRequest.GetQueryString("classid");
        string classname = cm.GetModel(int.Parse(classid)).className;
        bool blEdit = adminUser.setpurview(classname, "Edit");
        if (!blEdit)
        {
            lb.Visible = false;
        }


        switch (e.CommandName)
        {
            case "lbtnIsMsg":
                if (model.is_msg == 1)
                    this.updateSate(id, "is_msg=0");
                else
                    this.updateSate(id, "is_msg=1");
                break;
            case "lbtnIsTop":
                if (model.isTop == 1)
                    this.updateSate(id, "isTop=0");
                else
                    this.updateSate(id, "isTop=1");
                break;
            case "lbtnIsRed":
                if (model.isRecommend == 1)
                    this.updateSate(id, "isRecommend=0");
                else
                    this.updateSate(id, "isRecommend=1");
                break;
            case "lbtnIsHot":
                if (model.isHot == 1)
                    this.updateSate(id, "isHot=0");
                else
                    this.updateSate(id, "isHot=1");
                break;
            case "lbtnIsSlide":
                if (model.is_slide == 1)
                    this.updateSate(id, "is_slide=0");
                else
                    this.updateSate(id, "is_slide=1");
                break;
        }
    }

    #endregion
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string classid = DTRequest.GetQueryString("classid");
        Response.Redirect("articleEdit.aspx?action=add&classid=" + classid + "");
    }

    public void setqx()
    {
        Cms.BLL.C_Column cm=new Cms.BLL.C_Column();
        string classid = DTRequest.GetQueryString("classid");
        string classname = cm.GetModel(int.Parse(classid)).className;
        bool bladd = adminUser.setpurview(classname, "add");
        bool blEdit = adminUser.setpurview(classname, "Edit");
        bool blDelete = adminUser.setpurview(classname, "Delete");

        if (!bladd)
        {
            btnadd.Visible = false;
        }
        if (!blEdit)
        {
            btnSave.Visible = false;
        }
        if (!blDelete)
        {
            btnDelete.Visible = false;
        }
    }

    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        string articleId = e.CommandArgument.ToString();
        string classid = e.CommandName.ToString();
        Response.Redirect("articleEdit.aspx?action=edit&articleId=" + articleId + "&classid=" + classid + "");
    }
}