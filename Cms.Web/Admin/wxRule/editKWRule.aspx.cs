using Cms.BLL;
using Cms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_wxRule_editKWRule : System.Web.UI.Page
{
    wx_requestRule rBll = new wx_requestRule();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int rid = MyCommFun.RequestInt("rid");
            this.hidrId.Value = rid.ToString();
            if (rid > 0)
            {
                BindData(rid);
            }

        }
    }
    /// <summary>
    /// 编辑状态：赋值页面上的值
    /// </summary>
    /// <param name="id"></param>
    private void BindData(int id)
    {
        Cms.Model.wx_requestRule rule = rBll.GetModel(id);
        if (rule != null)
        {
            txtreqKeywords.Text = rule.reqKeywords;
            if (rule.isLikeSearch.ToString().ToLower() == "false")
            {
                this.rblisLikeSearch.SelectedValue = "0";
            }
            else
            {
                this.rblisLikeSearch.SelectedValue = "1";
            }
        }

    }


    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            string strErr = "";
            if (this.txtreqKeywords.Text.Trim().Length == 0)
            {
                strErr += "关键词不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            Cms.Model.C_admin admin = adminUser.GetLoginState();
            

            int rid = int.Parse(hidrId.Value);//规则id
            AddRule(rid);
           adminUser.AddAdminLog(Enums.ActionEnum.Edit.ToString(), "编辑图文回复"); //记录日志
            MessageBox.ResponseScript(this, " api.close(); ");
        }
        catch
        {
            JscriptMsg("编辑回复规则有问题！", "", "Error");
        }



    }

    /// <summary>
    /// 添加/修改规则
    /// </summary>
    /// <returns></returns>
    private void AddRule(int id)
    {

        Cms.Model.C_admin admin = adminUser.GetLoginState();
        
        Cms.Model.wx_requestRule rule = new Cms.Model.wx_requestRule();
        if (id == 0)
        {
            rule.uId = admin.id;
            rule.wId =1;
            rule.ruleName = "图文回复";

            rule.isDefault = false;
            rule.reqestType = 1;//关键词回复
            rule.createDate = DateTime.Now;
            rule.responseType = 2;//回复的类型:文本1，图文2，语音3，视频4,第三方接口5
        }
        else
        {
            rule = rBll.GetModel(id);
        }
        string radoValue = rblisLikeSearch.SelectedItem.Value;
        if (radoValue == "0")
        {
            rule.isLikeSearch = false;
        }
        else
        {
            rule.isLikeSearch = true;
        }
        rule.reqKeywords = txtreqKeywords.Text.Trim();

        if (id == 0)
        {
            rBll.Add(rule);
        }
        else
        {
            rBll.Update(rule);
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