using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Cms.DBUtility;


public partial class Tools_test : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //资料导入点击事件
    protected void Button1_Click(object sender, EventArgs e)
    {
        string clientid = Session["fileName"].ToString();
        string CustTypeMax = "";
        string CustTypeMin = "";
        string CustTypeSub = "";
        string sbResult = ExeclData(clientid, CustTypeMax, CustTypeMin, CustTypeSub);
        alert(sbResult);
        alert("导入成功!");
    }
    private void alert(string str)
    {

        Page.ClientScript.RegisterStartupScript(this.GetType(), " ", "<script>alert('" + HttpUtility.UrlDecode(str) + "')</script>");
    }

    //上传文件
    protected void Button2_Click(object sender, EventArgs e)
    {
        string strFileName = InputAffixFile.Value.Trim();//文件名
        string strFileSize = (Convert.ToInt32(InputAffixFile.PostedFile.ContentLength.ToString()) / 1024).ToString();//文件大小
        string strFileType = strFileName.Substring(strFileName.LastIndexOf(".") + 1).ToLower();//文件类型
        string fileName = "";
        string FilePath = "";
        if (strFileName != "")
        {
            if (strFileType == "jpg" || strFileType == "psd" || strFileType == "swf" || strFileType == "gif " || strFileType == "bmp " || strFileType == "png " || strFileType == "xls" || strFileType == "doc" || strFileType == "pdf" || strFileType == "rar" || strFileType == "zip" || strFileType == "txt" || strFileType == "chm" || strFileType == "rtf" || strFileType == "docx" || strFileType == "wps" || strFileType == "xlsx" || strFileType == "et" || strFileType == "ppt" || strFileType == "pptx" || strFileType == "dps")
            {
                fileName = DateTime.Now.ToString("yyyMMddHHmmss") + "." + strFileType; ;//文件重命名
                Session["fileName"] = fileName;
                FilePath = System.Web.HttpContext.Current.Server.MapPath("~") + "//Upload//file";
                InputAffixFile.PostedFile.SaveAs(FilePath + "/" + fileName);
                Response.Write("<Script Language=JavaScript>alert(\"上传文件成功！\")</Script>");
            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert(\"上传文件失败！\")</Script>");
            }
        }
        else
        {
            Response.Write("<Script Language=JavaScript>alert(\"请选择上传文件！\")</Script>");
        }
    }
    //资料导入方法
    public static string ExeclData(string clientid, string CustTypeMax, string CustTypeMin, string CustTypeSub)
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
                    modelarticle.parentId = 78;//栏目id
                    modelarticle.title = dr[2].ToString();//标题
                    modelarticle.englishtitle = "";//英文标题
                    modelarticle.orderNumber = 0;//排序

                    modelarticle.photoUrl = "";//缩略图

                    modelarticle.intro = "";//简介
                    modelarticle.content = dr[4].ToString();//内容

                    modelarticle.seoTitle = "";//seo标题
                    modelarticle.seoKeyword = "";//seo关键词
                    modelarticle.seoDescription = "";//seo描述
                    modelarticle.isRecommend = 1;//推荐
                    modelarticle.isChannel = "";//栏目推荐

                    modelarticle.isHidden = 1;//是否隐藏
                    modelarticle.isCheck = 1;//是否审核发布
                    modelarticle.isHot = 1;//是否热门文章


                    modelarticle.isTop = 1;//是否置顶
                    modelarticle.is_msg = 1;
                    modelarticle.is_slide = 1;
                    modelarticle.hits = 1;//点击量
                    modelarticle.Attachment = "";
                    modelarticle.expClass = "";//
                    modelarticle.editTime = DateTime.Now;//最后编辑时间
                    modelarticle.updateTime = DateTime.Now;//添加时间

                    modelarticle.txtLinkUrl = "";
                    modelarticle.contentUrl = "";
                    modelarticle.txtsource = "";
                    modelarticle.txtauthor = "";
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
                    //modelarticle.textParam1 = "";
                    //modelarticle.textParam2 = "";
                    //modelarticle.textParam3 = "";
                    //modelarticle.textParam4 = "";
                    //modelarticle.textParam5 = "";


                    result = bllarticle.Add(modelarticle);
                    if (result > 1)
                    {

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into C_article_attribute_value(");
                        strSql.Append("article_id,gra_time,card_id,cord_number)");
                        strSql.Append(" values (");
                        strSql.Append("@article_id,@gra_time,@card_id,@cord_number)");
                        SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@gra_time", SqlDbType.NVarChar,255),
					new SqlParameter("@card_id", SqlDbType.NVarChar,100),
					new SqlParameter("@cord_number", SqlDbType.NVarChar,50)};
                        parameters[0].Value = result;
                        parameters[1].Value = dr[5].ToString();
                        parameters[2].Value = dr[1].ToString();
                        parameters[3].Value = dr[3].ToString();

                        int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                        sbResult.Append("增加成功 <br />");

                    }
                    else
                    {
                        sbResult.Append("增加失败 <br />");
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
}