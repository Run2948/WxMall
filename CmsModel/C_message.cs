/**  版本信息模板在安装目录下，可自行修改。
* C_message.cs
*
* 功 能： N/A
* 类 名： C_message
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/11 18:39:01   N/A    初版
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
	/// C_message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_message
	{
		public C_message()
		{}
		#region Model
		private int _messageid;
		private string _name;
		private string _unitname;
		private string _phonenum;
		private string _telnum;
		private string _email;
		private string _qq;
		private string _adress;
		private string _title;
		private string _content;
		private int? _userid;
		private string _username;
		private DateTime? _updatetime;
		private string _replay;
		private string _re_updatetime;
		private string _textparam1;
		private string _textparam2;
		private string _textparam3;
		private string _textparam4;
		private string _textparam5;
		/// <summary>
		/// 
		/// </summary>
		public int messageid
		{
			set{ _messageid=value;}
			get{return _messageid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 单位名称
		/// </summary>
		public string UnitName
		{
			set{ _unitname=value;}
			get{return _unitname;}
		}
		/// <summary>
		/// 电话号码
		/// </summary>
		public string PhoneNum
		{
			set{ _phonenum=value;}
			get{return _phonenum;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string telNum
		{
			set{ _telnum=value;}
			get{return _telnum;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// QQ号码
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string adress
		{
			set{ _adress=value;}
			get{return _adress;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 用户id
		/// </summary>
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户账号
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 回复
		/// </summary>
		public string replay
		{
			set{ _replay=value;}
			get{return _replay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string re_updateTime
		{
			set{ _re_updatetime=value;}
			get{return _re_updatetime;}
		}
		/// <summary>
		/// 预留字段
		/// </summary>
		public string textParam1
		{
			set{ _textparam1=value;}
			get{return _textparam1;}
		}
		/// <summary>
		/// 预留字段2
		/// </summary>
		public string textParam2
		{
			set{ _textparam2=value;}
			get{return _textparam2;}
		}
		/// <summary>
		/// 预留字段3
		/// </summary>
		public string textParam3
		{
			set{ _textparam3=value;}
			get{return _textparam3;}
		}
		/// <summary>
		/// 预留字段4
		/// </summary>
		public string textParam4
		{
			set{ _textparam4=value;}
			get{return _textparam4;}
		}
		/// <summary>
		/// 预留字段5
		/// </summary>
		public string textParam5
		{
			set{ _textparam5=value;}
			get{return _textparam5;}
		}
		#endregion Model

	}
}

