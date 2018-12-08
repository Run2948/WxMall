/**  版本信息模板在安装目录下，可自行修改。
* C_ad.cs
*
* 功 能： N/A
* 类 名： C_ad
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/6/21 15:34:25   N/A    初版
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
	/// 数据访问类:C_ad
	/// </summary>
	public partial class C_ad
	{
		public C_ad()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_ad"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_ad");
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
		public int Add(Cms.Model.C_ad model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_ad(");
			strSql.Append("name,picUrl,width,height,linkUrl1,hits,filestype,ishidden,ordernum,linkUrl,note,adtype,updateTime,textParam1,textParam2,textParam3,textParam4,textParam5)");
			strSql.Append(" values (");
			strSql.Append("@name,@picUrl,@width,@height,@linkUrl1,@hits,@filestype,@ishidden,@ordernum,@linkUrl,@note,@adtype,@updateTime,@textParam1,@textParam2,@textParam3,@textParam4,@textParam5)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,-1),
					new SqlParameter("@picUrl", SqlDbType.VarChar,-1),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@linkUrl1", SqlDbType.VarChar,350),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@filestype", SqlDbType.VarChar,350),
					new SqlParameter("@ishidden", SqlDbType.Int,4),
					new SqlParameter("@ordernum", SqlDbType.Int,4),
					new SqlParameter("@linkUrl", SqlDbType.VarChar,-1),
					new SqlParameter("@note", SqlDbType.VarChar,-1),
					new SqlParameter("@adtype", SqlDbType.VarChar,50),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@textParam1", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam2", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam3", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam4", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam5", SqlDbType.VarChar,-1)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.picUrl;
			parameters[2].Value = model.width;
			parameters[3].Value = model.height;
			parameters[4].Value = model.linkUrl1;
			parameters[5].Value = model.hits;
			parameters[6].Value = model.filestype;
			parameters[7].Value = model.ishidden;
			parameters[8].Value = model.ordernum;
			parameters[9].Value = model.linkUrl;
			parameters[10].Value = model.note;
			parameters[11].Value = model.adtype;
			parameters[12].Value = model.updateTime;
			parameters[13].Value = model.textParam1;
			parameters[14].Value = model.textParam2;
			parameters[15].Value = model.textParam3;
			parameters[16].Value = model.textParam4;
			parameters[17].Value = model.textParam5;

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
		public bool Update(Cms.Model.C_ad model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_ad set ");
			strSql.Append("name=@name,");
			strSql.Append("picUrl=@picUrl,");
			strSql.Append("width=@width,");
			strSql.Append("height=@height,");
			strSql.Append("linkUrl1=@linkUrl1,");
			strSql.Append("hits=@hits,");
			strSql.Append("filestype=@filestype,");
			strSql.Append("ishidden=@ishidden,");
			strSql.Append("ordernum=@ordernum,");
			strSql.Append("linkUrl=@linkUrl,");
			strSql.Append("note=@note,");
			strSql.Append("adtype=@adtype,");
			strSql.Append("updateTime=@updateTime,");
			strSql.Append("textParam1=@textParam1,");
			strSql.Append("textParam2=@textParam2,");
			strSql.Append("textParam3=@textParam3,");
			strSql.Append("textParam4=@textParam4,");
			strSql.Append("textParam5=@textParam5");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,-1),
					new SqlParameter("@picUrl", SqlDbType.VarChar,-1),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@linkUrl1", SqlDbType.VarChar,350),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@filestype", SqlDbType.VarChar,350),
					new SqlParameter("@ishidden", SqlDbType.Int,4),
					new SqlParameter("@ordernum", SqlDbType.Int,4),
					new SqlParameter("@linkUrl", SqlDbType.VarChar,-1),
					new SqlParameter("@note", SqlDbType.VarChar,-1),
					new SqlParameter("@adtype", SqlDbType.VarChar,50),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@textParam1", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam2", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam3", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam4", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam5", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.picUrl;
			parameters[2].Value = model.width;
			parameters[3].Value = model.height;
			parameters[4].Value = model.linkUrl1;
			parameters[5].Value = model.hits;
			parameters[6].Value = model.filestype;
			parameters[7].Value = model.ishidden;
			parameters[8].Value = model.ordernum;
			parameters[9].Value = model.linkUrl;
			parameters[10].Value = model.note;
			parameters[11].Value = model.adtype;
			parameters[12].Value = model.updateTime;
			parameters[13].Value = model.textParam1;
			parameters[14].Value = model.textParam2;
			parameters[15].Value = model.textParam3;
			parameters[16].Value = model.textParam4;
			parameters[17].Value = model.textParam5;
			parameters[18].Value = model.id;

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
			strSql.Append("delete from C_ad ");
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
			strSql.Append("delete from C_ad ");
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
		public Cms.Model.C_ad GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,picUrl,width,height,linkUrl1,hits,filestype,ishidden,ordernum,linkUrl,note,adtype,updateTime,textParam1,textParam2,textParam3,textParam4,textParam5 from C_ad ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_ad model=new Cms.Model.C_ad();
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
		public Cms.Model.C_ad DataRowToModel(DataRow row)
		{
			Cms.Model.C_ad model=new Cms.Model.C_ad();
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
				if(row["picUrl"]!=null)
				{
					model.picUrl=row["picUrl"].ToString();
				}
				if(row["width"]!=null && row["width"].ToString()!="")
				{
					model.width=int.Parse(row["width"].ToString());
				}
				if(row["height"]!=null && row["height"].ToString()!="")
				{
					model.height=int.Parse(row["height"].ToString());
				}
				if(row["linkUrl1"]!=null)
				{
					model.linkUrl1=row["linkUrl1"].ToString();
				}
				if(row["hits"]!=null && row["hits"].ToString()!="")
				{
					model.hits=int.Parse(row["hits"].ToString());
				}
				if(row["filestype"]!=null)
				{
					model.filestype=row["filestype"].ToString();
				}
				if(row["ishidden"]!=null && row["ishidden"].ToString()!="")
				{
					model.ishidden=int.Parse(row["ishidden"].ToString());
				}
				if(row["ordernum"]!=null && row["ordernum"].ToString()!="")
				{
					model.ordernum=int.Parse(row["ordernum"].ToString());
				}
				if(row["linkUrl"]!=null)
				{
					model.linkUrl=row["linkUrl"].ToString();
				}
				if(row["note"]!=null)
				{
					model.note=row["note"].ToString();
				}
				if(row["adtype"]!=null)
				{
					model.adtype=row["adtype"].ToString();
				}
				if(row["updateTime"]!=null && row["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(row["updateTime"].ToString());
				}
				if(row["textParam1"]!=null)
				{
					model.textParam1=row["textParam1"].ToString();
				}
				if(row["textParam2"]!=null)
				{
					model.textParam2=row["textParam2"].ToString();
				}
				if(row["textParam3"]!=null)
				{
					model.textParam3=row["textParam3"].ToString();
				}
				if(row["textParam4"]!=null)
				{
					model.textParam4=row["textParam4"].ToString();
				}
				if(row["textParam5"]!=null)
				{
					model.textParam5=row["textParam5"].ToString();
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
			strSql.Append("select id,name,picUrl,width,height,linkUrl1,hits,filestype,ishidden,ordernum,linkUrl,note,adtype,updateTime,textParam1,textParam2,textParam3,textParam4,textParam5 ");
			strSql.Append(" FROM C_ad ");
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
			strSql.Append(" id,name,picUrl,width,height,linkUrl1,hits,filestype,ishidden,ordernum,linkUrl,note,adtype,updateTime,textParam1,textParam2,textParam3,textParam4,textParam5 ");
			strSql.Append(" FROM C_ad ");
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
			strSql.Append("select count(1) FROM C_ad ");
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
			strSql.Append(")AS Row, T.*  from C_ad T ");
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
			parameters[0].Value = "C_ad";
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

