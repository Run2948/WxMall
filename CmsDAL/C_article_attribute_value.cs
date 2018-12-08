/**  版本信息模板在安装目录下，可自行修改。
* C_article_attribute_value.cs
*
* 功 能： N/A
* 类 名： C_article_attribute_value
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/9 17:11:13   N/A    初版
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
	/// 数据访问类:C_article_attribute_value
	/// </summary>
	public partial class C_article_attribute_value
	{
		public C_article_attribute_value()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("article_id", "C_article_attribute_value"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int article_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_article_attribute_value");
			strSql.Append(" where article_id=@article_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4)			};
			parameters[0].Value = article_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Cms.Model.C_article_attribute_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_article_attribute_value(");
			strSql.Append("article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point)");
			strSql.Append(" values (");
			strSql.Append("@article_id,@sub_title,@source,@author,@goods_no,@stock_quantity,@market_price,@sell_price,@point)");
			SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@sub_title", SqlDbType.NVarChar,255),
					new SqlParameter("@source", SqlDbType.NVarChar,100),
					new SqlParameter("@author", SqlDbType.NVarChar,50),
					new SqlParameter("@goods_no", SqlDbType.NVarChar,100),
					new SqlParameter("@stock_quantity", SqlDbType.Int,4),
					new SqlParameter("@market_price", SqlDbType.Decimal,5),
					new SqlParameter("@sell_price", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4)};
			parameters[0].Value = model.article_id;
			parameters[1].Value = model.sub_title;
			parameters[2].Value = model.source;
			parameters[3].Value = model.author;
			parameters[4].Value = model.goods_no;
			parameters[5].Value = model.stock_quantity;
			parameters[6].Value = model.market_price;
			parameters[7].Value = model.sell_price;
			parameters[8].Value = model.point;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Cms.Model.C_article_attribute_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_article_attribute_value set ");
			strSql.Append("sub_title=@sub_title,");
			strSql.Append("source=@source,");
			strSql.Append("author=@author,");
			strSql.Append("goods_no=@goods_no,");
			strSql.Append("stock_quantity=@stock_quantity,");
			strSql.Append("market_price=@market_price,");
			strSql.Append("sell_price=@sell_price,");
			strSql.Append("point=@point");
			strSql.Append(" where article_id=@article_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@sub_title", SqlDbType.NVarChar,255),
					new SqlParameter("@source", SqlDbType.NVarChar,100),
					new SqlParameter("@author", SqlDbType.NVarChar,50),
					new SqlParameter("@goods_no", SqlDbType.NVarChar,100),
					new SqlParameter("@stock_quantity", SqlDbType.Int,4),
					new SqlParameter("@market_price", SqlDbType.Decimal,5),
					new SqlParameter("@sell_price", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@article_id", SqlDbType.Int,4)};
			parameters[0].Value = model.sub_title;
			parameters[1].Value = model.source;
			parameters[2].Value = model.author;
			parameters[3].Value = model.goods_no;
			parameters[4].Value = model.stock_quantity;
			parameters[5].Value = model.market_price;
			parameters[6].Value = model.sell_price;
			parameters[7].Value = model.point;
			parameters[8].Value = model.article_id;

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
		public bool Delete(int article_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_article_attribute_value ");
			strSql.Append(" where article_id=@article_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4)			};
			parameters[0].Value = article_id;

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
		public bool DeleteList(string article_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_article_attribute_value ");
			strSql.Append(" where article_id in ("+article_idlist + ")  ");
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
		public Cms.Model.C_article_attribute_value GetModel(int article_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point from C_article_attribute_value ");
			strSql.Append(" where article_id=@article_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4)			};
			parameters[0].Value = article_id;

			Cms.Model.C_article_attribute_value model=new Cms.Model.C_article_attribute_value();
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
		public Cms.Model.C_article_attribute_value DataRowToModel(DataRow row)
		{
			Cms.Model.C_article_attribute_value model=new Cms.Model.C_article_attribute_value();
			if (row != null)
			{
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["sub_title"]!=null)
				{
					model.sub_title=row["sub_title"].ToString();
				}
				if(row["source"]!=null)
				{
					model.source=row["source"].ToString();
				}
				if(row["author"]!=null)
				{
					model.author=row["author"].ToString();
				}
				if(row["goods_no"]!=null)
				{
					model.goods_no=row["goods_no"].ToString();
				}
				if(row["stock_quantity"]!=null && row["stock_quantity"].ToString()!="")
				{
					model.stock_quantity=int.Parse(row["stock_quantity"].ToString());
				}
				if(row["market_price"]!=null && row["market_price"].ToString()!="")
				{
					model.market_price=decimal.Parse(row["market_price"].ToString());
				}
				if(row["sell_price"]!=null && row["sell_price"].ToString()!="")
				{
					model.sell_price=decimal.Parse(row["sell_price"].ToString());
				}
				if(row["point"]!=null && row["point"].ToString()!="")
				{
					model.point=int.Parse(row["point"].ToString());
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
			strSql.Append("select article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point ");
			strSql.Append(" FROM C_article_attribute_value ");
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
			strSql.Append(" article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point ");
			strSql.Append(" FROM C_article_attribute_value ");
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
			strSql.Append("select count(1) FROM C_article_attribute_value ");
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
				strSql.Append("order by T.article_id desc");
			}
			strSql.Append(")AS Row, T.*  from C_article_attribute_value T ");
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
			parameters[0].Value = "C_article_attribute_value";
			parameters[1].Value = "article_id";
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

