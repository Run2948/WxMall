using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;
using System.Collections;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:XT_ChatLog
	/// </summary>
	public partial class XT_ChatLog
	{
		public XT_ChatLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Chatid", "XT_ChatLog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Chatid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from XT_ChatLog");
			strSql.Append(" where Chatid=@Chatid");
			SqlParameter[] parameters = {
					new SqlParameter("@Chatid", SqlDbType.Int,4)
			};
			parameters[0].Value = Chatid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.XT_ChatLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into XT_ChatLog(");
			strSql.Append("FromUserName,Worker,ToUserName,SendUserName,OperCode,Time,MsgContent,Remark,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@FromUserName,@Worker,@ToUserName,@SendUserName,@OperCode,@Time,@MsgContent,@Remark,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FromUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Worker", SqlDbType.NVarChar,100),
					new SqlParameter("@ToUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@SendUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@OperCode", SqlDbType.NVarChar,10),
					new SqlParameter("@Time", SqlDbType.NVarChar,100),
					new SqlParameter("@MsgContent", SqlDbType.Text),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime,3)};
			parameters[0].Value = model.FromUserName;
			parameters[1].Value = model.Worker;
			parameters[2].Value = model.ToUserName;
			parameters[3].Value = model.SendUserName;
			parameters[4].Value = model.OperCode;
			parameters[5].Value = model.Time;
			parameters[6].Value = model.MsgContent;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.CreateTime;

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
		public bool Update(Cms.Model.XT_ChatLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update XT_ChatLog set ");
			strSql.Append("FromUserName=@FromUserName,");
			strSql.Append("Worker=@Worker,");
			strSql.Append("ToUserName=@ToUserName,");
			strSql.Append("SendUserName=@SendUserName,");
			strSql.Append("OperCode=@OperCode,");
			strSql.Append("Time=@Time,");
			strSql.Append("MsgContent=@MsgContent,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where Chatid=@Chatid");
			SqlParameter[] parameters = {
					new SqlParameter("@FromUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Worker", SqlDbType.NVarChar,100),
					new SqlParameter("@ToUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@SendUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@OperCode", SqlDbType.NVarChar,10),
					new SqlParameter("@Time", SqlDbType.NVarChar,100),
					new SqlParameter("@MsgContent", SqlDbType.Text),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime,3),
					new SqlParameter("@Chatid", SqlDbType.Int,4)};
			parameters[0].Value = model.FromUserName;
			parameters[1].Value = model.Worker;
			parameters[2].Value = model.ToUserName;
			parameters[3].Value = model.SendUserName;
			parameters[4].Value = model.OperCode;
			parameters[5].Value = model.Time;
			parameters[6].Value = model.MsgContent;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.CreateTime;
			parameters[9].Value = model.Chatid;

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
		public bool Delete(int Chatid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from XT_ChatLog ");
			strSql.Append(" where Chatid=@Chatid");
			SqlParameter[] parameters = {
					new SqlParameter("@Chatid", SqlDbType.Int,4)
			};
			parameters[0].Value = Chatid;

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
		public bool DeleteList(string Chatidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from XT_ChatLog ");
			strSql.Append(" where Chatid in ("+Chatidlist + ")  ");
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
        /// 根据用户获取聊天记录
        /// </summary>
        /// <returns></returns>
        public Cms.Model.XT_ChatLog[] GetChatLogList(string FromUserName, string SendUserName)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = {
					new SqlParameter("@FromUserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@SendUserName", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = FromUserName;
            parameters[1].Value = SendUserName;
            SqlDataReader rd = DbHelperSQL.ExecuteReader("select chatid, FromUserName, worker, ToUserName,SendUserName,opercode, time, MsgContent, remark, createtime from  xt_chatlog where FromUserName=@FromUserName and (SendUserName=@SendUserName or SendUserName=@FromUserName) and ToUserName=@SendUserName  order by createtime asc", parameters);
           
           
            try
            {
                while (rd.Read())
                {
                    Cms.Model.XT_ChatLog cl = new Cms.Model.XT_ChatLog();
                    cl.SendUserName = rd["SendUserName"].ToString();
                    cl.ToUserName = rd["ToUserName"].ToString();
                    cl.MsgContent = rd["MsgContent"].ToString();
                    cl.CreateTime =Convert.ToDateTime(rd["createtime"]);
                    list.Add(cl);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                rd.Close();
                rd.Dispose();
            }

            return (Cms.Model.XT_ChatLog[])list.ToArray(typeof(Cms.Model.XT_ChatLog));
        }

        /// <summary>
        /// 获取48小时内联系过的用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public Cms.Model.XT_ChatLog[] GetUserList()
        {
            ArrayList list = new ArrayList();
            string username="";
            DataTable dt = DbHelperSQL.Query("select * from wx_info").Tables[0];
            if (dt.Rows.Count > 0)
            {
                username = dt.Rows[0]["wxid"].ToString();
            }
            SqlDataReader rd = DbHelperSQL.ExecuteReader("select distinct sendusername from xt_chatlog where  createtime > GETDATE() - 2 and  createtime < GETDATE() and sendusername!='"+username+"' ");
            try
            {
                while (rd.Read())
                {
                    Cms.Model.XT_ChatLog cl = new Cms.Model.XT_ChatLog();
                    cl.SendUserName = rd["sendusername"].ToString();
                    list.Add(cl);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                rd.Close();
                rd.Dispose();
            }

            return (Cms.Model.XT_ChatLog[])list.ToArray(typeof(Cms.Model.XT_ChatLog));

        }

        /// <summary>
        /// 获取未读消息
        /// </summary>
        /// <param name="FromUserName"></param>
        /// <param name="SendUserName"></param>
        /// <returns></returns>
        public int GetNotReadCount(string FromUserName, string SendUserName)
        {
           
            SqlParameter[] parameters = {
					new SqlParameter("@FromUserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@SendUserName", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = FromUserName;
            parameters[1].Value = SendUserName;
            object obj = DbHelperSQL.GetSingle("select count(1) from  xt_chatlog  where FromUserName=@FromUserName and (SendUserName=@SendUserName or SendUserName=@FromUserName) and ToUserName=@SendUserName and  worker=0", parameters);

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
        /// 修改已读记录
        /// </summary>
        /// <param name="FromUserName"></param>
        /// <param name="SendUserName"></param>
        /// <returns></returns>
        public bool UpdateMsgStatus(string FromUserName, string SendUserName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@FromUserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@SendUserName", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = FromUserName;
            parameters[1].Value = SendUserName;
            int doline = DbHelperSQL.ExecuteSql("update XT_ChatLog set worker=1 where FromUserName=@FromUserName and (SendUserName=@SendUserName or SendUserName=@FromUserName) and ToUserName=@SendUserName and  worker=0", parameters);
            if (doline > 0)
            {
                return true;
            }
            return false;
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.XT_ChatLog GetModel(int Chatid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Chatid,FromUserName,Worker,ToUserName,SendUserName,OperCode,Time,MsgContent,Remark,CreateTime from XT_ChatLog ");
			strSql.Append(" where Chatid=@Chatid");
			SqlParameter[] parameters = {
					new SqlParameter("@Chatid", SqlDbType.Int,4)
			};
			parameters[0].Value = Chatid;

			Cms.Model.XT_ChatLog model=new Cms.Model.XT_ChatLog();
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
		public Cms.Model.XT_ChatLog DataRowToModel(DataRow row)
		{
			Cms.Model.XT_ChatLog model=new Cms.Model.XT_ChatLog();
			if (row != null)
			{
				if(row["Chatid"]!=null && row["Chatid"].ToString()!="")
				{
					model.Chatid=int.Parse(row["Chatid"].ToString());
				}
				if(row["FromUserName"]!=null)
				{
					model.FromUserName=row["FromUserName"].ToString();
				}
				if(row["Worker"]!=null)
				{
					model.Worker=row["Worker"].ToString();
				}
				if(row["ToUserName"]!=null)
				{
					model.ToUserName=row["ToUserName"].ToString();
				}
				if(row["SendUserName"]!=null)
				{
					model.SendUserName=row["SendUserName"].ToString();
				}
				if(row["OperCode"]!=null)
				{
					model.OperCode=row["OperCode"].ToString();
				}
				if(row["Time"]!=null)
				{
					model.Time=row["Time"].ToString();
				}
				if(row["MsgContent"]!=null)
				{
					model.MsgContent=row["MsgContent"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select Chatid,FromUserName,Worker,ToUserName,SendUserName,OperCode,Time,MsgContent,Remark,CreateTime ");
			strSql.Append(" FROM XT_ChatLog ");
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
			strSql.Append(" Chatid,FromUserName,Worker,ToUserName,SendUserName,OperCode,Time,MsgContent,Remark,CreateTime ");
			strSql.Append(" FROM XT_ChatLog ");
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
			strSql.Append("select count(1) FROM XT_ChatLog ");
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
				strSql.Append("order by T.Chatid desc");
			}
			strSql.Append(")AS Row, T.*  from XT_ChatLog T ");
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
			parameters[0].Value = "XT_ChatLog";
			parameters[1].Value = "Chatid";
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

