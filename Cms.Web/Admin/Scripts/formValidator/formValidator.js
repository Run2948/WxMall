$(document).ready(function () {
    $.formValidator.initConfig({ formID: "form1", debug: false, submitOnce: true,
        onError: function (msg, obj, errorlist) {
            $("#errorlist").empty();
            $.map(errorlist, function (msg) {
                $("#errorlist").append("<li>" + msg + "</li>")
            });
            alert(msg);
        },
        submitAfterAjaxPrompt: '有数据正在异步验证，请稍等...'
    });
    var strusername = $("#UserName").val();
    $("#UserName").formValidator({ onShow: "请输入用户名,只有输入\"maodong\"才是对的", onFocus: "用户名至少5个字符,最多10个字符", onCorrect: "该用户名可以注册" }).inputValidator({ min: 5, max: 10, onError: "你输入的用户名非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
	    .ajaxValidator({
	        dataType: "html",
	        async: true,
	        url: "/user/Verification.ashx?UserName=" + strusername,
	        success: function (data) {
	            if (data.indexOf("此用户名可以注册!") > 0) return true;
	            if (data.indexOf("此用户名已存在,请填写其它用户名!") > 0) return false;
	            return false;
	        },
	        buttons: $("#button"),
	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
	        onError: "该用户名不可用，请更换用户名",
	        onWait: "正在对用户名进行合法性校验，请稍候..."
	    }).defaultPassed(); ;


});