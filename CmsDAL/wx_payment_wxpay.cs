/**  版本信息模板在安装目录下，可自行修改。
* wx_payment_wxpay.cs
*
* 功 能： N/A
* 类 名： wx_payment_wxpay
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/26 17:32:07   N/A    初版
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
	/// 数据访问类:wx_payment_wxpay
	/// </summary>
	public partial class wx_payment_wxpay
	{
		public wx_payment_wxpay()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_payment_wxpay"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_payment_wxpay");
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
		public int Add(Cms.Model.wx_payment_wxpay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_payment_wxpay(");
			strSql.Append("wid,partnerId,appId,partnerKey,paySignKey,createDate,CertInfoPath,partnerPwd,shName,bankName,bankCode,remark,quicklyFH)");
			strSql.Append(" values (");
			strSql.Append("@wid,@partnerId,@appId,@partnerKey,@paySignKey,@createDate,@CertInfoPath,@partnerPwd,@shName,@bankName,@bankCode,@remark,@quicklyFH)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@partnerId", SqlDbType.VarChar,100),
					new SqlParameter("@appId", SqlDbType.VarChar,100),
					new SqlParameter("@partnerKey", SqlDbType.VarChar,100),
					new SqlParameter("@paySignKey", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@CertInfoPath", SqlDbType.VarChar,1000),
					new SqlParameter("@partnerPwd", SqlDbType.VarChar,200),
					new SqlParameter("@shName", SqlDbType.VarChar,300),
					new SqlParameter("@bankName", SqlDbType.VarChar,300),
					new SqlParameter("@bankCode", SqlDbType.VarChar,200),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@quicklyFH", SqlDbType.Bit,1)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.partnerId;
			parameters[2].Value = model.appId;
			parameters[3].Value = model.partnerKey;
			parameters[4].Value = model.paySignKey;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.CertInfoPath;
			parameters[7].Value = model.partnerPwd;
			parameters[8].Value = model.shName;
			parameters[9].Value = model.bankName;
			parameters[10].Value = model.bankCode;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.quicklyFH;

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
		public bool Update(Cms.Model.wx_payment_wxpay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_payment_wxpay set ");
			strSql.Append("wid=@wid,");
			strSql.Append("partnerId=@partnerId,");
			strSql.Append("appId=@appId,");
			strSql.Append("partnerKey=@partnerKey,");
			strSql.Append("paySignKey=@paySignKey,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("CertInfoPath=@CertInfoPath,");
			strSql.Append("partnerPwd=@partnerPwd,");
			strSql.Append("shName=@shName,");
			strSql.Append("bankName=@bankName,");
			strSql.Append("bankCode=@bankCode,");
			strSql.Append("remark=@remark,");
			strSql.Append("quicklyFH=@quicklyFH");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@partnerId", SqlDbType.VarChar,100),
					new SqlParameter("@appId", SqlDbType.VarChar,100),
					new SqlParameter("@partnerKey", SqlDbType.VarChar,100),
					new SqlParameter("@paySignKey", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@CertInfoPath", SqlDbType.VarChar,1000),
					new SqlParameter("@partnerPwd", SqlDbType.VarChar,200),
					new SqlParameter("@shName", SqlDbType.VarChar,300),
					new SqlParameter("@bankName", SqlDbType.VarChar,300),
					new SqlParameter("@bankCode", SqlDbType.VarChar,200),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@quicklyFH", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.partnerId;
			parameters[2].Value = model.appId;
			parameters[3].Value = model.partnerKey;
			parameters[4].Value = model.paySignKey;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.CertInfoPath;
			parameters[7].Value = model.partnerPwd;
			parameters[8].Value = model.shName;
			parameters[9].Value = model.bankName;
			parameters[10].Value = model.bankCode;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.quicklyFH;
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
			strSql.Append("delete from wx_payment_wxpay ");
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
			strSql.Append("delete from wx_payment_wxpay ");
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
		public Cms.Model.wx_payment_wxpay GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,partnerId,appId,partnerKey,paySignKey,createDate,CertInfoPath,partnerPwd,shName,bankName,bankCode,remark,quicklyFH from wx_payment_wxpay ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_payment_wxpay model=new Cms.Model.wx_payment_wxpay();
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
		public Cms.Model.wx_payment_wxpay DataRowToModel(DataRow row)
		{
			Cms.Model.wx_payment_wxpay model=new Cms.Model.wx_payment_wxpay();
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
				if(row["partnerId"]!=null)
				{
					model.partnerId=row["partnerId"].ToString();
				}
				if(row["appId"]!=null)
				{
					model.appId=row["appId"].ToString();
				}
				if(row["partnerKey"]!=null)
				{
					model.partnerKey=row["partnerKey"].ToString();
				}
				if(row["paySignKey"]!=null)
				{
					model.paySignKey=row["paySignKey"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["CertInfoPath"]!=null)
				{
					model.CertInfoPath=row["CertInfoPath"].ToString();
				}
				if(row["partnerPwd"]!=null)
				{
					model.partnerPwd=row["partnerPwd"].ToString();
				}
				if(row["shName"]!=null)
				{
					model.shName=row["shName"].ToString();
				}
				if(row["bankName"]!=null)
				{
					model.bankName=row["bankName"].ToString();
				}
				if(row["bankCode"]!=null)
				{
					model.bankCode=row["bankCode"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["quicklyFH"]!=null && row["quicklyFH"].ToString()!="")
				{
					if((row["quicklyFH"].ToString()=="1")||(row["quicklyFH"].ToString().ToLower()=="true"))
					{
						model.quicklyFH=true;
					}
					else
					{
						model.quicklyFH=false;
					}
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
			strSql.Append("select id,wid,partnerId,appId,partnerKey,paySignKey,createDate,CertInfoPath,partnerPwd,shName,bankName,bankCode,remark,quicklyFH ");
			strSql.Append(" FROM wx_payment_wxpay ");
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
			strSql.Append(" id,wid,partnerId,appId,partnerKey,paySignKey,createDate,CertInfoPath,partnerPwd,shName,bankName,bankCode,remark,quicklyFH ");
			strSql.Append(" FROM wx_payment_wxpay ");
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
			strSql.Append("select count(1) FROM wx_payment_wxpay ");
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
			strSql.Append(")AS Row, T.*  from wx_payment_wxpay T ");
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
			parameters[0].Value = "wx_payment_wxpay";
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

