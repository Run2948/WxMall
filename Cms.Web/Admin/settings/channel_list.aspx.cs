using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Common;

public partial class Admin_settings_channel_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //登录验证
            adminUser.GetLoginState();

            //登录信息
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];
            RptBind();//绑定栏目列表
            if (cookie != null)
            {
                Application["adminname"] = (string)cookie.Values["adminname"];
            }
            else if (Session["adminname"] != null)
            {
                Application["adminname"] = (string)Session["adminname"];
            }
            // ListControl_Bind(26);//绑定栏目列表
            this.Del();


        }

    }

    #region 删除=================================================
    public void Del()
    {
        if (Request.QueryString["action"] != null)
        {
            if (Request.QueryString["action"].ToString() == "del")
            {
                int classid = Convert.ToInt32(Request.QueryString["classid"].ToString());
                string strclassname = Request.QueryString["classname"].ToString();
                Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), bllcolumn.GetModel(classid).className); //记录日志
                if (bllcolumn.Delete(classid))
                {
                   

                    JscriptMsg("删除栏目信息成功！", "channel_list.aspx", "Success");
                }
                else
                {
                    JscriptMsg("删除栏目信息失败！", "channel_list.aspx", "Error");
                }
            }
        }
    }
    #endregion

    #region 绑定栏目列表递归Generate======================================
    /// <summary>
    /// 递归栏目信息
    /// </summary>
    /// <param name="n"></param>
    public void ListControl_Bind(int n)
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet dt = bllcolumn.GetList("parentId=" + n + "order by orderNumber desc");

        dt.Tables[0].Columns.Add("Operate", typeof(string));//操作
        dt.Tables[0].Columns.Add("Colum", typeof(String));//在dt中增加字段名为Colum的列
        if (dt.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.Tables[0].Rows[i];
                string strchar = "";
                dr["operate"] = "<a href='Column_edit.aspx?action=add&classid=" + dr["classid"].ToString() + "&parentId=" + dr["parentId"].ToString() + "'>[添加下级]</a>&nbsp;&nbsp;<a href='Column_edit.aspx?action=edit&classid=" + dr["classid"].ToString() + "&parentId=" + dr["parentId"].ToString() + "'>[编辑]</a>&nbsp;&nbsp;<a href='Column_list.aspx??action=del&classID=" + dr["classid"].ToString() + "&classname=" + dr["className"].ToString() + " ' onclick='return confirm(\"真的要删除该栏目以及子栏目和栏目下的新闻吗?不可恢复!\");'>[删除]</a> ";
                strchar += "<tr  onmouseover=this.bgColor='#EBFFDC'; onmouseout=this.bgColor='#ffffff';  bgcolor='#ffffff'>";
                strchar += "<td align=\"center\"><input type='checkbox'/></td> ";
                strchar += "<td align=\"left\">" + dr["classid"].ToString() + "</td> ";
                strchar += "<td align=\"left\" >" + dr["className"].ToString() + "</td>";
                strchar += "<td align=\"center\" >" + GetClassisShowChannel(dr["isShowChannel"].ToString()) + "</td>";
                strchar += "<td align=\"center\" >" + GetClassAttrbute(dr["modelId"].ToString()) + "</td>";
                strchar += "<td align=\"left\" >" + dr["orderNumber"].ToString() + "</td>";
                strchar += "<td align=\"center\" >" + dr["operate"].ToString() + "</td>";
                strchar += "</tr>";
                strchar = InitChild(dr, strchar, 2);
                dr["Colum"] = strchar;
            }
        }
        this.rptList.DataSource = dt;
        this.rptList.DataBind();
    }

    private string InitChild(DataRow dr, string strchar, int n)
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet dtt = bllcolumn.GetList("parentId=" + dr["classid"] + "order by orderNumber desc");

        dtt.Tables[0].Columns.Add("Operate", typeof(string));
        dtt.Tables[0].Columns.Add("Colum", typeof(String));
        if (dtt.Tables[0].Rows.Count > 0)
        {
            string s = "&nbsp;";
            for (int j = 1; j <= n; j++)
            {
                s += "&nbsp;";
            }
            for (int k = 0; k < dtt.Tables[0].Rows.Count; k++)
            {
                DataRow dro = dtt.Tables[0].Rows[k];
                string flag = "├";
                if (dtt.Tables[0].Rows.Count == 1)
                {
                    flag = "├";
                }
                else
                {
                    if (k == 0)
                    {
                        flag = "├";
                    }
                    if (k == dtt.Tables[0].Rows.Count - 1)
                    {
                        flag = "├";
                    }
                }
                dro["operate"] = "<a href='Column_edit.aspx?action=add&classid=" + dro["classid"].ToString() + "&parentId=" + dro["parentId"].ToString() + "'>[添加下级]</a>&nbsp;&nbsp;<a href='Column_edit.aspx?action=edit&classid=" + dro["classid"].ToString() + "&parentId=" + dro["parentId"].ToString() + "'>[编辑]</a>&nbsp;&nbsp;<a href='Column_list.aspx?action=del&classid=" + dro["classid"].ToString() + "&classname=" + dro["className"].ToString() + " ' onclick='return confirm(\"真的要删除?栏目删除之后,该栏目下的新闻也将删除,不可恢复!\");'>[删除]</a>";
                strchar += "<tr  onmouseover=this.bgColor='#EBFFDC'; onmouseout=this.bgColor='#ffffff';  bgcolor='#ffffff'>";
                strchar += "<td align=\"center\"><input type='checkbox'/></td> ";
                strchar += "<td align=\"left\">" + dro["classid"].ToString() + "</td> ";
                strchar += "<td align=\"left\" >" + s + flag + dro["className"].ToString() + "</td>";
                strchar += "<td align=\"center\" >" + GetClassisShowChannel(dro["isShowChannel"].ToString()) + "</td>";
                strchar += "<td align=\"center\" >" + GetClassAttrbute(dro["modelId"].ToString()) + "</td>";
                strchar += "<td align=\"left\" >" + dro["orderNumber"].ToString() + "</td>";
                strchar += "<td align=\"center\" >" + dro["Operate"].ToString() + "</td>";
                strchar += "</tr>";
                strchar = InitChild(dro, strchar, n + 8);
            }

        }
        return strchar;
    }
    #endregion

    #region 绑定栏目列表=================================================
    //数据绑定
    private void RptBind()
    {
        Cms.BLL.C_Column bll = new Cms.BLL.C_Column();
        DataTable dt = bll.GetList(0, Cms.Common.Enums.NavigationEnum.System.ToString());
        this.rptList.DataSource = dt;
        this.rptList.DataBind();

        bool bladd = adminUser.setpurview("频道管理", "add");
        bool blEdit = adminUser.setpurview("频道管理", "Edit");
        bool blDelete = adminUser.setpurview("频道管理", "Delete");

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

    //美化列表
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
            HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
            string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            string LitImg1 = "<span class=\"folder-open\"></span>";
            string LitImg2 = "<span class=\"folder-line\"></span>";

            int classLayer = Convert.ToInt32(hidLayer.Value);
            if (classLayer == 1)
            {
                LitFirst.Text = LitImg1;
            }
            else
            {
                LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
            }

            LinkButton edit = (LinkButton)e.Item.FindControl("lbedit");
            LinkButton ladd = (LinkButton)e.Item.FindControl("lbadd");
            HiddenField hidname = (HiddenField)e.Item.FindControl("hidname");
            string classname = hidname.Value;
            bool bladd = adminUser.setpurview(classname, "add");
            bool blEdit = adminUser.setpurview(classname, "Edit");


            if (!bladd)
            {
                ladd.Visible = false;
            }
            if (!blEdit)
            {

                edit.Visible = false;
            }
        }
    }

    #endregion

    #region 保存排序=============================================
    protected void btnSave_Click(object sender, EventArgs e)
    {

        Cms.BLL.C_Column bll = new Cms.BLL.C_Column();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("ordernumber")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_Column set ordernumber=" + sortId + " where classId='" + id + "'");//修改
        }

        JscriptMsg("保存排序成功！", "channel_list.aspx", "Success");
    }
    #endregion

    #region 删除导航======================================
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        Cms.BLL.C_Column bll = new Cms.BLL.C_Column();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), bll.GetModel(id).className); //记录日志
                bll.Delete(id);
               
            }
        }

        JscriptMsg("删除数据成功！", "channel_list.aspx", "Success");
    }
    #endregion

    #region 获取栏目模型名称================================
    public string GetClassAttrbute(string attribute)
    {
        if (attribute == "1")
        {
            return attribute = "导航模型";
        }
        else if (attribute == "2")
        {
            return attribute = "文章模型";
        }
        else if (attribute == "3")
        {
            return attribute = "产品模型";
        }
        else if (attribute == "4")
        {
            return attribute = "单页模型";
        }
        else
        {
            return attribute = "积分模型";
        }
    }
    #endregion

    #region 获取是否参与导航===========================
    public string GetClassisShowChannel(string isShowChannel)
    {
        if (isShowChannel == "1")
        {
            return isShowChannel = "是";
        }
        else
        {
            return isShowChannel = "否";
        }

    }
    #endregion

    #region 提示框==============================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("channel_edit.aspx?action=add");
    }
    protected void lbadd_Command(object sender, CommandEventArgs e)
    {
        string cid = e.CommandArgument.ToString();
        Response.Redirect("channel_edit.aspx?action=add&classid=" + cid + "");
    }
    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        string cid = e.CommandArgument.ToString();
        Response.Redirect("channel_edit.aspx?action=edit&classid=" + cid + "");
    }
}