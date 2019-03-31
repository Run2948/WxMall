using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Runtime.CompilerServices;
using Cms.API.Payment.wxpay;
using System.Data;


/// <summary>
/// 单例模式 处理订单
/// </summary>
public class wxOrderTmpMgr
{
    static wxOrderTmpMgr uniCounter;
    private int totNum = 0;
    private wxOrderTmpMgr()
    {
        Thread.Sleep(400); //假设多线程的时候因某种原因阻塞400毫秒 
    }
    [MethodImpl(MethodImplOptions.Synchronized)] //方法的同步属性 
    static public wxOrderTmpMgr instance()
    {
        if (null == uniCounter)
        {
            uniCounter = new wxOrderTmpMgr();
        }
        return uniCounter;
    }


    /// <summary>
    /// 【微支付】 订单付款成功，处理订单：1将订单的状态改成付款完成；
    /// 
    /// </summary>
    /// <param name="beforeFunName"></param>
    /// <param name="notify_id">通知id</param>
    /// <param name="out_trade_no">商户订单号</param>
    /// <param name="transaction_id">订单交易号</param>
    /// <param name="pay_info">支付结果</param>
    /// <param name="total_fee">付款金额（单位为分）</param>
    /// <param name="otid">订单临时表id</param>
    /// <returns>有错误则返回错误信息，正确，则返回空字符串</returns>
    public string ProcessPaySuccess_wx(string beforeFunName, string notify_id, string out_trade_no, string transaction_id, string pay_info, int total_fee, int otid, int wid)
    {
        string payTmpType = "【微支付】";
        total_fee = total_fee / 100;
        Cms.BLL.C_order orderBll = new Cms.BLL.C_order();

        string funName = payTmpType + beforeFunName + " ProcessPaySuccess_wx ";

        Cms.BLL.wx_log logBll = new Cms.BLL.wx_log();
        Cms.Model.wx_log logModel = new Cms.Model.wx_log();
        logModel.modelName = "微支付";
        logModel.funName =funName;
        logModel.logsContent = "开始执行ProcessPaySuccess_wx方法[otid:" + otid + "]";
        logBll.Add(logModel);
        try
        {
            #region 数据同步前
            IList<Cms.Model.C_order> orderlist = orderBll.GetModelList("id=" + otid + " and order_num='" + out_trade_no + "'");
            if (orderlist == null || orderlist.Count <= 0)
            {
                logModel.modelName = payTmpType;
                logModel.funName = funName;
                logModel.logsContent = "订单号【" + out_trade_no + "】订单号不存在";
                logModel.logsType = 0;
                logBll.Add(logModel);
                return "订单号不存在";
            }
            ////这个暂时不处理
            //if (logBll.ExistsFlg((out_trade_no + otid)))
            //{  //如果已经处理过，则不再处理
            //    return "";
            //}
            //logBll.AddFlg(wid, payTmpType, funName, (out_trade_no + otid));//加标志，防止重复提交

            Cms.Model.C_order orderEntity = orderlist[0];
            //if (orderEntity.price_sum > total_fee)
            //{
            //    return "付款的金额(" + total_fee + ")小于订单的预付款金额(" + orderEntity.price_sum + ")信息，直接退款";
            //}
            orderEntity.notify_id = notify_id;
            orderEntity.trade_no = transaction_id;
            orderEntity.pay_info = pay_info;
            //orderEntity.price_sum = total_fee;
            orderEntity.payment_time = DateTime.Now;
            orderEntity.is_transaction = 0;
            orderEntity.order_status = 0;
            orderEntity.is_payment = 1;


            #region 修改积分============================
            Cms.BLL.C_user user_bll = new Cms.BLL.C_user();
            Cms.Model.C_user user_model = new Cms.BLL.C_user().GetModel(Convert.ToInt32(orderEntity.user_id));
            user_model.userallscore = user_model.userallscore + orderEntity.integral_sum;
            user_model.userscore = user_model.userscore + orderEntity.integral_sum;
            user_bll.Update(user_model);

            Cms.BLL.C_integral_rec integral_BLL = new Cms.BLL.C_integral_rec();
            Cms.Model.C_integral_rec integral_model = new Cms.Model.C_integral_rec();

           DataTable dt=new Cms.BLL.C_ordersub().GetList("order_id="+otid).Tables[0];
            for(int i=0;i<dt.Rows.Count;i++)
            {
                integral_model.article_id = Convert.ToInt32(dt.Rows[i]["article_id"].ToString());
                integral_model.user_id = Convert.ToInt32(dt.Rows[i]["user_id"].ToString());
                integral_model.usercard = user_model.usercard;
                integral_model.openid = user_model.openid;
                integral_model.numberid = dt.Rows[i]["id"].ToString();
                integral_model.scorename ="购买产品";
                integral_model.title = dt.Rows[i]["title"].ToString();
                integral_model.wescore = Convert.ToInt32(dt.Rows[i]["integral"].ToString() == "" ? "0" : dt.Rows[i]["integral"].ToString()) * Convert.ToInt32(dt.Rows[i]["quantity"].ToString());
                integral_model.quantity = Convert.ToInt32(dt.Rows[i]["quantity"].ToString());
                integral_model.type = 0;
                integral_model.updateTime = DateTime.Now;
                integral_BLL.Add(integral_model);
                try
                {
                    wxuser.UserSale wu = new wxuser.UserSale();
                    wu = wxuser.getUserScore(user_model.usercard, user_model.openid, dt.Rows[i]["id"].ToString(), "购买产品", "+" + integral_model.wescore);
                }
                catch(Exception ex)
                {

                }
               }
            
            #endregion
            ////判断是否需要立即发货
            //if (orderEntity.express_status == 0)
            //{
            //    //立即发货
            //    FaHuoProc fahuo = new FaHuoProc();

            //    BLL.wx_payment_wxpay payBll = new BLL.wx_payment_wxpay();
            //    Model.wx_payment_wxpay paymentInfo = payBll.GetModelByWid(wid);
            //    Dictionary<string, object> fahuoDict = fahuo.fahuomgr(paymentInfo, orderEntity);
            //    string errcode = fahuoDict["errcode"].ToString();
            //    string errmsg = fahuoDict["errmsg"].ToString();
            //    orderEntity.fahuoCode = errcode;
            //    orderEntity.fahuoMsg = errmsg;
            //    if (errcode == "0")
            //    {
            //        orderEntity.express_status = 2;
            //        orderEntity.express_time = DateTime.Now;
            //    }
            //    else
            //    {
            //        orderEntity.express_status = 1;
            //    }
            //}

            bool ret = orderBll.Update(orderEntity);
            if (!ret)
            {
                logModel.modelName = payTmpType;
                logModel.funName = funName;
                logModel.logsContent = "订单号【" + out_trade_no + "】支付成功后处理数据失败";
                logModel.logsType = 0;
                logBll.Add(logModel);
               
                return "订单号【" + out_trade_no + "】支付成功后处理数据失败";
            }
            logModel.modelName = payTmpType;
            logModel.funName = funName;
            logModel.logsContent = "订单号【" + out_trade_no + "】支付成功后，处理数据成功";
            logModel.logsType =1;
            logBll.Add(logModel);
            
            return "";

            #endregion

        }
        catch (Exception ex)
        {
            logModel.modelName = payTmpType;
            logModel.funName = funName;
            logModel.logsContent = "订单号【" + out_trade_no + "】支付成功后处理数据同步出现错误：" + ex.Message;
            logModel.logsType =0;
            logBll.Add(logModel);
           
            return null;
        }

    }




    public void Inc() { totNum++; }
    public int GetCounter() { return totNum; }
}