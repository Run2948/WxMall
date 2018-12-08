/**  版本信息模板在安装目录下，可自行修改。
* C_order.cs
*
* 功 能： N/A
* 类 名： C_order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/7 22:40:08   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Cms.Model
{
	/// <summary>
	/// C_order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_order
	{
		public C_order()
		{}
		#region Model
		private int _id;
		private string _order_num;
		private int? _user_id;
		private int? _adress_id;
		private int? _quantity_sum;
		private decimal? _price_sum;
		private int? _integral_sum;
		private int? _is_payment;
		private int? _order_status;
		private int? _is_delivery;
		private int? _is_receiving;
		private int? _is_transaction;
		private int? _is_sms;
		private string _pay_method;
		private string _shipping_method;
		private int? _coupon_id;
		private int? _cash_volume_id;
		private int? _integral_arrived;
		private string _note;
		private string _recommended_code;
		private DateTime? _updatetime;
		private string _notify_id;
		private string _pay_info;
		private bool _issubscribe;
		private string _fahuocode;
		private string _fahuomsg;
		private string _trade_no="";
		private decimal? _real_amount=0M;
		private decimal? _order_amount=0M;
		private DateTime? _payment_time;
		private int? _is_refund=0;
		private string _courier_number;
		private string _invoicetype;
		private string _invoicecontent;
		private string _invoicesraised;
		private string _invoiceinfo;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string order_num
		{
			set{ _order_num=value;}
			get{return _order_num;}
		}
		/// <summary>
		/// 会员id
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 收货地址id
		/// </summary>
		public int? adress_id
		{
			set{ _adress_id=value;}
			get{return _adress_id;}
		}
		/// <summary>
		/// 总数量
		/// </summary>
		public int? quantity_sum
		{
			set{ _quantity_sum=value;}
			get{return _quantity_sum;}
		}
		/// <summary>
		/// 总价格
		/// </summary>
		public decimal? price_sum
		{
			set{ _price_sum=value;}
			get{return _price_sum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? integral_sum
		{
			set{ _integral_sum=value;}
			get{return _integral_sum;}
		}
		/// <summary>
		/// 是否支付  0表示未支付  1表示已支付
		/// </summary>
		public int? is_payment
		{
			set{ _is_payment=value;}
			get{return _is_payment;}
		}
		/// <summary>
		/// 订单状态  0状态正在进行中  1表示订单订单关闭 2表示订单完成
		/// </summary>
		public int? order_status
		{
			set{ _order_status=value;}
			get{return _order_status;}
		}
		/// <summary>
		/// 是否发货  0表示未发货  1表示已发货
		/// </summary>
		public int? is_delivery
		{
			set{ _is_delivery=value;}
			get{return _is_delivery;}
		}
		/// <summary>
		/// 是否收货   0表示未发货  1待 确认收货  2表示已收货
		/// </summary>
		public int? is_receiving
		{
			set{ _is_receiving=value;}
			get{return _is_receiving;}
		}
		/// <summary>
		/// 交易是否完成   0表示交易未完成  1表示已完成
		/// </summary>
		public int? is_transaction
		{
			set{ _is_transaction=value;}
			get{return _is_transaction;}
		}
		/// <summary>
		/// 是否发送短信
		/// </summary>
		public int? is_sms
		{
			set{ _is_sms=value;}
			get{return _is_sms;}
		}
		/// <summary>
		/// 支付方式
		/// </summary>
		public string pay_method
		{
			set{ _pay_method=value;}
			get{return _pay_method;}
		}
		/// <summary>
		/// 配送方式
		/// </summary>
		public string shipping_method
		{
			set{ _shipping_method=value;}
			get{return _shipping_method;}
		}
		/// <summary>
		/// 优惠卷id
		/// </summary>
		public int? Coupon_id
		{
			set{ _coupon_id=value;}
			get{return _coupon_id;}
		}
		/// <summary>
		/// 现金卷id
		/// </summary>
		public int? cash_volume_id
		{
			set{ _cash_volume_id=value;}
			get{return _cash_volume_id;}
		}
		/// <summary>
		/// 积分相抵多少
		/// </summary>
		public int? integral_arrived
		{
			set{ _integral_arrived=value;}
			get{return _integral_arrived;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 推荐码
		/// </summary>
		public string recommended_code
		{
			set{ _recommended_code=value;}
			get{return _recommended_code;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 微支付通知id（商户可以查询交易结果）
		/// </summary>
		public string notify_id
		{
			set{ _notify_id=value;}
			get{return _notify_id;}
		}
		/// <summary>
		/// 支付结果
		/// </summary>
		public string pay_info
		{
			set{ _pay_info=value;}
			get{return _pay_info;}
		}
		/// <summary>
		/// 是否关注了
		/// </summary>
		public bool isSubscribe
		{
			set{ _issubscribe=value;}
			get{return _issubscribe;}
		}
		/// <summary>
		/// 微支付发货状态
		/// </summary>
		public string fahuoCode
		{
			set{ _fahuocode=value;}
			get{return _fahuocode;}
		}
		/// <summary>
		/// 微支付发货状态信息
		/// </summary>
		public string fahuoMsg
		{
			set{ _fahuomsg=value;}
			get{return _fahuomsg;}
		}
		/// <summary>
		/// 交易号担保支付用到
		/// </summary>
		public string trade_no
		{
			set{ _trade_no=value;}
			get{return _trade_no;}
		}
		/// <summary>
		/// 实付商品总金额
		/// </summary>
		public decimal? real_amount
		{
			set{ _real_amount=value;}
			get{return _real_amount;}
		}
		/// <summary>
		/// 订单总金额
		/// </summary>
		public decimal? order_amount
		{
			set{ _order_amount=value;}
			get{return _order_amount;}
		}
		/// <summary>
		/// 支付时间
		/// </summary>
		public DateTime? payment_time
		{
			set{ _payment_time=value;}
			get{return _payment_time;}
		}
		/// <summary>
		/// 0 未申请退款 1 提交退款未审核退款  2已审核退款 3退款成功
		/// </summary>
		public int? is_refund
		{
			set{ _is_refund=value;}
			get{return _is_refund;}
		}
		/// <summary>
		/// 快递单号
		/// </summary>
		public string courier_number
		{
			set{ _courier_number=value;}
			get{return _courier_number;}
		}
		/// <summary>
		/// 发票类型
		/// </summary>
		public string invoiceType
		{
			set{ _invoicetype=value;}
			get{return _invoicetype;}
		}
		/// <summary>
		/// 发票内容
		/// </summary>
		public string invoiceContent
		{
			set{ _invoicecontent=value;}
			get{return _invoicecontent;}
		}
		/// <summary>
		/// 发票抬头
		/// </summary>
		public string invoicesRaised
		{
			set{ _invoicesraised=value;}
			get{return _invoicesraised;}
		}
		/// <summary>
		/// 发票信息
		/// </summary>
		public string invoiceInfo
		{
			set{ _invoiceinfo=value;}
			get{return _invoiceinfo;}
		}
		#endregion Model

	}
}

