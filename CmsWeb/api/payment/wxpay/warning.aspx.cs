using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// 微支付警告页面
/// </summary>
public partial class api_payment_wxpay_warning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JinGao();
    }
    private void JinGao()
    {

        try
        {

        }
        catch (Exception ex)
        {

        }
        finally
        {
            Response.Write("success");
            Response.End();
        }

        string AppId = "";
        //1001,
        string ErrorType = "";

        //发货超时
        string Description = "";

        //transaction_id=订单号
        string AlarmContent = "";
        string TimeStamp = "";
        string AppSignature = "";
        string SignMethod = "";

        using (XmlReader xr = XmlReader.Create(Request.InputStream))
        {
            XDocument RequestDocument = XDocument.Load(xr);

            AppId = RequestDocument.Root.Element("AppId").Value;
            ErrorType = RequestDocument.Root.Element("ErrorType").Value;
            Description = RequestDocument.Root.Element("Description").Value;
            AlarmContent = RequestDocument.Root.Element("AlarmContent").Value;
            TimeStamp = RequestDocument.Root.Element("AppSignature").Value;
            AppSignature = RequestDocument.Root.Element("AppSignature").Value;
            SignMethod = RequestDocument.Root.Element("SignMethod").Value;


        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //逻辑：通知管理员，以及在后台提醒
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////





    }

}