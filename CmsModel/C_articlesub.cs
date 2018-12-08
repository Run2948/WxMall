/**  版本信息模板在安装目录下，可自行修改。
* C_articlesub.cs
*
* 功 能： N/A
* 类 名： C_articlesub
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/7 10:31:14   N/A    初版
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
	/// C_articlesub:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_articlesub
	{
		public C_articlesub()
		{}
		#region Model
		private int _id;
		private int? _parent_id;
		private string _price;
		private string _offerprice;
		private int? _stock;
		private string _format;
		private string _feature;
		private string _suitable;
		private string _adress;
		private string _shelflife;
		private string _belong;
		private string _restriction;
		private string _productype;
		private string _colortype;
		private string _toostype;
		private string _bardtype;
		private string _s_textparam1;
		private string _s_textparam2;
		private string _s_textparam3;
		private string _s_textparam4;
		private string _s_textparam5;
		private string _s_textparam6;
		private string _s_textparam7;
		private string _s_textparam8;
		private string _s_textparam9;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? parent_Id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 市场价格
		/// </summary>
		public string Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 优惠价格
		/// </summary>
		public string Offerprice
		{
			set{ _offerprice=value;}
			get{return _offerprice;}
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
		/// 规格类型
		/// </summary>
		public string format
		{
			set{ _format=value;}
			get{return _format;}
		}
		/// <summary>
		/// 特性
		/// </summary>
		public string feature
		{
			set{ _feature=value;}
			get{return _feature;}
		}
		/// <summary>
		/// 适合肤质
		/// </summary>
		public string Suitable
		{
			set{ _suitable=value;}
			get{return _suitable;}
		}
		/// <summary>
		/// 产地
		/// </summary>
		public string adress
		{
			set{ _adress=value;}
			get{return _adress;}
		}
		/// <summary>
		/// 保质期
		/// </summary>
		public string ShelfLife
		{
			set{ _shelflife=value;}
			get{return _shelflife;}
		}
		/// <summary>
		/// 属于套装
		/// </summary>
		public string Belong
		{
			set{ _belong=value;}
			get{return _belong;}
		}
		/// <summary>
		/// 限购数量
		/// </summary>
		public string Restriction
		{
			set{ _restriction=value;}
			get{return _restriction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string productype
		{
			set{ _productype=value;}
			get{return _productype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string colortype
		{
			set{ _colortype=value;}
			get{return _colortype;}
		}
		/// <summary>
		/// 工具分类
		/// </summary>
		public string toostype
		{
			set{ _toostype=value;}
			get{return _toostype;}
		}
		/// <summary>
		/// 品牌分类
		/// </summary>
		public string bardtype
		{
			set{ _bardtype=value;}
			get{return _bardtype;}
		}
		/// <summary>
		/// 预留字段
		/// </summary>
		public string s_textParam1
		{
			set{ _s_textparam1=value;}
			get{return _s_textparam1;}
		}
		/// <summary>
		/// 预留字段2
		/// </summary>
		public string s_textParam2
		{
			set{ _s_textparam2=value;}
			get{return _s_textparam2;}
		}
		/// <summary>
		/// 预留字段3
		/// </summary>
		public string s_textParam3
		{
			set{ _s_textparam3=value;}
			get{return _s_textparam3;}
		}
		/// <summary>
		/// 预留字段4
		/// </summary>
		public string s_textParam4
		{
			set{ _s_textparam4=value;}
			get{return _s_textparam4;}
		}
		/// <summary>
		/// 预留字段
		/// </summary>
		public string s_textParam5
		{
			set{ _s_textparam5=value;}
			get{return _s_textparam5;}
		}
		/// <summary>
		/// 预留字段2
		/// </summary>
		public string s_textParam6
		{
			set{ _s_textparam6=value;}
			get{return _s_textparam6;}
		}
		/// <summary>
		/// 预留字段3
		/// </summary>
		public string s_textParam7
		{
			set{ _s_textparam7=value;}
			get{return _s_textparam7;}
		}
		/// <summary>
		/// 预留字段4
		/// </summary>
		public string s_textParam8
		{
			set{ _s_textparam8=value;}
			get{return _s_textparam8;}
		}
		/// <summary>
		/// 预留字段4
		/// </summary>
		public string s_textParam9
		{
			set{ _s_textparam9=value;}
			get{return _s_textparam9;}
		}
		#endregion Model

	}
}

