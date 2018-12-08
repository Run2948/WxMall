<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>在线文件管理</title>
    <link href="images/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="js/main.js" type="text/javascript"></script>
    <script src="js/jqModal.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#checkedAll").click(function () {
                if ($(this).attr("checked") == true) { // 全选
                    $("input[type='checkbox']").each(function () {
                        $(this).attr("checked", true);
                    });
                } else { // 取消全选
                    $("input[type='checkbox']").each(function () {
                        $(this).attr("checked", false);
                    });
                }
            });
        });

        $().ready(function () {
            $('#divCreate').jqm({ trigger: '#create' });
            $('#divRename').jqm({ trigger: '#rename' });
            $('#divDelete').jqm({ trigger: '#delete' });
            $('#divUpload').jqm({ trigger: '#upload' });
            $('#divCopy').jqm({ trigger: '#copy' });
            $('#divPaste').jqm({ trigger: '#paste' });
            $('#divCut').jqm({ trigger: '#cut' });
            $('#divCreateFile').jqm({ trigger: '#createfile' });
            $('#divdownload').jqm({ trigger: '#download' });
        });

    
    </script>
    <script type="text/javascript">
        $(function () {

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
    <style>
        *
        {
            margin: 0;
            padding: 0;
            list-style-type: none;
        }
        img, a
        {
            border: 0;
        }
        
        .piccon li
        {
            float: left;
            padding: 0 10px;
        }
        #preview
        {
            position: absolute;
            border: 1px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
        }
        .jqmWindow{ background:#fff; line-height:30px; width:280px; border:#000 solid 1px;}
        .jqmWindow h4{border-bottom:#000 solid 1px;}
        .jqmWindow p{ margin-top:10px; margin-bottom:10px;}
        .jqmWindow input{ float:right;}
        .cifom{ margin-right:20px;}
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span></span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                   
                    <li><a href="Default.aspx">刷新</a></li>
                    <li><a href="javascript:void(0);" id="delete">删除</a></li>
                    <li>
                        <div class="upload-box upload-album" style="float: left;">
                        </div>
                        <input type="hidden" name="hidFocusPhoto" id="hidFocusPhoto" runat="server" class="focus-photo" /></li>
                    <li><a href="javascript:void(0);" id="download">下载</a></li>
                </ul>
            </div>
        </div>
    </div>
    <!--/工具栏-->
    <div id="divUpload" class="jqmWindow" style="display: none;">
        <h4>
            文件上传</h4>
        选择文件：<asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnPanel3Cancel" runat="server" Text="取消" />
        <asp:Button ID="btnUpload" CssClass="cifom" runat="server" Text="确定" OnClick="btnUpload_Click" />
        
    </div>
    <div id="divDelete" class="jqmWindow" style="display: none;">
        <h4>
            删除文件</h4>
        <p>
            确定删除选中的文件或文件夹吗？
            </p>
             <asp:Button ID="Button2" runat="server" Text="取消" />
            <asp:Button ID="btnDelete" CssClass="cifom" runat="server" Text="确定" OnClick="btnDelete_Click" />
          
    </div>
    <div id="divdownload" class="jqmWindow" style="display: none;">
        <h4>
            下载图片</h4>
        <p>
            确定下载选中的图片吗？
        </p>
        <asp:Button ID="Button8" runat="server" Text="取消" />
        <asp:Button ID="btndownload" CssClass="cifom" runat="server" Text="确定" OnClick="btndownload_Click" />
        
    </div>
    <div style="padding: 5px; display: none;">
        <strong>路径: </strong>
        <asp:Label ID="lblCurrentPath" Font-Bold="true" runat="server" Font-Names="Verdana"
            Font-Size="12px"></asp:Label></div>
    <div>
        <ul class="piccon">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                OnRowDataBound="GridView1_RowDataBound" CssClass="ltable" BorderStyle="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                             <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                        <HeaderTemplate>
                            <input id="checkedAll" type="checkbox" name="checkedAll">
                        </HeaderTemplate>
                        <ItemStyle Width="3%" Wrap="False" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:LinkButton ID="LinkButton1" rel='<%#Eval("FullNameOne")%>' runat="server" CssClass="preview"
                                    CommandArgument='<%#Eval("FullName") %>' Text='<%#Eval("Name")%>'></asp:LinkButton>
                            </li>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LastWriteDate" HeaderText="上传日期">
                        <ItemStyle Width="12%" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Size" HeaderText="大小" DataFormatString="{0} KB">
                        <ItemStyle HorizontalAlign="Right" Width="5%" Wrap="False" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="White" />
                <RowStyle />
                <PagerStyle BackColor="White" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" ForeColor="White" />
                <HeaderStyle BackColor="#006699" ForeColor="White" />
            </asp:GridView>
        </ul>
    </div>
    </form>
</body>
</html>
