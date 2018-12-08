/**  版本信息模板在安装目录下，可自行修改。
* wx_payment_wxpay.cs
*
* 功 能： N/A
* 类 名： wx_payment_wxpay
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/26 17:32:07   N/A    初版
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
	/// wx_payment_wxpay:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_payment_wxpay
	{
		public wx_payment_wxpay()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _partnerid;
		private string _appid;
		private string _partnerkey;
		private string _paysignkey;
		private DateTime? _createdate;
		private string _certinfopath;
		private string _partnerpwd;
		private string _shname;
		private string _bankname;
		private string _bankcode;
		private string _remark;
		private bool _quicklyfh;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 财付通身份标志
		/// </summary>
		public string partnerId
		{
			set{ _partnerid=value;}
			get{return _partnerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string appId
		{
			set{ _appid=value;}
			get{return _appid;}
		}
		/// <summary>
		/// 财付通密匙
		/// </summary>
		public string partnerKey
		{
			set{ _partnerkey=value;}
			get{return _partnerkey;}
		}
		/// <summary>
		/// 秘钥
		/// </summary>
		public string paySignKey
		{
			set{ _paysignkey=value;}
			get{return _paysignkey;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 证书地址
		/// </summary>
		public string CertInfoPath
		{
			set{ _certinfopath=value;}
			get{return _certinfopath;}
		}
		/// <summary>
		/// 财付通登录密码
		/// </summary>
		public string partnerPwd
		{
			set{ _partnerpwd=value;}
			get{return _partnerpwd;}
		}
		/// <summary>
		/// 商户名称
		/// </summary>
		public string shName
		{
			set{ _shname=value;}
			get{return _shname;}
		}
		/// <summary>
		/// 银行名称
		/// </summary>
		public string bankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 银行帐号
		/// </summary>
		public string bankCode
		{
			set{ _bankcode=value;}
			get{return _bankcode;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 立即发货
		/// </summary>
		public bool quicklyFH
		{
			set{ _quicklyfh=value;}
			get{return _quicklyfh;}
		}
		#endregion Model

	}
}

