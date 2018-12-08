using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Text;

public partial class Admin_settings_attribute_field_edit : System.Web.UI.Page
{
    private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
    private int id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = DTRequest.GetQueryString("action");

        if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
        {
            this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
            this.id = DTRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new Cms.BLL.C_article_attribute_field().Exists(this.id))
            {
                JscriptMsg("记录不存在或已被删除！", "back", "Error");
                return;
            }
        }
        if (!Page.IsPostBack)
        {
           
            dlIsPassWord.Visible = dlIsHtml.Visible = dlEditorType.Visible = dlDataType.Visible
                = dlDataLength.Visible = dlDataPlace.Visible = dlItemOption.Visible = false; //隐藏相应控件
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ddlControlType.Enabled = false;
                ShowInfo(this.id);
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        Cms.BLL.C_article_attribute_field bll = new Cms.BLL.C_article_attribute_field();
        Cms.Model.C_article_attribute_field model = bll.GetModel(_id);

        txtName.Enabled = false;
        txtName.Attributes.Remove("ajaxurl");
        txtName.Attributes.Remove("datatype");
        ddlControlType.SelectedValue = model.control_type;
        showControlHtml(model.control_type); //显示对应的HTML
        txtSortId.Text = model.sort_id.ToString();
        txtName.Text = model.name;
        txtTitle.Text = model.title;
        if (model.is_required == 1)
        {
            cbIsRequired.Checked = true;
        }
        else
        {
            cbIsRequired.Checked = false;
        }
        if (model.is_password == 1)
        {
            cbIsPassword.Checked = true;
        }
        else
        {
            cbIsPassword.Checked = false;
        }
        if (model.is_html == 1)
        {
            cbIsHtml.Checked = true;
        }
        else
        {
            cbIsHtml.Checked = false;
        }
        rblEditorType.SelectedValue = model.editor_type.ToString();
        rblDataType.SelectedValue = model.data_type;
        txtDataLength.Text = model.data_length.ToString();
        ddlDataPlace.SelectedValue = model.data_place.ToString();
        txtItemOption.Text = model.item_option;
        txtDefaultValue.Text = model.default_value;
        txtValidPattern.Text = model.valid_pattern;
        txtValidTipMsg.Text = model.valid_tip_msg;
        txtValidErrorMsg.Text = model.valid_error_msg;
        if (model.is_sys == 1)
        {
            ddlControlType.Enabled = false;
        }

    }
    #endregion

    #region 显示对应的控件===========================
    private void showControlHtml(string control_type)
    {
        dlIsPassWord.Visible = dlIsHtml.Visible = dlEditorType.Visible = dlDataType.Visible
                = dlDataLength.Visible = dlDataPlace.Visible = dlItemOption.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = false; //隐藏相应控件
        switch (control_type)
        {
            case "single-text": //单行文本
                dlIsPassWord.Visible = dlDataLength.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                break;
            case "multi-text": //多行文本
                dlIsHtml.Visible = dlDataLength.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                break;
            case "editor": //编辑器
                dlEditorType.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                break;
            case "images": //图片上传
                dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                break;
            case "number": //数字
                dlDataPlace.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                break;
            case "checkbox": //复选框
                break;
            case "multi-radio": //多项单选
                dlDataType.Visible = dlDataLength.Visible = dlItemOption.Visible = true;
                break;
            case "multi-checkbox": //多项多选
                dlDataLength.Visible = dlItemOption.Visible = true;
                break;
        }

    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        bool result = false;
        Cms.Model.C_article_attribute_field model = new Cms.Model.C_article_attribute_field();
        Cms.BLL.C_article_attribute_field bll = new Cms.BLL.C_article_attribute_field();

        model.control_type = ddlControlType.SelectedValue;
        model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
        model.name = txtName.Text.Trim();
        model.title = txtTitle.Text;
        if (cbIsRequired.Checked == true)
        {
            model.is_required = 1;
        }
        else
        {
            model.is_required = 0;
        }
        if (cbIsPassword.Checked == true)
        {
            model.is_password = 1;
        }
        else
        {
            model.is_password = 0;
        }
        if (cbIsHtml.Checked == true)
        {
            model.is_html = 1;
        }
        else
        {
            model.is_html = 0;
        }
        model.editor_type = Utils.StrToInt(rblEditorType.SelectedValue, 0);
        model.data_length = Utils.StrToInt(txtDataLength.Text.Trim(), 0);
        model.data_place = Utils.StrToInt(ddlDataPlace.SelectedValue, 0);
        model.data_type = rblDataType.SelectedValue;
        model.item_option = txtItemOption.Text.Trim();
        model.default_value = txtDefaultValue.Text.Trim();
        model.valid_pattern = txtValidPattern.Text.Trim();
        model.valid_tip_msg = txtValidTipMsg.Text.Trim();
        model.valid_error_msg = txtValidErrorMsg.Text.Trim();

        if (bll.Add(model) > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加扩展字段:" + model.title); //记录日志
            result = true;
        }
        return result;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;
        Cms.BLL.C_article_attribute_field bll = new Cms.BLL.C_article_attribute_field();
        Cms.Model.C_article_attribute_field model = bll.GetModel(_id);

        if (model.is_sys == 0)
        {
            model.control_type = ddlControlType.SelectedValue;
            model.data_length = Utils.StrToInt(txtDataLength.Text.Trim(), 0);
            model.data_place = Utils.StrToInt(ddlDataPlace.SelectedValue, 0);
            model.data_type = rblDataType.SelectedValue;
        }
        model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
        model.title = txtTitle.Text;
        if (cbIsRequired.Checked == true)
        {
            model.is_required = 1;
        }
        else
        {
            model.is_required = 0;
        }
        if (cbIsPassword.Checked == true)
        {
            model.is_password = 1;
        }
        else
        {
            model.is_password = 0;
        }
        if (cbIsHtml.Checked == true)
        {
            model.is_html = 1;
        }
        else
        {
            model.is_html = 0;
        }
        model.editor_type = Utils.StrToInt(rblEditorType.SelectedValue, 0);
        model.item_option = txtItemOption.Text.Trim();
        model.default_value = txtDefaultValue.Text.Trim();
        model.valid_pattern = txtValidPattern.Text.Trim();
        model.valid_tip_msg = txtValidTipMsg.Text.Trim();
        model.valid_error_msg = txtValidErrorMsg.Text.Trim();

        if (bll.Update(model))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "修改扩展字段:" + model.title); //记录日志
            result = true;
        }

        return result;
    }
    #endregion

    //根据选择的控件类型显示相应部分
    protected void ddlControlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        showControlHtml(ddlControlType.SelectedValue);
    }

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
        {
           
            if (!DoEdit(this.id))
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("修改扩展字段成功！", "attribute_field_list.aspx", "Success");
        }
        else //添加
        {
           
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("添加扩展字段成功！", "attribute_field_list.aspx", "Success");
        }
    }
    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}