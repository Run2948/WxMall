<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntegralEdit.aspx.cs" Inherits="Admin_order_IntegralEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看订单信息</title>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="#" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx" class="home">
            <i></i><span>首页</span></a> <i class="arrow"></i><a href="#"><span>订单管理</span></a>
        <i class="arrow"></i><span>订单详细</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">订单详细信息</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">商品详细信息</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">会员详细信息</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">预约店面信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dd>
                <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
                    <tr>
                        <th>
                            订单号
                        </th>
                        <td>
                            <span id="ordernum" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th width="20%">
                            下单时间
                        </th>
                        <td>
                            <span id="updateTime" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            推荐码
                        </th>
                        <td>
                            <span id="recommended_code" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            总数量
                        </th>
                        <td>
                            <span id="Quantity" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            总价格
                        </th>
                        <td>
                            <span id="countprice" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            总积分
                        </th>
                        <td>
                            <span id="integral_sum" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            订单状态
                        </th>
                        <td>
                            <span id="OrderStatus" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            是否支付
                        </th>
                        <td>
                            <span id="isPayment" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            是否发货
                        </th>
                        <td>
                            <span id="isDelivery" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th width="20%">
                            是否收货
                        </th>
                        <td>
                            <span id="is_receiving" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            支付方式
                        </th>
                        <td>
                            <span id="pay_method" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            配送方式
                        </th>
                        <td>
                            <span id="shipping_method" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            备注
                        </th>
                        <td>
                            <span id="note" runat="server"></span>
                        </td>
                    </tr>
                </table>
            </dd>
        </dl>
    </div>
    <div class="tab-content" style="display: none">
        <dl>
            <dd>
                <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
                    <tr>
                        <td align="left">
                            商品名称
                        </td>
                        <td align="left">
                            单价
                        </td>
                        <td align="left">
                            数量
                        </td>
                        <td align="left">
                            备注
                        </td>
                    </tr>
                    <asp:Repeater ID="Repeaterordersub" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="left">
                                    <%#Eval("title")%>
                                </td>
                                <td align="left">
                                    <%#Convert.ToDecimal(Eval("price")).ToString("0.00")%>
                                </td>
                                <td align="left">
                                    <%#Eval("quantity")%>
                                </td>
                                <td align="left">
                                    <%#Eval("note")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </dd>
        </dl>
    </div>
    <div class="tab-content" style="display: none">
        <dl>
            <dd id="userinfo" runat="server">
                <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
                    <tr>
                        <th width="20%">
                            会员账户
                        </th>
                        <td>
                            <span id="UserName" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            账户余额
                        </th>
                        <td>
                            <span id="userMoney" runat="server"></span>元
                        </td>
                    </tr>
                    <tr>
                        <th>
                            账户积分
                        </th>
                        <td>
                            <span id="userJifen" runat="server"></span>分
                        </td>
                    </tr>
                </table>
            </dd>
        </dl>
    </div>

    <div class="tab-content" style="display: none">
      
               <asp:Repeater ID="RepAddress" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="4%">
                            店名
                        </th>
                        <th width="12%">
                            地址
                        </th>
                        <th width="8%">
                            电话
                        </th>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%#Eval("storename")%>
                    </td>
                    <td align="center">
                        <%#Eval("address")%>
                    </td>
                    <td align="center">
                        <%#Eval("tel")%>
                    </td>
                   
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#RepAddress.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
           
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <%-- <input id="btnPrint" type="button" value="打印订单" class="btn violet" />--%>
            <input id="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>