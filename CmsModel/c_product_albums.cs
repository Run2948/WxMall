/**  版本信息模板在安装目录下，可自行修改。
* c_product_albums.cs
*
* 功 能： N/A
* 类 名： c_product_albums
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/4/29 19:58:48   N/A    初版
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
	/// c_product_albums:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class c_product_albums
	{
		public c_product_albums()
		{}
		#region Model
		private int _id;
		private int? _productid;
		private string _thumb_path;
		private string _original_path;
		private string _remark;
		private DateTime? _add_time;
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
		public int? productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string thumb_path
		{
			set{ _thumb_path=value;}
			get{return _thumb_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string original_path
		{
			set{ _original_path=value;}
			get{return _original_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

