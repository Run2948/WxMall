/**  版本信息模板在安装目录下，可自行修改。
* C_admin.cs
*
* 功 能： N/A
* 类 名： C_admin
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/28 10:48:52   N/A    初版
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
	/// C_admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_admin
	{
		public C_admin()
		{}
		#region Model
		private int _id;
		private int _role_id;
		private int? _role_type=2;
		private string _user_name;
		private string _password;
		private string _salt;
		private string _real_name="";
		private string _telephone="";
		private string _email="";
		private int? _is_lock=0;
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
		/// 角色ID
		/// </summary>
		public int role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 管理员类型1超管2系管
		/// </summary>
		public int? role_type
		{
			set{ _role_type=value;}
			get{return _role_type;}
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
		/// 登录密码
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 6位随机字符串,加密用到
		/// </summary>
		public string salt
		{
			set{ _salt=value;}
			get{return _salt;}
		}
		/// <summary>
		/// 用户昵称
		/// </summary>
		public string real_name
		{
			set{ _real_name=value;}
			get{return _real_name;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 是否锁定
		/// </summary>
		public int? is_lock
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

