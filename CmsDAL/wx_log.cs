/**  版本信息模板在安装目录下，可自行修改。
* wx_log.cs
*
* 功 能： N/A
* 类 名： wx_log
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/26 17:07:35   N/A    初版
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
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:wx_log
	/// </summary>
	public partial class wx_log
	{
		public wx_log()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_log"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_log");
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
		public int Add(Cms.Model.wx_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_log(");
			strSql.Append("wid,modelName,remark,logsType,logsTypeName,createDate,logsContent,logsTitle,funName,createPerson,extInt,extStr,extStr2,extStr3,flg,flg2,flg3,flgInt,flgDate)");
			strSql.Append(" values (");
			strSql.Append("@wid,@modelName,@remark,@logsType,@logsTypeName,@createDate,@logsContent,@logsTitle,@funName,@createPerson,@extInt,@extStr,@extStr2,@extStr3,@flg,@flg2,@flg3,@flgInt,@flgDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@modelName", SqlDbType.VarChar,300),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@logsType", SqlDbType.Int,4),
					new SqlParameter("@logsTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@logsContent", SqlDbType.Text),
					new SqlParameter("@logsTitle", SqlDbType.VarChar,200),
					new SqlParameter("@funName", SqlDbType.VarChar,300),
					new SqlParameter("@createPerson", SqlDbType.VarChar,200),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@extStr3", SqlDbType.VarChar,1500),
					new SqlParameter("@flg", SqlDbType.VarChar,500),
					new SqlParameter("@flg2", SqlDbType.VarChar,1000),
					new SqlParameter("@flg3", SqlDbType.VarChar,1000),
					new SqlParameter("@flgInt", SqlDbType.Int,4),
					new SqlParameter("@flgDate", SqlDbType.DateTime)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.modelName;
			parameters[2].Value = model.remark;
			parameters[3].Value = model.logsType;
			parameters[4].Value = model.logsTypeName;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.logsContent;
			parameters[7].Value = model.logsTitle;
			parameters[8].Value = model.funName;
			parameters[9].Value = model.createPerson;
			parameters[10].Value = model.extInt;
			parameters[11].Value = model.extStr;
			parameters[12].Value = model.extStr2;
			parameters[13].Value = model.extStr3;
			parameters[14].Value = model.flg;
			parameters[15].Value = model.flg2;
			parameters[16].Value = model.flg3;
			parameters[17].Value = model.flgInt;
			parameters[18].Value = model.flgDate;

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
		public bool Update(Cms.Model.wx_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_log set ");
			strSql.Append("wid=@wid,");
			strSql.Append("modelName=@modelName,");
			strSql.Append("remark=@remark,");
			strSql.Append("logsType=@logsType,");
			strSql.Append("logsTypeName=@logsTypeName,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("logsContent=@logsContent,");
			strSql.Append("logsTitle=@logsTitle,");
			strSql.Append("funName=@funName,");
			strSql.Append("createPerson=@createPerson,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2,");
			strSql.Append("extStr3=@extStr3,");
			strSql.Append("flg=@flg,");
			strSql.Append("flg2=@flg2,");
			strSql.Append("flg3=@flg3,");
			strSql.Append("flgInt=@flgInt,");
			strSql.Append("flgDate=@flgDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@modelName", SqlDbType.VarChar,300),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@logsType", SqlDbType.Int,4),
					new SqlParameter("@logsTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@logsContent", SqlDbType.Text),
					new SqlParameter("@logsTitle", SqlDbType.VarChar,200),
					new SqlParameter("@funName", SqlDbType.VarChar,300),
					new SqlParameter("@createPerson", SqlDbType.VarChar,200),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@extStr3", SqlDbType.VarChar,1500),
					new SqlParameter("@flg", SqlDbType.VarChar,500),
					new SqlParameter("@flg2", SqlDbType.VarChar,1000),
					new SqlParameter("@flg3", SqlDbType.VarChar,1000),
					new SqlParameter("@flgInt", SqlDbType.Int,4),
					new SqlParameter("@flgDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.modelName;
			parameters[2].Value = model.remark;
			parameters[3].Value = model.logsType;
			parameters[4].Value = model.logsTypeName;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.logsContent;
			parameters[7].Value = model.logsTitle;
			parameters[8].Value = model.funName;
			parameters[9].Value = model.createPerson;
			parameters[10].Value = model.extInt;
			parameters[11].Value = model.extStr;
			parameters[12].Value = model.extStr2;
			parameters[13].Value = model.extStr3;
			parameters[14].Value = model.flg;
			parameters[15].Value = model.flg2;
			parameters[16].Value = model.flg3;
			parameters[17].Value = model.flgInt;
			parameters[18].Value = model.flgDate;
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
			strSql.Append("delete from wx_log ");
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
			strSql.Append("delete from wx_log ");
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
		public Cms.Model.wx_log GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,modelName,remark,logsType,logsTypeName,createDate,logsContent,logsTitle,funName,createPerson,extInt,extStr,extStr2,extStr3,flg,flg2,flg3,flgInt,flgDate from wx_log ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_log model=new Cms.Model.wx_log();
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
		public Cms.Model.wx_log DataRowToModel(DataRow row)
		{
			Cms.Model.wx_log model=new Cms.Model.wx_log();
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
				if(row["modelName"]!=null)
				{
					model.modelName=row["modelName"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["logsType"]!=null && row["logsType"].ToString()!="")
				{
					model.logsType=int.Parse(row["logsType"].ToString());
				}
				if(row["logsTypeName"]!=null)
				{
					model.logsTypeName=row["logsTypeName"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["logsContent"]!=null)
				{
					model.logsContent=row["logsContent"].ToString();
				}
				if(row["logsTitle"]!=null)
				{
					model.logsTitle=row["logsTitle"].ToString();
				}
				if(row["funName"]!=null)
				{
					model.funName=row["funName"].ToString();
				}
				if(row["createPerson"]!=null)
				{
					model.createPerson=row["createPerson"].ToString();
				}
				if(row["extInt"]!=null && row["extInt"].ToString()!="")
				{
					model.extInt=int.Parse(row["extInt"].ToString());
				}
				if(row["extStr"]!=null)
				{
					model.extStr=row["extStr"].ToString();
				}
				if(row["extStr2"]!=null)
				{
					model.extStr2=row["extStr2"].ToString();
				}
				if(row["extStr3"]!=null)
				{
					model.extStr3=row["extStr3"].ToString();
				}
				if(row["flg"]!=null)
				{
					model.flg=row["flg"].ToString();
				}
				if(row["flg2"]!=null)
				{
					model.flg2=row["flg2"].ToString();
				}
				if(row["flg3"]!=null)
				{
					model.flg3=row["flg3"].ToString();
				}
				if(row["flgInt"]!=null && row["flgInt"].ToString()!="")
				{
					model.flgInt=int.Parse(row["flgInt"].ToString());
				}
				if(row["flgDate"]!=null && row["flgDate"].ToString()!="")
				{
					model.flgDate=DateTime.Parse(row["flgDate"].ToString());
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
			strSql.Append("select id,wid,modelName,remark,logsType,logsTypeName,createDate,logsContent,logsTitle,funName,createPerson,extInt,extStr,extStr2,extStr3,flg,flg2,flg3,flgInt,flgDate ");
			strSql.Append(" FROM wx_log ");
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
			strSql.Append(" id,wid,modelName,remark,logsType,logsTypeName,createDate,logsContent,logsTitle,funName,createPerson,extInt,extStr,extStr2,extStr3,flg,flg2,flg3,flgInt,flgDate ");
			strSql.Append(" FROM wx_log ");
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
			strSql.Append("select count(1) FROM wx_log ");
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
			strSql.Append(")AS Row, T.*  from wx_log T ");
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
			parameters[0].Value = "wx_log";
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

