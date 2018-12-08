using System;
namespace Cms.Model
{
	/// <summary>
	/// 微信请求回复规则表
	/// </summary>
	[Serializable]
	public partial class wx_requestRule
	{
		public wx_requestRule()
		{}
		#region Model
		private int _id;
		private int? _uid;
        private int? _wid;
		private string _rulename;
		private string _reqkeywords;
		private int? _reqesttype;
		private int? _responsetype;
		private bool _isdefault= false;
		private string _modelfunctionname;
		private int? _modelfunctionid;
		private int? _seq;
		private DateTime? _createdate;
		private string _agenturl;
		private string _agenttoken;
		private bool _islikesearch= false;
		private int? _extint;
		private int? _extint2;
		private string _extstr;
		private string _extstr2;
		private string _extstr3;
		private string _extstr4;
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
        /// 微信公众帐号信息表主键Id
        /// </summary>
        public int? wId
        {
            set { _wid = value; }
            get { return _wid; }
        }

		/// <summary>
		/// 规则名称
		/// </summary>
		public string ruleName
		{
			set{ _rulename=value;}
			get{return _rulename;}
		}
		/// <summary>
		/// 请求的关键词（多个中间使用英文逗号隔开）
		/// </summary>
		public string reqKeywords
		{
			set{ _reqkeywords=value;}
			get{return _reqkeywords;}
		}
		/// <summary>
		/// 请求类型 （文字1，图片2，语音3，链接4，地理位置5，6关注，7取消关注，8扫描带参数二维码事件，上报地理位置事件9，自定义菜单事件10）
		/// </summary>
		public int? reqestType
		{
			set{ _reqesttype=value;}
			get{return _reqesttype;}
		}
		/// <summary>
		/// 回复类型（文本1，图文2，语音3，视频4,第三方接口5）
		/// </summary>
		public int? responseType
		{
			set{ _responsetype=value;}
			get{return _responsetype;}
		}
		/// <summary>
		/// 是默认回复
		/// </summary>
		public bool isDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 功能模版名称
		/// </summary>
		public string modelFunctionName
		{
			set{ _modelfunctionname=value;}
			get{return _modelfunctionname;}
		}
		/// <summary>
		/// 功能模块Id
		/// </summary>
		public int? modelFunctionId
		{
			set{ _modelfunctionid=value;}
			get{return _modelfunctionid;}
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
		/// 第三方接口的url
		/// </summary>
		public string agentUrl
		{
			set{ _agenturl=value;}
			get{return _agenturl;}
		}
		/// <summary>
		/// 第三方token值
		/// </summary>
		public string agentToken
		{
			set{ _agenttoken=value;}
			get{return _agenttoken;}
		}
		/// <summary>
		/// 是模糊查询
		/// </summary>
		public bool isLikeSearch
		{
			set{ _islikesearch=value;}
			get{return _islikesearch;}
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
		public string extStr3
		{
			set{ _extstr3=value;}
			get{return _extstr3;}
		}
		/// <summary>
		/// 扩展str4
		/// </summary>
		public string extStr4
		{
			set{ _extstr4=value;}
			get{return _extstr4;}
		}
		#endregion Model

	}
}

