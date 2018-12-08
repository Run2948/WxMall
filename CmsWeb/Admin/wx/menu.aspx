<%@ Page Language="c#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="Admin_wx_menu"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">        var yyuc_jspath = "/@system/";</script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function checkuser() {
            var _username = document.getelementbyid("<%=tburl.ClientID%>").value;

            if (_username != null || _username != "") {

                if (_username.indexof("http://") > -1 || _username.indexof("HTTP://") > -1) {
                    return;
                } else {

                    document.getelementbyid("<%=tburl.ClientID%>").value = "http://" + _username;

                }

            }
        }
    </script>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="js/yyucadapter.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.maincd').click(function () {
                var cdid = $(this).attr('id');
                var sid = $(this).attr('reldata');
                document.getElementById("<%=hdsid.ClientID%>").value = sid;
                document.getElementById("<%=hdfid.ClientID%>").value = cdid;
                var va = $(this).text().replace(/\s/g, "");
                document.getElementById("<%=tbname.ClientID%>").value = va;
                document.getElementById("<%=hdfid2.ClientID%>").value = va;




                var ddl = document.getElementById("<%=ddeven.ClientID%>");


                var ddlvalue = ddl.options[0].value;
                //                var ddlvalues = ddl.options[2].value;
                if (ddlvalue == "0") {
                    //ddl.options.add(new Option("显示二级菜单", 0))
                    document.getElementById("<%=ddeven.ClientID%>").options[0].selected = true;
                }


                var str = new Array();
                var result = Admin_wx_menu.setmenu(cdid).value;
                document.getElementById("PlaceHolder1").style.display = "";
                document.getElementById("PlaceHolder2").style.display = "none";
                document.getElementById("PlaceHolder3").style.display = "none";
                str = result.split(",");
                document.getElementById("<%=tbmenu1.ClientID%>").value = "";
                document.getElementById("<%=tbmenu2.ClientID%>").value = "";
                document.getElementById("<%=tbmenu3.ClientID%>").value = "";
                document.getElementById("<%=tbmenu4.ClientID%>").value = "";
                document.getElementById("<%=tbmenu5.ClientID%>").value = "";
                for (var i = 0; i < str.length; i++) {
                    if (i == 0)
                        document.getElementById("<%=tbmenu1.ClientID%>").value = str[i];
                    if (i == 1)
                        document.getElementById("<%=tbmenu2.ClientID%>").value = str[i];
                    if (i == 2)
                        document.getElementById("<%=tbmenu3.ClientID%>").value = str[i];
                    if (i == 3)
                        document.getElementById("<%=tbmenu4.ClientID%>").value = str[i];
                    if (i == 4)
                        document.getElementById("<%=tbmenu5.ClientID%>").value = str[i];

                }
                //            suitdata();
                //            window.curcd = this;
                //            window.curctyp = '1';
                //            backdata();
            });

            $('.zizicd').click(function () {
                var sid = $(this).attr('reldata');
                document.getElementById("<%=hdsid.ClientID%>").value = sid;

                var va = $(this).text().replace(/\s/g, "");
                document.getElementById("<%=tbname.ClientID%>").value = va;
                document.getElementById("<%=hdfid.ClientID%>").value = va;

                document.getElementById("PlaceHolder1").style.display = "none";
                var ddl = document.getElementById("<%=ddeven.ClientID%>");
                var ddlvalue = ddl.options[0].value;
                if (ddlvalue == "0") {
                    //ddl.options.remove(0);
                }
                var type = Admin_wx_menu.setmenutype(va).value;
                if (type != '') {

                    if (type == "click") {
                        var keys = Admin_wx_menu.setmenuvalue(va, 0).value;
                        var val = Admin_wx_menu.setmenuvalue(va, 2).value;
                        document.getElementById("<%=tbkey.ClientID%>").value = keys;
                        document.getElementById("<%=tinfo.ClientID%>").value = val;

                        document.getElementById("ddeven").value = type;
                        document.getElementById("PlaceHolder2").style.display = "";
                        document.getElementById("PlaceHolder3").style.display = "none";
                    } else {
                        var val = Admin_wx_menu.setmenuvalue(va, 1).value;
                        document.getElementById("<%=tburl.ClientID%>").value = val;
                        document.getElementById("ddeven").value = "url";
                        document.getElementById("PlaceHolder2").style.display = "none";
                        document.getElementById("PlaceHolder3").style.display = "";
                    }

                }

                //            suitdata();
                //            window.curcd = this;
                //            window.curctyp = '2';
                //            backdata();
            });
            $('#answertype').change(function () {
                $('.szcjbt').hide();
                $('#' + $(this).val()).show();
            });





            $('.maincd').eq(0).trigger('click');
            $('.zizicd').eq(0).trigger('click');

            $('.zizicd,.maincd').click(function () {
                $('.zizicd,.maincd').unmask();
                $(this).mask();
            });
        });

        function change(n) {
            var types = n.value;
            var va = document.getElementById("<%=hdfid.ClientID%>").value;
            var type = Admin_wx_menu.setmenutype(va).value;
            if (type != '') {

                if (types == "click") {
                    var keys = Admin_wx_menu.setmenuvalue(va, 0).value;
                    var val = Admin_wx_menu.setmenuvalue(va, 2).value;
                    document.getElementById("<%=tbkey.ClientID%>").value = keys;
                    document.getElementById("<%=tinfo.ClientID%>").value = val;


                    document.getElementById("PlaceHolder2").style.display = "";
                    document.getElementById("PlaceHolder3").style.display = "none";
                } else {
                    var val = Admin_wx_menu.setmenuvalue(va, 1).value;
                    document.getElementById("<%=tburl.ClientID%>").value = val;
                    document.getElementById("ddeven").value = "url";
                    document.getElementById("PlaceHolder2").style.display = "none";
                    document.getElementById("PlaceHolder3").style.display = "";
                }

            } else {
                var vals = document.getElementById("<%=hdfid2.ClientID%>").value;
                if (types == "0") {

                    document.getElementById("PlaceHolder1").style.display = ""
                    document.getElementById("PlaceHolder2").style.display = "none";
                    document.getElementById("PlaceHolder3").style.display = "none";
                }
                if (types == "click") {
                    var keys = Admin_wx_menu.setmenuvalue(vals, 0).value;
                    var val = Admin_wx_menu.setmenuvalue(vals, 2).value;
                    document.getElementById("<%=tbkey.ClientID%>").value = keys;
                    document.getElementById("<%=tinfo.ClientID%>").value = val;
                    document.getElementById("PlaceHolder1").style.display = "none"
                    document.getElementById("PlaceHolder2").style.display = "";
                    document.getElementById("PlaceHolder3").style.display = "none";
                }
                if (types == "url") {
                    var val = Admin_wx_menu.setmenuvalue(vals, 1).value;
                    document.getElementById("<%=tburl.ClientID%>").value = val;
                    document.getElementById("ddeven").value = "url";
                    document.getElementById("PlaceHolder1").style.display = "none"
                    document.getElementById("PlaceHolder2").style.display = "none";
                    document.getElementById("PlaceHolder3").style.display = "";
                }
            }
        }
   

   

 

    

  
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="location">
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>微信管理</span>
    </div>
    <div class="line10">
    </div>
    <div class="content-tab-wrap">
        <div id="floathead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                   
                    <li><a href="javascript:;" onclick="tabs(this);">菜单设置</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <div style="margin: 0px" id="top" class="alert alert-info">
            1.使用本模块，必须在微信公众平台<strong>申请</strong>自定义菜单使用的<strong>appid和appsecret</strong>，然后在【授权设置】中设置。<br />
            2.最多创建<span class="red bold">3 个一级菜单</span>，每个一级菜单下最多可以创建 <span class="red bold">5 个二级菜单</span>，菜单<span
                class="red bold">最多支持两层</span>。
        </div>
        <div>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <div style="background-image: url(images/3customlt.png); position: relative; width: 344px;
                                height: 623px">
                                <div style="position: absolute; width: 82px; bottom: 170px; left: 46px" zcdrel="maincd1">
                                    <asp:Repeater ID="rmenu1" runat="server">
                                        <ItemTemplate>
                                            <div class="zizicd" rel="zizicd<%#Container.ItemIndex+1 %>" reldata="<%#Eval("id")%>">
                                                <%#Eval("name")%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div style="position: absolute; width: 83px; bottom: 170px; left: 131px" zcdrel="maincd2">
                                    <asp:Repeater ID="rmenu2" runat="server">
                                        <ItemTemplate>
                                            <div class="zizicd" rel="zizicd<%#Container.ItemIndex+1 %>" reldata="<%#Eval("id")%>">
                                                <%#Eval("name")%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div style="position: absolute; width: 83px; bottom: 170px; left: 216px" zcdrel="maincd3">
                                    <asp:Repeater ID="rmenu3" runat="server">
                                        <ItemTemplate>
                                            <div class="zizicd" rel="zizicd<%#Container.ItemIndex+1 %>" reldata="<%#Eval("id")%>">
                                                <%#Eval("name")%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div style="position: absolute; bottom: 122px; left: 43px">
                                    <table style="border-bottom-style: none; border-right-style: none; border-top-style: none;
                                        border-left-style: none" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <asp:Repeater ID="rmenu" runat="server">
                                                    <ItemTemplate>
                                                        <td>
                                                            <div style="text-align: center; line-height: 45px; width: 85px; height: 45px" id="maincd<%#Container.ItemIndex+1 %>"
                                                                class="maincd" reldata="<%#Eval("id")%>">
                                                                <%#Eval("name")%></div>
                                                        </td>
                                                        <td>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td valign="top">
                            <br />
                            <div style="position: relative; width: 100%">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-big btn-primary" Text="发布菜单"
                                    OnClick="btnSubmit_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btndz" CssClass="btn btn-big btn-primary" runat="server" Text="停用菜单"
                                    OnClick="btndz_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnsaves" runat="server" CssClass="btn btn-big btn-primary" Text="保存菜单数据"
                                    OnClick="btnsaves_Click" /><br />
                            </div>
                            <div>
                                <br />
                                <div style="padding-bottom: 0px; line-height: 16px" id="top" class="alert alert-info">
                                    菜单名称：<asp:TextBox ID="tbname" runat="server" MaxLength="4"></asp:TextBox>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="answertype">
                                        菜单点击事件:</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddeven" runat="server" onchange="change(this)">
                                            <asp:ListItem Value="0">显示二级菜单</asp:ListItem>
                                            <asp:ListItem Value="click">点击事件</asp:ListItem>
                                            <asp:ListItem Value="url">链接地址</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <!-- 微投票 -->
                            <div>
                                <div id="top" class="alert alert-info">
                                    至少填写一项子菜单
                                </div>
                                <asp:Panel ID="PlaceHolder1" runat="server">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                菜单一：<asp:TextBox ID="tbmenu1" runat="server" MaxLength="16"></asp:TextBox>
                                                * 最好七个汉字
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                菜单二：<asp:TextBox ID="tbmenu2" runat="server" MaxLength="16"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                菜单三：<asp:TextBox ID="tbmenu3" runat="server" MaxLength="16"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                菜单四：<asp:TextBox ID="tbmenu4" runat="server" MaxLength="16"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                菜单五：<asp:TextBox ID="tbmenu5" runat="server" MaxLength="16"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="PlaceHolder2" runat="server">
                                    key：
                                    <asp:TextBox ID="tbkey" runat="server" MaxLength="20"></asp:TextBox><br />
                                    信息：<textarea cols="2" rows="5" id="tinfo" runat="server" style="width: 300px"></textarea>
                                    <br />
                                </asp:Panel>
                                <asp:Panel ID="PlaceHolder3" runat="server">
                                    要链接到的url地址：<asp:TextBox ID="tburl" runat="server" MaxLength="150" onblur="checkuser()"
                                        Width="229"></asp:TextBox>
                                </asp:Panel>
                            </div>
                            <asp:HiddenField ID="hdfid" runat="server" />
                            <asp:HiddenField ID="hdfid2" runat="server" />
                            <asp:HiddenField ID="hdsid" runat="server" />
                            <asp:HiddenField ID="hdid" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
