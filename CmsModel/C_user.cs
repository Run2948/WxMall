/**  版本信息模板在安装目录下，可自行修改。
* C_user.cs
*
* 功 能： N/A
* 类 名： C_user
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/3 10:34:34   N/A    初版
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
	/// C_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_user
	{
		public C_user()
		{}
		#region Model
		private int _id;
		private string _password;
		private string _usercard;
		private string _openid;
		private string _username;
		private string _sex;
		private string _useraddress;
		private DateTime? _birthday;
		private DateTime? _marryday;
		private string _telphone;
		private string _shopname;
        private string _shopcode;
		private string _userlevel;
		private decimal? _allbuy;
		private int? _buytimes;
        private int? _userallscore;
		private int? _userscore;
		private DateTime _updatetime;
		private int? _issign;
		private int? _isbind;
		private string _latitude;
		private string _longitude;
		private decimal? _usermoney;
        private int? _userYesScore;
        private string _headimgurl;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string usercard
		{
			set{ _usercard=value;}
			get{return _usercard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string useraddress
		{
			set{ _useraddress=value;}
			get{return _useraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? marryday
		{
			set{ _marryday=value;}
			get{return _marryday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telphone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 所属店名
		/// </summary>
		public string shopname
		{
			set{ _shopname=value;}
			get{return _shopname;}
		}
        /// <summary>
        /// 所属店编码
        /// </summary>
        public string shopcode
        {
            set { _shopcode = value; }
            get { return _shopcode; }
        }
		/// <summary>
		/// 会员级别
		/// </summary>
		public string userlevel
		{
			set{ _userlevel=value;}
			get{return _userlevel;}
		}
		/// <summary>
		/// 消费金额
		/// </summary>
		public decimal? allbuy
		{
			set{ _allbuy=value;}
			get{return _allbuy;}
		}
		/// <summary>
		/// 购买次数
		/// </summary>
		public int? buytimes
		{
			set{ _buytimes=value;}
			get{return _buytimes;}
		}
        /// <summary>
        /// 全部积分  从办卡到现在的所有积分
        /// </summary>
        public int? userallscore
        {
            set { _userallscore = value; }
            get { return _userallscore; }
        }
		/// <summary>
		/// 未兑换积分
		/// </summary>
		public int? userscore
		{
			set{ _userscore=value;}
			get{return _userscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isSign
		{
			set{ _issign=value;}
			get{return _issign;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isbind
		{
			set{ _isbind=value;}
			get{return _isbind;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string latitude
		{
			set{ _latitude=value;}
			get{return _latitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? userMoney
		{
			set{ _usermoney=value;}
			get{return _usermoney;}
		}
		/// <summary>
        /// 已经兑换使用的积分
		/// </summary>
        public int? userYesScore
		{
            set { _userYesScore = value; }
            get { return _userYesScore; }
		}
        /// <summary>
        /// 用户头像
        /// </summary>
        public string headimgurl
        {
            set { _headimgurl = value; }
            get { return _headimgurl; }
        }
		#endregion Model

	}
}

