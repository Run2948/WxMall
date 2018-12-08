using System;
namespace Cms.Model
{
	/// <summary>
	/// 刮刮卡用户抽奖临时表
	/// </summary>
	[Serializable]
	public partial class wx_ggkUsersTemp
	{
		public wx_ggkUsersTemp()
		{}
		#region Model
		private int _id;
		private int? _actid;
		private string _openid;
		private int? _times;
		private DateTime? _createdate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 活动Id
		/// </summary>
		public int? actId
		{
			set{ _actid=value;}
			get{return _actid;}
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
		/// 次数
		/// </summary>
		public int? times
		{
			set{ _times=value;}
			get{return _times;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

