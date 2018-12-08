/**  版本信息模板在安装目录下，可自行修改。
* C_payment.cs
*
* 功 能： N/A
* 类 名： C_payment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/25 16:35:58   N/A    初版
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
	/// C_payment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_payment
	{
		public C_payment()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _img_url="";
		private string _remark;
		private int? _type=1;
		private int? _poundage_type=1;
		private decimal? _poundage_amount=0M;
		private int? _sort_id=99;
		private int? _is_lock=0;
		private string _api_path;
		private string _p_name;
		private string _p_account;
		private string _p_merchant;
		private string _p_secretkey;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 支付名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 显示图片
		/// </summary>
		public string img_url
		{
			set{ _img_url=value;}
			get{return _img_url;}
		}
		/// <summary>
		/// 备注说明
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 支付类型1线上2线下
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 手续费类型1百分比2固定金额
		/// </summary>
		public int? poundage_type
		{
			set{ _poundage_type=value;}
			get{return _poundage_type;}
		}
		/// <summary>
		/// 手续费金额
		/// </summary>
		public decimal? poundage_amount
		{
			set{ _poundage_amount=value;}
			get{return _poundage_amount;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 是否启用
		/// </summary>
		public int? is_lock
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
		}
		/// <summary>
		/// API目录名称
		/// </summary>
		public string api_path
		{
			set{ _api_path=value;}
			get{return _api_path;}
		}
		/// <summary>
		/// 账户名
		/// </summary>
		public string p_name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 账户
		/// </summary>
		public string p_account
		{
			set{ _p_account=value;}
			get{return _p_account;}
		}
		/// <summary>
		/// 商户号
		/// </summary>
		public string p_merchant
		{
			set{ _p_merchant=value;}
			get{return _p_merchant;}
		}
		/// <summary>
		/// 秘钥
		/// </summary>
		public string p_secretkey
		{
			set{ _p_secretkey=value;}
			get{return _p_secretkey;}
		}
		#endregion Model

	}
}

