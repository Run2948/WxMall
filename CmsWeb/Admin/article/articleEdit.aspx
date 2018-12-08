<%@ Page Language="C#" AutoEventWireup="true" CodeFile="articleEdit.aspx.cs" Inherits="Admin_article_articleEdit"
    ValidateRequest="false" EnableEventValidation="false" EnableViewState="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑信息</title>
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
                            K('#photoUrlImg').attr("src", url); 
                            
                            editor.hideDialog();
                        }
                    });
                });
            });
        });
        //上传单张图片end



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
        <a href="articleList.aspx" id="hreflist" runat="server" class="back"><i></i><span>返回列表页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>
            <%=new Cms.BLL.C_Column().GetModel(Convert.ToInt32(Request["classid"].ToString())).className.ToString()%></span>
        <i class="arrow"></i><span>编辑信息</span>
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
                    <li><a href="javascript:;" onclick="tabs(this);">SEO信息</a></li>
                    <li id="best_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">
                        高级选项</a></li>
                    <li id="field_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">
                        扩展选项</a></li>
                    <li id="related_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">
                        关联信息</a></li>
                    <li id="wap_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">
                        手机站信息</a></li>
                    <li id="english_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">
                        英文站信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>所属导航</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="parentId" runat="server" datatype="*" sucmsg=" ">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>标题</dt>
            <dd>
                <asp:TextBox ID="Title" runat="server" CssClass="input normal" datatype="*2-100"
                    sucmsg=" " />
                <span class="Validform_checktip">*标题最多100个字符</span>
            </dd>
        </dl>
        <dl>
            <dt>显示状态</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="isHidden" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
                        <%--  <asp:ListItem Value="1">待审核</asp:ListItem>--%>
                        <asp:ListItem Value="2">不显示</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>推荐类型</dt>
            <dd>
                <div class="rule-multi-checkbox">
                    <asp:CheckBoxList ID="cblItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">置顶</asp:ListItem>
                        <asp:ListItem Value="1">推荐</asp:ListItem>
                        <asp:ListItem Value="1">热门</asp:ListItem>
                        <asp:ListItem Value="1">评论</asp:ListItem>
                        <asp:ListItem Value="1">幻灯片</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>排序数字</dt>
            <dd>
                <asp:TextBox ID="orderNumber" runat="server" CssClass="input small" datatype="n"
                    sucmsg=" ">0</asp:TextBox>
                <span class="Validform_checktip">*数字，越大越向前</span>
            </dd>
        </dl>
        <dl id="div_source" runat="server">
            <dt>信息来源</dt>
            <dd>
                <asp:TextBox ID="txtsource" runat="server" CssClass="input normal"></asp:TextBox>
                <asp:Label ID="div_source_tip" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl id="div_author" runat="server">
            <dt>文章作者</dt>
            <dd>
                <asp:TextBox ID="txtauthor" runat="server" CssClass="input normal" datatype="s0-50"
                    sucmsg=" "></asp:TextBox>
                <asp:Label ID="div_author_tip" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl>
            
            <dt>封面图片</dt>
            <dd>
                <asp:TextBox ID="photoUrl" runat="server" CssClass="input normal" />
                <input type="button" id="image1" value="选择图片" /><br />
                <asp:Image ID="photoUrlImg" runat="server" Width="250" Height="135"  />
                
                <asp:Label ID="Label4" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl>
            <dt>发布时间</dt>
            <dd>
                <div class="input-date">
                    <asp:TextBox ID="updateTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期"
                        sucmsg=" " />
                    <i>日期</i>
                </div>
                <span class="Validform_checktip">不选择默认当前发布时间</span>
            </dd>
        </dl>
        <dl id="div_attach_container" runat="server">
            <dt>上传附件</dt>
            <dd>
                <input type="text" id="Attachment" value="" runat="server" />
                <input type="button" id="insertfile" value="选择文件" />
                <span class="Validform_checktip">限制格式MP4,文件大小不能超过10M</span>
            </dd>
        </dl>
        
        
         <dl>
            <dt>外链</dt>
            <dd>
                <asp:TextBox ID="txtLinkUrl" runat="server" MaxLength="255" CssClass="input normal" />
                <span class="Validform_checktip">跳转到第三方</span>
            </dd>
        </dl>
        <dl id="div_albums_container" runat="server" visible="false">
            <dt>图片相册</dt>
            <dd>
                <div class="upload-box upload-album">
                </div>
                <input type="hidden" name="hidFocusPhoto" id="hidFocusPhoto" runat="server" class="focus-photo" />
                <div class="photo-list">
                    <ul>
                        <asp:Repeater ID="rptAlbumList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <input type="hidden" name="hid_photo_name" value="<%#Eval("id")%>|<%#Eval("original_path")%>|<%#Eval("thumb_path")%>" />
                                    <input type="hidden" name="hid_photo_remark" value="<%#Eval("remark")%>" />
                                    <div class="img-box" onclick="setFocusImg(this);">
                                        <img src="<%#Eval("thumb_path")%>" bigsrc="<%#Eval("original_path")%>" />
                                        <span class="remark"><i>
                                            <%#Eval("remark").ToString() == "" ? "暂无描述..." : Eval("remark").ToString()%></i></span>
                                    </div>
                                    <a href="javascript:;" onclick="setRemark(this);">描述</a> <a href="javascript:;" onclick="delImg(this);">
                                        删除</a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </dd>
        </dl>
        <dl id="Dl1" runat="server" visible="false">
            <dt>上传附件</dt>
            <dd>
                <a class="icon-btn add attach-btn"><span>添加附件</span></a>
                <div id="showAttachList" class="attach-list">
                    <ul>
                        <asp:Repeater ID="rptAttachList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <input name="hid_attach_id" type="hidden" value="<%#Eval("id")%>" />
                                    <input name="hid_attach_filename" type="hidden" value="<%#Eval("file_name")%>" />
                                    <input name="hid_attach_filepath" type="hidden" value="<%#Eval("file_path")%>" />
                                    <input name="hid_attach_filesize" type="hidden" value="<%#Eval("file_size")%>" />
                                    <i class="icon"></i><a href="javascript:;" onclick="delAttachNode(this);" class="del"
                                        title="删除附件"></a><a href="javascript:;" onclick="showAttachDialog(this);" class="edit"
                                            title="更新附件"></a>
                                    <div class="title">
                                        <%#Eval("file_name")%></div>
                                    <div class="info">
                                        类型：<span class="ext"><%#Eval("file_ext")%></span> 大小：<span class="size"><%#(Convert.ToInt32(Eval("file_size")) / 1024) > 1024 ? Convert.ToDouble((Convert.ToDouble(Eval("file_size")) / 1048576f)).ToString("0.0") + "MB" : (Convert.ToInt32(Eval("file_size")) / 1024) + "KB"%></span>
                                        下载：<span class="down"><%#Eval("down_num")%></span>次</div>
                                    <div class="btns">
                                        下载积分：<input type="text" name="txt_attach_point" onkeydown="return checkNumber(event);"
                                            value="<%#Eval("point")%>" /></div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
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
                <textarea id="content" name="content" class="editor" style="width: 800px; height: 200px;
                    visibility: hidden;" runat="server"></textarea>
            </dd>
        </dl>
    </div>
    <div class="tab-content" style="display: none">
        <dl>
            <dt>SEO标题</dt>
            <dd>
                <asp:TextBox ID="seoTitle" runat="server" MaxLength="255" CssClass="input normal"
                    datatype="*0-100" sucmsg=" " />
                <span class="Validform_checktip">255个字符以内</span>
            </dd>
        </dl>
        <dl>
            <dt>SEO关健字</dt>
            <dd>
                <asp:TextBox ID="seoKeyword" runat="server" CssClass="input" TextMode="MultiLine"
                    datatype="*0-255" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">以“,”逗号区分开，255个字符以内</span>
            </dd>
        </dl>
        <dl>
            <dt>SEO描述</dt>
            <dd>
                <asp:TextBox ID="seoDescription" runat="server" CssClass="input" TextMode="MultiLine"
                    datatype="*0-255" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">255个字符以内</span>
            </dd>
        </dl>
    </div>
    <div id="best_tab_content" runat="server" visible="false" class="tab-content" style="display: none">
        
        <dl>
            <dt>浏览次数</dt>
            <dd>
                <asp:TextBox ID="hits" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>
                <span class="Validform_checktip">点击浏览该信息自动+1</span>
            </dd>
        </dl>
        
       
        <div runat="server" visible="false">
            <input id="articlesubid" runat="server" value="" type="hidden" />
            <dl>
                <dt>品牌分类</dt>
                <dd>
                    <asp:ListBox ID="bardtype" runat="server" Height="200px" Width="130px" SelectionMode="Multiple"
                        OnSelectedIndexChanged="bardtype_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                    <asp:ListBox ID="bardtypechose" runat="server" Height="200px" Width="130px" SelectionMode="Multiple"
                        OnSelectedIndexChanged="bardtypechose_SelectedIndexChanged" AutoPostBack="True">
                    </asp:ListBox>
                </dd>
            </dl>
            <dl>
                <dt>产品类别</dt>
                <dd>
                    <asp:ListBox ID="productype" runat="server" Height="200px" Width="130px" SelectionMode="Multiple"
                        OnSelectedIndexChanged="productype_SelectedIndexChanged" AutoPostBack="True">
                    </asp:ListBox>
                    <asp:ListBox ID="productypechose" runat="server" Height="200px" Width="130px" SelectionMode="Multiple"
                        OnSelectedIndexChanged="productypechose_SelectedIndexChanged" AutoPostBack="True">
                    </asp:ListBox>
                </dd>
            </dl>
            <dl>
                <dt>颜色类别</dt>
                <dd>
                    <asp:ListBox ID="colortype" runat="server" Height="200px" Width="130px" SelectionMode="Multiple"
                        OnSelectedIndexChanged="colortype_SelectedIndexChanged" AutoPostBack="True">
                    </asp:ListBox>
                    <asp:ListBox ID="colortypechose" runat="server" Height="200px" Width="130px" SelectionMode="Multiple"
                        OnSelectedIndexChanged="colortypechose_SelectedIndexChanged" AutoPostBack="True">
                    </asp:ListBox>
                </dd>
            </dl>
        </div>
    </div>
    <div id="field_tab_content" runat="server" visible="false" class="tab-content" style="display: none">
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    </div>
    <div id="related_tab_content" runat="server" visible="false" class="tab-content"
        style="display: none">
        <dl>
            <dt>关联信息</dt>
            <dd>
                <asp:CheckBoxList ID="CheckBoxList_related" runat="server">
                </asp:CheckBoxList>
            </dd>
        </dl>
    </div>
    <div id="wap_tab_content" runat="server" visible="false" class="tab-content" style="display: none">
        <dl>
            <dt>外链地址</dt>
            <dd>
                <asp:TextBox ID="w_LinkUrl" runat="server" MaxLength="255" CssClass="input normal" />
                <span class="Validform_checktip">填写后直接跳转到该网址</span>
            </dd>
        </dl>
        <dl>
            <dt>简介</dt>
            <dd>
                <asp:TextBox ID="w_intro" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255"
                    sucmsg=" "></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>内容</dt>
            <dd>
                <textarea id="w_content" name="Packagecontent" class="editor" style="width: 800px;
                    height: 200px; visibility: hidden;" runat="server"></textarea>
            </dd>
        </dl>
    </div>
    <div id="english_tab_content" runat="server" visible="false" class="tab-content"
        style="display: none">
        <dl id="div_sub_title" runat="server">
            <dt>英文标题</dt>
            <dd>
                <asp:TextBox ID="englishtitle" runat="server" CssClass="input normal" datatype="*0-255"
                    sucmsg=" " />
                <asp:Label ID="div_sub_title_tip" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl>
            <dt>外链地址</dt>
            <dd>
                <asp:TextBox ID="e_LinkUrl" runat="server" MaxLength="255" CssClass="input normal" />
                <span class="Validform_checktip">填写后直接跳转到该网址</span>
            </dd>
        </dl>
        <dl>
            <dt>英文信息来源</dt>
            <dd>
                <asp:TextBox ID="e_source" runat="server" CssClass="input normal" datatype="s0-50"
                    sucmsg=" "></asp:TextBox>
                <asp:Label ID="Label2" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl>
            <dt>英文作者</dt>
            <dd>
                <asp:TextBox ID="e_author" runat="server" CssClass="input normal" datatype="s0-50"
                    sucmsg=" "></asp:TextBox>
                <asp:Label ID="Label3" runat="server" CssClass="Validform_checktip" />
            </dd>
        </dl>
        <dl>
            <dt>SEO标题</dt>
            <dd>
                <asp:TextBox ID="e_seoTitle" runat="server" MaxLength="255" CssClass="input normal"
                    datatype="*0-100" sucmsg=" " />
                <span class="Validform_checktip">255个字符以内</span>
            </dd>
        </dl>
        <dl>
            <dt>SEO关健字</dt>
            <dd>
                <asp:TextBox ID="e_seoKeyword" runat="server" CssClass="input" TextMode="MultiLine"
                    datatype="*0-255" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">以“,”逗号区分开，255个字符以内</span>
            </dd>
        </dl>
        <dl>
            <dt>SEO描述</dt>
            <dd>
                <asp:TextBox ID="e_seoDescription" runat="server" CssClass="input" TextMode="MultiLine"
                    datatype="*0-255" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">255个字符以内</span>
            </dd>
        </dl>
        <dl>
            <dt>简介</dt>
            <dd>
                <asp:TextBox ID="e_intro" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255"
                    sucmsg=" "></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>内容</dt>
            <dd>
                <textarea id="e_content" name="Packagecontent" class="editor" style="width: 800px;
                    height: 200px; visibility: hidden;" runat="server"></textarea>
            </dd>
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
