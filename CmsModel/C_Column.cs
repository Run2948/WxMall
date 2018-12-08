/**  版本信息模板在安装目录下，可自行修改。
* C_Column.cs
*
* 功 能： N/A
* 类 名： C_Column
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/10 10:58:57   N/A    初版
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
	/// C_Column:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Column
	{
		public C_Column()
		{}
		#region Model
        private int _classId;
		private int? _parentid;
		private int? _modelid;
		private string _classname;
		private string _engname;
		private int? _ordernumber;
		private string _photourl;
		private string _photourlone;
		private string _photourltwo;
		private int? _isshowchannel;
		private int? _isshownext=1;
		private int? _isblank;
		private int? _ishidden;
		private string _intro;
		private string _content;
		private string _linkurl;
		private string _seotitle;
		private string _seokeyword;
		private string _seodescription;
		private string _expandclass;
        private string _name;
        private string _related;
		private string _listinfopath;
		private int? _isaddsub;
		private string _action_type;
		private string _class_list="";
		private int? _class_layer=1;
		private int? _channel_id=0;
		private string _sub_title="";
		private int? _is_sys=0;
		private string _nav_type="";
		private string _w_intro;
		private string _w_content;
		private int? _w_isshowchannel;
		private string _w_seotitle;
		private string _w_seokeyword;
		private string _w_seodescription;
		private string _w_expandclass;
		private string _w_linkurl;
		private string _w_contenturl;
		private string _e_intro;
		private string _e_content;
		private int? _e_isshowchannel;
		private string _e_seotitle;
		private string _e_seokeyword;
		private string _e_seodescription;
		private string _e_expandclass;
		private string _e_linkurl;
		private string _e_contenturl;
        private int? _is_albums = 0;
        private int? _is_attach = 0;
        private int? _page_size;

        private string _tpl_channel;
        private string _tpl_content;

		/// <summary>
		/// 
		/// </summary>
		public int classId
		{
            set { _classId = value; }
            get { return _classId; }
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
		/// 模型ID
		/// </summary>
		public int? modelId
		{
			set{ _modelid=value;}
			get{return _modelid;}
		}
		/// <summary>
		/// 栏目名称
		/// </summary>
		public string className
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 栏目英文
		/// </summary>
		public string engName
		{
			set{ _engname=value;}
			get{return _engname;}
		}
		/// <summary>
		/// 排序ID
		/// </summary>
		public int? orderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		/// <summary>
		/// 缩略图
		/// </summary>
		public string photoUrl
		{
			set{ _photourl=value;}
			get{return _photourl;}
		}
		/// <summary>
		/// 栏目图标True
		/// </summary>
		public string photoUrlone
		{
			set{ _photourlone=value;}
			get{return _photourlone;}
		}
		/// <summary>
		/// 栏目图标False
		/// </summary>
		public string photoUrltwo
		{
			set{ _photourltwo=value;}
			get{return _photourltwo;}
		}
		/// <summary>
		/// 是否参与导航
		/// </summary>
		public int? isShowChannel
		{
			set{ _isshowchannel=value;}
			get{return _isshowchannel;}
		}
		/// <summary>
		/// 是否显示子目录
		/// </summary>
		public int? isShowNext
		{
			set{ _isshownext=value;}
			get{return _isshownext;}
		}
		/// <summary>
		/// 是否打开新窗口
		/// </summary>
		public int? isBlank
		{
			set{ _isblank=value;}
			get{return _isblank;}
		}
		/// <summary>
		/// 是否隐藏栏目
		/// </summary>
		public int? isHidden
		{
			set{ _ishidden=value;}
			get{return _ishidden;}
		}
		/// <summary>
		/// 栏目描述
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 栏目内容
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
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
		/// SEO标题
		/// </summary>
		public string seoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// SEO关键字
		/// </summary>
		public string seoKeyword
		{
			set{ _seokeyword=value;}
			get{return _seokeyword;}
		}
		/// <summary>
		/// SEO描述
		/// </summary>
		public string seoDescription
		{
			set{ _seodescription=value;}
			get{return _seodescription;}
		}
		/// <summary>
		/// 扩展分类3,4,
		/// </summary>
		public string expandClass
		{
			set{ _expandclass=value;}
			get{return _expandclass;}
		}
        /// <summary>
        /// 导航调用id名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 导航关联
        /// </summary>
        public string related
        {
            set { _related = value; }
            get { return _related; }
        }
		
		/// <summary>
		/// 后台显示信息列路径
		/// </summary>
		public string listinfopath
		{
			set{ _listinfopath=value;}
			get{return _listinfopath;}
		}
		/// <summary>
		/// 是否可以添加子栏目
		/// </summary>
		public int? isaddsub
		{
			set{ _isaddsub=value;}
			get{return _isaddsub;}
		}
		/// <summary>
		/// 操作权限
		/// </summary>
		public string action_type
		{
			set{ _action_type=value;}
			get{return _action_type;}
		}
		/// <summary>
		/// 菜单ID列表(逗号分隔开)
		/// </summary>
		public string class_list
		{
			set{ _class_list=value;}
			get{return _class_list;}
		}
		/// <summary>
		/// 导航深度
		/// </summary>
		public int? class_layer
		{
			set{ _class_layer=value;}
			get{return _class_layer;}
		}
		/// <summary>
		/// 所属频道ID
		/// </summary>
		public int? channel_id
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// 副标题
		/// </summary>
		public string sub_title
		{
			set{ _sub_title=value;}
			get{return _sub_title;}
		}
		/// <summary>
		/// 系统默认
		/// </summary>
		public int? is_sys
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}
		/// <summary>
		/// 导航类别
		/// </summary>
		public string nav_type
		{
			set{ _nav_type=value;}
			get{return _nav_type;}
		}
		/// <summary>
		/// 手机站简介
		/// </summary>
		public string w_intro
		{
			set{ _w_intro=value;}
			get{return _w_intro;}
		}
		/// <summary>
		/// 手机站内容
		/// </summary>
		public string w_content
		{
			set{ _w_content=value;}
			get{return _w_content;}
		}
		/// <summary>
		/// 是否参与手机站导航
		/// </summary>
		public int? w_isShowChannel
		{
			set{ _w_isshowchannel=value;}
			get{return _w_isshowchannel;}
		}
		/// <summary>
		/// 手机SEO标题
		/// </summary>
		public string w_seoTitle
		{
			set{ _w_seotitle=value;}
			get{return _w_seotitle;}
		}
		/// <summary>
		/// 手机SEO关键字
		/// </summary>
		public string w_seoKeyword
		{
			set{ _w_seokeyword=value;}
			get{return _w_seokeyword;}
		}
		/// <summary>
		/// 手机SEO描述
		/// </summary>
		public string w_seoDescription
		{
			set{ _w_seodescription=value;}
			get{return _w_seodescription;}
		}
		/// <summary>
		/// 手机扩展分类3,4,
		/// </summary>
		public string w_expandClass
		{
			set{ _w_expandclass=value;}
			get{return _w_expandclass;}
		}
		/// <summary>
		/// 手机链接地址
		/// </summary>
		public string w_linkUrl
		{
			set{ _w_linkurl=value;}
			get{return _w_linkurl;}
		}
		/// <summary>
		/// 手机内容路径
		/// </summary>
		public string w_contentUrl
		{
			set{ _w_contenturl=value;}
			get{return _w_contenturl;}
		}
		/// <summary>
		/// 英文简介
		/// </summary>
		public string e_intro
		{
			set{ _e_intro=value;}
			get{return _e_intro;}
		}
		/// <summary>
		/// 英文内容
		/// </summary>
		public string e_content
		{
			set{ _e_content=value;}
			get{return _e_content;}
		}
		/// <summary>
		/// 是否参与英文导航
		/// </summary>
		public int? e_isShowChannel
		{
			set{ _e_isshowchannel=value;}
			get{return _e_isshowchannel;}
		}
		/// <summary>
		/// 英文SEO标题
		/// </summary>
		public string e_seoTitle
		{
			set{ _e_seotitle=value;}
			get{return _e_seotitle;}
		}
		/// <summary>
		/// 英文SEO关键字
		/// </summary>
		public string e_seoKeyword
		{
			set{ _e_seokeyword=value;}
			get{return _e_seokeyword;}
		}
		/// <summary>
		/// 英文SEO描述
		/// </summary>
		public string e_seoDescription
		{
			set{ _e_seodescription=value;}
			get{return _e_seodescription;}
		}
		/// <summary>
		/// 英文扩展分类3,4,
		/// </summary>
		public string e_expandClass
		{
			set{ _e_expandclass=value;}
			get{return _e_expandclass;}
		}
		/// <summary>
		/// 英文链接地址
		/// </summary>
		public string e_linkUrl
		{
			set{ _e_linkurl=value;}
			get{return _e_linkurl;}
		}
		/// <summary>
		/// 英文内容路径
		/// </summary>
		public string e_contentUrl
		{
			set{ _e_contenturl=value;}
			get{return _e_contenturl;}
		}
		/// <summary>
        /// 是否开启相册功能
		/// </summary>
        public int? is_albums
		{
            set { _is_albums = value; }
            get { return _is_albums; }
		}
		/// <summary>
        /// 是否开启附件功能
		/// </summary>
        public int? is_attach
		{
			set{ _is_attach=value;}
            get { return _is_attach; }
		}
		/// <summary>
        /// 每页显示数量
		/// </summary>
        public int? page_size
		{
            set { _page_size = value; }
            get { return _page_size; }
		}

		#endregion Model
        private List<C_Column_field> _channel_fields;
        /// <summary>
        /// 扩展字段 
        /// </summary>
        public List<C_Column_field> channel_fields
        {
            set { _channel_fields = value; }
            get { return _channel_fields; }
        }
        /// <summary>
        /// 栏目列表模版
        /// </summary>
        public string tplChannel
        {
            set { _tpl_channel = value; }
            get { return _tpl_channel; }
        }
        /// <summary>
        /// 栏目内容模版
        /// </summary>
        public string tplContent
        {
            set { _tpl_content = value; }
            get { return _tpl_content; }
        }
	}
}

