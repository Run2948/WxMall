/**  版本信息模板在安装目录下，可自行修改。
* C_article_product.cs
*
* 功 能： N/A
* 类 名： C_article_product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/4/29 7:37:09   N/A    初版
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
	/// C_article_product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_article_product
	{
		public C_article_product()
		{}
		#region Model
		private int _id;
		private int? _article_id;
		private decimal? _price;
		private decimal? _marketprice;
		private int? _integral;
		private int? _stock;
		private int? _is_integral;
		private int? _group_id=0;
		private int? _s_version;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 文章ID
		/// </summary>
		public int? article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
		}
		/// <summary>
		/// 优惠价格
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 市场价格
		/// </summary>
		public decimal? marketPrice
		{
			set{ _marketprice=value;}
			get{return _marketprice;}
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
		/// 库存
		/// </summary>
		public int? stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 是否开启积分兑换
		/// </summary>
		public int? is_integral
		{
			set{ _is_integral=value;}
			get{return _is_integral;}
		}
		/// <summary>
		/// 会员组ID
		/// </summary>
		public int? group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? s_version
		{
			set{ _s_version=value;}
			get{return _s_version;}
		}
		#endregion Model

	}
}

