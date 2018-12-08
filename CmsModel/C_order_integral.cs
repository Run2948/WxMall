/**  版本信息模板在安装目录下，可自行修改。
* C_order_integral.cs
*
* 功 能： N/A
* 类 名： C_order_integral
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/20 17:21:23   N/A    初版
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
	/// C_order_integral:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_order_integral
	{
		public C_order_integral()
		{}
		#region Model
		private int _id;
		private string _order_num;
		private int? _user_id;
		private int? _adress_id;
		private int? _quantity_sum;
		private decimal? _price_sum;
		private int? _integral_sum;
		private int? _order_status;
		private int? _is_sms;
		private string _note;
		private string _recommended_code;
		private DateTime? _updatetime;
		private int? _storesid;
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
		/// 订单状态  0表示未预约  1表示已预约  2表示已领取
		/// </summary>
		public int? order_status
		{
			set{ _order_status=value;}
			get{return _order_status;}
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
		/// 
		/// </summary>
		public int? storesId
		{
			set{ _storesid=value;}
			get{return _storesid;}
		}
		#endregion Model

	}
}

