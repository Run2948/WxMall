using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;

public partial class Admin_settings_oauth_app_edit : System.Web.UI.Page
{
    private string action = "add"; //操作类型
    private int id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = DTRequest.GetQueryString("action");

        if (!string.IsNullOrEmpty(_action) && _action == "edit")
        {
            this.action = "edit";//修改类型
            this.id = DTRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new Cms.BLL.C_user_oauth_app().Exists(this.id))
            {
                JscriptMsg("记录不存在或已被删除！", "back", "Error");
                return;
            }
        }
        if (!Page.IsPostBack)
        {
          
            if (action =="edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        Cms.BLL.C_user_oauth_app bll = new Cms.BLL.C_user_oauth_app();
        Cms.Model.C_user_oauth_app model = bll.GetModel(_id);
        txtTitle.Text = model.title;
        if (model.is_lock == 0)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }
        txtSortId.Text = model.sort_id.ToString();
        txtApiPath.Text = model.api_path;
        txtAppId.Text = model.app_id;
        txtAppKey.Text = model.app_key;
        txtImgUrl.Value = model.img_url;
        txtRemark.Text = model.remark;
    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        bool result = false;
        Cms.Model.C_user_oauth_app model = new Cms.Model.C_user_oauth_app();
        Cms.BLL.C_user_oauth_app bll = new Cms.BLL.C_user_oauth_app();

        model.title = txtTitle.Text.Trim();
        if (cbIsLock.Checked == true)
        {
            model.is_lock = 0;
        }
        else
        {
            model.is_lock = 1;
        }
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        model.api_path = txtApiPath.Text.Trim();
        model.app_id = txtAppId.Text.Trim();
        model.app_key = txtAppKey.Text.Trim();
        model.img_url = txtImgUrl.Value.Trim();
        model.remark = txtRemark.Text;
        if (bll.Add(model) > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), model.title); //记录日志
            result = true;
        }
        return result;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;
        Cms.BLL.C_user_oauth_app bll = new Cms.BLL.C_user_oauth_app();
        Cms.Model.C_user_oauth_app model = bll.GetModel(_id);

        model.title = txtTitle.Text.Trim();
        if (cbIsLock.Checked == true)
        {
            model.is_lock = 0;
        }
        else
        {
            model.is_lock = 1;
        }
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        model.api_path = txtApiPath.Text.Trim();
        model.app_id = txtAppId.Text.Trim();
        model.app_key = txtAppKey.Text.Trim();
        model.img_url = txtImgUrl.Value.Trim();
        model.remark = txtRemark.Text;
        if (bll.Update(model))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.title); //记录日志
            result = true;
        }

        return result;
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "edit") //修改
        {
         
            if (!DoEdit(this.id))
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("修改OAuth应用成功！", "oauth_app_list.aspx", "Success");
        }
        else //添加
        {
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("添加OAuth应用成功！", "oauth_app_list.aspx", "Success");
        }
    }

    #region 提示框=======================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}