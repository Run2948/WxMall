/**  版本信息模板在安装目录下，可自行修改。
* C_article_comment.cs
*
* 功 能： N/A
* 类 名： C_article_comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/25 9:44:43   N/A    初版
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
	/// C_article_comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_article_comment
	{
		public C_article_comment()
		{}
		#region Model
		private int _id;
		private int? _channel_id=0;
		private int? _article_id=0;
		private int? _parent_id=0;
		private int? _user_id=0;
		private string _user_name="";
		private string _user_ip;
		private string _content;
		private int? _is_lock=0;
		private DateTime? _add_time= DateTime.Now;
		private int? _is_reply=0;
		private string _reply_content;
		private DateTime? _reply_time;
		private int? _hits;
		private string _subcontent;
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
		public int? channel_id
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// 主表ID
		/// </summary>
		public int? article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
		}
		/// <summary>
		/// 父评论ID
		/// </summary>
		public int? parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 用户IP
		/// </summary>
		public string user_ip
		{
			set{ _user_ip=value;}
			get{return _user_ip;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 是否锁定
		/// </summary>
		public int? is_lock
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
		}
		/// <summary>
		/// 发表时间
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 是否已答复
		/// </summary>
		public int? is_reply
		{
			set{ _is_reply=value;}
			get{return _is_reply;}
		}
		/// <summary>
		/// 答复内容
		/// </summary>
		public string reply_content
		{
			set{ _reply_content=value;}
			get{return _reply_content;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime? reply_time
		{
			set{ _reply_time=value;}
			get{return _reply_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hits
		{
			set{ _hits=value;}
			get{return _hits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string subcontent
		{
			set{ _subcontent=value;}
			get{return _subcontent;}
		}
		#endregion Model

	}
}

