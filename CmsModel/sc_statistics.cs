using System;
namespace Cms.Model
{
	/// <summary>
	/// sc_statistics:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sc_statistics
	{
		public sc_statistics()
		{}
		#region Model
		private int _id;
		private string _typename;
		private string _typecontents;
		private int? _msgnumber;
		private int? _visitnumber;
		private int? _gznumber;
		private int? _qxnumber;
		private int? _doingnumber;
		private int? _zfnumber;
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
		public string typename
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string typecontents
		{
			set{ _typecontents=value;}
			get{return _typecontents;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? msgnumber
		{
			set{ _msgnumber=value;}
			get{return _msgnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? visitnumber
		{
			set{ _visitnumber=value;}
			get{return _visitnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gznumber
		{
			set{ _gznumber=value;}
			get{return _gznumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? qxnumber
		{
			set{ _qxnumber=value;}
			get{return _qxnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? doingnumber
		{
			set{ _doingnumber=value;}
			get{return _doingnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? zfnumber
		{
			set{ _zfnumber=value;}
			get{return _zfnumber;}
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

