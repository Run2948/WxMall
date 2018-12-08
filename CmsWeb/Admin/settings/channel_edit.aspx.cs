using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Common;

public partial class Admin_settings_channel_edit : System.Web.UI.Page
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
            DropList_Bind();//绑定栏目===========================
            ActionTypeBind();//绑定权限值===========================
            FieldBind();//绑定扩展字段===========================
            cblActionType.Items[0].Selected = true;//默认选择权限值===========================
            isShowChannel.Checked = true;//默认选择参与导航===========================
            int classId = Convert.ToInt32(this.Request.QueryString["classId"] ?? "0");//栏目ID===========================
            string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID===========================
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add===========================
            switch (action)
            {
                case "add":
                    parentId.SelectedValue = classId.ToString();//设置默认上级栏目===========================
                    break;
                case "edit":
                    this.classid.Text = classId.ToString();
                    this.DataBind(classId);//绑定栏目信息===========================
                    parentId.SelectedValue = strparentId;//设置默认上级栏目===========================
                    break;
            }
        }
    }

    #region 绑定操作权限类型=========================
    private void ActionTypeBind()
    {
        cblActionType.Items.Clear();
        foreach (KeyValuePair<string, string> kvp in Utils.ActionType())
        {
            cblActionType.Items.Add(new ListItem(kvp.Value + "(" + kvp.Key + ")", kvp.Key));
        }
    }
    #endregion

    #region 赋值操作=================================
    public void DataBind(int classId)
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column model = bllcolumn.GetModel(classId);
        DataSet ds = bllcolumn.GetList("classId=" + classId + "");
        if (ds.Tables[0].Rows.Count > 0)
        {

            DataRow dr = ds.Tables[0].Rows[0];
            this.parentId.SelectedValue = model.parentId.ToString();//上级栏目ID
            this.modelId.SelectedValue = model.modelId.ToString();//栏目模型ID
            this.className.Text = model.className.ToString();//栏目名称
            this.sub_title.Text = model.sub_title.ToString();//副名称
            this.engName.Text = model.engName.ToString();//栏目英文名称
            this.orderNumber.Text = model.orderNumber.ToString();//栏目排序
            this.photoUrl.Value = model.photoUrl.ToString();//栏目缩略图
            this.photoUrlone.Value = model.photoUrlone.ToString();//栏目图标True
            this.photoUrltwo.Value = model.photoUrltwo.ToString();//栏目图标False


            string ShowChannel = model.isShowChannel.ToString();
            if (ShowChannel == "0")
            {
                isShowChannel.Checked = false;//是否参与导航 0是参与导航
            }
            else
            {
                isShowChannel.Checked = true;//是否参与导航 1是不参与导航
            }
            string ShowNext = model.isShowNext.ToString();
            if (ShowNext == "0")
            {
                isShowNext.Checked = false;//是否显示子栏目 0是显示
            }
            else
            {
                isShowNext.Checked = true;//是否显示子栏目 1是隐藏
            }
            string Blank = model.isBlank.ToString();
            if (Blank == "0")
            {
                isBlank.Checked = false;//是否打开新窗口 0是不打开新窗口
            }
            else
            {
                isBlank.Checked = true;//是否打开新窗口 1是打开新窗口
            }
            string Hidden = model.isHidden.ToString();
            if (Hidden == "0")
            {
                isHidden.Checked = false;//是否隐藏 0是显示
            }
            else
            {
                isHidden.Checked = true;//是否隐藏 1是隐藏
            }
            this.linkUrl.Text = model.linkUrl.ToString();//列表调用地址

            this.listinfopath.Text = model.listinfopath.ToString();//后台列表信息地址
            this.txtCallIndex.Text = model.name.ToString();//调用别名
            this.columnchose.Text = model.related.ToString();//关联栏目

            this.intro.Text = model.intro.ToString();//栏目简介
            this.content.Value = model.content.ToString();//栏目内容
            this.seoTitle.Text = model.seoTitle.ToString();//SEO标题
            this.seoKeyword.Text = model.seoKeyword.ToString();//SEO关键字
            this.seoDescription.Text = model.seoDescription.ToString();//SEO描述

            string wisShowChannel = model.w_isShowChannel.ToString(); //是否参与手机导航 0是参与导航
            if (wisShowChannel == "0")
            {
                w_isShowChannel.Checked = false;//是否参与手机导航 1是不参与导航
            }
            else
            {
                w_isShowChannel.Checked = true;//是否参与导航 1是不参与导航
            }
            this.w_linkUrl.Text = model.w_linkUrl.ToString();//手机链接地址

            this.w_intro.Text = model.w_intro.ToString();//手机站简介
            this.w_content.Value = model.w_content.ToString();//手机站内容

            string eisShowChannel = model.e_isShowChannel.ToString();//是否参与英文导航 0是参与导航
            if (eisShowChannel == "0")
            {
                e_isShowChannel.Checked = false;//是否参与英文导航 1是不参与导航
            }
            else
            {
                e_isShowChannel.Checked = true;//是否参与英文导航 1是不参与导航
            }
            this.e_linkUrl.Text = model.e_linkUrl.ToString();//手英文链接地址

            this.e_intro.Text = model.e_intro.ToString();//英文站简介
            this.e_content.Value = model.e_content.ToString();//英文站内容
            this.e_seoTitle.Text = model.e_seoTitle.ToString();//英文站SEO标题
            this.e_seoKeyword.Text = model.e_seoKeyword.ToString();//英文站SEO关键字
            this.e_seoDescription.Text = model.e_seoDescription.ToString();//英文站SEO描述

            #region 赋值操作权限类型=============================
            string[] actionTypeArr = model.action_type.Split(',');
            for (int i = 0; i < cblActionType.Items.Count; i++)
            {
                for (int n = 0; n < actionTypeArr.Length; n++)
                {
                    if (actionTypeArr[n].ToLower() == cblActionType.Items[i].Value.ToLower())
                    {
                        cblActionType.Items[i].Selected = true;
                    }
                }
            }
            #endregion

            #region 赋值扩展字段=============================
            if (model.channel_fields != null)
            {
                for (int i = 0; i < cblAttributeField.Items.Count; i++)
                {
                    Cms.Model.C_Column_field modelt = model.channel_fields.Find(p => p.field_id == int.Parse(cblAttributeField.Items[i].Value)); //查找对应的字段ID
                    if (modelt != null)
                    {
                        cblAttributeField.Items[i].Selected = true;
                    }
                }
            }
            #endregion


        }

    }
    #endregion

    #region 绑定栏目=================================
    public void DropList_Bind()
    {

        parentId.Items.Clear();
        parentId.Items.Add(new ListItem("作为一级分类", "0"));
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet ds = bllcolumn.GetList("parentId=0");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ListItem item = new ListItem();
                item.Text = "" + dr["className"].ToString();
                item.Value = dr["classId"].ToString();

                parentId.Items.Add(item);
                ChileNodeBind(dr, parentId, 2);
            }
        }

    }

    private void ChileNodeBind(DataRow drr, DropDownList parentId, int m)
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet dss = bllcolumn.GetList("parentId=" + drr["classId"] + "");
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
                item.Text = s + flag + dro["className"].ToString();
                item.Value = dro["classId"].ToString();

                parentId.Items.Add(item);

                ChileNodeBind(dro, parentId, m + 5);
            }
        }
    }
    #endregion

    #region 绑定扩展字段=============================
    private void FieldBind()
    {
        Cms.BLL.C_article_attribute_field bll = new Cms.BLL.C_article_attribute_field();
        DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];

        this.cblAttributeField.Items.Clear();
        foreach (DataRow dr in dt.Rows)
        {
            this.cblAttributeField.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
        }
    }
    #endregion

    #region 提交操作===============================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        int classId = Convert.ToInt32(this.Request.QueryString["classId"] ?? "0");//栏目ID
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        switch (action)
        {
            case "add":
                this.DataAdd();
                break;
            case "edit":
                this.DataUpdate(classId);
                break;
        }
    }
    #endregion

    #region 获取栏目等级========================================
    public string getclasslayer(int parentId, int result)
    {
        string resultone = "";
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        DataSet ds = bllcolumn.GetList("classId=" + parentId);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = result + 1;
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["parentId"].ToString());
            resultone = getclasslayer(id, result);
        }
        else
        {
            resultone = result.ToString();

        }
        return resultone;
    }
    #endregion

    #region 添加栏目=================================
    public void DataAdd()
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        modelcolumn.parentId = Convert.ToInt32(this.parentId.SelectedValue);//上级栏目ID
        string class_layer = getclasslayer(Convert.ToInt32(this.parentId.SelectedValue), 1);
        modelcolumn.class_layer = Convert.ToInt32(class_layer);
        modelcolumn.modelId = Convert.ToInt32(this.modelId.SelectedValue);//栏目模型ID
        modelcolumn.className = this.className.Text.Trim();//栏目名称
        modelcolumn.sub_title = this.sub_title.Text.Trim();//副名称
        modelcolumn.engName = this.engName.Text.Trim();//栏目英文名称
        modelcolumn.orderNumber = Convert.ToInt32(this.orderNumber.Text.Trim());//栏目排序
        modelcolumn.photoUrl = this.photoUrl.Value.Trim();//栏目缩略图
        modelcolumn.photoUrlone = this.photoUrlone.Value;//栏目图标True
        modelcolumn.photoUrltwo = this.photoUrltwo.Value;//栏目图标False

        modelcolumn.nav_type = Cms.Common.Enums.NavigationEnum.System.ToString();

        modelcolumn.isShowChannel = 0;//是否参与导航 0是参与导航
        if (isShowChannel.Checked == true)
        {
            modelcolumn.isShowChannel = 1;//是否参与导航 1是不参与导航
        }
        modelcolumn.isShowNext = 0;//是否显示子栏目 0是显示
        if (isShowNext.Checked == true)
        {
            modelcolumn.isShowNext = 1;//是否显示子栏目 1是隐藏
        }
        modelcolumn.isBlank = 0;//是否打开新窗口 0是不打开新窗口
        if (isBlank.Checked == true)
        {
            modelcolumn.isBlank = 1;//是否打开新窗口 1是打开新窗口
        }
        modelcolumn.isHidden = 0;//是否隐藏 0是显示
        if (isHidden.Checked == true)
        {
            modelcolumn.isHidden = 1;//是否打开新窗口 1是隐藏
        }
        modelcolumn.linkUrl = this.linkUrl.Text.Trim();//列表调用地址

        modelcolumn.listinfopath = this.listinfopath.Text.Trim();//后台列表信息地址
        modelcolumn.name = this.txtCallIndex.Text.Trim();//调用别名
        modelcolumn.related = this.columnchose.Text;//关联栏目

        modelcolumn.seoTitle = this.seoTitle.Text.Trim();//SEO标题
        modelcolumn.seoKeyword = this.seoKeyword.Text.Trim();//SEO关键字
        modelcolumn.seoDescription = this.seoDescription.Text.Trim();//SEO描述
        modelcolumn.intro = this.intro.Text;//栏目简介
        modelcolumn.content = this.content.Value;//栏目内容

        modelcolumn.w_isShowChannel = 0;//是否参与手机导航 0是参与导航
        if (w_isShowChannel.Checked == true)
        {
            modelcolumn.w_isShowChannel = 1;//是否参与手机导航 1是不参与导航
        }
        modelcolumn.w_linkUrl = this.w_linkUrl.Text;//手机链接地址

        modelcolumn.w_intro = this.w_intro.Text;//手机站简介
        modelcolumn.w_content = this.w_content.Value;//手机站内容

        modelcolumn.e_isShowChannel = 0;//是否参与英文导航 0是参与导航
        if (e_isShowChannel.Checked == true)
        {
            modelcolumn.e_isShowChannel = 1;//是否参与英文导航 1是不参与导航
        }
        modelcolumn.e_linkUrl = this.e_linkUrl.Text;//手英文链接地址

        modelcolumn.e_intro = this.e_intro.Text;//英文站简介
        modelcolumn.e_content = this.e_content.Value;//英文站内容
        modelcolumn.e_seoTitle = this.e_seoTitle.Text.Trim();//英文站SEO标题
        modelcolumn.e_seoKeyword = this.e_seoKeyword.Text.Trim();//英文站SEO关键字
        modelcolumn.e_seoDescription = this.e_seoDescription.Text.Trim();//英文站SEO描述

        //添加操作权限类型
        string action_type_str = string.Empty;
        for (int i = 0; i < cblActionType.Items.Count; i++)
        {
            if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
            {
                action_type_str += cblActionType.Items[i].Value + ",";
            }
        }
        if (action_type_str == "")
        {
            modelcolumn.action_type = action_type_str;
        }
        else
        {
            modelcolumn.action_type = Utils.DelLastComma(action_type_str);
        }

        #region 添加频道扩展字段========================
        List<Cms.Model.C_Column_field> ls = new List<Cms.Model.C_Column_field>();
        for (int i = 0; i < cblAttributeField.Items.Count; i++)
        {
            if (cblAttributeField.Items[i].Selected)
            {
                ls.Add(new Cms.Model.C_Column_field { field_id = Utils.StrToInt(cblAttributeField.Items[i].Value, 0) });
            }
        }
        modelcolumn.channel_fields = ls;
        #endregion

        int result = bllcolumn.Add(modelcolumn);
        if (result > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加" + this.className.Text.Trim()); //记录日志

            JscriptMsg("添加栏目信息成功！", "channel_list.aspx", "Success");
        }
        else
        {
            JscriptMsg("添加栏目信息失败！", "channel_edit.aspx", "Error");
        }
    }
    #endregion

    #region 修改栏目=================================
    public void DataUpdate(int classid)
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        modelcolumn.classId = classid;//栏目ID
        modelcolumn.parentId = Convert.ToInt32(this.parentId.SelectedValue);//上级栏目ID
        string class_layer = getclasslayer(Convert.ToInt32(this.parentId.SelectedValue), 1);
        modelcolumn.class_layer = Convert.ToInt32(class_layer);
        modelcolumn.modelId = Convert.ToInt32(this.modelId.SelectedValue);//栏目模型ID
        modelcolumn.className = this.className.Text.Trim();//栏目名称
        modelcolumn.sub_title = this.sub_title.Text.Trim();//副名称
        modelcolumn.engName = this.engName.Text.Trim();//栏目英文名称
        modelcolumn.orderNumber = Convert.ToInt32(this.orderNumber.Text.Trim());//栏目排序
        modelcolumn.photoUrl = this.photoUrl.Value.Trim();//栏目缩略图
        modelcolumn.photoUrlone = this.photoUrlone.Value;//栏目图标True
        modelcolumn.photoUrltwo = this.photoUrltwo.Value;//栏目图标False

        modelcolumn.nav_type = Cms.Common.Enums.NavigationEnum.System.ToString();

        modelcolumn.isShowChannel = 0;//是否参与导航 0是参与导航
        if (isShowChannel.Checked == true)
        {
            modelcolumn.isShowChannel = 1;//是否参与导航 1是不参与导航
        }
        modelcolumn.isShowNext = 0;//是否显示子栏目 0是显示
        if (isShowNext.Checked == true)
        {
            modelcolumn.isShowNext = 1;//是否显示子栏目 1是隐藏
        }
        modelcolumn.isBlank = 0;//是否打开新窗口 0是不打开新窗口
        if (isBlank.Checked == true)
        {
            modelcolumn.isBlank = 1;//是否打开新窗口 1是打开新窗口
        }
        modelcolumn.isHidden = 0;//是否隐藏 0是显示
        if (isHidden.Checked == true)
        {
            modelcolumn.isHidden = 1;//是否打开新窗口 1是隐藏
        }

        //添加操作权限类型
        string action_type_str = string.Empty;
        for (int i = 0; i < cblActionType.Items.Count; i++)
        {
            if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
            {
                action_type_str += cblActionType.Items[i].Value + ",";
            }
        }
        if (action_type_str == "")
        {
            modelcolumn.action_type = action_type_str;
        }
        else
        {
            modelcolumn.action_type = Utils.DelLastComma(action_type_str);
        }

        //end

        modelcolumn.linkUrl = this.linkUrl.Text.Trim();//列表调用地址

        modelcolumn.listinfopath = this.listinfopath.Text.Trim();//后台列表信息地址
        modelcolumn.name = txtCallIndex.Text;//调用别名
        modelcolumn.related = columnchose.Text;//关联栏目

        modelcolumn.seoTitle = this.seoTitle.Text.Trim();//SEO标题
        modelcolumn.seoKeyword = this.seoKeyword.Text.Trim();//SEO关键字
        modelcolumn.seoDescription = this.seoDescription.Text.Trim();//SEO描述
        modelcolumn.intro = this.intro.Text;//栏目简介
        modelcolumn.content = this.content.Value;//栏目内容

        modelcolumn.w_isShowChannel = 0;//是否参与手机导航 0是参与导航
        if (w_isShowChannel.Checked == true)
        {
            modelcolumn.w_isShowChannel = 1;//是否参与手机导航 1是不参与导航
        }
        modelcolumn.w_linkUrl = this.w_linkUrl.Text;//手机链接地址

        modelcolumn.w_intro = this.w_intro.Text;//手机站简介
        modelcolumn.w_content = this.w_content.Value;//手机站内容

        modelcolumn.e_isShowChannel = 0;//是否参与英文导航 0是参与导航
        if (e_isShowChannel.Checked == true)
        {
            modelcolumn.e_isShowChannel = 1;//是否参与英文导航 1是不参与导航
        }
        modelcolumn.e_linkUrl = this.e_linkUrl.Text;//手英文链接地址

        modelcolumn.e_intro = this.e_intro.Text;//英文站简介
        modelcolumn.e_content = this.e_content.Value;//英文站内容
        modelcolumn.e_seoTitle = this.e_seoTitle.Text.Trim();//英文站SEO标题
        modelcolumn.e_seoKeyword = this.e_seoKeyword.Text.Trim();//英文站SEO关键字
        modelcolumn.e_seoDescription = this.e_seoDescription.Text.Trim();//英文站SEO描述

        #region 添加频道扩展字段========================
        List<Cms.Model.C_Column_field> ls = new List<Cms.Model.C_Column_field>();
        for (int i = 0; i < cblAttributeField.Items.Count; i++)
        {
            if (cblAttributeField.Items[i].Selected)
            {
                ls.Add(new Cms.Model.C_Column_field { channel_id = modelcolumn.classId, field_id = Utils.StrToInt(cblAttributeField.Items[i].Value, 0) });
            }
        }
        modelcolumn.channel_fields = ls;
        #endregion

        if (bllcolumn.Update(modelcolumn))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改" + this.className.Text.Trim()); //记录日志

            JscriptMsg("修改栏目信息成功！", "channel_list.aspx", "Success");
        }
        else
        {
            JscriptMsg("修改栏目信息失败！", "channel_edit.aspx", "Error");
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
}