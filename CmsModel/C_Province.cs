/**  版本信息模板在安装目录下，可自行修改。
* C_Province.cs
*
* 功 能： N/A
* 类 名： C_Province
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/28 14:12:43   N/A    初版
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
	/// C_Province:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Province
	{
		public C_Province()
		{}
		#region Model
		private long _provinceid;
		private string _provincename;
		private DateTime? _datecreated;
		private DateTime? _dateupdated;
		/// <summary>
		/// 
		/// </summary>
		public long ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProvinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateCreated
		{
			set{ _datecreated=value;}
			get{return _datecreated;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateUpdated
		{
			set{ _dateupdated=value;}
			get{return _dateupdated;}
		}
		#endregion Model

	}
}

