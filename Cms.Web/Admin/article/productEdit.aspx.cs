using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Cms.Common;
using System.Data;
using System.Collections;

public partial class Admin_article_productEdit : System.Web.UI.Page
{
    protected string classid;
    public int channel_id = 0;
    Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Admin_article_productEdit));//注册Ajax可调用的类的名称
        int articleId = Convert.ToInt32(this.Request.QueryString["articleId"] ?? "0");//文章ID
        
        classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID
        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;
            DropList_Bind();//绑定栏目
            //DropList_Bind_type();
            parentId.SelectedValue = classid.ToString();//设置默认上级栏目导航
            this.channel_id = Convert.ToInt32(classid);
            this.hreflist.HRef = "articleList.aspx?classid=" + classid;//设置返回列表链接
            //this.Bind_cut();//绑定切工分类
            //this.Bind_clarity();//绑定净度分类
            //this.Bind_finger_ring();//绑定指圈分类
            //this.Bind_color();//绑定颜色分类
            //this.Bind_shape();//绑定形状分类
            //this.Bind_material();//绑定金属材质
            //this.Bind_bstype();//绑定宝石类
            //this.Bind_pintype();//绑定品类

            bind_is(classid);//是否开通功能
            CreateOtherField(this.channel_id);//动态生成相应的扩展字段

            CreaterelatedCloumn(this.channel_id);//动态创建相应关联信息
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    if (!new Cms.BLL.C_article().Exists(articleId))
                    {
                        JscriptMsg("不存在或已被删除！", "back", "Error");
                        return;
                    }
                    this.DataBind(articleId);//绑定文章信息
                    break;
            }
        }
        else
        {
            CreateOtherField(this.channel_id);//动态生成相应的扩展字段
        }
    }

    #region 是否开通==========
    public void bind_is(string classid)
    {
        #region 读取是否开通手机站或者英文站===========================================
        string wisShowChannel = bllcolumn.GetModel(Convert.ToInt32(classid)).w_isShowChannel.ToString();
        string eisShowChannel = bllcolumn.GetModel(Convert.ToInt32(classid)).e_isShowChannel.ToString();
        string bisShowNext = bllcolumn.GetModel(Convert.ToInt32(classid)).isShowNext.ToString();
        if (wisShowChannel == "1")
        {
            wap_tab_item.Visible = true;
            wap_tab_content.Visible = true;
        }
        if (eisShowChannel == "1")
        {
            english_tab_item.Visible = true;
            english_tab_content.Visible = true;
        }
        if (bisShowNext == "1")
        {
            best_tab_item.Visible = true;
            best_tab_content.Visible = true;
        }
        //查找该频道所开启的相册功能
        if (bllcolumn.GetModel(Convert.ToInt32(classid)).is_albums == 1)
        {
            div_albums_container.Visible = true;
        }
        //查找该频道所开启的附件功能
        if (bllcolumn.GetModel(Convert.ToInt32(classid)).is_attach == 1)
        {
            Dl1.Visible = true;
        }
        #endregion
    }
    #endregion
    
    #region 动态创建相应关联信息====================================================
    public void CreaterelatedCloumn(int _channel_id)
    {
        string related = bllcolumn.GetModel(_channel_id).related.ToString();
        if (related != "" && related != null)
        {
            related_tab_item.Visible = true;
            related_tab_content.Visible = true;
            Cms.BLL.C_article bll = new Cms.BLL.C_article();
            DataSet ds = bll.GetList("parentId=" + Convert.ToInt32(related));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                //ListItem lt;
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    lt = new ListItem(ds.Tables[0].Rows[i]["articleId"].ToString(), ds.Tables[0].Rows[i]["title"].ToString());
                //    lt.Attributes["text"] = ds.Tables[0].Rows[i]["title"].ToString();
                //    lt.Attributes["myValue"] = ds.Tables[0].Rows[i]["articleId"].ToString();
                //    this.CheckBoxList_related.Items.Add(lt);


                //}
                CheckBoxList_related.DataSource = ds.Tables[0].DefaultView;
                CheckBoxList_related.DataTextField = "title";
                CheckBoxList_related.DataValueField = "articleId";
                CheckBoxList_related.DataBind();
            }
        }
    }
    #endregion

    #region 创建扩展字段=========================
    private void CreateOtherField(int _channel_id)
    {
        try
        {
            List<Cms.Model.C_article_attribute_field> ls = new Cms.BLL.C_article_attribute_field().GetModelList(Convert.ToInt32(this.classid), "is_sys=0");
            if (ls.Count > 0)
            {
                field_tab_item.Visible = true;
                field_tab_content.Visible = true;
            }
            foreach (Cms.Model.C_article_attribute_field modelt in ls)
            {
                //创建一个dl标签
                HtmlGenericControl htmlDL = new HtmlGenericControl("dl");
                HtmlGenericControl htmlDT = new HtmlGenericControl("dt");
                HtmlGenericControl htmlDD = new HtmlGenericControl("dd");
                htmlDT.InnerHtml = modelt.title;
                switch (modelt.control_type)
                {
                    case "single-text": //单行文本
                        //创建一个TextBox控件
                        TextBox txtControl = new TextBox();
                        txtControl.ID = "field_control_" + modelt.name;
                        //CSS样式及TextMode设置
                        if (modelt.control_type == "single-text") //单行
                        {
                            txtControl.CssClass = "input normal";
                            //是否密码框
                            if (modelt.is_password == 1)
                            {
                                txtControl.TextMode = TextBoxMode.Password;
                            }
                        }
                        else if (modelt.control_type == "multi-text") //多行
                        {
                            txtControl.CssClass = "input";
                            txtControl.TextMode = TextBoxMode.MultiLine;
                        }
                        else if (modelt.control_type == "number") //数字
                        {
                            txtControl.CssClass = "input small";
                        }
                        else if (modelt.control_type == "images") //图片
                        {
                            txtControl.CssClass = "input normal upload-path";
                        }
                        //设置默认值
                        txtControl.Text = modelt.default_value;
                        //验证提示信息
                        if (!string.IsNullOrEmpty(modelt.valid_tip_msg))
                        {
                            txtControl.Attributes.Add("tipmsg", modelt.valid_tip_msg);
                        }
                        //验证失败提示信息
                        if (!string.IsNullOrEmpty(modelt.valid_error_msg))
                        {
                            txtControl.Attributes.Add("errormsg", modelt.valid_error_msg);
                        }
                        //验证表达式
                        if (!string.IsNullOrEmpty(modelt.valid_pattern))
                        {
                            txtControl.Attributes.Add("datatype", modelt.valid_pattern);
                            txtControl.Attributes.Add("sucmsg", " ");
                        }
                        //创建一个Label控件
                        Label labelControl = new Label();
                        labelControl.CssClass = "Validform_checktip";
                        labelControl.Text = modelt.valid_tip_msg;

                        //将控件添加至DD中
                        htmlDD.Controls.Add(txtControl);
                        //如果是图片则添加上传按钮
                        if (modelt.control_type == "images")
                        {
                            HtmlGenericControl htmlBtn = new HtmlGenericControl("div");
                            htmlBtn.Attributes.Add("class", "upload-box upload-img");
                            htmlBtn.Attributes.Add("style", "margin-left:4px;");
                            htmlDD.Controls.Add(htmlBtn);
                        }
                        htmlDD.Controls.Add(labelControl);
                        break;
                    case "multi-text": //多行文本
                        goto case "single-text";
                    case "editor": //编辑器
                        HtmlTextArea txtTextArea = new HtmlTextArea();
                        txtTextArea.ID = "field_control_" + modelt.name;
                        txtTextArea.Attributes.Add("style", "visibility:hidden;");
                        //是否简洁型编辑器
                        if (modelt.editor_type == 1)
                        {
                            txtTextArea.Attributes.Add("class", "editor-mini");
                        }
                        else
                        {
                            txtTextArea.Attributes.Add("class", "editor");
                        }
                        txtTextArea.Value = modelt.default_value; //默认值
                        //验证提示信息
                        if (!string.IsNullOrEmpty(modelt.valid_tip_msg))
                        {
                            txtTextArea.Attributes.Add("tipmsg", modelt.valid_tip_msg);
                        }
                        //验证失败提示信息
                        if (!string.IsNullOrEmpty(modelt.valid_error_msg))
                        {
                            txtTextArea.Attributes.Add("errormsg", modelt.valid_error_msg);
                        }
                        //验证表达式
                        if (!string.IsNullOrEmpty(modelt.valid_pattern))
                        {
                            txtTextArea.Attributes.Add("datatype", modelt.valid_pattern);
                            txtTextArea.Attributes.Add("sucmsg", " ");
                        }
                        //创建一个Label控件
                        Label labelControl2 = new Label();
                        labelControl2.CssClass = "Validform_checktip";
                        labelControl2.Text = modelt.valid_tip_msg;
                        //将控件添加至DD中
                        htmlDD.Controls.Add(txtTextArea);
                        htmlDD.Controls.Add(labelControl2);
                        break;
                    case "images": //图片上传
                        goto case "single-text";
                    case "number": //数字
                        goto case "single-text";
                    case "checkbox": //复选框
                        CheckBox cbControl = new CheckBox();
                        cbControl.ID = "field_control_" + modelt.name;
                        //默认值
                        if (modelt.default_value == "1")
                        {
                            cbControl.Checked = true;
                        }
                        HtmlGenericControl htmlDiv1 = new HtmlGenericControl("div");
                        htmlDiv1.Attributes.Add("class", "rule-single-checkbox");
                        htmlDiv1.Controls.Add(cbControl);
                        //将控件添加至DD中
                        htmlDD.Controls.Add(htmlDiv1);
                        if (!string.IsNullOrEmpty(modelt.valid_tip_msg))
                        {
                            //创建一个Label控件
                            Label labelControl3 = new Label();
                            labelControl3.CssClass = "Validform_checktip";
                            labelControl3.Text = modelt.valid_tip_msg;
                            htmlDD.Controls.Add(labelControl3);
                        }
                        break;
                    case "multi-radio": //多项单选
                        RadioButtonList rblControl = new RadioButtonList();
                        rblControl.ID = "field_control_" + modelt.name;
                        rblControl.RepeatDirection = RepeatDirection.Horizontal;
                        rblControl.RepeatLayout = RepeatLayout.Flow;
                        HtmlGenericControl htmlDiv2 = new HtmlGenericControl("div");
                        htmlDiv2.Attributes.Add("class", "rule-multi-radio");
                        htmlDiv2.Controls.Add(rblControl);
                        //赋值选项
                        string[] valArr = modelt.item_option.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                        for (int i = 0; i < valArr.Length; i++)
                        {
                            string[] valItemArr = valArr[i].Split('|');
                            if (valItemArr.Length == 2)
                            {
                                rblControl.Items.Add(new ListItem(valItemArr[0], valItemArr[1]));
                            }
                        }
                        rblControl.SelectedValue = modelt.default_value; //默认值
                        //创建一个Label控件
                        Label labelControl4 = new Label();
                        labelControl4.CssClass = "Validform_checktip";
                        labelControl4.Text = modelt.valid_tip_msg;
                        //将控件添加至DD中
                        htmlDD.Controls.Add(htmlDiv2);
                        htmlDD.Controls.Add(labelControl4);
                        break;
                    case "multi-checkbox": //多项多选
                        CheckBoxList cblControl = new CheckBoxList();
                        cblControl.ID = "field_control_" + modelt.name;
                        cblControl.RepeatDirection = RepeatDirection.Horizontal;
                        cblControl.RepeatLayout = RepeatLayout.Flow;
                        HtmlGenericControl htmlDiv3 = new HtmlGenericControl("div");
                        htmlDiv3.Attributes.Add("class", "rule-multi-checkbox");
                        htmlDiv3.Controls.Add(cblControl);
                        //赋值选项
                        string[] valArr2 = modelt.item_option.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                        for (int i = 0; i < valArr2.Length; i++)
                        {
                            string[] valItemArr2 = valArr2[i].Split('|');
                            if (valItemArr2.Length == 2)
                            {
                                cblControl.Items.Add(new ListItem(valItemArr2[0], valItemArr2[1]));
                            }
                        }
                        cblControl.SelectedValue = modelt.default_value; //默认值
                        //创建一个Label控件
                        Label labelControl5 = new Label();
                        labelControl5.CssClass = "Validform_checktip";
                        labelControl5.Text = modelt.valid_tip_msg;
                        //将控件添加至DD中
                        htmlDD.Controls.Add(htmlDiv3);
                        htmlDD.Controls.Add(labelControl5);
                        break;
                }

                //将DT和DD添加到DL中
                htmlDL.Controls.Add(htmlDT);
                htmlDL.Controls.Add(htmlDD);
                //将DL添加至field_tab_content中
                Panel1.Controls.Add(htmlDL);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region 扩展字段赋值=============================
    private Dictionary<string, string> SetFieldValues(int _channel_id)
    {

        DataTable dt = new Cms.BLL.C_article_attribute_field().GetList(_channel_id, "").Tables[0];
        Dictionary<string, string> dic = new Dictionary<string, string>();
        foreach (DataRow dr in dt.Rows)
        {
            //查找相应的控件
            switch (dr["control_type"].ToString())
            {
                case "single-text": //单行文本
                    TextBox txtControl = FindControl("field_control_" + dr["name"].ToString()) as TextBox;
                    if (txtControl != null)
                    {
                        dic.Add(dr["name"].ToString(), txtControl.Text.Trim());

                    }
                    break;
                case "multi-text": //多行文本
                    goto case "single-text";
                case "editor": //编辑器
                    HtmlTextArea htmlTextAreaControl = FindControl("field_control_" + dr["name"].ToString()) as HtmlTextArea;
                    if (htmlTextAreaControl != null)
                    {
                        dic.Add(dr["name"].ToString(), htmlTextAreaControl.Value);
                    }
                    break;
                case "images": //图片上传
                    goto case "single-text";
                case "number": //数字
                    goto case "single-text";
                case "checkbox": //复选框
                    CheckBox cbControl = FindControl("field_control_" + dr["name"].ToString()) as CheckBox;
                    if (cbControl != null)
                    {
                        if (cbControl.Checked == true)
                        {
                            dic.Add(dr["name"].ToString(), "1");
                        }
                        else
                        {
                            dic.Add(dr["name"].ToString(), "0");
                        }
                    }
                    break;
                case "multi-radio": //多项单选
                    RadioButtonList rblControl = FindControl("field_control_" + dr["name"].ToString()) as RadioButtonList;
                    if (rblControl != null)
                    {
                        dic.Add(dr["name"].ToString(), rblControl.SelectedValue);
                    }
                    break;
                case "multi-checkbox": //多项多选
                    CheckBoxList cblControl = FindControl("field_control_" + dr["name"].ToString()) as CheckBoxList;
                    if (cblControl != null)
                    {
                        StringBuilder tempStr = new StringBuilder();
                        for (int i = 0; i < cblControl.Items.Count; i++)
                        {
                            if (cblControl.Items[i].Selected)
                            {
                                tempStr.Append(cblControl.Items[i].Value.Replace(',', '，') + ",");
                            }
                        }
                        dic.Add(dr["name"].ToString(), Utils.DelLastComma(tempStr.ToString()));
                    }
                    break;
            }
        }
        return dic;
    }
    #endregion

    #region 获取栏目的内容调用地址==============================================
    public string getconturl(int classid)
    {
        string result = "";
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        DataSet ds = bllColumn.GetList("classId=" + classid);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            //result = ds.Tables[0].Rows[0]["contentUrl"].ToString();
        }
        return result;
    }
    #endregion

    #region 赋值操作==========================================
    public void DataBind(int articleId)
    {
        Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
        Cms.Model.C_article model = bllarticle.GetModel(articleId);
        this.parentId.SelectedValue = model.parentId.ToString();//所属栏目、分类ID

        #region 基本信息
        this.isHidden.SelectedValue = model.isHidden.ToString(); //显示状态
        if (model.isTop.ToString() == "1")
        {
            cblItem.Items[0].Selected = true; //1 置顶
        }
        if (model.isRecommend.ToString() == "1")
        {
            cblItem.Items[1].Selected = true; //1 推荐
        }
        if (model.isHot.ToString() == "1")
        {
            cblItem.Items[2].Selected = true; //1 属于热门
        }
        if (model.is_msg.ToString() == "1")
        {
            cblItem.Items[3].Selected = true; //1 属于评论
        }
        if (model.is_slide.ToString() == "1")
        {
            cblItem.Items[4].Selected = true; //1 属于幻灯片
        }
        this.Title.Text = model.title.ToString();//标题
        this.photoUrl.Text = model.photoUrl.ToString(); //缩略图
        this.photoUrlImg.ImageUrl = model.photoUrl.ToString();
        this.orderNumber.Text = model.orderNumber.ToString();//排序
        this.hits.Text = model.hits.ToString(); //浏览次数
        this.updateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", model.updateTime);//添加时间
        this.Attachment.Value = model.Attachment.ToString();//附件文件名



        this.txtLinkUrl.Text = model.txtLinkUrl.ToString();//外链接
        this.txtsource.Text = model.txtsource.ToString();//来源
        this.txtauthor.Text = model.txtauthor.ToString();//作者
        this.intro.Text = model.intro.ToString();//简介
        this.content.Value = model.content.ToString();//内容
        this.seoTitle.Text = model.seoTitle.ToString();//SEO标题
        this.seoKeyword.Text = model.seoKeyword.ToString();//SEO关健字
        this.seoDescription.Text = model.seoDescription.ToString();//SEO描述

        this.w_LinkUrl.Text = model.w_LinkUrl.ToString();//手机站URL链接
        this.w_intro.Text = model.w_intro.ToString();//手机站简介
        this.w_content.Value = model.w_content.ToString();//手机站内容

        this.englishtitle.Text = model.englishtitle.ToString();//英文标题
        this.e_LinkUrl.Text = model.e_LinkUrl.ToString();//英文URL链接
        this.e_source.Text = model.e_source.ToString();//英文信息来源
        this.e_author.Text = model.e_author.ToString();//英文信息作者
        this.e_intro.Text = model.e_intro.ToString();//英文信息简介
        this.e_content.Value = model.e_content.ToString();//英文信息内容
        this.e_seoTitle.Text = model.e_seoTitle.ToString();//英文SEO标题
        this.e_seoKeyword.Text = model.e_seoKeyword.ToString();//英文SEO关健字
        this.e_seoDescription.Text = model.e_seoDescription.ToString();//英文SEO描述
        #endregion

        #region 扩展字段赋值=================================
        List<Cms.Model.C_article_attribute_field> ls1 = new Cms.BLL.C_article_attribute_field().GetModelList(Convert.ToInt32(this.classid), "");
        foreach (Cms.Model.C_article_attribute_field modelt1 in ls1)
        {
            switch (modelt1.control_type)
            {
                case "single-text": //单行文本
                    TextBox txtControl = FindControl("field_control_" + modelt1.name) as TextBox;
                    if (txtControl != null && model.fields.ContainsKey(modelt1.name))
                    {
                        if (modelt1.is_password == 1)
                        {
                            txtControl.Attributes.Add("value", model.fields[modelt1.name]);
                        }
                        else
                        {
                            txtControl.Text = model.fields[modelt1.name];
                        }
                    }
                    break;
                case "multi-text": //多行文本
                    goto case "single-text";
                case "editor": //编辑器
                    HtmlTextArea txtAreaControl = FindControl("field_control_" + modelt1.name) as HtmlTextArea;
                    if (txtAreaControl != null && model.fields.ContainsKey(modelt1.name))
                    {
                        txtAreaControl.Value = model.fields[modelt1.name];
                    }
                    break;
                case "images": //图片上传
                    goto case "single-text";
                case "number": //数字
                    goto case "single-text";
                case "checkbox": //复选框
                    CheckBox cbControl = FindControl("field_control_" + modelt1.name) as CheckBox;
                    if (cbControl != null && model.fields.ContainsKey(modelt1.name))
                    {
                        if (model.fields[modelt1.name] == "1")
                        {
                            cbControl.Checked = true;
                        }
                        else
                        {
                            cbControl.Checked = false;
                        }
                    }
                    break;
                case "multi-radio": //多项单选
                    RadioButtonList rblControl = FindControl("field_control_" + modelt1.name) as RadioButtonList;
                    if (rblControl != null && model.fields.ContainsKey(modelt1.name))
                    {
                        rblControl.SelectedValue = model.fields[modelt1.name];
                    }
                    break;
                case "multi-checkbox": //多项多选
                    CheckBoxList cblControl = FindControl("field_control_" + modelt1.name) as CheckBoxList;
                    if (cblControl != null && model.fields.ContainsKey(modelt1.name))
                    {
                        string[] valArr = model.fields[modelt1.name].Split(',');
                        for (int i = 0; i < cblControl.Items.Count; i++)
                        {
                            cblControl.Items[i].Selected = false; //先取消默认的选中
                            foreach (string str in valArr)
                            {
                                if (cblControl.Items[i].Value == str)
                                {
                                    cblControl.Items[i].Selected = true;
                                }
                            }
                        }
                    }
                    break;
            }
        }
        #endregion

        #region 相册==============================
        //不是相册图片就绑定
        string filename = model.photoUrl.Substring(model.photoUrl.LastIndexOf("/") + 1);
        //绑定图片相册

        hidFocusPhoto.Value = model.photoUrl; //封面图片

        rptAlbumList.DataSource = model.albums;
        rptAlbumList.DataBind();
        //绑定内容附件
        rptAttachList.DataSource = model.attach;
        rptAttachList.DataBind();
        #endregion

        #region 产品信息==================================
        DataTable dt = new Cms.BLL.C_article_product().GetList("article_id=" + articleId).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            price.Text = Convert.ToDecimal(dt.Rows[0]["price"]).ToString("0.00");
            marketPrice.Text = Convert.ToDecimal(dt.Rows[0]["marketPrice"]).ToString("0.00");
            integral.Text = dt.Rows[0]["integral"].ToString();
            stock.Text = dt.Rows[0]["stock"].ToString();
            productId.Value = dt.Rows[0]["id"].ToString();
            


           
        }
        #endregion
    }
    #endregion

    #region 添加信息=================================
    public void DataAdd()
    {
        Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
        Cms.Model.C_article modelarticle = new Cms.Model.C_article();

        #region 基本信息

        modelarticle.parentId = Convert.ToInt32(this.parentId.SelectedValue);//所属栏目、分类ID
        modelarticle.isHidden = Convert.ToInt32(this.isHidden.SelectedValue);//显示状态
        modelarticle.isTop = 0;//0 不置顶
        modelarticle.isRecommend = 0;//0 不推荐
        modelarticle.isHot = 0;//不属于热门
        if (cblItem.Items[0].Selected == true)
        {
            modelarticle.isTop = 1;//1 置顶
        }
        if (cblItem.Items[1].Selected == true)
        {
            modelarticle.isRecommend = 1;//1 推荐
        }
        if (cblItem.Items[2].Selected == true)
        {
            modelarticle.isHot = 1;//1 属于热门
        }
        if (cblItem.Items[3].Selected == true)
        {
            modelarticle.is_msg = 1;//1 属于评论
        }
        if (cblItem.Items[4].Selected == true)
        {
            modelarticle.is_slide = 1;//1 属于幻灯片
        }

        modelarticle.title = this.Title.Text.Trim();//标题
        if (this.photoUrl.Text == "")
        {
            modelarticle.photoUrl = "/img/noPic.jpg";
        }
        else
        {
            modelarticle.photoUrl = this.photoUrl.Text;//缩略图
        }
        modelarticle.orderNumber = Convert.ToInt32(this.orderNumber.Text.Trim());//排序
        modelarticle.hits = Convert.ToInt32(this.hits.Text.Trim());//浏览次数
        modelarticle.updateTime = Utils.StrToDateTime(updateTime.Text.Trim());//添加时间
        modelarticle.Attachment = this.Attachment.Value;//附件文件
        modelarticle.txtLinkUrl = this.txtLinkUrl.Text.Trim();//外链接
        modelarticle.txtsource = this.txtsource.Text.Trim();//来源
        modelarticle.txtauthor = this.txtauthor.Text.Trim();//作者


        modelarticle.intro = this.intro.Text;//简介
        modelarticle.content = this.content.Value;//内容
        modelarticle.seoTitle = this.seoTitle.Text.Trim();//SEO标题
        modelarticle.seoKeyword = this.seoKeyword.Text.Trim();//SEO关健字
        modelarticle.seoDescription = this.seoDescription.Text.Trim();//SEO描述

        modelarticle.w_LinkUrl = this.w_LinkUrl.Text;//手机站URL链接
        modelarticle.w_intro = this.w_intro.Text;//手机站简介
        modelarticle.w_content = this.w_content.Value;//手机站内容

        modelarticle.englishtitle = this.englishtitle.Text;//英文标题
        modelarticle.e_source = this.e_source.Text;//英文站信息来源
        modelarticle.e_author = this.e_author.Text;//英文站信息作者
        modelarticle.e_LinkUrl = this.e_LinkUrl.Text;//英文站链接

        modelarticle.e_intro = this.e_intro.Text;//英文站简介
        modelarticle.e_content = this.e_content.Value;//英文站内容
        modelarticle.e_seoTitle = this.e_seoTitle.Text.Trim();//英文站SEO标题
        modelarticle.e_seoKeyword = this.e_seoKeyword.Text.Trim();//英文站SEO关健字
        modelarticle.e_seoDescription = this.e_seoDescription.Text.Trim();//英文站SEO描述
        int channelID = Convert.ToInt32(this.parentId.SelectedValue);
        string channel_name = bllcolumn.GetModel(channelID).className.ToString();
        modelarticle.fields = SetFieldValues(channelID); //扩展字段赋值

        #endregion

        #region 保存相册====================
        //检查是否有自定义图片
        if (photoUrl.Text.Trim() == "")
        {
            modelarticle.photoUrl = hidFocusPhoto.Value;
        }
        string[] albumArr = Request.Form.GetValues("hid_photo_name");
        string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
        if (albumArr != null && albumArr.Length > 0)
        {
            List<Cms.Model.C_article_albums> ls = new List<Cms.Model.C_article_albums>();
            for (int i = 0; i < albumArr.Length; i++)
            {
                string[] imgArr = albumArr[i].Split('|');
                if (imgArr.Length == 3)
                {
                    if (!string.IsNullOrEmpty(remarkArr[i]))
                    {
                        ls.Add(new Cms.Model.C_article_albums { original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                    }
                    else
                    {
                        ls.Add(new Cms.Model.C_article_albums { original_path = imgArr[1], thumb_path = imgArr[2] });
                    }
                }
            }
            modelarticle.albums = ls;
        }
        #endregion

        #region 保存附件====================
        //保存附件
        string[] attachFileNameArr = Request.Form.GetValues("hid_attach_filename");
        string[] attachFilePathArr = Request.Form.GetValues("hid_attach_filepath");
        string[] attachFileSizeArr = Request.Form.GetValues("hid_attach_filesize");
        string[] attachPointArr = Request.Form.GetValues("txt_attach_point");
        if (attachFileNameArr != null && attachFilePathArr != null && attachFileSizeArr != null && attachPointArr != null
            && attachFileNameArr.Length > 0 && attachFilePathArr.Length > 0 && attachFileSizeArr.Length > 0 && attachPointArr.Length > 0)
        {
            List<Cms.Model.C_article_attach> ls = new List<Cms.Model.C_article_attach>();
            for (int i = 0; i < attachFileNameArr.Length; i++)
            {
                int fileSize = Utils.StrToInt(attachFileSizeArr[i], 0);
                string fileExt = Utils.GetFileExt(attachFilePathArr[i]);
                int _point = Utils.StrToInt(attachPointArr[i], 0);
                ls.Add(new Cms.Model.C_article_attach { file_name = attachFileNameArr[i], file_path = attachFilePathArr[i], file_size = fileSize, file_ext = fileExt, point = _point });
            }
            modelarticle.attach = ls;
        }
        #endregion

        int result = bllarticle.Add(modelarticle);
        if (result > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), channel_name + ":" + modelarticle.title); //记录日志

            #region 产品信息=====================
            Cms.BLL.C_article_product bllProduct = new Cms.BLL.C_article_product();
            Cms.Model.C_article_product modelProduct = new Cms.Model.C_article_product();
            modelProduct.article_id = result;
            modelProduct.price = Convert.ToDecimal(price.Text.Trim());
            modelProduct.marketPrice = Convert.ToDecimal(marketPrice.Text.Trim());
            modelProduct.integral = Convert.ToInt32(integral.Text);
            modelProduct.stock = Convert.ToInt32(stock.Text);
            modelProduct.is_integral = Convert.ToInt32(0);
            modelProduct.s_version = Convert.ToInt32(0);

            


            bllProduct.Add(modelProduct);
            #endregion

            JscriptMsg("添加信息成功！", "productList.aspx?classid=" + this.parentId.SelectedValue, "Success");
        }
        else
        {
            JscriptMsg("添加信息失败！", "productEdit.aspx?action=add&classid=" + this.parentId.SelectedValue, "Error");
        }
    }
    #endregion

    #region 修改信息=================================
    public void DataUpdate(int articleId)
    {
        Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
        Cms.Model.C_article modelarticle = new Cms.Model.C_article();

        #region 基本信息

        modelarticle.articleId = articleId;//文章ID
        modelarticle.parentId = Convert.ToInt32(this.parentId.SelectedValue);//所属栏目、分类ID
        modelarticle.isHidden = Convert.ToInt32(this.isHidden.SelectedValue);//显示状态
        modelarticle.isTop = 0;//0 不置顶
        modelarticle.isRecommend = 0;//0 不推荐
        modelarticle.isHot = 0;//不属于热门
        if (cblItem.Items[0].Selected == true)
        {
            modelarticle.isTop = 1;//1 置顶
        }
        if (cblItem.Items[1].Selected == true)
        {
            modelarticle.isRecommend = 1;//1 推荐
        }
        if (cblItem.Items[2].Selected == true)
        {
            modelarticle.isHot = 1;//1 属于热门
        }
        if (cblItem.Items[3].Selected == true)
        {
            modelarticle.is_msg = 1;//1 属于评论
        }
        if (cblItem.Items[4].Selected == true)
        {
            modelarticle.is_slide = 1;//1 属于幻灯片
        }
        modelarticle.title = this.Title.Text.Trim();//标题
        if (this.photoUrl.Text == "")
        {
            modelarticle.photoUrl = "/img/noPic.jpg";
        }
        else
        {
            modelarticle.photoUrl = this.photoUrl.Text;//缩略图
        }
        modelarticle.orderNumber = Convert.ToInt32(this.orderNumber.Text.Trim());//排序
        modelarticle.hits = Convert.ToInt32(this.hits.Text.Trim());//浏览次数
        modelarticle.updateTime = Utils.StrToDateTime(updateTime.Text.Trim());//添加时间
        modelarticle.Attachment = this.Attachment.Value;//附件文件
        modelarticle.txtLinkUrl = this.txtLinkUrl.Text.Trim();//外链接
        modelarticle.txtsource = this.txtsource.Text.Trim();//来源
        modelarticle.txtauthor = this.txtauthor.Text.Trim();//作者



        modelarticle.intro = this.intro.Text;//简介
        modelarticle.content = this.content.Value;//内容
        modelarticle.seoTitle = this.seoTitle.Text.Trim();//SEO标题
        modelarticle.seoKeyword = this.seoKeyword.Text.Trim();//SEO关健字
        modelarticle.seoDescription = this.seoDescription.Text.Trim();//SEO描述

        modelarticle.w_LinkUrl = this.w_LinkUrl.Text;//手机站URL链接
        modelarticle.w_intro = this.w_intro.Text;//手机站简介
        modelarticle.w_content = this.w_content.Value;//手机站内容

        modelarticle.englishtitle = this.englishtitle.Text;//英文标题
        modelarticle.e_source = this.e_source.Text;//英文站信息来源
        modelarticle.e_author = this.e_author.Text;//英文站信息作者
        modelarticle.e_LinkUrl = this.e_LinkUrl.Text;//英文站链接

        modelarticle.e_intro = this.e_intro.Text;//英文站简介
        modelarticle.e_content = this.e_content.Value;//英文站内容
        modelarticle.e_seoTitle = this.e_seoTitle.Text.Trim();//英文站SEO标题
        modelarticle.e_seoKeyword = this.e_seoKeyword.Text.Trim();//英文站SEO关健字
        modelarticle.e_seoDescription = this.e_seoDescription.Text.Trim();//英文站SEO描述
        int channelID = Convert.ToInt32(this.parentId.SelectedValue);
        string channel_name = bllcolumn.GetModel(channelID).className.ToString();
        modelarticle.fields = SetFieldValues(channelID); //扩展字段赋值

        #endregion

        #region 保存相册====================
        //检查是否有自定义图片
        if (photoUrl.Text.Trim() == "")
        {
            modelarticle.photoUrl = hidFocusPhoto.Value;
        }
        if (modelarticle.albums != null)
        {
            modelarticle.albums.Clear();
        }
        string[] albumArr = Request.Form.GetValues("hid_photo_name");
        string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
        if (albumArr != null)
        {
            List<Cms.Model.C_article_albums> ls = new List<Cms.Model.C_article_albums>();
            for (int i = 0; i < albumArr.Length; i++)
            {
                string[] imgArr = albumArr[i].Split('|');
                int img_id = Utils.StrToInt(imgArr[0], 0);
                if (imgArr.Length == 3)
                {
                    if (!string.IsNullOrEmpty(remarkArr[i]))
                    {
                        ls.Add(new Cms.Model.C_article_albums { id = img_id, article_id = articleId, original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                    }
                    else
                    {
                        ls.Add(new Cms.Model.C_article_albums { id = img_id, article_id = articleId, original_path = imgArr[1], thumb_path = imgArr[2] });
                    }
                }
            }
            modelarticle.albums = ls;
        }
        #endregion

        #region 保存附件====================
        if (modelarticle.attach != null)
        {
            modelarticle.attach.Clear();
        }
        string[] attachIdArr = Request.Form.GetValues("hid_attach_id");
        string[] attachFileNameArr = Request.Form.GetValues("hid_attach_filename");
        string[] attachFilePathArr = Request.Form.GetValues("hid_attach_filepath");
        string[] attachFileSizeArr = Request.Form.GetValues("hid_attach_filesize");
        string[] attachPointArr = Request.Form.GetValues("txt_attach_point");
        if (attachIdArr != null && attachFileNameArr != null && attachFilePathArr != null && attachFileSizeArr != null && attachPointArr != null
            && attachIdArr.Length > 0 && attachFileNameArr.Length > 0 && attachFilePathArr.Length > 0 && attachFileSizeArr.Length > 0 && attachPointArr.Length > 0)
        {
            List<Cms.Model.C_article_attach> ls = new List<Cms.Model.C_article_attach>();
            for (int i = 0; i < attachFileNameArr.Length; i++)
            {
                int attachId = Utils.StrToInt(attachIdArr[i], 0);
                int fileSize = Utils.StrToInt(attachFileSizeArr[i], 0);
                string fileExt = Utils.GetFileExt(attachFilePathArr[i]);
                int _point = Utils.StrToInt(attachPointArr[i], 0);
                ls.Add(new Cms.Model.C_article_attach { id = attachId, article_id = articleId, file_name = attachFileNameArr[i], file_path = attachFilePathArr[i], file_size = fileSize, file_ext = fileExt, point = _point, });
            }
            modelarticle.attach = ls;
        }
        #endregion

        #region 产品信息=====================
        Cms.BLL.C_article_product bllProduct = new Cms.BLL.C_article_product();
        Cms.Model.C_article_product modelProduct = new Cms.Model.C_article_product();

        modelProduct.article_id = articleId;
        modelProduct.price = Convert.ToDecimal(price.Text.Trim());
        modelProduct.marketPrice = Convert.ToDecimal(marketPrice.Text.Trim());
        modelProduct.integral = Convert.ToInt32(integral.Text);
        modelProduct.stock = Convert.ToInt32(stock.Text);
        modelProduct.is_integral = Convert.ToInt32(0);
        modelProduct.s_version = Convert.ToInt32(0);

        
        
        if (productId.Value == "")
        {
            bllProduct.Add(modelProduct);
        }
        else
        {
            modelProduct.id = Convert.ToInt32(productId.Value);
            bllProduct.Update(modelProduct);
        }
        #endregion

        if (bllarticle.Update(modelarticle))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), channel_name + ":" + modelarticle.title); //记录日志
            JscriptMsg("修改信息成功！", "productList.aspx?classid=" + this.parentId.SelectedValue, "Success");
        }
        else
        {
            JscriptMsg("修改信息失败！", "productEdit.aspx?action=edit&classid=" + this.parentId.SelectedValue, "Error");
        }
    }
    #endregion

    #region 绑定栏目=================================
    public void DropList_Bind()
    {
        parentId.Items.Clear();
        //parentId.Items.Add(new ListItem("作为一级分类", "0"));
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet ds = bllcolumn.GetList("parentId=26");
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

    //public void DropList_Bind_type()
    //{
    //    type.Items.Clear();
    //    //parentId.Items.Add(new ListItem("作为一级分类", "0"));
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=6");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[i];
    //            ListItem item = new ListItem();
    //            item.Text = "" + dr["title"].ToString();
    //            item.Value = dr["id"].ToString();
    //            type.Items.Add(item);
    //            ChileNodeBind_type(dr, type, 2);
    //        }
    //    }
    //}
    //private void ChileNodeBind_type(DataRow drr, DropDownList parentId, int m)
    //{
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=4");
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {
    //        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        for (int j = 1; j <= m; j++)
    //        {
    //            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        }
    //        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    //        {
    //            DataRow dro = dss.Tables[0].Rows[k];
    //            string flag = "├";
    //            if (dss.Tables[0].Rows.Count == 1)
    //            {
    //                flag = "├";
    //            }
    //            else
    //            {
    //                if (k == 0)
    //                {
    //                    flag = "├";
    //                }
    //                if (k == dss.Tables[0].Rows.Count - 1)
    //                {
    //                    flag = "├";
    //                }
    //            }
    //            ListItem item = new ListItem();
    //            item.Text = s + flag + dro["title"].ToString();
    //            item.Value = dro["id"].ToString();
    //            parentId.Items.Add(item);
    //            ChileNodeBind(dro, parentId, m + 5);
    //        }
    //    }
    //}
    #endregion

    #region 提交操作============================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int articleId = Convert.ToInt32(this.Request.QueryString["articleId"] ?? "0");//栏目ID
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        switch (action)
        {
            case "add":
                this.DataAdd();
                break;
            case "edit":
                this.DataUpdate(articleId);
                break;
        }
    }
    #endregion

    #region 绑定分类==========================================================
    //#region 绑定净度分类=======================================
    //public void Bind_clarity()
    //{
    //    clarity.Items.Clear();
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=2");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[i];
    //            ListItem item = new ListItem();
    //            item.Text = "" + dr["title"].ToString();
    //            item.Value = dr["id"].ToString();

    //            clarity.Items.Add(item);
    //            ChileNodeBindclarity(dr, clarity, 2);
    //        }
    //    }
    //    clarity.Items[0].Selected = true;
    //}

    //private void ChileNodeBindclarity(DataRow drr, RadioButtonList parentId, int m)
    //{
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=2");
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {

    //        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        for (int j = 1; j <= m; j++)
    //        {
    //            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        }
    //        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    //        {
    //            DataRow dro = dss.Tables[0].Rows[k];
    //            string flag = "├";
    //            if (dss.Tables[0].Rows.Count == 1)
    //            {
    //                flag = "├";
    //            }
    //            else
    //            {
    //                if (k == 0)
    //                {
    //                    flag = "├";
    //                }
    //                if (k == dss.Tables[0].Rows.Count - 1)
    //                {
    //                    flag = "├";
    //                }
    //            }
    //            ListItem item = new ListItem();
    //            item.Text = s + flag + dro["title"].ToString();
    //            item.Value = dro["id"].ToString();

    //            parentId.Items.Add(item);

    //            ChileNodeBindclarity(dro, parentId, m + 5);
    //        }
    //    }
    //}


    //#endregion

    //#region 绑定指圈分类=======================================
    //public void Bind_finger_ring()
    //{
    //    finger_ring.Items.Clear();
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=3");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[i];
    //            ListItem item = new ListItem();
    //            item.Text = "" + dr["title"].ToString();
    //            item.Value = dr["id"].ToString();

    //            finger_ring.Items.Add(item);
    //            ChileNodeBindbard(dr, finger_ring, 2);
    //        }
    //    }
    //    //finger_ring.Items[0].Selected = true;
    //}

    //private void ChileNodeBindbard(DataRow drr, CheckBoxList parentId, int m)
    //{
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=3");
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {

    //        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        for (int j = 1; j <= m; j++)
    //        {
    //            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        }
    //        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    //        {
    //            DataRow dro = dss.Tables[0].Rows[k];
    //            string flag = "├";
    //            if (dss.Tables[0].Rows.Count == 1)
    //            {
    //                flag = "├";
    //            }
    //            else
    //            {
    //                if (k == 0)
    //                {
    //                    flag = "├";
    //                }
    //                if (k == dss.Tables[0].Rows.Count - 1)
    //                {
    //                    flag = "├";
    //                }
    //            }
    //            ListItem item = new ListItem();
    //            item.Text = s + flag + dro["title"].ToString();
    //            item.Value = dro["id"].ToString();

    //            parentId.Items.Add(item);

    //            ChileNodeBindbard(dro, parentId, m + 5);
    //        }
    //    }
    //}
    //#endregion

    //#region 绑定颜色分类=================================
    //public void Bind_color()
    //{
    //    color.Items.Clear();
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=1");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[i];
    //            ListItem item = new ListItem();
    //            item.Text = "" + dr["title"].ToString();
    //            item.Value = dr["id"].ToString();

    //            color.Items.Add(item);
    //            ChileNodeBindcolor(dr, color, 2);
    //        }
    //    }
    //    color.Items[0].Selected = true;
    //}

    //private void ChileNodeBindcolor(DataRow drr, RadioButtonList parentId, int m)
    //{
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=1");
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {

    //        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        for (int j = 1; j <= m; j++)
    //        {
    //            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        }
    //        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    //        {
    //            DataRow dro = dss.Tables[0].Rows[k];
    //            string flag = "├";
    //            if (dss.Tables[0].Rows.Count == 1)
    //            {
    //                flag = "├";
    //            }
    //            else
    //            {
    //                if (k == 0)
    //                {
    //                    flag = "├";
    //                }
    //                if (k == dss.Tables[0].Rows.Count - 1)
    //                {
    //                    flag = "├";
    //                }
    //            }
    //            ListItem item = new ListItem();
    //            item.Text = s + flag + dro["title"].ToString();
    //            item.Value = dro["id"].ToString();

    //            parentId.Items.Add(item);

    //            ChileNodeBindcolor(dro, parentId, m + 5);
    //        }
    //    }
    //}
    //#endregion

    //#region 绑定形状分类=================================
    //public void Bind_shape()
    //{
    //    diamond_shape.Items.Clear();
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=5");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[i];
    //            ListItem item = new ListItem();
    //            item.Text = "" + dr["title"].ToString();
    //            item.Value = dr["id"].ToString();

    //            diamond_shape.Items.Add(item);
    //            ChileNodeBindshape(dr, diamond_shape, 2);
    //        }
    //    }
    //    diamond_shape.Items[0].Selected = true;
    //}

    //private void ChileNodeBindshape(DataRow drr, RadioButtonList parentId, int m)
    //{
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=5");
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {

    //        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        for (int j = 1; j <= m; j++)
    //        {
    //            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        }
    //        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    //        {
    //            DataRow dro = dss.Tables[0].Rows[k];
    //            string flag = "├";
    //            if (dss.Tables[0].Rows.Count == 1)
    //            {
    //                flag = "├";
    //            }
    //            else
    //            {
    //                if (k == 0)
    //                {
    //                    flag = "├";
    //                }
    //                if (k == dss.Tables[0].Rows.Count - 1)
    //                {
    //                    flag = "├";
    //                }
    //            }
    //            ListItem item = new ListItem();
    //            item.Text = s + flag + dro["title"].ToString();
    //            item.Value = dro["id"].ToString();

    //            parentId.Items.Add(item);

    //            ChileNodeBindcolor(dro, parentId, m + 5);
    //        }
    //    }
    //}
    //#endregion

    //#region 绑定切工=================================
    //public void Bind_cut()
    //{
    //    //cut.Items.Clear();
    //    //Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    //Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    //DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=4");
    //    //if (ds.Tables[0].Rows.Count > 0)
    //    //{
    //    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    //    {
    //    //        DataRow dr = ds.Tables[0].Rows[i];
    //    //        ListItem item = new ListItem();
    //    //        item.Text = "" + dr["title"].ToString();
    //    //        item.Value = dr["id"].ToString();

    //    //        cut.Items.Add(item);
    //    //        ChileNodeBindcut(dr, cut, 2);
    //    //    }
    //    }
    //   // cut.Items[0].Selected = true;
    //}

    ////private void ChileNodeBindcut(DataRow drr, RadioButtonList parentId, int m)
    ////{
    ////    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    ////    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    ////    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=4");
    ////    if (dss.Tables[0].Rows.Count > 0)
    ////    {

    ////        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    ////        for (int j = 1; j <= m; j++)
    ////        {
    ////            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    ////        }
    ////        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    ////        {
    ////            DataRow dro = dss.Tables[0].Rows[k];
    ////            string flag = "├";
    ////            if (dss.Tables[0].Rows.Count == 1)
    ////            {
    ////                flag = "├";
    ////            }
    ////            else
    ////            {
    ////                if (k == 0)
    ////                {
    ////                    flag = "├";
    ////                }
    ////                if (k == dss.Tables[0].Rows.Count - 1)
    ////                {
    ////                    flag = "├";
    ////                }
    ////            }
    ////            ListItem item = new ListItem();
    ////            item.Text = s + flag + dro["title"].ToString();
    ////            item.Value = dro["id"].ToString();

    ////            parentId.Items.Add(item);

    ////            ChileNodeBindcolor(dro, parentId, m + 5);
    ////        }
    ////    }
    ////}
    //#endregion

    //#region 绑定金属材质=================================
    //public void Bind_material()
    //{
    //    material.Items.Clear();
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=8");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[i];
    //            ListItem item = new ListItem();
    //            item.Text = "" + dr["title"].ToString();
    //            item.Value = dr["id"].ToString();

    //            material.Items.Add(item);
    //            ChileNodeBindmaterial(dr, cut, 2);
    //        }
    //    }
    //    material.Items[0].Selected = true;
    //}

    //private void ChileNodeBindmaterial(DataRow drr, RadioButtonList parentId, int m)
    //{
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=4");
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {

    //        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        for (int j = 1; j <= m; j++)
    //        {
    //            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        }
    //        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    //        {
    //            DataRow dro = dss.Tables[0].Rows[k];
    //            string flag = "├";
    //            if (dss.Tables[0].Rows.Count == 1)
    //            {
    //                flag = "├";
    //            }
    //            else
    //            {
    //                if (k == 0)
    //                {
    //                    flag = "├";
    //                }
    //                if (k == dss.Tables[0].Rows.Count - 1)
    //                {
    //                    flag = "├";
    //                }
    //            }
    //            ListItem item = new ListItem();
    //            item.Text = s + flag + dro["title"].ToString();
    //            item.Value = dro["id"].ToString();

    //            parentId.Items.Add(item);

    //            ChileNodeBindcolor(dro, parentId, m + 5);
    //        }
    //    }
    //}
    //#endregion

    //#region 绑定宝石分类=================================
    //public void Bind_bstype()
    //{
    //    bstype.Items.Clear();
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=9");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[i];
    //            ListItem item = new ListItem();
    //            item.Text = "" + dr["title"].ToString();
    //            item.Value = dr["id"].ToString();

    //            bstype.Items.Add(item);
    //            ChileNodeBindbstype(dr, cut, 2);
    //        }
    //    }
    //    bstype.Items[0].Selected = true;
    //}

    //private void ChileNodeBindbstype(DataRow drr, RadioButtonList parentId, int m)
    //{
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=4");
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {

    //        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        for (int j = 1; j <= m; j++)
    //        {
    //            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        }
    //        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    //        {
    //            DataRow dro = dss.Tables[0].Rows[k];
    //            string flag = "├";
    //            if (dss.Tables[0].Rows.Count == 1)
    //            {
    //                flag = "├";
    //            }
    //            else
    //            {
    //                if (k == 0)
    //                {
    //                    flag = "├";
    //                }
    //                if (k == dss.Tables[0].Rows.Count - 1)
    //                {
    //                    flag = "├";
    //                }
    //            }
    //            ListItem item = new ListItem();
    //            item.Text = s + flag + dro["title"].ToString();
    //            item.Value = dro["id"].ToString();

    //            parentId.Items.Add(item);

    //            ChileNodeBindcolor(dro, parentId, m + 5);
    //        }
    //    }
    //}
    //#endregion

    //#region 绑定品类=================================
    //public void Bind_pintype()
    //{
    //    pintype.Items.Clear();
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet ds = bllcolumn.GetList("parent_id=0 and channel_id=10");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[i];
    //            ListItem item = new ListItem();
    //            item.Text = "" + dr["title"].ToString();
    //            item.Value = dr["id"].ToString();

    //            pintype.Items.Add(item);
    //            ChileNodeBindpintype(dr, cut, 2);
    //        }
    //    }
    //    pintype.Items[0].Selected = true;
    //}

    //private void ChileNodeBindpintype(DataRow drr, RadioButtonList parentId, int m)
    //{
    //    Cms.BLL.C_article_category bllcolumn = new Cms.BLL.C_article_category();
    //    Cms.Model.C_article_category modelcolumn = new Cms.Model.C_article_category();
    //    DataSet dss = bllcolumn.GetList("parent_id=" + drr["id"] + "and channel_id=4");
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {

    //        string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        for (int j = 1; j <= m; j++)
    //        {
    //            s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
    //        }
    //        for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
    //        {
    //            DataRow dro = dss.Tables[0].Rows[k];
    //            string flag = "├";
    //            if (dss.Tables[0].Rows.Count == 1)
    //            {
    //                flag = "├";
    //            }
    //            else
    //            {
    //                if (k == 0)
    //                {
    //                    flag = "├";
    //                }
    //                if (k == dss.Tables[0].Rows.Count - 1)
    //                {
    //                    flag = "├";
    //                }
    //            }
    //            ListItem item = new ListItem();
    //            item.Text = s + flag + dro["title"].ToString();
    //            item.Value = dro["id"].ToString();

    //            parentId.Items.Add(item);

    //            ChileNodeBindcolor(dro, parentId, m + 5);
    //        }
    //    }
    //}
    //#endregion
    #endregion

    #region 提示框============================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}