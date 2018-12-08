/**  版本信息模板在安装目录下，可自行修改。
* C_user_oauth_app.cs
*
* 功 能： N/A
* 类 名： C_user_oauth_app
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/25 11:35:57   N/A    初版
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
	/// 数据访问类:C_user_oauth_app
	/// </summary>
	public partial class C_user_oauth_app
	{
		public C_user_oauth_app()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_user_oauth_app"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_user_oauth_app");
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
		public int Add(Cms.Model.C_user_oauth_app model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_user_oauth_app(");
			strSql.Append("title,img_url,app_id,app_key,remark,sort_id,is_lock,api_path)");
			strSql.Append(" values (");
			strSql.Append("@title,@img_url,@app_id,@app_key,@remark,@sort_id,@is_lock,@api_path)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@app_id", SqlDbType.NVarChar,100),
					new SqlParameter("@app_key", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@api_path", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.img_url;
			parameters[2].Value = model.app_id;
			parameters[3].Value = model.app_key;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.sort_id;
			parameters[6].Value = model.is_lock;
			parameters[7].Value = model.api_path;

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
		public bool Update(Cms.Model.C_user_oauth_app model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_user_oauth_app set ");
			strSql.Append("title=@title,");
			strSql.Append("img_url=@img_url,");
			strSql.Append("app_id=@app_id,");
			strSql.Append("app_key=@app_key,");
			strSql.Append("remark=@remark,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("is_lock=@is_lock,");
			strSql.Append("api_path=@api_path");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@app_id", SqlDbType.NVarChar,100),
					new SqlParameter("@app_key", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@api_path", SqlDbType.NVarChar,255),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.img_url;
			parameters[2].Value = model.app_id;
			parameters[3].Value = model.app_key;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.sort_id;
			parameters[6].Value = model.is_lock;
			parameters[7].Value = model.api_path;
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
			strSql.Append("delete from C_user_oauth_app ");
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
			strSql.Append("delete from C_user_oauth_app ");
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
		public Cms.Model.C_user_oauth_app GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,img_url,app_id,app_key,remark,sort_id,is_lock,api_path from C_user_oauth_app ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_user_oauth_app model=new Cms.Model.C_user_oauth_app();
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
		public Cms.Model.C_user_oauth_app DataRowToModel(DataRow row)
		{
			Cms.Model.C_user_oauth_app model=new Cms.Model.C_user_oauth_app();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["img_url"]!=null)
				{
					model.img_url=row["img_url"].ToString();
				}
				if(row["app_id"]!=null)
				{
					model.app_id=row["app_id"].ToString();
				}
				if(row["app_key"]!=null)
				{
					model.app_key=row["app_key"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["is_lock"]!=null && row["is_lock"].ToString()!="")
				{
					model.is_lock=int.Parse(row["is_lock"].ToString());
				}
				if(row["api_path"]!=null)
				{
					model.api_path=row["api_path"].ToString();
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
			strSql.Append("select id,title,img_url,app_id,app_key,remark,sort_id,is_lock,api_path ");
			strSql.Append(" FROM C_user_oauth_app ");
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
			strSql.Append(" id,title,img_url,app_id,app_key,remark,sort_id,is_lock,api_path ");
			strSql.Append(" FROM C_user_oauth_app ");
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
			strSql.Append("select count(1) FROM C_user_oauth_app ");
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
			strSql.Append(")AS Row, T.*  from C_user_oauth_app T ");
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
			parameters[0].Value = "C_user_oauth_app";
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

