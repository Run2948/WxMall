<%@ WebHandler Language="C#" Class="payinfo" %>

using Cms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class payinfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/json";
        string action = MyCommFun.QueryString("act");
        Dictionary<string, string> jsonDict = new Dictionary<string, string>();

        if (action == "orderRet")
        {
            #region   //跳转到结果页面，查询订单的最终结果信息
            string openid = MyCommFun.RequestOpenid();
            int otid = MyCommFun.RequestInt("otid");
            jsonDict = new Dictionary<string, string>();
            if (openid == "" || otid == 0)
            {
                jsonDict.Add("ret", "err");
                jsonDict.Add("content", "抱歉，参数不正确！");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                return;
            }
            Cms.BLL.C_order otBll = new Cms.BLL.C_order();
            Cms.Model.C_order ordertmp = otBll.GetModel(otid);
            if (ordertmp.is_payment == 1)
            {
                jsonDict.Add("ret", "ok");
                jsonDict.Add("content", "下单已经成功！");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));

            }
            else
            {
                jsonDict.Add("ret", "err");
                jsonDict.Add("content", "下单失败！");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
            }
            #endregion
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}