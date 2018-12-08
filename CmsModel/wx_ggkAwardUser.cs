using System;
namespace Cms.Model
{
	/// <summary>
	/// 中奖用户信息
	/// </summary>
	[Serializable]
	public partial class wx_ggkAwardUser
	{
		public wx_ggkAwardUser()
		{}
		#region Model
		private int _id;
		private int? _actid;
		private string _uname;
		private string _utel;
		private string _openid;
		private string _jxname;
		private string _jpname;
		private DateTime? _createdate;
		private bool _haslingqu;
		private string _sn;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 活动主键Id
		/// </summary>
		public int? actId
		{
			set{ _actid=value;}
			get{return _actid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string uName
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 用户手机号
		/// </summary>
		public string uTel
		{
			set{ _utel=value;}
			get{return _utel;}
		}
		/// <summary>
		/// 用户openid
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string jxName
		{
			set{ _jxname=value;}
			get{return _jxname;}
		}
		/// <summary>
		/// 奖品名称
		/// </summary>
		public string jpName
		{
			set{ _jpname=value;}
			get{return _jpname;}
		}
		/// <summary>
		/// 中奖时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 已经领取
		/// </summary>
		public bool hasLingQu
		{
			set{ _haslingqu=value;}
			get{return _haslingqu;}
		}
		/// <summary>
		/// sn码
		/// </summary>
		public string sn
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		#endregion Model

	}
}

