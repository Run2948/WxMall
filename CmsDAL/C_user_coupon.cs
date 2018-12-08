/**  版本信息模板在安装目录下，可自行修改。
* C_user_coupon.cs
*
* 功 能： N/A
* 类 名： C_user_coupon
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/10 17:08:03   N/A    初版
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
	/// 数据访问类:C_user_coupon
	/// </summary>
	public partial class C_user_coupon
	{
		public C_user_coupon()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_user_coupon"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_user_coupon");
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
		public int Add(Cms.Model.C_user_coupon model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_user_coupon(");
            strSql.Append("user_id,article_id,coupon_id,type_id,title,picUrl,price,stime,etime,number,content,status,updatetime)");
			strSql.Append(" values (");
            strSql.Append("@user_id,@article_id,@coupon_id,@type_id,@title,@picUrl,@price,@stime,@etime,@number,@content,@status,@updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@coupon_id", SqlDbType.Int,4),
                    new SqlParameter("@type_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,350),
					new SqlParameter("@picUrl", SqlDbType.VarChar,350),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@stime", SqlDbType.DateTime),
					new SqlParameter("@etime", SqlDbType.DateTime),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.article_id;
			parameters[2].Value = model.coupon_id;
            parameters[3].Value = model.type_id;
			parameters[4].Value = model.title;
			parameters[5].Value = model.picUrl;
			parameters[6].Value = model.price;
			parameters[7].Value = model.stime;
			parameters[8].Value = model.etime;
			parameters[9].Value = model.number;
			parameters[10].Value = model.content;
			parameters[11].Value = model.status;
			parameters[12].Value = model.updatetime;

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
		public bool Update(Cms.Model.C_user_coupon model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_user_coupon set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("article_id=@article_id,");
			strSql.Append("coupon_id=@coupon_id,");
            strSql.Append("type_id=@type_id,");
			strSql.Append("title=@title,");
			strSql.Append("picUrl=@picUrl,");
			strSql.Append("price=@price,");
			strSql.Append("stime=@stime,");
			strSql.Append("etime=@etime,");
			strSql.Append("number=@number,");
			strSql.Append("content=@content,");
			strSql.Append("status=@status,");
			strSql.Append("updatetime=@updatetime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@coupon_id", SqlDbType.Int,4),
                    new SqlParameter("@type_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,350),
					new SqlParameter("@picUrl", SqlDbType.VarChar,350),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@stime", SqlDbType.DateTime),
					new SqlParameter("@etime", SqlDbType.DateTime),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.article_id;
			parameters[2].Value = model.coupon_id;
            parameters[3].Value = model.type_id;
			parameters[4].Value = model.title;
			parameters[5].Value = model.picUrl;
			parameters[6].Value = model.price;
			parameters[7].Value = model.stime;
			parameters[8].Value = model.etime;
			parameters[9].Value = model.number;
			parameters[10].Value = model.content;
			parameters[11].Value = model.status;
			parameters[12].Value = model.updatetime;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from C_user_coupon ");
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
			strSql.Append("delete from C_user_coupon ");
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
		public Cms.Model.C_user_coupon GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,user_id,article_id,coupon_id,type_id,title,picUrl,price,stime,etime,number,content,status,updatetime from C_user_coupon ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_user_coupon model=new Cms.Model.C_user_coupon();
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
		public Cms.Model.C_user_coupon DataRowToModel(DataRow row)
		{
			Cms.Model.C_user_coupon model=new Cms.Model.C_user_coupon();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["coupon_id"]!=null && row["coupon_id"].ToString()!="")
				{
					model.coupon_id=int.Parse(row["coupon_id"].ToString());
				}
                if (row["type_id"] != null && row["type_id"].ToString() != "")
                {
                    model.type_id = int.Parse(row["type_id"].ToString());
                }
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["picUrl"]!=null)
				{
					model.picUrl=row["picUrl"].ToString();
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
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
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
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
            strSql.Append("select id,user_id,article_id,coupon_id,type_id,title,picUrl,price,stime,etime,number,content,status,updatetime ");
			strSql.Append(" FROM C_user_coupon ");
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
            strSql.Append(" id,user_id,article_id,coupon_id,type_id,title,picUrl,price,stime,etime,number,content,status,updatetime ");
			strSql.Append(" FROM C_user_coupon ");
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
			strSql.Append("select count(1) FROM C_user_coupon ");
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
			strSql.Append(")AS Row, T.*  from C_user_coupon T ");
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
			parameters[0].Value = "C_user_coupon";
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

