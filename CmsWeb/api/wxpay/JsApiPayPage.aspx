<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JsApiPayPage.aspx.cs" Inherits="api_wxpay_JsApiPayPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../../m/css/shop.css" rel="stylesheet" type="text/css" />
    <title>泓源鼎盛酒业-支付</title>
</head>
<script type="text/javascript">

               //调用微信JS api 支付
               function jsApiCall()
               {
                   
                   WeixinJSBridge.invoke(
                   'getBrandWCPayRequest',
                   <%=wxJsApiParam%>,//josn串
                    function (res)
                    {
                        WeixinJSBridge.log(res.err_msg);
//                        alert(res.err_code + res.err_desc + res.err_msg);
                        if (res.err_msg == 'get_brand_wcpay_request:ok') {
                        // alert('支付成功');
                        //去判断交易信息
                        window.location.href = "/api/wxpay/success.aspx?otid="+<%=orderNum%>;
                          
                    } else {

                       // alert('支付失败：'+res.err_msg);
                        
                        // window.location.href = rpage;
 
                        return false;
                    }
                     }
                    );
               }

               function callpay()
               {
                   if (typeof WeixinJSBridge == "undefined")
                   {
                       if (document.addEventListener)
                       {
                           document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
                       }
                       else if (document.attachEvent)
                       {
                           document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                           document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
                       }
                   }
                   else
                   {
                       jsApiCall();
                   }
               }
			   callpay();
               
</script>
<body>
    <form id="Form1" runat="server">
    <section class="body all">
      <header>
        <a href="javascript:history.back(-1);" class="back"></a>
        <a href="/m/mine.aspx" class="dbe-admin"></a>
        <a href="/m/mine.aspx" class="page-title">微信支付</a>
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
          <asp:Button ID="submit" runat="server" Text="立即支付"  CssClass="login_ipt" OnClientClick="javascript:callpay();return false;" />
        
           
            </div>
                    </div>
    </section>
    </section>
    </form>
</body>
</html>
