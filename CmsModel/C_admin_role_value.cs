/**  版本信息模板在安装目录下，可自行修改。
* C_admin_role_value.cs
*
* 功 能： N/A
* 类 名： C_admin_role_value
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
	/// C_admin_role_value:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_admin_role_value
	{
		public C_admin_role_value()
		{ }
		#region Model
		private int _id;
		private int? _role_id;
		private string _nav_name;
		private string _action_type;
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
        public int? role_id
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
		/// <summary>
		/// 导航名称
		/// </summary>
		public string nav_name
		{
			set{ _nav_name=value;}
			get{return _nav_name;}
		}
		/// <summary>
		/// 权限类型
		/// </summary>
		public string action_type
		{
			set{ _action_type=value;}
			get{return _action_type;}
		}
		#endregion Model
       
	}
}

