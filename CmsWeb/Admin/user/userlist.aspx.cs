using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Cms.DBUtility;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using Cms.Common;
public partial class Admin_user_userlist : System.Web.UI.Page
{
    public string classid = "";
    Cms.BLL.C_user blluser = new Cms.BLL.C_user();
    public DataSet ds;
    public SqlDataAdapter dr;
    
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!Page.IsPostBack)
        {

            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;

            string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
            classid = strparentId;//


            string where = "select * from C_user  order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = blluser.GetRecordCount("");
            this.RepeaterDataBind(where);

            int user_id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//订单ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "UpdateUser":
                    this.UpdateUser(user_id);// 赋值操作信息
                    break;

            }
        }
    }

    public void setqx()
    {
        bool blDelete = adminUser.setpurview("会员列表", "Delete");
        if (!blDelete)
        {
            btnDelete.Visible = false;
        }
    }
    #region 数据读取===================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_user");
        this.rptList.DataSource = ds.Tables["C_user"];
        this.rptList.DataBind();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int classid = Convert.ToInt32(this.Request.QueryString["parentId"] ?? "0");//栏目ID
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
		string Keywords = this.txtKeywords.Text.Trim();
		string strWhere="";
		if(Keywords!=""&&Keywords!=null)
		{
		strWhere="where telphone like '%"+Keywords+"%'";
		}
        string where = "select * from C_user "+strWhere+" order by id desc";
        
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
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), blluser.GetModel(id).username); //记录日志
                blluser.Delete(id);
            }
        }
        JscriptMsg("删除信息成功！", "userlist.aspx", "Success");
    }
    #endregion

    #region 提示框================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 搜索===============================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
        classid = strparentId;//
        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr = "select * from C_user where telphone like '%"+Keywords+"%' order by id desc";
		 string where = "select * from C_user  order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = blluser.GetRecordCount("");
            this.RepeaterDataBind(where);
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    #region 同步会员CRM======================
    public void UpdateUser(int user_id)
    {
        Cms.Model.C_user muser = new Cms.BLL.C_user().GetModel(user_id);
        //设置更新会员
        wxuser.UserSale wu = new wxuser.UserSale();
        wxuser.userinfo xw = new wxuser.userinfo();
        xw = wxuser.getuserinfo(muser.openid);
        if (xw.result == "获取失败")
        {
            wu = wxuser.getUserRegister(muser.openid, muser.username, muser.sex, muser.useraddress, string.Format("{0:yyyy-MM-dd}", muser.birthday), string.Format("{0:yyyy-MM-dd}", muser.marryday), muser.telphone, muser.shopcode);
            //Literal1.Text = wu.content + "-" + wu.result + "-" + wu.usercard;
            xw = wxuser.getuserinfo(muser.openid);
            string UpdateSql = "update C_user set usercard='" + xw.usercard + "' where id=" + user_id;
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql(UpdateSql);//修改
            if (counts > 0)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), muser.username); //记录日志
                JscriptMsg("绑定成功！", "userlist.aspx", "Success");
            }
            else
            {
                JscriptMsg("绑定失败！", "userlist.aspx", "Success");
            }
        }
        else
        {
            string UpdateSql = "update C_user set usercard='" + xw.usercard + "' where id=" + user_id;
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql(UpdateSql);//修改
            if (counts > 0)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), muser.username); //记录日志
                JscriptMsg("绑定成功！", "userlist.aspx", "Success");
            }
            else
            {
                JscriptMsg("绑定失败！", "userlist.aspx", "Success");
            }
        }
      
       
    }
    #endregion

  
}