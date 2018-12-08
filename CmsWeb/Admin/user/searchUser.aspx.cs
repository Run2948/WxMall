using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_user_searchUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 搜索===============================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      
        string Keywords = this.txtKeywords.Text.Trim();
       wxuser.userinfo xw = new wxuser.userinfo();
       xw = wxuser.getuserinfo(Keywords);
        Literal1.Text = xw.content + "-" + xw.result + "-" + xw.openid + "-" + xw.sex + "-" + xw.shopname + "-" + xw.telephone + "-" + xw.useraddress + "-" + xw.userallscore + "-" + xw.usercard + "-" + xw.userlevel + "-" + xw.username + "-" + xw.userscore + "-" + xw.allbuy + "-" + xw.birthday + "-" + xw.buytimes;
    }
    #endregion
}