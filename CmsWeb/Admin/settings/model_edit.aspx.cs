using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;

public partial class Admin_settings_model_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //登录验证
           Cms.Model.C_admin admin= adminUser.GetLoginState();
           Application["adminname"] = admin.user_name;
           
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//文章类别ID=====================
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add========================
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    this.ShowInfo(id);//绑定栏目信息===========================================
                    break;
            }


        }
    }



    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion



    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        Cms.BLL.C_model bll = new Cms.BLL.C_model();
        Cms.Model.C_model model = bll.GetModel(_id);


        txtTitle.Text = model.modelName;

    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
       
        try
        {
            Cms.Model.C_model model = new Cms.Model.C_model();
            Cms.BLL.C_model bll = new Cms.BLL.C_model();

            model.modelName = txtTitle.Text.Trim();
            model.modelValue = txtTitle.Text.Trim();
            if (bll.Add(model) > 0)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "[" + model.modelName + "]"); //记录日志
                return true;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
     
        try
        {
            Cms.BLL.C_model bll = new Cms.BLL.C_model();
            Cms.Model.C_model model = bll.GetModel(_id);
            model.modelName = txtTitle.Text.Trim();
            model.modelValue = txtTitle.Text.Trim();

            if (bll.Update(model))
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "[" + model.modelName + "]"); //记录日志
                return true;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
    #endregion



    #region 保存类别============================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//文章类别ID

        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        switch (action)
        {
            case "add":
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加类别成功！", "model_list.aspx", "Success");
                break;
            case "edit":

                if (!DoEdit(id))
                {

                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改类别成功！", "model_list.aspx", "Success");
                break;
        }

    }
    #endregion
}