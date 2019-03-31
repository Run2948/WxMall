<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tuwenMgr.aspx.cs" Inherits="Admin_wxRule_tuwenMgr" %>
<%@ Import Namespace="Cms.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>图文回复内容</title>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function parentToIndex(id) {
            parent.location.href = "/admin/Index.aspx?id=" + id;

        }
        $(function () {
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="tuWenList.aspx" class="back"><i></i><span>返回图文规则列表</span></a>

            <i class="arrow"></i>
            <span>图文回复内容</span>
        </div>
        <!--/导航栏-->
         <div class="mytips">
                最多添加10条内容！
            </div>
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">

                        <li>
                            <asp:HyperLink ID="hlAddTuWen" NavigateUrl="editTuWen.aspx" runat="server" CssClass="icon-btn add"><i></i><span>添加图文回复内容</span></asp:HyperLink></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                </div>
                <div class="r-list righttopname">
                    关键词：
                    <asp:Label ID="lblKeyWords" runat="server" Text="" CssClass="guc"></asp:Label>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->

        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                            <th width="20%">图片</th>
                            <th width="20%">标题</th>
                            <th width="20%">链接</th>
                            <th width="3%">排序</th>
                            <th width="8%">修改</th>

                        </tr>
                    </thead>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="td_c">
                    <td>
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("picUrl")%>' Style="max-height: 50px; max-width: 100px;" />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("rContent")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("detailUrl")%>'></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("seq")%>'></asp:Label>

                    </td>
                    <td>
                        <asp:HyperLink ID="hlEdit" runat="server"  NavigateUrl="editTuWen.aspx" CssClass="img-btn edit operator">修改</asp:HyperLink>
                         
                    </td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
                 </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>

        <!--/内容底部-->
    </form>
</body>
</html>