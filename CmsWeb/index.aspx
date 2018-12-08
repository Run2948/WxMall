<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <%= new Cms.BLL.C_WebSiteconfig().GetModel(1).title%></title>
    <meta name="keywords" content="<%=ToAspx.getWebSiteconfig(1).keyword%>" />
    <meta name="description" content="<%=ToAspx.getWebSiteconfig(1).Description%>" />
  
</head>
<body>
   请访问CmsWeb\api接口类
</body>


</html>
