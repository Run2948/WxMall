using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;
using Cms.Common;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:wx_dzpUsersTemp
	/// </summary>
	public partial class wx_dzpUsersTemp
	{
		public wx_dzpUsersTemp()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_dzpUsersTemp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_dzpUsersTemp");
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
		public int Add(Cms.Model.wx_dzpUsersTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_dzpUsersTemp(");
			strSql.Append("actId,openid,times,createDate)");
			strSql.Append(" values (");
			strSql.Append("@actId,@openid,@times,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@times", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.actId;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.times;
			parameters[3].Value = model.createDate;

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
		public bool Update(Cms.Model.wx_dzpUsersTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_dzpUsersTemp set ");
			strSql.Append("actId=@actId,");
			strSql.Append("openid=@openid,");
			strSql.Append("times=@times,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@times", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.actId;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.times;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.id;

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
			strSql.Append("delete from wx_dzpUsersTemp ");
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
			strSql.Append("delete from wx_dzpUsersTemp ");
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
		public Cms.Model.wx_dzpUsersTemp GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,actId,openid,times,createDate from wx_dzpUsersTemp ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_dzpUsersTemp model=new Cms.Model.wx_dzpUsersTemp();
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
		public Cms.Model.wx_dzpUsersTemp DataRowToModel(DataRow row)
		{
			Cms.Model.wx_dzpUsersTemp model=new Cms.Model.wx_dzpUsersTemp();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["actId"]!=null && row["actId"].ToString()!="")
				{
					model.actId=int.Parse(row["actId"].ToString());
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["times"]!=null && row["times"].ToString()!="")
				{
					model.times=int.Parse(row["times"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
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
			strSql.Append("select id,actId,openid,times,createDate ");
			strSql.Append(" FROM wx_dzpUsersTemp ");
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
			strSql.Append(" id,actId,openid,times,createDate ");
			strSql.Append(" FROM wx_dzpUsersTemp ");
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
			strSql.Append("select count(1) FROM wx_dzpUsersTemp ");
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
			strSql.Append(")AS Row, T.*  from wx_dzpUsersTemp T ");
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
			parameters[0].Value = "wx_dzpUsersTemp";
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

        /// <summary>
        /// 获取该openid已经使用了几次了
        /// </summary>
        public int getCJCiShu(int actId, string openid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 times FROM wx_dzpUsersTemp where actId=@actId and openid=@openid ");
            SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
                    new SqlParameter("@openid", SqlDbType.VarChar,100)
			};

            parameters[0].Value = actId;
            parameters[1].Value = openid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);

            string ret = "";
            while (sr.Read())
            {
                ret = sr["times"].ToString();
            }
            sr.Close();
            int times = MyCommFun.Str2Int(ret);
            return times;
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsOpenid(string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_dzpUsersTemp where " + whereStr);
            return DbHelperSQL.Exists(strSql.ToString());
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Cms.Model.wx_dzpUsersTemp getModelByAidOpenid(int actId, string openid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,actId,openid,times,createDate from wx_dzpUsersTemp ");
            strSql.Append(" where actId=@actId and openid=@openid");
            SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
                    new SqlParameter("@openid", SqlDbType.VarChar,100)
			};
            parameters[0].Value = actId;
            parameters[1].Value = openid;
            Cms.Model.wx_dzpUsersTemp model = new Cms.Model.wx_dzpUsersTemp();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }



        #endregion  ExtensionMethod
	}
}

