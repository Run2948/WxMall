using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cms.Common;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.UI.WebControls;
/// <summary>
///ToAspx 的摘要说明
/// </summary>
public class ToAspx
{
	public ToAspx()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    #region 返回页面数据赋值=========================================
    public static string getActive(string style,string cuurId, int classid)
    {
        string result = "";
        if (cuurId != "0")
        {
            if (classid == Convert.ToInt32(cuurId))
            { result = style; }
            else
            {
                string classIdList = ToAspx.getcloumnid(classid);
                if (classIdList.IndexOf(cuurId) > -1)
                {
                    result = style;
                }
            }
        }
        return result;
    }
    public static string getActive(string cuurId, int classid,string active)
    {
        string result = "";
        if (classid == Convert.ToInt32(cuurId))
        { result = active; }
        else
        {
            string classIdList = ToAspx.getcloumnid(classid);
            if (classIdList.IndexOf(cuurId) > -1)
            {
                result = active;
            }
        }
        return result;
    }

    public static void RepeaterArticle(int top, int classId, Repeater rep)
    {
       
        string workname = new Cms.BLL.C_Column().GetModel(classId).name.ToString();
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by T.orderNumber desc,T.articleId desc )AS Row, T.*  from view_channel_" + workname + " T WHERE parentId=" + classId + "  ) TT WHERE TT.Row between 0 and " + top);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    public static void RepeaterArticleWhere(int top, int classId,string where, Repeater rep)
    {

        string workname = new Cms.BLL.C_Column().GetModel(classId).name.ToString();
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by T.orderNumber desc,T.articleId desc )AS Row, T.*  from view_channel_" + workname + " T WHERE parentId=" + classId + where + "  ) TT WHERE TT.Row between 0 and " + top);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    public static void RepeaterArticleWhere(int top, int classId, int parentId, string where, Repeater rep)
    {
        string classIdString = ToAspx.getcloumnid(parentId);
        string workname = new Cms.BLL.C_Column().GetModel(classId).name.ToString();
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by T.orderNumber desc,T.articleId desc )AS Row, T.*  from View_content T WHERE parentId in (" + classIdString + ") " + where + "  ) TT WHERE TT.Row between 0 and " + top);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    public static void RepeaterArticleClassIdString(int top, int classId, Repeater rep)
    {
        string classIdString = ToAspx.getcloumnid(classId);
        DataSet ds =  new Cms.BLL.C_article().GetList(top, "parentId in (" + classIdString + ") and ishidden=0", "ordernumber desc ,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    public static void RepeaterArticleClassIdString(int star,int end, int classId, Repeater rep)
    {
        string classIdString = ToAspx.getcloumnid(classId);
        DataSet ds = new Cms.BLL.C_article().GetListByPage( "parentId in (" + classIdString + ") and ishidden=0", "ordernumber desc ,articleId desc",star,end);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    public static void RepeaterArticleClassIdWhere(int top, int classId, string where, Repeater rep)
    {
        string classIdString = ToAspx.getcloumnid(classId);
        DataSet ds = new Cms.BLL.C_article().GetList(top, "parentId in (" + classIdString + ") and ishidden=0 " + where, "ordernumber desc ,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    public static void RepeaterCloumn(int id, Repeater rep)
    {
        DataSet dt = new Cms.BLL.C_Column().GetList("parentId=" + id + " and isShowChannel=1 order by orderNumber desc");//导航
        if (dt != null && dt.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = dt.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    public static void RepeaterArticleImgList(int id, Repeater rep)
    {
        DataSet dt = new Cms.BLL.C_article_albums().GetList("article_id=" + id + " order by id desc");//文章组图
        if (dt != null && dt.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = dt.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    public static void RepeaterMessage(int top, Repeater rep)
    {
        DataSet ds = new Cms.BLL.C_message().GetList(top, "", "messageid desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }
    #endregion

    #region 返回栏目信息=======================================
    public static Cms.Model.C_Column getCloumnName(int id)
    {
        Cms.Model.C_Column result;
        Cms.Model.C_Column model = new Cms.BLL.C_Column().GetModel(id);
        if (model.parentId == 26)
        {
            result = model;
        }
        else
        {
            Cms.Model.C_Column modelParent = new Cms.BLL.C_Column().GetModel(Convert.ToInt32(model.parentId));
            result = modelParent;
        }
        return result;
    }

    #endregion

    #region 返回文章信息=======================================
    public static string getArticle(int classId, int id, string value)
    {
        string result;
        string workname = new Cms.BLL.C_Column().GetModel(classId).name.ToString();
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query("SELECT * FROM  view_channel_" + workname + " WHERE articleId=" + id);
        if (ds.Tables[0].Rows.Count > 0 && ds != null)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            result = dr[value].ToString();//内容
        }
        else
        {
            result = "";//内容
        }
        return result;
    }

    #endregion

    #region 返回栏目url=========================================
    public static string getCloumnUrl(int id)
    {
        string result = "";
        Cms.Model.C_Column model = new Cms.BLL.C_Column().GetModel(id);
       
        if (model != null)
        {
            if (model.linkUrl != null && model.linkUrl == "")
            {
                if (model.modelId == 1)
                {
                    DataSet ds = new Cms.BLL.C_Column().GetList(1, "parentId=" + id, "orderNumber desc,classId asc");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        result = "/htm/" + ds.Tables[0].Rows[0]["tpl_channel"].ToString() + ".aspx?classId=" + ds.Tables[0].Rows[0]["classId"].ToString();
                    }
                }
                else
                {
                    result = "/htm/" + model.tplChannel + ".aspx?classId=" + id;
                }
            }
            else {
                result = model.linkUrl;
            }
        }
        return result;
    }
   
    #endregion

    #region 返回栏目的内容Url==========================================
    public static string getContentUrl(int id, int articleId)
    {
        string result = "";
        Cms.Model.C_Column model = new Cms.BLL.C_Column().GetModel(id);

        if (model != null)
        {
            result = "/htm/" + model.tplContent + ".aspx?classId=" + id + "&articleId=" + articleId;
        }
        return result;
    }

    #endregion

    #region 读取面包线===============
    public static string crumb(int classId)
    {
        string result = "<li class='house'> <a href='/'>首页</a> ></li> {parent} <li class='shicol'> <a href='{linkUrl}'>{className}</a></li>";
        Cms.Model.C_Column model = new Cms.BLL.C_Column().GetModel(classId);
        if (model != null)
        {
            result = result.Replace("{linkUrl}", ToAspx.getCloumnUrl(model.classId));
            result = result.Replace("{className}", model.className);
            result = result.Replace("{parent}", InitChildCrumb(Convert.ToInt32(model.parentId)));
        }
        return result;
    }
    private static string InitChildCrumb(int parentId)
    {
        string result = "";
       
        if (parentId != 26)
        {
            Cms.Model.C_Column modelParent = new Cms.BLL.C_Column().GetModel(parentId);
            if (modelParent != null)
            {
                string parent = "<li><a href='{parentUrl}'>{parentName}</a> ></li> ";
                parent = parent.Replace("{parentUrl}", ToAspx.getCloumnUrl(modelParent.classId));
                parent = parent.Replace("{parentName}", modelParent.className);
                result = parent + result;
                result = InitChildCrumb(Convert.ToInt32(modelParent.parentId)) + result;
                
            }

        }
        return result;
    }
    #endregion

    #region 左侧栏目导航递归==========================================
    public static string listNav(int classId)
    {
        string result = "";
        DataSet dt = new Cms.BLL.C_Column().GetList("parentId=" + getParentId(classId) + " and isShowChannel=1 order by orderNumber desc");
        dt.Tables[0].Columns.Add("Operate", typeof(string));//操作
        dt.Tables[0].Columns.Add("Colum", typeof(String));//在dt中增加字段名为Colum的列
        if (dt.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.Tables[0].Rows[i];
                string strchar = "";
                if (dr["classId"].ToString() == classId.ToString())
                {
                    strchar += " <li class='current'><a  href='" + getCloumnUrl(Convert.ToInt32(dr["classId"].ToString())) + "'>" + dr["className"] +"</a><div class='submenu'>";
                }
                else
                {
                    strchar += "<li><a  href='" + getCloumnUrl(Convert.ToInt32(dr["classId"].ToString())) + "'>" + dr["className"] + "</a><div class='submenu'>";
                }
                strchar += InitChildListNav(dr);
                strchar += "</div></li>";
                result = result+strchar;
            }
        }
        return result;
    }

    private static string InitChildListNav(DataRow dr)
    {
        DataSet dtt = new Cms.BLL.C_Column().GetList("parentId=" + dr["classid"] + " and isShowChannel=1 order by orderNumber desc");
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
                DataSet dtt1 = bllcolumn1.GetList("parentId=" + dro["classid"] + " and isShowChannel=1 order by orderNumber desc");
                if (dtt1.Tables[0].Rows.Count > 0)
                {
                    DataRow dro1 = dtt.Tables[0].Rows[k];
                    strchar += "<li class='current'><a  href='" + getCloumnUrl(Convert.ToInt32(dro1["classId"].ToString())) + "'>" + dro1["className"] + "</a><div class='submenu'>";
                    strchar += InitChildListNav(dro1);
                    strchar += "</div></li>";
                }
                else
                {
                    temp += "<a  href='" + getCloumnUrl(Convert.ToInt32(dro["classId"].ToString())) + "'><span>——</span> " + dro["className"].ToString() + "</a>";
                }
            }
        }
        return strchar + temp;
    }

    private static int getParentId(int classId)
    {
        int result = 26;
        Cms.Model.C_Column model=new Cms.BLL.C_Column().GetModel(classId);
        if (model.class_layer == 2)
        {
            result = model.classId;
        }
        else
        {
            result=getParentId(Convert.ToInt32( model.parentId));
        }

        return result;
    }


    #endregion

    #region 上一篇========================================
    public static string pre(int articleId)
    {
        string Temp = "<a href='{linkUrl}' title='{title}' class='zhleft_btn'><img src='images/zhleft.jpg' /></a>";
        DataSet ds = new Cms.BLL.C_article().GetList(1, "parentId='" + new Cms.BLL.C_article().GetModel(articleId).parentId + "' and articleId<" + articleId, "ordernumber desc ,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Temp = Temp.Replace("{linkUrl}", getContentUrl(Convert.ToInt32(ds.Tables[0].Rows[0]["parentId"]), Convert.ToInt32(ds.Tables[0].Rows[0]["articleId"])));
            Temp = Temp.Replace("{title}", ds.Tables[0].Rows[0]["title"].ToString());
            Temp = Temp.Replace("{pagenum}", ds.Tables[0].Rows[0]["title"].ToString());
        }
        else
        {
            Temp = Temp.Replace("{linkUrl}", "javascript:void(0);");
            Temp = Temp.Replace("{title}", "没有上一篇了");
            Temp = Temp.Replace("{pagenum}", "没有上一篇了");
            
        }
        return Temp;
    }
    public static string preWap(int articleId)
    {
        string Temp = "<a href='{linkUrl}' title='{title}' class='zhleft_btn'><div class='preview'>上一篇</div></a>";
        DataSet ds = new Cms.BLL.C_article().GetList(1, "parentId='" + new Cms.BLL.C_article().GetModel(articleId).parentId + "' and articleId<" + articleId, "ordernumber desc ,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Temp = Temp.Replace("{linkUrl}", getContentUrl(Convert.ToInt32(ds.Tables[0].Rows[0]["parentId"]), Convert.ToInt32(ds.Tables[0].Rows[0]["articleId"])));
            Temp = Temp.Replace("{title}", ds.Tables[0].Rows[0]["title"].ToString());
            Temp = Temp.Replace("{pagenum}", ds.Tables[0].Rows[0]["title"].ToString());
        }
        else
        {
            Temp = Temp.Replace("{linkUrl}", "javascript:void(0);");
            Temp = Temp.Replace("{title}", "没有上一篇了");
            Temp = Temp.Replace("{pagenum}", "没有上一篇了");

        }
        return Temp;
    }
    #endregion

    #region 下一篇========================================
    public static string next(int articleId)
    {
        string Temp = "<a href='{linkUrl}' title='{title}' class='zhright_btn'><img src='images/zhright.jpg' /></a>";
        DataSet ds = new Cms.BLL.C_article().GetList(1, "parentId='" + new Cms.BLL.C_article().GetModel(articleId).parentId + "' and articleId>" + articleId, "ordernumber desc ,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Temp = Temp.Replace("{linkUrl}", getContentUrl(Convert.ToInt32(ds.Tables[0].Rows[0]["parentId"]), Convert.ToInt32(ds.Tables[0].Rows[0]["articleId"])));
            Temp = Temp.Replace("{title}", ds.Tables[0].Rows[0]["title"].ToString());
            Temp = Temp.Replace("{pagenum}", ds.Tables[0].Rows[0]["title"].ToString());
        }
        else
        {
            Temp = Temp.Replace("{linkUrl}", "javascript:void(0);");
            Temp = Temp.Replace("{title}", "没有下一篇了");
            Temp = Temp.Replace("{pagenum}", "没有下一篇了");
        }
        return Temp;
    }
    public static string nextWap(int articleId)
    {
        string Temp = "<a href='{linkUrl}' title='{title}' class='zhright_btn'><div class='next'>下一篇</div></a>";
        DataSet ds = new Cms.BLL.C_article().GetList(1, "parentId='" + new Cms.BLL.C_article().GetModel(articleId).parentId + "' and articleId>" + articleId, "ordernumber desc ,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Temp = Temp.Replace("{linkUrl}", getContentUrl(Convert.ToInt32(ds.Tables[0].Rows[0]["parentId"]), Convert.ToInt32(ds.Tables[0].Rows[0]["articleId"])));
            Temp = Temp.Replace("{title}", ds.Tables[0].Rows[0]["title"].ToString());
            Temp = Temp.Replace("{pagenum}", ds.Tables[0].Rows[0]["title"].ToString());
        }
        else
        {
            Temp = Temp.Replace("{linkUrl}", "javascript:void(0);");
            Temp = Temp.Replace("{title}", "没有下一篇了");
            Temp = Temp.Replace("{pagenum}", "没有下一篇了");
        }
        return Temp;
    }
    #endregion

    #region 增加浏览次数===========================================
    public static string addClick(int articleId)
    {
        string result="";
        int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_article set hits=hits+1 where articleId=" + articleId + "");
        return result;
    }
    #endregion

    #region 返回站点信息=======================================
    public static Cms.Model.C_WebSiteconfig getWebSiteconfig(int id)
    {
        
        Cms.Model.C_WebSiteconfig model = new Cms.BLL.C_WebSiteconfig().GetModel(id);

        return model;
    }

    #endregion

    #region 返回Wap栏目url=========================================
    public static string getWapCloumnUrl(int id)
    {
        string result = "";
        Cms.Model.C_Column model = new Cms.BLL.C_Column().GetModel(id);

        if (model != null)
        {
            if (model.modelId == 1)
            {
                DataSet ds = new Cms.BLL.C_Column().GetList(1, "parentId=" + id, "classId asc");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    result = "/m/" + ds.Tables[0].Rows[0]["tpl_channel"].ToString() + ".aspx?classId=" + ds.Tables[0].Rows[0]["classId"].ToString();
                }
            }
            else
            {
                result = "/m/" + model.tplChannel + ".aspx?classId=" + id;
            }
        }
        return result;
    }

    #endregion

    #region 返回Wap栏目的内容Url==========================================
    public static string getWapContentUrl(int id, int articleId)
    {
        string result = "";
        Cms.Model.C_Column model = new Cms.BLL.C_Column().GetModel(id);

        if (model != null)
        {
            result = "/m/" + model.tplContent + ".aspx?classId=" + id + "&articleId=" + articleId;
        }
        return result;
    }

    #endregion

    #region 返回栏目当前焦点=========================================
    public static string getActive(int id, string articleId, int classId)
    {
        string result = "";
        if (id != null&&articleId==null)
        {
            if (Convert.ToInt32(id) == classId)
            {
                result = "active";
            }
            else
            {
                Cms.Model.C_Column model = new Cms.BLL.C_Column().GetModel(Convert.ToInt32(id));
                if (model.parentId == classId)
                {
                    result = "active";
                }
            }
        }
        else
        {
            Cms.Model.C_article model = new Cms.BLL.C_article().GetModel(Convert.ToInt32(articleId));
            if (model != null)
            {
                Cms.Model.C_Column modelC_Column = new Cms.BLL.C_Column().GetModel(Convert.ToInt32(model.parentId));
                if (modelC_Column.classId == classId)
                {
                    result = "active";
                }
                else if ((modelC_Column.parentId == classId))
                {
                    result = "active";
                }
            }
        }
        return result;
    }

    #endregion

    #region 返回当前文章栏目下的文章总数=========================================
    public static int getArticleCount(int id)
    {
        int result = 0;
        Cms.Model.C_article model = new Cms.BLL.C_article().GetModel(id);
        DataSet ds = new Cms.BLL.C_article().GetList("parentId=" + model.parentId);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = ds.Tables[0].Rows.Count;
        }
        return result;
    }

    #endregion

    #region 返回广告banner=========================================
    public static void RepeaterBanner(int top, int adtype, Repeater rep)
    {
        DataSet ds = new Cms.BLL.C_ad().GetList(top, "adtype=" + adtype + " and ishidden=0", "ordernum desc");//广告图
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    #endregion

    #region 返回产品=========================================
    public static void RepeaterProduct(int top, string where, Repeater rep)
    {
        DataSet ds = new Cms.BLL.C_product().GetList(top, where + " ishidden=0", "sortId asc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }
    #endregion

    #region 返回友情链接=========================================
    public static void RepeaterLink(int top, string where, Repeater rep)
    {
        DataSet ds = new Cms.BLL.C_link().GetList(top, where, "ordernum asc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds.Tables[0].DefaultView;
            rep.DataBind();
        }
    }

    #endregion

    #region 返回通过文章id返回栏目的内容链接=======================
    public static string getContentUrlsub(int id)
    {
        string result = "";
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        Cms.BLL.C_article bllarticle = new Cms.BLL.C_article();
        int parentid =Convert.ToInt32(bllarticle.GetModel(id).parentId);
        DataSet ds = bllColumn.GetList("classId=" + parentid);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = GetToHtml(ds.Tables[0].Rows[0]["contentUrl"].ToString());
        }
        return result;
    }

    #endregion

    #region 去除html==============================================
    public static string GetToHtml(string intro)
    {
        //删除脚本   
        intro = Regex.Replace(intro, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML   
        intro = Regex.Replace(intro, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"-->", "", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"<!--.*", "", RegexOptions.IgnoreCase);

        intro = Regex.Replace(intro, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        intro = Regex.Replace(intro, @"&#(\d+);", "", RegexOptions.IgnoreCase);

        intro.Replace("<", "");
        intro.Replace(">", "");
        intro.Replace("\r\n", "");
        intro = HttpContext.Current.Server.HtmlEncode(intro).Trim();

        return intro;
    }
     #endregion

    #region 截取字符长度======================================
    public static string getLength(string str, int n)
    {
        if (str.Length > n)
            return str.Substring(0, n) + "...";
        else
            return str;
    }
    public static string getLengthNo(string str, int n)
    {
        if (str.Length > n)
            return str.Substring(0, n);
        else
            return str;
    }
    #endregion

    #region 去除HTML标记======================================== 
    public static string NoHTML(string Htmlstring)
    {
        //删除脚本   
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML   
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

        // Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

        return Htmlstring;
    }
    #endregion

    #region 遍历栏目id============================================
    public static string getcloumnid(int classid)
    {
        string result = "";
        Cms.BLL.C_Column bll = new Cms.BLL.C_Column();
        DataSet ds = bll.GetList("parentId=" + classid);
        StringBuilder sbuBuilder = new StringBuilder();
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sbuBuilder.Append(ds.Tables[0].Rows[i]["classId"].ToString() + ",");
            }
            if (sbuBuilder.Length > 1)
            {
                sbuBuilder.Remove(sbuBuilder.Length - 1, 1);
            }
            result = sbuBuilder.ToString();
        }
        else
        {
            result = classid.ToString();
        }
      
        return result;
    }
    #endregion
}