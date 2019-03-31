using System;
using System.Collections.Generic;
using System.Web;


/// <summary>
///Config 的摘要说明
/// </summary>
/**
* 	配置账号信息
*/
public class WxPayConfig
{
    //=======【基本信息设置】=====================================
    /* 微信公众号信息配置
    * APPID：绑定支付的APPID（必须配置）
    * MCHID：商户号（必须配置）
    * KEY：商户支付密钥，参考开户邮件设置（必须配置）
    * APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
    */
    public const string APPID = "wxf82d5ec0210f7c73";
    public const string MCHID = "1502526021";
    public const string KEY = "dbdc59e94851eb30815025260212804e";//19ace89a7acd6e14ac3c66b2852f14d6
    public const string APPSECRET = "4eb475d2059f9744c706fe49ebec805b";//YOFbXGzn0i8ZH8UlfqH7D7LpHHCXd4CxNqZgLffI8v58GSpxntqnVOx5zJFrsM2efT6XH89Nr0WDpfZjcfYCHD05uteWUfHq6BG8zuyTAe4uQ39yKOKqwYwl6yhgKueb

    //=======【证书路径设置】===================================== 
    /* 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
    */
    public const string SSLCERT_PATH = "cert/apiclient_cert.p12";
    public const string SSLCERT_PASSWORD = "12345_8888";



    //=======【支付结果通知url】===================================== 
    /* 支付结果通知回调url，用于商户接收支付结果
    */
    public const string NOTIFY_URL = "http://lxshenghuo.sulel.com/api/wxpay/ResultNotifyPage.aspx";

    //=======【商户系统后台机器IP】===================================== 
    /* 此参数可手动配置也可在程序中自动获取
    */
    public const string IP = "8.8.8.8";


    //=======【代理服务器设置】===================================
    /* 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
    */
    public const string PROXY_URL = "http://10.152.18.220:8080";

    //=======【上报信息配置】===================================
    /* 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
    */
    public const int REPORT_LEVENL = 1;

    //=======【日志级别】===================================
    /* 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
    */
    public const int LOG_LEVENL = 0;
}