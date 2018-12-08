using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using Cms.BLL;

public partial class Admin_wx_editWenBen : System.Web.UI.Page
{
    private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
    private int id = 0;
    wx_requestRule rBll = new wx_requestRule();
    wx_requestRuleContent rcBll = new wx_requestRuleContent();

    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = DTRequest.GetQueryString("action");
        if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
        {
            this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!rBll.Exists(this.id))
            {
                JscriptMsg("记录不存在或已被删除！", "back", "Error");
                return;
            }
        }
        if (!Page.IsPostBack)
        {

            //  ChkAdminLevel("manager_list", DTEnums.ActionEnum.View.ToString()); //检查权限

            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ShowInfo(this.id);
            }
        }
    }



    #region 赋值操作=================================
    private void ShowInfo(int id)
    {
        DataSet ds = rBll.GetRuleContent("id=" + id);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            txtreqKeywords.Text = MyCommFun.ObjToStr(dr["reqKeywords"]);
            if (MyCommFun.ObjToStr(dr["isLikeSearch"]) != "")
            {
                if (dr["isLikeSearch"].ToString().ToLower() == "false")
                {
                    rblisLikeSearch.SelectedValue = "0";

                }
                else
                { rblisLikeSearch.SelectedValue = "1"; }
            }

            txtrContent.Text = MyCommFun.ObjToStr(dr["rContent"]);
        }

    }

    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        string strErr = "";
        if (this.txtreqKeywords.Text.Trim().Length == 0)
        {
            strErr += "关键词不能为空！";
        }
        if (this.txtrContent.Text.Trim().Length == 0)
        {
            strErr += "内容或简介不能为空！";
        }
        if (strErr != "")
        {
            JscriptMsg(strErr, "back", "Error");
            return false;
        }

        Cms.Model.C_admin manager = adminUser.GetLoginState();
        //Cms.Model.wx_userweixin weixin = GetWeiXinCode();

        Cms.Model.wx_requestRule rule = new Cms.Model.wx_requestRule();
        rule.uId = manager.id;
        rule.wId = 1;
        rule.ruleName = "纯文本回复";
        rule.reqKeywords = txtreqKeywords.Text.Trim();
        rule.reqestType = 1;
        rule.responseType = 1;
        string radoValue = rblisLikeSearch.SelectedItem.Value;
        if (radoValue == "0")
        {
            rule.isLikeSearch = false;
        }
        else
        {
            rule.isLikeSearch = true;
        }
        rule.createDate = DateTime.Now;
        int rId = rBll.Add(rule);
        Cms.Model.wx_requestRuleContent rc = new Cms.Model.wx_requestRuleContent();
        rc.uId = manager.id;
        rc.rId = rId;
        rc.rContent = txtrContent.Text.Trim();
        rc.createDate = DateTime.Now;
        int rcId = rcBll.Add(rc);


        if (rcId > 0)
        {
           adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加纯文本回复，主键为:" + rId + ",关键词为：" + txtreqKeywords.Text.Trim()); //记录日志
            return true;
        }
        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        string strErr = "";
        if (this.txtreqKeywords.Text.Trim().Length == 0)
        {
            strErr += "关键词不能为空！";
        }
        if (this.txtrContent.Text.Trim().Length == 0)
        {
            strErr += "内容或简介不能为空！";
        }
        if (strErr != "")
        {
            JscriptMsg(strErr, "back", "Error");
            return false;
        }


        Cms.Model.wx_requestRule rule = rBll.GetModel(id);
        rule.reqKeywords = txtreqKeywords.Text.Trim();
        string radoValue = rblisLikeSearch.SelectedItem.Value;
        if (radoValue == "0")
        {
            rule.isLikeSearch = false;
        }
        else
        {
            rule.isLikeSearch = true;
        }
        bool ret = rBll.Update(rule);
        IList<Cms.Model.wx_requestRuleContent> ruleContentList = rcBll.GetModelList("rId=" + id);
        if (ruleContentList != null && ruleContentList.Count > 0)
        {
            Cms.Model.wx_requestRuleContent ruleContent = ruleContentList[0];

            ruleContent.rContent = txtrContent.Text;
            ret = rcBll.Update(ruleContent);
        }
        if (ret)
        {
           adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改纯文本回复，主键为:" + rule.id); //记录日志
            return true;
        }
        return false;
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
        {
            // ChkAdminLevel("manager_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("修改纯文本回复信息成功！", "wenBenList.aspx", "Success");
        }
        else //添加
        {
            // ChkAdminLevel("manager_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }

            JscriptMsg("添加纯文本回复信息成功！", "wenBenList.aspx", "Success");
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