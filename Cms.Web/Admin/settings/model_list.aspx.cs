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

public partial class Admin_settings_model_list : System.Web.UI.Page
{
    protected int channel_id;
    protected int id;
    protected string channel_name = string.Empty; //频道名称

    protected void Page_Load(object sender, EventArgs e)
    {
        this.channel_id = Convert.ToInt32(this.Request.QueryString["channel_id"] ?? "1");//栏目ID
        this.channel_name = ""; //取得频道名称
        if (this.channel_id == 0)
        {
            JscriptMsg("频道参数不正确！", "back", "Error");
            return;
        }
        if (!Page.IsPostBack)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_category", DTEnums.ActionEnum.View.ToString()); //检查权限
            id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//类别ID
            RptBind(id);
        }
    }

    #region 数据绑定==================================
    private void RptBind(int id)
    {
        
        DataTable dt =new Cms.BLL.C_model().GetList("").Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();

        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classname = cm.GetModel(27).className;
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
            LinkButton lb = (LinkButton)e.Item.FindControl("lbedit");
            LinkButton lbadd = (LinkButton)e.Item.FindControl("lbadd");

            Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
            string classname = cm.GetModel(27).className;
            bool blEdit = adminUser.setpurview(classname, "Edit");
            bool bladd = adminUser.setpurview(classname, "Edit");
            if (!bladd)
            {
                lbadd.Visible = false;
            }
            if (!blEdit)
            {
                lb.Visible = false;
            }
            int classLayer = Convert.ToInt32(hidLayer.Value);
            if (classLayer == 1)
            {
                LitFirst.Text = LitImg1;
            }
            else
            {
                LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
            }


        }

    }
    #endregion

    #region 保存排序==============================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //ChkAdminLevel("channel_" + this.channel_name + "_category", DTEnums.ActionEnum.Edit.ToString()); //检查权限
        Cms.BLL.C_article_category bll = new Cms.BLL.C_article_category();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article_category set sort_id=" + sortId + " where id='" + id + "'");//修改

        }
        //AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "保存" + this.channel_name + "频道栏目分类排序"); //记录日志
        int pid = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//类别ID
        JscriptMsg("保存排序成功！", Utils.CombUrlTxt("model_list.aspx", "id={0}", pid.ToString()), "Success");
    }
    #endregion

    #region 删除类别=====================================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // ChkAdminLevel("channel_" + this.channel_name + "_category", DTEnums.ActionEnum.Delete.ToString()); //检查权限
        Cms.BLL.C_model bll = new Cms.BLL.C_model();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
               
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "删除" + bll.GetModel(id).modelName); //记录日志
                bll.Delete(id);
            }

        }
        
        JscriptMsg("删除数据成功！", Utils.CombUrlTxt("model_list.aspx", "channel_id={0}", this.channel_id.ToString()), "Success");
    }
    #endregion

    #region 获取分类所属栏目名称=================================
    public string getcolumn(int channel_id)
    {
        string result = "";
        Cms.BLL.C_type bll = new Cms.BLL.C_type();
        DataSet ds = bll.GetList("id=" + channel_id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = ds.Tables[0].Rows[0]["title"].ToString();
        }
        return result;
    }
    public string getisHidden(int channel_id)
    {
        string result = "";
        if (channel_id == 0)
        {
            result = "正常";
        }
        if (channel_id == 1)
        {
            result = "待审核";
        }
        if (channel_id == 1)
        {
            result = "不显示";
        }
        return result;
    }
    #endregion

    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 设置操作===================================
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
        Cms.BLL.C_article_category bll = new Cms.BLL.C_article_category();
        Cms.Model.C_article_category model = bll.GetModel(id);
        switch (e.CommandName)
        {
            case "lbtnIsMsg":
                if (model.is_msg == 1)
                    this.updateSate(id, "is_msg=0");
                else
                    this.updateSate(id, "is_msg=1");
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
                if (model.is_slide == 1)
                    this.updateSate(id, "is_slide=0");
                else
                    this.updateSate(id, "is_slide=1");
                break;
        }
    }
    public void updateSate(int id, string state)
    {
        this.channel_id = Convert.ToInt32(this.Request.QueryString["id"] ?? "1");//栏目ID
        int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article_category set " + state + " where id='" + id + "'");//修改
        JscriptMsg("设置成功！", "model_list.aspx?id=" + channel_id, "Success");
    }
    #endregion


    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("model_edit.aspx?action=add");
    }
    protected void lbedit_Command(object sender, CommandEventArgs e)
    {
        string cid = e.CommandArgument.ToString();
        string pid = e.CommandName.ToString();
        Response.Redirect("model_edit.aspx?action=edit&id=" + cid + "");
    }
    protected void lbadd_Command(object sender, CommandEventArgs e)
    {
        string cid = e.CommandArgument.ToString();
        string pid = e.CommandName.ToString();
        Response.Redirect("model_edit.aspx?action=add&channel_id=" + pid + "&id=" + cid + "");
    }
}