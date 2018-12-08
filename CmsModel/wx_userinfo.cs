using System;
namespace Cms.Model
{
	/// <summary>
	/// wx_userinfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_userinfo
	{
		public wx_userinfo()
		{}
		#region Model
		private int _id;
		private int? _subscribe;
		private string _openid;
		private string _nickname;
		private int? _sex;
		private string _language;
		private string _city;
		private string _province;
		private string _country;
		private string _headimgurl;
		private string _subscribe_time;
		private string _remark;
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
		public int? subscribe
		{
			set{ _subscribe=value;}
			get{return _subscribe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string language
		{
			set{ _language=value;}
			get{return _language;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string headimgurl
		{
			set{ _headimgurl=value;}
			get{return _headimgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string subscribe_time
		{
			set{ _subscribe_time=value;}
			get{return _subscribe_time;}
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
		public DateTime? updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

