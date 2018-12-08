/**  版本信息模板在安装目录下，可自行修改。
* c_product_comment.cs
*
* 功 能： N/A
* 类 名： c_product_comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/4/30 22:26:05   N/A    初版
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
namespace Cms.DAL
{
	/// <summary>
	/// 数据访问类:c_product_comment
	/// </summary>
	public partial class c_product_comment
	{
		public c_product_comment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "c_product_comment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from c_product_comment");
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
		public int Add(Cms.Model.c_product_comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into c_product_comment(");
			strSql.Append("productId,parentId,userId,userName,userIp,content,is_lock,add_time,is_reply,reply_content,reply_time,descScore,logisticsScore,anonymous,litpic)");
			strSql.Append(" values (");
			strSql.Append("@productId,@parentId,@userId,@userName,@userIp,@content,@is_lock,@add_time,@is_reply,@reply_content,@reply_time,@descScore,@logisticsScore,@anonymous,@litpic)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@userName", SqlDbType.NVarChar,100),
					new SqlParameter("@userIp", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@is_reply", SqlDbType.TinyInt,1),
					new SqlParameter("@reply_content", SqlDbType.NText),
					new SqlParameter("@reply_time", SqlDbType.DateTime),
					new SqlParameter("@descScore", SqlDbType.Int,4),
					new SqlParameter("@logisticsScore", SqlDbType.Int,4),
					new SqlParameter("@anonymous", SqlDbType.Int,4),
					new SqlParameter("@litpic", SqlDbType.VarChar,-1)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.userId;
			parameters[3].Value = model.userName;
			parameters[4].Value = model.userIp;
			parameters[5].Value = model.content;
			parameters[6].Value = model.is_lock;
			parameters[7].Value = model.add_time;
			parameters[8].Value = model.is_reply;
			parameters[9].Value = model.reply_content;
			parameters[10].Value = model.reply_time;
			parameters[11].Value = model.descScore;
			parameters[12].Value = model.logisticsScore;
			parameters[13].Value = model.anonymous;
			parameters[14].Value = model.litpic;

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
		public bool Update(Cms.Model.c_product_comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update c_product_comment set ");
			strSql.Append("productId=@productId,");
			strSql.Append("parentId=@parentId,");
			strSql.Append("userId=@userId,");
			strSql.Append("userName=@userName,");
			strSql.Append("userIp=@userIp,");
			strSql.Append("content=@content,");
			strSql.Append("is_lock=@is_lock,");
			strSql.Append("add_time=@add_time,");
			strSql.Append("is_reply=@is_reply,");
			strSql.Append("reply_content=@reply_content,");
			strSql.Append("reply_time=@reply_time,");
			strSql.Append("descScore=@descScore,");
			strSql.Append("logisticsScore=@logisticsScore,");
			strSql.Append("anonymous=@anonymous,");
			strSql.Append("litpic=@litpic");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@userName", SqlDbType.NVarChar,100),
					new SqlParameter("@userIp", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@is_reply", SqlDbType.TinyInt,1),
					new SqlParameter("@reply_content", SqlDbType.NText),
					new SqlParameter("@reply_time", SqlDbType.DateTime),
					new SqlParameter("@descScore", SqlDbType.Int,4),
					new SqlParameter("@logisticsScore", SqlDbType.Int,4),
					new SqlParameter("@anonymous", SqlDbType.Int,4),
					new SqlParameter("@litpic", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.userId;
			parameters[3].Value = model.userName;
			parameters[4].Value = model.userIp;
			parameters[5].Value = model.content;
			parameters[6].Value = model.is_lock;
			parameters[7].Value = model.add_time;
			parameters[8].Value = model.is_reply;
			parameters[9].Value = model.reply_content;
			parameters[10].Value = model.reply_time;
			parameters[11].Value = model.descScore;
			parameters[12].Value = model.logisticsScore;
			parameters[13].Value = model.anonymous;
			parameters[14].Value = model.litpic;
			parameters[15].Value = model.id;

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
			strSql.Append("delete from c_product_comment ");
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
			strSql.Append("delete from c_product_comment ");
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
		public Cms.Model.c_product_comment GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,productId,parentId,userId,userName,userIp,content,is_lock,add_time,is_reply,reply_content,reply_time,descScore,logisticsScore,anonymous,litpic from c_product_comment ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.c_product_comment model=new Cms.Model.c_product_comment();
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
		public Cms.Model.c_product_comment DataRowToModel(DataRow row)
		{
			Cms.Model.c_product_comment model=new Cms.Model.c_product_comment();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["productId"]!=null && row["productId"].ToString()!="")
				{
					model.productId=int.Parse(row["productId"].ToString());
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
				}
				if(row["userId"]!=null && row["userId"].ToString()!="")
				{
					model.userId=int.Parse(row["userId"].ToString());
				}
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
				if(row["userIp"]!=null)
				{
					model.userIp=row["userIp"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["is_lock"]!=null && row["is_lock"].ToString()!="")
				{
					model.is_lock=int.Parse(row["is_lock"].ToString());
				}
				if(row["add_time"]!=null && row["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(row["add_time"].ToString());
				}
				if(row["is_reply"]!=null && row["is_reply"].ToString()!="")
				{
					model.is_reply=int.Parse(row["is_reply"].ToString());
				}
				if(row["reply_content"]!=null)
				{
					model.reply_content=row["reply_content"].ToString();
				}
				if(row["reply_time"]!=null && row["reply_time"].ToString()!="")
				{
					model.reply_time=DateTime.Parse(row["reply_time"].ToString());
				}
				if(row["descScore"]!=null && row["descScore"].ToString()!="")
				{
					model.descScore=int.Parse(row["descScore"].ToString());
				}
				if(row["logisticsScore"]!=null && row["logisticsScore"].ToString()!="")
				{
					model.logisticsScore=int.Parse(row["logisticsScore"].ToString());
				}
				if(row["anonymous"]!=null && row["anonymous"].ToString()!="")
				{
					model.anonymous=int.Parse(row["anonymous"].ToString());
				}
				if(row["litpic"]!=null)
				{
					model.litpic=row["litpic"].ToString();
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
			strSql.Append("select id,productId,parentId,userId,userName,userIp,content,is_lock,add_time,is_reply,reply_content,reply_time,descScore,logisticsScore,anonymous,litpic ");
			strSql.Append(" FROM c_product_comment ");
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
			strSql.Append(" id,productId,parentId,userId,userName,userIp,content,is_lock,add_time,is_reply,reply_content,reply_time,descScore,logisticsScore,anonymous,litpic ");
			strSql.Append(" FROM c_product_comment ");
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
			strSql.Append("select count(1) FROM c_product_comment ");
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
			strSql.Append(")AS Row, T.*  from c_product_comment T ");
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
			parameters[0].Value = "c_product_comment";
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

