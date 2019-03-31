$(function () {
    //初始化绑定默认的属性
    $.swfUpLoadDefaults = $.swfUpLoadDefaults || {};
    $.swfUpLoadDefaults.property = {
        single: true, //是否单文件
        water: false, //是否加水印
        thumbnail: false, //是否生成缩略图
        sendurl: null, //发送地址
        filetypes: "*.jpg;*.jpge;*.png;*.gif;", //文件类型
        filesize: "2048", //文件大小
        btntext: "浏览...", //上传按钮的文字
        btnwidth: 48, //上传按钮的宽度
        btnheight: 28, //上传按钮的高度
        flashurl: null //FLASH上传控件相对地址
    };
    //初始化SWFUpload上传控件
    $.fn.InitSWFUpload = function (p) {
        p = $.extend({}, $.swfUpLoadDefaults.property, p || {});
        //创建上传按钮
        var parentObj = $(this);
        var parentBtnId = "upload_span_" + Math.floor(Math.random() * 1000 + 1);
        parentObj.append('<div class="upload-btn"><span id="' + parentBtnId + '"></span></div>');
        //初始化属性
        var btnAction = SWFUpload.BUTTON_ACTION.SELECT_FILES; //多文件上传

        p.sendurl += "?action=UpLoadFile";
        if (p.single) {
            btnAction = SWFUpload.BUTTON_ACTION.SELECT_FILE; //单文件上传
        }
        if (p.water) {
            p.sendurl += "&IsWater=1";
        }
        if (p.thumbnail) {
            p.sendurl += "&IsThumbnail=1";
        }

        //初始化上传控件
        var swfu = new SWFUpload({
            post_params: { "ASPSESSID": "NONE" },
            upload_url: p.sendurl, //上传地址
            file_size_limit: p.filesize, //文件大小
            file_types: p.filetypes, //文件类型
            file_types_description: "JPG Images",
            file_upload_limit: "0", //一次能上传的文件数量

            file_queue_error_handler: fileQueueError,
            file_dialog_complete_handler: fileDialogComplete,
            upload_progress_handler: uploadProgress,
            upload_error_handler: uploadError,
            upload_success_handler: uploadSuccess,
            upload_complete_handler: uploadComplete,

            button_placeholder_id: parentBtnId, //指定一个dom元素
            button_width: p.btnwidth, //上传按钮的宽度
            button_height: p.btnheight, //上传按钮的高度
            button_text: '<span class="btnText">' + p.btntext + '</span>', //上传按钮的文字
            button_text_style: ".btnText{font-family:Microsoft YaHei;font-size:12px;line-height:28px;color:#333333;text-align:center;}", //按钮样式
            button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT, //背景透明
            button_action: btnAction, //单文件或多文件上传
            button_cursor: SWFUpload.CURSOR.HAND, //指针手形
            flash_url: p.flashurl, //Flash路径
            custom_settings: {
                "upload_target": parentObj,
                "button_action": btnAction
            },
            debug: false
        });
    }
});

//==================================以下是上传时处理事件===================================
//当选择文件对话框关闭消失时发生
function fileQueueError(file, errorCode, message) {
    try {
        switch (errorCode) {
            case SWFUpload.errorCode_QUEUE_LIMIT_EXCEEDED:
                alert("你选择的文件太多！");
                break;
            case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
                alert(file.name + "文件太小！");
                break;
            case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                alert(file.name + "文件太大！");
                break;
            case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                alert(file.name + "文件类型出错！");
                break;
            default:
                if (file !== null) {
                    alert("出现未知错误！");
                }
                break;
        }

    } catch (ex) {
        this.debug(ex);
    }
}
//当选择文件对话框关闭，所有文件已经处理完成时发生
function fileDialogComplete(numFilesSelected, numFilesQueued) {
    try {
        if (numFilesQueued > 0) {
            //如果是单文件上传，把旧的文件地址传过去
            if (this.customSettings.button_action == SWFUpload.BUTTON_ACTION.SELECT_FILE) {
                this.setPostParams({
                    "DelFilePath": $(this.customSettings.upload_target).siblings(".upload-path").val()
                });
            }
            this.startUpload();
            createHtmlProgress(this); //创建进度条
        }
    } catch (ex) {
        this.debug(ex);
    }
}
//flash定时触发，定时更新页面中的UI元素达到及时显示上传进度的效果
function uploadProgress(file, bytesLoaded) {
    try {
        var percent = Math.ceil((bytesLoaded / file.size) * 100);
        var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
        progressObj.children(".txt").html(file.name);
        progressObj.find(".bar b").width(percent + "%");
    } catch (ex) {
        this.debug(ex);
    }
}
//上传被终止或者没有成功完成时触发
function uploadError(file, errorCode, message) {
    var progress;
    try {
        switch (errorCode) {
            case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
                try {
                    var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
                    progressObj.children(".txt").html("上传被取消：Cancelled");
                }
                catch (ex1) {
                    this.debug(ex1);
                }
                break;
            case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
                try {
                    var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
                    progressObj.children(".txt").html("上传被停止：Stopped");
                }
                catch (ex2) {
                    this.debug(ex2);
                }
            case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
                alert(message + "SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED");
                break;
            default:
                alert(message + "未知！");
                break;
        }
    } catch (ex3) {
        this.debug(ex3);
    }
}
//文件上传的处理已经完成且服务端返回了200的HTTP状态时触发
function uploadSuccess(file, serverData) {
    try {
        var jsonstr = eval('(' + serverData + ')');
        if (jsonstr.status == '0') {
            var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
            progressObj.children(".txt").html(jsonstr.msg);
        }
        if (jsonstr.status == '1') {
            //如果是单文件上传，则赋值相应的表单
            if (this.customSettings.button_action == SWFUpload.BUTTON_ACTION.SELECT_FILE) {
                $(this.customSettings.upload_target).siblings(".upload-name").val(jsonstr.name);
                $(this.customSettings.upload_target).siblings(".upload-path").val(jsonstr.path);
                $(this.customSettings.upload_target).siblings(".upload-size").val(jsonstr.size);
            } else {
                addImage($(this.customSettings.upload_target), jsonstr.path, jsonstr.thumb);
            }
            var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
            progressObj.children(".txt").html("上传成功：" + file.name);
        }
    } catch (ex) {
        this.debug(ex);
    }
}
//当上传队列中的文件已完成时，无论成功(uoloadSuccess触发)或失败(uploadError触发)，此事件都会被触发
function uploadComplete(file) {
    try {
        if (this.getStats().files_queued > 0) {
            this.startUpload();
        } else {
            var progressObj = $(this.customSettings.upload_target).children(".upload-progress");
            progressObj.children(".txt").html("全部上传成功");
            progressObj.remove();
        }
    } catch (ex) {
        this.debug(ex);
    }
}

