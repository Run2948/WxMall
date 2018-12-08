using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:wx_userinfo
	/// </summary>
	public partial class wx_userinfo
	{
		public wx_userinfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_userinfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_userinfo");
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
		public int Add(Cms.Model.wx_userinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_userinfo(");
			strSql.Append("subscribe,openid,nickname,sex,language,city,province,country,headimgurl,subscribe_time,remark,updatetime)");
			strSql.Append(" values (");
			strSql.Append("@subscribe,@openid,@nickname,@sex,@language,@city,@province,@country,@headimgurl,@subscribe_time,@remark,@updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@subscribe", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.NVarChar,50),
					new SqlParameter("@nickname", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@language", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,50),
					new SqlParameter("@province", SqlDbType.NVarChar,50),
					new SqlParameter("@country", SqlDbType.NVarChar,50),
					new SqlParameter("@headimgurl", SqlDbType.Text),
					new SqlParameter("@subscribe_time", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,50),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.subscribe;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.nickname;
			parameters[3].Value = model.sex;
			parameters[4].Value = model.language;
			parameters[5].Value = model.city;
			parameters[6].Value = model.province;
			parameters[7].Value = model.country;
			parameters[8].Value = model.headimgurl;
			parameters[9].Value = model.subscribe_time;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.updatetime;

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
		public bool Update(Cms.Model.wx_userinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_userinfo set ");
			strSql.Append("subscribe=@subscribe,");
			strSql.Append("openid=@openid,");
			strSql.Append("nickname=@nickname,");
			strSql.Append("sex=@sex,");
			strSql.Append("language=@language,");
			strSql.Append("city=@city,");
			strSql.Append("province=@province,");
			strSql.Append("country=@country,");
			strSql.Append("headimgurl=@headimgurl,");
			strSql.Append("subscribe_time=@subscribe_time,");
			strSql.Append("remark=@remark,");
			strSql.Append("updatetime=@updatetime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@subscribe", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.NVarChar,50),
					new SqlParameter("@nickname", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@language", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,50),
					new SqlParameter("@province", SqlDbType.NVarChar,50),
					new SqlParameter("@country", SqlDbType.NVarChar,50),
					new SqlParameter("@headimgurl", SqlDbType.Text),
					new SqlParameter("@subscribe_time", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,50),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.subscribe;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.nickname;
			parameters[3].Value = model.sex;
			parameters[4].Value = model.language;
			parameters[5].Value = model.city;
			parameters[6].Value = model.province;
			parameters[7].Value = model.country;
			parameters[8].Value = model.headimgurl;
			parameters[9].Value = model.subscribe_time;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.updatetime;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from wx_userinfo ");
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
			strSql.Append("delete from wx_userinfo ");
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
		public Cms.Model.wx_userinfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,subscribe,openid,nickname,sex,language,city,province,country,headimgurl,subscribe_time,remark,updatetime from wx_userinfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_userinfo model=new Cms.Model.wx_userinfo();
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
		public Cms.Model.wx_userinfo DataRowToModel(DataRow row)
		{
			Cms.Model.wx_userinfo model=new Cms.Model.wx_userinfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["subscribe"]!=null && row["subscribe"].ToString()!="")
				{
					model.subscribe=int.Parse(row["subscribe"].ToString());
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["nickname"]!=null)
				{
					model.nickname=row["nickname"].ToString();
				}
				if(row["sex"]!=null && row["sex"].ToString()!="")
				{
					model.sex=int.Parse(row["sex"].ToString());
				}
				if(row["language"]!=null)
				{
					model.language=row["language"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["province"]!=null)
				{
					model.province=row["province"].ToString();
				}
				if(row["country"]!=null)
				{
					model.country=row["country"].ToString();
				}
				if(row["headimgurl"]!=null)
				{
					model.headimgurl=row["headimgurl"].ToString();
				}
				if(row["subscribe_time"]!=null)
				{
					model.subscribe_time=row["subscribe_time"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,subscribe,openid,nickname,sex,language,city,province,country,headimgurl,subscribe_time,remark,updatetime ");
			strSql.Append(" FROM wx_userinfo ");
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
			strSql.Append(" id,subscribe,openid,nickname,sex,language,city,province,country,headimgurl,subscribe_time,remark,updatetime ");
			strSql.Append(" FROM wx_userinfo ");
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
			strSql.Append("select count(1) FROM wx_userinfo ");
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
			strSql.Append(")AS Row, T.*  from wx_userinfo T ");
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
			parameters[0].Value = "wx_userinfo";
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

