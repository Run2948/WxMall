<%@ Page Language="C#" AutoEventWireup="true" CodeFile="typelist.aspx.cs" Inherits="Admin_settings_typelist" %>
<%@ Import namespace="Cms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>栏目管理</title>
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
  <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>分类列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
       <li>
           <asp:LinkButton ID="btnadd" CssClass="add" runat="server" onclick="btnadd_Click"><i></i><span>新增</span></asp:LinkButton>
      </li>
        <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本导航及下属子导航，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" width="12%">ID</th>
    <th align="left">名称</th>
    <th width="8%">是否热门</th>
    <th width="8%">是否隐藏</th>
    <th align="left" width="65">排序</th>
    <th width="12%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
      <asp:HiddenField ID="hidLayer" Value='<%#Eval("class_layer") %>' runat="server" />
      <asp:HiddenField ID="hidname" Value='<%#Eval("title")%>' runat="server" />
    </td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;"><%#Eval("id")%></td>
    <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
        <%#Eval("title")%>
    </td>
    <td align="center"><%#Eval("isHot").ToString() == "0" ? "否" : "是"%></td>
    <td align="center"><%#Eval("isHidden").ToString() == "0" ? "否" : "是"%></td>
    <td><asp:TextBox ID="ordernumber" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
      <asp:LinkButton ID="lbadd" runat="server" CommandArgument='<%#Eval("id")%>' 
    oncommand="lbadd_Command">添加子级</asp:LinkButton>
      <asp:LinkButton ID="lbedit" runat="server" CommandArgument='<%#Eval("id")%>' 
    oncommand="lbedit_Command">修改</asp:LinkButton>
    </td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

</form>
</body>
</html>
