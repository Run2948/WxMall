/**  版本信息模板在安装目录下，可自行修改。
* C_WebSiteconfig.cs
*
* 功 能： N/A
* 类 名： C_WebSiteconfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/3/19 13:50:17   N/A    初版
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
	/// C_WebSiteconfig:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_WebSiteconfig
	{
		public C_WebSiteconfig()
		{}
		#region Model
		private int _siteid;
		private string _webname;
		private string _weburl;
		private string _title;
		private string _keyword;
		private string _description;
		private string _upload;
		private string _copyright;
		private string _icprecord;
		private string _adress;
		private string _telphone;
		private string _mobiephone;
		private string _fax;
		private string _email;
		private string _contactperson;
		private string _textparam1;
		private string _textparam2;
		private string _textparam3;
		private string _textparam4;
		private string _textparam5;
		private string _logo;
		private string _mlogo;
		private string _qq;
		private string _weixin;
		private string _tel;
		/// <summary>
		/// 
		/// </summary>
		public int siteid
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webName
		{
			set{ _webname=value;}
			get{return _webname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weburl
		{
			set{ _weburl=value;}
			get{return _weburl;}
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
		public string keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string upload
		{
			set{ _upload=value;}
			get{return _upload;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Copyright
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IcpRecord
		{
			set{ _icprecord=value;}
			get{return _icprecord;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adress
		{
			set{ _adress=value;}
			get{return _adress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telphone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobiephone
		{
			set{ _mobiephone=value;}
			get{return _mobiephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contactperson
		{
			set{ _contactperson=value;}
			get{return _contactperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string textParam1
		{
			set{ _textparam1=value;}
			get{return _textparam1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string textParam2
		{
			set{ _textparam2=value;}
			get{return _textparam2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string textParam3
		{
			set{ _textparam3=value;}
			get{return _textparam3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string textParam4
		{
			set{ _textparam4=value;}
			get{return _textparam4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string textParam5
		{
			set{ _textparam5=value;}
			get{return _textparam5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mLogo
		{
			set{ _mlogo=value;}
			get{return _mlogo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qq
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weixin
		{
			set{ _weixin=value;}
			get{return _weixin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		#endregion Model

	}
}

