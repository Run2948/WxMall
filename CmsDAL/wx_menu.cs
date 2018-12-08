/**  版本信息模板在安装目录下，可自行修改。
* wx_menu.cs
*
* 功 能： N/A
* 类 名： wx_menu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/23 16:13:09   N/A    初版
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
	/// 数据访问类:wx_menu
	/// </summary>
	public partial class wx_menu
	{
		public wx_menu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_menu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_menu");
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
		public int Add(Cms.Model.wx_menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_menu(");
			strSql.Append("name,type,keys,url,pid,time,info,content)");
			strSql.Append(" values (");
			strSql.Append("@name,@type,@keys,@url,@pid,@time,@info,@content)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@keys", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,150),
					new SqlParameter("@pid", SqlDbType.NVarChar,50),
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@info", SqlDbType.VarChar,500),
					new SqlParameter("@content", SqlDbType.Text)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.type;
			parameters[2].Value = model.keys;
			parameters[3].Value = model.url;
			parameters[4].Value = model.pid;
			parameters[5].Value = model.time;
			parameters[6].Value = model.info;
			parameters[7].Value = model.content;

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
		public bool Update(Cms.Model.wx_menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_menu set ");
			strSql.Append("name=@name,");
			strSql.Append("type=@type,");
			strSql.Append("keys=@keys,");
			strSql.Append("url=@url,");
			strSql.Append("pid=@pid,");
			strSql.Append("time=@time,");
			strSql.Append("info=@info,");
			strSql.Append("content=@content");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@keys", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,150),
					new SqlParameter("@pid", SqlDbType.NVarChar,50),
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@info", SqlDbType.VarChar,500),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.type;
			parameters[2].Value = model.keys;
			parameters[3].Value = model.url;
			parameters[4].Value = model.pid;
			parameters[5].Value = model.time;
			parameters[6].Value = model.info;
			parameters[7].Value = model.content;
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
			strSql.Append("delete from wx_menu ");
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
			strSql.Append("delete from wx_menu ");
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
		public Cms.Model.wx_menu GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,type,keys,url,pid,time,info,content from wx_menu ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_menu model=new Cms.Model.wx_menu();
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
		public Cms.Model.wx_menu DataRowToModel(DataRow row)
		{
			Cms.Model.wx_menu model=new Cms.Model.wx_menu();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["keys"]!=null)
				{
					model.keys=row["keys"].ToString();
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["pid"]!=null)
				{
					model.pid=row["pid"].ToString();
				}
				if(row["time"]!=null && row["time"].ToString()!="")
				{
					model.time=DateTime.Parse(row["time"].ToString());
				}
				if(row["info"]!=null)
				{
					model.info=row["info"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
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
			strSql.Append("select id,name,type,keys,url,pid,time,info,content ");
			strSql.Append(" FROM wx_menu ");
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
			strSql.Append(" id,name,type,keys,url,pid,time,info,content ");
			strSql.Append(" FROM wx_menu ");
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
			strSql.Append("select count(1) FROM wx_menu ");
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
			strSql.Append(")AS Row, T.*  from wx_menu T ");
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
			parameters[0].Value = "wx_menu";
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

