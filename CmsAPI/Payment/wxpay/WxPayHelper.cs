using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;
using Cms.API.Payment.wxpay.comm;

namespace Cms.API.Payment.wxpay
{
    public class WxPayHelper
    {
        public WxPayHelper()
        {
            this.parameters = new Dictionary<string, string>();
            this.AppId = "";
            this.AppKey = "";
            this.SignType = "sha1";
            this.PartnerKey = "";

        }

        public sealed class Anonymous_C0 :
                IComparer<KeyValuePair<string, string>>
        {
            public int Compare(KeyValuePair<string, string> o1,
                    KeyValuePair<string, string> o2)
            {
                return String.CompareOrdinal((o1.Key).ToString(), o2.Key);
            }
        }

        private Dictionary<string, string> parameters;
        private string AppId;
        private string AppKey;
        private string SignType;
        private string PartnerKey;

        public void SetAppId(string str)
        {
            AppId = str;
        }
        /// <summary>
        /// PaySignKey
        /// </summary>
        /// <param name="str"></param>
        public void SetAppKey(string str)
        {
            AppKey = str;
        }

        public void SetSignType(string str)
        {
            SignType = str;
        }
        /// <summary>
        ///财付通: 初始密钥(PartnerKey)
        /// </summary>
        /// <param name="str"></param>
        public void SetPartnerKey(string str)
        {
            PartnerKey = str;
        }

        public void SetParameter(string key, string value_ren)
        {
            parameters.Add(key, value_ren);
        }

        public string GetParameter(string key)
        {
            return parameters[key];
        }

        private Object CheckCftParameters()
        {
            if (parameters["bank_type"] == "" || parameters["body"] == "" || parameters["partner"] == "" || parameters["out_trade_no"] == ""
                    || parameters["total_fee"] == "" || parameters["fee_type"] == "" || parameters["notify_url"] == null || parameters["spbill_create_ip"] == ""
                    || parameters["input_charset"] == "")
            {
                return false;
            }
            return true;
        }

        public string GetCftPackage()
        {
            if ("" == PartnerKey)
            {
                throw new SDKRuntimeException("密钥不能为空！");
            }
            string unSignParaString = CommonUtil.FormatBizQueryParaMap(parameters,
                    false);
            string paraString = CommonUtil.FormatBizQueryParaMap(parameters, true);
            return paraString + "&sign="
                    + MD5SignUtil.Sign(unSignParaString, PartnerKey);

        }

        public string GetBizSign(Dictionary<string, string> bizObj)
        {
            Dictionary<string, string> bizParameters = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> item in bizObj)
            {
                if (item.Key != "")
                {
                    bizParameters.Add(item.Key.ToLower(), item.Value);
                }
            }

            if (this.AppKey == "")
            {
                throw new SDKRuntimeException("APPKEY为空！");
            }
            bizParameters.Add("appkey", AppKey);
            string bizString = CommonUtil.FormatBizQueryParaMap(bizParameters, false);

            return SHA1Util.Sha1(bizString);

        }

        // 生成app支付请求json
        /*
         * { "appid":"wwwwb4f85f3a797777", "traceid":"crestxu",
         * "noncestr":"111112222233333", "package":
         * "bank_type=WX&body=XXX&fee_type=1&input_charset=GBK&notify_url=http%3a%2f%2f
         * www
         * .qq.com&out_trade_no=16642817866003386000&partner=1900000109&spbill_create_ip
         * =127.0.0.1&total_fee=1&sign=BEEF37AD19575D92E191C1E4B1474CA9",
         * "timestamp":1381405298,
         * "app_signature":"53cca9d47b883bd4a5c85a9300df3da0cb48565c",
         * "sign_method":"sha1" }
         */
        public string CreateAppPackage(string traceid)
        {
            Dictionary<string, string> nativeObj = new Dictionary<string, string>();
            if ((bool)((CheckCftParameters())) == false)
            {
                throw new SDKRuntimeException("生成package参数缺失！");
            }
            nativeObj.Add("appid", AppId);
            nativeObj.Add("package", GetCftPackage());
            nativeObj.Add("timestamp", ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString());
            nativeObj.Add("traceid", traceid);
            nativeObj.Add("noncestr", CommonUtil.CreateNoncestr());
            nativeObj.Add("app_signature", GetBizSign(nativeObj));
            nativeObj.Add("sign_method", SignType);

            var entries = nativeObj.Select(d => string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));

