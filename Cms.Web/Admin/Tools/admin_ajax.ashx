<%@ WebHandler Language="C#" Class="admin_ajax" %>

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;

using Cms.Common;

public class admin_ajax : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //取得处事类型
        string action = DTRequest.GetQueryString("action");

        switch (action)
        {
            case "attribute_field_validate": //验证扩展字段是否重复
                attribute_field_validate(context);
                break;
            case "get_remote_fileinfo": //获取远程文件的信息
                get_remote_fileinfo(context);
                break;
        }

    }
    
    #region 验证扩展字段是否重复============================
    private void attribute_field_validate(HttpContext context)
    {
        string column_name = DTRequest.GetString("param");
        if (string.IsNullOrEmpty(column_name))
        {
            context.Response.Write("{ \"info\":\"名称不可为空\", \"status\":\"n\" }");
            return;
        }
        Cms.BLL.C_article_attribute_field bll = new Cms.BLL.C_article_attribute_field();
        if (bll.Exists(column_name))
        {
            context.Response.Write("{ \"info\":\"该名称已被占用，请更换！\", \"status\":\"n\" }");
            return;
        }
        context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
        return;
    }
    #endregion

    #region 获取远程文件的信息==============================
    private void get_remote_fileinfo(HttpContext context)
    {
        string filePath = DTRequest.GetFormString("remotepath");
        if (string.IsNullOrEmpty(filePath))
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"没有找到远程附件地址！\"}");
            return;
        }
        if (!filePath.ToLower().StartsWith("http://"))
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"不是远程附件地址！\"}");
            return;
        }
        try
        {
            HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(filePath);
            HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
            int fileSize = (int)_response.ContentLength;
            string fileName = filePath.Substring(filePath.LastIndexOf("/") + 1);
            string fileExt = filePath.Substring(filePath.LastIndexOf(".") + 1).ToUpper();
            context.Response.Write("{\"status\": 1, \"msg\": \"获取远程文件成功！\", \"name\": \"" + fileName + "\", \"path\": \"" + filePath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}");
        }
        catch
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"远程文件不存在！\"}");
            return;
        }
    }
    #endregion
    
    public bool IsReusable 
    {
        get {
            return false;
        }
    }

}