using System;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;

public partial class Admin_settings_payment_edit : System.Web.UI.Page
{
    private int id = 0;
    protected Cms.Model.C_payment model = new Cms.Model.C_payment();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.id = DTRequest.GetQueryInt("id");
        if (this.id == 0)
        {
            JscriptMsg("传输参数不正确！", "back", "Error");
            return;
        }
        if (!new Cms.BLL.C_payment().Exists(this.id))
        {
            JscriptMsg("支付方式不存在或已删除！", "back", "Error");
            return;
        }
        if (!Page.IsPostBack)
        {
            
            ShowInfo(this.id);
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        Cms.BLL.C_payment bll = new Cms.BLL.C_payment();
        model = bll.GetModel(_id);
        txtTitle.Text = model.title;
        rblType.SelectedValue = model.type.ToString();
        p_name.Text = model.p_name.ToString();
        rblType.Enabled = false;
        if (model.is_lock == 0)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }
        txtSortId.Text = model.sort_id.ToString();
        rblPoundageType.SelectedValue = model.poundage_type.ToString();
        txtPoundageAmount.Text = model.poundage_amount.ToString();
        txtImgUrl.Value = model.img_url;
        txtRemark.Text = model.remark;
        if (model.api_path.ToLower().StartsWith("alipay"))
        {
            //支付宝
            XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath("/" + "xmlconfig/alipay.config"));
            txtAlipayPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
            txtAlipayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
            txtAlipaySellerEmail.Text = doc.SelectSingleNode(@"Root/email").InnerText;
        }
        //else if (model.api_path.ToLower().StartsWith("tenpay"))
        //{
        //    //财付通
        //    XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath("/" + "xmlconfig/tenpay.config"));
        //    txtTenpayBargainorId.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
        //    txtTenpayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
        //}
        //else if (model.api_path.ToLower().StartsWith("chinabank"))
        //{
        //    //网银在线
        //    XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath("/" + "xmlconfig/chinabank.config"));
        //    txtChinaBankPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
        //    txtChinaBankKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
        //}
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;
        Cms.BLL.C_payment bll = new Cms.BLL.C_payment();
        Cms.Model.C_payment model = bll.GetModel(_id);

        model.title = txtTitle.Text.Trim();
        model.p_name = p_name.Text;
        if (cbIsLock.Checked == true)
        {
            model.is_lock = 0;
        }
        else
        {
            model.is_lock = 1;
        }
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        model.poundage_type = int.Parse(rblPoundageType.SelectedValue);
        model.poundage_amount = decimal.Parse(txtPoundageAmount.Text.Trim());
        model.img_url = txtImgUrl.Value.Trim();
        model.remark = txtRemark.Text;
        model.p_account = txtAlipaySellerEmail.Text;
        if (model.api_path.ToLower() == "alipay")
        {
            //支付宝
            string alipayFilePath = Utils.GetMapPath("/" + "xmlconfig/alipay.config");
            XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/partner", txtAlipayPartner.Text);
            XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/key", txtAlipayKey.Text);
            XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/email", txtAlipaySellerEmail.Text);
        }
        //else if (model.api_path.ToLower() == "tenpay")
        //{
        //    //财付通
        //    string tenpayFilePath = Utils.GetMapPath("/" + "xmlconfig/tenpay.config");
        //    XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/partner", txtTenpayBargainorId.Text);
        //    XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/key", txtTenpayKey.Text);
        //}
        //else if (model.api_path.ToLower().StartsWith("chinabank"))
        //{
        //    //网银在线
        //    string chinaBankFilePath = Utils.GetMapPath("/" + "xmlconfig/chinabank.config");
        //    XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/partner", txtChinaBankPartner.Text);
        //    XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/key", txtChinaBankKey.Text);
        //}

        if (bll.Update(model))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.title); //记录日志
            result = true;
        }

        return result;
    }
    #endregion

    #region 保存================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        if (!DoEdit(this.id))
        {
            JscriptMsg("保存过程中发生错误！", "", "Error");
            return;
        }
        JscriptMsg("修改配置成功！", "payment_list.aspx", "Success");
    }
    #endregion

    #region 提示框=======================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}