using System;
using System.Text;
using System.Web;

namespace Cms.API.Payment.wxpay.comm
{
    /// <summary>
    /// TenpayUtil 的摘要说明。
    /// 配置文件
    /// </summary>
    public class TenpayUtil
    {
        //public static string tenpay = "1";
        //public static string partner = "1218574001";                   //商户号
        //public static string key = "huyuxianghuyuxianghuyuxiang12345";  //密钥
        //public static string appid = "wxa9b8e33e48ac5e0f";//appid
        //public static string appkey = "nwRmqgvSG08pe3vU5qzBLb7Bvih0WOABGzUPvqgFqE0iSkJlJ8wh7JlLYy2cXFgFA3v1bM8eTDm1y1UcyeW9IGq2py2qei7J5xDoVR9lfO3cS6fMjFbMQeeqBRit0bKp";//paysignkey(非appkey) 
        //public static string tenpay_notify = "http://localhost/payNotifyUrl.aspx"; //支付完成后的回调处理页面,*替换成notify_url.asp所在路径

        public TenpayUtil()
        {

        }
        public static string getNoncestr()
        {
            Random random = new Random();
            return MD5Util.GetMD5(random.Next(1000).ToString(), "UTF-8");
        }


        public static string getTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        /** 对字符串进行URL编码 */
        public static string UrlEncode(string instr, string charset)
        {
            //return instr;
            if (instr == null || instr.Trim() == "")
                return "";
            else
            {
                string res;

                try
                {
                    res = HttpUtility.UrlEncode(instr, Encoding.GetEncoding(charset));

                }
                catch (Exception ex)
                {
                    res = HttpUtility.UrlEncode(instr, Encoding.GetEncoding("GB2312"));
                }


                return res;
            }
        }

        /** 对字符串进行URL解码 */
        public static string UrlDecode(string instr, string charset)
        {
            if (instr == null || instr.Trim() == "")
                return "";
            else
            {
                string res;

                try
                {
                    res = HttpUtility.UrlDecode(instr, Encoding.GetEncoding(charset));

                }
                catch (Exception ex)
                {
                    res = HttpUtility.UrlDecode(instr, Encoding.GetEncoding("GB2312"));
                }


                return res;

            }
        }


        /** 取时间戳生成随即数,替换交易单号中的后10位流水号 */
        public static UInt32 UnixStamp()
        {
            TimeSpan ts = DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return Convert.ToUInt32(ts.TotalSeconds);
        }
        /** 取随机数 */
        public static string BuildRandomStr(int length)
        {
            Random rand = new Random();

            int num = rand.Next();

            string str = num.ToString();

            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            else if (str.Length < length)
            {
                int n = length - str.Length;
                while (n > 0)
                {
                    str.Insert(0, "0");
                    n--;
                }
            }

            return str;
        }

    }
}
