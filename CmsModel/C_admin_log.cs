/**  版本信息模板在安装目录下，可自行修改。
* C_admin_log.cs
*
* 功 能： N/A
* 类 名： C_admin_log
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/28 10:48:53   N/A    初版
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
	/// C_admin_log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_admin_log
	{
		public C_admin_log()
		{}
		#region Model
		private int _id;
		private int? _user_id;
		private string _user_name;
		private string _action_type;
		private string _remark;
		private string _user_ip;
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
		/// 操作类型
		/// </summary>
		public string action_type
		{
			set{ _action_type=value;}
			get{return _action_type;}
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
		/// 用户IP
		/// </summary>
		public string user_ip
		{
			set{ _user_ip=value;}
			get{return _user_ip;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

