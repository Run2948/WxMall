using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:wx_ConcernReply
	/// </summary>
	public partial class wx_ConcernReply
	{
		public wx_ConcernReply()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_ConcernReply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_ConcernReply");
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
		public int Add(Cms.Model.wx_ConcernReply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_ConcernReply(");
			strSql.Append("typeid,title,contents,fileurl,updatetime,url,isopen,media_id)");
			strSql.Append(" values (");
			strSql.Append("@typeid,@title,@contents,@fileurl,@updatetime,@url,@isopen,@media_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@contents", SqlDbType.Text),
					new SqlParameter("@fileurl", SqlDbType.NVarChar,500),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@url", SqlDbType.NVarChar,500),
					new SqlParameter("@isopen", SqlDbType.Int,4),
					new SqlParameter("@media_id", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.typeid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.contents;
			parameters[3].Value = model.fileurl;
			parameters[4].Value = model.updatetime;
			parameters[5].Value = model.url;
			parameters[6].Value = model.isopen;
			parameters[7].Value = model.media_id;

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
		public bool Update(Cms.Model.wx_ConcernReply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_ConcernReply set ");
			strSql.Append("typeid=@typeid,");
			strSql.Append("title=@title,");
			strSql.Append("contents=@contents,");
			strSql.Append("fileurl=@fileurl,");
			strSql.Append("updatetime=@updatetime,");
			strSql.Append("url=@url,");
			strSql.Append("isopen=@isopen,");
			strSql.Append("media_id=@media_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@contents", SqlDbType.Text),
					new SqlParameter("@fileurl", SqlDbType.NVarChar,500),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@url", SqlDbType.NVarChar,500),
					new SqlParameter("@isopen", SqlDbType.Int,4),
					new SqlParameter("@media_id", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.typeid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.contents;
			parameters[3].Value = model.fileurl;
			parameters[4].Value = model.updatetime;
			parameters[5].Value = model.url;
			parameters[6].Value = model.isopen;
			parameters[7].Value = model.media_id;
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
			strSql.Append("delete from wx_ConcernReply ");
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
			strSql.Append("delete from wx_ConcernReply ");
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
		public Cms.Model.wx_ConcernReply GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,typeid,title,contents,fileurl,updatetime,url,isopen,media_id from wx_ConcernReply ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_ConcernReply model=new Cms.Model.wx_ConcernReply();
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
		public Cms.Model.wx_ConcernReply DataRowToModel(DataRow row)
		{
			Cms.Model.wx_ConcernReply model=new Cms.Model.wx_ConcernReply();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["typeid"]!=null && row["typeid"].ToString()!="")
				{
					model.typeid=int.Parse(row["typeid"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["contents"]!=null)
				{
					model.contents=row["contents"].ToString();
				}
				if(row["fileurl"]!=null)
				{
					model.fileurl=row["fileurl"].ToString();
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["isopen"]!=null && row["isopen"].ToString()!="")
				{
					model.isopen=int.Parse(row["isopen"].ToString());
				}
				if(row["media_id"]!=null)
				{
					model.media_id=row["media_id"].ToString();
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
			strSql.Append("select id,typeid,title,contents,fileurl,updatetime,url,isopen,media_id ");
			strSql.Append(" FROM wx_ConcernReply ");
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
			strSql.Append(" id,typeid,title,contents,fileurl,updatetime,url,isopen,media_id ");
			strSql.Append(" FROM wx_ConcernReply ");
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
			strSql.Append("select count(1) FROM wx_ConcernReply ");
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
			strSql.Append(")AS Row, T.*  from wx_ConcernReply T ");
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
			parameters[0].Value = "wx_ConcernReply";
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

