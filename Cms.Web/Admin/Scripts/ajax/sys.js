
var xmlHttp;
if (window.ActiveXObject) {
    xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
}
else if (window.XMLHttpRequest) {
    xmlHttp = new window.XMLHttpRequest();
}

function ajax(Url) {
    var ajaxUrl = Url + "&e=" + Math.random();
    xmlHttp.open("POST", ajaxUrl, false);
    xmlHttp.send();
    var Result = unescape(xmlHttp.responseText);
    return Result;
}

function ajaxGet(Url) {
    var ajaxUrl = Url + "&e=" + Math.random();
    xmlHttp.open("GET", ajaxUrl, false);
    xmlHttp.send();
    var Result = unescape(xmlHttp.responseTexst);
    return Result;
}

function loadHtmlByUri(uri) {
    return ajaxGet(uri);
}

function g(id) {
    return document.getElementById(id);
}
/*//post方法提交  编码 utf-8
$(function () {
    $("#btnSubmit").click(function () {
        if ($("#txtName").val() == "") {
            alert("姓名不能为空!");
            $("#txtName").focus();
            return;
        } else if ($("#txtContent").val() == "") {
            alert("内容不能为空!");
            $("#txtContent").focus();
            return;
        }
        else {
            var content = $("#txtContent");
            var name = $("#txtName");
            $.ajax({
                type: "POST",
                url: "/Check/checkreg.aspx",
                data: { username: name.val(),contents: content.val() },
                contentType: "application/x-www-form-urlencoded;charset=utf-8",
                error: function (xmlobj, errtext) {
                    debugger;
                },
                success: function (msg) {
                    alert("提交成功!");
                    window.location.href = url;
                }
            });
        }
    })
})
*/

//读写cookis
function cook(ckName, ckValue, ckDate) {
    if (!ckName && !ckValue && !ckDate) {
        return false;
    }
    //写入cookies
    else if (ckName && ckValue) {
        //设置过期时间
        var day = new Date();
        var expDay = new Date();
        if (!ckDate || ckDate == 'undefined')
            ckDate = 0;
        expDay.setTime = day.getTime() * 3600000 * 24 * ckDate;
        try {
            document.cookie = escape(ckName.Trim()) + '=' + escape(ckValue) + ';expiress' + expDay.toGMTString();
        }
        catch (ee) { return false; }
        return true;
    }
    //读取Cookie
    else if (ckName && !ckValue) {
        ckName = escape(ckName);
        var cookieList = document.cookie.split(';');
        for (var j = 0; j < cookieList.length; j++) {
            var s = cookieList[j].split('=')[0].Trim();
            if (ckName.Trim() == cookieList[j].split('=')[0].Trim()) {
                return unescape(cookieList[j].split('=')[1]);
            }
        }
        return '';
    }
}



//获取url参数
function RequestFrom(key) {
    var locString = location.search;
    var reg = new RegExp("(\\?|\\&)" + key + "=([^\\&]*)(\\&?)", "i").exec(locString);
    if (reg != null) {
        return RegExp.$2;
    }
    else {
        return "";
    }
}


String.prototype.replaceAll = function (val, Reg) {
    return this.replace(new RegExp(val, "gm"), Reg);
}

//判断时间大小
function checkDate(dateStart, dateEnd) {

    var a = dateStart.split('-');
    var b = dateEnd.split('-');
    var startDate = new Date(a[0], a[1], a[2]);
    startDate = startDate.getTime();
    var endDate = new Date(b[0], b[1], b[2]);
    endDate = endDate.getTime();
    if (startDate > endDate)
        return false
    else
        return true;
}

//验证是否是数字
function isNumber(ber) {
    var reg = /^\d*$/;
    if (reg.test(ber)) {
        return true;
    }
    else
    { return false; }

}

String.prototype.Trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.LTrim = function () {
    return this.replace(/(^\s*)/g, "");
}
String.prototype.RTrim = function () {
    return this.replace(/(\s*$)/g, "");
}


