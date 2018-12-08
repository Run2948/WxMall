/**  版本信息模板在安装目录下，可自行修改。
* sc_Coupon.cs
*
* 功 能： N/A
* 类 名： sc_Coupon
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/10 16:37:53   N/A    初版
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
	/// 数据访问类:sc_Coupon
	/// </summary>
	public partial class sc_Coupon
	{
		public sc_Coupon()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "sc_Coupon"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sc_Coupon");
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
		public int Add(Cms.Model.sc_Coupon model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sc_Coupon(");
			strSql.Append("type_id,article_id,peson,cname,picurl,cmoney,stime,etime,number,content,updatetime)");
			strSql.Append(" values (");
			strSql.Append("@type_id,@article_id,@peson,@cname,@picurl,@cmoney,@stime,@etime,@number,@content,@updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@type_id", SqlDbType.Int,4),
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@peson", SqlDbType.Int,4),
					new SqlParameter("@cname", SqlDbType.NVarChar,100),
					new SqlParameter("@picurl", SqlDbType.NVarChar,100),
					new SqlParameter("@cmoney", SqlDbType.Int,4),
					new SqlParameter("@stime", SqlDbType.DateTime),
					new SqlParameter("@etime", SqlDbType.DateTime),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.type_id;
			parameters[1].Value = model.article_id;
			parameters[2].Value = model.peson;
			parameters[3].Value = model.cname;
			parameters[4].Value = model.picurl;
			parameters[5].Value = model.cmoney;
			parameters[6].Value = model.stime;
			parameters[7].Value = model.etime;
			parameters[8].Value = model.number;
			parameters[9].Value = model.content;
			parameters[10].Value = model.updatetime;

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
		public bool Update(Cms.Model.sc_Coupon model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sc_Coupon set ");
			strSql.Append("type_id=@type_id,");
			strSql.Append("article_id=@article_id,");
			strSql.Append("peson=@peson,");
			strSql.Append("cname=@cname,");
			strSql.Append("picurl=@picurl,");
			strSql.Append("cmoney=@cmoney,");
			strSql.Append("stime=@stime,");
			strSql.Append("etime=@etime,");
			strSql.Append("number=@number,");
			strSql.Append("content=@content,");
			strSql.Append("updatetime=@updatetime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@type_id", SqlDbType.Int,4),
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@peson", SqlDbType.Int,4),
					new SqlParameter("@cname", SqlDbType.NVarChar,100),
					new SqlParameter("@picurl", SqlDbType.NVarChar,100),
					new SqlParameter("@cmoney", SqlDbType.Int,4),
					new SqlParameter("@stime", SqlDbType.DateTime),
					new SqlParameter("@etime", SqlDbType.DateTime),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.type_id;
			parameters[1].Value = model.article_id;
			parameters[2].Value = model.peson;
			parameters[3].Value = model.cname;
			parameters[4].Value = model.picurl;
			parameters[5].Value = model.cmoney;
			parameters[6].Value = model.stime;
			parameters[7].Value = model.etime;
			parameters[8].Value = model.number;
			parameters[9].Value = model.content;
			parameters[10].Value = model.updatetime;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from sc_Coupon ");
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
			strSql.Append("delete from sc_Coupon ");
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
		public Cms.Model.sc_Coupon GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,type_id,article_id,peson,cname,picurl,cmoney,stime,etime,number,content,updatetime from sc_Coupon ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.sc_Coupon model=new Cms.Model.sc_Coupon();
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
		public Cms.Model.sc_Coupon DataRowToModel(DataRow row)
		{
			Cms.Model.sc_Coupon model=new Cms.Model.sc_Coupon();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["type_id"]!=null && row["type_id"].ToString()!="")
				{
					model.type_id=int.Parse(row["type_id"].ToString());
				}
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["peson"]!=null && row["peson"].ToString()!="")
				{
					model.peson=int.Parse(row["peson"].ToString());
				}
				if(row["cname"]!=null)
				{
					model.cname=row["cname"].ToString();
				}
				if(row["picurl"]!=null)
				{
					model.picurl=row["picurl"].ToString();
				}
				if(row["cmoney"]!=null && row["cmoney"].ToString()!="")
				{
					model.cmoney=int.Parse(row["cmoney"].ToString());
				}
				if(row["stime"]!=null && row["stime"].ToString()!="")
				{
					model.stime=DateTime.Parse(row["stime"].ToString());
				}
				if(row["etime"]!=null && row["etime"].ToString()!="")
				{
					model.etime=DateTime.Parse(row["etime"].ToString());
				}
				if(row["number"]!=null && row["number"].ToString()!="")
				{
					model.number=int.Parse(row["number"].ToString());
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
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
			strSql.Append("select id,type_id,article_id,peson,cname,picurl,cmoney,stime,etime,number,content,updatetime ");
			strSql.Append(" FROM sc_Coupon ");
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
			strSql.Append(" id,type_id,article_id,peson,cname,picurl,cmoney,stime,etime,number,content,updatetime ");
			strSql.Append(" FROM sc_Coupon ");
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
			strSql.Append("select count(1) FROM sc_Coupon ");
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
			strSql.Append(")AS Row, T.*  from sc_Coupon T ");
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
			parameters[0].Value = "sc_Coupon";
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

