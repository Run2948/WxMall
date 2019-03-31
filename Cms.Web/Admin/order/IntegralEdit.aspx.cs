using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_order_IntegralEdit : System.Web.UI.Page
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
            }
            else if (Session["adminname"] != null)
            {
                Application["adminname"] = (string)Session["adminname"];
            }
            int id = Convert.ToInt32(this.Request.QueryString["orderid"] ?? "0");//订单ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    this.bind_date(id);// 赋值操作信息
                    break;
            }
        }
    }
    #region 订单读取===================================
    public void bind_date(int _id)
    {
        Cms.BLL.C_order_integral bll = new Cms.BLL.C_order_integral();
        Cms.Model.C_order_integral model = bll.GetModel(_id);
        ordernum.InnerHtml = model.order_num;
        updateTime.InnerHtml = model.updateTime.ToString();
        OrderStatus.InnerHtml =getState(Convert.ToInt32(model.order_status));
      
        countprice.InnerHtml = model.price_sum.ToString();
        Quantity.InnerHtml = model.quantity_sum.ToString();
       
       
        integral_sum.InnerHtml = model.integral_sum.ToString();
      
        note.InnerHtml = model.note.ToString();
        recommended_code.InnerHtml = model.recommended_code.ToString();
        #region 会员信息=====================
        int struserid = Convert.ToInt32(model.user_id);
        Cms.BLL.C_user blluser = new Cms.BLL.C_user();
        DataSet ds2 = blluser.GetList("id=" + struserid);
        if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
        {

            UserName.InnerHtml = ds2.Tables[0].Rows[0]["username"].ToString();
            userMoney.InnerHtml = Convert.ToDecimal(ds2.Tables[0].Rows[0]["userMoney"]).ToString("0.00");
            userJifen.InnerHtml = ds2.Tables[0].Rows[0]["userscore"].ToString();
        }
        else
        {
            userinfo.InnerHtml = "匿名用户";
        }
        #endregion

        #region 产品信息===========================
        Cms.BLL.C_order_integralsub bllordersub = new Cms.BLL.C_order_integralsub();
        DataSet ds1 = bllordersub.GetList("order_id=" + _id);
        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            Repeaterordersub.DataSource = ds1.Tables[0].DefaultView;
            Repeaterordersub.DataBind();
        }
        #endregion

        #region 收货信息===========================

        DataSet ds3 = new Cms.BLL.sc_stores().GetList("id=" + model.storesId);
        if (ds3 != null && ds3.Tables[0].Rows.Count > 0)
        {
            RepAddress.DataSource = ds3.Tables[0].DefaultView;
            RepAddress.DataBind();
        }
        #endregion

    }
    public string getState(int order_state)
    {
        string result = "";
        switch (order_state)
        {
            case 0:
                result = "未预约";
                break;
            case 1:
                result = "已预约";
                break;
            case 2:
                result = "已领取";
                break;
        }

        return result;
    }
    #endregion

    #region 增加操作=================================
    private bool DataAdd()
    {

        //Cms.BLL.C_admin bll = new Cms.BLL.C_admin();
        //Cms.Model.C_admin model = new Cms.Model.C_admin();
        //model.role_id = int.Parse(ddlRoleId.SelectedValue);
        //model.role_type = Convert.ToInt32(ddlRoleId.SelectedValue);
        //if (cbIsLock.Checked == true)
        //{
        //    model.is_lock = 0;
        //}
        //else
        //{
        //    model.is_lock = 1;
        //}
        ////检测用户名是否重复
        //if (bll.Exists(txtUserName.Text.Trim()))
        //{
        //    return false;
        //}
        //model.user_name = txtUserName.Text.Trim();

        //model.password = txtPassword.Text.Trim();
        //model.real_name = txtRealName.Text.Trim();
        //model.telephone = txtTelephone.Text.Trim();
        //model.email = txtEmail.Text.Trim();
        //model.add_time = DateTime.Now;

        //if (bll.Add(model) > 0)
        //{
        //    //写入登录日志
        //    Cms.Model.C_admin_log adminlog = new Cms.Model.C_admin_log();
        //    Cms.BLL.C_admin_log adminlogdal = new Cms.BLL.C_admin_log();
        //    adminlog.user_id = Convert.ToInt32((string)Session["adminid"]);//用户名角色ID
        //    adminlog.user_name = (string)Session["adminname"];//用户名
        //    adminlog.user_ip = Cms.Common.ManagementInfo.GetIP();//ip地址
        //    adminlog.action_type = "Add";
        //    adminlog.action_type = "添加管理员信息" + this.txtUserName.Text.Trim();
        //    adminlog.add_time = Convert.ToDateTime(Cms.Common.ManagementInfo.GetTime());//时间
        //    adminlogdal.Add(adminlog);

        //    JscriptMsg("添加信息成功！", "manager_edit.aspx", "Success");
        //    return true;
        //}
        //else
        //{
        //    JscriptMsg("添加信息失败！", "manager_edit.aspx?action=add", "Error");
        //    return false;
        //}
        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DataUpdate(int _id)
    {
        //bool result = false;
        //Cms.BLL.C_admin bll = new Cms.BLL.C_admin();
        //Cms.Model.C_admin model = new Cms.Model.C_admin();
        //model.id = _id;
        //model.role_id = int.Parse(ddlRoleId.SelectedValue);
        //model.role_type = Convert.ToInt32(ddlRoleId.SelectedValue);
        //if (cbIsLock.Checked == true)
        //{
        //    model.is_lock = 0;
        //}
        //else
        //{
        //    model.is_lock = 1;
        //}
        ////检测用户名是否重复
        //if (bll.Exists(txtUserName.Text.Trim()))
        //{
        //    return false;
        //}
        //model.user_name = txtUserName.Text.Trim();

        //model.password = txtPassword.Text.Trim();
        //model.real_name = txtRealName.Text.Trim();
        //model.telephone = txtTelephone.Text.Trim();
        //model.email = txtEmail.Text.Trim();
        //model.add_time = DateTime.Now;

        //if (bll.Update(model))
        //{
        //    //写入登录日志
        //    Cms.Model.C_admin_log adminlog = new Cms.Model.C_admin_log();
        //    Cms.BLL.C_admin_log adminlogdal = new Cms.BLL.C_admin_log();
        //    adminlog.user_id = Convert.ToInt32((string)Session["adminid"]);//用户名角色ID
        //    adminlog.user_name = (string)Session["adminname"];//用户名
        //    adminlog.user_ip = Cms.Common.ManagementInfo.GetIP();//ip地址
        //    adminlog.action_type = "Edit";
        //    adminlog.action_type = "修改管理员信息" + this.txtUserName.Text.Trim();
        //    adminlog.add_time = Convert.ToDateTime(Cms.Common.ManagementInfo.GetTime());//时间
        //    adminlogdal.Add(adminlog);

        //    JscriptMsg("修改信息成功！", "manager_edit.aspx", "Success");
        //    return true;
        //}
        //else
        //{
        //    JscriptMsg("修改信息失败！", "manager_edit.aspx?action=add", "Error");
        //    return false;
        //}

        return false;
    }
    #endregion

    #region 保存======================================
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

    #region 提示框===============================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}