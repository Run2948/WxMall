/**  版本信息模板在安装目录下，可自行修改。
* C_collect.cs
*
* 功 能： N/A
* 类 名： C_collect
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/15 11:42:23   N/A    初版
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
	/// C_collect:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_collect
	{
		public C_collect()
		{}
		#region Model
		private int _id;
		private int? _article_id;
		private int? _typeid;
		private int? _user_id;
		private string _title;
		private decimal? _price;
		private int? _integral;
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
		/// 文章id
		/// </summary>
		public int? article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
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
		/// 会员id
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
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

