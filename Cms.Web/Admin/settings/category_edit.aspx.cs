using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;

public partial class Admin_settings_category_edit : System.Web.UI.Page
{
   
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
            DropList_Bind();//绑定栏目========================================
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//文章类别ID=====================
            string parent_id = this.Request.QueryString["parent_id"] ?? "";//上级类别ID=======================
            int channel_id = Convert.ToInt32(this.Request.QueryString["channel_id"] == "" ? "0" : this.Request.QueryString["channel_id"]);//栏目ID===
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add========================
            switch (action)
            {
                case "add":
                    this.TreeBind(channel_id);//绑定类别===========================================
                    ddlParentId.SelectedValue = id.ToString();//设置默认上级类别===============================
                    ddlchannel_id.SelectedValue = channel_id.ToString();//设置栏目===============================
                    break;
                case "edit":
                   this.TreeBind(channel_id);//绑定类别==================================
                   this.ShowInfo(id);//绑定栏目信息===========================================
                    ddlParentId.SelectedValue = parent_id;//设置默认上级类别===================================
                    ddlchannel_id.SelectedValue = channel_id.ToString();//设置栏目=================================
                    break;
            }


        }
    }

    #region 绑定栏目===================================
    public void DropList_Bind()
    {

        ddlchannel_id.Items.Clear();
        //ddlchannel_id.Items.Add(new ListItem("颜色分类", "0"));
        Cms.BLL.C_type bllcolumn = new Cms.BLL.C_type();
        Cms.Model.C_type modelcolumn = new Cms.Model.C_type();
        DataSet ds = bllcolumn.GetList("");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ListItem item = new ListItem();
                item.Text = "" + dr["title"].ToString();
                item.Value = dr["id"].ToString();

                ddlchannel_id.Items.Add(item);
                ChileNodeBind(dr, ddlchannel_id, 2);
            }
        }

    }

    private void ChileNodeBind(DataRow drr, DropDownList parentId, int m)
    {
        Cms.BLL.C_type bllcolumn = new Cms.BLL.C_type();
        Cms.Model.C_type modelcolumn = new Cms.Model.C_type();
        DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "");
        if (dss.Tables[0].Rows.Count > 0)
        {

            string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
            for (int j = 1; j <= m; j++)
            {
                s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
            }
            for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
            {
                DataRow dro = dss.Tables[0].Rows[k];
                string flag = "├";
                if (dss.Tables[0].Rows.Count == 1)
                {
                    flag = "├";
                }
                else
                {
                    if (k == 0)
                    {
                        flag = "├";
                    }
                    if (k == dss.Tables[0].Rows.Count - 1)
                    {
                        flag = "├";
                    }
                }
                ListItem item = new ListItem();
                item.Text = s + flag + dro["title"].ToString();
                item.Value = dro["id"].ToString();

                parentId.Items.Add(item);

                ChileNodeBind(dro, parentId, m + 5);
            }
        }
    }
    #endregion

    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 绑定类别=================================
    public void TreeBind(int channel_id)
    {
        Cms.BLL.C_article_category bll = new Cms.BLL.C_article_category();
        DataTable dt = null;
        if (channel_id == 0)
        {
            dt = bll.GetList(0, channel_id, "");
        }
        else
        {
            dt = bll.GetList(0, channel_id, "where channel_id=" + channel_id);
        }

        this.ddlParentId.Items.Clear();
        this.ddlParentId.Items.Add(new ListItem("无父级", "0"));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            int ClassLayer = int.Parse(dr["class_layer"].ToString());
            string Title = dr["title"].ToString().Trim();

            if (ClassLayer == 1)
            {
                this.ddlParentId.Items.Add(new ListItem(Title, Id));
            }
            else
            {
                Title = "├ " + Title;
                Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                this.ddlParentId.Items.Add(new ListItem(Title, Id));
            }
        }
    }
    #endregion

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        Cms.BLL.C_article_category bll = new Cms.BLL.C_article_category();
        Cms.Model.C_article_category model = bll.GetModel(_id);

        ddlParentId.SelectedValue = model.parent_id.ToString();
        ddlchannel_id.SelectedValue = model.channel_id.ToString();
        txtCallIndex.Text = model.call_index;
        txtTitle.Text = model.title;
        txtSortId.Text = model.sort_id.ToString();
        txtSeoTitle.Text = model.seo_title;
        txtSeoKeywords.Text = model.seo_keywords;
        txtSeoDescription.Text = model.seo_description;
        txtLinkUrl.Text = model.link_url;
        txtImgUrl.Value = model.img_url;
        txtContent.Value = model.content;
        this.isHidden.SelectedValue = model.isHidden.ToString();//显示状态
       
        adword.Text=model.adword;
        Fold.Text = model.Fold;
        activetime.Text = model.activetime;
        Special.Text = model.Special;
        video.Text = model.video;
    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        string channel_id = this.Request.QueryString["channel_id"] ?? "";//栏目ID
        try
        {
            Cms.Model.C_article_category model = new Cms.Model.C_article_category();
            Cms.BLL.C_article_category bll = new Cms.BLL.C_article_category();
            model.channel_id = Convert.ToInt32(ddlchannel_id.SelectedValue);
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            string class_layer = getclasslayer(Convert.ToInt32(this.ddlParentId.SelectedValue), 1);
            model.class_layer = Convert.ToInt32(class_layer);
            model.parent_id = int.Parse(ddlParentId.SelectedValue);
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.seo_title = txtSeoTitle.Text;
            model.seo_keywords = txtSeoKeywords.Text;
            model.seo_description = txtSeoDescription.Text;
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Value.Trim();
            model.content = txtContent.Value;
            model.isHidden = Convert.ToInt32(this.isHidden.SelectedValue);//显示状态
            model.isTop = 0;//0 不置顶
            model.isRecommend = 0;//0 不推荐
            model.isHot = 0;//不属于热门
            model.is_msg = 0;//不属于评论
            model.is_slide = 0;//不属于幻灯片
          
            model.adword=adword.Text ;
            model.Fold = Fold.Text;
            model.activetime = activetime.Text;
            model.Special = Special.Text;
            model.video = video.Text;
            if (bll.Add(model) > 0)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), model.title); //记录日志
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
        string channel_id = this.Request.QueryString["channel_id"] ?? "";//栏目ID
        try
        {
            Cms.BLL.C_article_category bll = new Cms.BLL.C_article_category();
            Cms.Model.C_article_category model = bll.GetModel(_id);

            int parentId = int.Parse(ddlParentId.SelectedValue);
            string class_layer = getclasslayer(Convert.ToInt32(this.ddlParentId.SelectedValue), 1);
            model.class_layer = Convert.ToInt32(class_layer);
            model.channel_id = Convert.ToInt32(ddlchannel_id.SelectedValue);
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            //如果选择的父ID不是自己,则更改
            if (parentId != model.id)
            {
                model.parent_id = parentId;
            }
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.seo_title = txtSeoTitle.Text;
            model.seo_keywords = txtSeoKeywords.Text;
            model.seo_description = txtSeoDescription.Text;
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Value.Trim();
            model.content = txtContent.Value;
            model.isHidden = Convert.ToInt32(this.isHidden.SelectedValue);//显示状态
            model.isTop = 0;//0 不置顶
            model.isRecommend = 0;//0 不推荐
            model.isHot = 0;//不属于热门
            model.is_msg = 0;//不属于评论
            model.is_slide = 0;//不属于幻灯片
           
            model.adword = adword.Text;
            model.Fold = Fold.Text;
            model.activetime = activetime.Text;
            model.Special = Special.Text;
            model.video = video.Text;
            if (bll.Update(model))
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.title); //记录日志
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

    #region 获取栏目等级========================================
    public string getclasslayer(int parentId, int result)
    {
        string resultone = "";
        Cms.BLL.C_article_category bll = new Cms.BLL.C_article_category();
        DataSet ds = bll.GetList("id=" + parentId);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = result + 1;
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["parent_id"].ToString());
            resultone = getclasslayer(id, result);
        }
        else
        {
            resultone = result.ToString();

        }
        return resultone;
    }
    #endregion

    #region 保存类别============================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//文章类别ID
        string parent_id = this.Request.QueryString["parent_id"] ?? "";//上级类别ID
        string channel_id =ddlchannel_id.SelectedValue;//栏目ID
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        switch (action)
        {
            case "add":
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("添加类别成功！", "category_list.aspx?id=" + channel_id, "Success");
                break;
            case "edit":

           if (!DoEdit(id))
            {

                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("修改类别成功！", "category_list.aspx?id=" + channel_id, "Success");
            break;
        }

    }
    #endregion
}