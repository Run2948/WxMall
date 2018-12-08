/**  版本信息模板在安装目录下，可自行修改。
* C_order_integralsub.cs
*
* 功 能： N/A
* 类 名： C_order_integralsub
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/3 19:14:27   N/A    初版
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
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:C_order_integralsub
	/// </summary>
	public partial class C_order_integralsub
	{
		public C_order_integralsub()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_order_integralsub"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_order_integralsub");
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
		public int Add(Cms.Model.C_order_integralsub model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_order_integralsub(");
			strSql.Append("user_id,order_id,order_num,article_id,title,price,quantity,integral,property_value,note,updateTime)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@order_id,@order_num,@article_id,@title,@price,@quantity,@integral,@property_value,@note,@updateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@order_num", SqlDbType.VarChar,350),
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,-1),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@property_value", SqlDbType.VarChar,550),
					new SqlParameter("@note", SqlDbType.VarChar,-1),
					new SqlParameter("@updateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.order_id;
			parameters[2].Value = model.order_num;
			parameters[3].Value = model.article_id;
			parameters[4].Value = model.title;
			parameters[5].Value = model.price;
			parameters[6].Value = model.quantity;
			parameters[7].Value = model.integral;
			parameters[8].Value = model.property_value;
			parameters[9].Value = model.note;
			parameters[10].Value = model.updateTime;

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
		public bool Update(Cms.Model.C_order_integralsub model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_order_integralsub set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("order_id=@order_id,");
			strSql.Append("order_num=@order_num,");
			strSql.Append("article_id=@article_id,");
			strSql.Append("title=@title,");
			strSql.Append("price=@price,");
			strSql.Append("quantity=@quantity,");
			strSql.Append("integral=@integral,");
			strSql.Append("property_value=@property_value,");
			strSql.Append("note=@note,");
			strSql.Append("updateTime=@updateTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@order_num", SqlDbType.VarChar,350),
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,-1),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@property_value", SqlDbType.VarChar,550),
					new SqlParameter("@note", SqlDbType.VarChar,-1),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.order_id;
			parameters[2].Value = model.order_num;
			parameters[3].Value = model.article_id;
			parameters[4].Value = model.title;
			parameters[5].Value = model.price;
			parameters[6].Value = model.quantity;
			parameters[7].Value = model.integral;
			parameters[8].Value = model.property_value;
			parameters[9].Value = model.note;
			parameters[10].Value = model.updateTime;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from C_order_integralsub ");
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
			strSql.Append("delete from C_order_integralsub ");
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
		public Cms.Model.C_order_integralsub GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,user_id,order_id,order_num,article_id,title,price,quantity,integral,property_value,note,updateTime from C_order_integralsub ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_order_integralsub model=new Cms.Model.C_order_integralsub();
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
		public Cms.Model.C_order_integralsub DataRowToModel(DataRow row)
		{
			Cms.Model.C_order_integralsub model=new Cms.Model.C_order_integralsub();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["order_id"]!=null && row["order_id"].ToString()!="")
				{
					model.order_id=int.Parse(row["order_id"].ToString());
				}
				if(row["order_num"]!=null)
				{
					model.order_num=row["order_num"].ToString();
				}
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["quantity"]!=null && row["quantity"].ToString()!="")
				{
					model.quantity=int.Parse(row["quantity"].ToString());
				}
				if(row["integral"]!=null && row["integral"].ToString()!="")
				{
					model.integral=int.Parse(row["integral"].ToString());
				}
				if(row["property_value"]!=null)
				{
					model.property_value=row["property_value"].ToString();
				}
				if(row["note"]!=null)
				{
					model.note=row["note"].ToString();
				}
				if(row["updateTime"]!=null && row["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(row["updateTime"].ToString());
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
			strSql.Append("select id,user_id,order_id,order_num,article_id,title,price,quantity,integral,property_value,note,updateTime ");
			strSql.Append(" FROM C_order_integralsub ");
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
			strSql.Append(" id,user_id,order_id,order_num,article_id,title,price,quantity,integral,property_value,note,updateTime ");
			strSql.Append(" FROM C_order_integralsub ");
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
			strSql.Append("select count(1) FROM C_order_integralsub ");
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
			strSql.Append(")AS Row, T.*  from C_order_integralsub T ");
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
			parameters[0].Value = "C_order_integralsub";
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

