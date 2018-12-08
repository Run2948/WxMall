/**  版本信息模板在安装目录下，可自行修改。
* C_City.cs
*
* 功 能： N/A
* 类 名： C_City
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
	/// 数据访问类:C_City
	/// </summary>
	public partial class C_City
	{
		public C_City()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long CityID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_City");
			strSql.Append(" where CityID=@CityID");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.BigInt)
			};
			parameters[0].Value = CityID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Cms.Model.C_City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_City(");
			strSql.Append("CityName,ZipCode,ProvinceID,DateCreated,DateUpdated)");
			strSql.Append(" values (");
			strSql.Append("@CityName,@ZipCode,@ProvinceID,@DateCreated,@DateUpdated)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CityName", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.BigInt,8),
					new SqlParameter("@DateCreated", SqlDbType.DateTime),
					new SqlParameter("@DateUpdated", SqlDbType.DateTime)};
			parameters[0].Value = model.CityName;
			parameters[1].Value = model.ZipCode;
			parameters[2].Value = model.ProvinceID;
			parameters[3].Value = model.DateCreated;
			parameters[4].Value = model.DateUpdated;

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
		public bool Update(Cms.Model.C_City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_City set ");
			strSql.Append("CityName=@CityName,");
			strSql.Append("ZipCode=@ZipCode,");
			strSql.Append("ProvinceID=@ProvinceID,");
			strSql.Append("DateCreated=@DateCreated,");
			strSql.Append("DateUpdated=@DateUpdated");
			strSql.Append(" where CityID=@CityID");
			SqlParameter[] parameters = {
					new SqlParameter("@CityName", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.BigInt,8),
					new SqlParameter("@DateCreated", SqlDbType.DateTime),
					new SqlParameter("@DateUpdated", SqlDbType.DateTime),
					new SqlParameter("@CityID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.CityName;
			parameters[1].Value = model.ZipCode;
			parameters[2].Value = model.ProvinceID;
			parameters[3].Value = model.DateCreated;
			parameters[4].Value = model.DateUpdated;
			parameters[5].Value = model.CityID;

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
		public bool Delete(long CityID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_City ");
			strSql.Append(" where CityID=@CityID");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.BigInt)
			};
			parameters[0].Value = CityID;

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
		public bool DeleteList(string CityIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_City ");
			strSql.Append(" where CityID in ("+CityIDlist + ")  ");
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
		public Cms.Model.C_City GetModel(long CityID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CityID,CityName,ZipCode,ProvinceID,DateCreated,DateUpdated from C_City ");
			strSql.Append(" where CityID=@CityID");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.BigInt)
			};
			parameters[0].Value = CityID;

			Cms.Model.C_City model=new Cms.Model.C_City();
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
		public Cms.Model.C_City DataRowToModel(DataRow row)
		{
			Cms.Model.C_City model=new Cms.Model.C_City();
			if (row != null)
			{
				if(row["CityID"]!=null && row["CityID"].ToString()!="")
				{
					model.CityID=long.Parse(row["CityID"].ToString());
				}
				if(row["CityName"]!=null)
				{
					model.CityName=row["CityName"].ToString();
				}
				if(row["ZipCode"]!=null)
				{
					model.ZipCode=row["ZipCode"].ToString();
				}
				if(row["ProvinceID"]!=null && row["ProvinceID"].ToString()!="")
				{
					model.ProvinceID=long.Parse(row["ProvinceID"].ToString());
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
			strSql.Append("select CityID,CityName,ZipCode,ProvinceID,DateCreated,DateUpdated ");
			strSql.Append(" FROM C_City ");
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
			strSql.Append(" CityID,CityName,ZipCode,ProvinceID,DateCreated,DateUpdated ");
			strSql.Append(" FROM C_City ");
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
			strSql.Append("select count(1) FROM C_City ");
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
				strSql.Append("order by T.CityID desc");
			}
			strSql.Append(")AS Row, T.*  from C_City T ");
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
			parameters[0].Value = "C_City";
			parameters[1].Value = "CityID";
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

