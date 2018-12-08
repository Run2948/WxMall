<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Admin_index" ValidateRequest="false" EnableEventValidation="false"%>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>后台管理中心</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="scripts/jquery/jquery.nicescroll.js"></script>
<script type="text/javascript" src="scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="js/layout.js"></script>
<script src="scripts/jQuery-Tree-Control/js/jquery.tree.js" type="text/javascript"></script>
<script type="text/javascript">
    //页面加载完成时
    $(function () {
        //检测IE
        if ('undefined' == typeof (document.body.style.maxHeight)) {
            window.location.href = 'ie6update.html';
        }
        
    });
    //左边菜单树
    $(function () {
        $('#files').tree({
            //expanded: 'li:first'
        });
    }); 
    $(function () {
        $('#syscofig').tree({
            expanded: 'li:first'
        });
    });
    $(function () {
        $('#userlist').tree({
            expanded: 'li:first'
        });
    });
    $(function () {
        $('#orderlist').tree({
            expanded: 'li:first'
        });
    });
    $(function () {
        $('#plug').tree({
            expanded: 'li:first'
        });
    });
    //页面尺寸改变时
    $(window).resize(function () {
        navresize();
    });
    //导航菜单显示和隐藏
    function navresize() {
        var docWidth = $(document).width();
        if (docWidth < 1004) {
            $(".nav li span").hide();
        } else {
            $(".nav li span").show();
        }
    }
    //点击加载栏目=======================
//    function loadColumn(txt) {

//        var result = Admin_index.loadingColumn(txt).value;
//        document.getElementById("files").innerHTML = "";
//        document.getElementById("files").innerHTML = result;
//        location.reload();
//        
//    }
    //END =============================

</script>
<style type="text/css">
#files{margin:0px auto;width:163px;}
.tree,.tree ul,.tree li{list-style:none;margin:0;padding:0;zoom: 1;}
.tree ul{margin-left:8px;}
.tree li a{color:#555;padding:.1em 7px .1em 27px;display:block;text-decoration:none;border:1px dashed #fff;background:url(scripts/jQuery-Tree-Control/images/icon-file.gif) 5px 50% no-repeat;}
.tree li a.tree-parent{background:url(scripts/jQuery-Tree-Control/images/icon-folder-open.gif) 5px 50% no-repeat;}
.tree li a.tree-parent-collapsed{background:url(scripts/jQuery-Tree-Control/images/icon-folder.gif) 5px 50% no-repeat;}
.tree li a:hover,.tree li a.tree-parent:hover,.tree li a:focus,.tree li a.tree-parent:focus,.tree li a.tree-item-active{color:#000;border:1px solid#eee;background-color:#fafafa;-moz-border-radius:4px;-webkit-border-radius:4px;border-radius:4px;}
.tree li a:focus,.tree li a.tree-parent:focus,.tree li a.tree-item-active{border:1px solid #e2f3fb;background-color:#f2fafd;}
.tree ul.tree-group-collapsed{display:none;}
</style>
</head>

<body class="indexbody">
<form id="form1" runat="server">
<!--全局菜单-->
<a class="btn-paograms" onclick="triggerMenu(true);" style=" display:none;"></a>
<div id="pop-menu" class="pop-menu">
  <div class="pop-box">
    <h1 class="title"><i></i>导航菜单</h1>
    <i class="close" onclick="triggerMenu(false);">关闭</i>
    <div class="list-box"></div>
  </div>
  <i class="arrow">箭头</i>
</div>
<!--/全局菜单-->

<div class="header">
  <div class="header-box">
    <h1 class="logo"></h1>
         <ul id="nav" class="nav">
        <%=Application["strNav"]%>
        
        </ul>
    <div class="nav-right">
      <div class="icon-info">
        <span>
          您好，<%=Application["adminname"]%><br />
          <%=Application["adminType"]%>
         
        </span>
      </div>
      <div class="icon-option">
      	<i></i>
        <div class="drop-box">
          <div class="arrow"></div>
          <ul class="drop-item">
            <li><a  target="_blank" href="../">预览网站</a></li>
            <li><a href="center.aspx" target="mainframe">管理中心</a></li>
            <li><asp:LinkButton ID="lbtnExit" runat="server" onclick="lbtnExit_Click">注销登录</asp:LinkButton></li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</div>

<div class="main-sidebar">
    <div id="sidebar-nav" class="sidebar-nav">
      <div class="list-box">
      <div class="list-group" id="c_content" name="树形菜单" style="display: block;">

        <ul id="files" runat="server" class="tree" role="tree">
            <asp:Repeater ID="RepeaterColum" runat="server">
            <ItemTemplate>
                <%#((DataRowView)Container.DataItem)["Colum"]%>
            </ItemTemplate>
            </asp:Repeater>
           
            </ul>
        </div>

      </div>
    </div>
</div>

<div class="main-container">
  <iframe id="mainframe" name="mainframe" frameborder="0" src="center.aspx"></iframe>
</div>
</form>
</body>
</html>
