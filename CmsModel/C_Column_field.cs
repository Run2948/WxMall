/**  版本信息模板在安装目录下，可自行修改。
* C_Column_field.cs
*
* 功 能： N/A
* 类 名： C_Column_field
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
	/// C_Column_field:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Column_field
	{
		public C_Column_field()
		{}
		#region Model
		private int _id;
		private int _channel_id;
		private int _field_id;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 频道ID
		/// </summary>
		public int channel_id
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// 字段ID
		/// </summary>
		public int field_id
		{
			set{ _field_id=value;}
			get{return _field_id;}
		}
		#endregion Model

	}
}

