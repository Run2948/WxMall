using System;
namespace Cms.Model
{
	/// <summary>
	/// 刮刮卡奖品列表
	/// </summary>
	[Serializable]
	public partial class wx_ggkAwardItem
	{
		public wx_ggkAwardItem()
		{}
		#region Model
		private int _id;
		private int? _actid;
		private string _jxname;
		private string _jpname;
		private int? _jpnum;
		private int? _jprealnum;
		private int? _sort_id;
		private DateTime? _createdate;
		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 刮刮卡活动表主键Id
		/// </summary>
		public int? actId
		{
			set{ _actid=value;}
			get{return _actid;}
		}
		/// <summary>
		/// 奖项名称
		/// </summary>
		public string jxName
		{
			set{ _jxname=value;}
			get{return _jxname;}
		}
		/// <summary>
		/// 奖品名称
		/// </summary>
		public string jpName
		{
			set{ _jpname=value;}
			get{return _jpname;}
		}
		/// <summary>
		/// 奖品显示数量
		/// </summary>
		public int? jpNum
		{
			set{ _jpnum=value;}
			get{return _jpnum;}
		}
		/// <summary>
		/// 奖品真实数量
		/// </summary>
		public int? jpRealNum
		{
			set{ _jprealnum=value;}
			get{return _jprealnum;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

