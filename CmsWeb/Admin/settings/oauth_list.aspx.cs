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

public partial class Admin_settings_oauth_list : System.Web.UI.Page
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    public DataSet ds;
    public SqlDataAdapter dr;
    protected string keywords = string.Empty;
    Cms.BLL.C_user_oauth bll = new Cms.BLL.C_user_oauth();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.keywords = DTRequest.GetQueryString("keywords");
        if (!Page.IsPostBack)
        {

            string where = "select * from C_user_oauth  order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bll.GetRecordCount("");
            this.RepeaterDataBind(where);
        }
    }

    #region 数据读取========================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_user_oauth");
        this.rptList.DataSource = ds.Tables["C_user_oauth"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_user_oauth order by id desc";
        this.RepeaterDataBind(where.ToString());

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (user_name like '%" + _keywords + "%' or oauth_name like '%" + _keywords + "%')");
        }

        return strTemp.ToString();
    }

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("oauth_list.aspx", "keywords={0}", txtKeywords.Text));
    }
    #endregion


    //批量删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
        int sucCount = 0;
        int errorCount = 0;
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), bll.GetModel(id).oauth_name); //记录日志
                if (bll.Delete(id))
                {
                    
                    sucCount += 1;
                }
                else
                {
                    errorCount += 1;
                }
            }
        }
        JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("oauth_list.aspx", "keywords={0}", this.keywords), "Success");
    }
    #region 提示框=======================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}