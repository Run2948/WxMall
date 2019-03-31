using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Text;


public partial class Admin_wxRule_tuwenMgr : System.Web.UI.Page
{
    Cms.BLL.wx_requestRuleContent rcbll = new Cms.BLL.wx_requestRuleContent();
    protected string keywords = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            // ChkAdminLevel("manager_list", MXEnums.ActionEnum.View.ToString()); //检查权限
            int rid = MyCommFun.RequestInt("rid");
            Cms.BLL.wx_requestRule rbll = new Cms.BLL.wx_requestRule();
            Cms.Model.wx_requestRule rule = rbll.GetModel(rid);
            this.lblKeyWords.Text = MyCommFun.SubStrAddSuffix(rule.reqKeywords, 10, "...");
            hlAddTuWen.NavigateUrl = "editTuWen.aspx?rid=" + rid + "&action=" + Enums.ActionEnum.Add;
            RptBind();
        }
    }

    #region 数据绑定=================================
    private void RptBind()
    {
        int rid = MyCommFun.RequestInt("rid");
        string _strWhere = "rId=" + rid + " order by seq asc";
        this.rptList.DataSource = rcbll.GetList(_strWhere);
        this.rptList.DataBind();
    }
    #endregion


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
                if (rcbll.Delete(id))
                {
                    sucCount += 1;
                }
                else
                {
                    errorCount += 1;
                }
            }
        }
        adminUser.AddAdminLog(Enums.ActionEnum.Delete.ToString(), "删除图文回复信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志

        JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", "tuwenMgr.aspx?rid=" + MyCommFun.RequestInt("rid"), "Success");
    }

    /// <summary>
    /// 选择某一个微信公众帐号，并且将其保存到session里
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "toIndex":
                {
                    int wid = int.Parse(e.CommandArgument.ToString());

                }
                break;
        }
    }

    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int rid = MyCommFun.RequestInt("rid");
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hlEdit = e.Item.FindControl("hlEdit") as HyperLink;
            HiddenField hidId = e.Item.FindControl("hidId") as HiddenField;
            hlEdit.NavigateUrl = "editTuWen.aspx?rid=" + rid + "&id=" + hidId.Value + "&action=" + Enums.ActionEnum.Edit;
        }
    }
    #region 提示框============================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}