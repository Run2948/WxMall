using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:ws_Lottery
	/// </summary>
	public partial class ws_Lottery
	{
		public ws_Lottery()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "ws_Lottery"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ws_Lottery");
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
		public int Add(Cms.Model.ws_Lottery model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ws_Lottery(");
			strSql.Append("lname,picurl,stime,etime,info,isnum,total,daynum,typeid,updatetime)");
			strSql.Append(" values (");
			strSql.Append("@lname,@picurl,@stime,@etime,@info,@isnum,@total,@daynum,@typeid,@updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,100),
					new SqlParameter("@picurl", SqlDbType.NVarChar,50),
					new SqlParameter("@stime", SqlDbType.DateTime),
					new SqlParameter("@etime", SqlDbType.DateTime),
					new SqlParameter("@info", SqlDbType.NVarChar,500),
					new SqlParameter("@isnum", SqlDbType.Int,4),
					new SqlParameter("@total", SqlDbType.Int,4),
					new SqlParameter("@daynum", SqlDbType.Int,4),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.lname;
			parameters[1].Value = model.picurl;
			parameters[2].Value = model.stime;
			parameters[3].Value = model.etime;
			parameters[4].Value = model.info;
			parameters[5].Value = model.isnum;
			parameters[6].Value = model.total;
			parameters[7].Value = model.daynum;
			parameters[8].Value = model.typeid;
			parameters[9].Value = model.updatetime;

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
		public bool Update(Cms.Model.ws_Lottery model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ws_Lottery set ");
			strSql.Append("lname=@lname,");
			strSql.Append("picurl=@picurl,");
			strSql.Append("stime=@stime,");
			strSql.Append("etime=@etime,");
			strSql.Append("info=@info,");
			strSql.Append("isnum=@isnum,");
			strSql.Append("total=@total,");
			strSql.Append("daynum=@daynum,");
			strSql.Append("typeid=@typeid,");
			strSql.Append("updatetime=@updatetime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,100),
					new SqlParameter("@picurl", SqlDbType.NVarChar,50),
					new SqlParameter("@stime", SqlDbType.DateTime),
					new SqlParameter("@etime", SqlDbType.DateTime),
					new SqlParameter("@info", SqlDbType.NVarChar,500),
					new SqlParameter("@isnum", SqlDbType.Int,4),
					new SqlParameter("@total", SqlDbType.Int,4),
					new SqlParameter("@daynum", SqlDbType.Int,4),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.lname;
			parameters[1].Value = model.picurl;
			parameters[2].Value = model.stime;
			parameters[3].Value = model.etime;
			parameters[4].Value = model.info;
			parameters[5].Value = model.isnum;
			parameters[6].Value = model.total;
			parameters[7].Value = model.daynum;
			parameters[8].Value = model.typeid;
			parameters[9].Value = model.updatetime;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from ws_Lottery ");
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
			strSql.Append("delete from ws_Lottery ");
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
		public Cms.Model.ws_Lottery GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,lname,picurl,stime,etime,info,isnum,total,daynum,typeid,updatetime from ws_Lottery ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.ws_Lottery model=new Cms.Model.ws_Lottery();
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
		public Cms.Model.ws_Lottery DataRowToModel(DataRow row)
		{
			Cms.Model.ws_Lottery model=new Cms.Model.ws_Lottery();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["lname"]!=null)
				{
					model.lname=row["lname"].ToString();
				}
				if(row["picurl"]!=null)
				{
					model.picurl=row["picurl"].ToString();
				}
				if(row["stime"]!=null && row["stime"].ToString()!="")
				{
					model.stime=DateTime.Parse(row["stime"].ToString());
				}
				if(row["etime"]!=null && row["etime"].ToString()!="")
				{
					model.etime=DateTime.Parse(row["etime"].ToString());
				}
				if(row["info"]!=null)
				{
					model.info=row["info"].ToString();
				}
				if(row["isnum"]!=null && row["isnum"].ToString()!="")
				{
					model.isnum=int.Parse(row["isnum"].ToString());
				}
				if(row["total"]!=null && row["total"].ToString()!="")
				{
					model.total=int.Parse(row["total"].ToString());
				}
				if(row["daynum"]!=null && row["daynum"].ToString()!="")
				{
					model.daynum=int.Parse(row["daynum"].ToString());
				}
				if(row["typeid"]!=null && row["typeid"].ToString()!="")
				{
					model.typeid=int.Parse(row["typeid"].ToString());
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
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
			strSql.Append("select id,lname,picurl,stime,etime,info,isnum,total,daynum,typeid,updatetime ");
			strSql.Append(" FROM ws_Lottery ");
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
			strSql.Append(" id,lname,picurl,stime,etime,info,isnum,total,daynum,typeid,updatetime ");
			strSql.Append(" FROM ws_Lottery ");
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
			strSql.Append("select count(1) FROM ws_Lottery ");
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
			strSql.Append(")AS Row, T.*  from ws_Lottery T ");
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
			parameters[0].Value = "ws_Lottery";
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

