<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_Column.aspx.cs" Inherits="Admin_dialog_dialog_Column" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>频道URL配置</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>

    <script src="../js/layout.js" type="text/javascript"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();

    });
</script>
</head>

<body>
<form runat="server">
<!--内容-->
<div class="div-content" style=" margin:0 auto; width:255px">
        <div class="rule-multi-radiosub">
        <asp:RadioButtonList ID="cblItem" runat="server" RepeatLayout="Flow">
        </asp:RadioButtonList>
        </div>
</div>

<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="确认" CssClass="btn" onclick="btnSubmit_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn yellow" onclick="btnCancel_Click" />
    <%--<input name="btnReturn" type="button" value="取消" class="btn yellow" onclick="javascript:history.back(-1);" />--%>
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
