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
public partial class Admin_wx_menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string str = "{\"access_token\":\"HG2dJ-T0-KgBYKDSOYQ2makk5bhj7QRlJYKOETr_aVzAX_4PbmnhaOJ77U_I85zx4Tx89c5ySJlJyPmvzueYWQ\",\"expires_in\":7200}";
        //string[] s = str.Split(',');
        //Response.Write(s[0].Replace("access_token", "").Replace(":","").Replace("{","").Replace("\"",""));
        if (!IsPostBack)
            Bind();
       // Gettoken();
    }

    public void Bind()
    {
       // Response.Write(setmenu());
        Cms.BLL.wx_info wx = new Cms.BLL.wx_info();
        Cms.Model.wx_info mwx = new Cms.Model.wx_info();
        DataTable dt = wx.GetList("").Tables[0];
        if (dt.Rows.Count > 0)
        {
            mwx = wx.GetModel(1);
            if (mwx != null)
            {
                AppId.Text = mwx.AppId;
                AppSecret.Text = mwx.AppSecret;
                hdid.Text = mwx.access_token;
            }
            mwx = wx.GetModel(2);
            if (mwx != null)
            {
                tbid.Text = mwx.AppId;
                tburls.Text = mwx.AppSecret;
            }
           
        }
        Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
        Cms.Model.wx_menu wmd = new Cms.Model.wx_menu();
        dt = wm.GetList("pid=0").Tables[0];
       
        foreach (DataRow dr in dt.Rows)
        {
            int id = int.Parse(dr["id"].ToString());
            string name = dr["name"].ToString();
            int pid = int.Parse(dr["pid"].ToString());
            if (id == 1)
            {
                DataTable dts = wm.GetList("pid=" + id).Tables[0];
             
               
                ListBox1.DataSource = dts.DefaultView;
                ListBox1.DataTextField = "name";
                ListBox1.DataValueField = "id";
                ListBox1.DataBind();
                ListBox1.Items.Insert(0, new ListItem(name, id.ToString()));
            }
            if (id == 2)
            {
                DataTable dts = wm.GetList("pid=" + id).Tables[0];
              
                ListBox2.DataSource = dts.DefaultView;
                ListBox2.DataTextField = "name";
                ListBox2.DataValueField = "id";
                ListBox2.DataBind();
                ListBox2.Items.Insert(0, new ListItem(name, id.ToString()));
            }
            if (id == 3)
            {
                DataTable dts = wm.GetList("pid=" + id).Tables[0];
               
                ListBox3.DataSource = dts.DefaultView;
                ListBox3.DataTextField = "name";
                ListBox3.DataValueField = "id";
                ListBox3.DataBind();
                ListBox3.Items.Insert(0, new ListItem(name, id.ToString()));
            }
        }
    }

   
    
    public string Gettoken()
    {
        string sAppId = AppId.Text.Trim();
        string sAppSecret = AppSecret.Text.Trim();
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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        Cms.BLL.wx_info wx = new Cms.BLL.wx_info();
        Cms.Model.wx_info mwx = new Cms.Model.wx_info();
        DataTable dt = wx.GetList("id=1").Tables[0];
        bool bl = false;
        if (dt.Rows.Count > 0)
        {
            mwx = wx.GetModel(1);
            mwx.AppId = AppId.Text.Trim();
            mwx.AppSecret = AppSecret.Text.Trim();
            mwx.access_token = hdid.Text.Trim();
            bl = wx.Update(mwx);
        }
        else
        {
            mwx.AppId = AppId.Text.Trim();
            mwx.AppSecret=AppSecret.Text.Trim();
            mwx.access_token = Gettoken();
            if (wx.Add(mwx) > 0) {
                bl= true;
               
            }
        }
        if (bl)
        {
            Bind();
            ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置成功！')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置失败！')</script>");
        }
    }
 
    
    protected void ListBox1_TextChanged(object sender, EventArgs e)
    {
        PlaceHolder4.Visible = true;
        ListBox2.ClearSelection();
        ListBox3.ClearSelection();

        ddeven.Items.Clear();
        int value = int.Parse(ListBox1.SelectedItem.Value);
        tbname.Text = ListBox1.SelectedItem.Text;
        if (value == 1)
        {
            bindlist(value.ToString());
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;
            ddeven.Items.Insert(0, new ListItem("显示二级菜单", "0"));
            ddeven.Items.Insert(1, new ListItem("点击事件", "click"));
            ddeven.Items.Insert(2, new ListItem("链接地址", "url"));
        }
        else
        {
            ddeven.Items.Insert(0, new ListItem("点击事件", "click"));
            ddeven.Items.Insert(1, new ListItem("链接地址", "url"));
            Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
            
            DataTable dt = wm.GetList("id=" + value).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string type = dr["type"].ToString();
                if (type == "click")
                {
                    ddeven.SelectedValue = "click";
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = true;
                    PlaceHolder3.Visible = false;
                    tbkey.Text = dr["keys"].ToString();
                    tinfo.Value = dr["info"].ToString();
                    tcontent.Value = dr["content"].ToString();
                }
                else
                {
                    ddeven.SelectedValue = "url";
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = false;
                    PlaceHolder3.Visible = true;
                    tburl.Text = dr["url"].ToString();
                }
            }
           
        }

       
    }
    protected void ListBox2_TextChanged(object sender, EventArgs e)
    {
        PlaceHolder4.Visible = true;
        ListBox1.ClearSelection();
        ListBox3.ClearSelection();
        ddeven.Items.Clear();
        int value = int.Parse(ListBox2.SelectedItem.Value);
        if (value == 2)
        {
            bindlist(value.ToString());
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;
            ddeven.Items.Insert(0, new ListItem("显示二级菜单", "0"));
            ddeven.Items.Insert(1, new ListItem("点击事件", "click"));
            ddeven.Items.Insert(2, new ListItem("链接地址", "url"));
        }
        else
        {
            ddeven.Items.Insert(0, new ListItem("点击事件", "click"));
            ddeven.Items.Insert(1, new ListItem("链接地址", "url"));
            Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();

            DataTable dt = wm.GetList("id=" + value).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string type = dr["type"].ToString();
                if (type == "click")
                {
                    ddeven.SelectedValue = "click";
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = true;
                    PlaceHolder3.Visible = false;
                    tbkey.Text = dr["keys"].ToString();
                    tinfo.Value = dr["info"].ToString();
                    tcontent.Value = dr["content"].ToString();
                }
                else
                {
                    ddeven.SelectedValue = "url";
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = false;
                    PlaceHolder3.Visible = true;
                    tburl.Text = dr["url"].ToString();
                }
            }
        }

        tbname.Text = ListBox2.SelectedItem.Text;
       
       
    }
    protected void ListBox3_TextChanged(object sender, EventArgs e)
    {
        PlaceHolder4.Visible = true;
        ListBox1.ClearSelection();
        ListBox2.ClearSelection();
        ddeven.Items.Clear();
        int value = int.Parse(ListBox3.SelectedItem.Value);
        if (value == 3)
        {
            bindlist(value.ToString());
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;
            ddeven.Items.Insert(0, new ListItem("显示二级菜单", "0"));
            ddeven.Items.Insert(1, new ListItem("点击事件", "click"));
            ddeven.Items.Insert(2, new ListItem("链接地址", "url"));
        }
        else
        {
            ddeven.Items.Insert(0, new ListItem("点击事件", "click"));
            ddeven.Items.Insert(1, new ListItem("链接地址", "url"));
            Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();

            DataTable dt = wm.GetList("id=" + value).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string type = dr["type"].ToString();
                if (type == "click")
                {
                    ddeven.SelectedValue = "click";
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = true;
                    PlaceHolder3.Visible = false;
                    tbkey.Text = dr["keys"].ToString();
                    tinfo.Value = dr["info"].ToString();
                    tcontent.Value = dr["content"].ToString();
                }
                else
                {
                    ddeven.SelectedValue = "url";
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = false;
                    PlaceHolder3.Visible = true;
                    tburl.Text = dr["url"].ToString();
                }
            }
        }

        tbname.Text = ListBox3.SelectedItem.Text;
    

    }

    
    protected void ddeven_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        string sid = "";
        if (ListBox1.SelectedItem != null)
            sid = ListBox1.SelectedItem.Value;

        if (ListBox2.SelectedItem != null)
            sid = ListBox2.SelectedItem.Value;

        if (ListBox3.SelectedItem != null)
            sid = ListBox3.SelectedItem.Value;

        string value = ddeven.SelectedValue.ToString();
        if (value == "0")
        {
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = false;
        }
        if (value == "click")
        {
            Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
            tbkey.Text = wm.GetList("id="+sid).Tables[0].Rows[0]["keys"].ToString();
            tinfo.Value = wm.GetList("id=" + sid).Tables[0].Rows[0]["info"].ToString();
            tcontent.Value = wm.GetList("id=" + sid).Tables[0].Rows[0]["content"].ToString();
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = true;
            PlaceHolder3.Visible = false;
        }
        if (value == "url")
        {
            Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
            tburl.Text = wm.GetList("id=" + sid).Tables[0].Rows[0]["url"].ToString();
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = false;
            PlaceHolder3.Visible = true;
        }


    }

    public void bindlist(string id)
    {
        string sid = "";
        if (ListBox1.SelectedItem != null)
            sid = ListBox1.SelectedItem.Value;

        if (ListBox2.SelectedItem != null)
            sid = ListBox2.SelectedItem.Value;

        if (ListBox3.SelectedItem != null)
            sid = ListBox3.SelectedItem.Value;

        Cms.BLL.wx_menu wm = new Cms.BLL.wx_menu();
        Cms.Model.wx_menu wmd = new Cms.Model.wx_menu();
        DataTable dt = wm.GetList("pid="+id).Tables[0];
        tbmenu1.Text = "";
        tbmenu2.Text = "";
        tbmenu3.Text = "";
        tbmenu4.Text = "";
        tbmenu5.Text = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == 0)
            {
                tbmenu1.Text = dt.Rows[i]["name"].ToString();
            }
            if (i == 1)
            {
                tbmenu2.Text = dt.Rows[i]["name"].ToString();
            }
            if (i ==2)
            {
                tbmenu3.Text = dt.Rows[i]["name"].ToString();
            }
            if (i == 3)
            {
                tbmenu4.Text = dt.Rows[i]["name"].ToString();
            }
            if (i == 4)
            {
                tbmenu5.Text = dt.Rows[i]["name"].ToString();
            }
        }


    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GetPage("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + hdid.Text, setmenu());
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

            if (content.IndexOf("42001") > -1)
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
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('发布成功！');", true);
               // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('发布成功！')</script>");
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('发布失败！" + content + "');", true);
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('发布失败！" + content + "')</script>"); 
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

        GetPage2("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + hdid.Text, setmenu());
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
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('停用失败！" + content + "')</script>");
             //   Response.Write("<script>alert('停用失败!" + content + "');window.location.href ='menu.aspx'</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('停用失败！');", true);

            }
            if (content.IndexOf("ok") > -1)
            {
                //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('停用成功！')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('停用成功！');", true);
               // Response.Write("<script>alert('停用成功!');window.location.href ='menu.aspx'</script>");
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
        if(ListBox1.SelectedItem!=null)
            sid = ListBox1.SelectedItem.Value;

        if (ListBox2.SelectedItem != null)
            sid = ListBox2.SelectedItem.Value;

        if (ListBox3.SelectedItem != null)
            sid = ListBox3.SelectedItem.Value;


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
                        //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('key值不能重复！')</script>");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('key值不能重复！');", true);
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
               // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置成功！')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('设置成功！');", true);
            }
            else
            {
               // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置失败！')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('设置失败！');", true);
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
                        //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置成功！')</script>");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('设置成功！');", true);
                    }
                    else
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置失败！')</script>");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('设置失败！');", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('设置无效！');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('设置无效！');", true);
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
    protected void btnts_Click(object sender, EventArgs e)
    {
        Cms.BLL.C_article cb=new Cms.BLL.C_article();
        int id = int.Parse(tbid.Text.Trim()==""?"0":tbid.Text.Trim());
        if (id == 0) return;
        DataTable dt = cb.GetList("articleId="+id).Tables[0];
        if (dt.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "", "alert('文章不存在！');", true);
            return;
        }
        DataRow dr = dt.Rows[0];
        string strurl = tburls.Text.Trim();
        if (strurl == "")
        {
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "", "alert('请输入文章路径！');", true);
            return;
        }
        string[] suser = GetPage4("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + hdid.Text, "").Split(',');
        
        //string str = UploadMultimedia(hdid.Text, "image");
        string surl ="http://"+HttpContext.Current.Request.Url.Host.ToString();
        string spic=surl+dr["photourl"].ToString();
        foreach (string s in suser)
        {
            if (s == "")
            {
                continue;
            }
            StringBuilder sb = new StringBuilder();
            //sb.Append("{");
            //sb.Append("\"touser\":"+s+",");
            //sb.Append("\"msgtype\":\"image\",");
            //sb.Append("\"image\":");
            //sb.Append("{");
            //sb.Append("\"media_id\":\"" + str + "\"");
            //sb.Append("}");
            //sb.Append("}");

            sb.Append("{");
            sb.Append("\"touser\":" + s + ",");
            sb.Append("\"msgtype\":\"news\",");
            sb.Append("\"news\":{");
            sb.Append("\"articles\":[");
            sb.Append("{");
            sb.Append("\"title\":\""+dr["title"].ToString()+"\",");
            sb.Append("\"description\":\"" + dr["intro"].ToString() + "\",");
            sb.Append("\"url\":\"" + strurl + "\",");
            sb.Append("\"picurl\":\"" + spic + "\"");
            sb.Append(" }");
            sb.Append("]");
            sb.Append("}");
            sb.Append("}");
            setinfo("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token="+hdid.Text.Trim(), sb.ToString());
        }

        //StringBuilder sb = new StringBuilder();
        //string str = UploadMultimedia(hdid.Text, "image");
        //sb.Append("{");
        //sb.Append("\"articles\": [");
        //sb.Append("{");
        //sb.Append("\"thumb_media_id\":\"" + str + "\",");
        //sb.Append("\"author\":\"\",");
        //sb.Append("\"title\":\"小额贷款审计我之见\",");
        //sb.Append("\"content_source_url\":\"http://www.muhn.org.cn/contents9.html\",");
        //sb.Append("\"content\":\"自2008年银监会、央行发布《关于小额贷款公司试点的指导意见》以来\",");
        //sb.Append("\"digest\":\"digest\",");
        //sb.Append("\"show_cover_pic\":\"1\"");
        //sb.Append("}");
        //sb.Append("]");
        //sb.Append("}");
        //GetPage3("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token="+hdid.Text, sb.ToString(), 1);
        Cms.BLL.wx_info wx = new Cms.BLL.wx_info();
        Cms.Model.wx_info mwx = new Cms.Model.wx_info();
        dt = wx.GetList("id=2").Tables[0];
        bool bl = false;
        if (dt.Rows.Count > 0)
        {
            mwx = wx.GetModel(2);
            mwx.AppId = tbid.Text.Trim();
            mwx.AppSecret = tburls.Text.Trim();
            bl = wx.Update(mwx);
        }
        else
        {
            mwx.AppId = tbid.Text.Trim();
            mwx.AppSecret = tburls.Text.Trim();
       
            if (wx.Add(mwx) > 0)
            {
                bl = true;

            }
        }
        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "", "alert('推送成功！');", true);
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
                sb.Append("" + GetPage4("https://api.weixin.qq.com/cgi-bin/user/get?access_token="+hdid.Text,"") + "");
                sb.Append(" ],");
                sb.Append("\"mpnews\":{");
                sb.Append("\"media_id\":\""+contents+"\"");
                sb.Append(" },");
                sb.Append("\"msgtype\":\"mpnews\"");
                sb.Append("}");

                string str=GetPage3("https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token=" + hdid.Text + "", sb.ToString(), 0);
            }
            else if (content.IndexOf("0") > -1)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('推送成功！')</script>");
                return null;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('推送失败！" + content + "')</script>");
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
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('推送成功！')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('推送失败！" + content + "')</script>");
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

                    content = content+","+GetPage4("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + hdid.Text + "&next_openid=" + snextid + "", "");
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
}