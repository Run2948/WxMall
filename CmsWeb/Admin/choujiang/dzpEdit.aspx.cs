using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using Cms.BLL;

public partial class Admin_choujiang_dzpEdit : System.Web.UI.Page
{
    private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型

    wx_dzpActionInfo dzpBll = new wx_dzpActionInfo();
    wx_dzpAwardItem iBll = new wx_dzpAwardItem();
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
            if (!dzpBll.Exists(id))
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
        Cms.Model.wx_dzpActionInfo dzpAction = dzpBll.GetModel(id);
        IList<Cms.Model.wx_dzpAwardItem> aItemlist = iBll.GetModelList("actId=" + id);
        Cms.Model.wx_requestRule rule = rBll.GetModelList("modelFunctionName='大转盘' and modelFunctionId=" + id)[0];
        txtKW.Text = rule.reqKeywords;

        if (dzpAction.beginPic != null && dzpAction.beginPic.Trim() != "/weixin/dzp/images/start.jpg")
        {
            txtImgUrl.Text = dzpAction.beginPic;
            imgbeginPic.ImageUrl = dzpAction.beginPic;
        }
        txtactName.Text = dzpAction.actName;
        txtcontractInfo.Text = dzpAction.contractInfo;
        txtbrief.Value = dzpAction.brief;
        txtbeginDate.Text = dzpAction.beginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
        txtendDate.Text = dzpAction.endDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
        txtactContent.Value = dzpAction.actContent;
        txtcfcjhf.Text = dzpAction.cfcjhf;
        this.txtdjPwd.Text = dzpAction.djPwd;
        //结束
        if (dzpAction.endPic != null && dzpAction.endPic.Trim() != "/weixin/dzp/images/end.jpg")
        {
            txtEndPic.Text = dzpAction.endPic;
            imgEndPic.ImageUrl = dzpAction.endPic;
        }
        txtendNotice.Text = dzpAction.endNotice;
        txtendContent.Text = dzpAction.endContent;

        //奖项基本信息
        txtpersonNum.Text = MyCommFun.ObjToStr(dzpAction.personNum);
        txtpersonMaxTimes.Text = MyCommFun.ObjToStr(dzpAction.personMaxTimes);
        txtdayMaxTimes.Text = MyCommFun.ObjToStr(dzpAction.dayMaxTimes);


        //绑定奖项信息
        IList<Cms.Model.wx_dzpAwardItem> itemlist = iBll.GetModelList("actId=" + id + " order by sort_id asc");
        if (itemlist != null && itemlist.Count > 0)
        {
            int count = itemlist.Count;
            TextBox txtJXName;
            TextBox txtJPName;
            TextBox txtNum;
            TextBox txtRealNum;
            Cms.Model.wx_dzpAwardItem itemEntity = new Cms.Model.wx_dzpAwardItem();
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
        ////Cms.Model.C_user weixin = GetWeiXinCode();

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
        if (txt2JXName.Text.Trim().Length == 0 || txt2JPName.Text.Trim().Length == 0 || txt2Num.Text.Trim().Length == 0 || txt2RealNum.Text.Trim().Length == 0)
        {
            strErr += "第二个奖项不能为空！";
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
        Cms.Model.wx_dzpActionInfo dzp = new Cms.Model.wx_dzpActionInfo();
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
            dzp = dzpBll.GetModel(id);
        }

        dzp.actName = txtactName.Text.Trim();
        dzp.contractInfo = txtcontractInfo.Text.Trim();
        dzp.brief = txtbrief.Value.Trim();
        dzp.beginDate = begin;
        dzp.endDate = end;
        dzp.actContent = txtactContent.Value.Trim();
        dzp.cfcjhf = txtcfcjhf.Text.Trim();
        dzp.endNotice = txtendNotice.Text.Trim();
        dzp.endContent = txtendContent.Text.Trim();
        dzp.djPwd = txtdjPwd.Text.Trim();

        dzp.beginPic = beginPic;
        dzp.endPic = endPic;
        dzp.personNum = MyCommFun.Str2Int(txtpersonNum.Text);
        dzp.personMaxTimes = MyCommFun.Str2Int(txtpersonMaxTimes.Text);
        dzp.dayMaxTimes = MyCommFun.Str2Int(txtdayMaxTimes.Text);

        #endregion

        if (id <= 0)
        {  //新增
            dzp.wid =1;
            dzp.createDate = DateTime.Now;
            //1新增主表
            id = dzpBll.Add(dzp);

            //2新增奖项表
            EditAwardItem(id);
            //3 新增回复规则表
            AddRule(1, id);
           adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加大转盘活动，主键为" + id); //记录日志
            JscriptMsg("添加大转盘活动成功！", "dzplist.aspx", "Success");
        }
        else
        {   //修改
            //1修改主表
            dzpBll.Update(dzp);
            //2删除，且新增奖项表
            EditAwardItem(id);
            //3 修改回复规则表
            IList<Cms.Model.wx_requestRule> rlist = rBll.GetModelList("modelFunctionName = '大转盘' and modelFunctionId=" + id);

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

           adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改大转盘活动，主键为" + id); //记录日志
            JscriptMsg("修改大转盘活动成功！", "dzplist.aspx", "Success");
        }

    }

    /// <summary>
    /// 添加回复规则
    /// </summary>
    /// <param name="wid"></param>
    /// <param name="modelId"></param>
    private void AddRule(int wid, int modelId)
    {
        rBll.AddModeltxtPicRule(wid, "大转盘", modelId, txtKW.Text.Trim());
    }


    /// <summary>
    /// 添加奖品项目
    /// </summary>
    private void EditAwardItem(int dzpId)
    {
        //1删除原来的，2新增
        iBll.DeleteByActId(dzpId);
        Cms.Model.wx_dzpAwardItem item = new Cms.Model.wx_dzpAwardItem();
        TextBox txtJXName;
        TextBox txtJPName;
        TextBox txtNum;
        TextBox txtRealNum;
        int sort_id = 0;

        int totJxNum = 0; //一共有多少奖项
        for (int i = 1; i <= 6; i++)
        {
            txtJXName = this.FindControl("txt" + i + "JXName") as TextBox;
            txtJPName = this.FindControl("txt" + i + "JPName") as TextBox;
            txtNum = this.FindControl("txt" + i + "Num") as TextBox;
            txtRealNum = this.FindControl("txt" + i + "RealNum") as TextBox;
            if (txtJXName.Text.Trim() != "" && txtJPName.Text.Trim() != "" && txtNum.Text.Trim() != "" && txtRealNum.Text.Trim() != "" && MyCommFun.isNumber(txtNum.Text) && MyCommFun.isNumber(txtRealNum.Text))
            {
                totJxNum++;
            }
        }

        //计算每个奖项的角度值
        decimal avgDeg = (decimal)360.0 / (totJxNum + 1);

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
                item.actId = dzpId;
                item.createDate = DateTime.Now;
                item.jiaodu_min = avgDeg * sort_id;
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