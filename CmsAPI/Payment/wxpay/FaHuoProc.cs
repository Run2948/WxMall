
using LitJson;
using Cms.BLL;
using Cms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Cms.API.Payment.wxpay
{
    public class FaHuoProc
    {
        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="paymentInfo"></param>
        /// <param name="orderEntity"></param>
        /// <returns></returns>
        public Dictionary<string, object> fahuomgr()
        {
            //BLL.C_admin_log logBll = new BLL.C_admin_log();
            //string funName = "发货";
            //logBll.Add(paymentInfo.wid.Value, "微支付", funName, "开始执行fahuomgr方法[otid:" + orderEntity.id + "]");

            //WxPayHelper wxPayHelper = new WxPayHelper();
            //wx_payment_wxpay payBll = new wx_payment_wxpay();

            ////先设置基本信息
            //string partnerId = paymentInfo.partnerId; //"1218574001";
            //string appId = paymentInfo.appId;// "wxa9b8e33e48ac5e0f";
            //string partnerKey = paymentInfo.partnerKey;// "huyuxianghuyuxianghuyuxiang12345";
            ////paysignkey(非appkey) 
            //string appKey = paymentInfo.paySignKey;// "nwRmqgvSG08pe3vU5qzBLb7Bvih0WOABGzUPvqgFqE0iSkJlJ8wh7JlLYy2cXFgFA3v1bM8eTDm1y1UcyeW9IGq2py2qei7J5xDoVR9lfO3cS6fMjFbMQeeqBRit0bKp";

            //wxPayHelper.SetAppId(appId);
            //wxPayHelper.SetAppKey(appKey);
            //wxPayHelper.SetPartnerKey(partnerKey);
            //wxPayHelper.SetSignType("sha1");
            ////设置请求package信息

            //WeiXinCRMComm wxComm = new WeiXinCRMComm();
            //string err = "";
            string access_token = "";// wxComm.getAccessToken(paymentInfo.wid.Value, out err);

            string param = "";// WxPayHelper.CreateFaHuoPackage(orderEntity.openid, orderEntity.trade_no, orderEntity.order_no);

            string url = "https://api.weixin.qq.com/pay/delivernotify?access_token=" + access_token;
            string ret = Utils.HttpPost(url, param);
            //logBll.AddLog(paymentInfo.wid.Value, "微支付", funName, "ret=" + ret);
            Dictionary<string, object> dict = JsonToDictionary(ret);
           // logBll.AddLog(paymentInfo.wid.Value, "微支付", funName, "[otid:" + orderEntity.id + "]发货成功");
            //string errcode = dict["errcode"].ToString();
            //string errmsg = dict["errmsg"].ToString();

            //mxAuthFrame.BLL.wxOrderTmpBLL wot = new mxAuthFrame.BLL.wxOrderTmpBLL();
            //ordertmp.fahuoCode = errcode;
            //ordertmp.fahuoMsg = errmsg;
            //wot.Update(ordertmp);

            //Dictionary<string, string> ret_d = new Dictionary<string, string>();
            //ret_d.Add(errcode, errmsg);
            return dict;
        }

        public Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
