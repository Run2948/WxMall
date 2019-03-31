using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;


public partial class Admin_settings_payment_list : System.Web.UI.Page
{
    protected string keywords = string.Empty;
    Cms.BLL.C_payment bll = new Cms.BLL.C_payment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            RptBind("id>0" + CombSqlTxt(keywords), "sort_id asc,id desc");
        }
    }

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        txtKeywords.Text = this.keywords;
        this.rptList.DataSource = bll.GetList(0, _strWhere, _orderby);
        this.rptList.DataBind();
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and title like  '%" + _keywords + "%'");
        }

        return strTemp.ToString();
    }
    #endregion

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("payment_list.aspx", "keywords={0}", txtKeywords.Text));
    }

    //保存排序
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
           
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_payment set sort_id=" + sortId + " where id='" + id + "'");//修改
        }
      
        JscriptMsg("保存排序成功！", Utils.CombUrlTxt("payment_list.aspx", "keywords={0}", this.keywords), "Success");
    }
    #region 提示框=======================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}