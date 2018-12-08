using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using Cms.BLL;

public partial class Admin_choujiang_ggkEdit : System.Web.UI.Page
{
    private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型

    wx_ggkActionInfo ggkBll = new wx_ggkActionInfo();
    wx_ggkAwardItem iBll = new wx_ggkAwardItem();
    wx_requestRule rBll = new wx_requestRule();

    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = DTRequest.GetQueryString("action");
        int id = 0;
        if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
        {

            this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
            if (!int.TryParse(Request.QueryString["id"] as string, out  id))
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!ggkBll.Exists(id))
            {
                JscriptMsg("记录不存在或已被删除！", "back", "Error");
                return;
            }
        }
        if (!Page.IsPostBack)
        {

            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ShowInfo(id);
            }
            else
            {
                txtbeginDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                txtendDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }



    #region 赋值操作=================================
    private void ShowInfo(int id)
    {
        hidid.Value = id.ToString();
        Cms.Model.wx_ggkActionInfo ggk = ggkBll.GetModel(id);
        IList<Cms.Model.wx_ggkAwardItem> aItemlist = iBll.GetModelList("actId=" + id);
        Cms.Model.wx_requestRule rule = rBll.GetModelList("modelFunctionName='刮刮卡' and modelFunctionId=" + id)[0];
        txtKW.Text = rule.reqKeywords;

        if (ggk.beginPic != null && ggk.beginPic.Trim() != "/weixin/ggk/images/start.jpg")
        {
            txtImgUrl.Text = ggk.beginPic;
            imgbeginPic.ImageUrl = ggk.beginPic;
        }
        txtactName.Text = ggk.actName;
        txtcontractInfo.Text = ggk.contractInfo;
        txtbrief.Value = ggk.brief;
        txtbeginDate.Text = ggk.beginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
        txtendDate.Text = ggk.endDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
        txtactContent.Value = ggk.actContent;
        txtcfcjhf.Text = ggk.cfcjhf;
        this.txtdjPwd.Text = ggk.djPwd;
        //结束
        if (ggk.endPic != null && ggk.endPic.Trim() != "/weixin/ggk/images/end.jpg")
        {
            txtEndPic.Text = ggk.endPic;
            imgEndPic.ImageUrl = ggk.endPic;
        }
        txtendNotice.Text = ggk.endNotice;
        txtendContent.Text = ggk.endContent;

        //奖项基本信息
        txtpersonNum.Text = MyCommFun.ObjToStr(ggk.personNum);
        txtpersonMaxTimes.Text = MyCommFun.ObjToStr(ggk.personMaxTimes);
        txtdayMaxTimes.Text = MyCommFun.ObjToStr(ggk.dayMaxTimes);


        //绑定奖项信息
        IList<Cms.Model.wx_ggkAwardItem> itemlist = iBll.GetModelList("actId=" + id + " order by sort_id asc");
        if (itemlist != null && itemlist.Count > 0)
        {
            int count = itemlist.Count;
            TextBox txtJXName;
            TextBox txtJPName;
            TextBox txtNum;
            TextBox txtRealNum;
            Cms.Model.wx_ggkAwardItem itemEntity = new Cms.Model.wx_ggkAwardItem();
            for (int i = 1; i <= count; i++)
            {
                itemEntity = itemlist[(i - 1)];
                txtJXName = this.FindControl("txt" + i + "JXName") as TextBox;
                txtJPName = this.FindControl("txt" + i + "JPName") as TextBox;
                txtNum = this.FindControl("txt" + i + "Num") as TextBox;
                txtRealNum = this.FindControl("txt" + i + "RealNum") as TextBox;

                txtJXName.Text = itemEntity.jxName;
                txtJPName.Text = itemEntity.jpName;
                txtNum.Text = itemEntity.jpNum == null ? "0" : itemEntity.jpNum.Value.ToString();
                txtRealNum.Text = itemEntity.jpRealNum == null ? "0" : itemEntity.jpRealNum.Value.ToString();
            }

        }

    }

    #endregion



    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Model.wx_userweixin weixin = GetWeiXinCode();

        Cms.Model.wx_requestRuleContent rc = new Cms.Model.wx_requestRuleContent();
        int id = MyCommFun.Str2Int(hidid.Value);
        #region  //先判断
        string strErr = "";
        if (this.txtKW.Text.Trim().Length == 0)
        {
            strErr += "关键词不能为空！";
        }
        if (this.txtactName.Text.Trim().Length == 0)
        {
            strErr += "活动名称不能为空！";
        }
        if (this.txtbeginDate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtbeginDate.Text))
        {
            strErr += "开始时间不能为空！";
        }
        if (this.txtendDate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtendDate.Text))
        {
            strErr += "结束时间不能为空！";
        }
        if (txt1JXName.Text.Trim().Length == 0 || txt1JPName.Text.Trim().Length == 0 || txt1Num.Text.Trim().Length == 0 || txt1RealNum.Text.Trim().Length == 0)
        {
            strErr += "第一个奖项不能为空！";
        }
        if (strErr != "")
        {
            JscriptMsg(strErr, "back", "Error");
            return;
        }
        DateTime begin = DateTime.Parse(txtbeginDate.Text.Trim());
        DateTime end = DateTime.Parse(txtendDate.Text.Trim());
        if (begin >= end)
        {
            JscriptMsg("开始时间必须小于结束时间", "back", "Error");
            return;
        }
        #endregion

        #region 赋值
        Cms.Model.wx_ggkActionInfo ggk = new Cms.Model.wx_ggkActionInfo();
        Cms.Model.wx_requestRule rule = new Cms.Model.wx_requestRule();

        string beginPic = imgbeginPic.ImageUrl;
        if (txtImgUrl.Text.Trim() != "")
        {
            beginPic = txtImgUrl.Text.Trim();
        }
        string endPic = imgEndPic.ImageUrl;
        if (txtEndPic.Text.Trim() != "")
        {
            endPic = txtEndPic.Text.Trim();
        }

        if (id > 0)
        {
            ggk = ggkBll.GetModel(id);
        }

        ggk.actName = txtactName.Text.Trim();
        ggk.contractInfo = txtcontractInfo.Text.Trim();
        ggk.brief = txtbrief.Value.Trim();
        ggk.beginDate = begin;
        ggk.endDate = end;
        ggk.actContent = txtactContent.Value.Trim();
        ggk.cfcjhf = txtcfcjhf.Text.Trim();
        ggk.endNotice = txtendNotice.Text.Trim();
        ggk.endContent = txtendContent.Text.Trim();
        ggk.djPwd = txtdjPwd.Text.Trim();

        ggk.beginPic = beginPic;
        ggk.endPic = endPic;
        ggk.personNum = MyCommFun.Str2Int(txtpersonNum.Text);
        ggk.personMaxTimes = MyCommFun.Str2Int(txtpersonMaxTimes.Text);
        ggk.dayMaxTimes = MyCommFun.Str2Int(txtdayMaxTimes.Text);

        #endregion

        if (id <= 0)
        {  //新增
            ggk.wid = 1;
            ggk.createDate = DateTime.Now;
            //1新增主表
            id = ggkBll.Add(ggk);

            //2新增奖项表
            EditAwardItem(id);
            //3 新增回复规则表
            AddRule(1, id);
           adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加刮刮卡活动，主键为" + id); //记录日志
            JscriptMsg("添加刮刮卡活动成功！", "ggklist.aspx", "Success");
        }
        else
        {   //修改
            //1修改主表
            ggkBll.Update(ggk);
            //2删除，且新增奖项表
            EditAwardItem(id);
            //3 修改回复规则表
            IList<Cms.Model.wx_requestRule> rlist = rBll.GetModelList("modelFunctionName = '刮刮卡' and modelFunctionId=" + id);

            if (rlist != null && rlist.Count > 0)
            {
                rule = rlist[0];
                rule.reqKeywords = txtKW.Text.Trim();
                rBll.Update(rule);
            }
            else
            {
                AddRule(1, id);
            }

           adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改刮刮卡活动，主键为" + id); //记录日志
            JscriptMsg("修改刮刮卡活动成功！", "ggklist.aspx", "Success");
        }

    }

    /// <summary>
    /// 添加回复规则
    /// </summary>
    /// <param name="wid"></param>
    /// <param name="modelId"></param>
    private void AddRule(int wid, int modelId)
    {
        rBll.AddModeltxtPicRule(wid, "刮刮卡", modelId, txtKW.Text.Trim());
    }


    /// <summary>
    /// 添加奖品项目
    /// </summary>
    private void EditAwardItem(int ggkId)
    {
        //1删除原来的，2新增
        iBll.DeleteByActId(ggkId);
        Cms.Model.wx_ggkAwardItem item = new Cms.Model.wx_ggkAwardItem();
        TextBox txtJXName;
        TextBox txtJPName;
        TextBox txtNum;
        TextBox txtRealNum;
        int sort_id = 0;
        for (int i = 1; i <= 6; i++)
        {
            txtJXName = this.FindControl("txt" + i + "JXName") as TextBox;
            txtJPName = this.FindControl("txt" + i + "JPName") as TextBox;
            txtNum = this.FindControl("txt" + i + "Num") as TextBox;
            txtRealNum = this.FindControl("txt" + i + "RealNum") as TextBox;

            if (txtJXName.Text.Trim() != "" && txtJPName.Text.Trim() != "" && txtNum.Text.Trim() != "" && txtRealNum.Text.Trim() != "" && MyCommFun.isNumber(txtNum.Text) && MyCommFun.isNumber(txtRealNum.Text))
            {
                sort_id++;
                //那么添加奖品信息 
                item.jxName = txtJXName.Text.Trim();
                item.sort_id = sort_id;
                item.jpName = txtJPName.Text.Trim();
                item.jpNum = MyCommFun.Str2Int(txtNum.Text.Trim());
                item.jpRealNum = MyCommFun.Str2Int(txtRealNum.Text.Trim());
                item.actId = ggkId;
                item.createDate = DateTime.Now;
                iBll.Add(item);
            }

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