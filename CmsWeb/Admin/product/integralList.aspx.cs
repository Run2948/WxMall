using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Cms.DBUtility;
using Cms.Common;
using System.Text;
using System.Data.OleDb;


public partial class Admin_product_integralList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;
            setqx();
            string where = "select * from C_integral_product order by id desc,sortId desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = new Cms.BLL.C_integral_product().GetRecordCount("");
            this.RepeaterDataBind(where);

        }
    }

    #region 保存排序=================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Repeater rptList = new Repeater();
        rptList = this.rptList1;
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("Fielddocid")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_integral_product set sortId=" + sortId + " where id='" + id + "'");//修改
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), new Cms.BLL.C_integral_product().GetModel(id).name + "排序"); //记录日志
        }

        JscriptMsg("保存排序成功！", "integralList.aspx", "Success");
    }
    #endregion

    #region 数据读取==================================
    public void RepeaterDataBind(string whereStr)
    {
        SqlDataAdapter dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        DataSet ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_integral_product");
        this.rptList1.DataSource = ds.Tables["C_integral_product"];
        this.rptList1.DataBind();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_integral_product order by id desc,sortId desc";
        this.RepeaterDataBind(where.ToString());

    }

    public void rptList2_Bind(int strparentId)
    {
        DataSet ds = new Cms.BLL.C_integral_product().GetList("");
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.rptList1.DataSource = ds;
            this.rptList1.DataBind();
        }
    }
    //设置文字列表显示
    protected void lbtnViewTxt_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("article_list_view", "Txt", 14400);
        Response.Redirect("integralList.aspx");

    }

    //设置图文列表显示
    protected void lbtnViewImg_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("article_list_view", "Img", 14400);
        Response.Redirect("integralList.aspx");

    }


    #endregion

    #region 批量删除=============================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Repeater rptList = new Repeater();
        rptList = this.rptList1;
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("Fielddocid") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                string title = new Cms.BLL.C_integral_product().GetModel(id).name.ToString();
                new Cms.BLL.C_product().Delete(id);
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除：产品信息" + title); //记录日志
            }
        }
        JscriptMsg("删除信息成功！", "list.aspx", "Success");
    }
    #endregion

    #region 提示框=================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 搜索操作======================================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr = "select * from C_integral_product where name like '%" + Keywords + "%' order by id desc";
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    #region 列表设置操作==============================================================
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("Fielddocid")).Value);
        Cms.Model.C_integral_product model = new Cms.BLL.C_integral_product().GetModel(id);
        LinkButton lb = (LinkButton)e.Item.FindControl("lbedit");
        switch (e.CommandName)
        {
            case "lbtnIsMsg":
                if (model.isActive == 1)
                    this.updateSate(id, "isActive=0");
                else
                    this.updateSate(id, "isActive=1");
                break;
            case "lbtnIsTop":
                if (model.isTop == 1)
                    this.updateSate(id, "isTop=0");
                else
                    this.updateSate(id, "isTop=1");
                break;
            case "lbtnIsRed":
                if (model.isRecommend == 1)
                    this.updateSate(id, "isRecommend=0");
                else
                    this.updateSate(id, "isRecommend=1");
                break;
            case "lbtnIsHot":
                if (model.isHot == 1)
                    this.updateSate(id, "isHot=0");
                else
                    this.updateSate(id, "isHot=1");
                break;
            case "lbtnIsSlide":
                if (model.isHidden == 1)
                    this.updateSate(id, "isHidden=0");
                else
                    this.updateSate(id, "isHidden=1");
                break;
        }
    }
    public void updateSate(int id, string state)
    {
        int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_integral_product set " + state + " where id='" + id + "'");//修改
        JscriptMsg("修改成功！", "list.aspx", "Success");
    }
    #endregion



    #region 新增操作=========================
    protected void btnadd_Click(object sender, EventArgs e)
    {

        Response.Redirect("integralEdit.aspx?action=add");
    }
    #endregion

    #region 设置权限=============================================
    /// <summary>
    /// 设置权限
    /// </summary>
    public void setqx()
    {
        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classname = cm.GetModel(int.Parse("1")).className;
        bool bladd = adminUser.setpurview(classname, "add");
        bool blEdit = adminUser.setpurview(classname, "Edit");
        bool blDelete = adminUser.setpurview(classname, "Delete");

        if (!bladd)
        {
            btnadd.Visible = false;
        }
        if (!blEdit)
        {
            btnSave.Visible = false;
        }
        if (!blDelete)
        {
            btnDelete.Visible = false;
        }
    }
    #endregion

    #region 修改操作==================
    /// <summary>
    /// 修改操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        string cid = e.CommandArgument.ToString();
        string pid = e.CommandName.ToString();
        Response.Redirect("integralEdit.aspx?action=edit&id=" + cid + "");
    }
    #endregion

    
}