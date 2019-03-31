using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;

public partial class Admin_settings_typeedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //登录验证
            adminUser.GetLoginState();

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
            
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//文章类别ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            bind_Province(Province);
            bind_City(1, City);
            bind_District(1, District);
            switch (action)
            {
                case "add":
                    Application["latitude"] = "121.526149";
                    Application["longitude"] = "31.222663";
                    break;
                case "edit":            
                    this.ShowInfo(id);//绑定栏目信息
                    break;
            }


        }
    }

    #region 省市===========================================
    /// <summary>
    /// 绑定省
    /// </summary>
    public void bind_Province(DropDownList lbCity)
    {
        DataSet ds = new Cms.BLL.C_Province().GetList("");
        lbCity.DataSource = ds.Tables[0].DefaultView;
        lbCity.DataValueField = "ProvinceID";
        lbCity.DataTextField = "ProvinceName";
        lbCity.DataBind();
    }
    protected void Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.Province.SelectedValue == "")
        {
            return;
        }
        int txtProvince = Utils.StrToInt(Province.SelectedValue.ToString(), 0);
        bind_City(txtProvince, City);

    }
    /// <summary>
    /// 绑定市
    /// </summary>
    public void bind_City(int Province, DropDownList lbCity)
    {
        DataSet ds = new Cms.BLL.C_City().GetList("ProvinceID=" + Province);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            lbCity.DataSource = ds.Tables[0].DefaultView;
            lbCity.DataValueField = "CityID";
            lbCity.DataTextField = "CityName";
            lbCity.DataBind();
            int txtCityID = Utils.StrToInt(ds.Tables[0].Rows[0]["CityID"].ToString(), 0);
            bind_District(txtCityID, District);
        }
    }
    protected void City_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.City.SelectedValue == "")
        {
            return;
        }
        int txtCityID = Utils.StrToInt(City.SelectedValue.ToString(), 0);
        bind_District(txtCityID, District);
    }
    /// <summary>
    /// 绑定区
    /// </summary>
    public void bind_District(int CityID, DropDownList lbCity)
    {
        DataSet ds = new Cms.BLL.C_District().GetList("CityID=" + CityID);
        lbCity.DataSource = ds.Tables[0].DefaultView;
        lbCity.DataValueField = "DistrictID";
        lbCity.DataTextField = "DistrictName";
        lbCity.DataBind();
    }

    #endregion

    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion


    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        Cms.BLL.sc_stores bll = new Cms.BLL.sc_stores();
        Cms.Model.sc_stores model = bll.GetModel(_id);

        this.Province.SelectedValue = model.location;
        bind_City(Convert.ToInt32(model.location), City);
        this.City.SelectedValue = model.city;
        bind_District(Convert.ToInt32(model.city), District);
        this.District.SelectedValue = model.county;
        txtTitle.Text = model.storename;
        txtSortId.Text = model.sort_id.ToString();
        tblatitude.Text = model.latitude;
        Application["latitude"] = model.latitude;
        Application["longitude"] = model.longitude;
        tblongitude.Text = model.longitude;
        txtLinkUrl.Text = model.linkurl;
        txtImgUrl.Value = model.picurl;
        txtContent.Value = model.info;
        this.isHidden.SelectedValue = model.isHidden.ToString();//显示状态
        tbphone.Text = model.tel;
        tbaddress.Text = model.address;
        verificationPass.Text = model.verificationPass;

    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
       
        try
        {
            Cms.Model.sc_stores model = new Cms.Model.sc_stores();
            Cms.BLL.sc_stores bll = new Cms.BLL.sc_stores();
            model.location = Province.SelectedValue;
            model.city = City.SelectedValue;
            model.county = District.SelectedValue;
            model.storename = txtTitle.Text.Trim();
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            string urlhot = Request.Url.Host.ToString();
            if (urlhot.IndexOf("http") > -1 || urlhot.IndexOf("HTTP") > -1 || urlhot.IndexOf("https") > -1 || urlhot.IndexOf("HTTPS") > -1)
            {

            }
            else
            {
                urlhot = "http://" + urlhot;
            }

            model.linkurl =txtLinkUrl.Text.Trim();
            model.picurl =urlhot+txtImgUrl.Value.Trim();
            model.info = txtContent.Value;
            model.isHidden = Convert.ToInt32(this.isHidden.SelectedValue);//显示状态
            model.latitude = tblatitude.Text;
            model.longitude = tblongitude.Text;

            model.tel = tbphone.Text;
            model.address = tbaddress.Text;
            model.updatetime = DateTime.Now;
            model.verificationPass = verificationPass.Text;

            if (bll.Add(model) > 0)
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
       
        try
        {
            Cms.BLL.sc_stores bll = new Cms.BLL.sc_stores();
            Cms.Model.sc_stores model = bll.GetModel(_id);


            model.location = Province.SelectedValue;
            model.city = City.SelectedValue;
            model.county = District.SelectedValue;
            model.storename = txtTitle.Text.Trim();
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            string urlhot = Request.Url.Host.ToString();
            if (txtImgUrl.Value.IndexOf("http") > -1 || txtImgUrl.Value.IndexOf("HTTP") > -1 || txtImgUrl.Value.IndexOf("https") > -1 || txtImgUrl.Value.IndexOf("HTTPS") > -1)
            {
                urlhot = "";
            }
            else
            {
                urlhot = "http://" + urlhot;
            }
       
            model.picurl = urlhot + txtImgUrl.Value.Trim();
            model.linkurl = txtLinkUrl.Text.Trim();
          
            model.info = txtContent.Value;
            model.isHidden = Convert.ToInt32(this.isHidden.SelectedValue);//显示状态
            model.latitude = tblatitude.Text;
            model.longitude = tblongitude.Text;
           // model.updatetime = DateTime.Now;
            model.tel = tbphone.Text;
            model.address = tbaddress.Text;
            model.verificationPass = verificationPass.Text;
         
            if (bll.Update(model))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
    #endregion

  

    #region 保存类别============================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//文章类别ID
        string parent_id = this.Request.QueryString["parent_id"] ?? "";//上级类别ID
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        switch (action)
        {
            case "add":
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加类别成功！", "storeslist.aspx", "Success");
                 adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加" + this.txtTitle.Text + "门店信息"); //记录日志
                break;
            case "edit":

                if (!DoEdit(id))
                {

                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改类别成功！", "storeslist.aspx", "Success");
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改" + this.txtTitle.Text + "门店信息"); //记录日志
                break;
        }

    }
    #endregion
}