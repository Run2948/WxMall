using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Common;
public partial class Admin_user_useredit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;

            int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID



            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "add":
                    break;
                case "edit":
                    if (new Cms.BLL.C_user().Exists(userId))
                    {
                        this.DataBind(userId);//绑定信息
                    }
                    break;
            }

        }
    }


    #region 读取数据==================================
    public void DataBind(int userId)
    {
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        this.username.Text = model.username.ToString(); ;//姓名
        this.usercard.Text = model.usercard.ToString();//会员卡
        this.password.Text = model.password.ToString();//密码
        this.openid.Text = model.openid.ToString();//微信账号
        this.birthday.Text = string.Format("{0:yyyy-MM-dd}", model.birthday);
        this.useraddress.Text = model.useraddress.ToString();
        this.telphone.Text = model.telphone.ToString();
        this.marryday.Text = string.Format("{0:yyyy-MM-dd}", model.marryday);
        //this.userMoney.Text = Convert.ToDecimal(model.userMoney).ToString("0.00");
        this.userJifen.Text = model.userscore.ToString();
        this.shopcode.Text = model.shopcode.ToString();
        this.shopname.Text = model.shopname.ToString();
        this.sex.SelectedValue = model.sex.ToString();//性别
        this.updatetime.Text = model.updatetime.ToString();

        DataSet ds = new Cms.BLL.c_user_address().GetList("user_id=" + userId);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rptList.DataSource = ds.Tables[0].DefaultView;
            rptList.DataBind();
        }
        else
        {
            rptList.DataSource = ds.Tables[0].DefaultView;
            rptList.DataBind();
        }

        DataSet dsBuy = new Cms.BLL.C_ordersub().GetList("user_id=" + userId);
        if (dsBuy != null && dsBuy.Tables[0].Rows.Count > 0)
        {
            RepBuyRecord.DataSource = dsBuy.Tables[0].DefaultView;
            RepBuyRecord.DataBind();
        }
        else
        {
            RepBuyRecord.DataSource = dsBuy.Tables[0].DefaultView;
            RepBuyRecord.DataBind();
        }

        DataSet dsIntegral = new Cms.BLL.C_order_integralsub().GetList("user_id=" + userId);
        if (dsIntegral != null && dsIntegral.Tables[0].Rows.Count > 0)
        {
            RepIntegralRec.DataSource = dsIntegral.Tables[0].DefaultView;
            RepIntegralRec.DataBind();
        }
        else
        {
            RepIntegralRec.DataSource = dsIntegral.Tables[0].DefaultView;
            RepIntegralRec.DataBind();
        }

        DataSet dsOne = new Cms.BLL.C_integral_rec().GetList("user_id=" + userId);
        if (dsOne != null && dsOne.Tables[0].Rows.Count > 0)
        {
            Repeater1.DataSource = dsOne.Tables[0].DefaultView;
            Repeater1.DataBind();
        }
        else
        {
            Repeater1.DataSource = dsOne.Tables[0].DefaultView;
            Repeater1.DataBind();
        }


    }
    #endregion

    #region 保存===================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        Cms.BLL.C_user bll = new Cms.BLL.C_user();
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        model.sex = this.sex.SelectedValue;
        //model.userMoney = Convert.ToDecimal(this.userMoney.Text);
        model.telphone = telphone.Text;
        model.usercard = usercard.Text;
        DataSet ds = new Cms.BLL.C_user().GetList("usercard='" + model.usercard + "' and id<>" + userId);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && usercard.Text.ToString()!="")
        {
            JscriptMsg("会员编号已存在！", "useredit.aspx?action=edit&id=" + userId, "Error");
        }
        else
        {
            if (bll.Update(model))
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.username); //记录日志
                JscriptMsg("提交信息成功！", "userlist.aspx", "Success");
            }
            else
            {
                JscriptMsg("提交信息失败！", "useredit.aspx?action=edit&id=" + userId, "Error");
            }
        }
    }
    #endregion

    #region 会员绑定验证===================
    protected void UserBindSubmit_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        Cms.BLL.C_user bll = new Cms.BLL.C_user();
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        wxuser.UserSale wu = new wxuser.UserSale();
        wxuser.userinfo xw = new wxuser.userinfo();
        xw = wxuser.getUserBind(model.openid, model.telphone, model.usercard);
        Literal1.Text = xw.content + "-" + xw.result;
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"会员绑定验证\", \"" + Literal1.Text + "\", \"back\",\"Success\",\"\")", true);

    }
    #endregion

    #region 获取会员信息===================
    protected void UserInfoSubmit_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        Cms.BLL.C_user bll = new Cms.BLL.C_user();
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        wxuser.UserSale wu = new wxuser.UserSale();
        wxuser.userinfo xw = new wxuser.userinfo();
        xw = wxuser.getuserinfo(model.openid);
        Literal1.Text = "内容：" + xw.content + "；结果：" + xw.result + "；微信openid:" + xw.openid + "；性别：" + xw.sex + "；门店：" + xw.shopname + "；手机：" + xw.telephone + "；地址：" + xw.useraddress + "；所有积分：" + xw.userallscore + "；<br>会员卡：" + xw.usercard + "；会员等级：" + xw.userlevel + "；姓名：" + xw.username + "；未使用积分：" + xw.userscore + "；消费金额：" + xw.allbuy + "；生日：" + xw.birthday + "；结婚日期" + xw.marryday + "；消费次数：" + xw.buytimes;
        model.userallscore = Convert.ToInt32(xw.userallscore);
        model.userscore = Convert.ToInt32(xw.userscore);
        model.userYesScore = Convert.ToInt32(xw.userallscore) - Convert.ToInt32(xw.userscore);
        model.userlevel = xw.userlevel;
        // bll.Update(model);

        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"获取会员信息\", \"" + Literal1.Text + "\", \"back\",\"Success\",\"\")", true);
    }
    #endregion

    #region 更新会员信息===================
    protected void UserUpdateSubmit_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        Cms.BLL.C_user bll = new Cms.BLL.C_user();
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        wxuser.userinfo xw = new wxuser.userinfo();
        xw = wxuser.getUserUpdate(model.openid, model.usercard, model.username, model.sex, model.useraddress, string.Format("{0:yyyy-MM-dd}", model.birthday), string.Format("{0:yyyy-MM-dd}", model.marryday), model.telphone, model.shopcode);
        if (xw.result == "更新成功")
        {
            Literal1.Text = xw.content + "-" + xw.result;
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"更新会员信息\", \"" + Literal1.Text + "\", \"back\",\"Success\",\"\")", true);
        }
        else
        {
            Literal1.Text = xw.content + "-" + xw.result;
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"更新会员信息\", \"" + Literal1.Text + "\", \"back\",\"Success\",\"\")", true);
        }
    }
    #endregion

    #region 消费列表===================
    protected void UserSaleSubmit_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        Cms.BLL.C_user bll = new Cms.BLL.C_user();
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        wxuser.UserSale wu = new wxuser.UserSale();
        wxuser.userinfo xw = new wxuser.userinfo();
        List<wxuser.UserSale> list = new List<wxuser.UserSale>();
        list = wxuser.getUserSale(model.openid, model.usercard);
        for (int i = 0; i < list.Count; i++)
        {
            wxuser.UserSale ux = new wxuser.UserSale();
            ux = list[i];
            Literal1.Text = ux.content + "-" + ux.result + "||";
        }
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"消费列表\", \"" + Literal1.Text + "\", \"back\",\"Success\",\"\")", true);
    }
    #endregion

    #region 会员签到===================
    protected void UserSignSubmit_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        Cms.BLL.C_user bll = new Cms.BLL.C_user();
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        wxuser.UserSale wu = new wxuser.UserSale();
        wxuser.userinfo xw = new wxuser.userinfo();
        DateTime todaybegin = DateTime.Parse(DateTime.Now.ToShortDateString());
        DateTime mingtianBegin = todaybegin.AddDays(1);
        if (!Cms.DBUtility.DbHelperSQL.Exists("select count(1) from C_integral_rec where scorename='签到领取积分' and user_id=" + model.id + "and updateTime>='" + todaybegin + "' and updateTime<'" + mingtianBegin + "'"))
        {
            wxuser.userinfo userinfo = new wxuser.userinfo();
            xw = wxuser.getUserSign(model.openid, model.usercard);
            Literal1.Text = xw.content + "-" + xw.result;
            xw = wxuser.getuserinfo(model.openid);
            model.userallscore = Convert.ToInt32(xw.userallscore);
            model.userscore = Convert.ToInt32(xw.userscore);
            model.userYesScore = Convert.ToInt32(xw.userallscore) - Convert.ToInt32(xw.userscore);
            bll.Update(model);

            Cms.BLL.C_integral_rec integral_BLL = new Cms.BLL.C_integral_rec();
            Cms.Model.C_integral_rec integral_model = new Cms.Model.C_integral_rec();
            integral_model.article_id = 1;
            integral_model.user_id = model.id;
            integral_model.usercard = model.usercard;
            integral_model.openid = model.openid;
            integral_model.numberid = "2";
            integral_model.scorename = "签到领取积分";
            integral_model.title = "签到领取积分";
            integral_model.wescore = 2000;
            integral_model.quantity = 1;
            integral_model.type = 0;
            integral_model.updateTime = DateTime.Now;
            integral_BLL.Add(integral_model);
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"会员签到\", \"" + Literal1.Text + "\", \"back\",\"Success\",\"\")", true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"您今日已经签到过了\", \"您今日已经签到过了\", \"back\",\"Error\",\"\")", true);

        }
    }
    public void getUserUpdate(int user_id)
    {

    }

    #endregion

    #region 注册会员===================
    protected void UserRegisterSubmit_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        Cms.BLL.C_user bll = new Cms.BLL.C_user();
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        wxuser.UserSale wu = new wxuser.UserSale();
        wxuser.userinfo xw = new wxuser.userinfo();
        wu = wxuser.getUserRegister(model.openid, model.username, model.sex, model.useraddress, string.Format("{0:yyyy-MM-dd}", model.birthday), string.Format("{0:yyyy-MM-dd}", model.marryday), model.telphone,"");
        if (wu.result == "更新成功")
        {
            xw = wxuser.getuserinfo(model.openid);
            if (xw.result == "获取成功")
            {
                model = bll.GetModel(model.id);
                model.usercard = xw.usercard;
                model.userallscore = Convert.ToInt32(Math.Round(Convert.ToDecimal(xw.userallscore)).ToString());
                model.userscore = Convert.ToInt32(Math.Round(Convert.ToDecimal(xw.userscore)).ToString());
                model.userYesScore = Convert.ToInt32(Math.Round(Convert.ToDecimal(xw.userallscore)).ToString()) - Convert.ToInt32(Math.Round(Convert.ToDecimal(xw.userscore)).ToString());
                model.userlevel = xw.userlevel;
                model.shopname = xw.shopname;
                bll.Update(model);
                Literal1.Text = wu.content + "-" + wu.result;
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"注册会员\", \"" + Literal1.Text + "\", \"back\",\"Success\",\"\")", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"注册失败\", \"" + Literal1.Text + "\", \"back\",\"Error\",\"\")", true);
            }
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", "parent.jsdialog(\"注册失败\", \"" + Literal1.Text + "\", \"back\",\"Error\",\"\")", true);
        }
    }
    #endregion

    #region 会员加减积分===================
    protected void UserScoreSubmit_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//ID
        Cms.BLL.C_user bll = new Cms.BLL.C_user();
        Cms.Model.C_user model = new Cms.BLL.C_user().GetModel(userId);
        wxuser.UserSale wu = new wxuser.UserSale();
        wxuser.userinfo xw = new wxuser.userinfo();
        // wu = wxuser.getUserScore(model.usercard, model.openid, "1", "产品购买", "100");
        // Literal1.Text = wu.content + "-" + wu.result;

    }
    #endregion

    #region 提示框===================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}