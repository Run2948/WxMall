<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productedit.aspx.cs" Inherits="Admin_order_orderedit" ValidateRequest="false" EnableEventValidation="false"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>查看订单信息</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../scripts/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" charset="utf-8" src="../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../editor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });

    //上传单张图片start
    KindEditor.ready(function (K) {
        var editor = K.editor({
            allowFileManager: true
        });
        K('#image1').click(function () {
            editor.loadPlugin('image', function () {
                editor.plugin.imageDialog({
                    imageUrl: K('#photoUrl').val(),
                    clickFn: function (url, title, width, height, border, align) {
                        K('#photoUrl').val(url);
                        editor.hideDialog();
                    }
                });
            });
        });
    });

    //批量上传文件start
    KindEditor.ready(function (K) {
        var editor = K.editor({
            allowFileManager: true
        });
        K('#insertfile').click(function () {
            editor.loadPlugin('insertfile', function () {
                editor.plugin.fileDialog({
                    fileUrl: K('#Attachment').val(),
                    clickFn: function (url, title) {
                        K('#Attachment').val(url);
                        editor.hideDialog();
                    }
                });
            });
        });
    });
    //批量上传文件end   
</script>
<script type="text/javascript">
    $(function () {
        //初始化编辑器
        var editor = KindEditor.create('.editor', {
            width: '800px',
            height: '200px',
            resizeType: 1,
            uploadJson: '../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            fileManagerJson: '../tools/upload_ajax.ashx?action=ManagerFile',
            allowFileManager: true
        });
        var editorMini = KindEditor.create('.editor-mini', {
            width: '800px',
            height: '200px',
            resizeType: 1,
            uploadJson: '../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            items: [
				'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });
        //初始化上传控件
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "../tools/upload_ajax.ashx", flashurl: "../scripts/swfupload/swfupload.swf" });
        });
        $(".upload-album").each(function () {
            $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../tools/upload_ajax.ashx", flashurl: "../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
        });
        $(".attach-btn").click(function () {
            showAttachDialog();
        });
        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });

    })

    //创建附件窗口
    function showAttachDialog(obj) {
        var objNum = arguments.length;
        var attachDialog = $.dialog({
            id: 'attachDialogId',
            lock: true,
            max: false,
            min: false,
            title: "上传附件",
            content: 'url:dialog/dialog_attach.aspx',
            width: 500,
            height: 180
        });
        //如果是修改状态，将对象传进去
        if (objNum == 1) {
            attachDialog.data = obj;
        }
    }

    function setimage() {
        document.getElementById("photoUrl").value = "/img/noPic.jpg";
    }

    function xzimg(url) {

        window.open("../Download.aspx?url=" + encodeURIComponent(url)); ////////
        map.panTo(new BMap.Point(116.31557 + i * 0.029078, 39.93381));
    }
    </script>
   
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="#"><span>产品信息</span></a>
  <i class="arrow"></i>
</div>
<div class="line10"></div>
<!--/导航栏-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">产品详细信息</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">产品积分信息</a></li>
      </ul>
    </div>
  </div>
</div>
<!--内容-->


<div class="tab-content">
   <dl>
   <dt>产品类型：</dt>
   <dd>
              <div class="rule-single-select">
                    <asp:DropDownList ID="ddpid" runat="server" datatype="*" sucmsg=" ">
                    </asp:DropDownList>
              </div>
     </dd>
   </dl>

   <dl>
   <dt>产品材质：</dt>
   <dd>
              <div class="rule-single-select">
                    <asp:DropDownList ID="ddcz" runat="server" datatype="*" sucmsg=" ">
                    </asp:DropDownList>
                </div>
    
     </dd>
   </dl>
   <dl>
   <dt>产品名称：</dt>
   <dd><asp:TextBox ID="tbtilte" runat="server" CssClass="input normal" datatype="*2-100"
                    sucmsg=" "   /> &nbsp;&nbsp;<span style=" color:Red"></span></dd>
   </dl>
   <dl>
   <dt>上传图片:</dt>
   <dd><asp:TextBox ID="photoUrl" runat="server" CssClass="input normal" />
                <input type="button" id="image1" value="选择图片" />&nbsp;&nbsp; <span style=" color:Red"></span></dd>
   </dl>
    
    <dl>
    <dt>优惠价：</dt>
    <dd><asp:TextBox ID="tbPrice" runat="server" CssClass="input normal" datatype="pirce"
                    sucmsg=" " Text="0"  /></dd>
    </dl>
    <dl>
    <dt>市场价：</dt>
    <dd><asp:TextBox ID="tbmarketpice" runat="server" CssClass="input normal" datatype="pirce"
                    sucmsg=" " Text="0" /></dd>
    </dl>
    <dl>
    <dt>赠送积分：</dt>
    <dd><asp:TextBox ID="tbintegral" runat="server" CssClass="input normal" datatype="n"
                    sucmsg=" " Text="0" /></dd>
    </dl>
    <dl>
    <dt>库存：</dt>
    <dd><asp:TextBox ID="tbstock" runat="server" CssClass="input normal" datatype="n"
                    sucmsg=" " Text="0" /></dd>
    </dl>
   <dl>
   <dt>产品详情:</dt>
   <dd> <textarea id="tbinfo" cols="20" rows="2" name="content" class="editor" runat="server"></textarea><span style=" color:Red"></span></dd>
   </dl>
   
  </div>
  <div class="tab-content" style="display: none">
     <dl>
            <dt>是否积分产品</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="isjf" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">是</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">否</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </dd>
        </dl>
  <dl>
    <dt>购买积分：</dt>
    <dd><asp:TextBox ID="tbProperty" runat="server" CssClass="input normal" datatype="n"
                    sucmsg=" " Text="0"  /></dd>
    </dl>
  </div>
  <div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/内容-->


<!--工具栏-->

<!--/工具栏-->
</form>
</body>
</html>