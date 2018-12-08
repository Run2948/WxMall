/**  版本信息模板在安装目录下，可自行修改。
* C_integral_product.cs
*
* 功 能： N/A
* 类 名： C_integral_product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/7 23:34:29   N/A    初版
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
	/// C_integral_product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_integral_product
	{
		public C_integral_product()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _litpic;
		private decimal? _price;
		private decimal? _marketprice;
		private int? _integral;
		private int? _marketintegral;
		private int? _stock;
		private int? _typeid;
		private int? _sales;
		private string _intro;
		private int? _istop;
		private int? _ishot;
		private int? _ishidden;
		private int? _isactive;
		private int? _isrecommend;
		private string _content;
		private DateTime? _createdtime;
		private int? _comments;
		private string _favorablerate;
		private int? _sortid;
		private int? _limitnumber;
		private DateTime? _startime;
		private DateTime? _endtime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 积分产品名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 封面图
		/// </summary>
		public string litpic
		{
			set{ _litpic=value;}
			get{return _litpic;}
		}
		/// <summary>
		/// 实际价格
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
		/// 
		/// </summary>
		public int? marketIntegral
		{
			set{ _marketintegral=value;}
			get{return _marketintegral;}
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
		/// 0:限时 1:永久
		/// </summary>
		public int? typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 销量
		/// </summary>
		public int? sales
		{
			set{ _sales=value;}
			get{return _sales;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 置顶
		/// </summary>
		public int? isTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 热门
		/// </summary>
		public int? isHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 是否显示
		/// </summary>
		public int? isHidden
		{
			set{ _ishidden=value;}
			get{return _ishidden;}
		}
		/// <summary>
		/// 是否活动
		/// </summary>
		public int? isActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int? isRecommend
		{
			set{ _isrecommend=value;}
			get{return _isrecommend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createdTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// 评论数
		/// </summary>
		public int? comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}
		/// <summary>
		/// 好评率
		/// </summary>
		public string favorableRate
		{
			set{ _favorablerate=value;}
			get{return _favorablerate;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? sortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 限制数量
		/// </summary>
		public int? limitNumber
		{
			set{ _limitnumber=value;}
			get{return _limitnumber;}
		}
		/// <summary>
		/// 活动开始时间
		/// </summary>
		public DateTime? starTime
		{
			set{ _startime=value;}
			get{return _startime;}
		}
		/// <summary>
		/// 活动结束时间
		/// </summary>
		public DateTime? endTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		#endregion Model

	}
}

