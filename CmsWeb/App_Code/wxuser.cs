using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using Cms.Common;
/// <summary>
///wxuser 的摘要说明
/// </summary>
public class wxuser
{
	public wxuser()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    #region 会员编号
    public static string getusercard()
    {
        string str = "";
        DateTime dtime = DateTime.Now;

        str = dtime.ToString("ssHHddmmffff");

        return str;
    }

    /// <summary>
    /// 会员卡是否已存在
    /// </summary>
    /// <param name="usercard"></param>
    /// <returns></returns>
    public static bool isExistsUsercard(string usercard)
    {
        bool bl = false;
        Cms.BLL.C_user cuser = new Cms.BLL.C_user();
        DataTable dt = cuser.GetList("usercard='" + usercard + "'").Tables[0];
        if (dt.Rows.Count > 0)
        {
            bl = true;
        }
        return bl;
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
    #region 获取微信用户信息
    /// <summary>
    /// 获取微信用户信息
    /// </summary>
    /// <param name="openid"></param>
    /// <returns></returns>
    public static Cms.Model.wx_userinfo getwxuserinfo(string openid)
    {
        Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
        Cms.Model.wx_info Model = new Cms.Model.wx_info();
        Cms.BLL.wx_userinfo userinfo = new Cms.BLL.wx_userinfo();
        Cms.Model.wx_userinfo muserinfo = new Cms.Model.wx_userinfo();
        Model = wxinfo.GetModel(1);
        string str = "";
        DataTable dt = userinfo.GetList("openid='" + openid + "' order by updatetime desc").Tables[0];
        if (dt.Rows.Count > 0)
        {
            string uptime = Convert.ToDateTime(dt.Rows[0]["updatetime"]).ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("yyyy-MM-dd");

            if (uptime == time)
            {
                muserinfo = userinfo.GetModel(int.Parse(dt.Rows[0]["id"].ToString()));
            }
            else
            {
                string Str = GetJson("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + Model.AppId + "&secret=" + Model.AppSecret + "");
                //微信回传的数据为Json格式，将Json格式转化成对象  
                OAuth_Token ModelOAuth_Token = wxuser.JSONToObject<OAuth_Token>(Str);
                setlog("添加ModelOAuth_Token", ModelOAuth_Token.access_token);
                string StrTwo = GetJson("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + ModelOAuth_Token.access_token + "&openid=" + openid + "");
                wxuserinfo ModelTwo = wxuser.JSONToObject<wxuserinfo>(StrTwo);
                muserinfo.subscribe = ModelTwo.subscribe;
                muserinfo.openid = ModelTwo.openid;
                muserinfo.nickname = ModelTwo.nickname;
                muserinfo.sex = ModelTwo.sex;
                muserinfo.language = ModelTwo.language;
                muserinfo.city = ModelTwo.city;
                muserinfo.province = ModelTwo.province;
                muserinfo.country = ModelTwo.country;
                muserinfo.headimgurl = ModelTwo.headimgurl;
                muserinfo.subscribe_time = ModelTwo.subscribe_time;
                muserinfo.remark = ModelTwo.remark;
                muserinfo.updatetime = DateTime.Now;

                //str = setinfo("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + Model.access_token + "&openid=" + openid, "", openid);
                //muserinfo = JSONToObject<Cms.Model.wx_userinfo>(str);
                //Cms.Model.wx_userinfo wx = new Cms.Model.wx_userinfo();
                ////wx.id = int.Parse(dt.Rows[0]["id"].ToString());
                //wx.subscribe = muserinfo.subscribe;
                //wx.openid = muserinfo.openid;
                //wx.nickname = muserinfo.nickname;
                //wx.sex = muserinfo.sex;
                //wx.language = muserinfo.language;
                //wx.city = muserinfo.city;
                //wx.province = muserinfo.province;
                //wx.country = muserinfo.country;
                //wx.headimgurl = muserinfo.headimgurl;
                //wx.subscribe_time = muserinfo.subscribe_time;
                //wx.remark = muserinfo.remark;
                //wx.updatetime = DateTime.Now;
                userinfo.Add(muserinfo);
            }
        }
        


        return muserinfo;
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
    public static string setinfo(string posturl, string postData,string openid)
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

                setinfo("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + str + "&openid=" + openid, postData,openid);


            }
            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }
    public static string Gettoken()
    {
        Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
        Cms.Model.wx_info Model = new Cms.Model.wx_info();
        Model=wxinfo.GetModel(1);
       

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
    

    #region 会员设置接口
    public static string erpApi = new Cms.BLL.C_WebSiteconfig().GetModel(1).textParam1.ToString() + "/ChatServlet"; //ConfigHelper.GetConfigString("ERPAPI");
    /// <summary>
    /// 设置查询会员信息
    /// </summary>
    //设置查询会员信息
    public static userinfo getuserinfo(string openid)
    {
        string posturl = erpApi + "?UserInfo={\"openid\":\"" + openid + "\"}";
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

            userinfo uf = new userinfo();
            uf = JSONToObject<userinfo>(content);

            return uf;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }
    /// <summary>
    /// 设置更新会员信息
    /// </summary>
    //设置更新会员信息
    public static userinfo getUserUpdate(string openid, string usercard, string username, string sex, string useraddress, string birthday, string marryday, string telephone, string shopcode)
    {
        string posturl = erpApi + "?UserUpdate={\"openid\":\"" + openid + "\",\"usercard\":\"" + usercard + "\",\"username\":\"" + username + "\",\"sex\":\"" + sex + "\",\"useraddress\":\"" + useraddress + "\",\"birthday\":\"" + birthday + "\",\"marryday\":\"" + marryday + "\",\"telephone\":\"" + telephone + "\",\"shopcode\":\"" + shopcode + "\"}";
       // string url = HttpUtility.UrlEncode(posturl,Encoding.UTF8);
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

            userinfo uf = new userinfo();
            uf = JSONToObject<userinfo>(content);

            return uf;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }
    /// <summary>
    /// 设置会员绑定验证
    /// </summary>
    //设置会员绑定验证
    public static userinfo getUserBind(string openid, string telphone, string usercard)
    {
        string posturl = erpApi + "?UserBind={\"usercard\":\"" + usercard + "\",\"telphone\":\"" + telphone + "\",\"openid\":\"" + openid + "\"}";
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

            userinfo uf = new userinfo();
            uf = JSONToObject<userinfo>(content);

            return uf;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }
    /// <summary>
    /// 设置会员签到
    /// </summary>
    //设置会员签到
    public static userinfo getUserSign(string openid, string usercard)
    {
        string posturl = erpApi + "?UserSign={\"openid\":\"" + openid + "\",\"usercard\":\"" + usercard + "\"}";
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

         
            userinfo uf = new userinfo();
            uf = JSONToObject<userinfo>(content);

            return uf;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }
    /// <summary>
    /// 设置消费列表
    /// </summary>
    //设置消费列表
    public static List<UserSale> getUserSale(string openid, string usercard)
    {
        string posturl = erpApi + "?UserSale={\"openid\":\"" + openid + "\",\"usercard\":\"" + usercard + "\"}";
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

            string str = content.Replace("[", "").Replace("]", "");
            string[] s = str.Split(new []{"},"},StringSplitOptions.None);
            List<UserSale> list = new List<UserSale>();
            foreach (string ss in s)
            {
                string strs = "";
                if (ss.LastIndexOf('}') < 0)
                {
                    strs = ss + "}";
                }
                else {
                    strs = ss;
                }
                UserSale uf = new UserSale();
                uf = JSONToObject<UserSale>(strs);
                list.Add(uf);
            }
           

            return list;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }
    /// <summary>
    /// 设置注册会员信息
    /// </summary>
    //设置注册会员信息
    public static UserSale getUserRegister(string openid, string username, string sex, string useraddress, string birthday, string marryday, string telephone, string shopcode)
    {
        string posturl = erpApi + "?UserRegister={\"openid\":\"" + openid + "\",\"username\":\"" + username + "\",\"sex\":\"" + sex + "\",\"useraddress\":\"" + useraddress + "\",\"birthday\":\"" + birthday + "\",\"marryday\":\"" + marryday + "\",\"telephone\":\"" + telephone + "\",\"shopcode\":\"" + shopcode + "\"}";
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

            UserSale uf = new UserSale();
            uf = JSONToObject<UserSale>(content);

            return uf;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }

    /// <summary>
    /// 设置注册会员信息
    /// </summary>
    //设置注册会员信息
    public static List<ShopInfo> getShopInfo(string shopcode)
    {
        string posturl = erpApi + "?ShopInfo={\"shopcode\":\"" + shopcode + "\"}";
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
            string str = content.Replace("\r", "").Replace("\n", "");
            string[] s = str.Split(new[] { "}" }, StringSplitOptions.None);
            List<ShopInfo> list = new List<ShopInfo>();
            foreach (string ss in s)
            {
                
                string strs = "";
                if (ss.LastIndexOf('}') < 0)
                {
                    strs = ss + "}";
                }
                else
                {
                    strs = ss;
                }
                if (strs.Length > 4)
                {
                    ShopInfo uf = new ShopInfo();
                    uf = JSONToObject<ShopInfo>(strs);
                    list.Add(uf);
                }
            }


            return list;
            

           
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }

    /// <summary>
    /// 设置会员加减积分
    /// </summary>
    //设置会员加减积分
    public static UserSale getUserScore(string usercard, string openid, string numberid, string scorename, string wescore)
    {
        string posturl = erpApi + "?UserScore={\"usercard\":\"" + usercard + "\",\"openid\":\"" + openid + "\",\"numberid\":\"" + numberid + "\",\"scorename\":\"" + scorename + "\",\"wescore\":\"" + wescore + "\"}";
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

            UserSale uf = new UserSale();
            uf = JSONToObject<UserSale>(content);

            return uf;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }


    /// <summary>
    /// 传送礼品预约信息
    /// </summary>
    /// <param name="shopcode">单位编号</param>
    /// <param name="openid">微信ID</param>
    /// <param name="username">领取人姓名</param>
    /// <param name="shoptel">领取人电话</param>
    /// <param name="giftname">礼品名称</param>
    /// <param name="gifttype">礼品款号</param>
    /// <param name="giftcount">礼品数量</param>
    /// <param name="giftscore">礼品分数</param>
    /// <param name="bookdate">预订日期</param>
    /// <param name="takedate">取礼品日期</param>
    /// <param name="ordernumber">对应你们微信的单号（由你们那边生成）</param>
    /// <returns></returns>
    public static GiftBook getGiftBook(string shopcode, string openid, string username, string shoptel, string giftname, string gifttype, string giftcount, string giftscore, string bookdate, string takedate, string ordernumber)
    {
        string posturl = erpApi + "?GiftBook={\"shopcode\":\"" + shopcode + "\",\"openid\":\"" + openid + "\",\"username\":\"" + username + "\",\"shoptel\":\"" + shoptel + "\",\"giftname\":\"" + giftname + "\",\"gifttype\":\"" + gifttype + "\",\"giftcount\":\"" + giftcount + "\",\"giftscore\":\"" + giftscore + "\",\"bookdate\":\"" + bookdate + "\",\"takedate\":\"" + takedate + "\",\"ordernumber\":\"" + ordernumber + "\"}";
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

            GiftBook uf = new GiftBook();
            uf = JSONToObject<GiftBook>(content);

            return uf;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return null;
        }
    }
    
    /// <summary>
    /// 微信日志
    /// </summary>
    /// <param name="strwhere"></param>
    /// <param name="typename"></param>
    /// <param name="typecontents"></param>
    /// <param name="type"></param>
    /// <param name="number"></param>
    public static void setstatistics(string strwhere, string typename, string typecontents, int type, int number)
    {
        Cms.BLL.sc_statistics sc = new Cms.BLL.sc_statistics();
        Cms.Model.sc_statistics msc = new Cms.Model.sc_statistics();
        DataTable dt = sc.GetTimeList(strwhere).Tables[0];
        if (dt.Rows.Count > 0)
        {
            int id = int.Parse(dt.Rows[0]["id"].ToString());
            msc = sc.GetModel(id);
            if (typename.Length > 1)
            {
                msc.typename = typename;
            }
            if (typecontents.Length > 1)
            {
                msc.typecontents = typecontents;
            }
            if (type == 1)
            {
                msc.msgnumber += number;
            }
            if (type == 2)
            {
                msc.visitnumber += number;
            }
            if (type == 3)
            {
                msc.gznumber += number;
            }
            if (type == 4)
            {
                msc.qxnumber += number;
            }
            if (type == 5)
            {
                msc.doingnumber += number;
            }
            if (type == 6)
            {
                msc.zfnumber += number;
            }
            msc.updatetime = DateTime.Now;
            sc.Update(msc);
        }
        else {
            if (typename.Length > 1)
            {
                msc.typename = typename;
            }
            if (typecontents.Length > 1)
            {
                msc.typecontents = typecontents;
            }
            if (type == 1)
            {
                msc.msgnumber = number;
            }
            if (type == 2)
            {
                msc.visitnumber = number;
            }
            if (type == 3)
            {
                msc.gznumber = number;
            }
            if (type == 4)
            {
                msc.qxnumber = number;
            }
            if (type == 5)
            {
                msc.doingnumber = number;
            }
            if (type == 6)
            {
                msc.zfnumber = number;
            }
            msc.updatetime = DateTime.Now;
            sc.Add(msc);
        }
    }

    #endregion

    public class ShopInfo
    {
        private string _shopcode;
        private string _shopname;
        private string _shopadd;
        private string _showtel;
        private string _result;
        private string _content;

        public string shopcode
        {
            set { _shopcode = value; }
            get { return _shopcode; }
        }
        public string shopname
        {
            set { _shopname = value; }
            get { return _shopname; }
        }
        public string shopadd
        {
            set { _shopadd = value; }
            get { return _shopadd; }
        }
        public string showtel
        {
            set { _showtel = value; }
            get { return _showtel; }
        }
        public string result
        {
            set { _result = value; }
            get { return _result; }
        }
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
    }
    
    public class userinfo
    {
        private string _openid;
        private string _usercard;
        private string _username;
        private string _sex;
        private string _useraddress;
        private string _birthday;
        private string _marryday;
        private string _telephone;
        private string _shopcode;
        private string _shopname;
        private string _userlevel;
        private string _allbuy;
        private string _buytimes;
        private string _userallscore;
        private string _userscore;
        private string _result;
        private string _content;


        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        public string usercard
        {
            set { _usercard = value; }
            get { return _usercard; }
        }
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        public string useraddress
        {
            set { _useraddress = value; }
            get { return _useraddress; }
        }
        public string birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        public string marryday
        {
            set { _marryday = value; }
            get { return _marryday; }
        }
        public string telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        public string shopcode
        {
            set { _shopcode = value; }
            get { return _shopcode; }
        }
        public string shopname
        {
            set { _shopname = value; }
            get { return _shopname; }
        }
        public string userlevel
        {
            set { _userlevel = value; }
            get { return _userlevel; }
        }
        public string allbuy
        {
            set { _allbuy = value; }
            get { return _allbuy; }
        }
        public string buytimes
        {
            set { _buytimes = value; }
            get { return _buytimes; }
        }
        public string userallscore
        {
            set { _userallscore = value; }
            get { return _userallscore; }
        }
        public string userscore
        {
            set { _userscore = value; }
            get { return _userscore; }
        }
        public string result
        {
            set { _result = value; }
            get { return _result; }
        }
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
    }

    public class UserSale
    {
        private string _openid;
        private string _usercard;
        private string _shopname;
        private string _barcode;
        private string _productname;
        private string _saledate;
        private string _result;
        private string _content;
    


        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        public string usercard
        {
            set { _usercard = value; }
            get { return _usercard; }
        }
        public string shopname
        {
            set { _shopname = value; }
            get { return _shopname; }
        }
        public string barcode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        public string productname
        {
            set { _productname = value; }
            get { return _productname; }
        }
        public string saledate
        {
            set { _saledate = value; }
            get { return _saledate; }
        }
        public string result
        {
            set { _result = value; }
            get { return _result; }
        }
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
    }

    /// <param name="shopcode">单位编号</param>
    /// <param name="openid">微信ID</param>
    /// <param name="username">领取人姓名</param>
    /// <param name="shoptel">领取人电话</param>
    /// <param name="giftname">礼品名称</param>
    /// <param name="gifttype">礼品款号</param>
    /// <param name="giftcount">礼品数量</param>
    /// <param name="giftscore">礼品分数</param>
    /// <param name="bookdate">预订日期</param>
    /// <param name="takedate">取礼品日期</param>
    /// <param name="ordernumber">对应你们微信的单号（由你们那边生成）</param>
    public class GiftBook
    {
        private string _shopcode;
        private string _openid;
        private string _username;
        private string _shoptel;
        private string _giftname;
        private string _gifttype;
        private string _giftcount;
        private string _giftscore;
        private string _bookdate;
        private string _takedate;
        private string _ordernumber;
        private string _result;
        private string _content;


        public string shopcode
        {
            set { _shopcode = value; }
            get { return _shopcode; }
        }
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }

        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        public string shoptel
        {
            set { _shoptel = value; }
            get { return _shoptel; }
        }
        public string giftname
        {
            set { _giftname = value; }
            get { return _giftname; }
        }
        public string gifttype
        {
            set { _gifttype = value; }
            get { return _gifttype; }
        }
        public string giftcount
        {
            set { _giftcount = value; }
            get { return _giftcount; }
        }
        public string giftscore
        {
            set { _giftscore = value; }
            get { return _giftscore; }
        }
        public string bookdate
        {
            set { _bookdate = value; }
            get { return _bookdate; }
        }
        public string takedate
        {
            set { _takedate = value; }
            get { return _takedate; }
        }
        public string ordernumber
        {
            set { _ordernumber = value; }
            get { return _ordernumber; }
        }
        public string result
        {
            set { _result = value; }
            get { return _result; }
        }
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
    }
}