//检测账号
function getusername() {
    var username = document.getElementById("UserName").value;
    if (username != "") {
        //传参路径
        var uri = "/Check/checkreg.aspx?opt=checkusername";
        uri += "&username=" + username;
        var result = ajax(uri);
        $("#checkTip").eq(2).empty();
        $("#checkTip").show();
        if (result == "1") {
            $("#checkTip").find("td").html("该用户账号已经被注册");
        }
        else {
            $("#checkTip").find("td").html("该用户账号未被注册");
        }
    }
}

//检测手机号码
function getmobiephone(obj) {
    var mobiephone = document.getElementById("mobiephone").value;
    if (mobiephone != "") {
        //传参路径
        var uri = "/Check/checkreg.aspx?opt=checkmobiephone";
        uri += "&mobiephone=" + mobiephone;
        var result = ajax(uri);
        $("#checkTip").eq(2).empty();
        $("#checkTip").show();
        if (result == "1") {
            $("#checkTip").find("td").html("该手机号码已经被使用");
        }
        else {
            $("#checkTip").find("td").html("该手机号码未被使用");
        }
    }
    $("#UserName").val(obj.value);
    return true 
}