<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment_list.aspx.cs" Inherits="Admin_settings_payment_list" %>
<%@ Import namespace="Cms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>支付方式</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>支付方式</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存排序</span></asp:LinkButton></li>
      </ul>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">序号</th>
    <th align="left" width="15%">名称</th>
    <th align="left" width="15%">图标</th>
    <th align="left">支付描述</th>
    <th align="left" width="12%">排序</th>
    <th width="8%">是否启用</th>
    <th width="10%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center"><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /><%#Eval("id")%></td>
    <td><a href="payment_edit.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></td>
    <td><%#Eval("img_url").ToString() == "" ? "-" : "<img width=\"20\" src=\"" + Eval("img_url") + "\" />"%></td>
    <td><%#Eval("remark")%></td>
    <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center"><%#Convert.ToInt32(Eval("is_lock")) == 0 ? "是" : "否"%></td>
    <td align="center"><a href="payment_edit.aspx?id=<%#Eval("id")%>">配置</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

</form>
</body>
</html>
