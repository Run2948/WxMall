/**  版本信息模板在安装目录下，可自行修改。
* C_order_integral.cs
*
* 功 能： N/A
* 类 名： C_order_integral
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/20 17:21:23   N/A    初版
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
	/// 数据访问类:C_order_integral
	/// </summary>
	public partial class C_order_integral
	{
		public C_order_integral()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_order_integral"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_order_integral");
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
		public int Add(Cms.Model.C_order_integral model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_order_integral(");
			strSql.Append("order_num,user_id,adress_id,quantity_sum,price_sum,integral_sum,order_status,is_sms,note,recommended_code,updateTime,storesId)");
			strSql.Append(" values (");
			strSql.Append("@order_num,@user_id,@adress_id,@quantity_sum,@price_sum,@integral_sum,@order_status,@is_sms,@note,@recommended_code,@updateTime,@storesId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@order_num", SqlDbType.VarChar,350),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@adress_id", SqlDbType.Int,4),
					new SqlParameter("@quantity_sum", SqlDbType.Int,4),
					new SqlParameter("@price_sum", SqlDbType.Money,8),
					new SqlParameter("@integral_sum", SqlDbType.Int,4),
					new SqlParameter("@order_status", SqlDbType.Int,4),
					new SqlParameter("@is_sms", SqlDbType.Int,4),
					new SqlParameter("@note", SqlDbType.VarChar,350),
					new SqlParameter("@recommended_code", SqlDbType.VarChar,250),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@storesId", SqlDbType.Int,4)};
			parameters[0].Value = model.order_num;
			parameters[1].Value = model.user_id;
			parameters[2].Value = model.adress_id;
			parameters[3].Value = model.quantity_sum;
			parameters[4].Value = model.price_sum;
			parameters[5].Value = model.integral_sum;
			parameters[6].Value = model.order_status;
			parameters[7].Value = model.is_sms;
			parameters[8].Value = model.note;
			parameters[9].Value = model.recommended_code;
			parameters[10].Value = model.updateTime;
			parameters[11].Value = model.storesId;

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
		public bool Update(Cms.Model.C_order_integral model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_order_integral set ");
			strSql.Append("order_num=@order_num,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("adress_id=@adress_id,");
			strSql.Append("quantity_sum=@quantity_sum,");
			strSql.Append("price_sum=@price_sum,");
			strSql.Append("integral_sum=@integral_sum,");
			strSql.Append("order_status=@order_status,");
			strSql.Append("is_sms=@is_sms,");
			strSql.Append("note=@note,");
			strSql.Append("recommended_code=@recommended_code,");
			strSql.Append("updateTime=@updateTime,");
			strSql.Append("storesId=@storesId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@order_num", SqlDbType.VarChar,350),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@adress_id", SqlDbType.Int,4),
					new SqlParameter("@quantity_sum", SqlDbType.Int,4),
					new SqlParameter("@price_sum", SqlDbType.Money,8),
					new SqlParameter("@integral_sum", SqlDbType.Int,4),
					new SqlParameter("@order_status", SqlDbType.Int,4),
					new SqlParameter("@is_sms", SqlDbType.Int,4),
					new SqlParameter("@note", SqlDbType.VarChar,350),
					new SqlParameter("@recommended_code", SqlDbType.VarChar,250),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@storesId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.order_num;
			parameters[1].Value = model.user_id;
			parameters[2].Value = model.adress_id;
			parameters[3].Value = model.quantity_sum;
			parameters[4].Value = model.price_sum;
			parameters[5].Value = model.integral_sum;
			parameters[6].Value = model.order_status;
			parameters[7].Value = model.is_sms;
			parameters[8].Value = model.note;
			parameters[9].Value = model.recommended_code;
			parameters[10].Value = model.updateTime;
			parameters[11].Value = model.storesId;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from C_order_integral ");
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
			strSql.Append("delete from C_order_integral ");
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
		public Cms.Model.C_order_integral GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,order_num,user_id,adress_id,quantity_sum,price_sum,integral_sum,order_status,is_sms,note,recommended_code,updateTime,storesId from C_order_integral ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_order_integral model=new Cms.Model.C_order_integral();
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
		public Cms.Model.C_order_integral DataRowToModel(DataRow row)
		{
			Cms.Model.C_order_integral model=new Cms.Model.C_order_integral();
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
				if(row["order_status"]!=null && row["order_status"].ToString()!="")
				{
					model.order_status=int.Parse(row["order_status"].ToString());
				}
				if(row["is_sms"]!=null && row["is_sms"].ToString()!="")
				{
					model.is_sms=int.Parse(row["is_sms"].ToString());
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
				if(row["storesId"]!=null && row["storesId"].ToString()!="")
				{
					model.storesId=int.Parse(row["storesId"].ToString());
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
			strSql.Append("select id,order_num,user_id,adress_id,quantity_sum,price_sum,integral_sum,order_status,is_sms,note,recommended_code,updateTime,storesId ");
			strSql.Append(" FROM C_order_integral ");
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
			strSql.Append(" id,order_num,user_id,adress_id,quantity_sum,price_sum,integral_sum,order_status,is_sms,note,recommended_code,updateTime,storesId ");
			strSql.Append(" FROM C_order_integral ");
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
			strSql.Append("select count(1) FROM C_order_integral ");
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
			strSql.Append(")AS Row, T.*  from C_order_integral T ");
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
			parameters[0].Value = "C_order_integral";
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

