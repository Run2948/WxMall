<%@ Page Language="C#" AutoEventWireup="true" CodeFile="smsEdit.aspx.cs" Inherits="Admin_sms_smsEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>编辑信息</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../kindeditor/kindeditor-min.js"></script>
<script src="../kindeditor/kindeditor.js" type="text/javascript"></script>
<script type="text/javascript" charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });

    KindEditor.ready(function (K) {
        window.editor = K.create('#intro');
    });
    KindEditor.ready(function (K) {
        window.editor = K.create('#content');
    });
    KindEditor.ready(function (K) {
        window.editor = K.create('#tips');
    });
    KindEditor.ready(function (K) {
        window.editor = K.create('#Packagecontent');
    });
    KindEditor.ready(function (K) {
        window.editor = K.create('#textParam1');
    });
    KindEditor.ready(function (K) {
        window.editor = K.create('#integracontent');
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
    //上传单张图片end
    //批量上传图片start
    KindEditor.ready(function (K) {
        var editor = K.editor({
            allowFileManager: true
        });
        K('#J_selectImage').click(function () {
            editor.loadPlugin('multiimage', function () {
                editor.plugin.multiImageDialog({
                    clickFn: function (urlList) {
                        var div = K('#J_imageView');
                        //                    div.html('');
                        K.each(urlList, function (i, data) {
                            //div.append('<img src="' + data.url + '" width="120" height="120" id="' + i + '"/>');
                            div.append("<li ><img src=" + data.url + "  width='120' height='120'/><br/><span><input id='Checkbox" + i + "' name='imglist' type='checkbox' value=" + data.url + " checked='checked' /><input type='button' value='删除' onclick='del(this,'" + data.url + "');'/></span></li>");

                        });
                        editor.hideDialog();
                    }
                });
            });
        });
    });
    //批量上传图片end

    //批量上传文件start
    KindEditor.ready(function (K) {
        var editor = K.editor({
            allowFileManager: true
        });
        K('#insertfile').click(function () {
            editor.loadPlugin('insertfile', function () {
                editor.plugin.fileDialog({
                    fileUrl: K('#url').val(),
                    clickFn: function (url, title) {
                        K('#url').val(url);
                        editor.hideDialog();
                    }
                });
            });
        });
    });
    //批量上传文件end   

    KindEditor.ready(function (K) {
        var editor = K.editor({
            fileManagerJson: '/editor/asp.net/upload_json.ashx'
        });
        K('#filemanager').click(function () {
            editor.loadPlugin('filemanager', function () {
                editor.plugin.filemanagerDialog({
                    viewType: 'VIEW',
                    dirName: 'image',
                    clickFn: function (url, title) {
                        K('#url').val(url);
                        editor.hideDialog();
                    }
                });
            });
        });
    });
    //删除批量图片
    function del(obj, txt) {
        var s = document.getElementById('J_imageView');
        var result = Admin_article_articleEdit.delmultiimage(txt).value;
        $(obj).parent().parent().remove();

    }
    function add(n, txt) {
        var s = document.getElementById('s');
        var t = s.childNodes.length;
        var li = document.createElement("li");
        li.innerHTML = txt;
        for (var i = 0; i < t; i++) {
            if (n == -1) {
                s.appendChild(li);
            }
            else if (i == n - 1) {
                s.insertBefore(li, s.childNodes[i]);
            }
        }
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="smslist.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
 
  <i class="arrow"></i>
  <span>编辑信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl runat="server" visible="false">
    <dt>姓名</dt>
    <dd>
      <asp:TextBox ID="Title" runat="server" CssClass="input normal" datatype="*11-12" sucmsg=" " />
      <span class="Validform_checktip">*姓名最多10个字符</span>
      
    </dd>
  </dl>
  <dl>
    <dt>手机号码</dt>
    <dd>
      <asp:TextBox ID="englishtitle" runat="server" CssClass="input normal" datatype="*11-11" sucmsg=" " />
      <asp:Label ID="div_sub_title_tip" runat="server" CssClass="Validform_checktip" />
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="englishtitle"
                        ErrorMessage="请输入有效手机号码！" ValidationExpression="^(13|15|18)+[0-9]{9}$" 
                        ForeColor="#FF0066" ValidationGroup="submit" SetFocusOnError="True"></asp:RegularExpressionValidator> 
    </dd>
  </dl>
  <dl>
    <dt>发送内容</dt>
    <dd>
      <asp:TextBox ID="seoDescription" runat="server" CssClass="input" Height="200px" TextMode="MultiLine" datatype="*1-255" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">255个字符以内</span>
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