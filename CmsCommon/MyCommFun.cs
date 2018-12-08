using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Cms.Common
{
    public class MyCommFun
    {
        #region request参数处理

        /// <summary>
        /// 判断request的参数是否合法
        /// </summary>
        /// <param name="param">参数名称</param>
        /// <param name="otype"></param>
        /// <returns></returns>
        public static bool IsRequestStr(string param, RequestObjType otype)
        {
            bool ret = true;
            if (HttpContext.Current.Request[param] == null || HttpContext.Current.Request[param].ToString().Trim() == "")
            {
                return false;
            }

            string pValue = HttpContext.Current.Request[param].ToString().Trim();

            switch (otype)
            {
                case RequestObjType.intType:
                    int tmpInt = 0;
                    if (!int.TryParse(pValue, out tmpInt))
                    {
                        return false;
                    }
                    break;
                case RequestObjType.floatType:
                    float tmpFloat = 0;
                    if (!float.TryParse(pValue, out tmpFloat))
                    {
                        return false;
                    }
                    break;
                case RequestObjType.stringType:
                    break;
                default:
                    break;
            }
            return ret;
        }

        /// <summary>
        /// url请求里的参数
        /// 过滤非法字符
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string QueryString(string param)
        {
            if (HttpContext.Current.Request[param] == null || HttpContext.Current.Request[param].ToString().Trim() == "")
            {
                return "";
            }
            string ret = HttpContext.Current.Request[param].ToString().Trim();
            ret = ret.Replace(",", "");
            ret = ret.Replace("'", "");
            ret = ret.Replace(";", "");

            return ret;
        }

        /// <summary>
        /// 取request参数的值
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int RequestInt(string param)
        {
            if (IsRequestStr(param, RequestObjType.intType))
            {
                return int.Parse(HttpContext.Current.Request[param]);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 取request参数的值
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int RequestInt(string param, int defaultInt)
        {
            if (IsRequestStr(param, RequestObjType.intType))
            {
                return int.Parse(HttpContext.Current.Request[param]);
            }
            else
            {
                return defaultInt;
            }
        }

        /// <summary>
        /// 取request参数的值
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static float RequestFloat(string param, float defaultFloat)
        {
            if (IsRequestStr(param, RequestObjType.floatType))
            {
                return float.Parse(HttpContext.Current.Request[param]);
            }
            else
            {
                return defaultFloat;
            }
        }


        /// <summary>
        /// 获得参数openid
        /// 过滤非法字符
        /// </summary>
        /// <returns></returns>
        public static string RequestOpenid()
        {
            string ret = "";
            if (HttpContext.Current.Request.Params["openid"] != null)
            {
                ret = HttpContext.Current.Request.Params["openid"].ToString();
            }
            if (ret == "")
            {
                ret = "loseopenid";
            }
            ret = ret.Replace(",", "");
            ret = ret.Replace("'", "");
            ret = ret.Replace(";", "");

            return ret;
        }

        /// <summary>
        /// 获得参数wid
        /// </summary>
        /// <returns></returns>
        public static int RequestWid()
        {
            int ret = RequestInt("wid");
            return ret;
        }



        public static string RequestParam(string paramName)
        {
            string ret = "";
            if (HttpContext.Current.Request.Params[paramName] != null)
            {
                ret = HttpContext.Current.Request.Params[paramName].ToString();
            }
            return ret;
        }
        #endregion

        #region 判断数据类型和处理数据类型转换

        /// <summary>
        /// object 转 str
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjToStr(object o)
        {
            try
            {
                if (o == null)
                {
                    return "";
                }
                else
                {
                    return o.ToString();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// object 转 str，若转换失败，则返回nullReplaceStr字符串
        /// </summary>
        /// <param name="o"></param>
        /// <param name="nullReplaceStr"></param>
        /// <returns></returns>
        public static string ObjToStr(object o, string nullReplaceStr)
        {
            try
            {
                if (o == null)
                {
                    return nullReplaceStr;
                }
                else
                {
                    return o.ToString();
                }
            }
            catch (Exception ex)
            {
                return nullReplaceStr;
            }
        }

        /// <summary>
        /// 判断对象是否可以转成int型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool isNumber(object o)
        {
            int tmpInt;
            if (o == null)
            {
                return false;
            }
            if (o.ToString().Trim().Length == 0)
            {
                return false;
            }
            if (!int.TryParse(o.ToString(), out tmpInt))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断是否是合法的时间类型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool isDateTime(object o)
        {
            DateTime tmpInt = new DateTime();
            if (o == null)
            {
                return false;
            }
            if (o.ToString().Trim().Length == 0)
            {
                return false;
            }
            if (!DateTime.TryParse(o.ToString(), out tmpInt))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool isDecimal(object o)
        {
            decimal tmpInt;
            if (o == null)
            {
                return false;
            }
            if (o.ToString().Trim().Length == 0)
            {
                return false;
            }
            if (!decimal.TryParse(o.ToString(), out tmpInt))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 字符串转变成数字，如果转行失败，则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int Str2Int(string str)
        {
            if (isNumber(str))
            {
                return int.Parse(str);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 字符串转变成数字，如果转行失败，则返回defaultInt
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int Str2Int(string str, int defaultInt)
        {
            if (isNumber(str))
            {
                return int.Parse(str);
            }
            else
            {
                return defaultInt;
            }
        }

        /// <summary>
        /// 对象object转int，若失败则为0
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int Obj2Int(object obj)
        {
            if (isNumber(obj))
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 对象object转decimal，若失败则为defaultDec
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static decimal Obj2Decimal(object obj, decimal defaultDec)
        {
            decimal tmpDecimal = 0;
            if (obj == null || obj.ToString().Trim() == "")
            {
                return defaultDec;
            }

            if (decimal.TryParse(obj.ToString(), out tmpDecimal))
            {
                return tmpDecimal;
            }
            else
            {
                return defaultDec;
            }

        }

        /// <summary>
        /// 对象object转int，若失败则为defaultInt
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultInt"></param>
        /// <returns></returns>
        public static int Obj2Int(object obj, int defaultInt)
        {
            if (isNumber(obj))
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return defaultInt;
            }
        }


        public static float Str2Float(string str)
        {
            if (str == null || str.Trim().Length <= 0)
            {
                return 0;
            }
            float tmpFloat = 0;
            if (float.TryParse(str, out tmpFloat))
            {
                return tmpFloat;
            }
            else
            {
                return 0;
            }

        }


        public static decimal Str2Decimal(string str)
        {
            if (str == null || str.Trim().Length <= 0)
            {
                return 0;
            }
            decimal tmpFloat = 0;
            if (decimal.TryParse(str, out tmpFloat))
            {
                return tmpFloat;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// object 2时间类型，如果不成功则返回1990-1-1
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime Obj2DateTime(object obj)
        {
            if (isDateTime(obj))
            {
                return DateTime.Parse(obj.ToString());
            }
            else
            {
                return DateTime.Parse("1990-1-1");
            }
        }

        public static decimal decimalF2(decimal num)
        {
            decimal ret = 0;
            ret = decimal.Parse(num.ToString("f2"));

            return ret;
        }

        #endregion



        #region 微信后缀操作

        public static string getWXApiUrl(string url, string token, string openid)
        {
            string ret = "";
            if (openid == "")
            {
                openid = "loseopenid";
            }

            if (token == "")
            {
                token = "losetoken";
            }


            if (url.Contains("?"))
            {
                ret = url + "&token=" + token + "&openid=" + openid;
            }
            else
            {
                ret = url + "?token=" + token + "&openid=" + openid;
            }
            return ret;
        }

        /// <summary>
        /// 给url地址添加openid
        /// </summary>
        /// <param name="orginUrl"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static string urlAddOpenid(string orginUrl, string openid)
        {
            if (openid == "")
            {
                openid = "loseopenid";
            }
            if (orginUrl.Contains("?openid=") || orginUrl.Contains("&openid="))
            {
                return orginUrl;
            }
            if (orginUrl.Contains("?"))
            {
                return orginUrl + "&openid=" + openid;
            }
            else
            {
                return orginUrl + "?openid=" + openid;
            }
        }


        /// <summary>
        /// 设置微信支持的一键拨号手机的url后缀
        /// </summary>
        /// <returns></returns>
        public static string getWxSuffixByTel()
        {
            string suffix = "";
            if (ConfigurationManager.AppSettings["nati_suffix"] != null)
            {
                suffix = ConfigurationManager.AppSettings["nati_suffix"].ToString();
            }

            return suffix;

        }

        #endregion

        #region 站点的基本url信息
        /// <summary>
        /// 获得网站的根目录的url,比如http://www.baidu.com
        /// </summary>
        /// <returns></returns>
        public static string getWebSite()
        {
            string website = "http://" + HttpContext.Current.Request.Url.Authority;
            return website;
        }

        /// <summary>
        /// 设当前页完整地址 
        /// 比如：http://www.jb51.net/aaa/bbb.aspx?id=5&name=kelli 
        /// </summary>
        /// <returns></returns>
        public static string getTotalUrl()
        {
            string url = HttpContext.Current.Request.Url.ToString();
            return url;

        }
        /// <summary>
        /// 取得网站根目录的物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            if (HttpCurrent != null)
            {
                AppPath = HttpCurrent.Server.MapPath("~");
            }
            else
            {
                AppPath = AppDomain.CurrentDomain.BaseDirectory;
                if (Regex.Match(AppPath, @"\\$", RegexOptions.Compiled).Success)
                    AppPath = AppPath.Substring(0, AppPath.Length - 1);
            }
            return AppPath;
        }

        #endregion


        /// <summary>
        /// 改变url的页码参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="newPageNum"></param>
        /// <returns></returns>
        public static string ChangePageNum(string url, int newPageNum)
        {
            string newUrl = "";
            string canshu = "page";
            string beforZ = "?"; //前缀
            if (url.Contains("?"))
            {
                beforZ = "&";
            }
            if (!url.Contains("page="))
            {
                newUrl = url + beforZ + "page=" + newPageNum;
            }
            else
            {
                int oldPageNum = 0;
                Regex urlRegex = new Regex(@"(?:^|\?|&)page=(\d*)(?:&|$)");
                Match m = urlRegex.Match(url.ToLower());
                if (m.Success)
                {
                    oldPageNum = int.Parse(m.Groups[1].Value);
                }
                newUrl = url.Replace("page=" + oldPageNum, "page=" + newPageNum);
            }

            return newUrl;
        }


        /// <summary>
        /// 拼接json的字符串;
        /// 比如："{\"ret\":\"err\",\"stadname\":\"未知\"}"
        /// </summary>
        /// <param name="jsonDict"></param>
        /// <returns></returns>
        public static string getJsonStr(Dictionary<string, string> jsonDict)
        {
            StringBuilder sb = new StringBuilder("{");
            int i = 0;
            foreach (KeyValuePair<string, string> jd in jsonDict)
            {
                if (i != (jsonDict.Count() - 1))
                {
                    sb.Append("\"" + jd.Key + "\":\"" + jd.Value + "\",");
                }
                else
                {
                    sb.Append("\"" + jd.Key + "\":\"" + jd.Value + "\"");
                }

                i++;
            }

            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 截取字符串长度，超出部分使用后缀suffix代替，比如abcdevfddd取前3位，后面使用...代替
        /// </summary>
        /// <param name="orginStr"></param>
        /// <param name="length"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string SubStrAddSuffix(string orginStr, int length, string suffix)
        {
            string ret = orginStr;
            if (orginStr.Length > length)
            {
                ret = orginStr.Substring(0, length) + suffix;
            }
            return ret;
        }

        #region 时间类型《===》时间戳

        /// <summary>
        /// 时间戳转成时间类型
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 时间类型转成long
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            long intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (long)(time - startTime).TotalSeconds;
            return intResult;
        }

        #endregion


    }

    public enum RequestObjType
    {
        intType, stringType, floatType
    }
}
