using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
///Notify 的摘要说明
/// </summary>
/// <summary>
/// 回调处理基类
/// 主要负责接收微信支付后台发送过来的数据，对数据进行签名验证
/// 子类在此类基础上进行派生并重写自己的回调处理过程
/// </summary>
public class Notify
{
    public Page page { get; set; }
    public Notify(Page page)
    {
        this.page = page;
    }
    #region 添加日志
    public void setlog(string str, string sname)
    {
        Cms.BLL.C_admin_log cm = new Cms.BLL.C_admin_log();
        Cms.Model.C_admin_log mc = new Cms.Model.C_admin_log();
        mc.remark = str;
        mc.action_type = "微信信息";
        mc.user_name = sname;
        mc.add_time = DateTime.Now;
        cm.Add(mc);
    }
    #endregion
    /// <summary>
    /// 接收从微信支付后台发送过来的数据并验证签名
    /// </summary>
    /// <returns>微信支付后台返回的数据</returns>
    public WxPayData GetNotifyData()
    {

        //转换数据格式并验证签名
        WxPayData data = new WxPayData();
        try
        {
            //接收从微信后台POST过来的数据
            System.IO.Stream s = page.Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            Log.Info(this.GetType().ToString(), "Receive data from WeChat : " + builder.ToString());


            data.FromXml(builder.ToString());
            setlog("LogInfo", "验证签名成功");
        }
        catch (WxPayException ex)
        {
            //若签名错误，则立即返回结果给微信支付后台
            WxPayData res = new WxPayData();
            res.SetValue("return_code", "FAIL");
            res.SetValue("return_msg", ex.Message);
            Log.Error(this.GetType().ToString(), "Sign check error : " + res.ToXml());
            page.Response.Write(res.ToXml());
            page.Response.End();
        }

        Log.Info(this.GetType().ToString(), "Check sign success");
        return data;

    }

    //派生类需要重写这个方法，进行不同的回调处理
    public virtual void ProcessNotify()
    {

    }
}