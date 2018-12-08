/**  版本信息模板在安装目录下，可自行修改。
* C_user_cart.cs
*
* 功 能： N/A
* 类 名： C_user_cart
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/11 23:28:31   N/A    初版
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
	/// 数据访问类:C_user_cart
	/// </summary>
	public partial class C_user_cart
	{
		public C_user_cart()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_user_cart"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_user_cart");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int article_id, int user_id, int typeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_user_cart");
            strSql.Append(" where article_id=@article_id and user_id=@user_id and typeId=@typeId");
            SqlParameter[] parameters = {					new SqlParameter("@article_id", SqlDbType.Int,4),                    new SqlParameter("@user_id", SqlDbType.Int,4),                     new SqlParameter("@typeId", SqlDbType.Int,4)			};
            parameters[0].Value = article_id;
            parameters[1].Value = user_id;
            parameters[2].Value = typeId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_user_cart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_user_cart(");
			strSql.Append("user_id,typeId,article_id,title,price,quantity,integral,property_value,note,is_checked,updateTime)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@typeId,@article_id,@title,@price,@quantity,@integral,@property_value,@note,@is_checked,@updateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,350),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@property_value", SqlDbType.VarChar,550),
					new SqlParameter("@note", SqlDbType.VarChar,350),
					new SqlParameter("@is_checked", SqlDbType.Int,4),
					new SqlParameter("@updateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.typeId;
			parameters[2].Value = model.article_id;
			parameters[3].Value = model.title;
			parameters[4].Value = model.price;
			parameters[5].Value = model.quantity;
			parameters[6].Value = model.integral;
			parameters[7].Value = model.property_value;
			parameters[8].Value = model.note;
			parameters[9].Value = model.is_checked;
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
		public bool Update(Cms.Model.C_user_cart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_user_cart set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("typeId=@typeId,");
			strSql.Append("article_id=@article_id,");
			strSql.Append("title=@title,");
			strSql.Append("price=@price,");
			strSql.Append("quantity=@quantity,");
			strSql.Append("integral=@integral,");
			strSql.Append("property_value=@property_value,");
			strSql.Append("note=@note,");
			strSql.Append("is_checked=@is_checked,");
			strSql.Append("updateTime=@updateTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,350),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@property_value", SqlDbType.VarChar,550),
					new SqlParameter("@note", SqlDbType.VarChar,350),
					new SqlParameter("@is_checked", SqlDbType.Int,4),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.typeId;
			parameters[2].Value = model.article_id;
			parameters[3].Value = model.title;
			parameters[4].Value = model.price;
			parameters[5].Value = model.quantity;
			parameters[6].Value = model.integral;
			parameters[7].Value = model.property_value;
			parameters[8].Value = model.note;
			parameters[9].Value = model.is_checked;
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
			strSql.Append("delete from C_user_cart ");
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
			strSql.Append("delete from C_user_cart ");
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
		public Cms.Model.C_user_cart GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,user_id,typeId,article_id,title,price,quantity,integral,property_value,note,is_checked,updateTime from C_user_cart ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_user_cart model=new Cms.Model.C_user_cart();
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
		public Cms.Model.C_user_cart DataRowToModel(DataRow row)
		{
			Cms.Model.C_user_cart model=new Cms.Model.C_user_cart();
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
				if(row["typeId"]!=null && row["typeId"].ToString()!="")
				{
					model.typeId=int.Parse(row["typeId"].ToString());
				}
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["quantity"]!=null && row["quantity"].ToString()!="")
				{
					model.quantity=int.Parse(row["quantity"].ToString());
				}
				if(row["integral"]!=null && row["integral"].ToString()!="")
				{
					model.integral=int.Parse(row["integral"].ToString());
				}
				if(row["property_value"]!=null)
				{
					model.property_value=row["property_value"].ToString();
				}
				if(row["note"]!=null)
				{
					model.note=row["note"].ToString();
				}
				if(row["is_checked"]!=null && row["is_checked"].ToString()!="")
				{
					model.is_checked=int.Parse(row["is_checked"].ToString());
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
			strSql.Append("select id,user_id,typeId,article_id,title,price,quantity,integral,property_value,note,is_checked,updateTime ");
			strSql.Append(" FROM C_user_cart ");
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
			strSql.Append(" id,user_id,typeId,article_id,title,price,quantity,integral,property_value,note,is_checked,updateTime ");
			strSql.Append(" FROM C_user_cart ");
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
			strSql.Append("select count(1) FROM C_user_cart ");
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
			strSql.Append(")AS Row, T.*  from C_user_cart T ");
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
			parameters[0].Value = "C_user_cart";
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