/*存储过程分页通用方法*/
/*
* PageDataCount 总数据
* PageSize 每页条数
* thisPage 当前页
* box 容器
*/
function PageList(PageDataCount, PageSize, thisPage, box) {
    //总页数

    var countPage = parseFloat(PageDataCount) / parseFloat(PageSize);
    countPage = Math.ceil(countPage);
    countPage = parseInt(countPage);

    $("#" + box).myPagination({
        currPage: thisPage,
        pageCount: countPage,
        pageSize: 10,
        cssStyle: 'meneame',
        PtDataCount:PageDataCount
    });
    $("#" + box + " a").on("click", function () {
        goPage($(this).attr("title"));
    })

    
}



/*存储过程分页通用方法*/
/*
* PageDataCount 总数据
* PageSize 每页条数
* thisPage 当前页
* box 容器
* Len 页码长度
*/
function PageList2(PageDataCount, PageSize, thisPage, box, Len) {
    //总页数

    var countPage = parseFloat(PageDataCount) / parseFloat(PageSize);
    countPage = Math.ceil(countPage);
    countPage = parseInt(countPage);




    $("#" + box).myPagination({
        currPage: thisPage,
        pageCount: countPage,
        pageSize: Len,
        cssStyle: 'meneame',
        PtDataCount:PageDataCount
    });
    $("#" + box + " a").on("click", function () {
        goPage($(this).attr("title"));
    })


   
}

function loadJsByUrl(url) {
    var head = document.getElementsByTagName('HEAD').item(0);
    var js = document.createElement("script");
    js.type = "text/javascript";
    js.src = url;
    head.appendChild(js);

}


function loadadByUrl(url, gpuri, imguri, fun) {
    var head = document.getElementsByTagName('HEAD').item(0);
    var js = document.createElement("script");
    js.type = "text/javascript";
    js.src = url;
    head.appendChild(js);
    var d = setInterval(function () {
        if (eval(fun) != 'defined') {
            eval(fun + '(\'' + gpuri + '\',\'' + imguri + '\')');
            clearInterval(d);
        }
    }, 500)


}


function loadjs() {
    var currUrl = document.location.pathname;
    currUrl = currUrl.substr(0, currUrl.lastIndexOf(".")) + ".js";
    currUrl = "/js" + currUrl;
    try {
        loadJsByUrl(currUrl);
    }
    catch (e)
    { }
}

//进行四舍五入
Number.prototype.toFx = function () {
    var x = this;
    var f_x = parseFloat(x);
    if (isNaN(f_x)) {
        alert('输入不正确，请输入正确的阿拉伯数字');
        return false;
    }
    f_x = Math.round(x * 100) / 100;
    var s_x = f_x.toString();
    var pos_decimal = s_x.indexOf('.');
    if (pos_decimal < 0) {
        pos_decimal = s_x.length;
        s_x += '.';
    }
    while (s_x.length <= pos_decimal + 2) {
        s_x += '0';
    }
    return s_x;
}


function getInputVal(box) {
    //增加,修改的时候遍历参数     
    //遍历参数
    var parList = "";
    jQuery("#" + box).find(":input").each(function (i) {
        if (jQuery(this).attr("type") != 'checkbox' && jQuery(this).attr("type") != 'radio' && jQuery(this).attr("name")) {
            parList = parList + '&' + jQuery(this).attr('name') + '=' + encodeURIComponent(jQuery(this).val());
        }
    }); //each end  encodeURIComponent
    jQuery("#" + box).find("input:checked").each(function () {
        if (jQuery(this).attr("name")) {
            parList += "&" + jQuery(this).attr('name') + '=' + encodeURIComponent(jQuery(this).val());
        }
    })//each end
    return parList;
}

function ClearInputVal(box) {
    var parList = "";
    jQuery("#" + box).find(":input").each(function (i) {
        $(this).val("");
    });
}

