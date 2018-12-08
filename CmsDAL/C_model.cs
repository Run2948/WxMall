/**  版本信息模板在安装目录下，可自行修改。
* C_model.cs
*
* 功 能： N/A
* 类 名： C_model
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/28 10:48:56   N/A    初版
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
	/// 数据访问类:C_model
	/// </summary>
	public partial class C_model
	{
		public C_model()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("modelId", "C_model"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int modelId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_model");
			strSql.Append(" where modelId=@modelId");
			SqlParameter[] parameters = {
					new SqlParameter("@modelId", SqlDbType.Int,4)
			};
			parameters[0].Value = modelId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_model(");
			strSql.Append("modelName,modelValue)");
			strSql.Append(" values (");
			strSql.Append("@modelName,@modelValue)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@modelName", SqlDbType.VarChar,250),
					new SqlParameter("@modelValue", SqlDbType.VarChar,250)};
			parameters[0].Value = model.modelName;
			parameters[1].Value = model.modelValue;

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
		public bool Update(Cms.Model.C_model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_model set ");
			strSql.Append("modelName=@modelName,");
			strSql.Append("modelValue=@modelValue");
			strSql.Append(" where modelId=@modelId");
			SqlParameter[] parameters = {
					new SqlParameter("@modelName", SqlDbType.VarChar,250),
					new SqlParameter("@modelValue", SqlDbType.VarChar,250),
					new SqlParameter("@modelId", SqlDbType.Int,4)};
			parameters[0].Value = model.modelName;
			parameters[1].Value = model.modelValue;
			parameters[2].Value = model.modelId;

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
		public bool Delete(int modelId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_model ");
			strSql.Append(" where modelId=@modelId");
			SqlParameter[] parameters = {
					new SqlParameter("@modelId", SqlDbType.Int,4)
			};
			parameters[0].Value = modelId;

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
		public bool DeleteList(string modelIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_model ");
			strSql.Append(" where modelId in ("+modelIdlist + ")  ");
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
		public Cms.Model.C_model GetModel(int modelId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 modelId,modelName,modelValue from C_model ");
			strSql.Append(" where modelId=@modelId");
			SqlParameter[] parameters = {
					new SqlParameter("@modelId", SqlDbType.Int,4)
			};
			parameters[0].Value = modelId;

			Cms.Model.C_model model=new Cms.Model.C_model();
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
		public Cms.Model.C_model DataRowToModel(DataRow row)
		{
			Cms.Model.C_model model=new Cms.Model.C_model();
			if (row != null)
			{
				if(row["modelId"]!=null && row["modelId"].ToString()!="")
				{
					model.modelId=int.Parse(row["modelId"].ToString());
				}
				if(row["modelName"]!=null)
				{
					model.modelName=row["modelName"].ToString();
				}
				if(row["modelValue"]!=null)
				{
					model.modelValue=row["modelValue"].ToString();
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
			strSql.Append("select modelId,modelName,modelValue ");
			strSql.Append(" FROM C_model ");
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
			strSql.Append(" modelId,modelName,modelValue ");
			strSql.Append(" FROM C_model ");
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
			strSql.Append("select count(1) FROM C_model ");
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
				strSql.Append("order by T.modelId desc");
			}
			strSql.Append(")AS Row, T.*  from C_model T ");
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
			parameters[0].Value = "C_model";
			parameters[1].Value = "modelId";
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

