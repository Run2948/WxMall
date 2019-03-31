<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SinglePage_edit.aspx.cs"
    Inherits="Admin_settings_SinglePage_edit" ValidateRequest="false" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑栏目</title>
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

        KindEditor.ready(function (K) {
            window.editor = K.create('#w_content');
        });

        KindEditor.ready(function (K) {
            window.editor = K.create('#e_content');
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

        //上传单张图片start
        KindEditor.ready(function (K) {
            var editor = K.editor({
                allowFileManager: true
            });
            K('#image2').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        imageUrl: K('#photoUrlone').val(),
                        clickFn: function (url, title, width, height, border, align) {
                            K('#photoUrlone').val(url);
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
            K('#image3').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        imageUrl: K('#photoUrltwo').val(),
                        clickFn: function (url, title, width, height, border, align) {
                            K('#photoUrltwo').val(url);
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
            K('#image4').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        imageUrl: K('#textParam1').val(),
                        clickFn: function (url, title, width, height, border, align) {
                            K('#textParam1').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
        });
        //上传单张图片end

        //获取调用名称start
        function change2cn(en, cninput) {
            cninput.value = getSpell(en, "");
        }
        //获取调用名称end
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="Column_list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="Column_list.aspx">
                <span>栏目列表</span></a> <i class="arrow"></i><span>编辑栏目</span>
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
                    <li><a href="javascript:;" onclick="tabs(this);">SEO设置</a></li>
                    <li id="best_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">
                        高级选项</a></li>
                    <li id="wap_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">
                        手机站信息</a></li>
                    <li id="english_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">
                        英文站信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl runat="server" visible="false">
            <dt>上级导航</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="parentId" runat="server" Enabled="false">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>模型</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="modelId" runat="server" Enabled="false">
                        <asp:ListItem Value="2">文章模型</asp:ListItem>
                        <asp:ListItem Value="3">产品模型</asp:ListItem>
                        <asp:ListItem Value="4">单页模型</asp:ListItem>
                        <asp:ListItem Value="5">积分模型</asp:ListItem>
                        <asp:ListItem Value="1">导航模型</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>名称</dt>
            <dd>
                <asp:TextBox ID="className" runat="server" CssClass="input normal" onBlur="change2cn(this.value, this.form.txtCallIndex)"
                    datatype="*1-100" sucmsg=" "></asp:TextBox>
                <asp:Label ID="classid" runat="server" Text="Label"></asp:Label>
                <span class="Validform_checktip">*名称中文标题，100字符内</span></dd>
        </dl>
        <dl>
            <dt>副名称</dt>
            <dd>
                <asp:TextBox ID="sub_title" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*副名称中文标题，100字符内</span></dd>
        </dl>
        <dl>
            <dt>缩略图</dt>
            <dd>
                <p>
                    <input type="text" id="photoUrl" value="" runat="server" />
                    <input type="button" id="image1" value="选择图片" /></p>
            </dd>
        </dl>
        <dl>
            <dt>简介</dt>
            <dd>
                <asp:TextBox ID="intro" runat="server" TextMode="MultiLine" datatype="*0-255" sucmsg=" "
                    Style="width: 800px; height: 100px;" Font-Size="Small"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl>
            <dt>内容</dt>
            <dd>
                <textarea id="content" name="content" style="width: 800px; height: 200px; visibility: hidden;"
                    class="editor" runat="server"></textarea>
            </dd>
        </dl>
    </div>
    <div class="tab-content" style="display: none">
        <dl>
            <dt>SEO标题</dt>
            <dd>
                <asp:TextBox ID="seoTitle" runat="server" maxlength="255"  CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox>
                 <span class="Validform_checktip">255个字符以内</span></dd>
        </dl>
        <dl>
            <dt>SEO关键字</dt>
            <dd>
                <asp:TextBox ID="seoKeyword" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">以“,”逗号区分开，255个字符以内</span></dd>
        </dl>
        <dl>
            <dt>SEO描述</dt>
            <dd>
                <asp:TextBox ID="seoDescription" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">255个字符以内</span>
            </dd>
        </dl>
    </div>
    <div id="best_tab_content" runat="server" visible="false" class="tab-content" style="display: none">
        <dl runat="server" visible="false">
            <dt>是否开通高级设置</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </div>
                <span class="Validform_checktip"></span>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>调用别名</dt>
            <dd>
                <asp:TextBox ID="txtCallIndex" runat="server" CssClass="input normal" datatype="/^\s*$|^[a-zA-Z0-9\-\_]{2,50}$/"
                    errormsg="请填写正确的别名" sucmsg=" " ReadOnly="True"></asp:TextBox>
                <span class="Validform_checktip">类别的调用别名，只允许字母、数字、下划线</span>
            </dd>
        </dl>
        <dl>
            <dt>排序数字</dt>
            <dd>
                <asp:TextBox ID="orderNumber" runat="server" CssClass="input small" datatype="n"
                    sucmsg=" ">99</asp:TextBox>
                <span class="Validform_checktip">*数字，越大越向前</span>
            </dd>
        </dl>
        
        <div style="display: none;">
            <dl>
                <dt>栏目图标Ture</dt>
                <dd>
                    <p>
                        <input type="text" id="photoUrlone" value="" runat="server" />
                        <input type="button" id="image2" value="选择图片" /></p>
                </dd>
            </dl>
            <dl>
                <dt>栏目图标False</dt>
                <dd>
                    <p>
                        <input type="text" id="photoUrltwo" value="" runat="server" />
                        <input type="button" id="image3" value="选择图片" /></p>
                </dd>
            </dl>
        </div>
        <dl runat="server" visible="false">
            <dt>是否参与导航</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="isShowChannel" runat="server" />
                </div>
                <span class="Validform_checktip">*隐藏后不显示在前端导航菜单中。</span>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>是否隐藏子栏目</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="isShowNext" runat="server" />
                </div>
                <span class="Validform_checktip"></span>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>是否打开新窗口</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="isBlank" runat="server" />
                </div>
                <span class="Validform_checktip"></span>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>是否隐藏</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="isHidden" runat="server" />
                </div>
                <span class="Validform_checktip">*隐藏后不显示在后台管理导航菜单中。</span>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>开启相册功能</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsAlbums" runat="server" />
                </div>
                <span class="Validform_checktip">*开启相册功能后可上传多张图片</span>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>开启附件功能</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsAttach" runat="server" />
                </div>
                <span class="Validform_checktip">*开启附件功能后可上传多个附件。</span>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>分页数量</dt>
            <dd>
                <asp:TextBox ID="txtPageSize" runat="server" CssClass="input small" datatype="n"
                    sucmsg=" ">10</asp:TextBox>
                <span class="Validform_checktip">*列表页每页显示数据数量</span>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>选择字段</dt>
            <dd>
                <div class="rule-multi-porp">
                    <asp:CheckBoxList ID="cblAttributeField" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </div>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>栏目关联</dt>
            <dd>
                <a id="itemAddButton" class="icon-btn add" onclick="showcoliumn()"><i></i><span>选择栏目</span></a>
                <asp:TextBox ID="columnchose" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox>
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>权限资源</dt>
            <dd>
                <div class="rule-multi-porp">
                    <asp:CheckBoxList ID="cblActionType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>外链接</dt>
            <dd>
                <asp:TextBox ID="linkUrl" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox><asp:Label ID="Label7" runat="server" CssClass="Validform_checktip" /></dd>
        </dl>
        <dl>
            <dt>栏目模版</dt>
            <dd>
                <asp:TextBox ID="tplChannel" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox><asp:Label ID="Label4" runat="server" CssClass="Validform_checktip" />
                
            </dd>
        </dl>
        <dl>
            <dt>内容模版</dt>
            <dd>
                <asp:TextBox ID="tplContent" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox><asp:Label ID="Label6" runat="server" CssClass="Validform_checktip" />
               
            </dd>
        </dl>
        <dl runat="server" visible="false">
            <dt>后台操作地址</dt>
            <dd>
                <asp:TextBox ID="listinfopath" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox>
                <asp:Label ID="Label9" runat="server" CssClass="Validform_checktip" /></dd>
        </dl>
    </div>
    <div id="wap_tab_content" runat="server" visible="false" class="tab-content" style="display: none">
        <dl>
            <dt>是否开通手机导航</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="w_isShowChannel" runat="server" />
                </div>
                <span class="Validform_checktip">*隐藏后不显示在界面导航菜单中。</span>
            </dd>
        </dl>
        <dl>
            <dt>外链地址</dt>
            <dd>
                <asp:TextBox ID="w_linkUrl" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox><asp:Label ID="Label11" runat="server" CssClass="Validform_checktip" /></dd>
        </dl>
        <dl>
            <dt>简介</dt>
            <dd>
                <asp:TextBox ID="w_intro" runat="server" TextMode="MultiLine" datatype="*0-255" sucmsg=" "
                    Style="width: 800px; height: 100px;" Font-Size="Small"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl>
            <dt>内容</dt>
            <dd>
                <textarea id="w_content" name="content" style="width: 800px; height: 200px; visibility: hidden;"
                    class="editor" runat="server"></textarea></dd>
        </dl>
    </div>
    <div id="english_tab_content" runat="server" visible="false" class="tab-content"
        style="display: none">
        <dl>
            <dt>是否开通英文导航</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="e_isShowChannel" runat="server" />
                </div>
                <span class="Validform_checktip">*隐藏后不显示在界面导航菜单中。</span>
            </dd>
        </dl>
        <dl>
            <dt>名称</dt>
            <dd>
                <asp:TextBox ID="engName" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox>
                <asp:Label ID="div_sub_title_tip" runat="server" CssClass="Validform_checktip" /></dd>
        </dl>
        <dl>
            <dt>外链地址</dt>
            <dd>
                <asp:TextBox ID="e_linkUrl" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox><asp:Label ID="Label16" runat="server" CssClass="Validform_checktip" /></dd>
        </dl>
        <dl>
            <dt>简介</dt>
            <dd>
                <asp:TextBox ID="e_intro" runat="server" TextMode="MultiLine" datatype="*0-255" sucmsg=" "
                    Style="width: 800px; height: 100px;" Font-Size="Small"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl>
            <dt>内容</dt>
            <dd>
                <textarea id="e_content" name="content" style="width: 800px; height: 200px; visibility: hidden;"
                    class="editor" runat="server"></textarea></dd>
        </dl>
        <dl>
            <dt>SEO标题</dt>
            <dd>
                <asp:TextBox ID="e_seoTitle" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox><asp:Label ID="Label13" runat="server" CssClass="Validform_checktip" /></dd>
        </dl>
        <dl>
            <dt>SEO关键字</dt>
            <dd>
                <asp:TextBox ID="e_seoKeyword" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox><asp:Label ID="Label14" runat="server" CssClass="Validform_checktip" /></dd>
        </dl>
        <dl>
            <dt>SEO描述</dt>
            <dd>
                <asp:TextBox ID="e_seoDescription" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" "></asp:TextBox><asp:Label ID="Label15" runat="server" CssClass="Validform_checktip" /></dd>
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
<script type="text/javascript">
    function showcoliumn() {
        traverseTemp();
        var uoo = new Dialog();
        uoo.Width = 300;
        uoo.Height = 500;
        //        uoo.CancelEvent = function () { uoo.close() };
        //        uoo.OKEvent = function () { uoo.close() };
        uoo.URL = "/Admin/dialog/dialog_Column.aspx";
        uoo.Title = "关联栏目";
        uoo.show();
    }
    function start() {
        parent.ColumnTemp = {};
    }
    start();
    //遍历全局变量
    function traverseTemp() {
        for (var i in parent.ColumnTemp) {
            document.getElementById(i).value = parent.ColumnTemp[i];
        }
    }
</script>
</html>
