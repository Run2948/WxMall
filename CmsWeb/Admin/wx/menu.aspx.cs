using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;
using System.Data;
using AjaxPro;
using Cms.Common;
public partial class Admin_wx_menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack){
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Admin_wx_menu));
            Bind();
       // Gettoken();
        }
    }

    public void Bind()
    {

        Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
        Cms.Model.wx_info minfo = new Cms.Model.wx_info();
        minfo = wxinfo.GetModel(1);

        hdid.Value = minfo.access_token;
      
        Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
        Cms.Model.wx_menu wmd = new Cms.Model.wx_menu();
        DataTable dt = wm.GetList("pid=0").Tables[0];
        rmenu.DataSource = dt.DefaultView;
        rmenu.DataBind();


        dt = wm.GetList("pid=1").Tables[0];
        rmenu1.DataSource = dt.DefaultView;
        rmenu1.DataBind();

        dt = wm.GetList("pid=2").Tables[0];
        rmenu2.DataSource = dt.DefaultView;
        rmenu2.DataBind();

        dt = wm.GetList("pid=3").Tables[0];
        rmenu3.DataSource = dt.DefaultView;
        rmenu3.DataBind();
    }

   
    
    public string Gettoken()
    {
        Cms.BLL.wx_info wxinfo = new Cms.BLL.wx_info();
        Cms.Model.wx_info minfo = new Cms.Model.wx_info();
        minfo = wxinfo.GetModel(1);
        string sAppId = minfo.AppId;
        string sAppSecret = minfo.AppSecret;
        string posturl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid="+sAppId+"&secret="+sAppSecret+"";
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
            string str=s[0].Replace("access_token", "").Replace(":", "").Replace("{", "").Replace("\"", "");
            //Response.Write(content);
            return str;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }
   
 
    

    public string bindlist(string id)
    {
        string str = "";
        Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
        Cms.Model.wx_menu wmd = new Cms.Model.wx_menu();
        DataTable dt = wm.GetList("pid="+id).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == 0)
            {
                str+= dt.Rows[i]["name"].ToString()+",";
            }
            if (i == 1)
            {
                str += dt.Rows[i]["name"].ToString() + ",";
            }
            if (i ==2)
            {
                str += dt.Rows[i]["name"].ToString() + ",";
            }
            if (i == 3)
            {
                str += dt.Rows[i]["name"].ToString()+",";
            }
            if (i == 4)
            {
                str += dt.Rows[i]["name"].ToString() + ",";
            }
        }
        if (str.Length > 1)
        {
            str = str.Substring(0, str.Length - 1);
        }
        return str;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GetPage("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + hdid.Value, setmenu());
    }
    public string GetPage(string posturl, string postData)
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

            if (content.IndexOf("42001") > -1 || content.IndexOf("40001") > -1)
            {
                string str = Gettoken();
                Cms.BLL.wx_info wx = new Cms.BLL.wx_info();
                Cms.Model.wx_info mwx = new Cms.Model.wx_info();
                mwx = wx.GetModel(1);
                mwx.access_token = str;
                wx.Update(mwx);
                GetPage("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + str, setmenu());
                Bind();
               
            }
            if (content.IndexOf("ok") > -1)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单发布成功"); //记录日志
                Response.Write("<script>alert('发布成功!');window.location.href ='menu.aspx'</script>");
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('发布成功！')</script>");
            }
            else
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单发布失败"); //记录日志
                Response.Write("<script>alert('发布失败!" + content + "');window.location.href ='menu.aspx'</script>");
               // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('发布失败！" + content + "')</script>"); 
            }
            //Response.Write(content);
            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }
    protected void btndz_Click(object sender, EventArgs e)
    {

        GetPage2("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + hdid.Value, setmenu());
    }

    public string GetPage2(string posturl, string postData)
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
                GetPage2("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + str, setmenu());
                Bind();
               // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('停用失败！" + content + "')</script>");
             //   Response.Write("<script>alert('停用失败!" + content + "');window.location.href ='menu.aspx'</script>");
                

            }
            if (content.IndexOf("ok") > -1)
            {
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('停用成功！')</script>");
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单停用成功"); //记录日志
                Response.Write("<script>alert('停用成功!');window.location.href ='menu.aspx'</script>");
            }
            else
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单停用失败"); //记录日志
                Response.Write("<script>alert('停用失败!" + content + "');window.location.href ='menu.aspx'</script>");
            }
            
          //  Response.Write(content);
            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }

    protected void btnsaves_Click(object sender, EventArgs e)
    {
        Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
        Cms.Model.wx_menu wmd = new Cms.Model.wx_menu();
        string sid="";
        if(hdsid.Value!="")
            sid = hdsid.Value;

       


        string seven = ddeven.SelectedValue.ToString();
        if (sid != null && sid != "")
        {
            wmd = wm.GetModel(int.Parse(sid));
            wmd.name = tbname.Text;
            if (seven == "0")
            {
                string smuen1 = tbmenu1.Text.Trim();
                string smuen2 = tbmenu2.Text.Trim();
                string smuen3 = tbmenu3.Text.Trim();
                string smuen4 = tbmenu4.Text.Trim();
                string smuen5 = tbmenu5.Text.Trim();
                string smuen = "";
                if (smuen1 != "")
                {
                    smuen += smuen1 + ",";
                }
                if (smuen1 != "")
                {
                    smuen += smuen2 + ",";
                }
                if (smuen1 != "")
                {
                    smuen += smuen3 + ",";
                }
                if (smuen1 != "")
                {
                    smuen += smuen4 + ",";
                }
                if (smuen1 != "")
                {
                    smuen += smuen5 + ",";
                }
                if (smuen != "")
                {
                    smuen = smuen.Substring(0, smuen.Length - 1);
                }
                DataTable dtt = wm.GetList("pid=" + sid).Tables[0];
                string strid = "";
                string strid2 = "";
                foreach (DataRow dr in dtt.Rows)
                {
                    string str = dr["name"].ToString();
                    if (smuen.IndexOf(str) > -1)
                    {
                        strid += str + ",";
                    }
                    else
                    {
                        strid2 += dr["id"].ToString() + ",";
                    }
                }
                if (strid2 != "")
                {
                    strid2 = strid2.Substring(0, strid2.Length - 1);
                    wm.DeleteList(strid2);
                }

                string[] s = smuen.Split(',');
                foreach (string ss in s)
                {
                    if (strid.IndexOf(ss) == -1)
                    {
                        Cms.Model.wx_menu wmds = new Cms.Model.wx_menu();
                        wmds.name = ss;
                        wmds.pid = sid;
                        wmds.time = DateTime.Now;
                        wm.Add(wmds);
                    }
                }

            }
            if (seven == "click")
            {
                wmd.type = "click";
                string skey = tbkey.Text.Trim();
                if (wmd.keys != skey)
                {
                    DataTable dt = wm.GetList("keys='" + skey + "'").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                       // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('key值不能重复！')</script>");
                        Response.Write("<script>alert('key值不能重复!');window.location.href ='menu.aspx'</script>");
                        return;
                    }
                }
                wmd.keys = tbkey.Text.Trim();
                wmd.info = tinfo.Value.Trim();
            }
            if (seven == "url")
            {
                wmd.keys = "";
                wmd.type = "view";
                wmd.url = tburl.Text.Trim();
            }
            if (wm.Update(wmd))
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单设置成功"); //记录日志
               //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置成功！')</script>");
               Response.Write("<script>alert('设置成功!');window.location.href ='menu.aspx'</script>");
            }
            else
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单设置失败"); //记录日志
               // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置失败！')</script>");
                Response.Write("<script>alert('设置失败!');window.location.href ='menu.aspx'</script>");
            }
        }
        else
        {
            string name = tbname.Text.Trim();
            if (name != "")
            {
                DataTable dtwx = wm.GetList("").Tables[0];
                if (dtwx.Rows.Count == 0 || dtwx.Rows.Count < 3)
                {
                    wmd.name = name;
                    wmd.pid = "0";
                    wmd.time = DateTime.Now;
                    if (wm.Add(wmd) > 0)
                    {
                        adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单设置成功"); //记录日志
                        Response.Write("<script>alert('设置成功!');window.location.href ='menu.aspx'</script>");
                    }
                    else
                    {
                        adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单设置失败"); //记录日志
                        //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置失败！')</script>");
                        Response.Write("<script>alert('设置失败!');window.location.href ='menu.aspx'</script>");
                    }

                }
                else
                {
                    adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单设置无效"); //记录日志
                    Response.Write("<script>alert('设置无效!');window.location.href ='menu.aspx'</script>");
                   // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置无效！')</script>");
                    //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('设置无效！');", true);
                }
            }
            else
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单设置无效"); //记录日志
                Response.Write("<script>alert('设置无效!');window.location.href ='menu.aspx'</script>");
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置无效！')</script>");
                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('设置无效！');", true);
            }
        }
    }

    public string setmenu()
    {
        Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
        Cms.Model.wx_menu wmd = new Cms.Model.wx_menu();
        DataTable dt = wm.GetList("pid=0").Tables[0];
        StringBuilder sb = new StringBuilder();
        int i = 1;
        int j = 1;
        sb.Append("{");
        sb.Append("\"button\":[");
        foreach (DataRow dr in dt.Rows)
        {
            int id = int.Parse(dr["id"].ToString());
            string name = dr["name"].ToString();
            string type = dr["type"].ToString();
            string key = dr["keys"].ToString();
            string url = dr["url"].ToString();
            DataTable dts = wm.GetList("pid="+id).Tables[0];

            if (dts.Rows.Count > 0)
            {
                i = 1;
                sb.Append("{");
                sb.Append("\"name\":\"" + name + "\",");
                sb.Append("\"sub_button\":[");
                foreach (DataRow dr2 in dts.Rows)
                {
                    
                    int id2 = int.Parse(dr2["id"].ToString());
                    string name2 = dr2["name"].ToString();
                    string type2 = dr2["type"].ToString();
                    string key2 = dr2["keys"].ToString();
                    string url2 = dr2["url"].ToString();
                    if (i != dts.Rows.Count)
                    {
                        sb.Append("{");
                        if (type2 == "click")
                        {
                            sb.Append("\"type\":\"click\",");
                            sb.Append("\"name\":\"" + name2 + "\",");
                            sb.Append("\"key\":\"" + key2 + "\"");
                        }
                        if (type2 == "view")
                        {
                            sb.Append("\"type\":\"view\",");
                            sb.Append("\"name\":\"" + name2 + "\",");
                            sb.Append("\"url\":\"" + url2 + "\"");
                        }
                        sb.Append("},");
                    }
                    else
                    {
                        sb.Append("{");
                        if (type2 == "click")
                        {
                            sb.Append("\"type\":\"click\",");
                            sb.Append("\"name\":\"" + name2 + "\",");
                            sb.Append("\"key\":\"" + key2+ "\"");
                        }
                        if (type2 == "view")
                        {
                            sb.Append("\"type\":\"view\",");
                            sb.Append("\"name\":\"" + name2 + "\",");
                            sb.Append("\"url\":\"" + url2 + "\"");
                        }
                        if (j != 3)
                        {
                            sb.Append("}]},");
                        }
                        else
                        {
                            sb.Append("}]}");
                        }
                    }

                    i++;
                }
            }
            else {
                if (j != dt.Rows.Count)
                {
                    sb.Append("{");
                    if (type == "click")
                    {
                        sb.Append("\"type\":\"click\",");
                        sb.Append("\"name\":\"" + name + "\",");
                        sb.Append("\"key\":\"" + key + "\"");
                    }
                    if (type == "view")
                    {
                        sb.Append("\"type\":\"view\",");
                        sb.Append("\"name\":\"" + name + "\",");
                        sb.Append("\"url\":\"" + url + "\"");
                    }
                    sb.Append("},");
                }
                else {
                    sb.Append("{");
                    if (type == "click")
                    {
                        sb.Append("\"type\":\"click\",");
                        sb.Append("\"name\":\"" + name + "\",");
                        sb.Append("\"key\":\"" + key + "\"");
                    }
                    if (type == "view")
                    {
                        sb.Append("\"type\":\"view\",");
                        sb.Append("\"name\":\"" + name + "\",");
                        sb.Append("\"url\":\"" + url + "\"");
                    }
                    sb.Append("}");
                }
            }
           

            j++;
        }
        sb.Append("]");
        sb.Append("}");
        return sb.ToString();
    }
    
    public string setinfo(string posturl, string postData)
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
                Bind();

                setinfo("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + str, postData);


            }


            //if (content.IndexOf("openid") > -1)
            //{
            //    string[] s = content.Split('[');
            //    string[] s2 = s[1].Split(']');
            //    content = s2[0].ToString();
            //}


            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }

    public string GetPage3(string posturl, string postData,int type)
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
                Bind();
                //if (type == 0)
                //{
                //    GetPage3("http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token=" + str + "&type=image", postData, type);
                //}
                if (type == 1)
                {
                    GetPage3("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token=" + str, postData, type);
                }

            }
            string[] s = content.Split(',');
            string contents = s[1].Replace("\"media_id\":\"", "").Replace("\"", "");


            if (content.IndexOf("media_id") > -1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                sb.Append("\"touser\":[");
                sb.Append("" + GetPage4("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + hdid.Value, "") + "");
                sb.Append(" ],");
                sb.Append("\"mpnews\":{");
                sb.Append("\"media_id\":\""+contents+"\"");
                sb.Append(" },");
                sb.Append("\"msgtype\":\"mpnews\"");
                sb.Append("}");

                string str = GetPage3("https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token=" + hdid.Value + "", sb.ToString(), 0);
            }
            else if (content.IndexOf("0") > -1)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单推送成功"); //记录日志
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('推送成功！');", true);
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('推送成功！')</script>");
                return null;
            }
            else
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单推送失败"); //记录日志
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('推送失败！" + content + "');", true);
              //  ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('推送失败！" + content + "')</script>");
                return null;
            }
            //Response.Write(content);
            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }
    public string GetPage3(string posturl, string postData)
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
                Bind();
              
                GetPage3("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token=" + str, postData);
               

            }
           

            if (content.IndexOf("0") > -1)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单推送成功"); //记录日志
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('推送成功！');", true);
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('推送成功！')</script>");
            }
            else
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "微信菜单推送失败"); //记录日志
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('推送失败！" + content + "');", true);
               // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('推送失败！" + content + "')</script>");
            }
            //Response.Write(content);
            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }
    public string UploadMultimedia(string ACCESS_TOKEN, string Type)
    {
        string result = "";
        string wxurl = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token=" + ACCESS_TOKEN + "&type=" + Type;
        string filepath = Server.MapPath("image") + "\\01.jpg"; //(本地服务器的地址)
       // string filepath = "http://www.muhn.org.cn/Upload/image/20140827/20140827100505_4660.jpg";
         //WriteLog("上传路径:" + filepath);
        WebClient myWebClient = new WebClient();
        myWebClient.Credentials = CredentialCache.DefaultCredentials;
        try
        {
            byte[] responseArray = myWebClient.UploadFile(wxurl, "POST", filepath);
            result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
            if (result.IndexOf("42001") > -1)
            {
                string str = Gettoken();
                Cms.BLL.wx_info wx = new Cms.BLL.wx_info();
                Cms.Model.wx_info mwx = new Cms.Model.wx_info();
                mwx = wx.GetModel(1);
                mwx.access_token = str;
                wx.Update(mwx);
                Bind();
                UploadMultimedia(str,Type);
            }
            string[] s = result.Split(',');
            result = s[1].Replace("\"media_id\":\"", "").Replace("\"", "");
        }
        catch (Exception ex)
        {
            result = "Error:" + ex.Message;
        }
       // WriteLog("上传MediaId:" + result);
        return result;
    }

    public string GetPage4(string posturl, string postData)
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
                Bind();

                GetPage4("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + str, postData);


            }


            if (content.IndexOf("openid") > -1)
            {
                string[] s = content.Split('[');

                string[] scount = s[0].Split(',');
                int stotal =int.Parse(scount[0].Replace("\"", "").Replace("total:", "").Replace("{",""));

                string[] s2 = s[1].Split(']');
                content = s2[0].ToString();
                string snextid = s2[1].Replace("\"", "").Replace("}", "").Replace("next_openid:", "");
                if (stotal > 10000 && snextid.Length>1) {

                    content = content+","+GetPage4("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + hdid.Value + "&next_openid=" + snextid + "", "");
                }
            }


            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }


    [AjaxPro.AjaxMethod]
    public string setmenu(string name)
    {
        if (name == "maincd1")
        {
          return  bindlist("1");
        }
        if (name == "maincd2")
        {
            return bindlist("2");
        }
        if (name == "maincd3")
        {
            return bindlist("3");
        }
        return "";
    }

    [AjaxPro.AjaxMethod]
    public string setmenutype(string name)
    {
        Cms.BLL.wx_menu wx = new Cms.BLL.wx_menu();
        DataTable dt= wx.GetList("name='" + name + "'").Tables[0];
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["type"].ToString();
        }
        return "";
    }

    [AjaxPro.AjaxMethod]
    public string setmenuvalue(string name,int type)
    {
        Cms.BLL.wx_menu wx = new Cms.BLL.wx_menu();
        DataTable dt = wx.GetList("name='" + name + "'").Tables[0];
        if (dt.Rows.Count > 0)
        {
            if(type==0)
                return dt.Rows[0]["keys"].ToString();
            if (type == 1)
                return dt.Rows[0]["url"].ToString();
            if (type == 2)
                return dt.Rows[0]["info"].ToString();
        }
        return "";
    }
    
}