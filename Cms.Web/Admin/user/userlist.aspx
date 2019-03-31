<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userlist.aspx.cs" Inherits="Admin_user_userlist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>用户管理</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../scripts/datepicker/WdatePicker.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //发送短信
    function PostSMS(mobiles) {
        if (mobiles == "") {
            $.dialog.alert('对不起，手机号码不能为空！');
            return false;
        }
        var dialog = $.dialog({
            title: '发送手机短信',
            content: '<textarea id="txtSmsContent" name="txtSmsContent" rows="2" cols="20" class="input"></textarea>',
            min: false,
            max: false,
            lock: true,
            ok: function () {
                var remark = $("#txtSmsContent", parent.document).val();
                if (remark == "") {
                    $.dialog.alert('对不起，请输入手机短信内容！', function () { }, dialog);
                    return false;
                }
                var postData = { "mobiles": mobiles, "content": remark };
                //发送AJAX请求
                $.ajax({
                    type: "post",
                    url: "../../tools/admin_ajax.ashx?action=sms_message_post",
                    data: postData,
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $.dialog.alert('尝试发送失败，错误信息：' + errorThrown, function () { }, dialog);
                    },
                    success: function (data, textStatus) {
                        if (data.status == 1) {
                            dialog.close();
                            $.dialog.tips(data.msg, 2, '32X32/succ.png', function () { location.reload(); }); //刷新页面
                        } else {
                            $.dialog.alert('错误提示：' + data.msg, function () { }, dialog);
                        }
                    }
                });
                return false;
            },
            cancel: true
        });
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>会员管理</span>
  <i class="arrow"></i>
  <span>用户列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
       <%-- <li><a class="add" href="user_edit.aspx?action=add"><i></i><span>新增</span></a></li>--%>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
      
    </div>
    <div class="r-list">
	
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" placeholder="请输入手机号码！" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable" >
  <tr>
    <th width="4%">选择</th>
    <th align="left" width="12%">openId</th> 
    <th align="left" width="15%" colspan="2">姓名</th>
    <th align="left" width="5%">手机号码</th>
    <th align="left" width="12%">会员地址</th>
    <th width="12%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
    <asp:CheckBox ID="Check_Select" CssClass="checkall" runat="server" />
      <asp:HiddenField ID="Fielddocid" Value='<%#Eval("id")%>' runat="server" />
     
    </td>
    <td><%#Eval("openid")%></td>
    <td width="64">
    <a href="useredit.aspx?action=edit&id=<%#Eval("id")%>">
        <%#Eval("headimgurl").ToString() != "" ? "<img width=\"64\" height=\"64\" src=\"" + Eval("headimgurl") + "\" />" : "<b class=\"user-avatar\"></b>"%>
      </a>
    </td>
    <td>
      <div class="user-box">
        <h4><b><%#Eval("userName")%></b></h4>
          
        <i>注册时间：<%#string.Format("{0:g}", Eval("updatetime"))%></i></div>
    </td>
    <td><%#Eval("telphone")%></td>
    <td><%#Eval("useraddress")%></td>
   <td align="center"><a href="useredit.aspx?action=edit&id=<%#Eval("id")%>">查看</a>
  <%-- <a href="userlist.aspx?action=UpdateUser&id=<%#Eval("id")%>">
                        绑定会员卡</a>--%>
                       <%# Eval("isSign").ToString() == "0" ? "<a href='useredit.aspx?action=edit&id=" + Eval("id") + "'>申请幸运大使</a>" : ""%>
   </td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div id="PageContent" runat="server" class="default">
  <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" FirstPageText="首页"
                        LastPageText="尾页" PrevPageText="上一页" NextPageText="下一页" NumericButtonTextFormatString="-{0}-"
                        Width="100%" ShowCustomInfoSection="Left"  ShowBoxThreshold="2" PageSize="5" InputBoxClass="text2"
                        TextAfterInputBox="" OnPageChanging="AspNetPager1_PageChanging" CssClass="paginator"
                        CurrentPageButtonClass="cpb" CustomInfoHTML="<a href='javascript:void(0);'>共%RecordCount%条</a> <a href='javascript:void(0);'>每页%PageSize%条</a> <a href='javascript:void(0);'>%CurrentPageIndex%/%PageCount%页</a> " NumericButtonCount="5" />
  </div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
