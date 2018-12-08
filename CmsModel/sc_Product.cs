using System;
namespace Cms.Model
{
	/// <summary>
	/// sc_Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sc_Product
	{
		public sc_Product()
		{}
		#region Model
		private int _id;
		private int? _pid;
		private string _pname;
		private string _picurl;
		private decimal? _price;
		private decimal? _marketpice;
		private string _material;
		private string _property;
		private int? _integral;
		private int? _stock;
		private string _content;
		private DateTime? _updatetime;
		private int? _isjf;
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
		public string picurl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? marketpice
		{
			set{ _marketpice=value;}
			get{return _marketpice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Material
		{
			set{ _material=value;}
			get{return _material;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Property
		{
			set{ _property=value;}
			get{return _property;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
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
		public int? isjf
		{
			set{ _isjf=value;}
			get{return _isjf;}
		}
		#endregion Model

	}
}

