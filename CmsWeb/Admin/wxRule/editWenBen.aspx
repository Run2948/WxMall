<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editWenBen.aspx.cs" Inherits="Admin_wxRule_editWenBen" %>
<%@ Import Namespace="Cms.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑文本回复</title>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

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

        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="wenBenList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <i class="arrow"></i>
            <span>编辑文本回复</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑文本回复</a></li>
                    </ul>
                </div>
            </div>
        </div>
        
        <div class="tab-content">

            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:TextBox ID="txtreqKeywords" runat="server" CssClass="input normal " datatype="*1-1000" sucmsg=" " nullmsg="请填写关键词，多个关键词请用|格开：例如: 美丽|漂亮|好看"></asp:TextBox>
                    <span class="Validform_checktip">*多个关键词请用|格开：例如: 美丽|漂亮|好看</span></dd>
            </dl>
            <dl>
                <dt>关键词类型</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblisLikeSearch" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">完全匹配，用户输入的和此关键词一样才会触发!</asp:ListItem>
                            <asp:ListItem Value="1">包含匹配 (只要用户输入的文字包含本关键词就触发!)</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                </dd>
            </dl>
            <dl>
                <dt>内容或简介</dt>
                <dd>
                    <asp:TextBox ID="txtrContent" runat="server" CssClass="mytextarea" TextMode="MultiLine" datatype="*1-1000" sucmsg=" " nullmsg="内容或简介"></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                 <a href="wenBenList.aspx"  > <span class="btn yellow">返回上一页</span></a>
                
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
