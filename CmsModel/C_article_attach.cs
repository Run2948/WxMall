/**  版本信息模板在安装目录下，可自行修改。
* C_article_attach.cs
*
* 功 能： N/A
* 类 名： C_article_attach
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/11 15:23:01   N/A    初版
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
	/// C_article_attach:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_article_attach
	{
		public C_article_attach()
		{}
		#region Model
		private int _id;
		private int? _article_id=0;
		private string _file_name="";
		private string _file_path="";
		private int? _file_size=0;
		private string _file_ext="";
		private int? _down_num=0;
		private int? _point=0;
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
		/// 文件名
		/// </summary>
		public string file_name
		{
			set{ _file_name=value;}
			get{return _file_name;}
		}
		/// <summary>
		/// 文件路径
		/// </summary>
		public string file_path
		{
			set{ _file_path=value;}
			get{return _file_path;}
		}
		/// <summary>
		/// 文件大小(字节)
		/// </summary>
		public int? file_size
		{
			set{ _file_size=value;}
			get{return _file_size;}
		}
		/// <summary>
		/// 文件扩展名
		/// </summary>
		public string file_ext
		{
			set{ _file_ext=value;}
			get{return _file_ext;}
		}
		/// <summary>
		/// 下载次数
		/// </summary>
		public int? down_num
		{
			set{ _down_num=value;}
			get{return _down_num;}
		}
		/// <summary>
		/// 积分(正赠送负消费)
		/// </summary>
		public int? point
		{
			set{ _point=value;}
			get{return _point;}
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

