<%@ Page Language="C#" AutoEventWireup="true" CodeFile="typeedit.aspx.cs" Inherits="Admin_settings_typeedit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑类别</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" charset="utf-8" src="../kindeditor/kindeditor-min.js"></script>
<script src="../kindeditor/kindeditor.js" type="text/javascript"></script>
<script type="text/javascript" charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();

        $("#btnVarAdd").click(function () {
            varHtml = createVarHtml();
            $("#tr_box").append(varHtml);

        });


        KindEditor.ready(function (K) {
            window.editor = K.create('#txtContent');
        });
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

    function change2cn(en, cninput) {
        cninput.value = getSpell(en, "");
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
  <a href="category_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="category_list.aspx"><span>内容类别</span></a>
  <i class="arrow"></i>
  <span>编辑分类</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">扩展选项</a></li>
        
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
<%--<dl>
    <dt>所属栏目类别</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlchannel_id" runat="server"></asp:DropDownList>
      </div>
    </dd>
  </dl>--%>
  <dl>
    <dt>所属父类别</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="parentId" runat="server"></asp:DropDownList>
      </div>
    </dd>
  </dl>
  
  <dl>
    <dt>类别名称</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" onBlur="change2cn(this.value, this.form.txtCallIndex)" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*类别中文名称，100字符内</span></dd>
  </dl>
  <dl>
    <dt>排序数字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*数字，越小越向前</span>
    </dd>
  </dl>
   <dl>
    <dt>显示状态</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="isHidden" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
        <asp:ListItem Value="1">待审核</asp:ListItem>
        <asp:ListItem Value="2">不显示</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
<%--  <dl>
    <dt>推荐类型</dt>
    <dd>
      <div class="rule-multi-checkbox">
        <asp:CheckBoxList ID="cblItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1">置顶</asp:ListItem>
        <asp:ListItem Value="1">首页推荐</asp:ListItem>
        <asp:ListItem Value="1">热门活动</asp:ListItem>
        <asp:ListItem Value="1">评论</asp:ListItem>
        <asp:ListItem Value="1">幻灯片</asp:ListItem>
        </asp:CheckBoxList>
      </div>
    </dd>
  </dl>--%>
  <dl>
    <dt>调用别名</dt>
    <dd>
      <asp:TextBox ID="txtCallIndex" runat="server" CssClass="input normal" datatype="/^\s*$|^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的别名" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">类别的调用别名，只允许字母、数字、下划线</span>
    </dd>
  </dl>
  
</div>

<div class="tab-content" style="display:none">
  <dl>
    <dt>URL链接</dt>
    <dd>
      <asp:TextBox ID="txtLinkUrl" runat="server" maxlength="255"  CssClass="input normal" />
      <span class="Validform_checktip">填写后直接跳转到该网址</span>
    </dd>
  </dl>
  <dl>
    <dt>Logo图标</dt>
    <dd>
    <input type="text" id="txtImgUrl" value=""  runat="server"/> <input type="button" id="image1" value="选择图片" />
     
    </dd>
  </dl>
  <dl>
    <dt>类别介绍</dt>
    <dd>
       <textarea id="txtContent" name="content" style="width:800px;height:200px;visibility:hidden;" class="editor" runat="server"></textarea>
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