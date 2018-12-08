/**  版本信息模板在安装目录下，可自行修改。
* C_product.cs
*
* 功 能： N/A
* 类 名： C_product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/12 15:26:16   N/A    初版
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
	/// C_product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_product
	{
		public C_product()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _intro;
		private string _litpic;
		private decimal? _price;
		private decimal? _marketprice;
		private int? _integral;
		private int? _stock;
		private string _unit;
		private int? _sversion;
		private int? _typeid;
		private int? _sales;
		private int? _views;
		private int? _istop;
		private int? _ishot;
		private int? _ishidden;
		private int? _isactive;
		private int? _isrecommend;
		private string _seotitle;
		private string _seokeyword;
		private string _seodescription;
		private string _content;
		private string _ingredients;
		private string _factoryaddress;
		private string _factoryname;
		private string _manufacturedate;
		private DateTime? _createdtime;
		private int? _comments;
		private string _favorablerate;
		private int? _sortid;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 产品名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 库存
		/// </summary>
		public int? stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 版本号
		/// </summary>
		public int? sVersion
		{
			set{ _sversion=value;}
			get{return _sversion;}
		}
		/// <summary>
		/// 分类id
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
		/// 浏览次数
		/// </summary>
		public int? views
		{
			set{ _views=value;}
			get{return _views;}
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
		public string seoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seoKeyword
		{
			set{ _seokeyword=value;}
			get{return _seokeyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seoDescription
		{
			set{ _seodescription=value;}
			get{return _seodescription;}
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
		/// 配料
		/// </summary>
		public string ingredients
		{
			set{ _ingredients=value;}
			get{return _ingredients;}
		}
		/// <summary>
		/// 厂址
		/// </summary>
		public string factoryAddress
		{
			set{ _factoryaddress=value;}
			get{return _factoryaddress;}
		}
		/// <summary>
		/// 厂名
		/// </summary>
		public string factoryName
		{
			set{ _factoryname=value;}
			get{return _factoryname;}
		}
		/// <summary>
		/// 生产日期
		/// </summary>
		public string manufactureDate
		{
			set{ _manufacturedate=value;}
			get{return _manufacturedate;}
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
		#endregion Model

	}
}

