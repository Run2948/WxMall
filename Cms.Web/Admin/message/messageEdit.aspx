<%@ Page Language="C#" AutoEventWireup="true" CodeFile="messageEdit.aspx.cs" Inherits="Admin_message_messageEdit" %>

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
  <a href="messagelist.aspx" class="back"><i></i><span>返回列表页</span></a>
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
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
 
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>联系人</dt>
    <dd>
      <asp:TextBox ID="Name" runat="server" CssClass="input normal" datatype="*0-100" 
            sucmsg=" " Enabled="False" />
    </dd>
  </dl>
  <dl style=" display:none;">
    <dt>单位名称</dt>
    <dd>
       <asp:TextBox ID="UnitName" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Enabled="False"/>
    </dd>
  </dl>
  <dl>
    <dt>电话号码</dt>
    <dd>
      <asp:TextBox ID="PhoneNum" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Enabled="False"/>
    </dd>
  </dl>
  <dl>
    <dt>手机号码</dt>
    <dd>
      <asp:TextBox ID="telNum" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Enabled="False"/>
    </dd>
  </dl>
  <dl ID="div_sub_title" runat="server" >
    <dt>项目</dt>
    <dd>
      <asp:TextBox ID="email" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Enabled="False"/>
    </dd>
  </dl>
  <dl style=" display:none;">
    <dt>留言标题</dt>
    <dd>
      <asp:TextBox ID="title" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Enabled="False"/>
    </dd>
  </dl>
  <dl>
    <dt>留言内容</dt>
    <dd>
       <asp:TextBox ID="strcontent" runat="server" CssClass="input normal" 
            datatype="*0-10000" sucmsg=" " Enabled="False" Height="112px" Width="314px" 
            TextMode="MultiLine"/>
    </dd>
  </dl>
  <dl style=" display:none;">
    <dt>用户账号</dt>
    <dd>
      <asp:TextBox ID="userName" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Enabled="False"/>
    </dd>
  </dl>
  <dl>
    <dt>留言时间</dt>
    <dd>
       <asp:TextBox ID="updateTime" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " Enabled="False"/>
    </dd>
  </dl>
  <dl style=" display:none;" ID="div_albums_container" runat="server" >
    <dt>回复内容</dt>
    <dd>
     <asp:TextBox ID="replay" runat="server" CssClass="input normal" datatype="*0-10000" sucmsg=" " Height="112px" Width="314px" TextMode="MultiLine"/>
    </dd>
  </dl>
  <dl style=" display:none;" ID="div_attach_container" runat="server" >
    <dt>回复时间</dt>
    <dd>
     <asp:TextBox ID="re_updateTime" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
    </dd>
  </dl>
</div>



<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list" >
    <span style=" display:none;"><asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" /></span>
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
