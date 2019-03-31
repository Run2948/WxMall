using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cms.Common;
using System.Data;
using System.Text.RegularExpressions;
/// <summary>
///ToWap 的摘要说明
/// </summary>
public class ToWap
{
	public ToWap()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    #region 返回栏目手机站列表url==========================================
    public static string getCloumnUrl(int id)
    {
        string result = "";
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        DataSet ds = bllColumn.GetList("classId=" + id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = ds.Tables[0].Rows[0]["w_linkUrl"].ToString();
        }
        return result;
    }

    #endregion

    #region 返回栏目手机站内容链接======================================
    public static string getContentUrl(int id)
    {
        string result = "";
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        DataSet ds = bllColumn.GetList("classId=" + id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = GetToHtml(ds.Tables[0].Rows[0]["w_contentUrl"].ToString());
        }
        return result;
    }

    #endregion

    #region 返回栏目名称=====================================
    public static string getCloumnName(int id)
    {
        string result = "";
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        DataSet ds = bllColumn.GetList("classId=" + id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = ds.Tables[0].Rows[0]["className"].ToString();
        }
        return result;
    }

    #endregion

    #region 返回栏目缩略图======================================
    public static string getCloumnPicurl(int id)
    {
        string result = "";
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        DataSet ds = bllColumn.GetList("classId=" + id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = ds.Tables[0].Rows[0]["photoUrl"].ToString();
        }
        return result;
    }

    #endregion

    #region 返回栏目简介========================================
    public static string getCloumnIntro(int id)
    {
        string result = "";
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        DataSet ds = bllColumn.GetList("classId=" + id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = GetToHtml(ds.Tables[0].Rows[0]["intro"].ToString());
        }
        return result;
    }

    #endregion

    #region 返回栏目内容====================================
    public static string getCloumncontent(int id)
    {
        string result = "";
        Cms.BLL.C_Column bllColumn = new Cms.BLL.C_Column();
        DataSet ds = bllColumn.GetList("classId=" + id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            result = GetToHtml(ds.Tables[0].Rows[0]["content"].ToString());
        }
        return result;
    }

    #endregion

    #region 去除html=====================================
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

    #region 截取字符长度=====================================
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

    #region 去除HTML标记======================================= 
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

    #region 发生短信 =======================================
    public static string sendSMS(string phone)
    {
        Cms.BLL.C_code cc = new Cms.BLL.C_code();
        string code = cc.newcode(phone);

        string str = "您好，手机验证码【"+code+"】-【深圳戴维克珠宝】";

        string urlsms = string.Format("http://sms.yiwang.cc/action.jsp?action=sendSMS&uid=1&sn=ZQY-HN-TEST&key=test123456&phone={0}&content={1}", phone, str);
        System.Net.WebClient client = new System.Net.WebClient();
        string reply = client.DownloadString(urlsms);

        return reply;
    }
    #endregion
}