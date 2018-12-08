/**  版本信息模板在安装目录下，可自行修改。
* C_product.cs
*
* 功 能： N/A
* 类 名： C_product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/5/12 15:26:16   N/A    初版
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
	/// 数据访问类:C_product
	/// </summary>
	public partial class C_product
	{
		public C_product()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_product");
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
		public int Add(Cms.Model.C_product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_product(");
			strSql.Append("name,intro,litpic,price,marketPrice,integral,stock,unit,sVersion,typeId,sales,views,isTop,isHot,isHidden,isActive,isRecommend,seoTitle,seoKeyword,seoDescription,content,ingredients,factoryAddress,factoryName,manufactureDate,createdTime,comments,favorableRate,sortId)");
			strSql.Append(" values (");
			strSql.Append("@name,@intro,@litpic,@price,@marketPrice,@integral,@stock,@unit,@sVersion,@typeId,@sales,@views,@isTop,@isHot,@isHidden,@isActive,@isRecommend,@seoTitle,@seoKeyword,@seoDescription,@content,@ingredients,@factoryAddress,@factoryName,@manufactureDate,@createdTime,@comments,@favorableRate,@sortId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@intro", SqlDbType.VarChar,500),
					new SqlParameter("@litpic", SqlDbType.VarChar,50),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@marketPrice", SqlDbType.Money,8),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@unit", SqlDbType.VarChar,50),
					new SqlParameter("@sVersion", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@sales", SqlDbType.Int,4),
					new SqlParameter("@views", SqlDbType.Int,4),
					new SqlParameter("@isTop", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@isActive", SqlDbType.Int,4),
					new SqlParameter("@isRecommend", SqlDbType.Int,4),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@ingredients", SqlDbType.VarChar,-1),
					new SqlParameter("@factoryAddress", SqlDbType.VarChar,50),
					new SqlParameter("@factoryName", SqlDbType.VarChar,50),
					new SqlParameter("@manufactureDate", SqlDbType.VarChar,50),
					new SqlParameter("@createdTime", SqlDbType.DateTime),
					new SqlParameter("@comments", SqlDbType.Int,4),
					new SqlParameter("@favorableRate", SqlDbType.VarChar,50),
					new SqlParameter("@sortId", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.intro;
			parameters[2].Value = model.litpic;
			parameters[3].Value = model.price;
			parameters[4].Value = model.marketPrice;
			parameters[5].Value = model.integral;
			parameters[6].Value = model.stock;
			parameters[7].Value = model.unit;
			parameters[8].Value = model.sVersion;
			parameters[9].Value = model.typeId;
			parameters[10].Value = model.sales;
			parameters[11].Value = model.views;
			parameters[12].Value = model.isTop;
			parameters[13].Value = model.isHot;
			parameters[14].Value = model.isHidden;
			parameters[15].Value = model.isActive;
			parameters[16].Value = model.isRecommend;
			parameters[17].Value = model.seoTitle;
			parameters[18].Value = model.seoKeyword;
			parameters[19].Value = model.seoDescription;
			parameters[20].Value = model.content;
			parameters[21].Value = model.ingredients;
			parameters[22].Value = model.factoryAddress;
			parameters[23].Value = model.factoryName;
			parameters[24].Value = model.manufactureDate;
			parameters[25].Value = model.createdTime;
			parameters[26].Value = model.comments;
			parameters[27].Value = model.favorableRate;
			parameters[28].Value = model.sortId;

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
		public bool Update(Cms.Model.C_product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_product set ");
			strSql.Append("name=@name,");
			strSql.Append("intro=@intro,");
			strSql.Append("litpic=@litpic,");
			strSql.Append("price=@price,");
			strSql.Append("marketPrice=@marketPrice,");
			strSql.Append("integral=@integral,");
			strSql.Append("stock=@stock,");
			strSql.Append("unit=@unit,");
			strSql.Append("sVersion=@sVersion,");
			strSql.Append("typeId=@typeId,");
			strSql.Append("sales=@sales,");
			strSql.Append("views=@views,");
			strSql.Append("isTop=@isTop,");
			strSql.Append("isHot=@isHot,");
			strSql.Append("isHidden=@isHidden,");
			strSql.Append("isActive=@isActive,");
			strSql.Append("isRecommend=@isRecommend,");
			strSql.Append("seoTitle=@seoTitle,");
			strSql.Append("seoKeyword=@seoKeyword,");
			strSql.Append("seoDescription=@seoDescription,");
			strSql.Append("content=@content,");
			strSql.Append("ingredients=@ingredients,");
			strSql.Append("factoryAddress=@factoryAddress,");
			strSql.Append("factoryName=@factoryName,");
			strSql.Append("manufactureDate=@manufactureDate,");
			strSql.Append("createdTime=@createdTime,");
			strSql.Append("comments=@comments,");
			strSql.Append("favorableRate=@favorableRate,");
			strSql.Append("sortId=@sortId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@intro", SqlDbType.VarChar,500),
					new SqlParameter("@litpic", SqlDbType.VarChar,50),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@marketPrice", SqlDbType.Money,8),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@unit", SqlDbType.VarChar,50),
					new SqlParameter("@sVersion", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@sales", SqlDbType.Int,4),
					new SqlParameter("@views", SqlDbType.Int,4),
					new SqlParameter("@isTop", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@isActive", SqlDbType.Int,4),
					new SqlParameter("@isRecommend", SqlDbType.Int,4),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@ingredients", SqlDbType.VarChar,-1),
					new SqlParameter("@factoryAddress", SqlDbType.VarChar,50),
					new SqlParameter("@factoryName", SqlDbType.VarChar,50),
					new SqlParameter("@manufactureDate", SqlDbType.VarChar,50),
					new SqlParameter("@createdTime", SqlDbType.DateTime),
					new SqlParameter("@comments", SqlDbType.Int,4),
					new SqlParameter("@favorableRate", SqlDbType.VarChar,50),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.intro;
			parameters[2].Value = model.litpic;
			parameters[3].Value = model.price;
			parameters[4].Value = model.marketPrice;
			parameters[5].Value = model.integral;
			parameters[6].Value = model.stock;
			parameters[7].Value = model.unit;
			parameters[8].Value = model.sVersion;
			parameters[9].Value = model.typeId;
			parameters[10].Value = model.sales;
			parameters[11].Value = model.views;
			parameters[12].Value = model.isTop;
			parameters[13].Value = model.isHot;
			parameters[14].Value = model.isHidden;
			parameters[15].Value = model.isActive;
			parameters[16].Value = model.isRecommend;
			parameters[17].Value = model.seoTitle;
			parameters[18].Value = model.seoKeyword;
			parameters[19].Value = model.seoDescription;
			parameters[20].Value = model.content;
			parameters[21].Value = model.ingredients;
			parameters[22].Value = model.factoryAddress;
			parameters[23].Value = model.factoryName;
			parameters[24].Value = model.manufactureDate;
			parameters[25].Value = model.createdTime;
			parameters[26].Value = model.comments;
			parameters[27].Value = model.favorableRate;
			parameters[28].Value = model.sortId;
			parameters[29].Value = model.id;

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
			strSql.Append("delete from C_product ");
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
			strSql.Append("delete from C_product ");
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
		public Cms.Model.C_product GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,intro,litpic,price,marketPrice,integral,stock,unit,sVersion,typeId,sales,views,isTop,isHot,isHidden,isActive,isRecommend,seoTitle,seoKeyword,seoDescription,content,ingredients,factoryAddress,factoryName,manufactureDate,createdTime,comments,favorableRate,sortId from C_product ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_product model=new Cms.Model.C_product();
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
		public Cms.Model.C_product DataRowToModel(DataRow row)
		{
			Cms.Model.C_product model=new Cms.Model.C_product();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["intro"]!=null)
				{
					model.intro=row["intro"].ToString();
				}
				if(row["litpic"]!=null)
				{
					model.litpic=row["litpic"].ToString();
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["marketPrice"]!=null && row["marketPrice"].ToString()!="")
				{
					model.marketPrice=decimal.Parse(row["marketPrice"].ToString());
				}
				if(row["integral"]!=null && row["integral"].ToString()!="")
				{
					model.integral=int.Parse(row["integral"].ToString());
				}
				if(row["stock"]!=null && row["stock"].ToString()!="")
				{
					model.stock=int.Parse(row["stock"].ToString());
				}
				if(row["unit"]!=null)
				{
					model.unit=row["unit"].ToString();
				}
				if(row["sVersion"]!=null && row["sVersion"].ToString()!="")
				{
					model.sVersion=int.Parse(row["sVersion"].ToString());
				}
				if(row["typeId"]!=null && row["typeId"].ToString()!="")
				{
					model.typeId=int.Parse(row["typeId"].ToString());
				}
				if(row["sales"]!=null && row["sales"].ToString()!="")
				{
					model.sales=int.Parse(row["sales"].ToString());
				}
				if(row["views"]!=null && row["views"].ToString()!="")
				{
					model.views=int.Parse(row["views"].ToString());
				}
				if(row["isTop"]!=null && row["isTop"].ToString()!="")
				{
					model.isTop=int.Parse(row["isTop"].ToString());
				}
				if(row["isHot"]!=null && row["isHot"].ToString()!="")
				{
					model.isHot=int.Parse(row["isHot"].ToString());
				}
				if(row["isHidden"]!=null && row["isHidden"].ToString()!="")
				{
					model.isHidden=int.Parse(row["isHidden"].ToString());
				}
				if(row["isActive"]!=null && row["isActive"].ToString()!="")
				{
					model.isActive=int.Parse(row["isActive"].ToString());
				}
				if(row["isRecommend"]!=null && row["isRecommend"].ToString()!="")
				{
					model.isRecommend=int.Parse(row["isRecommend"].ToString());
				}
				if(row["seoTitle"]!=null)
				{
					model.seoTitle=row["seoTitle"].ToString();
				}
				if(row["seoKeyword"]!=null)
				{
					model.seoKeyword=row["seoKeyword"].ToString();
				}
				if(row["seoDescription"]!=null)
				{
					model.seoDescription=row["seoDescription"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["ingredients"]!=null)
				{
					model.ingredients=row["ingredients"].ToString();
				}
				if(row["factoryAddress"]!=null)
				{
					model.factoryAddress=row["factoryAddress"].ToString();
				}
				if(row["factoryName"]!=null)
				{
					model.factoryName=row["factoryName"].ToString();
				}
				if(row["manufactureDate"]!=null)
				{
					model.manufactureDate=row["manufactureDate"].ToString();
				}
				if(row["createdTime"]!=null && row["createdTime"].ToString()!="")
				{
					model.createdTime=DateTime.Parse(row["createdTime"].ToString());
				}
				if(row["comments"]!=null && row["comments"].ToString()!="")
				{
					model.comments=int.Parse(row["comments"].ToString());
				}
				if(row["favorableRate"]!=null)
				{
					model.favorableRate=row["favorableRate"].ToString();
				}
				if(row["sortId"]!=null && row["sortId"].ToString()!="")
				{
					model.sortId=int.Parse(row["sortId"].ToString());
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
			strSql.Append("select id,name,intro,litpic,price,marketPrice,integral,stock,unit,sVersion,typeId,sales,views,isTop,isHot,isHidden,isActive,isRecommend,seoTitle,seoKeyword,seoDescription,content,ingredients,factoryAddress,factoryName,manufactureDate,createdTime,comments,favorableRate,sortId ");
			strSql.Append(" FROM C_product ");
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
			strSql.Append(" id,name,intro,litpic,price,marketPrice,integral,stock,unit,sVersion,typeId,sales,views,isTop,isHot,isHidden,isActive,isRecommend,seoTitle,seoKeyword,seoDescription,content,ingredients,factoryAddress,factoryName,manufactureDate,createdTime,comments,favorableRate,sortId ");
			strSql.Append(" FROM C_product ");
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
			strSql.Append("select count(1) FROM C_product ");
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
			strSql.Append(")AS Row, T.*  from C_product T ");
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
			parameters[0].Value = "C_product";
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

