<%@ Page Language="C#" AutoEventWireup="true" CodeFile="model_edit.aspx.cs" Inherits="Admin_settings_model_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑信息</title>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/kindeditor-min.js"></script>
    <script src="../kindeditor/kindeditor.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <%--<script type="text/javascript" src="../js/pinyin.js"></script>--%>
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
   
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="model_list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="model_list.aspx">
                <span>模型</span></a> <i class="arrow"></i><span>编辑信息</span>
    </div>
    <div class="line10">
    </div>
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
            <dt>类别名称</dt>
            <dd>
                <asp:TextBox ID="txtTitle" runat="server" 
                    CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*类别中文名称，100字符内</span></dd>
        </dl>
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
