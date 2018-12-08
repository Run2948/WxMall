<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductPage.aspx.cs" Inherits="api_wxpay_ProductPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../../shop/css/style.css" rel="stylesheet" type="text/css" />
    <title>DBE-支付</title>
</head>
<%--<script type="text/javascript">
          //获取共享地址
          function editAddress()
          {
             WeixinJSBridge.invoke(
                 'editAddress',
                 <%=wxEditAddrParam%>,//josn串
                   function (res)
                   {
                       var addr1 = res.proviceFirstStageName;
                       var addr2 = res.addressCitySecondStageName;
                       var addr3 = res.addressCountiesThirdStageName;
                       var addr4 = res.addressDetailInfo;
                       var tel = res.telNumber;
                       var addr = addr1 + addr2 + addr3 + addr4;
                       alert(addr + ":" + tel);
                   }
               );
         }

           window.onload = function ()
           {
               if (typeof WeixinJSBridge == "undefined")
               {
                   if (document.addEventListener)
                   {
                       document.addEventListener('WeixinJSBridgeReady', editAddress, false);
                   }
                   else if (document.attachEvent)
                   {
                       document.attachEvent('WeixinJSBridgeReady', editAddress);
                       document.attachEvent('onWeixinJSBridgeReady', editAddress);
                   }
               }
               else
               {
                   editAddress();
               }
           };

</script>--%>
<body>
    <form id="Form1" runat="server">
    <section class="body all">
      <header>
        <a href="javascript:history.back(-1);" class="back"></a>
        <a href="/shop/main.aspx" class="dbe-admin"></a>
        <a href="/shop/user.aspx" class="page-title">微支付</a>
    </header>
    <section class="main main-product">
        <div class="p-contain">
        	<div class="info-t">
            	<div class="info-con">
                 <dl>
                        <dt>订单号：</dt>
                        <dd><asp:Literal ID="order_num" runat="server" EnableViewState="false"></asp:Literal></dd>
                        <div class="clear"></div>
                    </dl>
                                     <dl>
                        <dt>共计金额￥：</dt>
                        <dd><asp:Literal ID="litMoney" runat="server" EnableViewState="false" Text="1"></asp:Literal></dd>
                        <div class="clear"></div>
                    </dl>
                                     <dl>
                        <dt>下单时间：</dt>
                        <dd><asp:Literal ID="litDate" runat="server" EnableViewState="false"></asp:Literal></dd>
                        <div class="clear"></div>
                    </dl>
               </div>
            </div>
      
        <div class="paytype" style="display: none;">支付方式：微信支付</div>
       
        <div class="product-button1">
          <asp:Button ID="Button1" runat="server" Text="确认支付"  CssClass="login_ipt" OnClick="Button1_Click" />
        
           
            </div>
                    </div>
    </section>
    </section>
    </form>
</body>
</html>
