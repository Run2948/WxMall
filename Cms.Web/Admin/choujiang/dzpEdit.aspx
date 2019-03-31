<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dzpEdit.aspx.cs" Inherits="Admin_choujiang_dzpEdit" %>
<%@ Import Namespace="Cms.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑大转盘活动</title>
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


        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="dzplist.aspx" class="back"><i></i><span>返回大转盘活动列表</span></a>
            <i class="arrow"></i>
            <span>编辑大转盘活动</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑大转盘活动开始内容</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">活动结束内容</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">奖项设置</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtKW" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="大转盘" />
                    <span class="Validform_checktip">*只能写一个关键词，用户输入此关键词将会触发此活动。</span>
                </dd>
            </dl>
            <dl>
                <dt>开始活动的图片</dt>
                <dd>
                    <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/shop/dzp/images/start.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>
                    
                </dd>
            </dl>


            <dl>
                <dt>活动名称</dt>
                <dd>
                    <asp:TextBox ID="txtactName" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="大转盘活动开始了" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>
            <dl>
                <dt>兑奖信息</dt>
                <dd>
                    <asp:TextBox ID="txtcontractInfo" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" " Text="兑奖请联系我们，电话138xxxxxxx1" />
                    <span class="Validform_checktip">*请不要多于100字! 这个设定但用户输入兑奖时候的显示信息!</span>
                </dd>
            </dl>

            <dl>
                <dt>简介</dt>
                <dd>
                    <textarea name="txtbrief" rows="2" cols="20" id="txtbrief" class="input" runat="server" datatype="*1-300" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>活动时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtbeginDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>开始时间</i>
                    </div>
                    到
                  
                    <div class="input-date">
                        <asp:TextBox ID="txtendDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>结束时间</i>
                    </div>
                    <span class="Validform_checktip">*</span>

                </dd>
            </dl>

            <dl>
                <dt>活动说明</dt>
                <dd>
                    <textarea name="txtactContent" rows="2" cols="20" id="txtactContent" class="input" runat="server">亲，请点击进入大转盘活动页面，祝您好运哦！</textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>重复抽奖回复</dt>
                <dd>
                    <asp:TextBox ID="txtcfcjhf" runat="server" CssClass="input normal" Text="亲，继续努力哦！" datatype="*1-50" sucmsg=" " />
                    <span class="Validform_checktip">*如果设置只允许抽一次奖的，请写：你已经玩过了，下次再来。 如果设置可多次抽奖，请写：亲，继续努力哦！</span>
                </dd>
            </dl>

            <dl>
                <dt>商家兑奖密码</dt>
                <dd>
                    <asp:TextBox ID="txtdjPwd" runat="server" CssClass="input normal" datatype="*0-15" sucmsg=" " Text=""  />
                    <span class="Validform_checktip">*消费确认密码长度小于15位 不设置密码,兑奖页面的密码输入框则不出现</span>
                </dd>
            </dl>


        </div>
        <div class="tab-content" style="display: none">
            <dl>
                <dt>活动结束的图片</dt>
                <dd>
                    <asp:Image ID="imgEndPic" runat="server" ImageUrl="/shop/dzp/images/end.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtEndPic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>
                </dd>
            </dl>

            <dl>
                <dt>活动结束公告主题</dt>
                <dd>
                    <asp:TextBox ID="txtendNotice" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="大转盘活动已经结束了" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>
            <dl>
                <dt>活动结束说明</dt>
                <dd>
                    <asp:TextBox ID="txtendContent" runat="server" CssClass="input normal" datatype="*1-300" sucmsg=" " Text="亲，活动已经结束，请继续关注我们的后续活动哦。" />
                    <span class="Validform_checktip">*换行请输入
                        <br>
                    </span>
                </dd>
            </dl>

        </div>

        <div class="tab-content" style="display: none">
            <dl>
                <dt>奖项1（一等奖）</dt>
                <dd>奖项名称：<asp:TextBox ID="txt1JXName" runat="server" CssClass="input " datatype="*1-20" sucmsg=" " Text="" />
                    奖品名称：<asp:TextBox ID="txt1JPName" runat="server" CssClass="input " datatype="*1-20" sucmsg=" " Text="" />
                    显示数量：<asp:TextBox ID="txt1Num" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="" />
                    实际数量：<asp:TextBox ID="txt1RealNum" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>奖项2（二等奖）</dt>
                <dd>奖项名称：<asp:TextBox ID="txt2JXName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    奖品名称：<asp:TextBox ID="txt2JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    显示数量：<asp:TextBox ID="txt2Num" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                    实际数量：<asp:TextBox ID="txt2RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                </dd>
            </dl>
            <dl>
                <dt>奖项3（三等奖）</dt>
                 <dd>奖项名称：<asp:TextBox ID="txt3JXName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    奖品名称：<asp:TextBox ID="txt3JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    显示数量：<asp:TextBox ID="txt3Num" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                    实际数量：<asp:TextBox ID="txt3RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                </dd>
            </dl>
            <dl>
                <dt>奖项4（四等奖）</dt>
                <dd>奖项名称：<asp:TextBox ID="txt4JXName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    奖品名称：<asp:TextBox ID="txt4JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    显示数量：<asp:TextBox ID="txt4Num" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                    实际数量：<asp:TextBox ID="txt4RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />

                </dd>
            </dl>
            <dl>
                <dt>奖项5（五等奖）</dt>
                <dd>奖项名称：<asp:TextBox ID="txt5JXName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    奖品名称：<asp:TextBox ID="txt5JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    显示数量：<asp:TextBox ID="txt5Num" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                    实际数量：<asp:TextBox ID="txt5RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />

                </dd>
            </dl>
            <dl>
                <dt>奖项6（六等奖）</dt>
                <dd>奖项名称：<asp:TextBox ID="txt6JXName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    奖品名称：<asp:TextBox ID="txt6JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    显示数量：<asp:TextBox ID="txt6Num" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                    实际数量：<asp:TextBox ID="txt6RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />

                </dd>
            </dl>

            <dl>
                <dt>预计活动的人数</dt>
                <dd>
                    <asp:TextBox ID="txtpersonNum" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="100" />
                    <span class="Validform_checktip">*预估活动人数直接影响抽奖概率：中奖概率 = 实际奖品总数/(预估活动人数*每人抽奖次数) 如果要确保任何时候都100%中奖建议设置为1人参加!</span>
                </dd>
            </dl>
            <dl>
                <dt>每人最多允许抽奖总次数</dt>
                <dd>
                    <asp:TextBox ID="txtpersonMaxTimes" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="1" />
                    <span class="Validform_checktip">必须大于0无上限 推荐只设置1次!</span>
                </dd>
            </dl>
            <dl>
                <dt>每天最多抽奖次数</dt>
                <dd>
                    <asp:TextBox ID="txtdayMaxTimes" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="1" />
                    <span class="Validform_checktip">*必须小于总抽奖次数！ 0 为不限制 抽完总数就不能抽了! 可以抽奖天数 = 总数/每天抽奖次数!</span>
                </dd>
            </dl>

        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="dzplist.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>