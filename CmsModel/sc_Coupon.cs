/**  版本信息模板在安装目录下，可自行修改。
* sc_Coupon.cs
*
* 功 能： N/A
* 类 名： sc_Coupon
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/10 16:37:53   N/A    初版
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
	/// sc_Coupon:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sc_Coupon
	{
		public sc_Coupon()
		{}
		#region Model
		private int _id;
		private int? _type_id;
		private int? _article_id;
		private int? _peson;
		private string _cname;
		private string _picurl;
		private int? _cmoney;
		private DateTime? _stime;
		private DateTime? _etime;
		private int? _number;
		private string _content;
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
		/// 优惠卷类型
		/// </summary>
		public int? type_id
		{
			set{ _type_id=value;}
			get{return _type_id;}
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
		/// 选择人群  0:全部会员
		/// </summary>
		public int? peson
		{
			set{ _peson=value;}
			get{return _peson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string picurl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cmoney
		{
			set{ _cmoney=value;}
			get{return _cmoney;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? stime
		{
			set{ _stime=value;}
			get{return _stime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? etime
		{
			set{ _etime=value;}
			get{return _etime;}
		}
		/// <summary>
		/// 每个用户可以获得多少
		/// </summary>
		public int? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 使用说明
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

