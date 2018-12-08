using System;
namespace Cms.Model
{
	/// <summary>
	/// XT_ChatLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XT_ChatLog
	{
		public XT_ChatLog()
		{}
		#region Model
		private int _chatid;
		private string _fromusername="";
		private string _worker="";
		private string _tousername="";
		private string _sendusername="";
		private string _opercode="";
		private string _time="";
		private string _msgcontent="";
		private string _remark;
		private DateTime? _createtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int Chatid
		{
			set{ _chatid=value;}
			get{return _chatid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FromUserName
		{
			set{ _fromusername=value;}
			get{return _fromusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Worker
		{
			set{ _worker=value;}
			get{return _worker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ToUserName
		{
			set{ _tousername=value;}
			get{return _tousername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendUserName
		{
			set{ _sendusername=value;}
			get{return _sendusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperCode
		{
			set{ _opercode=value;}
			get{return _opercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgContent
		{
			set{ _msgcontent=value;}
			get{return _msgcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

