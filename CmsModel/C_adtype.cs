/**  版本信息模板在安装目录下，可自行修改。
* C_adtype.cs
*
* 功 能： N/A
* 类 名： C_adtype
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/6/21 15:34:25   N/A    初版
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
	/// C_adtype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_adtype
	{
		public C_adtype()
		{}
		#region Model
		private int _id;
		private int? _parentid;
		private string _name;
		private int? _ishidden=0;
		private int? _ordernum;
		private string _linkurl;
		private string _note;
		private string _textparam1;
		private string _textparam2;
		private string _textparam3;
		private string _textparam4;
		private string _textparam5;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 父级ID
		/// </summary>
		public int? parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 隐藏
		/// </summary>
		public int? ishidden
		{
			set{ _ishidden=value;}
			get{return _ishidden;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? ordernum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string linkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string note
		{
			set{ _note=value;}
			get{return _note;}
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

