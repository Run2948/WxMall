/**  版本信息模板在安装目录下，可自行修改。
* C_article_attribute_field.cs
*
* 功 能： N/A
* 类 名： C_article_attribute_field
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/5 17:08:16   N/A    初版
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
	/// C_article_attribute_field:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_article_attribute_field
	{
		public C_article_attribute_field()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _title="";
		private string _control_type;
		private string _data_type;
		private int? _data_length=0;
		private int? _data_place=0;
		private string _item_option="";
		private string _default_value="";
		private int? _is_required=0;
		private int? _is_password=0;
		private int? _is_html=0;
		private int? _editor_type=0;
		private string _valid_tip_msg="";
		private string _valid_error_msg="";
		private string _valid_pattern="";
		private int? _sort_id=99;
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
		/// 列名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 控件类型
		/// </summary>
		public string control_type
		{
			set{ _control_type=value;}
			get{return _control_type;}
		}
		/// <summary>
		/// 字段类型
		/// </summary>
		public string data_type
		{
			set{ _data_type=value;}
			get{return _data_type;}
		}
		/// <summary>
		/// 字段长度
		/// </summary>
		public int? data_length
		{
			set{ _data_length=value;}
			get{return _data_length;}
		}
		/// <summary>
		/// 小数点位数
		/// </summary>
		public int? data_place
		{
			set{ _data_place=value;}
			get{return _data_place;}
		}
		/// <summary>
		/// 选项列表
		/// </summary>
		public string item_option
		{
			set{ _item_option=value;}
			get{return _item_option;}
		}
		/// <summary>
		/// 默认值
		/// </summary>
		public string default_value
		{
			set{ _default_value=value;}
			get{return _default_value;}
		}
		/// <summary>
		/// 是否必填0非必填1必填
		/// </summary>
		public int? is_required
		{
			set{ _is_required=value;}
			get{return _is_required;}
		}
		/// <summary>
		/// 是否密码框
		/// </summary>
		public int? is_password
		{
			set{ _is_password=value;}
			get{return _is_password;}
		}
		/// <summary>
		/// 是否允许HTML
		/// </summary>
		public int? is_html
		{
			set{ _is_html=value;}
			get{return _is_html;}
		}
		/// <summary>
		/// 编辑器类型0标准型1简洁型
		/// </summary>
		public int? editor_type
		{
			set{ _editor_type=value;}
			get{return _editor_type;}
		}
		/// <summary>
		/// 验证提示信息
		/// </summary>
		public string valid_tip_msg
		{
			set{ _valid_tip_msg=value;}
			get{return _valid_tip_msg;}
		}
		/// <summary>
		/// 验证失败提示信息
		/// </summary>
		public string valid_error_msg
		{
			set{ _valid_error_msg=value;}
			get{return _valid_error_msg;}
		}
		/// <summary>
		/// 验证正则表达式
		/// </summary>
		public string valid_pattern
		{
			set{ _valid_pattern=value;}
			get{return _valid_pattern;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 系统默认
		/// </summary>
		public int? is_sys
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}
		#endregion Model

	}
}

