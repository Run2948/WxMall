/**  版本信息模板在安装目录下，可自行修改。
* C_user_oauth.cs
*
* 功 能： N/A
* 类 名： C_user_oauth
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/25 11:18:50   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Cms.Model
{
	/// <summary>
	/// C_user_oauth:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_user_oauth
	{
		public C_user_oauth()
		{}
		#region Model
		private int _id;
		private int? _user_id;
		private string _user_name;
		private string _oauth_name="0";
		private string _oauth_access_token;
		private string _oauth_openid;
		private DateTime? _add_time= DateTime.Now;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 开放平台名称
		/// </summary>
		public string oauth_name
		{
			set{ _oauth_name=value;}
			get{return _oauth_name;}
		}
		/// <summary>
		/// access_token
		/// </summary>
		public string oauth_access_token
		{
			set{ _oauth_access_token=value;}
			get{return _oauth_access_token;}
		}
		/// <summary>
		/// 授权key
		/// </summary>
		public string oauth_openid
		{
			set{ _oauth_openid=value;}
			get{return _oauth_openid;}
		}
		/// <summary>
		/// 授权时间
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

