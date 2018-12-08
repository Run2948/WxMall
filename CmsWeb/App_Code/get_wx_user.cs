using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Data;
using System.Xml;
/// <summary>
///get_wx_user 的摘要说明
/// </summary>
public class get_wx_user
{
	public get_wx_user()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    #region 获取来源微信用户信息=============================

    #region 服务器接受
    public static string getUser_info(string poststr)
    {
        string result = "123";
        try
        {
            wxuser.setstatistics("", "微信消息", poststr, 1, 1);
            string res = "";
            if (poststr != null)
            {
                wxmessage wx = new wxmessage();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(poststr);
                XmlElement root = xml.DocumentElement;


                wx.ToUserName = root.SelectSingleNode("ToUserName").InnerText;
                wx.FromUserName = root.SelectSingleNode("FromUserName").InnerText;
                wx.MsgType = root.SelectSingleNode("MsgType").InnerText;
                if (wx.MsgType.Trim() == "text")
                {
                    wx.Content = root.SelectSingleNode("Content").InnerText;
                }
                if (wx.MsgType.Trim() == "event")
                {
                    wx.EventName = root.SelectSingleNode("Event").InnerText;
                    wx.EventKey = root.SelectSingleNode("EventKey").InnerText;
                }
                if (wx.MsgType.Trim() == "voice")
                {
                    wx.Recognition = root.SelectSingleNode("Recognition").InnerText;
                }
                Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
                Cms.Model.wx_info Model = new Cms.Model.wx_info();
                Cms.BLL.wx_userinfo userinfo = new Cms.BLL.wx_userinfo();
                Cms.Model.wx_userinfo muserinfo = new Cms.Model.wx_userinfo();
                Model = wxinfo.GetModel(1);
                string str = "";
                string openid = wx.FromUserName;
                str = setinfo("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + Model.access_token + "&openid=" + openid, "", openid);
                muserinfo = JSONToObject<Cms.Model.wx_userinfo>(str);
                Cms.Model.wx_userinfo wxs = new Cms.Model.wx_userinfo();
                wxs.subscribe = muserinfo.subscribe;
                wxs.openid = muserinfo.openid;
                wxs.nickname = muserinfo.nickname;
                wxs.sex = muserinfo.sex;
                wxs.language = muserinfo.language;
                wxs.city = muserinfo.city;
                wxs.province = muserinfo.province;
                wxs.country = muserinfo.country;
                wxs.headimgurl = muserinfo.headimgurl;
                wxs.subscribe_time = muserinfo.subscribe_time;
                wxs.remark = muserinfo.remark;
                wxs.updatetime = DateTime.Now;
                if (!Cms.DBUtility.DbHelperSQL.Exists("select count(1) from wx_userinfo where openid='" + muserinfo.openid + "'"))
                {
                    if (muserinfo.openid != "")
                    {
                        userinfo.Add(wxs);
                    }
                }
                else
                {
                    Cms.DBUtility.DbHelperSQL.ExecuteSql("update wx_userinfo set updatetime='" + DateTime.Now + "' where openid='" + muserinfo.openid + "'");

                }
                wxuser.setstatistics("", "", "", 3, 1);
                result = muserinfo.openid;
            }


            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.Write(res);
        }
        catch (Exception ex)
        {
            setlog(ex.Message, "错误1");
        }
        return result = "21313";
    }


    #endregion

    #region 添加日志
    public static void setlog(string str, string sname)
    {
        Cms.BLL.C_admin_log cm = new Cms.BLL.C_admin_log();
        Cms.Model.C_admin_log mc = new Cms.Model.C_admin_log();
        mc.remark = str;
        mc.action_type = "微信信息";
        mc.user_name = sname;
        mc.add_time = DateTime.Now;
        cm.Add(mc);
    }
    #endregion

    #region 配置服务器
    //配置服务器
    public static void InterfaceTest()
    {
        string token = "abcdefhdsfdssddss";
        if (string.IsNullOrEmpty(token))
        {
            return;
        }

        string echoString = HttpContext.Current.Request.QueryString["echostr"];
        string signature = HttpContext.Current.Request.QueryString["signature"];
        string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
        string nonce = HttpContext.Current.Request.QueryString["nonce"];


        if (!string.IsNullOrEmpty(echoString))
        {
            HttpContext.Current.Response.Write(echoString);
            HttpContext.Current.Response.End();
        }

    }
    #endregion

    #region 会员信息
    /// <summary>    
    ///发送获取会员的请求
    /// </summary> 
    public static string setinfo(string posturl, string postData, string openid)
    {
        Stream outstream = null;
        Stream instream = null;
        StreamReader sr = null;
        HttpWebResponse response = null;
        HttpWebRequest request = null;
        Encoding encoding = Encoding.UTF8;
        byte[] data = encoding.GetBytes(postData);
        // 准备请求...
        try
        {
            // 设置参数
            request = WebRequest.Create(posturl) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Close();
            //发送请求并获取相应回应数据
            response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            instream = response.GetResponseStream();
            sr = new StreamReader(instream, encoding);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            string err = string.Empty;

            if (content.IndexOf("42001") > -1)
            {
                string str = Gettoken();
                Cms.BLL.wx_info wx = new Cms.BLL.wx_info();
                Cms.Model.wx_info mwx = new Cms.Model.wx_info();
                mwx = wx.GetModel(1);
                mwx.access_token = str;
                wx.Update(mwx);

                setinfo("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + str + "&openid=" + openid, postData, openid);


            }
            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }
    /// <summary>    
    ///获取token   
    /// </summary> 
    public static string Gettoken()
    {
        Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
        Cms.Model.wx_info Model = new Cms.Model.wx_info();
        Model = wxinfo.GetModel(1);


        string sAppId = Model.AppId;
        string sAppSecret = Model.AppSecret;
        string posturl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + sAppId + "&secret=" + sAppSecret + "";
        string postData = "";


        Stream outstream = null;
        Stream instream = null;
        StreamReader sr = null;
        HttpWebResponse response = null;
        HttpWebRequest request = null;
        Encoding encoding = Encoding.UTF8;
        byte[] data = encoding.GetBytes(postData);
        // 准备请求...
        try
        {
            request = WebRequest.Create(posturl) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            //发送请求并获取相应回应数据
            response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            instream = response.GetResponseStream();
            sr = new StreamReader(instream, encoding);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            string err = string.Empty;

            string[] s = content.Split(',');
            string str = s[0].Replace("access_token", "").Replace(":", "").Replace("{", "").Replace("\"", "");
            //Response.Write(content);
            return str;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }

    /// <summary>    
    ///JSON转换  
    /// </summary> 
    public static T JSONToObject<T>(string jsonText)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        try
        {
            return jss.Deserialize<T>(jsonText);
        }
        catch (Exception ex)
        {
            throw new Exception("JSONHelper.JSONToObject(): " + ex.Message);
        }
    }
    #endregion

    #endregion


    #region 获取来源微信用户信息二=========================
    public static string getwxCode(string code, string httpUrl)
    {
        string result = "123";
        string xtopenid = "";
        Cms.BLL.wx_info info = new Cms.BLL.wx_info();
        string appid = info.GetModel(1).AppId;
        string appsecret = info.GetModel(1).AppSecret;
        if (code != null && code != "")
        {

            string Code = code;
            string Str = GetJson("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + appsecret + "&code=" + Code + "&grant_type=authorization_code");
            //微信回传的数据为Json格式，将Json格式转化成对象  
            OAuth_Token Model = wxuser.JSONToObject<OAuth_Token>(Str);

            xtopenid = Model._openid;
            result = Model._openid + code;

            Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
            Cms.Model.wx_info Model_info = new Cms.Model.wx_info();
            Cms.BLL.wx_userinfo userinfo = new Cms.BLL.wx_userinfo();
            Cms.Model.wx_userinfo muserinfo = new Cms.Model.wx_userinfo();
            Model_info = wxinfo.GetModel(1);
            string str = "";
            string openid = Model._openid;
            str = setinfo("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + Model.access_token + "&openid=" + openid, "", openid);
            muserinfo = JSONToObject<Cms.Model.wx_userinfo>(str);
            Cms.Model.wx_userinfo wxs = new Cms.Model.wx_userinfo();
            wxs.subscribe = muserinfo.subscribe;
            wxs.openid = muserinfo.openid;
            wxs.nickname = muserinfo.nickname;
            wxs.sex = muserinfo.sex;
            wxs.language = muserinfo.language;
            wxs.city = muserinfo.city;
            wxs.province = muserinfo.province;
            wxs.country = muserinfo.country;
            wxs.headimgurl = muserinfo.headimgurl;
            wxs.subscribe_time = muserinfo.subscribe_time;
            wxs.remark = muserinfo.remark;
            wxs.updatetime = DateTime.Now;
            if (!Cms.DBUtility.DbHelperSQL.Exists("select count(1) from wx_userinfo where openid='" + muserinfo.openid + "'"))
            {
                if (wxs.openid != "")
                {
                    userinfo.Add(wxs);
                }
            }
            else
            {
                Cms.DBUtility.DbHelperSQL.ExecuteSql("update wx_userinfo set updatetime='" + DateTime.Now + "' where openid='" + muserinfo.openid + "'");

            }

        }

        return result;

    }
    /// <summary>
    /// 接受信息
    /// </summary>
    /// <param name="url">目标连接地址</param>
    /// <returns></returns>
    protected static string GetJson(string url)
    {
        WebClient wc = new WebClient();
        wc.Credentials = CredentialCache.DefaultCredentials;
        wc.Encoding = Encoding.UTF8;
        string returnText = wc.DownloadString(url);
        if (returnText.Contains("errcode"))
        {
            //可能发生错误  
        }
        return returnText;
    }

    public class OAuth_Token
    {
        public OAuth_Token()
        {
            //  
            //TODO: 在此处添加构造函数逻辑  
            //  
        }
        //access_token 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同  
        //expires_in access_token接口调用凭证超时时间，单位（秒）  
        //refresh_token 用户刷新access_token  
        //openid 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID  
        //scope 用户授权的作用域，使用逗号（,）分隔  
        public string _access_token;
        public string _expires_in;
        public string _refresh_token;
        public string _openid;
        public string _scope;
        public string access_token
        {
            set { _access_token = value; }
            get { return _access_token; }
        }
        public string expires_in
        {
            set { _expires_in = value; }
            get { return _expires_in; }
        }
        public string refresh_token
        {
            set { _refresh_token = value; }
            get { return _refresh_token; }
        }
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        public string scope
        {
            set { _scope = value; }
            get { return _scope; }
        }
    }
    #endregion
}