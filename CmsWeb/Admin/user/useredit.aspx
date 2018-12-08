<%@ Page Language="C#" AutoEventWireup="true" CodeFile="useredit.aspx.cs" Inherits="Admin_user_useredit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑用户</title>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="userlist.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>会员管理</span>
        <i class="arrow"></i><span>编辑用户</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本资料</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">收货地址</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">购物记录</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);" style="display:none;">兑换记录</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);" style="display:none;">积分明细</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);" style="display:none;">接口同步</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>姓名</dt>
            <dd>
                <asp:TextBox ID="username" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox>
            </dd>
        </dl>
     
        <dl style="display:none;">
            <dt>密码</dt>
            <dd>
                <asp:TextBox ID="password" runat="server" CssClass="input normal" datatype="*0-20"
                    sucmsg=" "></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>openId</dt>
            <dd>
                <asp:TextBox ID="openid" runat="server" CssClass="input normal" datatype="*0-50"
                    sucmsg=" "></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>性别</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="男">男</asp:ListItem>
                        <asp:ListItem Value="女">女</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>手机号码</dt>
            <dd>
                <asp:TextBox ID="telphone" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>微信号</dt>
            <dd>
                <asp:TextBox ID="shopname" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>生日</dt>
            <dd>
                <asp:TextBox ID="shopcode" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>地址</dt>
            <dd>
                <asp:TextBox ID="useraddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
          <dl >
            <dt>会员编号</dt>
            <dd>
                <asp:TextBox ID="usercard" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox>
            </dd>
        </dl>
        <dl style="display:none;">
            <dt>生日</dt>
            <dd>
                <asp:TextBox ID="birthday" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
        <dl style="display:none;">
            <dt>结婚纪念日</dt>
            <dd>
                <asp:TextBox ID="marryday" runat="server" CssClass="input normal"></asp:TextBox></dd>
        </dl>
        <%--<dl>
            <dt>账户金额</dt>
            <dd>
                <asp:TextBox ID="userMoney" runat="server" CssClass="input small" datatype="*0-50"
                    sucmsg=" ">0</asp:TextBox>
                元 <span class="Validform_checktip">*账户上的余额</span>
            </dd>
        </dl>--%>
        <dl style="display:none;">
            <dt>账户积分</dt>
            <dd>
                <asp:TextBox ID="userJifen" runat="server" CssClass="input small" datatype="*0-50"
                    sucmsg=" "></asp:TextBox>
                分 <span class="Validform_checktip">*积分也可做为交易</span>
            </dd>
        </dl>
        <dl>
            <dt>注册时间</dt>
            <dd>
                <asp:Label ID="updatetime" Text="-" runat="server"></asp:Label></dd>
        </dl>
    </div>
    <div class="tab-content" style="display: none;">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="4%">
                            收货人
                        </th>
                        <th width="12%">
                            手机
                        </th>
                        <th width="8%">
                            邮编
                        </th>
                        <th width="12%">
                            所在地区
                        </th>
                        <th width="8%">
                            街道
                        </th>
                        <th width="12%">
                            详细地址
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
               <tr>
                    <td align="center">
                        <%#Eval("consignee")%>
                    </td>
                    <td align="center">
                        <%#Eval("cellphone")%>
                    </td>
                    <td align="center">
                        <%#Eval("code")%>
                    </td>
                    <td align="center">
                        <%#Eval("location")%>
                    </td>
                    <td align="center">
                        <%#Eval("street")%>
                    </td>
                    <td align="center">
                        <%#Eval("address")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="tab-content" style="display: none;">
        <asp:Repeater ID="RepBuyRecord" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="4%">
                            商品名称
                        </th>
                        <th width="12%">
                            价格
                        </th>
                        <th  width="8%">
                            数量
                        </th>
                        <th width="12%">
                            属性值
                        </th>
                        <th width="8%">
                            备注
                        </th>
                        <th width="12%">
                            时间
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%#Eval("title")%>
                    </td>
                    <td align="center">
                        <%#Convert.ToDecimal(Eval("price")).ToString("0.00")%>
                    </td>
                    <td align="center">
                        <%#Eval("quantity")%>
                    </td>
                    <td align="center">
                        <%#Eval("property_value")%>
                    </td>
                    <td align="center">
                        <%#Eval("note")%>
                    </td>
                    <td align="center">
                        <%#Eval("updateTime")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#RepBuyRecord.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="tab-content" style="display: none;">
        <asp:Repeater ID="RepIntegralRec" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="4%">
                            商品名称
                        </th>
                        <th width="12%">
                            积分
                        </th>
                        <th  width="8%">
                            数量
                        </th>
                        <th width="12%">
                            属性值
                        </th>
                        <th width="8%">
                            备注
                        </th>
                        <th width="12%">
                            时间
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%#Eval("title")%>
                    </td>
                    <td align="center">
                        <%#Eval("integral")%>
                    </td>
                    <td align="center">
                        <%#Eval("quantity")%>
                    </td>
                    <td align="center">
                        <%#Eval("property_value")%>
                    </td>
                    <td align="center">
                        <%#Eval("note")%>
                    </td>
                    <td align="center">
                        <%#Eval("updateTime")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#RepBuyRecord.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="tab-content" style="display: none;">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="12%">
                            会员卡
                        </th>
                        <th  width="8%">
                            积分来源
                        </th>
                        <th width="12%">
                            名称
                        </th>
                        <th width="8%">
                            积分数量
                        </th>
                        <th width="12%">
                            时间
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%#Eval("usercard")%>
                    </td>
                    <td align="center">
                        <%#Eval("scorename")%>
                    </td>
                    <td align="center">
                        <%#Eval("title")%>
                    </td>
                    <td align="center">
                        <%#Eval("wescore")%>
                    </td>
                    <td align="center">
                        <%#Eval("updateTime")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#Repeater1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="tab-content" style="display: none;">
            <asp:Button ID="UserRegister" runat="server" Text="注册会员"  CssClass="btn" OnClick="UserRegisterSubmit_Click"/>
            
            <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    <div style="display: none;">
        <asp:Button ID="UserBind" runat="server" Text="会员绑定验证" CssClass="btn" OnClick="UserBindSubmit_Click"/>
          <asp:Button ID="UserInfo" runat="server" Text="获取会员信息" CssClass="btn" OnClick="UserInfoSubmit_Click"/>
           <asp:Button ID="UserUpdate" runat="server" Text="更新会员信息" CssClass="btn" OnClick="UserUpdateSubmit_Click"/>
           <asp:Button ID="UserSale" runat="server" Text="消费列表" CssClass="btn" OnClick="UserSaleSubmit_Click"/>
           <asp:Button ID="UserSign" runat="server" Text="会员签到" CssClass="btn" OnClick="UserSignSubmit_Click"/>
           <asp:Button ID="UserScore" runat="server" Text="会员加减积分" Visible="false" CssClass="btn" OnClick="UserScoreSubmit_Click"/>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
