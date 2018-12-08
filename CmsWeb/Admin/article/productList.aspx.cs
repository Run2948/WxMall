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

public partial class Admin_article_productList : System.Web.UI.Page
{
    public string classid = "";
    Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
    public DataSet ds;
    public SqlDataAdapter dr;
    protected string prolistview = string.Empty;
    protected string parentId = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.prolistview = Utils.GetCookie("article_list_view"); //显示方式
        classid = DTRequest.GetQueryString("classid"); //上级栏目ID
        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;
            setqx();
            string where = "select * from C_article where parentId=" + Convert.ToInt32(classid) + " order by articleId desc,ordernumber desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bllarticle.GetRecordCount("parentId=" + Convert.ToInt32(classid) + "");
            this.RepeaterDataBind(where);

        }
    }

    #region 保存排序=================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID
        Cms.BLL.C_article bll = new Cms.BLL.C_article();

        Repeater rptList = new Repeater();
        switch (this.prolistview)
        {
            case "Txt":
                rptList = this.rptList1;
                break;
            default:
                rptList = this.rptList2;
                break;
        }


        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("Fielddocid")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article set ordernumber=" + sortId + " where articleId='" + id + "'");//修改
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), bll.GetModel(id).title + "排序"); //记录日志
        }

        JscriptMsg("保存排序成功！", "productList.aspx?classid=" + classid, "Success");
    }
    #endregion

    #region 数据读取==================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_article");
        switch (this.prolistview)
        {
            case "Txt":
                this.rptList2.Visible = false;
                this.rptList1.DataSource = ds.Tables["C_article"];
                this.rptList1.DataBind();
                break;
            default:
                this.rptList1.Visible = false;
                this.rptList2.DataSource = ds.Tables["C_article"];
                this.rptList2.DataBind();
                break;
        }

    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int classid = Convert.ToInt32(this.Request.QueryString["classid"] ?? "0");//栏目ID
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_article where parentId=" + classid + " order by articleId desc,ordernumber desc";
        this.RepeaterDataBind(where.ToString());

    }

    public void rptList2_Bind(int strparentId)
    {
        Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
        Cms.Model.C_article modelarticle = new Cms.Model.C_article();
        DataSet ds = bllarticle.GetList("parentId=" + strparentId + "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            switch (this.prolistview)
            {
                case "Txt":
                    this.rptList2.Visible = false;
                    this.rptList1.DataSource = ds;
                    this.rptList1.DataBind();
                    break;
                default:
                    this.rptList1.Visible = false;
                    this.rptList2.DataSource = ds;
                    this.rptList2.DataBind();
                    break;
            }

        }
    }
    //设置文字列表显示
    protected void lbtnViewTxt_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("article_list_view", "Txt", 14400);
        Response.Redirect("productList.aspx?classid=" + this.classid.ToString());

    }

    //设置图文列表显示
    protected void lbtnViewImg_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("article_list_view", "Img", 14400);
        Response.Redirect("productList.aspx?classid=" + this.classid.ToString());

    }

    public string getPrice(string id)
    {
        string result = "";
        DataTable dt = new Cms.BLL.C_article_product().GetList("article_id=" + id).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            result = Convert.ToDecimal(dt.Rows[0]["price"]).ToString("0.00");
        }
        return result;
    }
  
    #endregion

    #region 批量删除=============================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID
        Repeater rptList = new Repeater();
        switch (this.prolistview)
        {
            case "Txt":
                rptList = this.rptList1;
                break;
            default:
                rptList = this.rptList2;
                break;
        }
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("Fielddocid") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                string title = bllarticle.GetModel(id).title.ToString();
                bllarticle.Delete(id);
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除：产品信息" + title); //记录日志
            }
        }
        JscriptMsg("删除信息成功！", "productList.aspx?classid=" + classid, "Success");
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
        classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID

        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr = "select * from C_article where parentId=" + classid + " and title like '%" + Keywords + "%' order by articleId desc";
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    #region 列表设置操作==============================================================
    protected void rptList2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("Fielddocid")).Value);
        Cms.BLL.C_article bll = new Cms.BLL.C_article();
        Cms.Model.C_article model = bll.GetModel(id);


        LinkButton lb = (LinkButton)e.Item.FindControl("lbedits");
        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        classid = DTRequest.GetQueryString("classid");
        string classname = cm.GetModel(int.Parse(classid)).className;
        bool blEdit = adminUser.setpurview(classname, "Edit");
        if (!blEdit)
        {
            lb.Visible = false;
        }

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
        classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID
        int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article set " + state + " where articleId='" + id + "'");//修改
        JscriptMsg("修改成功！", "productList.aspx?classid=" + classid, "Success");
    }
    #endregion

    #region 图文设置操作==============================================================
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("Fielddocid")).Value);

        Cms.BLL.C_article bll = new Cms.BLL.C_article();
        Cms.Model.C_article model = bll.GetModel(id);

        LinkButton lb = (LinkButton)e.Item.FindControl("lbedit");
        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classid = DTRequest.GetQueryString("classid");
        string classname = cm.GetModel(int.Parse(classid)).className;
        bool blEdit = adminUser.setpurview(classname, "Edit");
        if (!blEdit)
        {
            lb.Visible = false;
        }


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

    #endregion

    #region 新增操作=========================
    protected void btnadd_Click(object sender, EventArgs e)
    {
        classid = DTRequest.GetQueryString("classid");
        Response.Redirect("productEdit.aspx?action=add&classid=" + classid + "");
    }
    #endregion

    #region 设置权限=============================================
    /// <summary>
    /// 设置权限
    /// </summary>
    public void setqx()
    {
        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        classid = DTRequest.GetQueryString("classid");
        string classname = cm.GetModel(int.Parse(classid)).className;
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
        Response.Redirect("productEdit.aspx?action=edit&articleId=" + cid + "&classid=" + pid + "");
    }
    #endregion

    #region 商品导入==============
    protected void ToExcel_Click(object sender, EventArgs e)
    {
        //string strFileName = InputAffixFile.Value.Trim();//文件名
        //string strFileSize = (Convert.ToInt32(InputAffixFile.PostedFile.ContentLength.ToString()) / 1024).ToString();//文件大小
        //string strFileType = strFileName.Substring(strFileName.LastIndexOf(".") + 1).ToLower();//文件类型
        //string classid = Request.QueryString["classid"] ?? "0";
        //string fileName = "";
        //string FilePath = "";
        //if (strFileName != "")
        //{
        //    if (strFileType == "jpg" || strFileType == "psd" || strFileType == "swf" || strFileType == "gif " || strFileType == "bmp " || strFileType == "png " || strFileType == "xls" || strFileType == "doc" || strFileType == "pdf" || strFileType == "rar" || strFileType == "zip" || strFileType == "txt" || strFileType == "chm" || strFileType == "rtf" || strFileType == "docx" || strFileType == "wps" || strFileType == "xlsx" || strFileType == "et" || strFileType == "ppt" || strFileType == "pptx" || strFileType == "dps")
        //    {
        //        fileName = DateTime.Now.ToString("yyyMMddHHmmss") + "." + strFileType; ;//文件重命名
        //        Session["fileName"] = fileName;
        //        FilePath = System.Web.HttpContext.Current.Server.MapPath("~") + "//Upload//file";
        //        InputAffixFile.PostedFile.SaveAs(FilePath + "/" + fileName);
        //        string clientid = Session["fileName"].ToString();

        //        string CustTypeMin = "";
        //        string CustTypeSub = "";

        //        string sbResult = ExeclData(clientid, classid, CustTypeMin, CustTypeSub);
        //        JscriptMsg("导入成功！", "productList.aspx?classid=" + classid, "Success");
        //        //Response.Write("<Script Language=JavaScript>alert(\"导入成功！\")</Script>");
        //    }
        //    else
        //    {
        //        JscriptMsg("导入失败！", "productList.aspx?classid=" + classid, "Success");
        //        //Response.Write("<Script Language=JavaScript>alert(\"导入失败！\")</Script>");
        //    }
        //}
        //else
        //{
        //    JscriptMsg("请先点击浏览！", "productList.aspx?classid=" + classid, "Success");
        //    // Response.Write("<Script Language=JavaScript>alert(\"请先点击浏览！\")</Script>");
        //}
    }
    /// <summary>
    ///商品导入方法
    /// </summary>
    /// <param name="clientid"></param>
    /// <param name="CustTypeMax"></param>
    /// <param name="CustTypeMin"></param>
    /// <param name="CustTypeSub"></param>
    /// <returns></returns>
    public static string ExeclData(string clientid, string classid, string CustTypeMin, string CustTypeSub)
    {

        {

            //获取上传的菜单名称和路径
            string tempMenPath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\file\\" + clientid;//
            StringBuilder sbResult = new StringBuilder("");
            //string strconn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + tempMenPath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
            string strconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tempMenPath + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(strconn);
            conn.Open();
            string sql;
            sql = "SELECT * FROM [Sheet1$]";
            DataSet objDS = new DataSet();
            OleDbDataAdapter objadp = new OleDbDataAdapter(sql, conn);
            objadp.Fill(objDS);
            DataTable MenDt = objDS.Tables[0];
            conn.Close();
            int result = 0;
            foreach (DataRow dr in MenDt.Select())
            {
                try
                {
                    Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
                    Cms.Model.C_article modelarticle = new Cms.Model.C_article();
                    modelarticle.parentId = Convert.ToInt32(classid);//栏目id
                    modelarticle.title = dr[0].ToString();//标题
                    modelarticle.englishtitle = "";//英文标题
                    modelarticle.orderNumber = 0;//排序
                    modelarticle.photoUrl = "";//缩略图
                    modelarticle.intro = "";//简介
                    modelarticle.content = dr[1].ToString();//内容

                    modelarticle.seoTitle = "";//seo标题
                    modelarticle.seoKeyword = "";//seo关键词
                    modelarticle.seoDescription = "";//seo描述
                    modelarticle.isRecommend = 0;//推荐
                    modelarticle.isChannel = "";//栏目推荐
                    modelarticle.isHidden = 0;//是否隐藏
                    modelarticle.isCheck = 0;//是否审核发布
                    modelarticle.isHot = 0;//是否热门文章
                    modelarticle.isTop = 0;//是否置顶
                    modelarticle.is_msg = 0;
                    modelarticle.is_slide = 0;
                    modelarticle.hits = 1;//点击量
                    modelarticle.Attachment = "";
                    modelarticle.expClass = "";//
                    modelarticle.editTime = DateTime.Now;//最后编辑时间
                    modelarticle.updateTime = DateTime.Now;//添加时间
                    modelarticle.txtLinkUrl = "";
                    modelarticle.contentUrl = "";
                    modelarticle.txtsource = "";
                    modelarticle.txtauthor = "";

                    #region 手机|英文信息
                    modelarticle.w_LinkUrl = "";
                    modelarticle.w_contentUrl = "";
                    modelarticle.w_intro = "";
                    modelarticle.w_content = "";
                    modelarticle.e_LinkUrl = "";
                    modelarticle.e_contentUrl = "";
                    modelarticle.e_source = "";
                    modelarticle.e_author = "";
                    modelarticle.e_intro = "";
                    modelarticle.e_content = "";
                    modelarticle.e_seoTitle = "";
                    modelarticle.e_seoKeyword = "";
                    modelarticle.e_seoDescription = "";
                    string channel_name = new Cms.BLL.C_Column().GetModel(Convert.ToInt32(classid)).className.ToString();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("sub_title", "");
                    modelarticle.fields = dic; //扩展字段赋值
                    #endregion
                    result = bllarticle.Add(modelarticle);
                    if (result > 1)
                    {
                        #region 产品信息
                        Cms.BLL.C_article_product bll_product = new Cms.BLL.C_article_product();
                        Cms.Model.C_article_product model_product = new Cms.Model.C_article_product();
                        model_product.article_id = result;
                        model_product.price = Convert.ToDecimal(dr[2].ToString());
                        model_product.marketPrice = Convert.ToDecimal(dr[3].ToString());
                        model_product.integral = Convert.ToInt32(dr[4].ToString());
                        model_product.stock = Convert.ToInt32(dr[5].ToString());
                        model_product.is_integral = Convert.ToInt32(0);
                        model_product.s_version = Convert.ToInt32(0);

                       
                        #endregion
                        sbResult.Append("导入成功！ <br />");

                    }
                    else
                    {
                        sbResult.Append("导入失败！ <br />");
                    }

                }
                catch
                {

                    continue;
                }


            }

            return sbResult.ToString();

            //更新到数据库中

        }
    }
    #endregion

    #region 批量修改价格===========================
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //string classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID
        //Repeater rptList = new Repeater();
        //switch (this.prolistview)
        //{
        //    case "Txt":
        //        rptList = this.rptList1;
        //        break;
        //    default:
        //        rptList = this.rptList2;
        //        break;
        //}
        //try
        //{
        //    foreach (RepeaterItem item in rptList.Items)
        //    {
        //        //获取选择框
        //        CheckBox check = item.FindControl("Check_Select") as CheckBox;
        //        if (check.Checked)
        //        {
        //            HiddenField field = item.FindControl("Fielddocid") as HiddenField;
        //            int id = int.Parse(field.Value);

        //            string title = bllarticle.GetModel(id).title.ToString();
        //            DataTable dt = new Cms.BLL.C_article_product().GetList("article_id=" + id).Tables[0];
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                if (d_price.Text.ToString() != "")
        //                {
        //                    decimal dateTime_price = Convert.ToDecimal(d_price.Text.ToString());//当日金价
        //                    decimal labor_charges = Convert.ToDecimal(dt.Rows[0]["labor_charges"].ToString() == "" ? "0" : dt.Rows[0]["labor_charges"].ToString());//工费
        //                    decimal kim_joong = Convert.ToDecimal(dt.Rows[0]["kim_joong"].ToString() == "" ? "1" : dt.Rows[0]["kim_joong"].ToString());//金重
        //                    decimal accessories_price = Convert.ToDecimal(dt.Rows[0]["accessories_price"].ToString() == "" ? "0" : dt.Rows[0]["accessories_price"].ToString());//配件价
        //                    decimal sales_labor_charge = Convert.ToDecimal(dt.Rows[0]["sales_labor_charge"].ToString() == "" ? "0" : dt.Rows[0]["sales_labor_charge"].ToString());//销售工费

        //                    decimal price = ((dateTime_price + labor_charges) * kim_joong) + accessories_price + sales_labor_charge;
        //                    int count = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article_product set price='" + price + "' where article_id=" + id);
        //                    adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改价格：产品信息" + title); //记录日志
        //                }
        //                else
        //                {
        //                    JscriptMsg("请输入当日金价，谢谢！", "productList.aspx?classid=" + classid, "Error");
        //                }
        //            }

        //        }
        //    }
        //}
        //catch
        //{
        //    JscriptMsg("工费或者金重、配件价、销售工费不能为空！", "productList.aspx?classid=" + classid, "Error");
        //}
        //JscriptMsg("修改价格成功！", "productList.aspx?classid=" + classid, "Success");
    }

    //修改标价
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //string classid = this.Request.QueryString["classid"] ?? "";//上级栏目ID
        //Repeater rptList = new Repeater();
        //switch (this.prolistview)
        //{
        //    case "Txt":
        //        rptList = this.rptList1;
        //        break;
        //    default:
        //        rptList = this.rptList2;
        //        break;
        //}
        //try
        //{
        //    foreach (RepeaterItem item in rptList.Items)
        //    {
        //        //获取选择框
        //        CheckBox check = item.FindControl("Check_Select") as CheckBox;
        //        if (check.Checked)
        //        {
        //            HiddenField field = item.FindControl("Fielddocid") as HiddenField;
        //            int id = int.Parse(field.Value);

        //            string title = bllarticle.GetModel(id).title.ToString();
        //            DataTable dt = new Cms.BLL.C_article_product().GetList("article_id=" + id).Tables[0];
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                if (d_price.Text.ToString() != "")
        //                {
        //                    decimal dateTime_price = Convert.ToDecimal(d_price.Text.ToString());//当日金价
        //                    decimal labor_charges = Convert.ToDecimal(dt.Rows[0]["labor_charges"].ToString() == "" ? "0" : dt.Rows[0]["labor_charges"].ToString());//工费
        //                    decimal kim_joong = Convert.ToDecimal(dt.Rows[0]["kim_joong"].ToString() == "" ? "1" : dt.Rows[0]["kim_joong"].ToString());//金重
        //                    decimal accessories_price = Convert.ToDecimal(dt.Rows[0]["accessories_price"].ToString() == "" ? "0" : dt.Rows[0]["accessories_price"].ToString());//配件价
        //                    decimal sales_labor_charge = Convert.ToDecimal(dt.Rows[0]["sales_labor_charge"].ToString() == "" ? "0" : dt.Rows[0]["sales_labor_charge"].ToString());//销售工费

        //                    decimal price = ((dateTime_price + labor_charges) * kim_joong) + accessories_price + sales_labor_charge;
        //                    int count = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article_product set marketprice='" + price + "' ,gold_price='" + dateTime_price + "' where article_id=" + id);
        //                    adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改价格：产品信息" + title); //记录日志
        //                }
        //                else
        //                {
        //                    JscriptMsg("请输入当日金价，谢谢！", "productList.aspx?classid=" + classid, "Error");
        //                }
        //            }

        //        }
        //    }
        //}
        //catch
        //{
        //    JscriptMsg("工费或者金重、配件价、销售工费不能为空！", "productList.aspx?classid=" + classid, "Error");
        //}
        //JscriptMsg("修改价格成功！", "productList.aspx?classid=" + classid, "Success");
    }
    #endregion
}