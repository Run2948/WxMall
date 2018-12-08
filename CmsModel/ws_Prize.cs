using System;
namespace Cms.Model
{
	/// <summary>
	/// ws_Prize:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ws_Prize
	{
		public ws_Prize()
		{}
		#region Model
		private int _id;
		private int? _pid;
		private string _pname;
		private string _prize;
		private int? _quantity;
		private int? _probability;
		private int? _ordernumber;
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
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pname
		{
			set{ _pname=value;}
			get{return _pname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prize
		{
			set{ _prize=value;}
			get{return _prize;}
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
		/// 
		/// </summary>
		public int? probability
		{
			set{ _probability=value;}
			get{return _probability;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? orderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
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

