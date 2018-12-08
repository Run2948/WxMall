/**  版本信息模板在安装目录下，可自行修改。
* C_Province.cs
*
* 功 能： N/A
* 类 名： C_Province
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/28 14:12:43   N/A    初版
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
	/// 数据访问类:C_Province
	/// </summary>
	public partial class C_Province
	{
		public C_Province()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ProvinceID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Province");
			strSql.Append(" where ProvinceID=@ProvinceID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceID", SqlDbType.BigInt)
			};
			parameters[0].Value = ProvinceID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Cms.Model.C_Province model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Province(");
			strSql.Append("ProvinceName,DateCreated,DateUpdated)");
			strSql.Append(" values (");
			strSql.Append("@ProvinceName,@DateCreated,@DateUpdated)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@DateCreated", SqlDbType.DateTime),
					new SqlParameter("@DateUpdated", SqlDbType.DateTime)};
			parameters[0].Value = model.ProvinceName;
			parameters[1].Value = model.DateCreated;
			parameters[2].Value = model.DateUpdated;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Cms.Model.C_Province model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Province set ");
			strSql.Append("ProvinceName=@ProvinceName,");
			strSql.Append("DateCreated=@DateCreated,");
			strSql.Append("DateUpdated=@DateUpdated");
			strSql.Append(" where ProvinceID=@ProvinceID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@DateCreated", SqlDbType.DateTime),
					new SqlParameter("@DateUpdated", SqlDbType.DateTime),
					new SqlParameter("@ProvinceID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.ProvinceName;
			parameters[1].Value = model.DateCreated;
			parameters[2].Value = model.DateUpdated;
			parameters[3].Value = model.ProvinceID;

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
		public bool Delete(long ProvinceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Province ");
			strSql.Append(" where ProvinceID=@ProvinceID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceID", SqlDbType.BigInt)
			};
			parameters[0].Value = ProvinceID;

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
		public bool DeleteList(string ProvinceIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Province ");
			strSql.Append(" where ProvinceID in ("+ProvinceIDlist + ")  ");
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
		public Cms.Model.C_Province GetModel(long ProvinceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProvinceID,ProvinceName,DateCreated,DateUpdated from C_Province ");
			strSql.Append(" where ProvinceID=@ProvinceID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceID", SqlDbType.BigInt)
			};
			parameters[0].Value = ProvinceID;

			Cms.Model.C_Province model=new Cms.Model.C_Province();
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
		public Cms.Model.C_Province DataRowToModel(DataRow row)
		{
			Cms.Model.C_Province model=new Cms.Model.C_Province();
			if (row != null)
			{
				if(row["ProvinceID"]!=null && row["ProvinceID"].ToString()!="")
				{
					model.ProvinceID=long.Parse(row["ProvinceID"].ToString());
				}
				if(row["ProvinceName"]!=null)
				{
					model.ProvinceName=row["ProvinceName"].ToString();
				}
				if(row["DateCreated"]!=null && row["DateCreated"].ToString()!="")
				{
					model.DateCreated=DateTime.Parse(row["DateCreated"].ToString());
				}
				if(row["DateUpdated"]!=null && row["DateUpdated"].ToString()!="")
				{
					model.DateUpdated=DateTime.Parse(row["DateUpdated"].ToString());
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
			strSql.Append("select ProvinceID,ProvinceName,DateCreated,DateUpdated ");
			strSql.Append(" FROM C_Province ");
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
			strSql.Append(" ProvinceID,ProvinceName,DateCreated,DateUpdated ");
			strSql.Append(" FROM C_Province ");
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
			strSql.Append("select count(1) FROM C_Province ");
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
				strSql.Append("order by T.ProvinceID desc");
			}
			strSql.Append(")AS Row, T.*  from C_Province T ");
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
			parameters[0].Value = "C_Province";
			parameters[1].Value = "ProvinceID";
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

