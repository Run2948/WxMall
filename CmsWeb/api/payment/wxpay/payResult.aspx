<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payResult.aspx.cs" Inherits="api_payment_wxpay_payResult" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;">
    <meta name="format-detection" content="telephone=no">
    <link href="images/style.css" rel="stylesheet" type="text/css" />
    <link href="images/mystyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/list.css" />
    <script type="text/javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js"></script>
    <script src="../../../Admin/Scripts/jquery/jquery.query.js" type="text/javascript"></script>
    <title>交易结果</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="loading">
            <div class="bk"></div>
            <div class="cont">
                <img src="images/loading.gif" alt="loading...">正在查询订单...
            </div>
        </div>
        <div id="result_div" style="display: none; background-color: #FFF;">
            <div class="div_content">
                <div id="result_success" style="display: none;">

                    <div class="div_ret">
                        <img src="images/success.png" class="img_ret" />
                        <span class="span_success">交易成功!</span>
                    </div>
                    <div class="div_btn">
                        <a href="#" class="btn_submit returnpage" style="margin-left:4%; margin-right:4%; ">返回</a>
                    </div>

                </div>
                <div id="result_fail" style="display: none; background-color: #FFF;">

                    <div class="div_ret">
                        <img src="images/fail.png" class="img_ret" />
                        <span class="span_fail">查询结果失败!</span>
                    </div>
                    <div id="ordererr_info"></div>
                    
                    <div class="div_btn">
                        <span class="btn_confirm_shouye" id="lookorder">再查询！</span>&nbsp;&nbsp;
                        <a href="#" class="btn_confirm returnpage"><span style="color: #FFF;">返回</span></a>
                        <br />

                    </div>

                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        var openid = $.query.get("openid");
        var otid = $.query.get("otid");
        var wid = $.query.get("wid");
        var rpage = $.query.get("rpage");

        $(function () {

            $(".returnpage").attr("href", rpage);

            //$("#result_div").show();
            //$("#result_fail").show();
            //$("#loading").hide();

            setTimeout(function () {
                //查询订单状态
                lookOrderInfo();
            }, 1500);

            $("#lookorder").click(function () {
                lookOrderInfo();
            });

        });
        //查询订单
        function lookOrderInfo() {
            $("#loading").show();
            $("#result_div").hide();
            $("#result_success").hide();
            $("#result_fail").hide();

            var radNum = Math.random();
            $.get("payinfo.ashx?wid=" + wid + "&openid=" + openid + "&radnum=" + radNum + "&act=orderRet&otid=" + otid,
               { Action: "get" }, function (data, textStatus) {
                   if (data.ret == "ok") {
                       $("#result_div").show();
                       $("#result_success").show();
                   }
                   else {
                       $("#result_div").show();
                       $("#result_fail").show();
                       $("#result_success").hide();
                       $("#ordererr_info").text(data.content);
                       //setTimeout(function () { window.location.href = $("#a_returnIndex").attr("href"); }, 1500);
                   }
                   $("#loading").hide();
               });
        }

    </script>

</body>
</html>
