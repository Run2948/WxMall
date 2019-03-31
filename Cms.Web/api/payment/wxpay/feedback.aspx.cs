using System;
using Cms.API.Payment.wxpay;
using Cms.BLL;
using System.Net;
using System.IO;

/// <summary>
///  维权接口页面
/// </summary>
public partial class api_payment_wxpay_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //创建支付应答对象
        ResponseHandler resHandler = new ResponseHandler(Context);
        resHandler.init();
        wx_payment_wxpay payBll = new wx_payment_wxpay();

        //暂未获得wid
        Cms.Model.wx_payment_wxpay paymentInfo = payBll.GetModel(1);

        resHandler.setKey(paymentInfo.partnerKey, paymentInfo.paySignKey); //密匙，paysignkey

        //判断签名
        if (resHandler.isWXsignfeedback())
        {
            //回复服务器处理成功
            string AppId = resHandler.getMpParameter("AppId");
            string TimeStamp = resHandler.getMpParameter("TimeStamp");
            string OpenId = resHandler.getMpParameter("OpenId");
            string AppSignature = resHandler.getMpParameter("AppSignature");
            string MsgType = resHandler.getMpParameter("MsgType");
            string FeedBackId = resHandler.getMpParameter("FeedBackId");
            string TransId = resHandler.getMpParameter("TransId");
            string Reason = resHandler.getMpParameter("Reason");
            string Solution = resHandler.getMpParameter("Solution");
            string ExtInfo = resHandler.getMpParameter("ExtInfo");
            string SignMethod = resHandler.getParameter("SignMethod");
            string txt = string.Empty;
            if (MsgType.ToLower().Trim() == "request")
            {
                //新增维权操作
            }
            else
            {
                //用户确认处理完毕操作
            }

            //回复服务器处理成功
            Response.Write("OK");
            Response.Write("OK:" + resHandler.getDebugInfo());
        }
        else
        {
            //sha1签名失败
            Response.Write("fail");
            Response.Write("fail:" + resHandler.getDebugInfo());
        }
        Response.End();
    }


    /// <summary>
    /// 申请消除投诉
    /// 如您已经跟客户达成一致，可申请消除用户投诉！
    /// 向微信发送撤销投诉申请
    /// </summary>
    /// <returns></returns>
    private void MessageToTx(string accessToken, string openId, string feedBackId)
    {
        string url = "https://api.weixin.qq.com/payfeedback/update?access_token={0}&openid={1}&feedbackid={2}";
        url = string.Format(url, accessToken, openId, feedBackId);
        HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);
        webRequest2.ContentType = "text/html; charset=UTF-8";
        webRequest2.Method = "GET";
        webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
        HttpWebResponse httpWebResponse2 = (HttpWebResponse)webRequest2.GetResponse();
        StreamReader swRead = new StreamReader(httpWebResponse2.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
        Response.Write(swRead.ReadToEnd());
    }

}