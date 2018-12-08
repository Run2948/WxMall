/**  版本信息模板在安装目录下，可自行修改。
* C_WebSiteconfig.cs
*
* 功 能： N/A
* 类 名： C_WebSiteconfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/3/19 13:50:17   N/A    初版
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
	/// 数据访问类:C_WebSiteconfig
	/// </summary>
	public partial class C_WebSiteconfig
	{
		public C_WebSiteconfig()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("siteid", "C_WebSiteconfig"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int siteid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_WebSiteconfig");
			strSql.Append(" where siteid=@siteid");
			SqlParameter[] parameters = {
					new SqlParameter("@siteid", SqlDbType.Int,4)
			};
			parameters[0].Value = siteid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_WebSiteconfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_WebSiteconfig(");
			strSql.Append("webName,weburl,title,keyword,Description,upload,Copyright,IcpRecord,adress,telphone,mobiephone,fax,email,contactperson,textParam1,textParam2,textParam3,textParam4,textParam5,logo,mLogo,qq,weixin,tel)");
			strSql.Append(" values (");
			strSql.Append("@webName,@weburl,@title,@keyword,@Description,@upload,@Copyright,@IcpRecord,@adress,@telphone,@mobiephone,@fax,@email,@contactperson,@textParam1,@textParam2,@textParam3,@textParam4,@textParam5,@logo,@mLogo,@qq,@weixin,@tel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@webName", SqlDbType.VarChar,-1),
					new SqlParameter("@weburl", SqlDbType.VarChar,-1),
					new SqlParameter("@title", SqlDbType.VarChar,-1),
					new SqlParameter("@keyword", SqlDbType.VarChar,-1),
					new SqlParameter("@Description", SqlDbType.VarChar,-1),
					new SqlParameter("@upload", SqlDbType.VarChar,-1),
					new SqlParameter("@Copyright", SqlDbType.VarChar,-1),
					new SqlParameter("@IcpRecord", SqlDbType.VarChar,-1),
					new SqlParameter("@adress", SqlDbType.VarChar,-1),
					new SqlParameter("@telphone", SqlDbType.VarChar,-1),
					new SqlParameter("@mobiephone", SqlDbType.VarChar,-1),
					new SqlParameter("@fax", SqlDbType.VarChar,-1),
					new SqlParameter("@email", SqlDbType.VarChar,-1),
					new SqlParameter("@contactperson", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam1", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam2", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam3", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam4", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam5", SqlDbType.VarChar,-1),
					new SqlParameter("@logo", SqlDbType.Text),
					new SqlParameter("@mLogo", SqlDbType.Text),
					new SqlParameter("@qq", SqlDbType.VarChar,50),
					new SqlParameter("@weixin", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50)};
			parameters[0].Value = model.webName;
			parameters[1].Value = model.weburl;
			parameters[2].Value = model.title;
			parameters[3].Value = model.keyword;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.upload;
			parameters[6].Value = model.Copyright;
			parameters[7].Value = model.IcpRecord;
			parameters[8].Value = model.adress;
			parameters[9].Value = model.telphone;
			parameters[10].Value = model.mobiephone;
			parameters[11].Value = model.fax;
			parameters[12].Value = model.email;
			parameters[13].Value = model.contactperson;
			parameters[14].Value = model.textParam1;
			parameters[15].Value = model.textParam2;
			parameters[16].Value = model.textParam3;
			parameters[17].Value = model.textParam4;
			parameters[18].Value = model.textParam5;
			parameters[19].Value = model.logo;
			parameters[20].Value = model.mLogo;
			parameters[21].Value = model.qq;
			parameters[22].Value = model.weixin;
			parameters[23].Value = model.tel;

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
		public bool Update(Cms.Model.C_WebSiteconfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_WebSiteconfig set ");
			strSql.Append("webName=@webName,");
			strSql.Append("weburl=@weburl,");
			strSql.Append("title=@title,");
			strSql.Append("keyword=@keyword,");
			strSql.Append("Description=@Description,");
			strSql.Append("upload=@upload,");
			strSql.Append("Copyright=@Copyright,");
			strSql.Append("IcpRecord=@IcpRecord,");
			strSql.Append("adress=@adress,");
			strSql.Append("telphone=@telphone,");
			strSql.Append("mobiephone=@mobiephone,");
			strSql.Append("fax=@fax,");
			strSql.Append("email=@email,");
			strSql.Append("contactperson=@contactperson,");
			strSql.Append("textParam1=@textParam1,");
			strSql.Append("textParam2=@textParam2,");
			strSql.Append("textParam3=@textParam3,");
			strSql.Append("textParam4=@textParam4,");
			strSql.Append("textParam5=@textParam5,");
			strSql.Append("logo=@logo,");
			strSql.Append("mLogo=@mLogo,");
			strSql.Append("qq=@qq,");
			strSql.Append("weixin=@weixin,");
			strSql.Append("tel=@tel");
			strSql.Append(" where siteid=@siteid");
			SqlParameter[] parameters = {
					new SqlParameter("@webName", SqlDbType.VarChar,-1),
					new SqlParameter("@weburl", SqlDbType.VarChar,-1),
					new SqlParameter("@title", SqlDbType.VarChar,-1),
					new SqlParameter("@keyword", SqlDbType.VarChar,-1),
					new SqlParameter("@Description", SqlDbType.VarChar,-1),
					new SqlParameter("@upload", SqlDbType.VarChar,-1),
					new SqlParameter("@Copyright", SqlDbType.VarChar,-1),
					new SqlParameter("@IcpRecord", SqlDbType.VarChar,-1),
					new SqlParameter("@adress", SqlDbType.VarChar,-1),
					new SqlParameter("@telphone", SqlDbType.VarChar,-1),
					new SqlParameter("@mobiephone", SqlDbType.VarChar,-1),
					new SqlParameter("@fax", SqlDbType.VarChar,-1),
					new SqlParameter("@email", SqlDbType.VarChar,-1),
					new SqlParameter("@contactperson", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam1", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam2", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam3", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam4", SqlDbType.VarChar,-1),
					new SqlParameter("@textParam5", SqlDbType.VarChar,-1),
					new SqlParameter("@logo", SqlDbType.Text),
					new SqlParameter("@mLogo", SqlDbType.Text),
					new SqlParameter("@qq", SqlDbType.VarChar,50),
					new SqlParameter("@weixin", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@siteid", SqlDbType.Int,4)};
			parameters[0].Value = model.webName;
			parameters[1].Value = model.weburl;
			parameters[2].Value = model.title;
			parameters[3].Value = model.keyword;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.upload;
			parameters[6].Value = model.Copyright;
			parameters[7].Value = model.IcpRecord;
			parameters[8].Value = model.adress;
			parameters[9].Value = model.telphone;
			parameters[10].Value = model.mobiephone;
			parameters[11].Value = model.fax;
			parameters[12].Value = model.email;
			parameters[13].Value = model.contactperson;
			parameters[14].Value = model.textParam1;
			parameters[15].Value = model.textParam2;
			parameters[16].Value = model.textParam3;
			parameters[17].Value = model.textParam4;
			parameters[18].Value = model.textParam5;
			parameters[19].Value = model.logo;
			parameters[20].Value = model.mLogo;
			parameters[21].Value = model.qq;
			parameters[22].Value = model.weixin;
			parameters[23].Value = model.tel;
			parameters[24].Value = model.siteid;

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
		public bool Delete(int siteid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_WebSiteconfig ");
			strSql.Append(" where siteid=@siteid");
			SqlParameter[] parameters = {
					new SqlParameter("@siteid", SqlDbType.Int,4)
			};
			parameters[0].Value = siteid;

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
		public bool DeleteList(string siteidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_WebSiteconfig ");
			strSql.Append(" where siteid in ("+siteidlist + ")  ");
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
		public Cms.Model.C_WebSiteconfig GetModel(int siteid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 siteid,webName,weburl,title,keyword,Description,upload,Copyright,IcpRecord,adress,telphone,mobiephone,fax,email,contactperson,textParam1,textParam2,textParam3,textParam4,textParam5,logo,mLogo,qq,weixin,tel from C_WebSiteconfig ");
			strSql.Append(" where siteid=@siteid");
			SqlParameter[] parameters = {
					new SqlParameter("@siteid", SqlDbType.Int,4)
			};
			parameters[0].Value = siteid;

			Cms.Model.C_WebSiteconfig model=new Cms.Model.C_WebSiteconfig();
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
		public Cms.Model.C_WebSiteconfig DataRowToModel(DataRow row)
		{
			Cms.Model.C_WebSiteconfig model=new Cms.Model.C_WebSiteconfig();
			if (row != null)
			{
				if(row["siteid"]!=null && row["siteid"].ToString()!="")
				{
					model.siteid=int.Parse(row["siteid"].ToString());
				}
				if(row["webName"]!=null)
				{
					model.webName=row["webName"].ToString();
				}
				if(row["weburl"]!=null)
				{
					model.weburl=row["weburl"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["keyword"]!=null)
				{
					model.keyword=row["keyword"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["upload"]!=null)
				{
					model.upload=row["upload"].ToString();
				}
				if(row["Copyright"]!=null)
				{
					model.Copyright=row["Copyright"].ToString();
				}
				if(row["IcpRecord"]!=null)
				{
					model.IcpRecord=row["IcpRecord"].ToString();
				}
				if(row["adress"]!=null)
				{
					model.adress=row["adress"].ToString();
				}
				if(row["telphone"]!=null)
				{
					model.telphone=row["telphone"].ToString();
				}
				if(row["mobiephone"]!=null)
				{
					model.mobiephone=row["mobiephone"].ToString();
				}
				if(row["fax"]!=null)
				{
					model.fax=row["fax"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["contactperson"]!=null)
				{
					model.contactperson=row["contactperson"].ToString();
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
				if(row["logo"]!=null)
				{
					model.logo=row["logo"].ToString();
				}
				if(row["mLogo"]!=null)
				{
					model.mLogo=row["mLogo"].ToString();
				}
				if(row["qq"]!=null)
				{
					model.qq=row["qq"].ToString();
				}
				if(row["weixin"]!=null)
				{
					model.weixin=row["weixin"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
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
			strSql.Append("select siteid,webName,weburl,title,keyword,Description,upload,Copyright,IcpRecord,adress,telphone,mobiephone,fax,email,contactperson,textParam1,textParam2,textParam3,textParam4,textParam5,logo,mLogo,qq,weixin,tel ");
			strSql.Append(" FROM C_WebSiteconfig ");
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
			strSql.Append(" siteid,webName,weburl,title,keyword,Description,upload,Copyright,IcpRecord,adress,telphone,mobiephone,fax,email,contactperson,textParam1,textParam2,textParam3,textParam4,textParam5,logo,mLogo,qq,weixin,tel ");
			strSql.Append(" FROM C_WebSiteconfig ");
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
			strSql.Append("select count(1) FROM C_WebSiteconfig ");
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
				strSql.Append("order by T.siteid desc");
			}
			strSql.Append(")AS Row, T.*  from C_WebSiteconfig T ");
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
			parameters[0].Value = "C_WebSiteconfig";
			parameters[1].Value = "siteid";
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

