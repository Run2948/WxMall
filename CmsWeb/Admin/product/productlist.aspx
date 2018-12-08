<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productlist.aspx.cs" Inherits="Admin_order_orderlist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>订单管理</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>产品列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
         <li><asp:LinkButton ID="btnadd" CssClass="add" runat="server" onclick="btnadd_Click"><i></i><span>新增</span></asp:LinkButton></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','删除留言信息，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
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
<asp:Repeater ID="rptList" runat="server" 
    onitemdatabound="rptList_ItemDataBound">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="4%">选择</th>
    <th align="center" width="6%">类型</th>
    <th align="center" width="8%">材质</th>
    <th align="center" width="8%">名称</th>
    <th align="center" width="8%">优惠价</th>
    <th align="center" width="4%">市场价格</th>
    <th align="center" width="4%">库存</th>
    <th align="center" width="4%">赠送积分</th>
    <th align="center" width="8%">更新时间</th>
    <th align="center" width="4%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server"  style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td align="center"><%# typename(Eval("pid").ToString())%></a></td>
    <td align="center"><%# typename(Eval("Material").ToString())%></a></td>
    <td align="center"><%#Eval("pname")%></a></td>
    <td align="center"><%#Convert.ToDecimal(Eval("Price")).ToString("0.00")%></a></td>
    <td align="center"><%#Convert.ToDecimal(Eval("marketpice")).ToString("0.00")%></td>
    <td align="center"><%#Eval("stock")%></td>
     <td align="center"><%#Eval("integral")%></td>
    <td align="center"><%#Eval("updatetime")%></td>
    <td align="center"><asp:LinkButton ID="lbedit" runat="server" CommandArgument='<%#Eval("id")%>'  oncommand="lbedit_Command">修改</asp:LinkButton>
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
                        Width="100%" ShowCustomInfoSection="Left"  ShowBoxThreshold="2" PageSize="10" InputBoxClass="text2"
                        TextAfterInputBox="" OnPageChanging="AspNetPager1_PageChanging" CssClass="paginator"
                        CurrentPageButtonClass="cpb" CustomInfoHTML="<a href='javascript:void(0);'>共%RecordCount%条</a> <a href='javascript:void(0);'>每页%PageSize%条</a> <a href='javascript:void(0);'>%CurrentPageIndex%/%PageCount%页</a> " />
  </div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