//==================================以上是上传时处理事件===================================
//创建上传进度条
function createHtmlProgress(swfuInstance) {
    //判断显示进度的DIV是否存在，不存在则创建
    var targetObj = $(swfuInstance.customSettings.upload_target);
    var fileProgressObj = $('<div class="upload-progress"></div>').appendTo(targetObj);
    var progressText = $('<span class="txt">正在上传，请稍候...</span>').appendTo(fileProgressObj);
    var progressBar = $('<span class="bar"><b></b></span>').appendTo(fileProgressObj);
    var progressCancel = $('<a class="close" title="取消上传">关闭</a>').appendTo(fileProgressObj);
    //绑定点击事件
    progressCancel.click(function () {
        swfuInstance.stopUpload();
        fileProgressObj.remove();
    });
}

//======================================图片相册处理事件======================================
//添加图片相册
function addImage(targetObj, originalSrc, thumbSrc) {
    //插入到相册UL里面
    var newLi = $('<li>'
    + '<input type="hidden" name="hid_photo_name" value="0|' + originalSrc + '|' + thumbSrc + '" />'
    + '<input type="hidden" name="hid_photo_remark" value="" />'
    + '<div class="img-box" onclick="setFocusImg(this);">'
    + '<img src="' + thumbSrc + '" bigsrc="' + originalSrc + '" />'
    + '<span class="remark"><i>暂无描述...</i></span>'
    + '</div>'
    + '<a href="javascript:;" onclick="setRemark(this);">描述</a>'
    + '<a href="javascript:;" onclick="delImg(this);">删除</a>'
    + '</li>');
    newLi.appendTo(targetObj.siblings(".photo-list").children("ul"));

    //默认第一个为相册封面
    var focusPhotoObj = targetObj.siblings(".focus-photo");
    if (focusPhotoObj.val() == "") {
        focusPhotoObj.val(thumbSrc);
        newLi.children(".img-box").addClass("selected");
    }
}
//设置相册封面
function setFocusImg(obj) {
    var focusPhotoObj = $(obj).parents(".photo-list").siblings(".focus-photo");
    focusPhotoObj.val($(obj).children("img").eq(0).attr("src"));
    $(obj).parent().siblings().children(".img-box").removeClass("selected");
    $(obj).addClass("selected");
}
//设置图片描述
function setRemark(obj) {
    var parentObj = $(obj); //父对象
    var hidRemarkObj = parentObj.prevAll("input[name='hid_photo_remark']").eq(0); //取得隐藏值
    var m = $.dialog({
        lock: true,
        max: false,
        min: false,
        padding: 0,
        title: "图片描述",
        content: '<textarea id="ImageRemark" style="margin:10px 0;font-size:12px;padding:3px;color:#000;border:1px #d2d2d2 solid;vertical-align:middle;width:300px;height:50px;">' + hidRemarkObj.val() + '</textarea>',
        button: [{
            name: '批量描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', parent.document);
                if (remarkObj.val() == "") {
                    $.dialog.alert('总该写点什么吧？', function () {
                        remarkObj.focus();
                    }, m);
                    return false;
                }
                parentObj.parent().parent().find("li input[name='hid_photo_remark']").val(remarkObj.val());
                parentObj.parent().parent().find("li .img-box .remark i").html(remarkObj.val());
            }
        }, {
            name: '单张描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', parent.document);
                if (remarkObj.val() == "") {
                    $.dialog.alert('总该写点什么吧？', function () {
                        remarkObj.focus();
                    }, m);
                    return false;
                }
                hidRemarkObj.val(remarkObj.val());
                parentObj.siblings(".img-box").children(".remark").children("i").html(remarkObj.val());
            },
            focus: true
        }]
    });
}
//删除图片LI节点
function delImg(obj) {
    var parentObj = $(obj).parent().parent();
    var focusPhotoObj = parentObj.parent().siblings(".focus-photo");
    var smallImg = $(obj).siblings(".img-box").children("img").attr("src");
    $(obj).parent().remove(); //删除的LI节点
    //检查是否为封面
    if (focusPhotoObj.val() == smallImg) {
        focusPhotoObj.val("");
        var firtImgBox = parentObj.find("li .img-box").eq(0); //取第一张做为封面
        firtImgBox.addClass("selected");
        focusPhotoObj.val(firtImgBox.children("img").attr("src")); //重新给封面的隐藏域赋值
    }
}