/**  版本信息模板在安装目录下，可自行修改。
* c_user_address.cs
*
* 功 能： N/A
* 类 名： c_user_address
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/28 11:54:45   N/A    初版
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
	/// c_user_address:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class c_user_address
	{
		public c_user_address()
		{}
		#region Model
		private int _id;
		private int? _user_id;
		private string _consignee;
		private string _cellphone;
		private string _code;
		private string _location;
		private string _city;
		private string _county;
		private string _street;
		private string _address;
		private int? _is_default;
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
		/// 会员id
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 收货人
		/// </summary>
		public string consignee
		{
			set{ _consignee=value;}
			get{return _consignee;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string cellphone
		{
			set{ _cellphone=value;}
			get{return _cellphone;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 所在地区省
		/// </summary>
		public string location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 市
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 区
		/// </summary>
		public string county
		{
			set{ _county=value;}
			get{return _county;}
		}
		/// <summary>
		/// 街道
		/// </summary>
		public string street
		{
			set{ _street=value;}
			get{return _street;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 是否默认
		/// </summary>
		public int? is_default
		{
			set{ _is_default=value;}
			get{return _is_default;}
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

