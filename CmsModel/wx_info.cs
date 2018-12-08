using System;
namespace Cms.Model
{
	/// <summary>
	/// wx_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_info
	{
		public wx_info()
		{}
		#region Model
		private int _id;
		private string _wxid;
		private string _appid;
		private string _appsecret;
		private string _access_token;
		private string _url;
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
		public string wxid
		{
			set{ _wxid=value;}
			get{return _wxid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppId
		{
			set{ _appid=value;}
			get{return _appid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppSecret
		{
			set{ _appsecret=value;}
			get{return _appsecret;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string access_token
		{
			set{ _access_token=value;}
			get{return _access_token;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		#endregion Model

	}
}

