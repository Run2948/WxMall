/**  版本信息模板在安装目录下，可自行修改。
* sc_stores.cs
*
* 功 能： N/A
* 类 名： sc_stores
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/20 17:01:33   N/A    初版
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
	/// 数据访问类:sc_stores
	/// </summary>
	public partial class sc_stores
	{
		public sc_stores()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "sc_stores"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sc_stores");
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
		public int Add(Cms.Model.sc_stores model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sc_stores(");
			strSql.Append("pid,location,city,county,storename,info,sort_id,picurl,linkurl,latitude,longitude,isHidden,updatetime,tel,address,verificationPass)");
			strSql.Append(" values (");
			strSql.Append("@pid,@location,@city,@county,@storename,@info,@sort_id,@picurl,@linkurl,@latitude,@longitude,@isHidden,@updatetime,@tel,@address,@verificationPass)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@location", SqlDbType.VarChar,350),
					new SqlParameter("@city", SqlDbType.VarChar,350),
					new SqlParameter("@county", SqlDbType.VarChar,350),
					new SqlParameter("@storename", SqlDbType.NVarChar,100),
					new SqlParameter("@info", SqlDbType.Text),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@picurl", SqlDbType.NVarChar,150),
					new SqlParameter("@linkurl", SqlDbType.NVarChar,150),
					new SqlParameter("@latitude", SqlDbType.NVarChar,50),
					new SqlParameter("@longitude", SqlDbType.NVarChar,50),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@tel", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,300),
					new SqlParameter("@verificationPass", SqlDbType.NVarChar,300)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.location;
			parameters[2].Value = model.city;
			parameters[3].Value = model.county;
			parameters[4].Value = model.storename;
			parameters[5].Value = model.info;
			parameters[6].Value = model.sort_id;
			parameters[7].Value = model.picurl;
			parameters[8].Value = model.linkurl;
			parameters[9].Value = model.latitude;
			parameters[10].Value = model.longitude;
			parameters[11].Value = model.isHidden;
			parameters[12].Value = model.updatetime;
			parameters[13].Value = model.tel;
			parameters[14].Value = model.address;
			parameters[15].Value = model.verificationPass;

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
		public bool Update(Cms.Model.sc_stores model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sc_stores set ");
			strSql.Append("pid=@pid,");
			strSql.Append("location=@location,");
			strSql.Append("city=@city,");
			strSql.Append("county=@county,");
			strSql.Append("storename=@storename,");
			strSql.Append("info=@info,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("picurl=@picurl,");
			strSql.Append("linkurl=@linkurl,");
			strSql.Append("latitude=@latitude,");
			strSql.Append("longitude=@longitude,");
			strSql.Append("isHidden=@isHidden,");
			strSql.Append("updatetime=@updatetime,");
			strSql.Append("tel=@tel,");
			strSql.Append("address=@address,");
			strSql.Append("verificationPass=@verificationPass");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@location", SqlDbType.VarChar,350),
					new SqlParameter("@city", SqlDbType.VarChar,350),
					new SqlParameter("@county", SqlDbType.VarChar,350),
					new SqlParameter("@storename", SqlDbType.NVarChar,100),
					new SqlParameter("@info", SqlDbType.Text),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@picurl", SqlDbType.NVarChar,150),
					new SqlParameter("@linkurl", SqlDbType.NVarChar,150),
					new SqlParameter("@latitude", SqlDbType.NVarChar,50),
					new SqlParameter("@longitude", SqlDbType.NVarChar,50),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@tel", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,300),
					new SqlParameter("@verificationPass", SqlDbType.NVarChar,300),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.location;
			parameters[2].Value = model.city;
			parameters[3].Value = model.county;
			parameters[4].Value = model.storename;
			parameters[5].Value = model.info;
			parameters[6].Value = model.sort_id;
			parameters[7].Value = model.picurl;
			parameters[8].Value = model.linkurl;
			parameters[9].Value = model.latitude;
			parameters[10].Value = model.longitude;
			parameters[11].Value = model.isHidden;
			parameters[12].Value = model.updatetime;
			parameters[13].Value = model.tel;
			parameters[14].Value = model.address;
			parameters[15].Value = model.verificationPass;
			parameters[16].Value = model.id;

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
			strSql.Append("delete from sc_stores ");
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
			strSql.Append("delete from sc_stores ");
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
		public Cms.Model.sc_stores GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pid,location,city,county,storename,info,sort_id,picurl,linkurl,latitude,longitude,isHidden,updatetime,tel,address,verificationPass from sc_stores ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.sc_stores model=new Cms.Model.sc_stores();
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
		public Cms.Model.sc_stores DataRowToModel(DataRow row)
		{
			Cms.Model.sc_stores model=new Cms.Model.sc_stores();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["pid"]!=null && row["pid"].ToString()!="")
				{
					model.pid=int.Parse(row["pid"].ToString());
				}
				if(row["location"]!=null)
				{
					model.location=row["location"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["county"]!=null)
				{
					model.county=row["county"].ToString();
				}
				if(row["storename"]!=null)
				{
					model.storename=row["storename"].ToString();
				}
				if(row["info"]!=null)
				{
					model.info=row["info"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["picurl"]!=null)
				{
					model.picurl=row["picurl"].ToString();
				}
				if(row["linkurl"]!=null)
				{
					model.linkurl=row["linkurl"].ToString();
				}
				if(row["latitude"]!=null)
				{
					model.latitude=row["latitude"].ToString();
				}
				if(row["longitude"]!=null)
				{
					model.longitude=row["longitude"].ToString();
				}
				if(row["isHidden"]!=null && row["isHidden"].ToString()!="")
				{
					model.isHidden=int.Parse(row["isHidden"].ToString());
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["verificationPass"]!=null)
				{
					model.verificationPass=row["verificationPass"].ToString();
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
			strSql.Append("select id,pid,location,city,county,storename,info,sort_id,picurl,linkurl,latitude,longitude,isHidden,updatetime,tel,address,verificationPass ");
			strSql.Append(" FROM sc_stores ");
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
			strSql.Append(" id,pid,location,city,county,storename,info,sort_id,picurl,linkurl,latitude,longitude,isHidden,updatetime,tel,address,verificationPass ");
			strSql.Append(" FROM sc_stores ");
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
			strSql.Append("select count(1) FROM sc_stores ");
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
			strSql.Append(")AS Row, T.*  from sc_stores T ");
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
			parameters[0].Value = "sc_stores";
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

