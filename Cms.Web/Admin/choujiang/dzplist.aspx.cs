using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Text;
using System.Data;

public partial class Admin_choujiang_dzplist : System.Web.UI.Page
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    Cms.BLL.wx_dzpActionInfo gbll = new Cms.BLL.wx_dzpActionInfo();
    protected string keywords = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.keywords = DTRequest.GetQueryString("keywords");

        this.pageSize = GetPageSize(10); //每页数量

        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;
            RptBind(CombSqlTxt(keywords), "createDate desc,id desc");
        }
    }

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {

        
        
        this.page = DTRequest.GetQueryInt("page", 1);
        txtKeywords.Text = this.keywords;
        DataSet ds = gbll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr;
            DateTime begin = new DateTime();
            DateTime end = new DateTime();
            int count = ds.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                begin = MyCommFun.Obj2DateTime(dr["beginDate"]);
                end = MyCommFun.Obj2DateTime(dr["endDate"]);
                if (begin > DateTime.Now)
                {
                    dr["status_s"] = "<span class=\"act_before\">未开始</span>";
                }
                else if (end <= DateTime.Now)
                {
                    dr["status_s"] = "<span class=\"act_end\">已结束</span>";
                }
                else
                {
                    dr["status_s"] = "<span class=\"act_in\">进行中</span>";
                }
                dr["url"] = MyCommFun.getWebSite() + "/shop/dzp/index.aspx?aid=" + dr["id"].ToString();
            }
            ds.AcceptChanges();
        }
        this.rptList.DataSource = ds;
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("dzplist.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and  actName like  '%" + _keywords + "%' ");
        }

        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("dzplist_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("dzplist.aspx", "keywords={0}", txtKeywords.Text));
    }

    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("dzplist_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("dzplist.aspx", "keywords={0}", this.keywords));
    }

    //批量删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // ChkAdminLevel("manager_list", MXEnums.ActionEnum.Delete.ToString()); //检查权限
        int sucCount = 0;
        int errorCount = 0;

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                if (gbll.DeleteAction(id))
                {
                    sucCount += 1;
                }
                else
                {
                    errorCount += 1;
                }
            }
        }
       adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除刮刮卡活动信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志

        JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("dzplist.aspx", "keywords={0}", this.keywords), "Success");
    }

    /// <summary>
    ///  
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

        }
    }
    #region 提示框===================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}