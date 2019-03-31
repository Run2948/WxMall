using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using Cms.BLL;


public partial class Admin_wxRule_editTuWen : System.Web.UI.Page
{
    private string action = Enums.ActionEnum.Add.ToString(); //操作类型
    public int rid = 0;
    private int id = 0;
    wx_requestRuleContent rcBll = new wx_requestRuleContent();

    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = DTRequest.GetQueryString("action");
        rid = MyCommFun.RequestInt("rid");
        if (rid == 0)
        {
            JscriptMsg("传输参数不正确！", "back", "Error");
            return;
        }
        if (!string.IsNullOrEmpty(_action) && _action == Enums.ActionEnum.Edit.ToString())
        {
            this.action = Enums.ActionEnum.Edit.ToString();//修改类型
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!rcBll.Exists(this.id))
            {
                JscriptMsg("记录不存在或已被删除！", "back", "Error");
                return;
            }
        }
        if (!Page.IsPostBack)
        {

            //  ChkAdminLevel("manager_list", MXEnums.ActionEnum.View.ToString()); //检查权限

            if (action == Enums.ActionEnum.Edit.ToString()) //修改
            {
                ShowInfo(this.id);
            }
        }
    }



    #region 赋值操作=================================
    private void ShowInfo(int id)
    {
        Cms.Model.wx_requestRuleContent rc = rcBll.GetModel(id);
        txtTitle.Value = rc.rContent;
        txtImgUrl.Text = rc.picUrl;

        txtContent.Value = rc.rContent2;
        txtUrl.Value = rc.detailUrl;
        txtSortId.Text = rc.seq.Value.ToString();

    }

    #endregion



    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Cms.Model.C_admin admin = adminUser.GetLoginState();
        Cms.Model.wx_requestRuleContent rc = new Cms.Model.wx_requestRuleContent();
        if (id != 0)
        {
            rc = rcBll.GetModel(id);
        }
        if (id == 0)
        {
            rc.rId = rid;
            rc.uId = admin.id;
            rc.createDate = DateTime.Now;
        }
        rc.rContent = txtTitle.Value.Trim();
        rc.picUrl = txtImgUrl.Text;
        rc.rContent2 = txtContent.Value.Trim();
        rc.detailUrl = txtUrl.Value.Trim();
        rc.seq = int.Parse(txtSortId.Text.Trim());
        if (id == 0)
        {
            int ret = rcBll.Add(rc);
            if (ret > 0)
            {
                JscriptMsg("修改图文回复内容信息成功！", "tuwenMgr.aspx?rid=" + rid, "Success");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
        }
        else
        {
            bool ret = rcBll.Update(rc);
            if (ret)
            {
                JscriptMsg("添加图文回复内容信息成功！", "tuwenMgr.aspx?rid=" + rid, "Success");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
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