using Cms.API.Payment.wxpay.comm;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Xml;

namespace Cms.API.Payment.wxpay
{
    /** 
      '============================================================================
      'api说明：
      'getKey()/setKey(),获取/设置密钥
      'getParameter()/setParameter(),获取/设置参数值
      'getAllParameters(),获取所有参数
      'isTenpaySign(),是否正确的签名,true:是 false:否
      'isWXsign(),是否正确的签名,true:是 false:否
      ' * isWXsignfeedback判断微信维权签名
      ' *getDebugInfo(),获取debug信息
      '============================================================================
      */

    public class ResponseHandler
    {
        // 密钥 
        private string key;

        // appkey
        private string appkey;

        //xmlMap
        private Hashtable xmlMap;

        // 应答的参数
        protected Hashtable parameters;

        //debug信息
        private string debugInfo;
        //原始内容
        protected string content;

        //private string charset = "UTF-8";

        //参与签名的参数列表
        private static string SignField = "appid,appkey,timestamp,openid,noncestr,issubscribe";

        protected HttpContext httpContext;

        //初始化函数
        public virtual void init()
        {
        }

        //获取页面提交的get和post参数
        public ResponseHandler(HttpContext httpContext)
        {
            parameters = new Hashtable();
            xmlMap = new Hashtable();

            this.httpContext = httpContext;
            NameValueCollection collection;
            //post data
            if (this.httpContext.Request.HttpMethod == "POST")
            {
                collection = this.httpContext.Request.Form;
                foreach (string k in collection)
                {
                    string v = (string)collection[k];
                    this.setParameter(k, v);
                }
            }
            //query string
            collection = this.httpContext.Request.QueryString;
            foreach (string k in collection)
            {
                string v = (string)collection[k];
                this.setParameter(k, v);
            }
            if (this.httpContext.Request.InputStream.Length > 0)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(this.httpContext.Request.InputStream);
                XmlNode root = xmlDoc.SelectSingleNode("xml");
                XmlNodeList xnl = root.ChildNodes;

                foreach (XmlNode xnf in xnl)
                {
                    xmlMap.Add(xnf.Name, xnf.InnerText);
                }
            }
        }


        /** 获取密钥 */
        public string getKey()
        { return key; }

        /** 设置密钥 */
        public void setKey(string key, string appkey)
        {
            this.key = key;
            this.appkey = appkey;
        }

        /** 获取参数值 */
        public string getParameter(string parameter)
        {
            string s = (string)parameters[parameter];
            return (null == s) ? "" : s;
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

        /** 是否财付通签名,规则是:按参数名称a-z排序,遇到空值的参数不参加签名。 
         * @return boolean */
        public virtual Boolean isTenpaySign()
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
            string sign = MD5Util.GetMD5(sb.ToString(), getCharset()).ToLower();
            this.setDebugInfo(sb.ToString() + " => sign:" + sign);
            //debug信息
            return getParameter("sign").ToLower().Equals(sign);
        }

        //判断微信签名
        public virtual Boolean isWXsign()
        {
            StringBuilder sb = new StringBuilder();
            Hashtable signMap = new Hashtable();

            foreach (string k in xmlMap.Keys)
            {
                if (k != "SignMethod" && k != "AppSignature")
                {
                    signMap.Add(k.ToLower(), xmlMap[k]);
                }
            }
            signMap.Add("appkey", this.appkey);


            ArrayList akeys = new ArrayList(signMap.Keys);
            akeys.Sort();

            foreach (string k in akeys)
            {
                string v = (string)signMap[k];
                if (sb.Length == 0)
                {
                    sb.Append(k + "=" + v);
                }
                else
                {
                    sb.Append("&" + k + "=" + v);
                }
            }

            string sign = SHA1Util.getSha1(sb.ToString()).ToString().ToLower();

            this.setDebugInfo(sb.ToString() + " => SHA1 sign:" + sign);

            return sign.Equals(xmlMap["AppSignature"]);

        }

        //判断微信维权签名
        public virtual Boolean isWXsignfeedback()
        {
            StringBuilder sb = new StringBuilder();
            Hashtable signMap = new Hashtable();

            foreach (string k in xmlMap.Keys)
            {
                if (SignField.IndexOf(k.ToLower()) != -1)
                {
                    signMap.Add(k.ToLower(), xmlMap[k]);
                }
            }
            signMap.Add("appkey", this.appkey);


            ArrayList akeys = new ArrayList(signMap.Keys);
            akeys.Sort();

            foreach (string k in akeys)
            {
                string v = (string)signMap[k];
                if (sb.Length == 0)
                {
                    sb.Append(k + "=" + v);
                }
                else
                {
                    sb.Append("&" + k + "=" + v);
                }
            }

            string sign = SHA1Util.getSha1(sb.ToString()).ToString().ToLower();

            this.setDebugInfo(sb.ToString() + " => SHA1 sign:" + sign);

            return sign.Equals(xmlMap["AppSignature"]);

        }

        /** 获取debug信息 */
        public string getDebugInfo()
        { return debugInfo; }

        /** 设置debug信息 */
        protected void setDebugInfo(String debugInfo)
        { this.debugInfo = debugInfo; }

        protected virtual string getCharset()
        {
            return this.httpContext.Request.ContentEncoding.BodyName;

        }

        /// <summary>
        /// 获取XML参数的方法(李朴add 2014-5-13)
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string getMpParameter(string parameter)
        {
            string s = (string)xmlMap[parameter];
            return (null == s) ? "" : s;
        }


    }
}
