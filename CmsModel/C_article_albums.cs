/**  版本信息模板在安装目录下，可自行修改。
* C_article_albums.cs
*
* 功 能： N/A
* 类 名： C_article_albums
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/11 15:23:00   N/A    初版
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
	/// C_article_albums:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_article_albums
	{
		public C_article_albums()
		{}
		#region Model
		private int _id;
		private int? _article_id=0;
		private string _thumb_path="";
		private string _original_path="";
		private string _remark="";
		private DateTime? _add_time= DateTime.Now;
		/// <summary>
		/// 自增ID
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
		/// 缩略图地址
		/// </summary>
		public string thumb_path
		{
			set{ _thumb_path=value;}
			get{return _thumb_path;}
		}
		/// <summary>
		/// 原图地址
		/// </summary>
		public string original_path
		{
			set{ _original_path=value;}
			get{return _original_path;}
		}
		/// <summary>
		/// 图片描述
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

