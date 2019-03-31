using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class api_wxpay_JsApiPayPage : System.Web.UI.Page
{
    public static string wxJsApiParam { get; set; } //H5调起JS API参数
    public static string orderNum;
    protected void Page_Load(object sender, EventArgs e)
    {
        Log.Info(this.GetType().ToString(), "page load");
        if (!IsPostBack)
        {
            Cms.Model.C_user userModel = adminUser.GetuserLoginState();
            int otid = Convert.ToInt32(Request["orderid"].ToString());
            Cms.BLL.C_order otBll = new Cms.BLL.C_order();
            Cms.Model.C_order orderEntity = otBll.GetModel(otid);
            order_num.Text = orderEntity.order_num;
            litMoney.Text = Convert.ToDecimal(orderEntity.price_sum).ToString("0.00");
            litDate.Text = orderEntity.updateTime.ToString();
            string openid = userModel.openid.ToString();
            string total_fee = ((int)(Convert.ToDecimal(orderEntity.price_sum)* 100)).ToString();
            //检测是否给当前页面传递了相关参数
            if (string.IsNullOrEmpty(openid) || string.IsNullOrEmpty(total_fee))
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面传参出错,请返回重试" + "</span>");
                Log.Error(this.GetType().ToString(), "This page have not get params, cannot be inited, exit...");
                submit.Visible = false;
                return;
            }

            //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
            JsApiPay jsApiPay = new JsApiPay(this);
            jsApiPay.openid = openid;
            jsApiPay.orderid = orderEntity.order_num;
            DataTable dt = new Cms.BLL.C_ordersub().GetList("order_id=" + orderEntity.id).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                jsApiPay.productName = dt.Rows[0]["title"].ToString();
            }
            else
            {
                jsApiPay.productName = "泓源鼎盛酒业商品";
            }
            try
            {
            jsApiPay.total_fee = int.Parse(total_fee);
               

            //JSAPI支付预处理
           
                WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult();
                 
                wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数 
                orderNum = Request["orderid"].ToString();
                Log.Debug(this.GetType().ToString(), "wxJsApiParam : " + wxJsApiParam);
                //在页面上显示订单信息
                //Response.Write("<span style='color:#00CD00;font-size:20px'>订单详情：</span><br/>");
                //Response.Write("<span style='color:#00CD00;font-size:20px'>" + unifiedOrderResult.ToPrintStr() + "</span>");

            }
            catch (Exception ex)
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + "下单失败，请返回重试" + "</span>"+ex.Message.ToString() + Convert.ToDecimal(orderEntity.price_sum).ToString());
                submit.Visible = false;
            }
        }
    }
}