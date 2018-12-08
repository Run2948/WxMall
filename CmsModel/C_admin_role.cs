/**  版本信息模板在安装目录下，可自行修改。
* C_admin_role.cs
*
* 功 能： N/A
* 类 名： C_admin_role
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
using System.Collections.Generic;
namespace Cms.Model
{
	/// <summary>
	/// C_admin_role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_admin_role
	{
		public C_admin_role()
		{}
		#region Model
		private int _id;
		private string _role_name;
		private int? _role_type;
		private int? _is_sys=0;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string role_name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 角色类型
		/// </summary>
		public int? role_type
		{
			set{ _role_type=value;}
			get{return _role_type;}
		}
		/// <summary>
		/// 是否系统默认0否1是
		/// </summary>
		public int? is_sys
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}
		#endregion Model
        private List<C_admin_role_value> _manager_role_values;
        /// <summary>
        /// 权限子类 
        /// </summary>
        public List<C_admin_role_value> manager_role_values
        {
            set { _manager_role_values = value; }
            get { return _manager_role_values; }
        }
	}
}

