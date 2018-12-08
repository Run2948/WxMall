/**  版本信息模板在安装目录下，可自行修改。
* C_article.cs
*
* 功 能： N/A
* 类 名： C_article
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/2 16:26:07   N/A    初版
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
	/// C_article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_article
	{
		public C_article()
		{}
		#region Model
        private int _articleId;
        private int? _parentId;
		private string _title;
		private string _englishtitle;
		private int? _ordernumber;
		private string _photourl;
		private string _intro;
		private string _content;
		private string _seotitle;
		private string _seokeyword;
		private string _seodescription;
		private int? _isrecommend=0;
		private string _ischannel;
		private int? _ishidden=0;
		private int? _ischeck=1;
		private int? _ishot;
		private int? _istop=0;
		private int? _is_msg=0;
		private int? _is_slide=0;
		private int? _hits=0;
		private string _attachment;
		private string _expclass;
		private DateTime? _edittime;
		private DateTime? _updatetime;
		private string _txtlinkurl;
		private string _contenturl;
		private string _txtsource;
		private string _txtauthor;
		private string _w_linkurl;
		private string _w_contenturl;
		private string _w_intro;
		private string _w_content;
		private string _e_linkurl;
		private string _e_contenturl;
		private string _e_source;
		private string _e_author;
		private string _e_intro;
		private string _e_content;
		private string _e_seotitle;
		private string _e_seokeyword;
		private string _e_seodescription;

		/// <summary>
		/// 
		/// </summary>
        public int articleId
		{
            set { _articleId = value; }
            get { return _articleId; }
		}
		/// <summary>
		/// 分类ID
		/// </summary>
        public int? parentId
		{
            set { _parentId = value; }
            get { return _parentId; }
		}
		/// <summary>
		/// 文章标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 英文标题
		/// </summary>
		public string englishtitle
		{
			set{ _englishtitle=value;}
			get{return _englishtitle;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? orderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string photoUrl
		{
			set{ _photourl=value;}
			get{return _photourl;}
		}
		/// <summary>
		/// 描述简介
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 内容信息
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
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
		/// 首页推荐
		/// </summary>
		public int? isRecommend
		{
			set{ _isrecommend=value;}
			get{return _isrecommend;}
		}
		/// <summary>
		/// 栏目推荐
		/// </summary>
		public string isChannel
		{
			set{ _ischannel=value;}
			get{return _ischannel;}
		}
		/// <summary>
		/// 是否隐藏
		/// </summary>
		public int? isHidden
		{
			set{ _ishidden=value;}
			get{return _ishidden;}
		}
		/// <summary>
		/// 是否审核发布
		/// </summary>
		public int? isCheck
		{
			set{ _ischeck=value;}
			get{return _ischeck;}
		}
		/// <summary>
		/// 是否热门文章
		/// </summary>
		public int? isHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 是否置顶
		/// </summary>
		public int? isTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 是否允许评论
		/// </summary>
		public int? is_msg
		{
			set{ _is_msg=value;}
			get{return _is_msg;}
		}
		/// <summary>
		/// 是否幻灯片
		/// </summary>
		public int? is_slide
		{
			set{ _is_slide=value;}
			get{return _is_slide;}
		}
		/// <summary>
		/// 点击量
		/// </summary>
		public int? hits
		{
			set{ _hits=value;}
			get{return _hits;}
		}
		/// <summary>
		/// 附件
		/// </summary>
		public string Attachment
		{
			set{ _attachment=value;}
			get{return _attachment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string expClass
		{
			set{ _expclass=value;}
			get{return _expclass;}
		}
		/// <summary>
		/// 最后编辑时间
		/// </summary>
		public DateTime? editTime
		{
			set{ _edittime=value;}
			get{return _edittime;}
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
		/// URL链接
		/// </summary>
		public string txtLinkUrl
		{
			set{ _txtlinkurl=value;}
			get{return _txtlinkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contentUrl
		{
			set{ _contenturl=value;}
			get{return _contenturl;}
		}
		/// <summary>
		/// 信息来源
		/// </summary>
		public string txtsource
		{
			set{ _txtsource=value;}
			get{return _txtsource;}
		}
		/// <summary>
		/// 文章作者
		/// </summary>
		public string txtauthor
		{
			set{ _txtauthor=value;}
			get{return _txtauthor;}
		}
		/// <summary>
		/// 手机站链接
		/// </summary>
		public string w_LinkUrl
		{
			set{ _w_linkurl=value;}
			get{return _w_linkurl;}
		}
		/// <summary>
		/// 手机站内容链接
		/// </summary>
		public string w_contentUrl
		{
			set{ _w_contenturl=value;}
			get{return _w_contenturl;}
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
		/// 英文站链接
		/// </summary>
		public string e_LinkUrl
		{
			set{ _e_linkurl=value;}
			get{return _e_linkurl;}
		}
		/// <summary>
		/// 英文站内容链接
		/// </summary>
		public string e_contentUrl
		{
			set{ _e_contenturl=value;}
			get{return _e_contenturl;}
		}
		/// <summary>
		/// 英文站信息来源
		/// </summary>
		public string e_source
		{
			set{ _e_source=value;}
			get{return _e_source;}
		}
		/// <summary>
		/// 英文信息作者
		/// </summary>
		public string e_author
		{
			set{ _e_author=value;}
			get{return _e_author;}
		}
		/// <summary>
		/// 英文信息简介
		/// </summary>
		public string e_intro
		{
			set{ _e_intro=value;}
			get{return _e_intro;}
		}
		/// <summary>
		/// 英文信息内容
		/// </summary>
		public string e_content
		{
			set{ _e_content=value;}
			get{return _e_content;}
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
        /// 扩展字段字典
        /// </summary>
        private Dictionary<string, string> _fields;
        public Dictionary<string, string> fields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        /// <summary>
        /// 图片相册
        /// </summary>
        private List<C_article_albums> _albums;
        public List<C_article_albums> albums
        {
            set { _albums = value; }
            get { return _albums; }
        }

        /// <summary>
        /// 内容附件
        /// </summary>
        private List<C_article_attach> _attach;
        public List<C_article_attach> attach
        {
            set { _attach = value; }
            get { return _attach; }
        }
		#endregion Model

	}
}

