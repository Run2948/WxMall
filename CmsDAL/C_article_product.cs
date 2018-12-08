/**  版本信息模板在安装目录下，可自行修改。
* C_article_product.cs
*
* 功 能： N/A
* 类 名： C_article_product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/4/29 7:37:09   N/A    初版
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
	/// 数据访问类:C_article_product
	/// </summary>
	public partial class C_article_product
	{
		public C_article_product()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_article_product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_article_product");
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
		public int Add(Cms.Model.C_article_product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_article_product(");
			strSql.Append("article_id,price,marketPrice,integral,stock,is_integral,group_id,s_version)");
			strSql.Append(" values (");
			strSql.Append("@article_id,@price,@marketPrice,@integral,@stock,@is_integral,@group_id,@s_version)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@marketPrice", SqlDbType.Money,8),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@is_integral", SqlDbType.Int,4),
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@s_version", SqlDbType.Int,4)};
			parameters[0].Value = model.article_id;
			parameters[1].Value = model.price;
			parameters[2].Value = model.marketPrice;
			parameters[3].Value = model.integral;
			parameters[4].Value = model.stock;
			parameters[5].Value = model.is_integral;
			parameters[6].Value = model.group_id;
			parameters[7].Value = model.s_version;

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
		public bool Update(Cms.Model.C_article_product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_article_product set ");
			strSql.Append("article_id=@article_id,");
			strSql.Append("price=@price,");
			strSql.Append("marketPrice=@marketPrice,");
			strSql.Append("integral=@integral,");
			strSql.Append("stock=@stock,");
			strSql.Append("is_integral=@is_integral,");
			strSql.Append("group_id=@group_id,");
			strSql.Append("s_version=@s_version");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@marketPrice", SqlDbType.Money,8),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@is_integral", SqlDbType.Int,4),
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@s_version", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.article_id;
			parameters[1].Value = model.price;
			parameters[2].Value = model.marketPrice;
			parameters[3].Value = model.integral;
			parameters[4].Value = model.stock;
			parameters[5].Value = model.is_integral;
			parameters[6].Value = model.group_id;
			parameters[7].Value = model.s_version;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from C_article_product ");
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
			strSql.Append("delete from C_article_product ");
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
		public Cms.Model.C_article_product GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,article_id,price,marketPrice,integral,stock,is_integral,group_id,s_version from C_article_product ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_article_product model=new Cms.Model.C_article_product();
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
		public Cms.Model.C_article_product DataRowToModel(DataRow row)
		{
			Cms.Model.C_article_product model=new Cms.Model.C_article_product();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["marketPrice"]!=null && row["marketPrice"].ToString()!="")
				{
					model.marketPrice=decimal.Parse(row["marketPrice"].ToString());
				}
				if(row["integral"]!=null && row["integral"].ToString()!="")
				{
					model.integral=int.Parse(row["integral"].ToString());
				}
				if(row["stock"]!=null && row["stock"].ToString()!="")
				{
					model.stock=int.Parse(row["stock"].ToString());
				}
				if(row["is_integral"]!=null && row["is_integral"].ToString()!="")
				{
					model.is_integral=int.Parse(row["is_integral"].ToString());
				}
				if(row["group_id"]!=null && row["group_id"].ToString()!="")
				{
					model.group_id=int.Parse(row["group_id"].ToString());
				}
				if(row["s_version"]!=null && row["s_version"].ToString()!="")
				{
					model.s_version=int.Parse(row["s_version"].ToString());
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
			strSql.Append("select id,article_id,price,marketPrice,integral,stock,is_integral,group_id,s_version ");
			strSql.Append(" FROM C_article_product ");
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
			strSql.Append(" id,article_id,price,marketPrice,integral,stock,is_integral,group_id,s_version ");
			strSql.Append(" FROM C_article_product ");
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
			strSql.Append("select count(1) FROM C_article_product ");
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
			strSql.Append(")AS Row, T.*  from C_article_product T ");
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
			parameters[0].Value = "C_article_product";
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

