using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:wx_dzpAwardItem
	/// </summary>
	public partial class wx_dzpAwardItem
	{
		public wx_dzpAwardItem()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_dzpAwardItem"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_dzpAwardItem");
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
		public int Add(Cms.Model.wx_dzpAwardItem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_dzpAwardItem(");
			strSql.Append("actId,jxName,jpName,jpNum,jpRealNum,sort_id,createDate,jiaodu_min,jiaodu_max)");
			strSql.Append(" values (");
			strSql.Append("@actId,@jxName,@jpName,@jpNum,@jpRealNum,@sort_id,@createDate,@jiaodu_min,@jiaodu_max)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
					new SqlParameter("@jxName", SqlDbType.VarChar,50),
					new SqlParameter("@jpName", SqlDbType.VarChar,200),
					new SqlParameter("@jpNum", SqlDbType.Int,4),
					new SqlParameter("@jpRealNum", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@jiaodu_min", SqlDbType.Decimal,5),
					new SqlParameter("@jiaodu_max", SqlDbType.Decimal,5)};
			parameters[0].Value = model.actId;
			parameters[1].Value = model.jxName;
			parameters[2].Value = model.jpName;
			parameters[3].Value = model.jpNum;
			parameters[4].Value = model.jpRealNum;
			parameters[5].Value = model.sort_id;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.jiaodu_min;
			parameters[8].Value = model.jiaodu_max;

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
		public bool Update(Cms.Model.wx_dzpAwardItem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_dzpAwardItem set ");
			strSql.Append("actId=@actId,");
			strSql.Append("jxName=@jxName,");
			strSql.Append("jpName=@jpName,");
			strSql.Append("jpNum=@jpNum,");
			strSql.Append("jpRealNum=@jpRealNum,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("jiaodu_min=@jiaodu_min,");
			strSql.Append("jiaodu_max=@jiaodu_max");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4),
					new SqlParameter("@jxName", SqlDbType.VarChar,50),
					new SqlParameter("@jpName", SqlDbType.VarChar,200),
					new SqlParameter("@jpNum", SqlDbType.Int,4),
					new SqlParameter("@jpRealNum", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@jiaodu_min", SqlDbType.Decimal,5),
					new SqlParameter("@jiaodu_max", SqlDbType.Decimal,5),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.actId;
			parameters[1].Value = model.jxName;
			parameters[2].Value = model.jpName;
			parameters[3].Value = model.jpNum;
			parameters[4].Value = model.jpRealNum;
			parameters[5].Value = model.sort_id;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.jiaodu_min;
			parameters[8].Value = model.jiaodu_max;
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
			strSql.Append("delete from wx_dzpAwardItem ");
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
			strSql.Append("delete from wx_dzpAwardItem ");
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
		public Cms.Model.wx_dzpAwardItem GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,actId,jxName,jpName,jpNum,jpRealNum,sort_id,createDate,jiaodu_min,jiaodu_max from wx_dzpAwardItem ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_dzpAwardItem model=new Cms.Model.wx_dzpAwardItem();
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
		public Cms.Model.wx_dzpAwardItem DataRowToModel(DataRow row)
		{
			Cms.Model.wx_dzpAwardItem model=new Cms.Model.wx_dzpAwardItem();
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
				if(row["jxName"]!=null)
				{
					model.jxName=row["jxName"].ToString();
				}
				if(row["jpName"]!=null)
				{
					model.jpName=row["jpName"].ToString();
				}
				if(row["jpNum"]!=null && row["jpNum"].ToString()!="")
				{
					model.jpNum=int.Parse(row["jpNum"].ToString());
				}
				if(row["jpRealNum"]!=null && row["jpRealNum"].ToString()!="")
				{
					model.jpRealNum=int.Parse(row["jpRealNum"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
                if (row["jiaodu_min"] != null && row["jiaodu_min"].ToString() != "")
                {
                    model.jiaodu_min = decimal.Parse(row["jiaodu_min"].ToString());
                }
                if (row["jiaodu_max"] != null && row["jiaodu_max"].ToString() != "")
                {
                    model.jiaodu_max = decimal.Parse(row["jiaodu_max"].ToString());
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
			strSql.Append("select id,actId,jxName,jpName,jpNum,jpRealNum,sort_id,createDate,jiaodu_min,jiaodu_max ");
			strSql.Append(" FROM wx_dzpAwardItem ");
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
			strSql.Append(" id,actId,jxName,jpName,jpNum,jpRealNum,sort_id,createDate,jiaodu_min,jiaodu_max ");
			strSql.Append(" FROM wx_dzpAwardItem ");
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
			strSql.Append("select count(1) FROM wx_dzpAwardItem ");
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
			strSql.Append(")AS Row, T.*  from wx_dzpAwardItem T ");
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
			parameters[0].Value = "wx_dzpAwardItem";
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
        /// 删除刮刮卡活动的奖项信息
        /// </summary>
        public bool DeleteByActId(int actId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_dzpAwardItem ");
            strSql.Append(" where actId=@actId");
            SqlParameter[] parameters = {
					new SqlParameter("@actId", SqlDbType.Int,4)
			};
            parameters[0].Value = actId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion  ExtensionMethod
	}
}

