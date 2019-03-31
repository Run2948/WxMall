<%@ Page Language="C#" AutoEventWireup="true" CodeFile="model_list.aspx.cs" Inherits="Admin_settings_model_list" %>
<%@ Import namespace="Cms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>模型</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/jquery.lazyload.min.js"></script>
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
  <span>模型</span>
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
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本类别及下属子类别，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<div class="imglist">
<asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound" 
        onitemcommand="rptList_ItemCommand">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="6%">选择</th>
    <th align="left" width="6%">ID</th>
    <th align="left">模型名称</th>
   
    <th width="12%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("modelId")%>' runat="server" />
      <asp:HiddenField ID="hidLayer" Value='1' runat="server" />
    </td>
    <td><%#Eval("modelId")%></td>
    <td>
      <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
      <%#Eval("modelName")%>
    </td>
 
    <td align="center">
      <asp:LinkButton ID="lbedit" runat="server" CommandArgument='<%#Eval("modelId")%>' CommandName='<%#Eval("modelId")%>' oncommand="lbedit_Command">修改</asp:LinkButton>
    </td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>

</div>
<!--/列表-->
</form>
</body>
</html>