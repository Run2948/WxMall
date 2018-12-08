using System;
namespace Cms.Model
{
	/// <summary>
	/// user_coupon:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class user_coupon
	{
		public user_coupon()
		{}
		#region Model
		private int _id;
		private string _usercard;
		private int? _pid;
		private int? _isuse;
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
		public string usercard
		{
			set{ _usercard=value;}
			get{return _usercard;}
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
		/// 
		/// </summary>
		public int? isuse
		{
			set{ _isuse=value;}
			get{return _isuse;}
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

