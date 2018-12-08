/**  版本信息模板在安装目录下，可自行修改。
* C_ad.cs
*
* 功 能： N/A
* 类 名： C_ad
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
	/// C_ad:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_ad
	{
		public C_ad()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _picurl;
		private int? _width;
		private int? _height;
		private string _linkurl1;
		private int? _hits;
		private string _filestype;
		private int? _ishidden=0;
		private int? _ordernum;
		private string _linkurl;
		private string _note;
		private string _adtype;
		private DateTime? _updatetime;
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
		/// 友情链接名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 缩略图
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 宽度
		/// </summary>
		public int? width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// 高度
		/// </summary>
		public int? height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 广告链接地址
		/// </summary>
		public string linkUrl1
		{
			set{ _linkurl1=value;}
			get{return _linkurl1;}
		}
		/// <summary>
		/// 点击率
		/// </summary>
		public int? hits
		{
			set{ _hits=value;}
			get{return _hits;}
		}
		/// <summary>
		/// 文件类型,pic,swf,flv,pics,links
		/// </summary>
		public string filestype
		{
			set{ _filestype=value;}
			get{return _filestype;}
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
		/// 链接类型
		/// </summary>
		public string adtype
		{
			set{ _adtype=value;}
			get{return _adtype;}
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

