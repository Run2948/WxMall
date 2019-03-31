<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wx_userList.aspx.cs" Inherits="Admin_wx_wx_userList" %>

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
                     <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                     <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="del" OnClick="btnDelete_Click1"><i></i><span>删除</span></asp:LinkButton></li>
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
                   <th width="6%">
                        选择
                    </th>
                    <th width="5%">
                        ID
                    </th>
                    <th width="5%">
                        subscribe
                    </th>
                    <th width="15%">
                        openid
                    </th>
                    <th width="5%">
                        nickname
                    </th>
                    <th width="5%">
                        sex
                    </th>
                    <th width="5%">
                        language
                    </th>
                    <th width="10%">
                        subscribe_time
                    </th>
                    <th width="15%">
                        remark
                    </th>
                    <th width="12%">
                        添加时间
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
            <td align="center">
                    <asp:CheckBox ID="Check_Select" CssClass="checkall" runat="server" Style="vertical-align: middle;" /><asp:HiddenField
                        ID="Fielddocid" Value='<%#Eval("id")%>' runat="server" />
                </td>
                <td width="5%" align="center">
                    <a href="" title="<%# Eval("city")%> <%# Eval("province")%>  <%# Eval("country")%> <%# Eval("headimgurl")%>">
                        <%# Eval("id")%></a>
                </td>
                <td width="5%" align="center">
                    <a href="" title="<%# Eval("city")%> <%# Eval("province")%>  <%# Eval("country")%> <%# Eval("headimgurl")%>">
                        <%# Eval("subscribe")%></a>
                </td>
                <td width="15%" align="center">
                    <%# Eval("openid")%>
                </td>
                <td width="5%" align="center">
                   <a href="" title="<%# Eval("city")%> <%# Eval("province")%>  <%# Eval("country")%> <%# Eval("headimgurl")%>"><%# Eval("nickname")%></a> 
                </td>
                <td width="5%" align="center">
                    <%# Eval("sex")%>
                </td>
                <td width="5%" align="center">
                    <%# Eval("language")%>
                </td>
                <td width="10%" align="center">
                    <%# Eval("subscribe_time")%>
                </td>
                <td width="15%" align="center">
                    <%# Eval("remark")%>
                    <%#Eval("headimgurl").ToString() != "" ? "<img width=\"64\" height=\"64\" src=\"" + Eval("headimgurl") + "\" />" : "<b class=\"user-avatar\"></b>"%>
                </td>
                <td width="15%" align="center">
                    <%# Eval("updatetime")%>
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
    <div class="line20">
    </div>
    <div class="pagelist">
        <div id="PageContent" runat="server" class="default">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" FirstPageText="首页"
                LastPageText="尾页" PrevPageText="上一页" NextPageText="下一页" NumericButtonTextFormatString="-{0}-"
                Width="100%" ShowCustomInfoSection="Left" ShowBoxThreshold="0" PageSize="5" InputBoxClass="text2"
                TextAfterInputBox="" OnPageChanging="AspNetPager1_PageChanging" CssClass="paginator"
                CurrentPageButtonClass="cpb" CustomInfoHTML="<a href='javascript:void(0);'>共%RecordCount%条</a> <a href='javascript:void(0);'>每页%PageSize%条</a> <a href='javascript:void(0);'>%CurrentPageIndex%/%PageCount%页</a> "
                NumericButtonCount="5" ShowMoreButtons="False" ShowPageIndex="True" ShowPageIndexBox="Never" />
        </div>
    </div>
    <!--/内容底部-->
    </form>
</body>
</html>
