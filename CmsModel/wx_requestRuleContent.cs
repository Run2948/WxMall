using System;
namespace Cms.Model
{
	/// <summary>
	/// 微信请求回复的内容
	/// </summary>
	[Serializable]
	public partial class wx_requestRuleContent
	{
		public wx_requestRuleContent()
		{}
		#region Model
		private int _id;
		private int? _uid;
		private int? _rid;
		private string _rcontent;
		private string _rcontent2;
		private string _detailurl;
		private string _picurl;
		private string _mediaurl;
		private string _meidahdurl;
		private string _remark;
		private int? _seq;
		private DateTime? _createdate;
		private int? _extint;
		private int? _extint2;
		private string _extstr;
		private string _extstr2;
		private string _extstr3;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户表主键Id
		/// </summary>
		public int? uId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 规则主键Id
		/// </summary>
		public int? rId
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string rContent
		{
			set{ _rcontent=value;}
			get{return _rcontent;}
		}
		/// <summary>
		/// 内容2
		/// </summary>
		public string rContent2
		{
			set{ _rcontent2=value;}
			get{return _rcontent2;}
		}
		/// <summary>
		/// 详情链接地址
		/// </summary>
		public string detailUrl
		{
			set{ _detailurl=value;}
			get{return _detailurl;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 语音或视频地址
		/// </summary>
		public string mediaUrl
		{
			set{ _mediaurl=value;}
			get{return _mediaurl;}
		}
		/// <summary>
		/// 高清语音或者视频地址
		/// </summary>
		public string meidaHDUrl
		{
			set{ _meidahdurl=value;}
			get{return _meidahdurl;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 扩展int
		/// </summary>
		public int? extInt
		{
			set{ _extint=value;}
			get{return _extint;}
		}
		/// <summary>
		/// 扩展int
		/// </summary>
		public int? extInt2
		{
			set{ _extint2=value;}
			get{return _extint2;}
		}
		/// <summary>
		/// 扩展str
		/// </summary>
		public string extStr
		{
			set{ _extstr=value;}
			get{return _extstr;}
		}
		/// <summary>
		/// 扩展str2
		/// </summary>
		public string extStr2
		{
			set{ _extstr2=value;}
			get{return _extstr2;}
		}
		/// <summary>
		/// 扩展str3
		/// </summary>
		public string extstr3
		{
			set{ _extstr3=value;}
			get{return _extstr3;}
		}
		#endregion Model

	}
}

