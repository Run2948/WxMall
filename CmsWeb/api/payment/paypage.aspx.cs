using Cms.API.Payment.wxpay;
using Cms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_payment_paypage : System.Web.UI.Page
{

    public String packageValue = "";
    protected int wid = 0;
    protected string openid = "";
    /// <summary>
    /// 订单付款的有效持续时间（单位为分）
    /// </summary>
    protected int expireMinute = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        openid = MyCommFun.RequestOpenid();
        int otid =Convert.ToInt32( Request["orderid"].ToString());
       
        expireMinute = MyCommFun.RequestInt("expireminute");
        if (expireMinute == 0)
        {
            expireMinute = 30;
        }
        else if (expireMinute == -1)
        {  //如果为-1，则有限期间为1年
            expireMinute = 60 * 12 * 365;
        }
        //if (openid == "" || otid == 0 || wid == 0)
        //{
        //    return;
        //}
        Cms.BLL.C_order otBll = new Cms.BLL.C_order();
        Cms.Model.C_order orderEntity = otBll.GetModel(otid);
        order_num.Text = orderEntity.order_num;
        litMoney.Text = Convert.ToDecimal(orderEntity.price_sum).ToString("0.00");
        litDate.Text = orderEntity.updateTime.ToString();
        WxPayData(Convert.ToDecimal(orderEntity.price_sum), orderEntity.id.ToString(), orderEntity.order_num);

        FileHelper.Write(HttpRuntime.AppDomainAppPath + "\\log.txt", packageValue);
    }

    /// <summary>
    /// 微信支付：生成请求数据
    /// </summary>
    /// <param name="openid">微信用户id</openid>
    /// <param name="ttFee">商品总价格</param>
    /// <param name="busiBody"></param>
    /// <returns></returns>
    protected void WxPayData(decimal ttFee, string busiBody, string out_trade_no)
    {
        WxPayHelper wxPayHelper = new WxPayHelper();
        //BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
        //Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);

        //先设置基本信息
        string partnerId = "1220201501";// "1220201501";//  
        string appId = "wxe5d8d2c5589f5ffb";// "wxe5d8d2c5589f5ffb";// 
        string partnerKey = "19ace89a7acd6e14ac3c66b2852f14d6";// "19ace89a7acd6e14ac3c66b2852f14d6";//  
        //paysignkey(非appkey) 
        string appKey = "YOFbXGzn0i8ZH8UlfqH7D7LpHHCXd4CxNqZgLffI8v58GSpxntqnVOx5zJFrsM2efT6XH89Nr0WDpfZjcfYCHD05uteWUfHq6BG8zuyTAe4uQ39yKOKqwYwl6yhgKueb"; //"YOFbXGzn0i8ZH8UlfqH7D7LpHHCXd4CxNqZgLffI8v58GSpxntqnVOx5zJFrsM2efT6XH89Nr0WDpfZjcfYCHD05uteWUfHq6BG8zuyTAe4uQ39yKOKqwYwl6yhgKueb";// 

        wxPayHelper.SetAppId(appId);
        wxPayHelper.SetAppKey(appKey);
        wxPayHelper.SetPartnerKey(partnerKey);
        wxPayHelper.SetSignType("SHA1");
        //设置请求package信息
        wxPayHelper.SetParameter("bank_type", "WX");
        wxPayHelper.SetParameter("body", busiBody);
        wxPayHelper.SetParameter("attach", wid + "|" + busiBody);
        wxPayHelper.SetParameter("partner", partnerId);
        wxPayHelper.SetParameter("out_trade_no", out_trade_no);
        wxPayHelper.SetParameter("total_fee", ((int)(ttFee * 100)).ToString());
        wxPayHelper.SetParameter("fee_type", "1");
        // wxPayHelper.SetParameter("notify_url", "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx?wid="+wid);

        wxPayHelper.SetParameter("notify_url", "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx");//不能带参数
        wxPayHelper.SetParameter("spbill_create_ip", DTRequest.GetIP());
        wxPayHelper.SetParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
        //---------有效期截至日期------

        wxPayHelper.SetParameter("time_expire", DateTime.Now.AddMinutes(expireMinute).ToString("yyyyMMddHHmmss"));

        wxPayHelper.SetParameter("input_charset", "UTF-8");
        packageValue = wxPayHelper.CreateBizPackage();


    }

}