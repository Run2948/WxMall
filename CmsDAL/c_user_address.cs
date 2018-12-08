/**  版本信息模板在安装目录下，可自行修改。
* c_user_address.cs
*
* 功 能： N/A
* 类 名： c_user_address
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/28 11:54:45   N/A    初版
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
	/// 数据访问类:c_user_address
	/// </summary>
	public partial class c_user_address
	{
		public c_user_address()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "c_user_address"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from c_user_address");
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
		public int Add(Cms.Model.c_user_address model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into c_user_address(");
			strSql.Append("user_id,consignee,cellphone,code,location,city,county,street,address,is_default,updateTime)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@consignee,@cellphone,@code,@location,@city,@county,@street,@address,@is_default,@updateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@consignee", SqlDbType.VarChar,150),
					new SqlParameter("@cellphone", SqlDbType.VarChar,150),
					new SqlParameter("@code", SqlDbType.VarChar,150),
					new SqlParameter("@location", SqlDbType.VarChar,350),
					new SqlParameter("@city", SqlDbType.VarChar,350),
					new SqlParameter("@county", SqlDbType.VarChar,350),
					new SqlParameter("@street", SqlDbType.VarChar,350),
					new SqlParameter("@address", SqlDbType.VarChar,350),
					new SqlParameter("@is_default", SqlDbType.Int,4),
					new SqlParameter("@updateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.consignee;
			parameters[2].Value = model.cellphone;
			parameters[3].Value = model.code;
			parameters[4].Value = model.location;
			parameters[5].Value = model.city;
			parameters[6].Value = model.county;
			parameters[7].Value = model.street;
			parameters[8].Value = model.address;
			parameters[9].Value = model.is_default;
			parameters[10].Value = model.updateTime;

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
		public bool Update(Cms.Model.c_user_address model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update c_user_address set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("consignee=@consignee,");
			strSql.Append("cellphone=@cellphone,");
			strSql.Append("code=@code,");
			strSql.Append("location=@location,");
			strSql.Append("city=@city,");
			strSql.Append("county=@county,");
			strSql.Append("street=@street,");
			strSql.Append("address=@address,");
			strSql.Append("is_default=@is_default,");
			strSql.Append("updateTime=@updateTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@consignee", SqlDbType.VarChar,150),
					new SqlParameter("@cellphone", SqlDbType.VarChar,150),
					new SqlParameter("@code", SqlDbType.VarChar,150),
					new SqlParameter("@location", SqlDbType.VarChar,350),
					new SqlParameter("@city", SqlDbType.VarChar,350),
					new SqlParameter("@county", SqlDbType.VarChar,350),
					new SqlParameter("@street", SqlDbType.VarChar,350),
					new SqlParameter("@address", SqlDbType.VarChar,350),
					new SqlParameter("@is_default", SqlDbType.Int,4),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.consignee;
			parameters[2].Value = model.cellphone;
			parameters[3].Value = model.code;
			parameters[4].Value = model.location;
			parameters[5].Value = model.city;
			parameters[6].Value = model.county;
			parameters[7].Value = model.street;
			parameters[8].Value = model.address;
			parameters[9].Value = model.is_default;
			parameters[10].Value = model.updateTime;
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
			strSql.Append("delete from c_user_address ");
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
			strSql.Append("delete from c_user_address ");
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
		public Cms.Model.c_user_address GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,user_id,consignee,cellphone,code,location,city,county,street,address,is_default,updateTime from c_user_address ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.c_user_address model=new Cms.Model.c_user_address();
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
		public Cms.Model.c_user_address DataRowToModel(DataRow row)
		{
			Cms.Model.c_user_address model=new Cms.Model.c_user_address();
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
				if(row["consignee"]!=null)
				{
					model.consignee=row["consignee"].ToString();
				}
				if(row["cellphone"]!=null)
				{
					model.cellphone=row["cellphone"].ToString();
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
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
				if(row["street"]!=null)
				{
					model.street=row["street"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["is_default"]!=null && row["is_default"].ToString()!="")
				{
					model.is_default=int.Parse(row["is_default"].ToString());
				}
				if(row["updateTime"]!=null && row["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(row["updateTime"].ToString());
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
			strSql.Append("select id,user_id,consignee,cellphone,code,location,city,county,street,address,is_default,updateTime ");
			strSql.Append(" FROM c_user_address ");
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
			strSql.Append(" id,user_id,consignee,cellphone,code,location,city,county,street,address,is_default,updateTime ");
			strSql.Append(" FROM c_user_address ");
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
			strSql.Append("select count(1) FROM c_user_address ");
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
			strSql.Append(")AS Row, T.*  from c_user_address T ");
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
			parameters[0].Value = "c_user_address";
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

