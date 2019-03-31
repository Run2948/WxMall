<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntegralList.aspx.cs" Inherits="Admin_order_IntegralList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单管理</title>
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
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>订单列表</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','是否继续删除订单？');"
                            OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="ToExcel" runat="server" OnClick="ToExcel_Click"><span>导出到Excel</span></asp:LinkButton></li>
                    <li>
                        <div class="input-date">
                            <asp:TextBox ID="startime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                            <i>日期</i></div>
                        <div class="input-date">
                            <asp:TextBox ID="endtime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                            <i>日期</i></div>
                    </li>
                </ul>
                <div class="menu-list">
                    <%--<div class="rule-single-select">
          <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" >
            <asp:ListItem Value="" Selected="True">订单状态</asp:ListItem>
            <asp:ListItem Value="1">已完单</asp:ListItem>
            <asp:ListItem Value="2">未完单</asp:ListItem>
          </asp:DropDownList>
        </div>
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlPaymentStatus" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0" Selected="True">支付状态</asp:ListItem>
            <asp:ListItem Value="1">已支付</asp:ListItem>
            <asp:ListItem Value="2">未支付</asp:ListItem>
          </asp:DropDownList>
        </div>--%>
                </div>
            </div>
            <div class="r-list">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
            </div>
        </div>
    </div>
    <!--/工具栏-->
    <!--列表-->
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="8%">
                        选择
                    </th>
                    <th align="left" width="8%">
                        订单号
                    </th>
                    <th align="center" width="8%">
                       会员
                    </th>
                    <th align="center" width="8%">
                        总数量
                    </th>
                    <th width="10%">
                        总金额
                    </th>
                    <th width="8%">
                        订单状态
                    </th>
                    <th align="left" width="16%">
                        兑换时间
                    </th>
                    <th width="8%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr id="Tr1" runat="server">
                <td align="center">
                    <asp:CheckBox ID="Check_Select" CssClass="checkall" runat="server" />
                    <asp:HiddenField ID="Fielddocid" Value='<%#Eval("id")%>' runat="server" />
                </td>
                <td style="vnd.ms-excel.numberformat: @">
                    <%# DataBinder.Eval(Container.DataItem, "order_num")%>
                </td>
                <td align="center">
                     <%# getUserName(Convert.ToInt32(Eval("user_id").ToString())) %>
                </td>
                <td align="center">
                    <%#Eval("quantity_sum")%>
                </td>
                <td align="center">
                   <%#Convert.ToDecimal(Eval("price_sum")).ToString("0.00")%>
                </td>
                <td align="center">
                <%#getState(Convert.ToInt32(Eval("order_status")))%>
                   
                </td>
                <td>
                    <%#string.Format("{0:g}", Eval("updateTime"))%>
                </td>
                <td align="center">
                    <a href="IntegralEdit.aspx?action=edit&orderid=<%#Eval("id")%>">详细</a> 
                    <%#Eval("order_status").ToString() == "0" || Eval("order_status").ToString() == "1" ? "<a href='IntegralList.aspx?action=Updateorder&id=" + Eval("id") + "'>完单</a>" : "已领取"%>
                  
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
    <div class="line20">
    </div>
    <div class="pagelist">
        <div id="PageContent" runat="server" class="default">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" FirstPageText="首页"
                LastPageText="尾页" PrevPageText="上一页" NextPageText="下一页" NumericButtonTextFormatString="-{0}-"
                Width="100%" ShowCustomInfoSection="Left" ShowBoxThreshold="2" PageSize="10"
                InputBoxClass="text2" TextAfterInputBox="" OnPageChanging="AspNetPager1_PageChanging"
                CssClass="paginator" CurrentPageButtonClass="cpb" CustomInfoHTML="<a href='javascript:void(0);'>共%RecordCount%条</a> <a href='javascript:void(0);'>每页%PageSize%条</a> <a href='javascript:void(0);'>%CurrentPageIndex%/%PageCount%页</a> "
                NumericButtonCount="5" />
        </div>
    </div>
    <!--/内容底部-->
    </form>
</body>
</html>
