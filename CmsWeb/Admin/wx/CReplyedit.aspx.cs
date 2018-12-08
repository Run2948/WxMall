using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using Cms.DBUtility;
using System.IO;
using System.Net;
using System.Text;
using Cms.Common;
public partial class Admin_order_orderedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //登录验证
            adminUser.GetLoginState();
            DateTime time = DateTime.Now;
            DateTime dttime = Convert.ToDateTime("2015-01-11");
            TimeSpan s = time - dttime;
            //Response.Write(s.Days);
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
           
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//订单ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    this.bind_date(id);// 赋值操作信息
                    break;
            }

        }
    }
    public void bind_date(int _id)
    {
        Cms.BLL.wx_ConcernReply bll = new Cms.BLL.wx_ConcernReply();
        DataTable dt = bll.GetList("id="+_id).Tables[0];
        if (dt.Rows.Count > 0)
        {
            string type = dt.Rows[0]["typeid"].ToString();
           string isopen = dt.Rows[0]["isopen"].ToString();
            if (type == "0")
            {
                rbtype.Items[0].Selected = true;
            }
            if (type == "1")
            {
                rbtype.Items[1].Selected = true;
                photoUrl.Text = dt.Rows[0]["fileurl"].ToString();
            }
            if (type == "2")
            {
                rbtype.Items[2].Selected = true;
                Attachment.Value = dt.Rows[0]["fileurl"].ToString();
            }
            if(isopen=="0")
            {
                rbopen.Items[0].Selected = true;
            }else{
                rbopen.Items[1].Selected = true;
            }
            tbinfo.Value = dt.Rows[0]["contents"].ToString();
            tburl.Text = dt.Rows[0]["url"].ToString();
            tbtilte.Text = dt.Rows[0]["title"].ToString();
        }
      
    }
 

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Cms.BLL.wx_ConcernReply bll = new Cms.BLL.wx_ConcernReply();
        Cms.Model.wx_ConcernReply bml = new Cms.Model.wx_ConcernReply();
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");
        bool bl = false;
        bool bls = true;
        string channel_name = "文本";
        string urlhot = Request.Url.Host.ToString();
        if (action == "add")
        {
            bml.typeid =int.Parse(rbtype.SelectedValue.ToString());
            bml.url = tburl.Text.Trim();
            bml.title = tbtilte.Text.Trim();

            if (urlhot.IndexOf("http") > -1 || urlhot.IndexOf("HTTP") > -1 || urlhot.IndexOf("https") > -1 || urlhot.IndexOf("HTTPS") > -1)
            {

            }
            else
            {
                urlhot = "http://" + urlhot;
            }

            if (rbtype.SelectedValue.ToString() == "1")
            {
                channel_name = "图文";
                bml.fileurl =urlhot+photoUrl.Text;
            }
            if (rbtype.SelectedValue.ToString() == "2")
            {
                channel_name = "语音";
                bml.fileurl = Attachment.Value;
                string media_id = HttpUploadFile(bml.fileurl);
                if (media_id.Length < 40)
                {
                    bls = false;   
                }
                bml.media_id = media_id;
            }
            bml.contents = tbinfo.Value;
            bml.updatetime = DateTime.Now;
            bml.isopen = int.Parse(rbopen.SelectedValue.ToString());
            bl = bll.Add(bml) > 0 ? true : false ;
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(),"微信："+ bml.title); //记录日志
        }
        else {
            bml = bll.GetModel(id);
            bml.typeid = int.Parse(rbtype.SelectedValue.ToString());
            bml.url = tburl.Text.Trim();
            bml.title = tbtilte.Text.Trim();

            

            if (rbtype.SelectedValue.ToString() == "1")
            {
                if (photoUrl.Text.IndexOf("http") > -1 || photoUrl.Text.IndexOf("HTTP") > -1 || photoUrl.Text.IndexOf("https") > -1 || photoUrl.Text.IndexOf("HTTPS") > -1)
                {
                    urlhot = "";
                }
                else
                {
                    urlhot = "http://" + urlhot;
                }
                bml.fileurl =urlhot+photoUrl.Text;
                channel_name = "图文";
            }
            if (rbtype.SelectedValue.ToString() == "2")
            {
                channel_name = "语音";
                bml.fileurl =Attachment.Value;
                string media_id = HttpUploadFile(bml.fileurl);
                if (media_id.Length < 40)
                {
                    bls = false;
                }
                bml.media_id = media_id;
            }
            bml.contents = tbinfo.Value;

            if (rbopen.SelectedValue.ToString() == "1")
            {
                string strSql = "update wx_ConcernReply  set isopen=0 where id not in(" + id + ")";
                DbHelperSQL.ExecuteSql(strSql);
            }
            bml.updatetime = DateTime.Now;
            bml.isopen = int.Parse(rbopen.SelectedValue.ToString());
            bl = bll.Update(bml);
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信：" + bml.title); //记录日志
        }
        if (bl && bls)
        {
            if (action == "add")
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加" + channel_name); //记录日志
                ShowConfirm("是否继续添加？", "CReplyedit.aspx?action=add", "CReplylist.aspx");
            }
            else
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "修改" + channel_name); //记录日志
                JscriptMsg("提交成功！", "CReplylist.aspx", "Success");
            }
        }
        else
        {
            JscriptMsg("提交失败！", "CReplyedit.aspx?action=edit?id=" + id, "Error");
        }
    }

    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }

    public static void ShowConfirm(string strMsg, string strUrl_Yes, string strUrl_No)
    {
        System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) {  window.location.href='" + strUrl_Yes +
                          "' } else {window.location.href='" + strUrl_No + "' };</script>");
    }

    public static string setinfo(string postData)
    {
        Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
        Cms.Model.wx_info Model = new Cms.Model.wx_info();
        Model = wxinfo.GetModel(1);
        //string postData = "";
        string posturl = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token="+Model.access_token+"&type=voice";
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
            request.ContentType = "audior";
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

                setinfo(postData);


            }

            string s = content.Replace("{", "").Replace("}", "").Replace("\"","");
            string[] ss = s.Split(',');

            return ss[1];
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }


    public  string HttpUploadFile(string postData)
    {
        Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
        Cms.Model.wx_info Model = new Cms.Model.wx_info();
        Model = wxinfo.GetModel(1);
        string result = "";  
        string posturl = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token="+Model.access_token+"&type=voice";

        string filepath = Server.MapPath("~"+postData);
        
        WebClient myWebClient = new WebClient();  
        myWebClient.Credentials = CredentialCache.DefaultCredentials;  
        try  
        {
            byte[] responseArray = myWebClient.UploadFile(posturl, "POST", filepath);  
            result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);

            if (result.IndexOf("42001") > -1)
            {
                string str = Gettoken();
                Cms.BLL.wx_info wx = new Cms.BLL.wx_info();
                Cms.Model.wx_info mwx = new Cms.Model.wx_info();
                mwx = wx.GetModel(1);
                mwx.access_token = str;
                wx.Update(mwx);

                HttpUploadFile(postData);


            }

            string s = result.Replace("{", "").Replace("}", "").Replace("\"", "");
            string[] ss = s.Split(',');
            result = ss[1].Replace("media_id:","");
        }  
        catch (Exception ex)  
        {  
            result = "Error:" + ex.Message;  
        }  
       
        return result;  
  
    } 
    public static string Gettoken()
    {
        Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
        Cms.Model.wx_info Model = new Cms.Model.wx_info();
        Model = wxinfo.GetModel(1);


        string sAppId = Model.AppId;
        string sAppSecret = Model.AppSecret;
        string posturl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + sAppId + "&secret=" + sAppSecret + "";
        string postData = "";


        //Stream outstream = null;
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
}