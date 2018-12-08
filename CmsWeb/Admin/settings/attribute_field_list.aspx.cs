using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;
using System.Data;

public partial class Admin_settings_attribute_field_list : System.Web.UI.Page
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    public DataSet ds;
    public SqlDataAdapter dr;
    protected string control_type = string.Empty;
    protected string keywords = string.Empty;
    Cms.BLL.C_article_attribute_field bllattribute = new Cms.BLL.C_article_attribute_field();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.control_type = DTRequest.GetQueryString("control_type");
        this.keywords = DTRequest.GetQueryString("keywords");

        this.pageSize = GetPageSize(10); //每页数量
        if (!Page.IsPostBack)
        {
            string where = "select * from C_article_attribute_field  order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bllattribute.GetRecordCount("");
            this.RepeaterDataBind(where);
            
        }
    }

    #region 数据绑定=================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_article_attribute_field");
        this.rptList.DataSource = ds.Tables["C_article_attribute_field"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_article_attribute_field order by id desc";
        this.RepeaterDataBind(where.ToString());

    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _control_type, string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        if (!string.IsNullOrEmpty(_control_type))
        {
            strTemp.Append(" and control_type='" + _control_type + "'");
        }
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (name like  '%" + _keywords + "%' or title like '%" + _keywords + "%')");
        }

        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("attribute_field_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

    #region 返回字段类型中文名称
    protected string GetTypeCn(string _control_type)
    {
        string type_name = "";
        switch (_control_type)
        {
            case "single-text":
                type_name = "单行文本";
                break;
            case "multi-text":
                type_name = "多行文本";
                break;
            case "editor":
                type_name = "编辑器";
                break;
            case "images":
                type_name = "图片上传";
                break;
            case "number":
                type_name = "数字";
                break;
            case "checkbox":
                type_name = "复选框";
                break;
            case "multi-radio":
                type_name = "多项单选";
                break;
            case "multi-checkbox":
                type_name = "多项多选";
                break;
            default:
                type_name = "未知类型";
                break;
        }
        return type_name;
    }
    #endregion

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("attribute_field_list.aspx", "control_type={0}&keywords={1}", this.control_type, txtKeywords.Text));
    }

    //筛选类型
    protected void ddlControlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("attribute_field_list.aspx", "control_type={0}&keywords={1}", ddlControlType.SelectedValue, this.keywords));
    }


    //保存排序
    protected void btnSave_Click(object sender, EventArgs e)
    {

        Cms.BLL.C_article_attribute_field bll = new Cms.BLL.C_article_attribute_field();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
          
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article_attribute_field set sort_id=" + sortId + " where id='" + id + "'");//修改
        }
        adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "保存扩展字段排序"); //记录日志
        JscriptMsg("保存排序成功！", Utils.CombUrlTxt("attribute_field_list.aspx", "control_type={0}&keywords={1}", this.control_type, this.keywords), "Success");
    }

    //批量删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
        int sucCount = 0; //成功数量
        int errorCount = 0; //失败数量
        Cms.BLL.C_article_attribute_field bll = new Cms.BLL.C_article_attribute_field();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                if (bll.Delete(id))
                {
                    sucCount++;
                }
                else
                {
                    errorCount++;
                }
            }
        }
        adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除扩展字段成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
        JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("attribute_field_list.aspx", "control_type={0}&keywords={1}", this.control_type, this.keywords), "Success");
    }
    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}