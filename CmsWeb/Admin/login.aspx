<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>管理员登录</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript">
    $(function () {
        //检测IE
        if ('undefined' == typeof (document.body.style.maxHeight)) {
            window.location.href = 'ie6update.html';
        }
    });
</script>
    <script type="text/javascript">
        function getValidateCode(el) {
            $(el).find("img").attr("src", "tools/validate.aspx?" + Math.random());
        }
    </script>
</head>

<body class="loginbody">
<form id="form1" runat="server">
<div class="login-screen">
	<div class="login-icon">LOGO</div>
    <div class="login-form">
        <h1>系统管理登录</h1>
        <div class="control-group">
            <asp:TextBox ID="txtUserName" runat="server" CssClass="login-field" placeholder="用户名" title="用户名"></asp:TextBox>
            <label class="login-field-icon user" for="txtUserName"></label>
        </div>
        <div class="control-group">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="login-field" TextMode="Password" placeholder="密码" title="密码"></asp:TextBox>
            <label class="login-field-icon pwd" for="txtPassword"></label>
        </div>
        <div class="control-group">
            <asp:TextBox ID="SecureCode" runat="server" CssClass="login-field" placeholder="验证码" title="验证码"></asp:TextBox>
            <label class="login-field-icon pwd" for="txtPassword"><a href="javascript:void(0);" onclick="getValidateCode(this);"><img id="code"
                    src="tools/validate.aspx?rnd=Math.random()" alt="" border="0" /></a></label>
           
        </div>
        <div><asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="btn-login" onclick="btnSubmit_Click" /></div>
        <span class="login-tips"><i></i><b id="msgtip" runat="server">请输入用户名和密码、验证码！</b></span>
    </div>
    <i class="arrow">箭头</i>
</div>
</form>
</body>
</html>