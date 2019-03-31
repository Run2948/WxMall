<%@ Page Language="C#" AutoEventWireup="true" CodeFile="siteconfig.aspx.cs" Inherits="Admin_siteconfig_siteconfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>编辑用户</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script src="../Scripts/zDialog/zDialog.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/kindeditor-min.js"></script>
    <script src="../kindeditor/kindeditor.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/ajax/sys.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/pinyin.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
    KindEditor.ready(function (K) {
        window.editor = K.create('#content');
    });
    //上传单张图片start
    KindEditor.ready(function (K) {
        var editor = K.editor({
            allowFileManager: true
        });
        K('#image1').click(function () {
            editor.loadPlugin('image', function () {
                editor.plugin.imageDialog({
                    imageUrl: K('#txtlogo').val(),
                    clickFn: function (url, title, width, height, border, align) {
                        K('#txtlogo').val(url);
                        editor.hideDialog();
                    }
                });
            });
        });
    });
    //上传单张图片end
    //上传单张图片start
    KindEditor.ready(function (K) {
        var editor = K.editor({
            allowFileManager: true
        });
        K('#image2').click(function () {
            editor.loadPlugin('image', function () {
                editor.plugin.imageDialog({
                    imageUrl: K('#txtmLogo').val(),
                    clickFn: function (url, title, width, height, border, align) {
                        K('#txtmLogo').val(url);
                        editor.hideDialog();
                    }
                });
            });
        });
    });
    //上传单张图片end
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="siteconfig.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>站点信息</span>
  <i class="arrow"></i>
  <span>编辑站点信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本资料</a></li>
      
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>网站名称</dt>
    <dd><asp:TextBox ID="webName" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " ></asp:TextBox> </dd>
  </dl> 
  <dl>
    <dt>网址</dt>
    <dd><asp:TextBox ID="weburl" runat="server" CssClass="input normal"  datatype="*0-100"  sucmsg=" "></asp:TextBox> </dd>
  </dl>
  <dl>
    <dt>网站标题</dt>
    <dd><asp:TextBox ID="title" runat="server" CssClass="input normal"  datatype="*"  sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>网站关键词</dt>
    <dd><asp:TextBox ID="keyword" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " ></asp:TextBox> </dd>
  </dl> 
  <dl>
    <dt>网站描述</dt>
    <dd>
      <asp:TextBox ID="Description" runat="server" CssClass="input normal" datatype="*0-1000" sucmsg=" " ></asp:TextBox>
    </dd>
  </dl> 
  <dl>
    <dt>附件上传目录</dt>
    <dd><asp:TextBox ID="upload" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>网站版权</dt>
    <dd>
  <asp:TextBox ID="Copyright" runat="server" CssClass="input normal" datatype="*0-1000" sucmsg=" "></asp:TextBox>
    </dd>
  </dl>
  <dl>
    <dt>网站备案号</dt>
    <dd><asp:TextBox ID="IcpRecord" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>地址</dt>
    <dd><asp:TextBox ID="adress" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
        <dt>logo</dt>
        <dd>
            <p>
                <input type="text" id="txtlogo" value="" runat="server" />
                <input type="button" id="image1" value="选择图片" /></p>
        </dd>
    </dl>
    <dl>
        <dt>手机logo</dt>
        <dd>
            <p>
                <input type="text" id="txtmLogo" value="" runat="server" />
                <input type="button" id="image2" value="选择图片" /></p>
        </dd>
    </dl>
     <dl>
    <dt>400</dt>
    <dd><asp:TextBox ID="txttel" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
   <dl>
    <dt>QQ</dt>
    <dd><asp:TextBox ID="txtqq" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>电话</dt>
    <dd><asp:TextBox ID="telphone" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>手机</dt>
    <dd><asp:TextBox ID="mobiephone" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>传真</dt>
    <dd><asp:TextBox ID="fax" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>邮箱</dt>
    <dd><asp:TextBox ID="email" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>联系人</dt>
    <dd><asp:TextBox ID="contactperson" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>ERP接口地址</dt>
    <dd><asp:TextBox ID="TextBox1" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox></dd>
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
