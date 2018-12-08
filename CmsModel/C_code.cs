using System;
namespace Cms.Model
{
	/// <summary>
	/// C_code:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_code
	{
		public C_code()
		{}
		#region Model
		private int _id;
		private string _vcode;
		private string _vphone;
		private int? _isare;
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
		public string vcode
		{
			set{ _vcode=value;}
			get{return _vcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vphone
		{
			set{ _vphone=value;}
			get{return _vphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isare
		{
			set{ _isare=value;}
			get{return _isare;}
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

