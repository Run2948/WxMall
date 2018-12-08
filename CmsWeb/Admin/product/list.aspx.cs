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

public partial class Admin_product_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;
            setqx();
            string where = "select * from C_product order by id desc,sortId desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = new Cms.BLL.C_product().GetRecordCount("");
            this.RepeaterDataBind(where);

        }
    }

    #region 保存排序=================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Repeater rptList = new Repeater();
        rptList = this.rptList1;
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("Fielddocid")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_product set sortId=" + sortId + " where id='" + id + "'");//修改
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), new Cms.BLL.C_product().GetModel(id).name + "排序"); //记录日志
        }

        JscriptMsg("保存排序成功！", "list.aspx", "Success");
    }
    #endregion

    #region 数据读取==================================
    public void RepeaterDataBind(string whereStr)
    {
        SqlDataAdapter dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        DataSet ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_product");
        this.rptList1.DataSource = ds.Tables["C_product"];
        this.rptList1.DataBind();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_product order by id desc,sortId desc";
        this.RepeaterDataBind(where.ToString());

    }

    public void rptList2_Bind(int strparentId)
    {
        DataSet ds = new Cms.BLL.C_product().GetList("");
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.rptList1.DataSource = ds;
            this.rptList1.DataBind();
        }
    }
    //设置文字列表显示
    protected void lbtnViewTxt_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("article_list_view", "Txt", 14400);
        Response.Redirect("list.aspx");

    }

    //设置图文列表显示
    protected void lbtnViewImg_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("article_list_view", "Img", 14400);
        Response.Redirect("list.aspx");

    }


    #endregion

    #region 批量删除=============================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Repeater rptList = new Repeater();
        rptList = this.rptList1;
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("Fielddocid") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
                string title = new Cms.BLL.C_product().GetModel(id).name.ToString();
                new Cms.BLL.C_product().Delete(id);
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除：产品信息" + title); //记录日志
            }
        }
        JscriptMsg("删除信息成功！", "list.aspx", "Success");
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
        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr = "select * from C_product where name like '%" + Keywords + "%' order by id desc";
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    #region 列表设置操作==============================================================
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("Fielddocid")).Value);
        Cms.Model.C_product model = new Cms.BLL.C_product().GetModel(id);
        LinkButton lb = (LinkButton)e.Item.FindControl("lbedit");
        switch (e.CommandName)
        {
            case "lbtnIsMsg":
                if (model.isActive == 1)
                    this.updateSate(id, "isActive=0");
                else
                    this.updateSate(id, "isActive=1");
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
                if (model.isHidden == 1)
                    this.updateSate(id, "isHidden=0");
                else
                    this.updateSate(id, "isHidden=1");
                break;
        }
    }
    public void updateSate(int id, string state)
    {
        int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_product set " + state + " where id='" + id + "'");//修改
        JscriptMsg("修改成功！", "list.aspx", "Success");
    }
    #endregion

    

    #region 新增操作=========================
    protected void btnadd_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("edit.aspx?action=add");
    }
    #endregion

    #region 设置权限=============================================
    /// <summary>
    /// 设置权限
    /// </summary>
    public void setqx()
    {
        Cms.BLL.C_Column cm = new Cms.BLL.C_Column();
        string classname = cm.GetModel(int.Parse("1")).className;
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
        Response.Redirect("edit.aspx?action=edit&id=" + cid + "");
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

    
}