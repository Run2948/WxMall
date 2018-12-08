/**  版本信息模板在安装目录下，可自行修改。
* C_integral_rec.cs
*
* 功 能： N/A
* 类 名： C_integral_rec
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/4 10:53:10   N/A    初版
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
	/// C_integral_rec:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_integral_rec
	{
		public C_integral_rec()
		{}
		#region Model
		private int _id;
		private int? _article_id;
		private int? _user_id;
		private string _usercard;
		private string _openid;
		private string _numberid;
		private string _scorename;
		private string _title;
		private long? _wescore;
		private int? _quantity;
		private int? _type;
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
		/// 文章id  产品id
		/// </summary>
		public int? article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
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
		/// 会员卡
		/// </summary>
		public string usercard
		{
			set{ _usercard=value;}
			get{return _usercard;}
		}
		/// <summary>
		/// 微信号（微信账号）
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 微信积分单号 （用于和微信销售单对应）
		/// </summary>
		public string numberid
		{
			set{ _numberid=value;}
			get{return _numberid;}
		}
		/// <summary>
		/// 积分名称，来源 （例：礼品兑换，消售积分）
		/// </summary>
		public string scorename
		{
			set{ _scorename=value;}
			get{return _scorename;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 例：1000  就是加1000分 -1000就是减1000分 
		/// </summary>
		public long? wescore
		{
			set{ _wescore=value;}
			get{return _wescore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 积分类型 0表示得积分  1表示消费积分
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

