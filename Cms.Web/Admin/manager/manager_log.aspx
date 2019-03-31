<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager_log.aspx.cs" Inherits="Admin_manager_manager_log" %>
<%@ Import Namespace="Cms.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理日志列表</title>
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
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>管理日志</span>
    </div>
    <!--/导航栏-->

    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExeNoCheckPostBack('btnDelete','删除7天前的管理日志，你确定吗?');"
                            OnClick="btnDelete_Click"><i></i><span>删除日志</span></asp:LinkButton>
                    </li>                    
                </ul>
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
                    <th width="10%">
                        用户名
                    </th>
                    <th width="15%">
                        操作类型
                    </th>
                    <th align="left">
                        备注
                    </th>
                    <th align="left" width="15%">
                        用户IP
                    </th>
                    <th align="left" width="12%">
                        添加时间
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <a href="manager_log.aspx?keywords=<%# Eval("user_name") %>">
                        <%# Eval("user_name")%></a>
                </td>
                <td align="center">
                    <a href="manager_log.aspx?keywords=<%# Eval("action_type") %>">
                        <%# Eval("action_type") %></a>
                </td>
                <td>
                    <%# Eval("remark") %>
                </td>
                <td>
                    <%# Eval("user_ip") %>
                </td>
                <td>
                    <%# Eval("add_time") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
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
                        CurrentPageButtonClass="cpb" CustomInfoHTML="<a href='javascript:void(0);'>共%RecordCount%条</a> <a href='javascript:void(0);'>每页%PageSize%条</a> <a href='javascript:void(0);'>%CurrentPageIndex%/%PageCount%页</a> " NumericButtonCount="5" />
  </div>
</div>
<!--/内容底部-->
    </form>
</body>
</html>
