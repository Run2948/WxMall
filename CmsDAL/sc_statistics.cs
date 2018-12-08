using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:sc_statistics
	/// </summary>
	public partial class sc_statistics
	{
		public sc_statistics()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "sc_statistics"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sc_statistics");
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
		public int Add(Cms.Model.sc_statistics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sc_statistics(");
			strSql.Append("typename,typecontents,msgnumber,visitnumber,gznumber,qxnumber,doingnumber,zfnumber,updatetime)");
			strSql.Append(" values (");
			strSql.Append("@typename,@typecontents,@msgnumber,@visitnumber,@gznumber,@qxnumber,@doingnumber,@zfnumber,@updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typename", SqlDbType.NVarChar,50),
					new SqlParameter("@typecontents", SqlDbType.Text),
					new SqlParameter("@msgnumber", SqlDbType.Int,4),
					new SqlParameter("@visitnumber", SqlDbType.Int,4),
					new SqlParameter("@gznumber", SqlDbType.Int,4),
					new SqlParameter("@qxnumber", SqlDbType.Int,4),
					new SqlParameter("@doingnumber", SqlDbType.Int,4),
					new SqlParameter("@zfnumber", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.typename;
			parameters[1].Value = model.typecontents;
			parameters[2].Value = model.msgnumber;
			parameters[3].Value = model.visitnumber;
			parameters[4].Value = model.gznumber;
			parameters[5].Value = model.qxnumber;
			parameters[6].Value = model.doingnumber;
			parameters[7].Value = model.zfnumber;
			parameters[8].Value = model.updatetime;

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
		public bool Update(Cms.Model.sc_statistics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sc_statistics set ");
			strSql.Append("typename=@typename,");
			strSql.Append("typecontents=@typecontents,");
			strSql.Append("msgnumber=@msgnumber,");
			strSql.Append("visitnumber=@visitnumber,");
			strSql.Append("gznumber=@gznumber,");
			strSql.Append("qxnumber=@qxnumber,");
			strSql.Append("doingnumber=@doingnumber,");
			strSql.Append("zfnumber=@zfnumber,");
			strSql.Append("updatetime=@updatetime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@typename", SqlDbType.NVarChar,50),
					new SqlParameter("@typecontents", SqlDbType.Text),
					new SqlParameter("@msgnumber", SqlDbType.Int,4),
					new SqlParameter("@visitnumber", SqlDbType.Int,4),
					new SqlParameter("@gznumber", SqlDbType.Int,4),
					new SqlParameter("@qxnumber", SqlDbType.Int,4),
					new SqlParameter("@doingnumber", SqlDbType.Int,4),
					new SqlParameter("@zfnumber", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.typename;
			parameters[1].Value = model.typecontents;
			parameters[2].Value = model.msgnumber;
			parameters[3].Value = model.visitnumber;
			parameters[4].Value = model.gznumber;
			parameters[5].Value = model.qxnumber;
			parameters[6].Value = model.doingnumber;
			parameters[7].Value = model.zfnumber;
			parameters[8].Value = model.updatetime;
			parameters[9].Value = model.id;

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
			strSql.Append("delete from sc_statistics ");
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
			strSql.Append("delete from sc_statistics ");
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
		public Cms.Model.sc_statistics GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,typename,typecontents,msgnumber,visitnumber,gznumber,qxnumber,doingnumber,zfnumber,updatetime from sc_statistics ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.sc_statistics model=new Cms.Model.sc_statistics();
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
		public Cms.Model.sc_statistics DataRowToModel(DataRow row)
		{
			Cms.Model.sc_statistics model=new Cms.Model.sc_statistics();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["typename"]!=null)
				{
					model.typename=row["typename"].ToString();
				}
				if(row["typecontents"]!=null)
				{
					model.typecontents=row["typecontents"].ToString();
				}
				if(row["msgnumber"]!=null && row["msgnumber"].ToString()!="")
				{
					model.msgnumber=int.Parse(row["msgnumber"].ToString());
				}
				if(row["visitnumber"]!=null && row["visitnumber"].ToString()!="")
				{
					model.visitnumber=int.Parse(row["visitnumber"].ToString());
				}
				if(row["gznumber"]!=null && row["gznumber"].ToString()!="")
				{
					model.gznumber=int.Parse(row["gznumber"].ToString());
				}
				if(row["qxnumber"]!=null && row["qxnumber"].ToString()!="")
				{
					model.qxnumber=int.Parse(row["qxnumber"].ToString());
				}
				if(row["doingnumber"]!=null && row["doingnumber"].ToString()!="")
				{
					model.doingnumber=int.Parse(row["doingnumber"].ToString());
				}
				if(row["zfnumber"]!=null && row["zfnumber"].ToString()!="")
				{
					model.zfnumber=int.Parse(row["zfnumber"].ToString());
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
			strSql.Append("select id,typename,typecontents,msgnumber,visitnumber,gznumber,qxnumber,doingnumber,zfnumber,updatetime ");
			strSql.Append(" FROM sc_statistics ");
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
			strSql.Append(" id,typename,typecontents,msgnumber,visitnumber,gznumber,qxnumber,doingnumber,zfnumber,updatetime ");
			strSql.Append(" FROM sc_statistics ");
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
			strSql.Append("select count(1) FROM sc_statistics ");
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
			strSql.Append(")AS Row, T.*  from sc_statistics T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取当天数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetTimeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM  sc_statistics where DateDiff(dd,updatetime,getdate())=0 ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取当天数据
        /// </summary>
        /// <returns></returns>
        public int GetTimeId(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT id FROM  sc_statistics where DateDiff(dd,updatetime,getdate())=0 ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
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
        /// 根据时间查询数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetTimeList(string strWhere, string stime, string etime, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM  sc_statistics where add_time between '"+stime+"' and '"+etime+"' ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by " + orderby);
            }
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
			parameters[0].Value = "sc_statistics";
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

