/**  版本信息模板在安装目录下，可自行修改。
* C_user_coupon.cs
*
* 功 能： N/A
* 类 名： C_user_coupon
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/10 17:08:03   N/A    初版
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
	/// C_user_coupon:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_user_coupon
	{
		public C_user_coupon()
		{}
		#region Model
		private int _id;
		private int? _user_id;
		private int? _article_id;
		private int? _coupon_id;
        private int? _type_id;
		private string _title;
		private string _picurl;
		private decimal? _price;
		private DateTime? _stime;
		private DateTime? _etime;
		private int? _number;
		private string _content;
		private int? _status;
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
		/// 
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
		}
		/// <summary>
		/// 卷id
		/// </summary>
		public int? coupon_id
		{
			set{ _coupon_id=value;}
			get{return _coupon_id;}
		}
        /// <summary>
        /// 类型id
        /// </summary>
        public int? type_id
        {
            set { _type_id = value; }
            get { return _type_id; }
        }
		/// <summary>
		/// 卷名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 面值价格
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
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
		/// 结束时间
		/// </summary>
		public DateTime? etime
		{
			set{ _etime=value;}
			get{return _etime;}
		}
		/// <summary>
		/// 数量
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
		/// 是否使用 0未  1 已
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
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

