/**  版本信息模板在安装目录下，可自行修改。
* C_article_category.cs
*
* 功 能： N/A
* 类 名： C_article_category
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/4 15:59:37   N/A    初版
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
	/// C_article_category:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_article_category
	{
		public C_article_category()
		{}
		#region Model
		private int _id;
		private int _channel_id;
		private string _title;
		private string _call_index="";
		private int? _parent_id=0;
		private string _class_list;
		private int? _class_layer=0;
		private int? _sort_id=99;
		private string _link_url="";
		private string _img_url="";
		private string _content;
		private int? _isrecommend=0;
		private string _ischannel;
		private int? _ishidden=0;
		private int? _ischeck=1;
		private int? _ishot;
		private int? _istop=0;
		private int? _is_msg=0;
		private int? _is_slide=0;
		private string _seo_title="";
		private string _seo_keywords="";
		private string _seo_description="";
		private string _adword;
		private string _fold;
		private string _activetime;
		private string _special;
		private string _video;
		private string _textparam1;
		private string _textparam2;
		private string _textparam3;
		private string _textparam4;
		private string _textparam5;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 频道ID
		/// </summary>
		public int channel_id
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// 类别标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 调用别名
		/// </summary>
		public string call_index
		{
			set{ _call_index=value;}
			get{return _call_index;}
		}
		/// <summary>
		/// 父类别ID
		/// </summary>
		public int? parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 类别ID列表(逗号分隔开)
		/// </summary>
		public string class_list
		{
			set{ _class_list=value;}
			get{return _class_list;}
		}
		/// <summary>
		/// 类别深度
		/// </summary>
		public int? class_layer
		{
			set{ _class_layer=value;}
			get{return _class_layer;}
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
		/// URL跳转地址
		/// </summary>
		public string link_url
		{
			set{ _link_url=value;}
			get{return _link_url;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string img_url
		{
			set{ _img_url=value;}
			get{return _img_url;}
		}
		/// <summary>
		/// 备注说明
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
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
		/// SEO标题
		/// </summary>
		public string seo_title
		{
			set{ _seo_title=value;}
			get{return _seo_title;}
		}
		/// <summary>
		/// SEO关健字
		/// </summary>
		public string seo_keywords
		{
			set{ _seo_keywords=value;}
			get{return _seo_keywords;}
		}
		/// <summary>
		/// SEO描述
		/// </summary>
		public string seo_description
		{
			set{ _seo_description=value;}
			get{return _seo_description;}
		}
		/// <summary>
		/// 广告词
		/// </summary>
		public string adword
		{
			set{ _adword=value;}
			get{return _adword;}
		}
		/// <summary>
		/// 折扣
		/// </summary>
		public string Fold
		{
			set{ _fold=value;}
			get{return _fold;}
		}
		/// <summary>
		/// 活动时间
		/// </summary>
		public string activetime
		{
			set{ _activetime=value;}
			get{return _activetime;}
		}
		/// <summary>
		/// 专场
		/// </summary>
		public string Special
		{
			set{ _special=value;}
			get{return _special;}
		}
		/// <summary>
		/// 视频介绍
		/// </summary>
		public string video
		{
			set{ _video=value;}
			get{return _video;}
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