            return "{" + string.Join(",", entries.ToArray()) + "}";

        }


        /// <summary>
        /// 发货的请求json
        /// </summary>
        /// <returns></returns>
        public string CreateFaHuoPackage(string openid, string transid, string out_trade_no)
        {
            Dictionary<string, string> nativeObj = new Dictionary<string, string>();

            nativeObj.Add("appid", AppId);
            nativeObj.Add("openid", openid);
            nativeObj.Add("transid", transid);

            nativeObj.Add("out_trade_no", out_trade_no);
            nativeObj.Add("deliver_timestamp", ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString());
            nativeObj.Add("deliver_status", "1");
            nativeObj.Add("deliver_msg", "ok");

            nativeObj.Add("app_signature", GetBizSign(nativeObj));
            nativeObj.Add("sign_method", SignType);


            var entries = nativeObj.Select(d => string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
            return "{" + string.Join(",", entries.ToArray()) + "}";

        }



        // 生成jsapi支付请求json
        /*
         * "appId" : "wxf8b4f85f3a794e77", //公众号名称，由商户传入 "timeStamp" : "189026618",
         * //时间戳这里随意使用了一个值 "nonceStr" : "adssdasssd13d", //随机串 "package" :
         * "bank_type=WX&body=XXX&fee_type=1&input_charset=GBK&notify_url=http%3a%2f
         * %2fwww.qq.com&out_trade_no=16642817866003386000&partner=1900000109&
         * spbill_create_i
         * p=127.0.0.1&total_fee=1&sign=BEEF37AD19575D92E191C1E4B1474CA9",
         * //扩展字段，由商户传入 "signType" : "SHA1", //微信签名方式:sha1 "paySign" :
         * "7717231c335a05165b1874658306fa431fe9a0de" //微信签名
         */
        public string CreateBizPackage()
        {
            Dictionary<string, string> nativeObj = new Dictionary<string, string>();
            if ((bool)((CheckCftParameters())) == false)
            {
                throw new SDKRuntimeException("生成package参数缺失！");
            }
            nativeObj.Add("appId", AppId);
            nativeObj.Add("package", GetCftPackage());
            nativeObj.Add("timeStamp", ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString());
            nativeObj.Add("nonceStr", CommonUtil.CreateNoncestr());
            nativeObj.Add("paySign", GetBizSign(nativeObj));
            nativeObj.Add("signType", SignType);


            var entries = nativeObj.Select(d => string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
            return "{" + string.Join(",", entries.ToArray()) + "}";

        }

        // 生成原生支付url
        /*
         * weixin://wxpay/bizpayurl?sign=XXXXX&appid=XXXXXX&productid=XXXXXX&timestamp
         * =XXXXXX&noncestr=XXXXXX
         */
        public string CreateNativeUrl(string productid)
        {
            string bizString = "";
            try
            {
                Dictionary<string, string> nativeObj = new Dictionary<string, string>();
                nativeObj.Add("appid", AppId);
                nativeObj.Add("productid", System.Web.HttpUtility.UrlEncode(productid));
                nativeObj.Add("timestamp", ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString());
                nativeObj.Add("noncestr", CommonUtil.CreateNoncestr());
                nativeObj.Add("sign", GetBizSign(nativeObj));
                bizString = CommonUtil.FormatBizQueryParaMap(nativeObj, false);

            }
            catch (Exception e)
            {
                throw new SDKRuntimeException(e.Message);

            }
            return "weixin://wxpay/bizpayurl?" + bizString;
        }

        // 生成原生支付请求xml
        /*
         * <xml> <AppId><![CDATA[wwwwb4f85f3a797777]]></AppId>
         * <Package><![CDATA[a=1&url=http%3A%2F%2Fwww.qq.com]]></Package>
         * <TimeStamp> 1369745073</TimeStamp>
         * <NonceStr><![CDATA[iuytxA0cH6PyTAVISB28]]></NonceStr>
         * <RetCode>0</RetCode> <RetErrMsg><![CDATA[ok]]></ RetErrMsg>
         * <AppSignature><![CDATA[53cca9d47b883bd4a5c85a9300df3da0cb48565c]]>
         * </AppSignature> <SignMethod><![CDATA[sha1]]></ SignMethod > </xml>
         */
        public string CreateNativePackage(string retcode, string reterrmsg)
        {
            Dictionary<string, string> nativeObj = new Dictionary<string, string>();
            if ((bool)((CheckCftParameters())) == false && retcode == "0")
            {
                throw new SDKRuntimeException("生成package参数缺失！");
            }
            nativeObj.Add("AppId", AppId);
            nativeObj.Add("Package", GetCftPackage());
            nativeObj.Add("TimeStamp", ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString());
            nativeObj.Add("RetCode", retcode);
            nativeObj.Add("RetErrMsg", reterrmsg);
            nativeObj.Add("NonceStr", CommonUtil.CreateNoncestr());
            nativeObj.Add("AppSignature", GetBizSign(nativeObj));
            nativeObj.Add("SignMethod", SignType);
            return CommonUtil.ArrayToXml(nativeObj);

        }
    }
}
