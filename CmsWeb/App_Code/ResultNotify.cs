using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Data;

/// <summary>
///ResultNotify 的摘要说明
/// </summary>

/// <summary>
/// 支付结果通知回调处理类
/// 负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
/// </summary>
public class ResultNotify : Notify
{
    public ResultNotify(Page page)
        : base(page)
    {

    }
    #region 添加日志
    public void setlog(string str, string sname)
    {
        Cms.BLL.C_admin_log cm = new Cms.BLL.C_admin_log();
        Cms.Model.C_admin_log mc = new Cms.Model.C_admin_log();
        mc.remark = str;
        mc.action_type = "微信信息";
        mc.user_name = sname;
        mc.add_time = DateTime.Now;
        cm.Add(mc);
    }
    #endregion
    public override void ProcessNotify()
    {

        WxPayData notifyData = GetNotifyData();
        setlog("transaction_id", notifyData.GetValue("transaction_id").ToString());
        //检查支付结果中transaction_id是否存在
        if (!notifyData.IsSet("transaction_id"))
        {
            setlog("transaction_id", "不存在");
            //若transaction_id不存在，则立即返回结果给微信支付后台
            WxPayData res = new WxPayData();
            res.SetValue("return_code", "FAIL");
            res.SetValue("return_msg", "支付结果中微信订单号不存在");
            Log.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
            page.Response.Write(res.ToXml());
            page.Response.End();
        }
        else
        {
            #region 支付成功后处理订单信息=============================================================
            setlog("transaction_id", "存在");
            Cms.BLL.C_order otBll = new Cms.BLL.C_order();

            setlog("orderid", notifyData.GetValue("out_trade_no").ToString());
            DataTable DT = otBll.GetList("order_num='" + notifyData.GetValue("out_trade_no").ToString() + "'").Tables[0];
            if (DT != null && DT.Rows.Count > 0)//购物
            {
                int orderId = Convert.ToInt32(DT.Rows[0]["id"].ToString());
                Cms.Model.C_order ordertmp = otBll.GetModel(orderId);
                ordertmp.trade_no = notifyData.GetValue("transaction_id").ToString();
                //ordertmp.notify_id = notifyData.GetValue("notify_id").ToString();
                //ordertmp.pay_info = notifyData.GetValue("pay_info").ToString();
                //orderEntity.price_sum = total_fee;
                ordertmp.payment_time = DateTime.Now;
                ordertmp.is_transaction = 0;
                ordertmp.order_status = 0;
                ordertmp.is_payment = 1;
                #region 修改积分============================
                //setlog("修改积分", notifyData.GetValue("out_trade_no").ToString());
                //Cms.BLL.C_user user_bll = new Cms.BLL.C_user();
                //Cms.Model.C_user user_model = new Cms.BLL.C_user().GetModel(Convert.ToInt32(ordertmp.user_id));
                //user_model.userallscore = user_model.userallscore + ordertmp.integral_sum;
                //user_model.userscore = user_model.userscore + ordertmp.integral_sum;
                //user_bll.Update(user_model);

                //Cms.BLL.C_integral_rec integral_BLL = new Cms.BLL.C_integral_rec();
                //Cms.Model.C_integral_rec integral_model = new Cms.Model.C_integral_rec();
                //DataTable dt = new Cms.BLL.C_ordersub().GetList("order_id=" + ordertmp.id).Tables[0];
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        integral_model.article_id = Convert.ToInt32(dt.Rows[i]["article_id"].ToString());
                //        integral_model.user_id = Convert.ToInt32(dt.Rows[i]["user_id"].ToString());
                //        integral_model.usercard = user_model.usercard;
                //        integral_model.openid = user_model.openid;
                //        integral_model.numberid = dt.Rows[i]["id"].ToString();
                //        integral_model.scorename = "购买产品";
                //        integral_model.title = dt.Rows[i]["title"].ToString();
                //        integral_model.wescore = Convert.ToInt32(dt.Rows[i]["integral"].ToString() == "" ? "0" : dt.Rows[i]["integral"].ToString()) * Convert.ToInt32(dt.Rows[i]["quantity"].ToString());
                //        integral_model.quantity = Convert.ToInt32(dt.Rows[i]["quantity"].ToString());
                //        integral_model.type = 0;
                //        integral_model.updateTime = DateTime.Now;
                //        integral_BLL.Add(integral_model);
                //        try
                //        {
                //            wxuser.UserSale wu = new wxuser.UserSale();//积分修改同步到ERP
                //            wu = wxuser.getUserScore(user_model.usercard, user_model.openid, dt.Rows[i]["id"].ToString(), "购买产品", "+" + integral_model.wescore);
                //        }
                //        catch (Exception ex)
                //        {
                //            page.Response.Write(ex.Message);
                //            page.Response.End();
                //        }
                //    }
                //}
                #endregion
                #region 减库存加销量============================



                DataTable dt = new Cms.BLL.C_ordersub().GetList("order_id=" + ordertmp.id).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            int productId = Convert.ToInt32(dt.Rows[i]["article_id"].ToString());
                            int quantity = Convert.ToInt32(dt.Rows[i]["quantity"].ToString());
                            Cms.Model.C_product product = new Cms.BLL.C_product().GetModel(productId);
                            if (product.stock - quantity > 0)
                            {
                                product.stock = product.stock - quantity;
                                product.sales = product.sales + quantity;
                                new Cms.BLL.C_product().Update(product);
                            }
                        }
                        catch (Exception ex)
                        {
                            page.Response.Write(ex.Message);
                            page.Response.End();
                        }
                    }
                }
                #endregion
                Cms.BLL.wx_log logBll = new Cms.BLL.wx_log();
                Cms.Model.wx_log logModel = new Cms.Model.wx_log();
                string payTmpType = "【微支付】";
                string funName = payTmpType + "【微支付】 订单付款成功，处理订单" + " ProcessPaySuccess_wx ";
                bool ret = otBll.Update(ordertmp);//修改主表订单信息
                if (!ret)
                {
                    logModel.modelName = payTmpType;
                    logModel.funName = funName;
                    logModel.logsContent = "订单号【" + notifyData.GetValue("out_trade_no").ToString() + "】支付成功后处理数据失败";
                    logModel.logsType = 0;
                    logBll.Add(logModel);
                }
                logModel.modelName = payTmpType;
                logModel.funName = funName;
                logModel.logsContent = "订单号【" + notifyData.GetValue("out_trade_no").ToString() + "】支付成功后，处理数据成功";
                logModel.logsType = 1;
                logBll.Add(logModel);

            }
            else//充值
            {
                DataTable dtRecharge = new Cms.BLL.C_user_recharge().GetList("orderNumber='" + notifyData.GetValue("out_trade_no").ToString() + "'").Tables[0];
                if (dtRecharge != null && dtRecharge.Rows.Count > 0)
                {
                    int orderId = Convert.ToInt32(dtRecharge.Rows[0]["id"].ToString());
                    Cms.Model.C_user_recharge orderRecharge = new Cms.BLL.C_user_recharge().GetModel(orderId);
                    orderRecharge.isPay = 1;

                    Cms.Model.C_user user = new Cms.BLL.C_user().GetModel(Convert.ToInt32(orderRecharge.userId));
                    user.userMoney = user.userMoney + orderRecharge.price;
                    new Cms.BLL.C_user().Update(user);

                    Cms.BLL.wx_log logBll = new Cms.BLL.wx_log();
                    Cms.Model.wx_log logModel = new Cms.Model.wx_log();
                    string payTmpType = "【微支付】";
                    string funName = payTmpType + "【微支付】 订单付款成功，处理订单" + " ProcessPaySuccess_wx ";
                    bool ret =new Cms.BLL.C_user_recharge().Update(orderRecharge);//修改订单信息
                    if (!ret)
                    {
                        logModel.modelName = payTmpType;
                        logModel.funName = funName;
                        logModel.logsContent = "订单号【" + notifyData.GetValue("out_trade_no").ToString() + "】支付成功后处理数据失败";
                        logModel.logsType = 0;
                        logBll.Add(logModel);
                    }
                    else
                    {
                        logModel.modelName = payTmpType;
                        logModel.funName = funName;
                        logModel.logsContent = "订单号【" + notifyData.GetValue("out_trade_no").ToString() + "】支付成功后，处理数据成功";
                        logModel.logsType = 1;
                        logBll.Add(logModel);
                    }

                }

            }

            #endregion
        }

        string transaction_id = notifyData.GetValue("transaction_id").ToString();
        //查询订单，判断订单真实性
        if (!QueryOrder(transaction_id))
        {
            setlog("return_code", "FAIL");
            //若订单查询失败，则立即返回结果给微信支付后台
            WxPayData res = new WxPayData();
            res.SetValue("return_code", "FAIL");
            res.SetValue("return_msg", "订单查询失败");
            Log.Error(this.GetType().ToString(), "Order query failure : " + res.ToXml());
            page.Response.Write(res.ToXml());
            page.Response.End();
        }
        //查询订单成功
        else
        {
            setlog("return_code", "SUCCESS");
            WxPayData res = new WxPayData();
            res.SetValue("return_code", "SUCCESS");
            res.SetValue("return_msg", "OK");
            Log.Info(this.GetType().ToString(), "order query success : " + res.ToXml());
            page.Response.Write(res.ToXml());
            page.Response.End();
            setlog("SUCCESS", res.ToXml());
        }

    }

    //查询订单
    private bool QueryOrder(string transaction_id)
    {
        WxPayData req = new WxPayData();
        req.SetValue("transaction_id", transaction_id);
        WxPayData res = WxPayApi.OrderQuery(req);
        if (res.GetValue("return_code").ToString() == "SUCCESS" &&
            res.GetValue("result_code").ToString() == "SUCCESS")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
