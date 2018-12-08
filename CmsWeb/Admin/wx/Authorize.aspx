<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Authorize.aspx.cs" Inherits="Admin_wx_menu"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">        var yyuc_jspath = "/@system/";</script>
    <script src="js/jquery.js" type="text/javascript"></script>
   
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="js/yyucadapter.js" type="text/javascript"></script>
    
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="location">
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>微信管理</span>
    </div>
    <div class="line10">
    </div>
    <div class="content-tab-wrap">
        <div id="floathead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">授权设置</a></li>
                  
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>微信号(原始ID)：</dt>
            <dd>
                <asp:TextBox ID="WxId" runat="server" Width="300"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>公众平台appid：</dt>
            <dd>
                <asp:TextBox ID="AppId" runat="server" Width="300"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>公众平台appsecret： </dt>
            <dd>
                <asp:TextBox ID="AppSecret" runat="server" Width="300"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>access_token:</dt>
            <dd>
                <asp:TextBox ID="hdid" runat="server" Width="300"></asp:TextBox>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>文章路径：</dt>
            <dd>
                <asp:TextBox ID="wurl" runat="server" Width="300"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt></dt>
            <dd>
                <asp:Button ID="btnsave" runat="server" CssClass="btn" Text="设置" OnClick="btnsave_Click" />
            </dd>
        </dl>
    </div>
    
    </form>
</body>
</html>
