<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productList.aspx.cs" Inherits="Admin_article_productList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>内容列表</title>
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
        </i><span>
            <%=new Cms.BLL.C_Column().GetModel(Convert.ToInt32(Request["classid"].ToString())).className.ToString()%></span>
        <i class="arrow"></i><span>内容列表</span>
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
                     <%--<li>
                           <input id="InputAffixFile" runat="server" name="InputPictureFile" size="33" 
                        style="WIDTH: 67px; HEIGHT: 31px; float:left;" type="file" />
                        <asp:LinkButton ID="ToExcel" runat="server" CssClass="add" OnClick="ToExcel_Click"><i></i><span>商品导入</span></asp:LinkButton></li>
                      <asp:TextBox ID="d_price" runat="server" Text='' style=" float:left; height:30px;"
                        placeholder="当日金价"/>
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="save" OnClientClick="return CheckPostBack('LinkButton1');" 
                            onclick="LinkButton1_Click"><i></i><span>批量修改优惠价</span></asp:LinkButton></li>
                            <li>
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="save" OnClientClick="return CheckPostBack('LinkButton2');" 
                            onclick="LinkButton2_Click"><i></i><span>批量修改标价</span></asp:LinkButton></li>--%>
                </ul>
                
            </div>
            <div class="r-list">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                <asp:LinkButton ID="lbtnViewImg" runat="server" CssClass="img-view" OnClick="lbtnViewImg_Click"
                    ToolTip="图像列表视图" />
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
                    <th width="6%">
                        选择
                    </th>
                    <th align="left">
                        标题
                    </th>
                    <th align="left" width="12%">
                        所属类别
                    </th>
                    <th align="left" width="16%">
                        发布时间
                    </th>
                     <th align="left" width="16%">
                        价格
                    </th>
                    <th align="left" width="65">
                        排序
                    </th>
                    <th align="left" width="110">
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
                        ID="Fielddocid" Value='<%#Eval("articleId")%>' runat="server" />
                </td>
                <td>
                    <a href="productEdit.aspx?action=edit&articleId=<%#Eval("articleId")%>&classid=<%#Eval("parentId")%>">
                        <%#Eval("title")%></a>
                </td>
                <td>
                    <%# new Cms.BLL.C_Column().GetModel(Convert.ToInt32(Eval("parentId"))).className%>
                </td>
                <td>
                    <%#string.Format("{0:g}", Eval("updateTime"))%>
                </td>
                <td>
                     <%# getPrice(Eval("articleId").ToString())%>
                </td>
                <td>
                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("ordernumber")%>' CssClass="sort"
                        onkeydown="return checkNumber(event);" />
                </td>
                <td>
                    <div class="btn-tools">
                        <asp:LinkButton ID="lbtnIsMsg" CommandName="lbtnIsMsg" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "msg selected" : "msg"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "取消评论" : "设置评论"%>' />
                        <asp:LinkButton ID="lbtnIsTop" CommandName="lbtnIsTop" runat="server" CssClass='<%# Convert.ToInt32(Eval("isTop")) == 1 ? "top selected" : "top"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("isTop")) == 1 ? "取消置顶" : "设置置顶"%>' />
                        <asp:LinkButton ID="lbtnIsRed" CommandName="lbtnIsRed" runat="server" CssClass='<%# Convert.ToInt32(Eval("isRecommend")) == 1 ? "red selected" : "red"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("isRecommend")) == 1 ? "取消推荐" : "设置推荐"%>' />
                        <asp:LinkButton ID="lbtnIsHot" CommandName="lbtnIsHot" runat="server" CssClass='<%# Convert.ToInt32(Eval("isHot")) == 1 ? "hot selected" : "hot"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("isHot")) == 1 ? "取消热门" : "设置热门"%>' />
                        <asp:LinkButton ID="lbtnIsSlide" CommandName="lbtnIsSlide" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "pic selected" : "pic"%>'
                            ToolTip='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "取消幻灯片" : "设置幻灯片"%>' />
                    </div>
                </td>
                <td align="center">
                    <asp:LinkButton ID="lbedit" runat="server" CommandArgument='<%#Eval("articleId")%>'
                        CommandName='<%#Eval("parentId")%>' OnCommand="lbedit_Command">修改</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--/文字列表-->
    <!--图片列表-->
    <div class="imglist">
        <ul>
            <asp:Repeater ID="rptList2" runat="server" OnItemCommand="rptList2_ItemCommand">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="details<%#Eval("photoUrl").ToString() != "" ? "" : " nopic"%>">
                            <div class="check">
                                <asp:CheckBox ID="Check_Select" CssClass="checkall" runat="server" /><asp:HiddenField
                                    ID="Fielddocid" Value='<%#Eval("articleId")%>' runat="server" />
                            </div>
                            <%#Eval("photoUrl").ToString() != "" ? "<div class=\"pic\"><img src=\"../skin/default/loadimg.gif\" data-original=\"" + Eval("photoUrl") + "\" /></div><i class=\"absbg\"></i>" : ""%>
                            <h1>
                                <span><a href="productEdit.aspx?action=edit&articleId=<%#Eval("articleId")%>&classid=<%#Eval("parentId")%>">
                                    <%#Eval("title")%></a></span></h1>
                            <div class="remark">
                                <%#Eval("content").ToString() == "" ? "暂无内容摘要说明..." : ToAspx.getLength(ToAspx.GetToHtml(Eval("content").ToString()), 100)%>
                            </div>
                            <div class="tools">
                                <asp:LinkButton ID="lbtnIsMsg" CommandName="lbtnIsMsg" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "msg selected" : "msg"%>'
                                    ToolTip='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "取消评论" : "设置评论"%>' />
                                <asp:LinkButton ID="lbtnIsTop" CommandName="lbtnIsTop" runat="server" CssClass='<%# Convert.ToInt32(Eval("isTop")) == 1 ? "top selected" : "top"%>'
                                    ToolTip='<%# Convert.ToInt32(Eval("isTop")) == 1 ? "取消置顶" : "设置置顶"%>' />
                                <asp:LinkButton ID="lbtnIsRed" CommandName="lbtnIsRed" runat="server" CssClass='<%# Convert.ToInt32(Eval("isRecommend")) == 1 ? "red selected" : "red"%>'
                                    ToolTip='<%# Convert.ToInt32(Eval("isRecommend")) == 1 ? "取消推荐" : "设置推荐"%>' />
                                <asp:LinkButton ID="lbtnIsHot" CommandName="lbtnIsHot" runat="server" CssClass='<%# Convert.ToInt32(Eval("isHot")) == 1 ? "hot selected" : "hot"%>'
                                    ToolTip='<%# Convert.ToInt32(Eval("isHot")) == 1 ? "取消热门" : "设置热门"%>' />
                                <asp:LinkButton ID="lbtnIsSlide" CommandName="lbtnIsSlide" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "pic selected" : "pic"%>'
                                    ToolTip='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "取消幻灯片" : "设置幻灯片"%>' />
                                <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("ordernumber")%>' CssClass="sort"
                                    onkeydown="return checkNumber(event);" />
                            </div>
                            <div class="foot">
                                <p class="time">
                                    <%#string.Format("{0:yyyy-MM-dd HH:mm:ss}", Eval("updateTime"))%></p>
                                <asp:LinkButton ID="lbedits" runat="server" CommandArgument='<%#Eval("articleId")%>'
                                    CommandName='<%#Eval("parentId")%>' CssClass="edit" title="编辑" OnCommand="lbedit_Command">编辑</asp:LinkButton>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList2.Items.Count == 0 ? "<div align=\"center\" style=\"font-size:12px;line-height:30px;color:#666;\">暂无记录</div>" : ""%>
                </FooterTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!--/图片列表-->
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
