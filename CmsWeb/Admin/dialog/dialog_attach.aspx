<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_attach.aspx.cs" Inherits="Admin_dialog_dialog_attach" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>上传附件</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type='text/javascript' src="../scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确定',
        focus: true,
        callback: function () {
            execAttachHtml();
            return false;
        }
    }, {
        name: '取消'
    });
    //页面加载完成执行
    $(function () {
        $(".upload-attach").InitSWFUpload({ filesize: "20480", sendurl: "../tools/upload_ajax.ashx", flashurl: "../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.rar;*.zip;*.doc;*.xls" });
        $("input[name='attachType']").click(function () {
            var indexNum = $("input[name='attachType']").index($(this));
            $(".dl-attach-box").hide();
            $(".dl-attach-box").eq(indexNum).show();
        });
        //修改状态，赋值给表单
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent();
            var filePath = parentObj.find("input[name='hid_attach_filepath']").val();
            var fileName = parentObj.find("input[name='hid_attach_filename']").val();
            var fileSize = parentObj.find("input[name='hid_attach_filesize']").val();
            if (filePath.substring(0, 7).toLowerCase() == "http://") {
                $(".rule-multi-radio div a").eq(1).trigger("click"); //触发事件
                $("#txtRemoteTitle").val(fileName);
                $("#txtRemoteUrl").val(filePath);
                $(".dl-attach-box").hide();
                $(".dl-attach-box").eq(1).show();
            } else {
                $(".rule-multi-radio div a").eq(0).trigger("click"); //触发事件
                $("#txtFileName").val(fileName);
                $("#hidFilePath").val(filePath);
                $("#hidFileSize").val(fileSize);
                $(".dl-attach-box").hide();
                $(".dl-attach-box").eq(0).show();
            }
        }
    });
    //创建附件节点
    function execAttachHtml() {
        if ($("input[name='attachType']:checked").val() == 0) {
            if ($("#hidFilePath").val() == "" || $("#hidFileSize").val() == "" || $("#txtFileName").val() == "") {
                W.$.dialog.alert('没有找到已上传附件，上传一张吧！', function () { }, api);
                return false;
            }
            var fileExt = $("#hidFilePath").val().substring($("#hidFilePath").val().lastIndexOf(".") + 1).toUpperCase();
            var fileSize = Math.round($("#hidFileSize").val() / 1024);
            var fileSizeStr = fileSize + "KB";
            if (fileSize >= 1024) {
                fileSizeStr = ForDight((fileSize / 1024), 1) + "MB";
            }
            appendAttachHtml($("#txtFileName").val(), $("#hidFilePath").val(), fileExt, $("#hidFileSize").val(), fileSizeStr); //插件节点
        } else {
            if ($("#txtRemoteTitle").val() == "" || $("#txtRemoteUrl").val() == "") {
                W.$.dialog.alert('没有远程附件地址或文件名为空！', function () {
                    $("#txtRemoteTitle").focus();
                }, api);
                return false;
            }
            //获得远程文件信息
            $.ajax({
                type: "post",
                url: "../tools/admin_ajax.ashx?action=get_remote_fileinfo",
                data: {
                    remotepath: function () {
                        return $("#txtRemoteUrl").val();
                    }
                },
                dataType: "json",
                success: function (data, textStatus) {
                    if (data.status == '0') {
                        W.$.dialog.alert(data.msg, function () { }, api);
                        return false;
                    } else {
                        var fileSize = Math.round(data.size / 1024);
                        var fileSizeStr = fileSize + "KB";
                        if (fileSize >= 1024) {
                            fileSizeStr = ForDight((fileSize / 1024), 1) + "MB";
                        }
                        appendAttachHtml($("#txtRemoteTitle").val(), $("#txtRemoteUrl").val(), data.ext, data.size, fileSizeStr); //插件节点
                    }
                }
            });
        }
    }
    //创建附件节点的HTML
    function appendAttachHtml(fileName, filePath, fileExt, fileSize, fileSizeStr) {
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent();
            parentObj.find("input[name='hid_attach_filename']").val(fileName);
            parentObj.find("input[name='hid_attach_filepath']").val(filePath);
            parentObj.find("input[name='hid_attach_fileSize']").val(fileSize);
            parentObj.find(".title").text(fileName);
            parentObj.find(".info .ext").text(fileExt);
            parentObj.find(".info .size").text(fileSizeStr);
        } else {
            var liHtml = '<li>'
            + '<input name="hid_attach_id" type="hidden" value="0" />'
            + '<input name="hid_attach_filename" type="hidden" value="' + fileName + '" />'
            + '<input name="hid_attach_filepath" type="hidden" value="' + filePath + '" />'
            + '<input name="hid_attach_filesize" type="hidden" value="' + fileSize + '" />'
            + '<i class="icon"></i>'
            + '<a href="javascript:;" onclick="delAttachNode(this);" class="del" title="删除附件"></a>'
            + '<a href="javascript:;" onclick="showAttachDialog(this);" class="edit" title="更新附件"></a>'
            + '<div class="title">' + fileName + '</div>'
            + '<div class="info">类型：<span class="ext">' + fileExt + '</span> 大小：<span class="size">' + fileSizeStr + '</span> 下载：<span class="down">0</span>次</div>'
            + '<div class="btns">下载积分：<input type="text" name="txt_attach_point" onkeydown="return checkNumber(event);" value="0" /></div>'
            + '</li>';
            $("#showAttachList", api.opener.document).children("ul").append(liHtml);
        }
        api.close();
    }
</script>
</head>
<body>
<div class="div-content">
  <dl>
    <dt>附件类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <input type="radio" name="attachType" value="0" checked="checked" /><label>本地附件</label><input type="radio" name="attachType" value="1" /><label>远程附件</label>
      </div>
    </dd>
  </dl>
  <div class="dl-attach-box">
    <dl>
      <dt></dt>
      <dd>
        <input type="hidden" id="hidFilePath" class="upload-path" />
        <input type="hidden" id="hidFileSize" class="upload-size" />
        <input type="text" id="txtFileName" class="input txt upload-name" />
        <div class="upload-box upload-attach"></div>
      </dd>
    </dl>
    <dl>
      <dt></dt>
      <dd>提示：上传文件后，可更改附件名称</dd>
    </dl>
  </div>
  <div class="dl-attach-box" style="display:none;">
    <dl>
      <dt>附件名称</dt>
      <dd><input type="text" id="txtRemoteTitle" class="input txt" /></dd>
    </dl>
    <dl>
      <dt>远程地址</dt>
      <dd><input type="text" id="txtRemoteUrl" class="input txt" /> <span>*以“http://”开头</span></dd>
    </dl>
  </div>
</div>
</body>
</html>
