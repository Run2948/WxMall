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

public partial class Admin_settings_typelist : System.Web.UI.Page
{
    protected int channel_id;
    protected string channel_name = string.Empty; //频道名称
    public DataSet ds;
    public SqlDataAdapter dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            RptBind();
        }
    }

    #region 数据绑定==================================
    private void RptBind()
    {
        Cms.BLL.sc_stores bll = new Cms.BLL.sc_stores();
        DataTable dt = bll.GetList("").Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();

        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classname = cm.GetModel(27).className;
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


    #region 数据绑定=================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_article_attribute_field");
        this.rptList.DataSource = ds.Tables["sc_stores"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from sc_stores order by id desc";
        this.RepeaterDataBind(where.ToString());

    }
    #endregion

    //美化列表
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
         
            LinkButton lb = (LinkButton)e.Item.FindControl("lbedit");
            
            Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
            string classname = cm.GetModel(27).className;
            bool blEdit = adminUser.setpurview(classname, "Edit");
            if (!blEdit)
            {
                lb.Visible = false;
            }
           


        }

    }
    #endregion

    #region 保存排序==============================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        Cms.BLL.C_type bll = new Cms.BLL.C_type();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update sc_stores set sort_id=" + sortId + " where id='" + id + "'");//修改

        }
        adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改顺序" + this.channel_name + "门店信息"); //记录日志
        JscriptMsg("保存排序成功！", Utils.CombUrlTxt("storeslist.aspx", "channel_id={0}", this.channel_id.ToString()), "Success");
    }
    #endregion

    #region 删除类别=====================================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
        Cms.BLL.sc_stores bll = new Cms.BLL.sc_stores();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                bll.Delete(id);
            }
        }
        adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除" + this.channel_name + "门店信息"); //记录日志
        JscriptMsg("删除数据成功！", Utils.CombUrlTxt("storeslist.aspx", "channel_id={0}", this.channel_id.ToString()), "Success");
    }
    #endregion

    #region 获取分类所属栏目名称=================================
    public string gettype(int channel_id)
    {
        string result = "";
        if (channel_id == 0)
        {
            result = "正常";
        }
        if (channel_id == 1)
        {
            result = "待审核";
        }
        if (channel_id == 1)
        {
            result = "不显示";
        }
        return result;
    }
    public string getcolumn(int channel_id)
    {
        string result = "";
        Cms.BLL.C_article_category bll = new Cms.BLL.C_article_category();
        DataSet ds = bll.GetList("id=" + channel_id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = ds.Tables[0].Rows[0]["title"].ToString();
        }
        return result;
    }
    #endregion

    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

  

    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("storesedit.aspx?action=add");
    }
    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        string cid = e.CommandArgument.ToString();
        Response.Redirect("storesedit.aspx?action=edit&id=" + cid + "");
    }

}