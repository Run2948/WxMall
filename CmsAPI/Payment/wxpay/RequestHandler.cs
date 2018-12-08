using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Xml;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cms.API.Payment.wxpay.comm;

namespace Cms.API.Payment.wxpay
{
    /**
       '签名工具类
        ============================================================================/// <summary>
       'api说明：
       'init();
       '初始化函数，默认给一些参数赋值。
       'setKey(key_)'设置商户密钥
       'createMd5Sign(signParams);字典生成Md5签名
       'genPackage(packageParams);获取package包
       'createSHA1Sign(signParams);创建签名SHA1
       'parseXML();输出xml
       'getDebugInfo(),获取debug信息
        * 
        * ============================================================================
        */
    public class RequestHandler
    {

        public RequestHandler(HttpContext httpContext)
        {
            parameters = new Hashtable();

            this.httpContext = httpContext;

        }
        /**  密钥 */
        private string key;

        protected HttpContext httpContext;

        /** 请求的参数 */
        protected Hashtable parameters;

        /** debug信息 */
        private string debugInfo;

        /** 初始化函数 */
        public virtual void init()
        {
        }
        /** 获取debug信息 */
        public String getDebugInfo()
        {
            return debugInfo;
        }
        /** 获取密钥 */
        public String getKey()
        {
            return key;
        }

        /** 设置密钥 */
        public void setKey(string key)
        {
            this.key = key;
        }

        /** 设置参数值 */
        public void setParameter(string parameter, string parameterValue)
        {
            if (parameter != null && parameter != "")
            {
                if (parameters.Contains(parameter))
                {
                    parameters.Remove(parameter);
                }

                parameters.Add(parameter, parameterValue);
            }
        }


        //获取package带参数的签名包
        public string getRequestURL()
        {
            this.createSign();
            StringBuilder sb = new StringBuilder();
            ArrayList akeys = new ArrayList(parameters.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                string v = (string)parameters[k];
                if (null != v && "key".CompareTo(k) != 0)
                {
                    sb.Append(k + "=" + TenpayUtil.UrlEncode(v, getCharset()) + "&");
                }
            }

            //去掉最后一个&
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }


            return sb.ToString();

        }


        //创建md5摘要,规则是:按参数名称a-z排序,遇到空值的参数不参加签名。

        protected virtual void createSign()
        {
            StringBuilder sb = new StringBuilder();

            ArrayList akeys = new ArrayList(parameters.Keys);
            akeys.Sort();

            foreach (string k in akeys)
            {
                string v = (string)parameters[k];
                if (null != v && "".CompareTo(v) != 0
                    && "sign".CompareTo(k) != 0 && "key".CompareTo(k) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }

            sb.Append("key=" + this.getKey());
            string sign = MD5Util.GetMD5(sb.ToString(), getCharset()).ToUpper();

            this.setParameter("sign", sign);

            //debug信息
            this.setDebugInfo(sb.ToString() + " => sign:" + sign);
        }


        //创建package签名
        public virtual string createMd5Sign()
        {
            StringBuilder sb = new StringBuilder();
            ArrayList akeys = new ArrayList(parameters.Keys);
            akeys.Sort();

            foreach (string k in akeys)
            {
                string v = (string)parameters[k];
                if (null != v && "".CompareTo(v) != 0
                    && "sign".CompareTo(k) != 0 && "".CompareTo(v) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }
            string sign = MD5Util.GetMD5(sb.ToString(), getCharset()).ToLower();

            this.setParameter("sign", sign);
            return sign;
        }


        //创建sha1签名
        public string createSHA1Sign()
        {
            StringBuilder sb = new StringBuilder();
            ArrayList akeys = new ArrayList(parameters.Keys);
            akeys.Sort();

            foreach (string k in akeys)
            {
                string v = (string)parameters[k];
                if (null != v && "".CompareTo(v) != 0
                       && "sign".CompareTo(k) != 0 && "key".CompareTo(k) != 0)
                {
                    if (sb.Length == 0)
                    {
                        sb.Append(k + "=" + v);
                    }
                    else
                    {
                        sb.Append("&" + k + "=" + v);
                    }
                }
            }
            string paySign = SHA1Util.getSha1(sb.ToString()).ToString().ToLower();

            //debug信息
            this.setDebugInfo(sb.ToString() + " => sign:" + paySign);
            return paySign;
        }


        //输出XML
        public string parseXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (string k in parameters.Keys)
            {
                string v = (string)parameters[k];
                if (Regex.IsMatch(v, @"^[0-9.]$"))
                {

                    sb.Append("<" + k + ">" + v + "</" + k + ">");
                }
                else
                {
                    sb.Append("<" + k + "><![CDATA[" + v + "]]></" + k + ">");
                }

            }
            sb.Append("</xml>");
            return sb.ToString();
        }



        /** 设置debug信息 */
        public void setDebugInfo(String debugInfo)
        {
            this.debugInfo = debugInfo;
        }

        public Hashtable getAllParameters()
        {
            return this.parameters;
        }

        protected virtual string getCharset()
        {
            return this.httpContext.Request.ContentEncoding.BodyName;
        }
    }
}
