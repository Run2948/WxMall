using System;
using System.Text;
using System.IO;
using System.Net;

//using NetPay;
/// <summary>
/// SignData 的摘要说明
/// </summary>
public class SignData: System.Web.UI.Page
{
    public static string priKeyPath = System.Web.HttpContext.Current.Server.MapPath("/App_Data/MerPrK.key");//System.Configuration.ConfigurationManager.AppSettings["priKeyPath"].ToString();
    public static string pubKeyPath = System.Web.HttpContext.Current.Server.MapPath("/App_Data/PgPubk.key");// System.Configuration.ConfigurationManager.AppSettings["pubKeyPath"].ToString();
    public SignData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    //签名
    public static string sign(string MerId, string plain)
    {
        NetPay netPay = new NetPay();
        Boolean flag = netPay.buildKey(MerId, 0, SignData.priKeyPath);
        string sign = null;
        if (flag)
        {
            if (netPay.PrivateKeyFlag)
            {
                sign = netPay.Sign(plain);
            }
        }
        return sign;

    }

    //验签
    public static bool check(string MerId, string OrdId, string TransAmt, string CuryId, string TransDate, string TransType, string status, string ChkValue)
    {

        NetPay netPay = new NetPay();
        Boolean flag = netPay.buildKey("999999999999999", 0, SignData.pubKeyPath);
        if (flag)
        {
            if (netPay.PublicKeyFlag)
            {
                flag = netPay.verifyTransResponse(MerId, OrdId, TransAmt, CuryId, TransDate, TransType, status, ChkValue);
            }
            else
            {
                flag = false;
            }
        }
        else
        {
            flag = false;
        }

        return flag;

    }


    //得到交易日期
    public static string getTransDate()
    {
        return DateTime.Now.ToString("yyyyMMdd");
    }

    //得到订单号16位
    public static string getOrdId()
    {
        return DateTime.Now.ToString("yyyyMMHHmmffffff");
    }


    public static string postData(string str, string url)
    {
        try
        {
            byte[] data = System.Text.Encoding.GetEncoding("gbk").GetBytes(str);
            //   准备请求...   
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@url);
            req.Method = "Post";
            req.ContentType = "application/x-www-form-urlencoded;charset=gbk";
            req.ContentLength = data.Length;
            Stream stream = req.GetRequestStream();
            //   发送数据   
            stream.Write(data, 0, data.Length);
            stream.Close();

            HttpWebResponse rep = (HttpWebResponse)req.GetResponse();
            Stream receiveStream = rep.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("gbk");
            StreamReader readStream = new StreamReader(receiveStream, encode);

            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            StringBuilder sb = new StringBuilder("");
            while (count > 0)
            {
                String readstr = new String(read, 0, count);
                sb.Append(readstr);
                count = readStream.Read(read, 0, 256);
            }

            rep.Close();
            readStream.Close();

            return sb.ToString();

        }
        catch (Exception ex)
        {
            return "";

        }
    }
}
