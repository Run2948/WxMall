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

public partial class Admin_product_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Admin_product_edit));//注册Ajax可调用的类的名称
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        
        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;
            DropList_Bind();//绑定分类
            this.hreflist.HRef = "list.aspx";//设置返回列表链接
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    if (!new Cms.BLL.C_product().Exists(id))
                    {
                        JscriptMsg("不存在或已被删除！", "back", "Error");
                        return;
                    }
                    this.DataBind(id);//绑定信息
                    break;
            }
        }
        else
        {
            
        }
    }


    #region 赋值操作==========================================
    public void DataBind(int id)
    {
        Cms.Model.C_product model =  new Cms.BLL.C_product().GetModel(id);
        this.parentId.SelectedValue = model.typeId.ToString();//所属栏目、分类ID
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
        if (model.isActive.ToString() == "1")
        {
            cblItem.Items[3].Selected = true; //1 属于评论
        }
        this.Title.Text = model.name.ToString();//标题
        this.photoUrl.Text = model.litpic.ToString(); //缩略图
        this.photoUrlImg.ImageUrl = model.litpic.ToString();
        this.orderNumber.Text = model.sortId.ToString();//排序
        this.hits.Text = model.views.ToString(); //浏览次数
        this.updateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", model.createdTime);//添加时间
        this.intro.Text = model.intro.ToString();//简介
        this.content.Value = model.content.ToString();//内容
        this.seoTitle.Text = model.seoTitle.ToString();//SEO标题
        this.seoKeyword.Text = model.seoKeyword.ToString();//SEO关健字
        this.seoDescription.Text = model.seoDescription.ToString();//SEO描述
        this.sales.Text = model.sales.ToString();
        price.Text =Convert.ToDecimal(model.price).ToString("0.00");
        marketPrice.Text = Convert.ToDecimal(model.marketPrice).ToString("0.00");
        integral.Text = model.integral.ToString();
        stock.Text = model.stock.ToString();
        unit.Text = model.unit.ToString();
        manufactureDate.Text = model.manufactureDate.ToString();
        factoryName.Text = model.factoryName.ToString();
        factoryAddress.Text = model.factoryAddress.ToString();
        ingredients.Text = model.ingredients.ToString();
        

        #endregion
        #region 相册==============================
        //不是相册图片就绑定
        string filename = model.litpic.Substring(model.litpic.LastIndexOf("/") + 1);
        //绑定图片相册
        hidFocusPhoto.Value = model.litpic; //封面图片
        List<Cms.Model.c_product_albums> list = new List<Cms.Model.c_product_albums>();
        list = new Cms.BLL.c_product_albums().DataTableToList(Cms.DBUtility.DbHelperSQL.Query("select * from c_product_albums where productId="+id).Tables[0]);
        rptAlbumList.DataSource = list;
        rptAlbumList.DataBind();
        #endregion
    }
    #endregion

    #region 添加信息=================================
    public void DataAdd()
    {
        Cms.BLL.C_product bllarticle = new Cms.BLL.C_product();
        Cms.Model.C_product model = new Cms.Model.C_product();

        #region 基本信息
        model.typeId = Convert.ToInt32(this.parentId.SelectedValue);//所属栏目、分类ID
        model.isHidden = Convert.ToInt32(this.isHidden.SelectedValue);//显示状态
        model.isTop = 0;//0 不置顶
        model.isRecommend = 0;//0 不推荐
        model.isHot = 0;//不属于热门
        model.isActive = 0;
        if (cblItem.Items[0].Selected == true)
        {
            model.isTop = 1;//1 置顶
        }
        if (cblItem.Items[1].Selected == true)
        {
            model.isRecommend = 1;//1 推荐
        }
        if (cblItem.Items[2].Selected == true)
        {
            model.isHot = 1;//1 属于热门
        }
        if (cblItem.Items[3].Selected == true)
        {
            model.isActive = 1;//1 属于评论
        }

        model.name = this.Title.Text.Trim();//标题
        if (this.photoUrl.Text == "")
        {
            model.litpic = "/img/noPic.jpg";
        }
        else
        {
            model.litpic = this.photoUrl.Text;//缩略图
        }
        model.sortId = Convert.ToInt32(this.orderNumber.Text.Trim());//排序
        model.views = Convert.ToInt32(this.hits.Text.Trim());//浏览次数
        model.createdTime = Utils.StrToDateTime(updateTime.Text.Trim());//添加时间
        model.intro = this.intro.Text;//简介
        model.content = this.content.Value;//内容
        model.seoTitle = this.seoTitle.Text.Trim();//SEO标题
        model.seoKeyword = this.seoKeyword.Text.Trim();//SEO关健字
        model.seoDescription = this.seoDescription.Text.Trim();//SEO描述
        model.sales = Convert.ToInt32(sales.Text.Trim());
        model.price = Convert.ToDecimal(price.Text.Trim());
        model.marketPrice = Convert.ToDecimal(marketPrice.Text.Trim());
        model.integral = Convert.ToInt32(integral.Text);
        model.stock = Convert.ToInt32(stock.Text);
        model.unit = unit.Text;
        model.sVersion = Convert.ToInt32(0);
        model.manufactureDate=manufactureDate.Text;
        model.factoryName=factoryName.Text;
        model.factoryAddress=factoryAddress.Text;
        model.ingredients=ingredients.Text ;
        model.comments = 0;
        model.favorableRate = "0";
        #endregion
        int result = new Cms.BLL.C_product().Add(model);
        if (result > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), model.name); //记录日志
            #region 保存相册====================
            //检查是否有自定义图片
            if (photoUrl.Text.Trim() == "")
            {
                model.litpic = hidFocusPhoto.Value;
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null && albumArr.Length > 0)
            {
                List<Cms.Model.c_product_albums> ls = new List<Cms.Model.c_product_albums>();
                Cms.Model.c_product_albums modelAlbums = new Cms.Model.c_product_albums();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        modelAlbums.original_path = imgArr[1];
                        modelAlbums.thumb_path = imgArr[2];
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            modelAlbums.remark = remarkArr[i];
                        }
                        else
                        {
                        }
                        modelAlbums.productId = result;
                    }
                    new Cms.BLL.c_product_albums().Add(modelAlbums);
                }
            }
            #endregion
            JscriptMsg("添加信息成功！", "list.aspx", "Success");
        }
        else
        {
            JscriptMsg("添加信息失败！", "edit.aspx?action=add", "Error");
        }
    }
    #endregion

    #region 修改信息=================================
    public void DataUpdate(int id)
    {
        Cms.Model.C_product model = new Cms.BLL.C_product().GetModel(id);
        #region 基本信息
        model.id = id;
        model.typeId = Convert.ToInt32(this.parentId.SelectedValue);//所属栏目、分类ID
        model.isHidden = Convert.ToInt32(this.isHidden.SelectedValue);//显示状态
        model.isTop = 0;//0 不置顶
        model.isRecommend = 0;//0 不推荐
        model.isHot = 0;//不属于热门
        model.isActive = 0;
        if (cblItem.Items[0].Selected == true)
        {
            model.isTop = 1;//1 置顶
        }
        if (cblItem.Items[1].Selected == true)
        {
            model.isRecommend = 1;//1 推荐
        }
        if (cblItem.Items[2].Selected == true)
        {
            model.isHot = 1;//1 属于热门
        }
        if (cblItem.Items[3].Selected == true)
        {
            model.isActive = 1;//1 属于评论
        }
        model.name = this.Title.Text.Trim();//标题
        if (this.photoUrl.Text == "")
        {
            model.litpic = "/img/noPic.jpg";
        }
        else
        {
            model.litpic = this.photoUrl.Text;//缩略图
        }
        model.sortId = Convert.ToInt32(this.orderNumber.Text.Trim());//排序
        model.views = Convert.ToInt32(this.hits.Text.Trim());//浏览次数
        model.createdTime = Utils.StrToDateTime(updateTime.Text.Trim());//添加时间
        model.intro = this.intro.Text;//简介
        model.content = this.content.Value;//内容
        model.seoTitle = this.seoTitle.Text.Trim();//SEO标题
        model.seoKeyword = this.seoKeyword.Text.Trim();//SEO关健字
        model.seoDescription = this.seoDescription.Text.Trim();//SEO描述
        model.sales =Convert.ToInt32( sales.Text.Trim());
        model.price = Convert.ToDecimal(price.Text.Trim());
        model.marketPrice = Convert.ToDecimal(marketPrice.Text.Trim());
        model.integral = Convert.ToInt32(integral.Text);
        model.stock = Convert.ToInt32(stock.Text);
        model.unit = unit.Text;
        model.sVersion = Convert.ToInt32(0);
        model.manufactureDate = manufactureDate.Text;
        model.factoryName = factoryName.Text;
        model.factoryAddress = factoryAddress.Text;
        model.ingredients = ingredients.Text;
        #endregion
        if (new Cms.BLL.C_product().Update(model))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.name); //记录日志
            #region 保存相册====================
            int cout = Cms.DBUtility.DbHelperSQL.ExecuteSql("delete from c_product_albums where productId=" + model.id);
            //检查是否有自定义图片
            if (photoUrl.Text.Trim() == "")
            {
                model.litpic = hidFocusPhoto.Value;
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null && albumArr.Length > 0)
            {
                List<Cms.Model.c_product_albums> ls = new List<Cms.Model.c_product_albums>();
                Cms.Model.c_product_albums modelAlbums = new Cms.Model.c_product_albums();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        modelAlbums.original_path = imgArr[1];
                        modelAlbums.thumb_path = imgArr[2];
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            modelAlbums.remark = remarkArr[i];
                        }
                        else
                        {
                        }
                        modelAlbums.productId = model.id;
                    }
                    new Cms.BLL.c_product_albums().Add(modelAlbums);
                }
            }
            #endregion
            JscriptMsg("修改信息成功！", "list.aspx", "Success");
        }
        else
        {
            JscriptMsg("修改信息失败！", "edit.aspx?action=edit", "Error");
        }
    }
    #endregion

    #region 绑定栏目=================================
    public void DropList_Bind()
    {
        parentId.Items.Clear();
        //parentId.Items.Add(new ListItem("作为一级分类", "0"));
        Cms.BLL.C_type bll = new Cms.BLL.C_type();
        DataSet ds = bll.GetList("parent_id=0");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ListItem item = new ListItem();
                item.Text = "" + dr["title"].ToString();
                item.Value = dr["id"].ToString();
                parentId.Items.Add(item);
                ChileNodeBind(dr, parentId, 2);
            }
        }
    }
    private void ChileNodeBind(DataRow drr, DropDownList parentId, int m)
    {
        Cms.BLL.C_type bll = new Cms.BLL.C_type();
        DataSet dss = bll.GetList("parent_id=" + drr["id"] + "");
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

    #region 提交操作============================
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

  
    #region 提示框============================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}