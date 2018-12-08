/**  版本信息模板在安装目录下，可自行修改。
* sc_stores.cs
*
* 功 能： N/A
* 类 名： sc_stores
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/20 17:01:33   N/A    初版
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
	/// sc_stores:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sc_stores
	{
		public sc_stores()
		{}
		#region Model
		private int _id;
		private int? _pid;
		private string _location;
		private string _city;
		private string _county;
		private string _storename;
		private string _info;
		private int? _sort_id;
		private string _picurl;
		private string _linkurl;
		private string _latitude;
		private string _longitude;
		private int? _ishidden;
		private DateTime? _updatetime;
		private string _tel;
		private string _address;
		private string _verificationpass;
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
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
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
		/// 
		/// </summary>
		public string storename
		{
			set{ _storename=value;}
			get{return _storename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string info
		{
			set{ _info=value;}
			get{return _info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string picurl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linkurl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string latitude
		{
			set{ _latitude=value;}
			get{return _latitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isHidden
		{
			set{ _ishidden=value;}
			get{return _ishidden;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 核销密码
		/// </summary>
		public string verificationPass
		{
			set{ _verificationpass=value;}
			get{return _verificationpass;}
		}
		#endregion Model

	}
}

