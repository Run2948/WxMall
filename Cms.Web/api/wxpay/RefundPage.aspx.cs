using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class api_wxpay_RefundPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Log.Info(this.GetType().ToString(), "page load");
        int orderId = Convert.ToInt32(Request["orderid"].ToString());
        Cms.Model.C_order model = new Cms.BLL.C_order().GetModel(Convert.ToInt32(orderId));
        transaction_id.Text = model.order_num;
        out_trade_no.Text = model.trade_no;
        total_fee.Text = Convert.ToDecimal(model.price_sum).ToString("0.00");
        refund_fee.Text = Convert.ToDecimal(model.price_sum).ToString("0.00");
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(transaction_id.Text) && string.IsNullOrEmpty(out_trade_no.Text))
        {
            Response.Write("<script LANGUAGE='javascript'>alert('微信订单号和商户订单号至少填一个！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(total_fee.Text))
        {
            Response.Write("<script LANGUAGE='javascript'>alert('订单总金额必填！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(refund_fee.Text))
        {
            Response.Write("<script LANGUAGE='javascript'>alert('退款金额必填！');</script>");
            return;
        }

        //调用订单退款接口,如果内部出现异常则在页面上显示异常原因
        try
        {
            int orderId = Convert.ToInt32(Request["orderid"].ToString());
            Cms.Model.C_order model = new Cms.BLL.C_order().GetModel(Convert.ToInt32(orderId));
            transaction_id.Text = model.order_num;
            out_trade_no.Text = model.trade_no;
            total_fee.Text = Convert.ToDecimal(model.price_sum).ToString("0.00");
            refund_fee.Text = Convert.ToDecimal(model.price_sum).ToString("0.00");
            string result = Refund.Run(transaction_id.Text, out_trade_no.Text, ((int)(Convert.ToDecimal(model.price_sum) * 100)).ToString(), ((int)(Convert.ToDecimal(model.price_sum) * 100)).ToString());
            Response.Write("<span style='color:#00CD00;font-size:20px'>" + result + "</span>");
        }
        catch (WxPayException ex)
        {
            Response.Write("<span style='color:#FF0000;font-size:20px'>" + ex.ToString() + "</span>");
        }
        catch (Exception ex)
        {
            Response.Write("<span style='color:#FF0000;font-size:20px'>" + ex.ToString() + "</span>");
        }

    }
}