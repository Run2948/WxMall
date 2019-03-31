using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Common;

public partial class Admin_manager_manager_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //登录验证
            adminUser.GetLoginState();

            //登录信息
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];

            if (cookie != null)
            {
                Application["adminname"] = (string)cookie.Values["adminname"];
                Application["adminType"] = (string)cookie.Values["adminType"];
            }
            else if (Session["adminname"] != null)
            {
                Application["adminname"] = (string)Session["adminname"];
                Application["adminType"] = (string)Session["adminType"];
            }
            DropList_Bind();//绑定角色=================================
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID=================================
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add=================================
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    this.bind_date(id);// 赋值操作信息=================================
                    break;
            }

        }
    }

    #region 赋值操作信息=================================
    public void bind_date(int _id)
    {
        Cms.BLL.C_admin bll = new Cms.BLL.C_admin();
        Cms.Model.C_admin model = bll.GetModel(_id);
        ddlRoleId.SelectedValue = model.role_id.ToString();
        if (model.is_lock == 0)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }
        txtUserName.Text = model.user_name;

        txtUserName.Attributes.Remove("ajaxurl");

        txtPassword.Text = model.password;
        txtPassword1.Text = model.password;
        txtRealName.Text = model.real_name;
        txtTelephone.Text = model.telephone;
        txtEmail.Text = model.email;
    }
    #endregion

    #region 绑定角色=================================
    public void DropList_Bind()
    {

        ddlRoleId.Items.Clear();

        Cms.BLL.C_admin_role blladmin_role = new Cms.BLL.C_admin_role();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet ds = blladmin_role.GetList("");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                if (Convert.ToInt32(dr["role_type"]) >= Convert.ToInt32(Application["adminType"]))
                {

                    ListItem item = new ListItem();
                    item.Text = "" + dr["role_name"].ToString();
                    item.Value = dr["id"].ToString();
                    ddlRoleId.Items.Add(item);
                }

            }
        }

    }


    #endregion

    #region 增加操作=================================
    private bool DataAdd()
    {

        Cms.BLL.C_admin bll = new Cms.BLL.C_admin();
        Cms.Model.C_admin model = new Cms.Model.C_admin();
        model.role_id = int.Parse(ddlRoleId.SelectedValue);
        model.role_type = new Cms.BLL.C_admin_role().GetModel(model.role_id).role_type;
        if (cbIsLock.Checked == true)
        {
            model.is_lock = 0;
        }
        else
        {
            model.is_lock = 1;
        }
        //检测用户名是否重复
        if (bll.Exists(txtUserName.Text.Trim()))
        {
            return false;
        }
        model.user_name = txtUserName.Text.Trim();

        model.password = txtPassword.Text.Trim();
        model.real_name = txtRealName.Text.Trim();
        model.telephone = txtTelephone.Text.Trim();
        model.email = txtEmail.Text.Trim();
        model.add_time = DateTime.Now;

        if (bll.Add(model) > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), model.user_name); //记录日志

            JscriptMsg("添加信息成功！", "articleList.aspx", "Success");
            return true;
        }
        else
        {
            JscriptMsg("添加信息失败！", "manager_edit.aspx?action=add", "Error");
            return false;
        }

    }
    #endregion

    #region 修改操作=================================
    private bool DataUpdate(int _id)
    {

        Cms.BLL.C_admin bll = new Cms.BLL.C_admin();
        Cms.Model.C_admin model = new Cms.Model.C_admin();
        model.id = _id;
        model.role_id = int.Parse(ddlRoleId.SelectedValue);
        model.role_type = new Cms.BLL.C_admin_role().GetModel(model.role_id).role_type;
        if (cbIsLock.Checked == true)
        {
            model.is_lock = 0;
        }
        else
        {
            model.is_lock = 1;
        }
        ////检测用户名是否重复
        //if (bll.Exists(txtUserName.Text.Trim()))
        //{
        //    return false;
        //}
        model.user_name = txtUserName.Text.Trim();

        model.password = txtPassword.Text.Trim();
        model.real_name = txtRealName.Text.Trim();
        model.telephone = txtTelephone.Text.Trim();
        model.email = txtEmail.Text.Trim();
        model.add_time = DateTime.Now;

        if (bll.Update(model))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.user_name); //记录日志

            JscriptMsg("修改信息成功！", "manager_list.aspx", "Success");
            return true;
        }
        else
        {
            JscriptMsg("修改信息失败！", "manager_edit.aspx?action=add", "Error");
            return false;
        }


    }
    #endregion

    #region 保存========================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//栏目ID
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        switch (action)
        {
            case "add":
                this.DataAdd();
                break;
            case "edit":
                this.DataUpdate(id);
                break;
        }
    }
    #endregion

    #region 提示框==========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}