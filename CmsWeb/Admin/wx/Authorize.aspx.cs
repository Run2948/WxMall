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
           
            Bind();
      
        }
    }
    #region 赋值操作============================
    public void Bind()
    {
      
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
                wurl.Text = mwx.url;
                WxId.Text = mwx.wxid;
            }
        }
       
    }
    #endregion


    #region 保存=====================================
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
            mwx.url = wurl.Text.Trim();
            mwx.wxid = WxId.Text.Trim();
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), mwx.AppId); //记录日志
            bl = wx.Update(mwx);
        }
        else
        {
            mwx.AppId = AppId.Text.Trim();
            mwx.AppSecret=AppSecret.Text.Trim();
            mwx.access_token = hdid.Text.Trim();
            mwx.url = wurl.Text.Trim();
            mwx.wxid = WxId.Text.Trim();
            if (wx.Add(mwx) > 0) {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), mwx.AppId); //记录日志
                bl= true;
               
            }
        }
        if (bl)
        {
            Bind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('设置成功！');", true);
           // ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置成功！')</script>");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('设置失败！');", true);
            //ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设置失败！')</script>");
        }
    }

    #endregion




}