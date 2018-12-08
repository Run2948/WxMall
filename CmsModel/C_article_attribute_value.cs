/**  版本信息模板在安装目录下，可自行修改。
* C_article_attribute_value.cs
*
* 功 能： N/A
* 类 名： C_article_attribute_value
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/9 17:11:13   N/A    初版
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
	/// C_article_attribute_value:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_article_attribute_value
	{
		public C_article_attribute_value()
		{}
		#region Model
		private int _article_id;
		private string _sub_title;
		private string _source="";
		private string _author="";
		private string _goods_no="";
		private int? _stock_quantity=0;
		private decimal? _market_price=0M;
		private decimal? _sell_price=0M;
		private int? _point=0;
		/// <summary>
		/// 父表ID
		/// </summary>
		public int article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
		}
		/// <summary>
		/// 副标题
		/// </summary>
		public string sub_title
		{
			set{ _sub_title=value;}
			get{return _sub_title;}
		}
		/// <summary>
		/// 来源
		/// </summary>
		public string source
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 作者
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 商品货号
		/// </summary>
		public string goods_no
		{
			set{ _goods_no=value;}
			get{return _goods_no;}
		}
		/// <summary>
		/// 库存数量
		/// </summary>
		public int? stock_quantity
		{
			set{ _stock_quantity=value;}
			get{return _stock_quantity;}
		}
		/// <summary>
		/// 市场价格
		/// </summary>
		public decimal? market_price
		{
			set{ _market_price=value;}
			get{return _market_price;}
		}
		/// <summary>
		/// 销售价格
		/// </summary>
		public decimal? sell_price
		{
			set{ _sell_price=value;}
			get{return _sell_price;}
		}
		/// <summary>
		/// 积分
		/// </summary>
		public int? point
		{
			set{ _point=value;}
			get{return _point;}
		}
		#endregion Model

	}
}

