using System;
namespace Cms.Model
{
	/// <summary>
	/// ws_Lottery:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ws_Lottery
	{
		public ws_Lottery()
		{}
		#region Model
		private int _id;
		private string _lname;
		private string _picurl;
		private DateTime? _stime;
		private DateTime? _etime;
		private string _info;
		private int? _isnum;
		private int? _total;
		private int? _daynum;
		private int? _typeid;
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
		public string lname
		{
			set{ _lname=value;}
			get{return _lname;}
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
		public DateTime? stime
		{
			set{ _stime=value;}
			get{return _stime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? etime
		{
			set{ _etime=value;}
			get{return _etime;}
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
		public int? isnum
		{
			set{ _isnum=value;}
			get{return _isnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? total
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? daynum
		{
			set{ _daynum=value;}
			get{return _daynum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
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

