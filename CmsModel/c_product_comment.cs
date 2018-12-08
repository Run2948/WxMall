/**  版本信息模板在安装目录下，可自行修改。
* c_product_comment.cs
*
* 功 能： N/A
* 类 名： c_product_comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/4/30 22:26:04   N/A    初版
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
	/// c_product_comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class c_product_comment
	{
		public c_product_comment()
		{}
		#region Model
		private int _id;
		private int? _productid;
		private int? _parentid;
		private int? _userid;
		private string _username;
		private string _userip;
		private string _content;
		private int? _is_lock;
		private DateTime? _add_time;
		private int? _is_reply;
		private string _reply_content;
		private DateTime? _reply_time;
		private int? _descscore;
		private int? _logisticsscore;
		private int? _anonymous;
		private string _litpic;
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
		public int? parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userIp
		{
			set{ _userip=value;}
			get{return _userip;}
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
		/// 
		/// </summary>
		public int? is_lock
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? is_reply
		{
			set{ _is_reply=value;}
			get{return _is_reply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reply_content
		{
			set{ _reply_content=value;}
			get{return _reply_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? reply_time
		{
			set{ _reply_time=value;}
			get{return _reply_time;}
		}
		/// <summary>
		/// 描述评分
		/// </summary>
		public int? descScore
		{
			set{ _descscore=value;}
			get{return _descscore;}
		}
		/// <summary>
		/// 物流评分
		/// </summary>
		public int? logisticsScore
		{
			set{ _logisticsscore=value;}
			get{return _logisticsscore;}
		}
		/// <summary>
		/// 是否匿名
		/// </summary>
		public int? anonymous
		{
			set{ _anonymous=value;}
			get{return _anonymous;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string litpic
		{
			set{ _litpic=value;}
			get{return _litpic;}
		}
		#endregion Model

	}
}

