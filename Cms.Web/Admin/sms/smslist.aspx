<%@ Page Language="C#" AutoEventWireup="true" CodeFile="smslist.aspx.cs" Inherits="Admin_sms_smslist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>短信管理</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../scripts/datepicker/WdatePicker.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>短信列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
         <li><a class="add" href="smsEdit.aspx?action=add"><i></i><span>发送短信</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','是否继续删除短信记录？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
    
      </ul>
      <div class="menu-list">

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
  <tr>
    <th width="8%">选择</th>
    <th align="center" width="8%">手机号</th>
    
    <th align="center">内容</th>
    <th align="center" width="8%">发送状态</th>
      <th align="center" width="8%">时间</th>
    <th width="10%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr id="Tr1" runat="server">
    <td align="center">
      <asp:CheckBox ID="Check_Select" CssClass="checkall" runat="server" />
      <asp:HiddenField ID="Fielddocid" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td align="center"><%#Eval("telphone").ToString()%></td>
   
    <td align="center"><%#Eval("content").ToString().Length>21? Eval("content").ToString().Substring(0,20):Eval("content").ToString()%></td>
    <td align="center"><%#Eval("state").ToString()=="0"? "发送失败":"发送成功"%></td>
    <td><%#string.Format("{0:g}", Eval("updateTime"))%></td>
    <td align="center"><a href="smsEdit.aspx?action=edit&id=<%#Eval("id")%>">查看并发送</a>
    
    </td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
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
                        Width="100%" ShowCustomInfoSection="Left"  
          ShowBoxThreshold="2" PageSize="10" InputBoxClass="text2"
                        TextAfterInputBox="" 
          OnPageChanging="AspNetPager1_PageChanging" CssClass="paginator"
                        CurrentPageButtonClass="cpb" 
          CustomInfoHTML="<a href='javascript:void(0);'>共%RecordCount%条</a> <a href='javascript:void(0);'>每页%PageSize%条</a> <a href='javascript:void(0);'>%CurrentPageIndex%/%PageCount%页</a> " 
          NumericButtonCount="5" />
  </div>
</div>
<!--/内容底部-->
</form>
</body>
</html>

