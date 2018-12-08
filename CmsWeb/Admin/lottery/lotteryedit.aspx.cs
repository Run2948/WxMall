using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_lottery_lotteryedit : System.Web.UI.Page
{
    public string classname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //登录验证
            adminUser.GetLoginState();

            //登录信息
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["admin"];

            if (cookie != null)
            {
                Application["adminname"] = (string)cookie.Values["adminname"];
                Application["adminType"] = (string)cookie.Values["adminType"];
            }
            else if (Session["adminname"] != null)
            {
                Application["adminname"] = (string)Session["adminname"];
                Application["adminType"] = (string)Session["adminType"];
            }
           
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID=================================
            string typeid = Request.QueryString["typeid"].ToString();
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add=================================
            switch (action)
            {
                case "add":
                    tbstime.Text =DateTime.Now.ToString();
                    tbetime.Text =DateTime.Now.AddDays(1).ToString();
                    break;
                case "edit":
                    this.bind_date(id);// 赋值操作信息=================================
                    break;
            }
            if (typeid == "1")
            {
                classname = "大转盘抽奖";
               
            }
            if (typeid == "2")
            {
                classname = "刮刮乐抽奖";
               
            }
            if (typeid == "3")
            {
                classname = "随机抽奖";
               
            }
        }
    }

    #region 赋值操作信息=================================
    public void bind_date(int _id)
    {
        Cms.BLL.ws_Lottery bll = new Cms.BLL.ws_Lottery();
        Cms.Model.ws_Lottery model = bll.GetModel(_id);
        tbname.Text=model.lname ;
        if (model.isnum == 1)
        {
            isnum.Checked = true;
        }
        else
        {
            isnum.Checked = false;
        }
        tbstime.Text = model.stime.ToString();
        tbetime.Text = model.etime.ToString();
        tbinfo.Value = model.info.ToString();
        photoUrl.Text = model.picurl;
        tbtotal.Text = model.total.ToString();
        tbdaynum.Text = model.daynum.ToString();
        Cms.BLL.ws_Prize wsbl = new Cms.BLL.ws_Prize();
        DataTable dt = wsbl.GetList("pid=" + _id + " order by orderNumber asc").Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == 0)
            {
                tbjxname.Text = dt.Rows[i]["pname"].ToString();
                tbjpname.Text = dt.Rows[i]["prize"].ToString();
                tbnumber.Text = dt.Rows[i]["quantity"].ToString();
                tbgl.Text = dt.Rows[i]["probability"].ToString();
            }
            if (i == 1)
            {
                tbjxname2.Text = dt.Rows[i]["pname"].ToString();
                tbjpname2.Text = dt.Rows[i]["prize"].ToString();
                tbnumber2.Text = dt.Rows[i]["quantity"].ToString();
                tbgl2.Text = dt.Rows[i]["probability"].ToString();
            }
            if (i == 2)
            {
                tbjxname3.Text = dt.Rows[i]["pname"].ToString();
                tbjpname3.Text = dt.Rows[i]["prize"].ToString();
                tbnumber3.Text = dt.Rows[i]["quantity"].ToString();
                tbgl3.Text = dt.Rows[i]["probability"].ToString();
            }
            if (i == 3)
            {
                tbjxname4.Text = dt.Rows[i]["pname"].ToString();
                tbjpname4.Text = dt.Rows[i]["prize"].ToString();
                tbnumber4.Text = dt.Rows[i]["quantity"].ToString();
                tbgl4.Text = dt.Rows[i]["probability"].ToString();
            }
            if (i == 4)
            {
                tbjxname5.Text = dt.Rows[i]["pname"].ToString();
                tbjpname5.Text = dt.Rows[i]["prize"].ToString();
                tbnumber5.Text = dt.Rows[i]["quantity"].ToString();
                tbgl5.Text = dt.Rows[i]["probability"].ToString();
            }
            if (i == 5)
            {
                tbjxname6.Text = dt.Rows[i]["pname"].ToString();
                tbjpname6.Text = dt.Rows[i]["prize"].ToString();
                tbnumber6.Text = dt.Rows[i]["quantity"].ToString();
                tbgl6.Text = dt.Rows[i]["probability"].ToString();
            }
        }

    }
    #endregion

  

    #region 增加操作=================================
    private bool DataAdd()
    {
        string typeid = Request.QueryString["typeid"].ToString();
        Cms.BLL.ws_Lottery bll = new Cms.BLL.ws_Lottery();
        Cms.Model.ws_Lottery model = new Cms.Model.ws_Lottery();
        model.lname = tbname.Text.Trim();
        model.stime =Convert.ToDateTime(tbstime.Text.Trim());
        model.etime =Convert.ToDateTime(tbetime.Text.Trim());
        model.picurl = photoUrl.Text.Trim();
        model.info = tbinfo.Value.Trim();
        int num=0;
        if(isnum.Checked)
        {
          num=1;
        }
        model.isnum = num;
        model.total = int.Parse(tbtotal.Text.Trim());
        model.daynum = int.Parse(tbdaynum.Text.Trim());
        model.typeid = int.Parse(typeid);
        DateTime time = DateTime.Now;
        model.updatetime = time;


        int id = bll.Add(model);

        if (id > 0)
        {
            {
                //奖项
                Cms.BLL.ws_Prize Prize = new Cms.BLL.ws_Prize();
                if (tbjxname.Text.Trim() != "" && tbjxname.Text.Trim().Length != 0)
                {
                    Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                    mPrize.pname = tbjxname.Text.Trim();
                    mPrize.prize = tbjpname.Text.Trim();
                    mPrize.quantity =int.Parse(tbnumber.Text.Trim());
                    mPrize.probability =int.Parse(tbgl.Text.Trim());
                    mPrize.pid = id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 0;
                    Prize.Add(mPrize);
                }
                if (tbjxname2.Text.Trim() != "" && tbjxname2.Text.Trim().Length != 0)
                {
                    Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                    mPrize.pname = tbjxname2.Text.Trim();
                    mPrize.prize = tbjpname2.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber2.Text.Trim());
                    mPrize.probability = int.Parse(tbgl2.Text.Trim());
                    mPrize.pid = id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 1;
                    Prize.Add(mPrize);
                }
                if (tbjxname3.Text.Trim() != "" && tbjxname3.Text.Trim().Length != 0)
                {
                    Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                    mPrize.pname = tbjxname3.Text.Trim();
                    mPrize.prize = tbjpname3.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber3.Text.Trim());
                    mPrize.probability = int.Parse(tbgl3.Text.Trim());
                    mPrize.pid = id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 2;
                    Prize.Add(mPrize);
                }
                if (tbjxname4.Text.Trim() != "" && tbjxname4.Text.Trim().Length != 0)
                {
                    Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                    mPrize.pname = tbjxname4.Text.Trim();
                    mPrize.prize = tbjpname4.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber4.Text.Trim());
                    mPrize.probability = int.Parse(tbgl4.Text.Trim());
                    mPrize.pid = id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 3;
                    Prize.Add(mPrize);
                }
                if (tbjxname5.Text.Trim() != "" && tbjxname5.Text.Trim().Length != 0)
                {
                    Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                    mPrize.pname = tbjxname5.Text.Trim();
                    mPrize.prize = tbjpname5.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber5.Text.Trim());
                    mPrize.probability = int.Parse(tbgl5.Text.Trim());
                    mPrize.pid = id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 4;
                    Prize.Add(mPrize);
                }
                if (tbjxname6.Text.Trim() != "" && tbjxname6.Text.Trim().Length != 0)
                {
                    Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                    mPrize.pname = tbjxname6.Text.Trim();
                    mPrize.prize = tbjpname6.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber6.Text.Trim());
                    mPrize.probability = int.Parse(tbgl6.Text.Trim());
                    mPrize.pid = id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 5;
                    Prize.Add(mPrize);
                }
            }
            //写入登录日志
            Cms.Model.C_admin_log adminlog = new Cms.Model.C_admin_log();
            Cms.BLL.C_admin_log adminlogdal = new Cms.BLL.C_admin_log();
            adminlog.user_id = Convert.ToInt32((string)Session["adminid"]);//用户名角色ID
            adminlog.user_name = (string)Session["adminname"];//用户名
            adminlog.user_ip = Cms.Common.ManagementInfo.GetIP();//ip地址
            adminlog.action_type = "Add";
            adminlog.action_type = "添加抽奖活动" + this.tbname.Text.Trim();
            adminlog.add_time = Convert.ToDateTime(Cms.Common.ManagementInfo.GetTime());//时间
            adminlogdal.Add(adminlog);

            JscriptMsg("添加信息成功！", "lotterylist.aspx?typeid="+typeid, "Success");
            return true;
        }
        else
        {
            JscriptMsg("添加信息失败！", "lotteryedit.aspx?action=add&typeid="+typeid, "Error");
            return false;
        }

    }
    #endregion

    #region 修改操作=================================
    private bool DataUpdate(int _id)
    {
  
        string typeid = Request.QueryString["typeid"].ToString();
        Cms.BLL.ws_Lottery bll = new Cms.BLL.ws_Lottery();
        Cms.Model.ws_Lottery model = new Cms.Model.ws_Lottery();
        model = bll.GetModel(_id);
        model.id = _id;
        model.lname = tbname.Text.Trim();
        model.stime = Convert.ToDateTime(tbstime.Text.Trim());
        model.etime = Convert.ToDateTime(tbetime.Text.Trim());
        model.picurl = photoUrl.Text.Trim();
        model.info = tbinfo.Value.Trim();
        int num = 0;
        if (isnum.Checked)
        {
            num = 1;
        }
        model.isnum = num;
        model.total = int.Parse(tbtotal.Text.Trim());
        model.daynum = int.Parse(tbdaynum.Text.Trim());
        //model.typeid = int.Parse(typeid);
        DateTime time = DateTime.Now;
       // model.updatetime = time;

        if (bll.Update(model))
        {
            Cms.BLL.ws_Prize Prize = new Cms.BLL.ws_Prize();
            DataTable dt = Prize.GetList("pid=" + _id + " order by orderNumber asc").Tables[0];
            if (tbjxname.Text.Trim() != "" && tbjxname.Text.Trim().Length != 0)
            {
                Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                if (dt.Rows.Count >= 1)
                {
                    mPrize = Prize.GetModel(int.Parse(dt.Rows[0]["id"].ToString()));
                    mPrize.pname = tbjxname.Text.Trim();
                    mPrize.prize = tbjpname.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber.Text.Trim());
                    mPrize.probability = int.Parse(tbgl.Text.Trim());
                    Prize.Update(mPrize);
                }
                else {
                    mPrize.pname = tbjxname.Text.Trim();
                    mPrize.prize = tbjpname.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber.Text.Trim());
                    mPrize.probability = int.Parse(tbgl.Text.Trim());
                    mPrize.pid = _id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 0;
                    Prize.Add(mPrize);
                }
            }
            if (tbjxname2.Text.Trim() != "" && tbjxname2.Text.Trim().Length != 0)
            {
                Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                if (dt.Rows.Count >= 2)
                {
                    mPrize = Prize.GetModel(int.Parse(dt.Rows[1]["id"].ToString()));
                    mPrize.pname = tbjxname2.Text.Trim();
                    mPrize.prize = tbjpname2.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber2.Text.Trim());
                    mPrize.probability = int.Parse(tbgl2.Text.Trim());
                    Prize.Update(mPrize);
                }
                else
                {
                    mPrize.pname = tbjxname2.Text.Trim();
                    mPrize.prize = tbjpname2.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber2.Text.Trim());
                    mPrize.probability = int.Parse(tbgl2.Text.Trim());
                    mPrize.pid = _id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 1;
                    Prize.Add(mPrize);
                }
            }
            if (tbjxname3.Text.Trim() != "" && tbjxname3.Text.Trim().Length != 0)
            {
                Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                if (dt.Rows.Count >= 3)
                {
                    mPrize = Prize.GetModel(int.Parse(dt.Rows[2]["id"].ToString()));
                    mPrize.pname = tbjxname3.Text.Trim();
                    mPrize.prize = tbjpname3.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber3.Text.Trim());
                    mPrize.probability = int.Parse(tbgl3.Text.Trim());
                    Prize.Update(mPrize);
                }
                else
                {
                    mPrize.pname = tbjxname3.Text.Trim();
                    mPrize.prize = tbjpname3.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber3.Text.Trim());
                    mPrize.probability = int.Parse(tbgl3.Text.Trim());
                    mPrize.pid = _id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 2;
                    Prize.Add(mPrize);
                }
            }
            if (tbjxname4.Text.Trim() != "" && tbjxname4.Text.Trim().Length != 0)
            {
                Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                if (dt.Rows.Count >= 4)
                {
                    mPrize = Prize.GetModel(int.Parse(dt.Rows[3]["id"].ToString()));
                    mPrize.pname = tbjxname4.Text.Trim();
                    mPrize.prize = tbjpname4.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber4.Text.Trim());
                    mPrize.probability = int.Parse(tbgl4.Text.Trim());
                    Prize.Update(mPrize);
                }
                else
                {
                    mPrize.pname = tbjxname4.Text.Trim();
                    mPrize.prize = tbjpname4.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber4.Text.Trim());
                    mPrize.probability = int.Parse(tbgl4.Text.Trim());
                    mPrize.pid = _id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 3;
                    Prize.Add(mPrize);
                }
            }
            if (tbjxname5.Text.Trim() != "" && tbjxname5.Text.Trim().Length != 0)
            {
                Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                if (dt.Rows.Count >= 5)
                {
                    mPrize = Prize.GetModel(int.Parse(dt.Rows[4]["id"].ToString()));
                    mPrize.pname = tbjxname5.Text.Trim();
                    mPrize.prize = tbjpname5.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber5.Text.Trim());
                    mPrize.probability = int.Parse(tbgl5.Text.Trim());
                    Prize.Update(mPrize);
                }
                else
                {
                    mPrize.pname = tbjxname5.Text.Trim();
                    mPrize.prize = tbjpname5.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber5.Text.Trim());
                    mPrize.probability = int.Parse(tbgl5.Text.Trim());
                    mPrize.pid = _id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 4;
                    Prize.Add(mPrize);
                }
            }
            if (tbjxname6.Text.Trim() != "" && tbjxname6.Text.Trim().Length != 0)
            {
                Cms.Model.ws_Prize mPrize = new Cms.Model.ws_Prize();
                if (dt.Rows.Count == 6)
                {
                    mPrize = Prize.GetModel(int.Parse(dt.Rows[5]["id"].ToString()));
                    mPrize.pname = tbjxname6.Text.Trim();
                    mPrize.prize = tbjpname6.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber6.Text.Trim());
                    mPrize.probability = int.Parse(tbgl6.Text.Trim());
                    Prize.Update(mPrize);
                }
                else
                {
                    mPrize.pname = tbjxname6.Text.Trim();
                    mPrize.prize = tbjpname6.Text.Trim();
                    mPrize.quantity = int.Parse(tbnumber6.Text.Trim());
                    mPrize.probability = int.Parse(tbgl6.Text.Trim());
                    mPrize.pid = _id;
                    mPrize.updatetime = time;
                    mPrize.orderNumber = 5;
                    Prize.Add(mPrize);
                }
            }
          
         
            //写入登录日志
            Cms.Model.C_admin_log adminlog = new Cms.Model.C_admin_log();
            Cms.BLL.C_admin_log adminlogdal = new Cms.BLL.C_admin_log();
            adminlog.user_id = Convert.ToInt32((string)Session["adminid"]);//用户名角色ID
            adminlog.user_name = (string)Session["adminname"];//用户名
            adminlog.user_ip = Cms.Common.ManagementInfo.GetIP();//ip地址
            adminlog.action_type = "Edit";
            adminlog.action_type = "修改抽奖活动" + this.tbname.Text.Trim();
            adminlog.add_time = Convert.ToDateTime(Cms.Common.ManagementInfo.GetTime());//时间
            adminlogdal.Add(adminlog);

            JscriptMsg("修改信息成功！", "lotterylist.aspx?typeid=" + typeid, "Success");
            return true;
        }
        else
        {
            JscriptMsg("修改信息失败！", "lotteryedit.aspx?action=edit&id=" + _id + "&typeid=" + typeid, "Error");
            return false;
        }


    }
    #endregion

    #region 保存========================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//栏目ID
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        switch (action)
        {
            case "add":
                this.DataAdd();
                break;
            case "edit":
                this.DataUpdate(id);
                break;
        }
    }
    #endregion

    #region 提示框==========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}