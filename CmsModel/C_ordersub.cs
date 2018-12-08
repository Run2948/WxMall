/**  版本信息模板在安装目录下，可自行修改。
* C_ordersub.cs
*
* 功 能： N/A
* 类 名： C_ordersub
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/2 16:29:12   N/A    初版
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
	/// C_ordersub:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_ordersub
	{
		public C_ordersub()
		{}
		#region Model
		private int _id;
		private int? _user_id;
		private int? _order_id;
		private string _order_num;
		private int? _article_id;
		private string _title;
		private decimal? _price;
        private int? _quantity;
		private int? _integral;
		private string _property_value;
		private string _note;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 订单id
		/// </summary>
		public int? order_id
		{
			set{ _order_id=value;}
			get{return _order_id;}
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
		/// 产品id
		/// </summary>
		public int? article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 积分
		/// </summary>
		public int? integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 属性值拼接
		/// </summary>
		public string property_value
		{
			set{ _property_value=value;}
			get{return _property_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

