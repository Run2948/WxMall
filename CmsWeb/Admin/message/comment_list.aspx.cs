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
public partial class Admin_message_comment_list : System.Web.UI.Page
{
    protected int channel_id;
    protected int totalCount;
    protected int page;
    protected int pageSize;

    public DataSet ds;
    public SqlDataAdapter dr;
    protected string channel_name = string.Empty; //频道名称
    protected string property = string.Empty;
    protected string keywords = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.channel_id =Convert.ToInt32(Request.QueryString["channel_id"]);
        this.channel_name = ""; //取得频道名称
        this.property = Request.QueryString["property"];
        this.keywords = Request.QueryString["keywords"];


        if (!Page.IsPostBack)
        {
            Cms.BLL.C_article_comment bll = new Cms.BLL.C_article_comment();
            string where = "select * from C_article_comment  order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bll.GetRecordCount("");
            this.RepeaterDataBind(where);
        }
    }

    #region 数据绑定=================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_article_comment");
        this.rptList.DataSource = ds.Tables["C_article_comment"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_article_comment order by id desc";
        this.RepeaterDataBind(where.ToString());

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords, string _property)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (user_name like '%" + _keywords + "%' or title like '%" + _keywords + "%' or content like '%" + _keywords + "%')");
        }
        if (!string.IsNullOrEmpty(_property))
        {
            switch (_property)
            {
                case "isLock":
                    strTemp.Append(" and is_lock=1");
                    break;
                case "unLock":
                    strTemp.Append(" and is_lock=0");
                    break;
            }
        }
        return strTemp.ToString();
    }

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("comment_list.aspx", "channel_id={0}&keywords={1}&property={2}",
            this.channel_id.ToString(), txtKeywords.Text, this.property));
    }

    //筛选属性
    protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("comment_list.aspx", "channel_id={0}&keywords={1}&property={2}",
           this.channel_id.ToString(), this.keywords, ddlProperty.SelectedValue));
    }
    #endregion

    #region 审核===================================================
    protected void btnAudit_Click(object sender, EventArgs e)
    {

        Cms.BLL.C_article_comment bll = new Cms.BLL.C_article_comment();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article_comment set is_lock=0 where id='" + id + "'");//修改
            }
        }
        JscriptMsg("审核通过成功！", Utils.CombUrlTxt("comment_list.aspx", "channel_id={0}&keywords={1}&property={2}",
            this.channel_id.ToString(), this.keywords, this.property), "Success");
    }
    #endregion

    #region 批量删除========================================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
       
        int sucCount = 0;
        int errorCount = 0;
        Cms.BLL.C_article_comment bll = new Cms.BLL.C_article_comment();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                if (bll.Delete(id))
                {
                    adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), bll.GetModel(id).content); //记录日志
                    sucCount += 1;
                }
                else
                {
                    errorCount += 1;
                }
            }
        }
        
        JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
            Utils.CombUrlTxt("comment_list.aspx", "channel_id={0}&keywords={1}&property={2}", this.channel_id.ToString(), this.keywords, this.property), "Success");
    }
    #endregion

    #region 提示框================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}