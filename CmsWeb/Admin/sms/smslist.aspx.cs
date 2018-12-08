using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Cms.DBUtility;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using Cms.Common;
public partial class Admin_sms_smslist : System.Web.UI.Page
{
    public string classid = "";
    Cms.BLL.C_sms bllorder = new Cms.BLL.C_sms();
    public DataSet ds;
    public SqlDataAdapter dr;
    private ExportExcel excel = new ExportExcel();
    private int excelRows = 0;
    private int excelColumns;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
            string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
            classid = strparentId;//


            string where = "select * from C_sms  order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bllorder.GetRecordCount("");
            this.RepeaterDataBind(where);

            int id = Convert.ToInt32(this.Request.QueryString["orderid"] ?? "0");//订单ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                

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

    #region 数据读取====================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_sms");
        this.rptList.DataSource = ds.Tables["C_sms"];
        this.rptList.DataBind();


    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_sms order by id desc";
        this.RepeaterDataBind(where.ToString());

    }

    #endregion

    #region 删除================================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("Fielddocid") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), bllorder.GetModel(id).telphone); //记录日志
                bllorder.Delete(id);
            }
        }
        JscriptMsg("删除信息成功！", "smslist.aspx", "Success");
    }
    #endregion

    #region 搜索==============================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
        classid = strparentId;//
        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr = "select * from C_sms where name like '%" + Keywords + "%' order by id desc";
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    

   
}