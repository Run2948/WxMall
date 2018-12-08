/**  版本信息模板在安装目录下，可自行修改。
* C_user_recharge.cs
*
* 功 能： N/A
* 类 名： C_user_recharge
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/11 20:57:17   N/A    初版
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
	/// C_user_recharge:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_user_recharge
	{
		public C_user_recharge()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private string _ordernumber;
		private int? _ispay;
		private int? _typeid;
		private decimal? _price;
		private string _note;
		private DateTime? _createdtime;
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
		public int? userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isPay
		{
			set{ _ispay=value;}
			get{return _ispay;}
		}
		/// <summary>
		/// 1是充值 2 是消费
		/// </summary>
		public int? typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createdTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		#endregion Model

	}
}

