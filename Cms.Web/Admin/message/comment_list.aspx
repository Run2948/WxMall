<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comment_list.aspx.cs" Inherits="Admin_message_comment_list" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import namespace="Cms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>评论管理</title>
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
  <span>评论管理</span>
  <i class="arrow"></i>
  <span>评论列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnAudit" runat="server" CssClass="save" OnClientClick="return ExePostBack('btnAudit','审核通过后将在前台显示，是否继续？');" onclick="btnAudit_Click"><i></i><span>审核</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
      <div class="menu-list">
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged">
            <asp:ListItem Value="" Selected="True">所有属性</asp:ListItem>
            <asp:ListItem Value="isLock">未审核</asp:ListItem>
            <asp:ListItem Value="unLoock">已审核</asp:ListItem>
          </asp:DropDownList>
        </div>
      </div>
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
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td class="comment">
      <div class="title">
        <span class="note"><i><%#Eval("user_name")%></i><i><%#Eval("add_time")%></i><i class="reply"><a href="comment_edit.aspx?id=<%#Eval("id")%>">回复</a></i></span>
        <b><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></b>
        <%#new Cms.BLL.C_article().GetModel(Convert.ToInt32(Eval("article_id"))).title.ToString()%>
      </div>
      <div class="ask">
        <%#Convert.ToInt32(Eval("is_lock")) == 1 ? "<b class=\"audit\" title=\"待审核\"></b>" : ""%><%#Eval("content")%>
        <%#Convert.ToInt32(Eval("is_reply")) == 1 ? "<div class=\"answer\">" +
            "<b>管理员回复：</b>" + Eval("reply_content") + "<span class=\"time\">" + Eval("reply_time") + "</span></div>" : ""%>
      </div>
    </td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\">暂无评论信息</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div id="PageContent" runat="server" class="default">
  <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" FirstPageText="首页"
                        LastPageText="尾页" PrevPageText="上一页" NextPageText="下一页" NumericButtonTextFormatString="-{0}-"
                        Width="100%" ShowCustomInfoSection="Left"  ShowBoxThreshold="2" PageSize="10" InputBoxClass="text2"
                        TextAfterInputBox="" OnPageChanging="AspNetPager1_PageChanging" CssClass="paginator"
                        CurrentPageButtonClass="cpb" CustomInfoHTML="<a href='javascript:void(0);'>共%RecordCount%条</a> <a href='javascript:void(0);'>每页%PageSize%条</a> <a href='javascript:void(0);'>%CurrentPageIndex%/%PageCount%页</a> " />
  </div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
