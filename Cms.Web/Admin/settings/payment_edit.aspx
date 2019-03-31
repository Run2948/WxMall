<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment_edit.aspx.cs" Inherits="Admin_settings_payment_edit" ValidateRequest="false" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑支付方式</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../scripts/swfupload/swfupload.handlers.js"></script>
<link rel="stylesheet" type="text/css" href="../kindeditor/themes/default/default.css"/>
<script type="text/javascript" charset="utf-8" src="../kindeditor/kindeditor-min.js"></script>
<script src="../kindeditor/kindeditor.js" type="text/javascript"></script>
<script type="text/javascript" charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //上传单张图片start
        KindEditor.ready(function (K) {
            var editor = K.editor({
                allowFileManager: true
            });
            K('#image1').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        imageUrl: K('#txtImgUrl').val(),
                        clickFn: function (url, title, width, height, border, align) {
                            K('#txtImgUrl').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
        });
        //上传单张图片end
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="payment_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="payment_list.aspx"><span>支付方式</span></a>
  <i class="arrow"></i>
  <span>编辑支付方式</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑分类信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>支付名称</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
    <dl>
    <dt>户名</dt>
    <dd><asp:TextBox ID="p_name" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>支付类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">线上付款</asp:ListItem>
        <asp:ListItem Value="2">线下付款</asp:ListItem>
        </asp:RadioButtonList>
      </div>
      <span class="Validform_checktip">*线上付款自动验证付款状态</span>
    </dd>
  </dl>
  <dl>
    <dt>是否启用</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" />
      </div>
      <span class="Validform_checktip">*不启用则不显示该支付方式</span>
    </dd>
  </dl>
  <dl>
    <dt>排序数字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*数字，越小越向前</span>
    </dd>
  </dl>
  <dl>
    <dt>手续费类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblPoundageType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">百分比</asp:ListItem>
        <asp:ListItem Value="2">固定金额</asp:ListItem>
        </asp:RadioButtonList>
      </div>
      <span class="Validform_checktip">*百分比的计算公式：商品总金额+(商品总金额*百分比)+配送费用=订单总金额</span>
    </dd>
  </dl>
  <dl>
    <dt>支付手续费</dt>
    <dd>
      <asp:TextBox ID="txtPoundageAmount" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*注意：百分比取值范围：0-100，固定金额单位为“元”</span>
    </dd>
  </dl>

  <dl>
    <dt>支付宝账号</dt>
    <dd>
      <asp:TextBox ID="txtAlipaySellerEmail" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*签约支付宝账号或卖家支付宝帐户</span>
    </dd>
  </dl>
  <dl>
    <dt>合作者身份(partner ID)</dt>
    <dd>
      <asp:TextBox ID="txtAlipayPartner" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*合作身份者ID，以2088开头由16位纯数字组成的字符串</span>
    </dd>
  </dl>
  <dl>
    <dt>交易安全校验码(key)</dt>
    <dd>
      <asp:TextBox ID="txtAlipayKey" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*交易安全检验码，由数字和字母组成的32位字符串</span>
    </dd>
  </dl>
 
  <dl>
    <dt>显示图标</dt>
    <dd>
       <input type="text" id="txtImgUrl" value=""  runat="server"/> <input type="button" id="image1" value="浏览..." />
      <div class="upload-box upload-img"></div>
    </dd>
  </dl>
  <dl>
    <dt>描述说明</dt>
    <dd>
      <asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" TextMode="MultiLine" />
      <span class="Validform_checktip">支付方式的描述说明，支持HTML代码</span>
    </dd>
  </dl>
</div>
<!--/内容-->


<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
