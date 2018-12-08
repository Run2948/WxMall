using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;
using Cms.Common;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:wx_dzpAwardUser
	/// </summary>
	public partial class wx_dzpAwardUser
	{
		public wx_dzpAwardUser()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_dzpAwardUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_dzpAwardUser");
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
		public int Add(Cms.Model.wx_dzpAwardUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_dzpAwardUser(");
			strSql.Append("actId,uName,uTel,openid,jxName,jxIndex,jpName,createDate,hasLingQu,sn)");
			strSql.Append(" values (");
			strSql.Append("@actId,@uName,@uTel,@openid,@jxName,@jxIndex,@jpName,@createDate,@hasLingQu,@sn)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
					new SqlParameter("@uName", SqlDbType.VarChar,50),
					new SqlParameter("@uTel", SqlDbType.VarChar,500),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@jxName", SqlDbType.VarChar,50),
					new SqlParameter("@jxIndex", SqlDbType.VarChar,4000),
					new SqlParameter("@jpName", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@hasLingQu", SqlDbType.Bit,1),
					new SqlParameter("@sn", SqlDbType.VarChar,100)};
			parameters[0].Value = model.actId;
			parameters[1].Value = model.uName;
			parameters[2].Value = model.uTel;
			parameters[3].Value = model.openid;
			parameters[4].Value = model.jxName;
			parameters[5].Value = model.jxIndex;
			parameters[6].Value = model.jpName;
			parameters[7].Value = model.createDate;
			parameters[8].Value = model.hasLingQu;
			parameters[9].Value = model.sn;

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
		public bool Update(Cms.Model.wx_dzpAwardUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_dzpAwardUser set ");
			strSql.Append("actId=@actId,");
			strSql.Append("uName=@uName,");
			strSql.Append("uTel=@uTel,");
			strSql.Append("openid=@openid,");
			strSql.Append("jxName=@jxName,");
			strSql.Append("jxIndex=@jxIndex,");
			strSql.Append("jpName=@jpName,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("hasLingQu=@hasLingQu,");
			strSql.Append("sn=@sn");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
					new SqlParameter("@uName", SqlDbType.VarChar,50),
					new SqlParameter("@uTel", SqlDbType.VarChar,500),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@jxName", SqlDbType.VarChar,50),
					new SqlParameter("@jxIndex", SqlDbType.VarChar,4000),
					new SqlParameter("@jpName", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@hasLingQu", SqlDbType.Bit,1),
					new SqlParameter("@sn", SqlDbType.VarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.actId;
			parameters[1].Value = model.uName;
			parameters[2].Value = model.uTel;
			parameters[3].Value = model.openid;
			parameters[4].Value = model.jxName;
			parameters[5].Value = model.jxIndex;
			parameters[6].Value = model.jpName;
			parameters[7].Value = model.createDate;
			parameters[8].Value = model.hasLingQu;
			parameters[9].Value = model.sn;
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
			strSql.Append("delete from wx_dzpAwardUser ");
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
			strSql.Append("delete from wx_dzpAwardUser ");
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
		public Cms.Model.wx_dzpAwardUser GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,actId,uName,uTel,openid,jxName,jxIndex,jpName,createDate,hasLingQu,sn from wx_dzpAwardUser ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_dzpAwardUser model=new Cms.Model.wx_dzpAwardUser();
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
		public Cms.Model.wx_dzpAwardUser DataRowToModel(DataRow row)
		{
			Cms.Model.wx_dzpAwardUser model=new Cms.Model.wx_dzpAwardUser();
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
				if(row["uName"]!=null)
				{
					model.uName=row["uName"].ToString();
				}
				if(row["uTel"]!=null)
				{
					model.uTel=row["uTel"].ToString();
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["jxName"]!=null)
				{
					model.jxName=row["jxName"].ToString();
				}
				if(row["jxIndex"]!=null)
				{
					model.jxIndex=row["jxIndex"].ToString();
				}
				if(row["jpName"]!=null)
				{
					model.jpName=row["jpName"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["hasLingQu"]!=null && row["hasLingQu"].ToString()!="")
				{
					if((row["hasLingQu"].ToString()=="1")||(row["hasLingQu"].ToString().ToLower()=="true"))
					{
						model.hasLingQu=true;
					}
					else
					{
						model.hasLingQu=false;
					}
				}
				if(row["sn"]!=null)
				{
					model.sn=row["sn"].ToString();
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
			strSql.Append("select id,actId,uName,uTel,openid,jxName,jxIndex,jpName,createDate,hasLingQu,sn ");
			strSql.Append(" FROM wx_dzpAwardUser ");
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
			strSql.Append(" id,actId,uName,uTel,openid,jxName,jxIndex,jpName,createDate,hasLingQu,sn ");
			strSql.Append(" FROM wx_dzpAwardUser ");
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
			strSql.Append("select count(1) FROM wx_dzpAwardUser ");
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
			strSql.Append(")AS Row, T.*  from wx_dzpAwardUser T ");
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
			parameters[0].Value = "wx_dzpAwardUser";
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  *   from wx_dzpAwardUser   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet getHasZJList(int actId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,actId,uName,uTel,openid,jxName,jpName,jxIndex,createDate,hasLingQu,sn ");
            strSql.Append(" FROM wx_dzpAwardUser where actId=@actId");

            SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4)
			};
            parameters[0].Value = actId;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 该用户的中奖信息
        /// </summary>
        public Cms.Model.wx_dzpAwardUser getZJinfoByOpenid(int actId, string openid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,actId,uName,uTel,openid,jxName,jxIndex,jpName,createDate,hasLingQu,sn from wx_dzpAwardUser ");
            strSql.Append(" where actId=@actId and openid=@openid");
            SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
                    new SqlParameter("@openid", SqlDbType.VarChar,100),
			};
            parameters[0].Value = actId;
            parameters[1].Value = openid;

            Cms.Model.wx_dzpAwardUser model = new Cms.Model.wx_dzpAwardUser();
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

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_dzpAwardUser set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        #endregion  ExtensionMethod

	}
}

