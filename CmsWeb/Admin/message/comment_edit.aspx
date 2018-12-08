<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comment_edit.aspx.cs" Inherits="Admin_message_comment_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>回复评论</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="comment_list.aspx?channel_id=<%=model.channel_id %>" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>评论管理</span>
  <i class="arrow"></i>
  <span>回复评论</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">回复评论信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>文章标题</dt>
    <dd><%=new Cms.BLL.C_article().GetModel(Convert.ToInt32(model.article_id)).title.ToString()%></dd>
  </dl>
  <dl>
    <dt>评论用户</dt>
    <dd><%=model.user_name %></dd>
  </dl>
  <dl>
    <dt>用户IP</dt>
    <dd><%=model.user_ip %></dd>
  </dl>
  <dl>
    <dt>评论内容</dt>
    <dd><%=model.content %></dd>
  </dl>
  <dl>
    <dt>评论时间</dt>
    <dd><%=model.add_time %></dd>
  </dl>
  <dl>
    <dt>审核状态</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblIsLock" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">已审核</asp:ListItem>
        <asp:ListItem Value="1">未审核</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>回复内容</dt>
    <dd>
      <asp:TextBox ID="txtReContent" runat="server" CssClass="input normal" TextMode="MultiLine" />
    </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
