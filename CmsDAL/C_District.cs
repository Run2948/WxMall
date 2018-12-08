/**  版本信息模板在安装目录下，可自行修改。
* C_District.cs
*
* 功 能： N/A
* 类 名： C_District
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
	/// 数据访问类:C_District
	/// </summary>
	public partial class C_District
	{
		public C_District()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long DistrictID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_District");
			strSql.Append(" where DistrictID=@DistrictID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt)
			};
			parameters[0].Value = DistrictID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Cms.Model.C_District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_District(");
			strSql.Append("DistrictName,CityID,DateCreated,DateUpdated)");
			strSql.Append(" values (");
			strSql.Append("@DistrictName,@CityID,@DateCreated,@DateUpdated)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.BigInt,8),
					new SqlParameter("@DateCreated", SqlDbType.DateTime),
					new SqlParameter("@DateUpdated", SqlDbType.DateTime)};
			parameters[0].Value = model.DistrictName;
			parameters[1].Value = model.CityID;
			parameters[2].Value = model.DateCreated;
			parameters[3].Value = model.DateUpdated;

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
		public bool Update(Cms.Model.C_District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_District set ");
			strSql.Append("DistrictName=@DistrictName,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("DateCreated=@DateCreated,");
			strSql.Append("DateUpdated=@DateUpdated");
			strSql.Append(" where DistrictID=@DistrictID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.BigInt,8),
					new SqlParameter("@DateCreated", SqlDbType.DateTime),
					new SqlParameter("@DateUpdated", SqlDbType.DateTime),
					new SqlParameter("@DistrictID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.DistrictName;
			parameters[1].Value = model.CityID;
			parameters[2].Value = model.DateCreated;
			parameters[3].Value = model.DateUpdated;
			parameters[4].Value = model.DistrictID;

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
		public bool Delete(long DistrictID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_District ");
			strSql.Append(" where DistrictID=@DistrictID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt)
			};
			parameters[0].Value = DistrictID;

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
		public bool DeleteList(string DistrictIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_District ");
			strSql.Append(" where DistrictID in ("+DistrictIDlist + ")  ");
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
		public Cms.Model.C_District GetModel(long DistrictID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DistrictID,DistrictName,CityID,DateCreated,DateUpdated from C_District ");
			strSql.Append(" where DistrictID=@DistrictID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt)
			};
			parameters[0].Value = DistrictID;

			Cms.Model.C_District model=new Cms.Model.C_District();
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
		public Cms.Model.C_District DataRowToModel(DataRow row)
		{
			Cms.Model.C_District model=new Cms.Model.C_District();
			if (row != null)
			{
				if(row["DistrictID"]!=null && row["DistrictID"].ToString()!="")
				{
					model.DistrictID=long.Parse(row["DistrictID"].ToString());
				}
				if(row["DistrictName"]!=null)
				{
					model.DistrictName=row["DistrictName"].ToString();
				}
				if(row["CityID"]!=null && row["CityID"].ToString()!="")
				{
					model.CityID=long.Parse(row["CityID"].ToString());
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
			strSql.Append("select DistrictID,DistrictName,CityID,DateCreated,DateUpdated ");
			strSql.Append(" FROM C_District ");
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
			strSql.Append(" DistrictID,DistrictName,CityID,DateCreated,DateUpdated ");
			strSql.Append(" FROM C_District ");
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
			strSql.Append("select count(1) FROM C_District ");
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
				strSql.Append("order by T.DistrictID desc");
			}
			strSql.Append(")AS Row, T.*  from C_District T ");
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
			parameters[0].Value = "C_District";
			parameters[1].Value = "DistrictID";
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

