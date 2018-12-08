using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;
using Cms.Common;
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:wx_dzpActionInfo
	/// </summary>
	public partial class wx_dzpActionInfo
	{
		public wx_dzpActionInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_dzpActionInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_dzpActionInfo");
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
		public int Add(Cms.Model.wx_dzpActionInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_dzpActionInfo(");
			strSql.Append("wid,actName,beginDate,endDate,brief,contractInfo,actContent,cfcjhf,endNotice,endContent,personNum,personMaxTimes,dayMaxTimes,openXyj,createDate,beginPic,endPic,aStatus,djPwd)");
			strSql.Append(" values (");
			strSql.Append("@wid,@actName,@beginDate,@endDate,@brief,@contractInfo,@actContent,@cfcjhf,@endNotice,@endContent,@personNum,@personMaxTimes,@dayMaxTimes,@openXyj,@createDate,@beginPic,@endPic,@aStatus,@djPwd)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@actName", SqlDbType.VarChar,100),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@brief", SqlDbType.VarChar,500),
					new SqlParameter("@contractInfo", SqlDbType.VarChar,200),
					new SqlParameter("@actContent", SqlDbType.VarChar,1000),
					new SqlParameter("@cfcjhf", SqlDbType.VarChar,100),
					new SqlParameter("@endNotice", SqlDbType.VarChar,200),
					new SqlParameter("@endContent", SqlDbType.VarChar,500),
					new SqlParameter("@personNum", SqlDbType.Int,4),
					new SqlParameter("@personMaxTimes", SqlDbType.Int,4),
					new SqlParameter("@dayMaxTimes", SqlDbType.Int,4),
					new SqlParameter("@openXyj", SqlDbType.VarChar,4000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@beginPic", SqlDbType.VarChar,500),
					new SqlParameter("@endPic", SqlDbType.VarChar,500),
					new SqlParameter("@aStatus", SqlDbType.Int,4),
					new SqlParameter("@djPwd", SqlDbType.VarChar,50)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.actName;
			parameters[2].Value = model.beginDate;
			parameters[3].Value = model.endDate;
			parameters[4].Value = model.brief;
			parameters[5].Value = model.contractInfo;
			parameters[6].Value = model.actContent;
			parameters[7].Value = model.cfcjhf;
			parameters[8].Value = model.endNotice;
			parameters[9].Value = model.endContent;
			parameters[10].Value = model.personNum;
			parameters[11].Value = model.personMaxTimes;
			parameters[12].Value = model.dayMaxTimes;
			parameters[13].Value = model.openXyj;
			parameters[14].Value = model.createDate;
			parameters[15].Value = model.beginPic;
			parameters[16].Value = model.endPic;
			parameters[17].Value = model.aStatus;
			parameters[18].Value = model.djPwd;

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
		public bool Update(Cms.Model.wx_dzpActionInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_dzpActionInfo set ");
			strSql.Append("wid=@wid,");
			strSql.Append("actName=@actName,");
			strSql.Append("beginDate=@beginDate,");
			strSql.Append("endDate=@endDate,");
			strSql.Append("brief=@brief,");
			strSql.Append("contractInfo=@contractInfo,");
			strSql.Append("actContent=@actContent,");
			strSql.Append("cfcjhf=@cfcjhf,");
			strSql.Append("endNotice=@endNotice,");
			strSql.Append("endContent=@endContent,");
			strSql.Append("personNum=@personNum,");
			strSql.Append("personMaxTimes=@personMaxTimes,");
			strSql.Append("dayMaxTimes=@dayMaxTimes,");
			strSql.Append("openXyj=@openXyj,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("beginPic=@beginPic,");
			strSql.Append("endPic=@endPic,");
			strSql.Append("aStatus=@aStatus,");
			strSql.Append("djPwd=@djPwd");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@actName", SqlDbType.VarChar,100),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@brief", SqlDbType.VarChar,500),
					new SqlParameter("@contractInfo", SqlDbType.VarChar,200),
					new SqlParameter("@actContent", SqlDbType.VarChar,1000),
					new SqlParameter("@cfcjhf", SqlDbType.VarChar,100),
					new SqlParameter("@endNotice", SqlDbType.VarChar,200),
					new SqlParameter("@endContent", SqlDbType.VarChar,500),
					new SqlParameter("@personNum", SqlDbType.Int,4),
					new SqlParameter("@personMaxTimes", SqlDbType.Int,4),
					new SqlParameter("@dayMaxTimes", SqlDbType.Int,4),
					new SqlParameter("@openXyj", SqlDbType.VarChar,4000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@beginPic", SqlDbType.VarChar,500),
					new SqlParameter("@endPic", SqlDbType.VarChar,500),
					new SqlParameter("@aStatus", SqlDbType.Int,4),
					new SqlParameter("@djPwd", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.actName;
			parameters[2].Value = model.beginDate;
			parameters[3].Value = model.endDate;
			parameters[4].Value = model.brief;
			parameters[5].Value = model.contractInfo;
			parameters[6].Value = model.actContent;
			parameters[7].Value = model.cfcjhf;
			parameters[8].Value = model.endNotice;
			parameters[9].Value = model.endContent;
			parameters[10].Value = model.personNum;
			parameters[11].Value = model.personMaxTimes;
			parameters[12].Value = model.dayMaxTimes;
			parameters[13].Value = model.openXyj;
			parameters[14].Value = model.createDate;
			parameters[15].Value = model.beginPic;
			parameters[16].Value = model.endPic;
			parameters[17].Value = model.aStatus;
			parameters[18].Value = model.djPwd;
			parameters[19].Value = model.id;

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
			strSql.Append("delete from wx_dzpActionInfo ");
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
			strSql.Append("delete from wx_dzpActionInfo ");
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
		public Cms.Model.wx_dzpActionInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,actName,beginDate,endDate,brief,contractInfo,actContent,cfcjhf,endNotice,endContent,personNum,personMaxTimes,dayMaxTimes,openXyj,createDate,beginPic,endPic,aStatus,djPwd from wx_dzpActionInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_dzpActionInfo model=new Cms.Model.wx_dzpActionInfo();
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
		public Cms.Model.wx_dzpActionInfo DataRowToModel(DataRow row)
		{
			Cms.Model.wx_dzpActionInfo model=new Cms.Model.wx_dzpActionInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["actName"]!=null)
				{
					model.actName=row["actName"].ToString();
				}
				if(row["beginDate"]!=null && row["beginDate"].ToString()!="")
				{
					model.beginDate=DateTime.Parse(row["beginDate"].ToString());
				}
				if(row["endDate"]!=null && row["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(row["endDate"].ToString());
				}
				if(row["brief"]!=null)
				{
					model.brief=row["brief"].ToString();
				}
				if(row["contractInfo"]!=null)
				{
					model.contractInfo=row["contractInfo"].ToString();
				}
				if(row["actContent"]!=null)
				{
					model.actContent=row["actContent"].ToString();
				}
				if(row["cfcjhf"]!=null)
				{
					model.cfcjhf=row["cfcjhf"].ToString();
				}
				if(row["endNotice"]!=null)
				{
					model.endNotice=row["endNotice"].ToString();
				}
				if(row["endContent"]!=null)
				{
					model.endContent=row["endContent"].ToString();
				}
				if(row["personNum"]!=null && row["personNum"].ToString()!="")
				{
					model.personNum=int.Parse(row["personNum"].ToString());
				}
				if(row["personMaxTimes"]!=null && row["personMaxTimes"].ToString()!="")
				{
					model.personMaxTimes=int.Parse(row["personMaxTimes"].ToString());
				}
				if(row["dayMaxTimes"]!=null && row["dayMaxTimes"].ToString()!="")
				{
					model.dayMaxTimes=int.Parse(row["dayMaxTimes"].ToString());
				}
				if(row["openXyj"]!=null)
				{
					model.openXyj=row["openXyj"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["beginPic"]!=null)
				{
					model.beginPic=row["beginPic"].ToString();
				}
				if(row["endPic"]!=null)
				{
					model.endPic=row["endPic"].ToString();
				}
				if(row["aStatus"]!=null && row["aStatus"].ToString()!="")
				{
					model.aStatus=int.Parse(row["aStatus"].ToString());
				}
				if(row["djPwd"]!=null)
				{
					model.djPwd=row["djPwd"].ToString();
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
			strSql.Append("select id,wid,actName,beginDate,endDate,brief,contractInfo,actContent,cfcjhf,endNotice,endContent,personNum,personMaxTimes,dayMaxTimes,openXyj,createDate,beginPic,endPic,aStatus,djPwd ");
			strSql.Append(" FROM wx_dzpActionInfo ");
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
			strSql.Append(" id,wid,actName,beginDate,endDate,brief,contractInfo,actContent,cfcjhf,endNotice,endContent,personNum,personMaxTimes,dayMaxTimes,openXyj,createDate,beginPic,endPic,aStatus,djPwd ");
			strSql.Append(" FROM wx_dzpActionInfo ");
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
			strSql.Append("select count(1) FROM wx_dzpActionInfo ");
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
			strSql.Append(")AS Row, T.*  from wx_dzpActionInfo T ");
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
			parameters[0].Value = "wx_dzpActionInfo";
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
        /// 兑换密码是否正确
        /// </summary>
        public bool ExistsPwd(int id, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_dzpActionInfo");
            strSql.Append(" where id=@id and djPwd=@djPwd");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@djPwd", SqlDbType.VarChar,50)
			};
            parameters[0].Value = id;
            parameters[1].Value = pwd;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,'' as status_s,'' as url,(select reqkeywords from wx_requestRule where modelfunctionName='大转盘' and modelFunctionId=a.id) as kw  from wx_dzpActionInfo a ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 删除一条大转盘活动数据[活动主表，回复的关键词记录，对应的奖品列表，获奖用户信息表，用户临时表]
        /// </summary>
        public bool DeleteAction(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_requestRule where modelFunctionName='大转盘' and modelFunctionId=" + id + " ; ");
            strSql.Append("delete from wx_dzpActionInfo where id=" + id + " ; ");
            strSql.Append(" delete from wx_dzpAwardItem where actId=" + id + ";");
            strSql.Append(" delete from wx_dzpAwardUser where actId=" + id + ";");
            strSql.Append(" delete from wx_dzpUsersTemp where actId=" + id + ";");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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

