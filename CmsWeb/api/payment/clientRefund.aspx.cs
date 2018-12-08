using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Cms.API.Payment.wxpay.tuikuan;
using Cms.API.Payment.wxpay.comm;


public partial class api_payment_clientRefund : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //商户号
        string partner = "1220201501";


        //密钥
        string key = "19ace89a7acd6e14ac3c66b2852f14d6";

        //创建请求对象
        RequestHandler reqHandler = new RequestHandler(Context);

        //通信对象
        TenpayHttpClient httpClient = new TenpayHttpClient();

        //应答对象
        ClientResponseHandler resHandler = new ClientResponseHandler();

        int otid = Convert.ToInt32(Request["orderid"].ToString());
        Cms.BLL.C_order otBll = new Cms.BLL.C_order();
        Cms.Model.C_order orderEntity = otBll.GetModel(otid);
      
        //-----------------------------
        //设置请求参数
        //-----------------------------
        reqHandler.init();
        reqHandler.setKey(key);
        reqHandler.setGateUrl("https://mch.tenpay.com/refundapi/gateway/refund.xml");

        reqHandler.setParameter("partner", partner);
        //out_trade_no和transaction_id至少一个必填，同时存在时transaction_id优先
        //reqHandler.setParameter("out_trade_no", "1458268681");
        reqHandler.setParameter("transaction_id", orderEntity.trade_no);
        reqHandler.setParameter("out_refund_no", orderEntity.order_num);
        reqHandler.setParameter("total_fee", ((int)(orderEntity.price_sum * 100)).ToString());//((int)(orderEntity.price_sum * 100)).ToString()
        reqHandler.setParameter("refund_fee", ((int)(orderEntity.price_sum * 100)).ToString());
        //reqHandler.setParameter("refund_fee", "100");
        reqHandler.setParameter("op_user_id", "1220201501");
        reqHandler.setParameter("op_user_passwd", MD5Util.GetMD5("dbezhifu1866", "GBK"));
        reqHandler.setParameter("service_version", "1.1");

        string requestUrl = reqHandler.getRequestURL();

        httpClient.setCertInfo("d:\\wwwroot\\anpurui\\wwwroot\\1220201501_20150203112358.pfx", "1220201501");
        //设置请求内容
        httpClient.setReqContent(requestUrl);
        //设置超时
        httpClient.setTimeOut(10);

        string rescontent = "";

        
        //后台调用
        if (httpClient.call())
        {
            //获取结果
            rescontent = httpClient.getResContent();

           
           

            resHandler.setKey(key);
            //设置结果参数
            resHandler.setContent(rescontent);

            //判断签名及结果
            if (resHandler.isTenpaySign() && resHandler.getParameter("retcode") == "0")
            {
                //商户订单号
                string out_trade_no = resHandler.getParameter("out_trade_no");
                //财付通订单号
                string transaction_id = resHandler.getParameter("transaction_id");

                DataTable dt = otBll.GetList("trade_no='" + transaction_id + "'").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                   
                    int id = Convert.ToInt32(dt.Rows[0]["id"]);
                    Cms.Model.C_order orderModel = otBll.GetModel(id);
                    orderModel.is_refund = 3;
                    if (otBll.Update(orderModel))
                    {
                        JscriptMsg("退款成功！", "/shop/myOrder.aspx", "Success");
                        
                    }
                }

                //业务处理
                //Response.Write("退款成功！" + out_trade_no + transaction_id);




            }
            else
            {
                //错误时，返回结果未签名。
                //如包格式错误或未确认结果的，请使用原来订单号重新发起，确认结果，避免多次操作
                //Response.Write("业务错误信息或签名错误:" + resHandler.getParameter("retcode") + "," + resHandler.getParameter("retmsg") + "<br>");
                JscriptMsg("退款失败！", "/shop/myOrder.aspx", "Error");
            }

        }
        else
        {
            //后台调用通信失败
            //Response.Write("call err:" + httpClient.getErrInfo() + "<br>" + httpClient.getResponseCode() + "<br>");
            JscriptMsg("退款失败！", "/shop/myOrder.aspx", "Error");
            //有可能因为网络原因，请求已经处理，但未收到应答。
        }


        //获取debug信息,建议把请求、应答内容、debug信息，通信返回码写入日志，方便定位问题

        //Response.Write("http res:" + httpClient.getResponseCode() + "," + httpClient.getErrInfo() + "<br>");
        //Response.Write("req url:" + requestUrl + "<br/>");
        //Response.Write("req debug:" + reqHandler.getDebugInfo() + "<br/>");
        //Response.Write("res content:" + Server.HtmlEncode(rescontent) + "<br/>");
        //Response.Write("res debug:" + Server.HtmlEncode(resHandler.getDebugInfo()) + "<br/>");

    }
    #region 提示框=================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "";
        if (url == "back")
        {
            msbox = "jsdialog(\"提示\", \"" + msgtitle + "\",\"" + url + "\", \"\", \"" + msgcss + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        else
        {
            msbox = "jsprintWeb(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }

    }
    #endregion
}