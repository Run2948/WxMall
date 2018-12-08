using System;
namespace Cms.Model
{
	/// <summary>
	/// wx_ConcernReply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_ConcernReply
	{
		public wx_ConcernReply()
		{}
		#region Model
		private int _id;
		private int? _typeid;
		private string _title;
		private string _contents;
		private string _fileurl;
		private DateTime? _updatetime;
		private string _url;
		private int? _isopen;
		private string _media_id;
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
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fileurl
		{
			set{ _fileurl=value;}
			get{return _fileurl;}
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
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isopen
		{
			set{ _isopen=value;}
			get{return _isopen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string media_id
		{
			set{ _media_id=value;}
			get{return _media_id;}
		}
		#endregion Model

	}
}

