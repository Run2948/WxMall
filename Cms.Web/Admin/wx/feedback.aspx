<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="Admin_wx_feedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.3.2.min.js"></script>
    <link href="css/mobilemain.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //加载信息
        function LoadMsg() {
            var SendUserName = document.getElementById("hdOpenid").value;
            $.ajax({
                type: "POST",
                url: "ashx/GetMsg.ashx?type=GetMsg&SendUserName=" + SendUserName,
                data: "",
                success: function (msg) {
                    $("#content").html(msg);
                    $("#content").scrollTop(15000);
                }
            });
        }

        function LoadOnlineUser() {
            $.ajax({
                type: "POST",
                url: "ashx/GetMsg.ashx?type=GetUser",
                data: "",
                success: function (msg) {
                    $("#sidebar").html(msg);
                }
            });
        }


        function SendMsg() {
            var openid = document.getElementById("hdOpenid").value;
            var msg = encodeURI(document.getElementById("txtMsg").value);
            if (openid == null || openid == "") {
                alert("请选择用户！");
                return;
            }

            if (msg == null || msg == "") {
                alert("消息不能为空！");
                return;
            }

            $.ajax({
                type: "POST",
                url: "ashx/GetMsg.ashx?type=SendMsg&Msg=" + msg + "&Openid=" + openid,
                data: "",
                success: function (msg) {
                    UpdateMsgStatus(openid);
                    LoadMsg();
                    document.getElementById("txtMsg").value = "";

                }
            });

        }


        function UpdateMsgStatus(openid) {
            $.ajax({
                type: "POST",
                url: "ashx/GetMsg.ashx?type=UpdateMsgStatus&Openid=" + openid,
                data: "",
                success: function (msg) {
                }
            });
        }




        function GetChat(openid) {
            LoadMsg();
            UpdateMsgStatus(openid);
            document.getElementById("hdOpenid").value = openid;
            document.getElementById("divtest" + openid).style.backgroundColor = '#0094ff';
            //$("#content").scrollTop(15000);
        }

        $(function () {
            //LoadOnlineUser();

            setInterval("LoadMsg()", 1000);
            setInterval("LoadOnlineUser()", 1000);
            //$("#content").scrollTop(15000);
           // LoadOnlineUser();
            //LoadMsg();
        });


    </script>
</head>
<body>
   <form id="form1" runat="server">
        <div id="container">
            <div id="header" style="text-align: center; font-size: 18px; padding-top: 20px;">客服聊天系统</div>
            <div id="mainContent">
                <div id="sidebar">
                </div>
                <div id="content">

                    <span id="msg_end" style="height: 0px; overflow: hidden"></span>
                </div>
            </div>
            <div id="footer">
                <table>
                    <tr>
                        <td style="text-align: center; padding-left: 100px;">
                            <textarea id="txtMsg" rows="5" cols="80"></textarea></td>
                        <td style="text-align: center;">
                            <input type="button" style="cursor:pointer;width: 80px; height: 40px;" value="发送" onclick='SendMsg()' /></td>
                    </tr>
                </table>
                <input id="hdOpenid" type="hidden" value="" />
            </div>
        </div>
    </form>`
</body>
</html>
