/**  版本信息模板在安装目录下，可自行修改。
* C_order.cs
*
* 功 能： N/A
* 类 名： C_order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/7 22:40:08   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.DAL
{
	/// <summary>
	/// 数据访问类:C_order
	/// </summary>
	public partial class C_order
	{
		public C_order()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_order"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_order");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_order(");
			strSql.Append("order_num,user_id,adress_id,quantity_sum,price_sum,integral_sum,is_payment,order_status,is_delivery,is_receiving,is_transaction,is_sms,pay_method,shipping_method,Coupon_id,cash_volume_id,integral_arrived,note,recommended_code,updateTime,notify_id,pay_info,isSubscribe,fahuoCode,fahuoMsg,trade_no,real_amount,order_amount,payment_time,is_refund,courier_number,invoiceType,invoiceContent,invoicesRaised,invoiceInfo)");
			strSql.Append(" values (");
			strSql.Append("@order_num,@user_id,@adress_id,@quantity_sum,@price_sum,@integral_sum,@is_payment,@order_status,@is_delivery,@is_receiving,@is_transaction,@is_sms,@pay_method,@shipping_method,@Coupon_id,@cash_volume_id,@integral_arrived,@note,@recommended_code,@updateTime,@notify_id,@pay_info,@isSubscribe,@fahuoCode,@fahuoMsg,@trade_no,@real_amount,@order_amount,@payment_time,@is_refund,@courier_number,@invoiceType,@invoiceContent,@invoicesRaised,@invoiceInfo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@order_num", SqlDbType.VarChar,350),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@adress_id", SqlDbType.Int,4),
					new SqlParameter("@quantity_sum", SqlDbType.Int,4),
					new SqlParameter("@price_sum", SqlDbType.Money,8),
					new SqlParameter("@integral_sum", SqlDbType.Int,4),
					new SqlParameter("@is_payment", SqlDbType.Int,4),
					new SqlParameter("@order_status", SqlDbType.Int,4),
					new SqlParameter("@is_delivery", SqlDbType.Int,4),
					new SqlParameter("@is_receiving", SqlDbType.Int,4),
					new SqlParameter("@is_transaction", SqlDbType.Int,4),
					new SqlParameter("@is_sms", SqlDbType.Int,4),
					new SqlParameter("@pay_method", SqlDbType.VarChar,150),
					new SqlParameter("@shipping_method", SqlDbType.VarChar,150),
					new SqlParameter("@Coupon_id", SqlDbType.Int,4),
					new SqlParameter("@cash_volume_id", SqlDbType.Int,4),
					new SqlParameter("@integral_arrived", SqlDbType.Int,4),
					new SqlParameter("@note", SqlDbType.VarChar,350),
					new SqlParameter("@recommended_code", SqlDbType.VarChar,250),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@notify_id", SqlDbType.VarChar,128),
					new SqlParameter("@pay_info", SqlDbType.VarChar,200),
					new SqlParameter("@isSubscribe", SqlDbType.Bit,1),
					new SqlParameter("@fahuoCode", SqlDbType.VarChar,50),
					new SqlParameter("@fahuoMsg", SqlDbType.VarChar,500),
					new SqlParameter("@trade_no", SqlDbType.NVarChar,100),
					new SqlParameter("@real_amount", SqlDbType.Money,8),
					new SqlParameter("@order_amount", SqlDbType.Money,8),
					new SqlParameter("@payment_time", SqlDbType.DateTime),
					new SqlParameter("@is_refund", SqlDbType.Int,4),
					new SqlParameter("@courier_number", SqlDbType.NVarChar,100),
					new SqlParameter("@invoiceType", SqlDbType.VarChar,50),
					new SqlParameter("@invoiceContent", SqlDbType.VarChar,50),
					new SqlParameter("@invoicesRaised", SqlDbType.VarChar,50),
					new SqlParameter("@invoiceInfo", SqlDbType.VarChar,-1)};
			parameters[0].Value = model.order_num;
			parameters[1].Value = model.user_id;
			parameters[2].Value = model.adress_id;
			parameters[3].Value = model.quantity_sum;
			parameters[4].Value = model.price_sum;
			parameters[5].Value = model.integral_sum;
			parameters[6].Value = model.is_payment;
			parameters[7].Value = model.order_status;
			parameters[8].Value = model.is_delivery;
			parameters[9].Value = model.is_receiving;
			parameters[10].Value = model.is_transaction;
			parameters[11].Value = model.is_sms;
			parameters[12].Value = model.pay_method;
			parameters[13].Value = model.shipping_method;
			parameters[14].Value = model.Coupon_id;
			parameters[15].Value = model.cash_volume_id;
			parameters[16].Value = model.integral_arrived;
			parameters[17].Value = model.note;
			parameters[18].Value = model.recommended_code;
			parameters[19].Value = model.updateTime;
			parameters[20].Value = model.notify_id;
			parameters[21].Value = model.pay_info;
			parameters[22].Value = model.isSubscribe;
			parameters[23].Value = model.fahuoCode;
			parameters[24].Value = model.fahuoMsg;
			parameters[25].Value = model.trade_no;
			parameters[26].Value = model.real_amount;
			parameters[27].Value = model.order_amount;
			parameters[28].Value = model.payment_time;
			parameters[29].Value = model.is_refund;
			parameters[30].Value = model.courier_number;
			parameters[31].Value = model.invoiceType;
			parameters[32].Value = model.invoiceContent;
			parameters[33].Value = model.invoicesRaised;
			parameters[34].Value = model.invoiceInfo;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Cms.Model.C_order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_order set ");
			strSql.Append("order_num=@order_num,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("adress_id=@adress_id,");
			strSql.Append("quantity_sum=@quantity_sum,");
			strSql.Append("price_sum=@price_sum,");
			strSql.Append("integral_sum=@integral_sum,");
			strSql.Append("is_payment=@is_payment,");
			strSql.Append("order_status=@order_status,");
			strSql.Append("is_delivery=@is_delivery,");
			strSql.Append("is_receiving=@is_receiving,");
			strSql.Append("is_transaction=@is_transaction,");
			strSql.Append("is_sms=@is_sms,");
			strSql.Append("pay_method=@pay_method,");
			strSql.Append("shipping_method=@shipping_method,");
			strSql.Append("Coupon_id=@Coupon_id,");
			strSql.Append("cash_volume_id=@cash_volume_id,");
			strSql.Append("integral_arrived=@integral_arrived,");
			strSql.Append("note=@note,");
			strSql.Append("recommended_code=@recommended_code,");
			strSql.Append("updateTime=@updateTime,");
			strSql.Append("notify_id=@notify_id,");
			strSql.Append("pay_info=@pay_info,");
			strSql.Append("isSubscribe=@isSubscribe,");
			strSql.Append("fahuoCode=@fahuoCode,");
			strSql.Append("fahuoMsg=@fahuoMsg,");
			strSql.Append("trade_no=@trade_no,");
			strSql.Append("real_amount=@real_amount,");
			strSql.Append("order_amount=@order_amount,");
			strSql.Append("payment_time=@payment_time,");
			strSql.Append("is_refund=@is_refund,");
			strSql.Append("courier_number=@courier_number,");
			strSql.Append("invoiceType=@invoiceType,");
			strSql.Append("invoiceContent=@invoiceContent,");
			strSql.Append("invoicesRaised=@invoicesRaised,");
			strSql.Append("invoiceInfo=@invoiceInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_num", SqlDbType.VarChar,350),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@adress_id", SqlDbType.Int,4),
					new SqlParameter("@quantity_sum", SqlDbType.Int,4),
					new SqlParameter("@price_sum", SqlDbType.Money,8),
					new SqlParameter("@integral_sum", SqlDbType.Int,4),
					new SqlParameter("@is_payment", SqlDbType.Int,4),
					new SqlParameter("@order_status", SqlDbType.Int,4),
					new SqlParameter("@is_delivery", SqlDbType.Int,4),
					new SqlParameter("@is_receiving", SqlDbType.Int,4),
					new SqlParameter("@is_transaction", SqlDbType.Int,4),
					new SqlParameter("@is_sms", SqlDbType.Int,4),
					new SqlParameter("@pay_method", SqlDbType.VarChar,150),
					new SqlParameter("@shipping_method", SqlDbType.VarChar,150),
					new SqlParameter("@Coupon_id", SqlDbType.Int,4),
					new SqlParameter("@cash_volume_id", SqlDbType.Int,4),
					new SqlParameter("@integral_arrived", SqlDbType.Int,4),
					new SqlParameter("@note", SqlDbType.VarChar,350),
					new SqlParameter("@recommended_code", SqlDbType.VarChar,250),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@notify_id", SqlDbType.VarChar,128),
					new SqlParameter("@pay_info", SqlDbType.VarChar,200),
					new SqlParameter("@isSubscribe", SqlDbType.Bit,1),
					new SqlParameter("@fahuoCode", SqlDbType.VarChar,50),
					new SqlParameter("@fahuoMsg", SqlDbType.VarChar,500),
					new SqlParameter("@trade_no", SqlDbType.NVarChar,100),
					new SqlParameter("@real_amount", SqlDbType.Money,8),
					new SqlParameter("@order_amount", SqlDbType.Money,8),
					new SqlParameter("@payment_time", SqlDbType.DateTime),
					new SqlParameter("@is_refund", SqlDbType.Int,4),
					new SqlParameter("@courier_number", SqlDbType.NVarChar,100),
					new SqlParameter("@invoiceType", SqlDbType.VarChar,50),
					new SqlParameter("@invoiceContent", SqlDbType.VarChar,50),
					new SqlParameter("@invoicesRaised", SqlDbType.VarChar,50),
					new SqlParameter("@invoiceInfo", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.order_num;
			parameters[1].Value = model.user_id;
			parameters[2].Value = model.adress_id;
			parameters[3].Value = model.quantity_sum;
			parameters[4].Value = model.price_sum;
			parameters[5].Value = model.integral_sum;
			parameters[6].Value = model.is_payment;
			parameters[7].Value = model.order_status;
			parameters[8].Value = model.is_delivery;
			parameters[9].Value = model.is_receiving;
			parameters[10].Value = model.is_transaction;
			parameters[11].Value = model.is_sms;
			parameters[12].Value = model.pay_method;
			parameters[13].Value = model.shipping_method;
			parameters[14].Value = model.Coupon_id;
			parameters[15].Value = model.cash_volume_id;
			parameters[16].Value = model.integral_arrived;
			parameters[17].Value = model.note;
			parameters[18].Value = model.recommended_code;
			parameters[19].Value = model.updateTime;
			parameters[20].Value = model.notify_id;
			parameters[21].Value = model.pay_info;
			parameters[22].Value = model.isSubscribe;
			parameters[23].Value = model.fahuoCode;
			parameters[24].Value = model.fahuoMsg;
			parameters[25].Value = model.trade_no;
			parameters[26].Value = model.real_amount;
			parameters[27].Value = model.order_amount;
			parameters[28].Value = model.payment_time;
			parameters[29].Value = model.is_refund;
			parameters[30].Value = model.courier_number;
			parameters[31].Value = model.invoiceType;
			parameters[32].Value = model.invoiceContent;
			parameters[33].Value = model.invoicesRaised;
			parameters[34].Value = model.invoiceInfo;
			parameters[35].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_order ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_order ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.C_order GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,order_num,user_id,adress_id,quantity_sum,price_sum,integral_sum,is_payment,order_status,is_delivery,is_receiving,is_transaction,is_sms,pay_method,shipping_method,Coupon_id,cash_volume_id,integral_arrived,note,recommended_code,updateTime,notify_id,pay_info,isSubscribe,fahuoCode,fahuoMsg,trade_no,real_amount,order_amount,payment_time,is_refund,courier_number,invoiceType,invoiceContent,invoicesRaised,invoiceInfo from C_order ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_order model=new Cms.Model.C_order();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.C_order DataRowToModel(DataRow row)
		{
			Cms.Model.C_order model=new Cms.Model.C_order();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["order_num"]!=null)
				{
					model.order_num=row["order_num"].ToString();
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["adress_id"]!=null && row["adress_id"].ToString()!="")
				{
					model.adress_id=int.Parse(row["adress_id"].ToString());
				}
				if(row["quantity_sum"]!=null && row["quantity_sum"].ToString()!="")
				{
					model.quantity_sum=int.Parse(row["quantity_sum"].ToString());
				}
				if(row["price_sum"]!=null && row["price_sum"].ToString()!="")
				{
					model.price_sum=decimal.Parse(row["price_sum"].ToString());
				}
				if(row["integral_sum"]!=null && row["integral_sum"].ToString()!="")
				{
					model.integral_sum=int.Parse(row["integral_sum"].ToString());
				}
				if(row["is_payment"]!=null && row["is_payment"].ToString()!="")
				{
					model.is_payment=int.Parse(row["is_payment"].ToString());
				}
				if(row["order_status"]!=null && row["order_status"].ToString()!="")
				{
					model.order_status=int.Parse(row["order_status"].ToString());
				}
				if(row["is_delivery"]!=null && row["is_delivery"].ToString()!="")
				{
					model.is_delivery=int.Parse(row["is_delivery"].ToString());
				}
				if(row["is_receiving"]!=null && row["is_receiving"].ToString()!="")
				{
					model.is_receiving=int.Parse(row["is_receiving"].ToString());
				}
				if(row["is_transaction"]!=null && row["is_transaction"].ToString()!="")
				{
					model.is_transaction=int.Parse(row["is_transaction"].ToString());
				}
				if(row["is_sms"]!=null && row["is_sms"].ToString()!="")
				{
					model.is_sms=int.Parse(row["is_sms"].ToString());
				}
				if(row["pay_method"]!=null)
				{
					model.pay_method=row["pay_method"].ToString();
				}
				if(row["shipping_method"]!=null)
				{
					model.shipping_method=row["shipping_method"].ToString();
				}
				if(row["Coupon_id"]!=null && row["Coupon_id"].ToString()!="")
				{
					model.Coupon_id=int.Parse(row["Coupon_id"].ToString());
				}
				if(row["cash_volume_id"]!=null && row["cash_volume_id"].ToString()!="")
				{
					model.cash_volume_id=int.Parse(row["cash_volume_id"].ToString());
				}
				if(row["integral_arrived"]!=null && row["integral_arrived"].ToString()!="")
				{
					model.integral_arrived=int.Parse(row["integral_arrived"].ToString());
				}
				if(row["note"]!=null)
				{
					model.note=row["note"].ToString();
				}
				if(row["recommended_code"]!=null)
				{
					model.recommended_code=row["recommended_code"].ToString();
				}
				if(row["updateTime"]!=null && row["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(row["updateTime"].ToString());
				}
				if(row["notify_id"]!=null)
				{
					model.notify_id=row["notify_id"].ToString();
				}
				if(row["pay_info"]!=null)
				{
					model.pay_info=row["pay_info"].ToString();
				}
				if(row["isSubscribe"]!=null && row["isSubscribe"].ToString()!="")
				{
					if((row["isSubscribe"].ToString()=="1")||(row["isSubscribe"].ToString().ToLower()=="true"))
					{
						model.isSubscribe=true;
					}
					else
					{
						model.isSubscribe=false;
					}
				}
				if(row["fahuoCode"]!=null)
				{
					model.fahuoCode=row["fahuoCode"].ToString();
				}
				if(row["fahuoMsg"]!=null)
				{
					model.fahuoMsg=row["fahuoMsg"].ToString();
				}
				if(row["trade_no"]!=null)
				{
					model.trade_no=row["trade_no"].ToString();
				}
				if(row["real_amount"]!=null && row["real_amount"].ToString()!="")
				{
					model.real_amount=decimal.Parse(row["real_amount"].ToString());
				}
				if(row["order_amount"]!=null && row["order_amount"].ToString()!="")
				{
					model.order_amount=decimal.Parse(row["order_amount"].ToString());
				}
				if(row["payment_time"]!=null && row["payment_time"].ToString()!="")
				{
					model.payment_time=DateTime.Parse(row["payment_time"].ToString());
				}
				if(row["is_refund"]!=null && row["is_refund"].ToString()!="")
				{
					model.is_refund=int.Parse(row["is_refund"].ToString());
				}
				if(row["courier_number"]!=null)
				{
					model.courier_number=row["courier_number"].ToString();
				}
				if(row["invoiceType"]!=null)
				{
					model.invoiceType=row["invoiceType"].ToString();
				}
				if(row["invoiceContent"]!=null)
				{
					model.invoiceContent=row["invoiceContent"].ToString();
				}
				if(row["invoicesRaised"]!=null)
				{
					model.invoicesRaised=row["invoicesRaised"].ToString();
				}
				if(row["invoiceInfo"]!=null)
				{
					model.invoiceInfo=row["invoiceInfo"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,order_num,user_id,adress_id,quantity_sum,price_sum,integral_sum,is_payment,order_status,is_delivery,is_receiving,is_transaction,is_sms,pay_method,shipping_method,Coupon_id,cash_volume_id,integral_arrived,note,recommended_code,updateTime,notify_id,pay_info,isSubscribe,fahuoCode,fahuoMsg,trade_no,real_amount,order_amount,payment_time,is_refund,courier_number,invoiceType,invoiceContent,invoicesRaised,invoiceInfo ");
			strSql.Append(" FROM C_order ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,order_num,user_id,adress_id,quantity_sum,price_sum,integral_sum,is_payment,order_status,is_delivery,is_receiving,is_transaction,is_sms,pay_method,shipping_method,Coupon_id,cash_volume_id,integral_arrived,note,recommended_code,updateTime,notify_id,pay_info,isSubscribe,fahuoCode,fahuoMsg,trade_no,real_amount,order_amount,payment_time,is_refund,courier_number,invoiceType,invoiceContent,invoicesRaised,invoiceInfo ");
			strSql.Append(" FROM C_order ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_order ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from C_order T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "C_order";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