function checkUser(val) {
    var reg = /^[0-9a-z_A-Z]{6,12}$/;
    return reg.test(val);
}


//验证E-mail
function checkEmail(val) {
    var reg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    return reg.test(val)
}

//收藏夹
function addFavoriteTag() {
    if (document.all) {
        window.external.addFavorite('http://www.186yl.com', '186娱乐人才网');
    }
    else if (window.sidebar) {
        window.sidebar.addPanel('186娱乐人才网', 'http://www.186yl.com', "");
    }
}


//加载新标签页面
function gotoWin(strUrl) {
    var a = document.createElement("a");
    a.setAttribute("href", strUrl);
    a.style.display = "none";
    a.setAttribute("target", "_blank");
    document.body.appendChild(a);
    if (document.all) {
        a.click();
    }
    else {
        var evt = document.createEvent("MouseEvents");
        evt.initEvent("click", true, true);
        a.dispatchEvent(evt);
    }
}

function removeHTMLTag(str) {
    str = str.replace(/<\/?[^>]*>/g, ''); //去除HTML tag
    str = str.replace(/[ | ]*\n/g, '\n'); //去除行尾空白
    //str = str.replace(/\n[\s| | ]*\r/g,'\n'); //去除多余空行
    str = str.replace(/&nbsp;/ig, ''); //去掉&nbsp;
    return str;
}

function removeHTMLTag_id(id) {
    var str = $("#" + id).val();
    str = str.replace(/<\/?[^>]*>/g, ''); //去除HTML tag
    str = str.replace(/[ | ]*\n/g, '\n'); //去除行尾空白
    //str = str.replace(/\n[\s| | ]*\r/g,'\n'); //去除多余空行
    str = str.replace(/&nbsp;/ig, ''); //去掉&nbsp;
    $("#" + id).val(str);
}



//弹出框，4秒关闭
//title 标题 
//strTip 提示语
//tipType 1,成功,2,警告，3错误
function showMsgBox(title, strTip, tipType) {
    var diag = new Dialog();
    title = title == "" ? "186温馨提示您:" : title;
    diag.Title = title;
    diag.AutoClose = 4;
    diag.OKEvent = function () { diag.close(); }; //点击确定后调用的方法 
    diag.Width = 300;
    diag.Height = 102;
    //wan,警告，ok,成功，err,错误
    var img = "";
    if (tipType == 1) {
        img = 'ok';
    }
    else if (tipType == 2) {
        img = 'wan';
    }
    else {
        img = 'err';
    }
    strTip = encodeURIComponent(strTip);
    diag.URL = '/commd_file/alert.html?&alert=' + strTip + '&ico=' + img + '&t=' + new Date().getTime();
    diag.show();
}

//全选
function CheckedAll(obj, box) {
    var State = obj.checked;
    $("." + box).attr("checked", State);
}

//手机
function isMobila(s) {
    var patrn = /(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/;
    if (!patrn.exec(s)) {
        return false;
    }
    return true;
}
//等比例 缩放图片 高度不变
function AutoResizeImage(maxWidth, maxHeight, objImg) {
    var img = new Image();
    img.src = objImg.src;
    var hRatio;
    var wRatio;
    var Ratio = 1;
    var w = img.width;
    var h = img.height;
    wRatio = maxWidth / w;
    hRatio = maxHeight / h;
    if (maxWidth == 0 && maxHeight == 0) {
        Ratio = 1;
    } else if (maxWidth == 0) {//
        if (hRatio < 1) Ratio = hRatio;
    } else if (maxHeight == 0) {
        if (wRatio < 1) Ratio = wRatio;
    } else if (wRatio < 1 || hRatio < 1) {
        Ratio = (wRatio <= hRatio ? wRatio : hRatio);
    }
    if (Ratio < 1) {
        w = w * Ratio;
        h = h * Ratio;
    }
    objImg.height = maxHeight; // objImg.height =h;
    objImg.width = w;
}