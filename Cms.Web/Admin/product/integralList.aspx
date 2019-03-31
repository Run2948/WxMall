<%@ Page Language="C#" AutoEventWireup="true" CodeFile="integralList.aspx.cs" Inherits="Admin_product_integralList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>产品列表</title>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            imgLayout();
            $(window).resize(function () {
                imgLayout();
            });
            //图片延迟加载
            $(".pic img").lazyload({ load: AutoResizeImage, effect: "fadeIn" });
            //点击图片链接
            $(".pic img").click(function () {
                //$.dialog({ lock: true, title: "查看大图", content: "<img src=\"" + $(this).attr("src") + "\" />", padding: 0 });
                var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
                if (linkUrl != "") {
                    location.href = linkUrl; //跳转到修改页面
                }
            });
        });
        //排列图文列表
        function imgLayout() {
            var imgWidth = $(".imglist").width();
            var lineCount = Math.floor(imgWidth / 235);
            var lineNum = imgWidth % 235 / (lineCount - 1);
            $(".imglist ul").width(imgWidth + Math.ceil(lineNum));
            $(".imglist ul li").css("margin-right", parseFloat(21));
        }
        //等比例缩放图片大小
        function AutoResizeImage(e, s) {
            var img = new Image();
            img.src = $(this).attr("src")
            var w = img.width;
            var h = img.height;
            var wRatio = w / h;
            if ((222 / wRatio) >= 165) {
                $(this).width(222); $(this).height(222 / wRatio);
            } else {
                $(this).width(165 * wRatio); $(this).height(165);
            }
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>积分产品</span> <i class="arrow"></i><span>列表</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li>
                        <asp:LinkButton ID="btnadd" CssClass="add" runat="server" OnClick="btnadd_Click"><i></i><span>新增</span></asp:LinkButton></li>
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                </ul>
            </div>
            <div class="r-list">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                <asp:LinkButton ID="lbtnViewTxt" runat="server" CssClass="txt-view" OnClick="lbtnViewTxt_Click"
                    ToolTip="文字列表视图" />
            </div>
        </div>
    </div>
    <!--/工具栏-->
    <!--文字列表-->
    <asp:Repeater ID="rptList1" runat="server" OnItemCommand="rptList_ItemCommand">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="5%">
                        选择
                    </th>
                    <th align="left" width="12%">
                        封面
                    </th>
                    <th align="left" width="30%">
                        产品名称
                    </th>
                    <th align="left" width="5%">
                        价格
                    </th>
                   <th align="left" width="5%">
                        积分
                    </th>
                    <th align="left" width="10%">
                        发布时间
                    </th>
                    <th align="left" width="5%">
                        排序
                    </th>
                    <th align="left" width="8%">
                        属性
                    </th>
                    <th width="8%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="Check_Select" CssClass="checkall" runat="server" Style="vertical-align: middle;" /><asp:HiddenField
                        ID="Fielddocid" Value='<%#Eval("id")%>' runat="server" />
                </td>
                <td>
                    <img src="<%#Eval("litpic")%>" width="80" height="80" />
                </td>
                <td>
                    <a href="edit.aspx?action=edit&id=<%#Eval("id")%>">
                        <%#Eval("name")%></a>
                </td>
                <td>
                    <%#Convert.ToDecimal(Eval("price")).ToString("f2")%>
                </td>
                <td>
                    <%#Convert.ToDecimal(Eval("integral")).ToString()%>
                </td>
                <td>
                    <%#string.Format("{0:g}", Eval("createdTime"))%>
                </td>
                <td>
                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sortId")%>' CssClass="sort"
                        onkeydown="return checkNumber(event);" />
                </td>
                <td>
                    <div class="btn-tools">
                        <asp:LinkButton ID="lbtnIsMsg" CommandName="lbtnIsMsg" runat="server" CssClass='<%# Convert.ToInt32(Eval("isActive")) == 1 ? "msg selected" : "msg"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("isActive")) == 1 ? "取消活动" : "设置活动"%>' />
                        <asp:LinkButton ID="lbtnIsTop" CommandName="lbtnIsTop" runat="server" CssClass='<%# Convert.ToInt32(Eval("isTop")) == 1 ? "top selected" : "top"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("isTop")) == 1 ? "取消置顶" : "设置置顶"%>' />
                        <asp:LinkButton ID="lbtnIsRed" CommandName="lbtnIsRed" runat="server" CssClass='<%# Convert.ToInt32(Eval("isRecommend")) == 1 ? "red selected" : "red"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("isRecommend")) == 1 ? "取消推荐" : "设置推荐"%>' />
                        <asp:LinkButton ID="lbtnIsHot" CommandName="lbtnIsHot" runat="server" CssClass='<%# Convert.ToInt32(Eval("isHot")) == 1 ? "hot selected" : "hot"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("isHot")) == 1 ? "取消热门" : "设置热门"%>' />
                        <%-- <asp:LinkButton ID="lbtnIsSlide" CommandName="lbtnIsSlide" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "pic selected" : "pic"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "取消幻灯片" : "设置幻灯片"%>' />--%>
                    </div>
                </td>
                <td align="center">
                    <asp:LinkButton ID="lbedit" runat="server" CommandArgument='<%#Eval("id")%>' CommandName='<%#Eval("id")%>'
                        OnCommand="lbedit_Command">修改</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--/文字列表-->
    <!--内容底部-->
    <div class="line20">
    </div>
    <div class="pagelist">
        <div id="PageContent" runat="server" class="default">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" FirstPageText="首页"
                LastPageText="尾页" PrevPageText="上一页" NextPageText="下一页" NumericButtonTextFormatString="-{0}-"
                Width="100%" ShowCustomInfoSection="Left" ShowBoxThreshold="2" InputBoxClass="text2"
                TextAfterInputBox="" OnPageChanging="AspNetPager1_PageChanging" CssClass="paginator"
                CurrentPageButtonClass="cpb" CustomInfoHTML="<a href='javascript:void(0);'>共%RecordCount%条</a> <a href='javascript:void(0);'>每页%PageSize%条</a> <a href='javascript:void(0);'>%CurrentPageIndex%/%PageCount%页</a> "
                NumericButtonCount="5" PageSize="5" ShowPageIndexBox="Never" />
        </div>
    </div>
    <!--/内容底部-->
    </form>
</body>
</html>

