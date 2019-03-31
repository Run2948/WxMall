<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lotteryedit.aspx.cs" Inherits="Admin_lottery_lotteryedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
<title>编辑管理员</title>
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
                        editor.hideDialog();
                    }
                });
            });
        });
    });
</script>
<script type="text/javascript">
    $(function () {
        //初始化编辑器
        var editor = KindEditor.create('.editor', {
            width: '800px',
            height: '230px',
            resizeType: 1,
            uploadJson: '../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            fileManagerJson: '../tools/upload_ajax.ashx?action=ManagerFile',
            allowFileManager: true
        });
        var editorMini = KindEditor.create('.editor-mini', {
            width: '800px',
            height: '230px',
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


    function stime() {
        var endtimeTf = $dp.$('tbetime');

        WdatePicker({
            maxDate: '#F{$dp.$D(\'tbstime\')}',
            dateFmt: "yyyy-MM-dd HH:mm:ss",
            onpicked: function () { endtimeTf.focus(); }
        });
    }
    function etime() {
        WdatePicker({
            minDate: '#F{$dp.$D(\'tbstime\')}',
            dateFmt: "yyyy-MM-dd HH:mm:ss"
        });
    }

   // var t = setInterval(xzimg, 3000);
    var i = 0;
    function xzimg(url) {
        i++;
        window.open("../Download.aspx?url=" + encodeURIComponent(url)); ////////
        map.panTo(new BMap.Point(116.31557 + i * 0.029078, 39.93381));
    }
//    map.addEventListener("click", function () {
//        clearInterval(t);
//    });
    </script>
    <script type="text/javascript">
        function yz() {
            var jx = document.getElementById("tbjxname").value;
            var jx2 = document.getElementById("tbjxname2").value;
            var jx3 = document.getElementById("tbjxname3").value;
            var jx4 = document.getElementById("tbjxname4").value;
            var jx5 = document.getElementById("tbjxname5").value;
            var jx6 = document.getElementById("tbjxname6").value;
            var msg = document.getElementById("smegs");
            msg.innerHTML = "";
            var bl = true;
            if (jx.length > 0){
                var jp = document.getElementById("tbjpname").value;
                var sl = document.getElementById("tbnumber").value;
                var gl = document.getElementById("tbgl").value;
               
                if (jp.length == 0) {
                    msg.innerHTML+= "奖项一奖品名称不能为空;";
                    bl = false;
                }
                if (sl.length == 0 || sl<1) {
                    msg.innerHTML += "奖项一数量不能为空或不能小于零;";
                    bl = false;
                }
                if (gl.length == 0 || gl < 1) {
                    msg.innerHTML += "奖项一概率不能为空或不能小于零;";
                    bl = false;
                }
               
            }
            if (jx2.length > 0) {
                var jp = document.getElementById("tbjpname2").value;
                var sl = document.getElementById("tbnumber2").value;
                var gl = document.getElementById("tbgl2").value;
                var bl = true;
                if (jp.length == 0) {
                    msg.innerHTML += "奖项二奖品名称不能为空;";
                    bl = false;
                }
                if (sl.length == 0 || sl < 1) {
                    msg.innerHTML += "奖项二数量不能为空或不能小于零;";
                    bl = false;
                }
                if (gl.length == 0 || gl < 1) {
                    msg.innerHTML += "奖项二概率不能为空或不能小于零;";
                    bl = false;
                }
                
            }
            if (jx3.length > 0) {
                var jp = document.getElementById("tbjpname3").value;
                var sl = document.getElementById("tbnumber3").value;
                var gl = document.getElementById("tbgl3").value;
                var bl = true;
                if (jp.length == 0) {
                    msg.innerHTML += "奖项三奖品名称不能为空;";
                    bl = false;
                }
                if (sl.length == 0 || sl < 1) {
                    msg.innerHTML += "奖项三数量不能为空或不能小于零;";
                    bl = false;
                }
                if (gl.length == 0 || gl < 1) {
                    msg.innerHTML += "奖项三概率不能为空或不能小于零;";
                    bl = false;
                }
               
            }
            if (jx4.length > 0) {
                var jp = document.getElementById("tbjpname4").value;
                var sl = document.getElementById("tbnumber4").value;
                var gl = document.getElementById("tbgl4").value;
                var bl = true;
                if (jp.length == 0) {
                    msg.innerHTML += "奖项四奖品名称不能为空;";
                    bl = false;
                }
                if (sl.length == 0 || sl < 1) {
                    msg.innerHTML += "奖项四数量不能为空或不能小于零;";
                    bl = false;
                }
                if (gl.length == 0 || gl < 1) {
                    msg.innerHTML += "奖项四概率不能为空或不能小于零;";
                    bl = false;
                }
               
            }
            if (jx5.length > 0) {
                var jp = document.getElementById("tbjpname5").value;
                var sl = document.getElementById("tbnumber5").value;
                var gl = document.getElementById("tbgl5").value;
                var bl = true;
                if (jp.length == 0) {
                    msg.innerHTML += "奖项五奖品名称不能为空;";
                    bl = false;
                }
                if (sl.length == 0 || sl < 1) {
                    msg.innerHTML += "奖项五数量不能为空或不能小于零;";
                    bl = false;
                }
                if (gl.length == 0 || gl < 1) {
                    msg.innerHTML += "奖项五概率不能为空或不能小于零;";
                    bl = false;
                }
              
            }
            if (jx6.length > 0) {
                var jp = document.getElementById("tbjpname6").value;
                var sl = document.getElementById("tbnumber6").value;
                var gl = document.getElementById("tbgl6").value;
                var bl = true;
                if (jp.length == 0) {
                    msg.innerHTML += "奖项六奖品名称不能为空;";
                    bl = false;
                }
                if (sl.length == 0 || sl < 1) {
                    msg.innerHTML += "奖项六数量不能为空或不能小于零;";
                    bl = false;
                }
                if (gl.length == 0 || gl < 1) {
                    msg.innerHTML += "奖项六概率不能为空或不能小于零;";
                    bl = false;
                }
               
            }
            return bl;
        }
    </script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="lotterylist.aspx?typeid=<%=Request.QueryString["typeid"].ToString() %>" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="lotterylist.aspx?typeid=<%=Request.QueryString["typeid"].ToString() %>"><span><%=classname%></span></a>
  <i class="arrow"></i>
  <span>编辑<%=classname%></span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑抽奖信息</a></li>
        <li><a href="javascript:;" onclick="tabs(this);" >编辑奖品信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>活动名称</dt>
    <dd>
      <div>
      <asp:TextBox ID="tbname" runat="server" CssClass="input normal" datatype="*4-20" sucmsg=" " ></asp:TextBox>
      <span class="Validform_checktip">*</span>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>活动开始时间</dt>
    <dd>
      <div class="input-date">
                    <asp:TextBox ID="tbstime" runat="server" CssClass="input date" onfocus="stime()"
                        datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期"
                        sucmsg=" " />
                    <i>日期</i>
     </div>
    </dd>
  </dl>
  <dl>
    <dt>活动结束时间</dt>
    <dd><div class="input-date">
                    <asp:TextBox ID="tbetime" runat="server" CssClass="input date" onfocus="etime()"
                        datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期"
                        sucmsg=" " />
                    <i>日期</i>
     </div>
     </dd>
  </dl> 
  <dl>
    <dt>活动照片展示</dt>
    <dd><asp:TextBox ID="photoUrl" runat="server" CssClass="input normal" />
                <input type="button" id="image1" value="选择图片" /> </dd>
  </dl>
  <dl>
    <dt>活动描述</dt>
    <dd><textarea id="tbinfo" runat="server" rows="5" cols="20" class="input normal" onpropertychange="if(value.length>500) value=value.substr(0,500)"></textarea>
    <br />
     <span class="Validform_checktip">最多500字</span>
    </dd>
  </dl>
  <dl>
    <dt>是否显示奖品数量</dt>
    <dd><div class="rule-single-checkbox">
          <asp:CheckBox ID="isnum" runat="server" Checked="True" />
      </div>
      </dd>
  </dl>
  <dl>
    <dt>每人参与的总次数</dt>
    <dd><asp:TextBox ID="tbtotal" runat="server" Width="50" CssClass="input normal" datatype="n"  sucmsg=" " onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" >1</asp:TextBox>
     <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>每人每天可参与次数</dt>
    <dd><asp:TextBox ID="tbdaynum" runat="server" Width="50" CssClass="input normal" datatype="n"  sucmsg=" " onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" >1</asp:TextBox>
     <span class="Validform_checktip">*</span>
    </dd>
  </dl>
</div>
<!--/内容-->
<div class="tab-content"  style="display: none">

<center>
<table border="0" cellpadding="20"  cellspacing="20" class="ltable">
  <tr>
   <th width="50" align="center"></th>
   <th width="230" align="center">奖项名称</th>
   <th width="230" align="center">奖品</th>
   <th width="80" align="center">奖品数量</th>
   <th width="80" align="center">中奖概率</th>
  </tr>
  <tr>
  <td width="50" align="center">奖项一</td>
  <td width="230" align="center"><asp:TextBox ID="tbjxname" Width="230" MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="230" align="center"><asp:TextBox ID="tbjpname" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbnumber" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"  ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbgl" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox>%</td>
  </tr>
   <tr>
  <td width="50" align="center">奖项二</td>
  <td width="230" align="center"><asp:TextBox ID="tbjxname2" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="230" align="center"><asp:TextBox ID="tbjpname2" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbnumber2" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"  ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbgl2" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox>%</td>
  </tr>
    <tr>
  <td width="50" align="center">奖项三</td>
  <td width="230" align="center"><asp:TextBox ID="tbjxname3" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="230" align="center"><asp:TextBox ID="tbjpname3" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbnumber3" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbgl3" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox>%</td>
  </tr>
    <tr>
  <td width="50" align="center">奖项四</td>
  <td width="230" align="center"><asp:TextBox ID="tbjxname4" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="230" align="center"><asp:TextBox ID="tbjpname4" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbnumber4" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbgl4" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox>%</td>
  </tr>
    <tr>
  <td width="50" align="center">奖项五</td>
  <td width="230" align="center"><asp:TextBox ID="tbjxname5" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="230" align="center"><asp:TextBox ID="tbjpname5" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbnumber5" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbgl5" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox>%</td>
  </tr>
    <tr>
  <td width="50" align="center">奖项六</td>
  <td width="230" align="center"><asp:TextBox ID="tbjxname6" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="230" align="center"><asp:TextBox ID="tbjpname6" Width="230"  MaxLength="50" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbnumber6" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox></td>
  <td width="80" align="center"><asp:TextBox ID="tbgl6" Width="50" runat="server" CssClass="input normal"  onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox>%</td>
  </tr>
  <tr>
  <td colspan="5" align="left" style=" color:Red">
   &nbsp;&nbsp;&nbsp;请依次填写奖项<br />
    &nbsp;&nbsp; 提示：1、奖品名称不能超过50个字 &nbsp;&nbsp; 2、奖品不能超过50个字 &nbsp;&nbsp;  3、奖品数量必须大于0  &nbsp;&nbsp; 4、中奖概率必须大于0 <br />
     &nbsp;&nbsp;&nbsp;<span id="smegs" style=" font-size:18px;"></span>
  </td>
  </tr>
</table>
</center>
</div>
<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" OnClientClick="return yz()" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
