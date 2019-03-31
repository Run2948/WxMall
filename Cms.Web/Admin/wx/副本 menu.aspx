<%@ Page Language="C#" AutoEventWireup="true" CodeFile="副本 menu.aspx.cs" Inherits="Admin_wx_menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
        function CheckUser() {
            var _username = document.getElementById("<%=tburl.ClientID%>").value;
           
            if (_username != null || _username != "") {

                if (_username.indexOf("http://") > -1 || _username.indexOf("HTTP://") > -1) {
                    return;
                } else {
                  
                    document.getElementById("<%=tburl.ClientID%>").value = "http://" + _username;

                }

            }
        }
      </script>
      <script language="javascript">
          document.all.ListBox1.size = document.all.ListBox1.options.length;  
</script>


</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="location">
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>微信管理</span>
</div>
<div class="line10"></div>

<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">微信菜单</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">菜单设置</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">文章推送</a></li>
      </ul>
    </div>
  </div>
</div>
<div class="tab-content">
<dl>
<dt>公众平台AppId：</dt>
   
<dd>
    <asp:TextBox ID="AppId" runat="server"  Width="150"></asp:TextBox>
   &nbsp;&nbsp;&nbsp;&nbsp; 公众平台AppSecret：      <asp:TextBox ID="AppSecret" runat="server"  Width="240"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;access_token <asp:TextBox ID="hdid" runat="server"  Width="300"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
       ID="btnsave" runat="server" Text="设置" onclick="btnsave_Click" />
</dd>
</dl>


  
</div>
<div class="tab-content" style="display:none;">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<dl>
    <dt>菜单</dt>
    <dd>
        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True"   Rows="6"
            ontextchanged="ListBox1_TextChanged" ></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True"   Rows="6"
            ontextchanged="ListBox2_TextChanged" ></asp:ListBox>
        <asp:ListBox ID="ListBox3" runat="server" AutoPostBack="True"   Rows="6"
            ontextchanged="ListBox3_TextChanged"></asp:ListBox>
       
    </dd>
  </dl>
  
  <dl>
  <dt>
   菜单名称
  </dt>
  <dd><asp:TextBox ID="tbname" runat="server" MaxLength="4"></asp:TextBox> * 最多四个汉字</dd>  
  </dl>
   <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible="false">
    <dl>
  <dt>
   菜单事件
  </dt>
  <dd><asp:DropDownList ID="ddeven" runat="server" AutoPostBack="True" 
          onselectedindexchanged="ddeven_SelectedIndexChanged">
      </asp:DropDownList>
  </dd>
  </dl>
  <dl >
  <dt></dt>
  <dd>
      <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
          <table style="width: 100%;">
              <tr>
                  <td>
                      菜单一：<asp:TextBox ID="tbmenu1" runat="server" MaxLength="16"></asp:TextBox> * 最好七个汉字
                  </td>              
              </tr>
                  <tr>
                  <td>
                       菜单二：<asp:TextBox ID="tbmenu2" runat="server" MaxLength="16"></asp:TextBox>
                  </td>              
              </tr>
                  <tr>
                  <td>
                      菜单三：<asp:TextBox ID="tbmenu3" runat="server" MaxLength="16"></asp:TextBox>
                  </td>              
              </tr>
                  <tr>
                  <td>
                      菜单四：<asp:TextBox ID="tbmenu4" runat="server" MaxLength="16"></asp:TextBox>
                  </td>              
              </tr>
                  <tr>
                  <td>
                     菜单五：<asp:TextBox ID="tbmenu5" runat="server" MaxLength="16"></asp:TextBox>
                  </td>              
              </tr>
          </table>
      </asp:PlaceHolder>
      <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
      key： <asp:TextBox ID="tbkey" runat="server" MaxLength="20"></asp:TextBox><br />
      信息：<textarea cols="2" rows="5" id="tinfo" runat="server" style="width:300px"></textarea>
<br />      回复：<textarea cols="2" rows="5" id="tcontent" runat="server" style="width:300px"></textarea>
      </asp:PlaceHolder>
      <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="false">
       要链接到的URL地址：<asp:TextBox ID="tburl" runat="server" MaxLength="64" onblur="CheckUser()" Width="300"></asp:TextBox>
      </asp:PlaceHolder>
  </dd>
  </dl>

  </asp:PlaceHolder>
  <dl>
  <dt></dt>
  <dd>
   <asp:Button ID="btnSubmit" runat="server" Text="发布菜单"  onclick="btnSubmit_Click" />
   <asp:Button ID="btndz" runat="server" Text="停用菜单" onclick="btndz_Click"  />
   <asp:Button ID="btnsaves" runat="server" Text="保存设置" onclick="btnsaves_Click"  />
     

  </dd>
  </dl>
  </ContentTemplate>
         </asp:UpdatePanel>
  
</div>
<div class="tab-content" style="display:none;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    

  <dl>
  <dt></dt>
  <dd> 
      
      文章id：<asp:TextBox ID="tbid" runat="server" Width="50" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>&nbsp;&nbsp; 文章url：<asp:TextBox ID="tburls" runat="server" MaxLength="50" Width="350" ></asp:TextBox><asp:Button ID="btnts" runat="server" Text="推送" onclick="btnts_Click" /></dd>
  </dl>
      </ContentTemplate>
    </asp:UpdatePanel>
</div>

    </form>
</body>
</html>
