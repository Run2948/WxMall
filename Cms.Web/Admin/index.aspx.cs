using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


public partial class Admin_index : System.Web.UI.Page
{
    #region 加载==========================================
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Admin_index));//注册Ajax可调用的类的名称
        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;
            Application["adminType"] = new Cms.BLL.C_admin_role().GetModel(Convert.ToInt32(admin.role_id)).role_name.ToString();
            
           // string action = this.Request.QueryString["action"] ?? "add";//编辑：edit 添加：add
            string column = this.Request.QueryString["id"] ?? "26";//编辑：edit 添加：add
            bind_RepeaterNav();//加载菜单
            this.files.InnerHtml = ListControl_Bind(Convert.ToInt32(column));//加载栏目
            //switch (action)
            //{
            //    case "add":
            //        this.files.InnerHtml = ListControl_Bind(Convert.ToInt32(column));//加载栏目
            //        break;
            //    case "edit":
            //        this.files.InnerHtml = ListControl_Bind(Convert.ToInt32(column));//加载栏目
            //        break;
            //}

        }
    }
    #endregion

    #region 绑定菜单==================================
    public void bind_RepeaterNav()
    {
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        DataSet ds = bllColumn.GetList("parentId=0 and nav_type='system' and isHidden=0 order by ordernumber desc");
        string strNav = "";
        string role_id = "";
        string role_type = "";
        HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];
        if (cookie != null)
        {
            role_id = (string)cookie.Values["adminid"];
            role_type = (string)cookie.Values["adminType"];
        }
        else if (Session["adminid"] != null)
        {
            role_id = (string)Session["adminid"];
            role_type = (string)Session["adminType"];
        }
        Cms.BLL.C_admin_role_value bllrole_value = new Cms.BLL.C_admin_role_value();

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            StringBuilder sbuBuilder = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataSet ds1 = null;
                if (role_type == "1")
                {
                    ds1 = ds;
                }
                else
                {
                    ds1 = bllrole_value.GetList("nav_name='" + ds.Tables[0].Rows[i]["className"].ToString() + "' and role_id=" + Convert.ToInt32(role_id));

                }

                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    sbuBuilder.Append("<li><a href='index.aspx?id=" + ds.Tables[0].Rows[i]["classId"].ToString() + "'><i class='icon-" + i + "'></i><span>" + ds.Tables[0].Rows[i]["className"].ToString() + "</span></a></li>");
                }
                else
                {
                    continue;
                }
            }
            strNav = sbuBuilder.ToString();

        }
        Application["strNav"] = strNav;
    }
    #endregion

    #region 绑定栏目递归Generate==============================
    public string ListControl_Bind(int n)
    {
        string role_id = "";
        string role_type = "";
        HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];
        if (cookie != null)
        {
            role_id = (string)cookie.Values["adminid"];
            role_type = (string)cookie.Values["adminType"];
        }
        else if (Session["adminid"] != null)
        {
            role_id = (string)Session["adminid"];
            role_type = (string)Session["adminType"];
        }
        Cms.BLL.C_admin_role_value bllrole_value = new Cms.BLL.C_admin_role_value();


        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet dt = bllcolumn.GetList("parentId=" + n + "and isHidden=0 order by orderNumber desc");
        string Temphtml = "";
        dt.Tables[0].Columns.Add("Operate", typeof(string));//操作
        dt.Tables[0].Columns.Add("Colum", typeof(String));//在dt中增加字段名为Colum的列
        if (dt.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.Tables[0].Rows[i];
                string strchar = "";
                string modelid = dr["modelId"].ToString();
                string strhref = "";
                if (modelid == "2")//文章模型
                {
                    strhref = "article/articlelist.aspx?classid=" + dr["classid"].ToString();
                }
                else if (modelid == "3")//产品模型
                {

                    strhref = "article/productList.aspx?action=edit&classid=" + dr["classid"].ToString() + "&parentId=" + dr["parentId"].ToString();
                }
                else if (modelid == "4")//单页模型
                {
                    strhref = "settings/SinglePage_edit.aspx?action=edit&classid=" + dr["classid"].ToString() + "&parentId=" + dr["parentId"].ToString();
                }
                else if (modelid == "5")
                {
                    strhref = "article/integralList.aspx?classid=" + dr["classid"].ToString();
                }
                else
                {
                    strhref = dr["listinfopath"].ToString() == "" ? "javascript:void(0);" : dr["listinfopath"].ToString();
                }
                DataSet ds = null;
                if (role_type == "1")
                {
                    ds = dt;
                }
                else
                {
                    ds = bllrole_value.GetList("nav_name='" + dr["className"] + "' and role_id=" + Convert.ToInt32(role_id));
                }
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    strchar += " <li><a class='item' target='mainframe' href='" + strhref + "'>" + dr["className"] + "</a><ul>";
                    strchar += InitChild(dr);
                    strchar += "</ul></li>";

                    Temphtml += strchar;
                    //this.files.InnerHtml = Temphtml;
                }
                else
                {

                    Temphtml += strchar;
                    //this.files.InnerHtml = Temphtml;
                }
            }
        }

        this.RepeaterColum.DataSource = dt;
        this.RepeaterColum.DataBind();
        return Temphtml.ToString();
    }

    private string InitChild(DataRow dr)
    {
        string role_id = "";
        string role_type = "";
        HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];
        if (cookie != null)
        {
            role_id = (string)cookie.Values["adminid"];
            role_type = (string)cookie.Values["adminType"];
        }
        else if (Session["adminid"] != null)
        {
            role_id = (string)Session["adminid"];
            role_type = (string)Session["adminType"];
        }
        Cms.BLL.C_admin_role_value bllrole_value = new Cms.BLL.C_admin_role_value();

        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet dtt = bllcolumn.GetList("parentId=" + dr["classid"] + "and isHidden=0 order by orderNumber desc");
        dtt.Tables[0].Columns.Add("Operate", typeof(string));
        dtt.Tables[0].Columns.Add("Colum", typeof(String));
        string temp = "";
        string strchar = "";
        if (dtt.Tables[0].Rows.Count > 0)
        {

            for (int k = 0; k < dtt.Tables[0].Rows.Count; k++)
            {
                DataRow dro = dtt.Tables[0].Rows[k];
                Cms.BLL.C_Column bllcolumn1 = new Cms.BLL.C_Column();
                DataSet dtt1 = bllcolumn1.GetList("parentId=" + dro["classid"] + "and isHidden=0 order by orderNumber desc");
                if (dtt1.Tables[0].Rows.Count > 0)
                {
                    DataRow dro1 = dtt.Tables[0].Rows[k];
                    string modelid = dro["modelId"].ToString();
                    string strhref = "";
                    if (modelid == "2")//文章模型
                    {
                        strhref = "article/articlelist.aspx?classid=" + dro["classid"].ToString();
                    }
                    else if (modelid == "3")//产品模型
                    {
                        strhref = "article/productList.aspx?action=edit&classid=" + dro["classid"].ToString() + "&parentId=" + dro["parentId"].ToString();
                       
                    }
                    else if (modelid == "4")//单页模型
                    {
                        strhref = "settings/SinglePage_edit.aspx?action=edit&classid=" + dro["classid"].ToString() + "&parentId=" + dro["parentId"].ToString();
                    }
                    else if (modelid == "5")
                    {
                        strhref = "article/integralList.aspx?classid=" + dro["classid"].ToString();
                    }
                    else
                    {
                        strhref = dro["listinfopath"].ToString() == "" ? "javascript:void(0);" : dro["listinfopath"].ToString();
                    }
                    DataSet ds = null;
                    if (role_type == "1")
                    {
                        ds = dtt;
                    }
                    else
                    {
                        ds = bllrole_value.GetList("nav_name='" + dro["className"] + "' and role_id=" + Convert.ToInt32(role_id));
                    }

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {


                        strchar += " <li><a class='item' href='" + strhref + "'  target='mainframe'>" + dro["className"].ToString() + "</a><ul>";
                        strchar += InitChild(dro1);
                        strchar += "</ul></li>";
                    }

                }
                else
                {
                    string modelid = dro["modelId"].ToString();
                    string strhref = "";
                    if (modelid == "2")//文章模型
                    {
                        strhref = "article/articlelist.aspx?classid=" + dro["classid"].ToString();
                    }
                    else if (modelid == "3")//产品模型
                    {
                        strhref = "article/productList.aspx?action=edit&classid=" + dro["classid"].ToString() + "&parentId=" + dro["parentId"].ToString();
                    }
                    else if (modelid == "4")//单页模型
                    {
                        strhref = "settings/SinglePage_edit.aspx?action=edit&classid=" + dro["classid"].ToString() + "&parentId=" + dro["parentId"].ToString();
                    }
                    else if (modelid == "5")
                    {
                        strhref = "article/integralList.aspx?action=edit&classid=" + dro["classid"].ToString() + "&parentId=" + dro["parentId"].ToString();
                    }
                    else
                    {
                        strhref = dro["listinfopath"].ToString() == "" ? "javascript:void(0);" : dro["listinfopath"].ToString();
                    }
                    DataSet ds = null;
                    if (role_type == "1")
                    {
                        ds = dtt;
                    }
                    else
                    {
                        ds = bllrole_value.GetList("nav_name='" + dro["className"] + "' and role_id=" + Convert.ToInt32(role_id));
                    }


                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        temp += "<li>";
                        temp += "<a  class='item' target='mainframe'  href='" + strhref + "'>" + dro["className"].ToString() + "</a>";
                        temp += "</li>";
                    }
                }

            }
        }
        return strchar + temp;
    }


    #endregion

    #region 安全退出==================================
    protected void lbtnExit_Click(object sender, EventArgs e)
    {

        Response.Redirect("login.aspx");
    }
    #endregion
}