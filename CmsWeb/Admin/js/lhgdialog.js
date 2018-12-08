//========================基于lhgdialog插件========================
//可以自动关闭的提示，基于lhgdialog插件
function jsprint(msgtitle, url, msgcss, callback) {
    var iconurl = "";
    switch (msgcss) {
        case "Success":
            iconurl = "32X32/succ.png";
            break;
        case "Error":
            iconurl = "32X32/fail.png";
            break;
        default:
            iconurl = "32X32/hits.png";
            break;
    }
    $.dialog.tips(msgtitle, 2, iconurl);
    if (url == "back") {
        frames["mainframe"].history.back(-1);
    } else if (url != "") {
//        frames["mainframe"].location.href = url;
    }
    //执行回调函数
    if (arguments.length == 4) {
        callback();
    }
}
//弹出一个Dialog窗口
function jsdialog(msgtitle, msgcontent, url, msgcss, callback) {
    var iconurl = "";
    var argnum = arguments.length;
    switch (msgcss) {
        case "Success":
            iconurl = "success.gif";
            break;
        case "Error":
            iconurl = "error.gif";
            break;
        default:
            iconurl = "alert.gif";
            break;
    }
    var dialog = $.dialog({
        title: msgtitle,
        content: msgcontent,
        fixed: true,
        min: false,
        max: false,
        lock: true,
        icon: iconurl,
        ok: true,
        close: function () {
            if (url == "back") {
                history.back(-1);
            } else if (url != "") {
                location.href = url;
            }
            //执行回调函数
            if (argnum == 5) {
                callback();
            }
        }
    });
}
//打开一个最大化的Dialog
function ShowMaxDialog(tit, url) {
    $.dialog({
        title: tit,
        content: 'url:' + url,
        min: false,
        max: false,
        lock: false
    }).max();
}
//执行回传函数
function ExePostBack(objId, objmsg) {
    if ($(".checkall input:checked").size() < 1) {
        $.dialog.alert('对不起，请选中您要操作的记录！');
        return false;
    }
    var msg = "删除记录后不可恢复，您确定吗？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    $.dialog.confirm(msg, function () {
        __doPostBack(objId, '');
    });
    return false;
}
//检查是否有选中再决定回传
function CheckPostBack(objId, objmsg) {
    var msg = "对不起，请选中您要操作的记录！";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    if ($(".checkall input:checked").size() < 1) {
        $.dialog.alert(msg);
        return false;
    }
    __doPostBack(objId, '');
    return false;
}
//执行回传无复选框确认函数
function ExeNoCheckPostBack(objId, objmsg) {

    var msg = "删除记录后不可恢复，您确定吗？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    $.dialog.confirm(msg, function () {
        __doPostBack(objId, '');
    });
    return false;
}
//======================以上基于lhgdialog插件======================