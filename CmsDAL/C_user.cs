/**  版本信息模板在安装目录下，可自行修改。
* C_user.cs
*
* 功 能： N/A
* 类 名： C_user
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/3 10:34:34   N/A    初版
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
	/// 数据访问类:C_user
	/// </summary>
	public partial class C_user
	{
		public C_user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_user");
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
        public bool Exists(string tel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_user");
            strSql.Append(" where telphone=@tel");
            SqlParameter[] parameters = {
					new SqlParameter("@tel", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = tel;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_user(");
            strSql.Append("password,usercard,openid,username,sex,useraddress,birthday,marryday,telphone,shopname,shopcode,userlevel,allbuy,buytimes,userallscore,userscore,updatetime,isSign,isbind,latitude,longitude,userMoney,userYesScore,headimgurl)");
			strSql.Append(" values (");
            strSql.Append("@password,@usercard,@openid,@username,@sex,@useraddress,@birthday,@marryday,@telphone,@shopname,@shopcode,@userlevel,@allbuy,@buytimes,@userallscore,@userscore,@updatetime,@isSign,@isbind,@latitude,@longitude,@userMoney,@userYesScore,@headimgurl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@password", SqlDbType.NVarChar,50),
					new SqlParameter("@usercard", SqlDbType.NVarChar,50),
					new SqlParameter("@openid", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,50),
					new SqlParameter("@useraddress", SqlDbType.NVarChar,150),
					new SqlParameter("@birthday", SqlDbType.Date,3),
					new SqlParameter("@marryday", SqlDbType.Date,3),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@shopname", SqlDbType.VarChar,250),
                    new SqlParameter("@shopcode", SqlDbType.VarChar,250),
					new SqlParameter("@userlevel", SqlDbType.NChar,10),
					new SqlParameter("@allbuy", SqlDbType.Money,8),
					new SqlParameter("@buytimes", SqlDbType.Int,4),
                    new SqlParameter("@userallscore", SqlDbType.Int,4),
					new SqlParameter("@userscore", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@isSign", SqlDbType.Int,4),
					new SqlParameter("@isbind", SqlDbType.Int,4),
					new SqlParameter("@latitude", SqlDbType.NVarChar,50),
					new SqlParameter("@longitude", SqlDbType.NVarChar,50),
					new SqlParameter("@userMoney", SqlDbType.Money,8),
					new SqlParameter("@userYesScore", SqlDbType.Int,4),
                    new SqlParameter("@headimgurl", SqlDbType.Text)};
			parameters[0].Value = model.password;
			parameters[1].Value = model.usercard;
			parameters[2].Value = model.openid;
			parameters[3].Value = model.username;
			parameters[4].Value = model.sex;
			parameters[5].Value = model.useraddress;
			parameters[6].Value = model.birthday;
			parameters[7].Value = model.marryday;
			parameters[8].Value = model.telphone;
			parameters[9].Value = model.shopname;
            parameters[10].Value = model.shopcode;
			parameters[11].Value = model.userlevel;
			parameters[12].Value = model.allbuy;
			parameters[13].Value = model.buytimes;
            parameters[14].Value = model.userallscore;
			parameters[15].Value = model.userscore;
			parameters[16].Value = model.updatetime;
			parameters[17].Value = model.isSign;
			parameters[18].Value = model.isbind;
			parameters[19].Value = model.latitude;
			parameters[20].Value = model.longitude;
			parameters[21].Value = model.userMoney;
            parameters[22].Value = model.userYesScore;
            parameters[23].Value = model.headimgurl;

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
		public bool Update(Cms.Model.C_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_user set ");
			strSql.Append("password=@password,");
			strSql.Append("usercard=@usercard,");
			strSql.Append("openid=@openid,");
			strSql.Append("username=@username,");
			strSql.Append("sex=@sex,");
			strSql.Append("useraddress=@useraddress,");
			strSql.Append("birthday=@birthday,");
			strSql.Append("marryday=@marryday,");
			strSql.Append("telphone=@telphone,");
			strSql.Append("shopname=@shopname,");
            strSql.Append("shopcode=@shopcode,");
			strSql.Append("userlevel=@userlevel,");
			strSql.Append("allbuy=@allbuy,");
			strSql.Append("buytimes=@buytimes,");
            strSql.Append("userallscore=@userallscore,");
			strSql.Append("userscore=@userscore,");
			strSql.Append("updatetime=@updatetime,");
			strSql.Append("isSign=@isSign,");
			strSql.Append("isbind=@isbind,");
			strSql.Append("latitude=@latitude,");
			strSql.Append("longitude=@longitude,");
			strSql.Append("userMoney=@userMoney,");
            strSql.Append("userYesScore=@userYesScore,");
            strSql.Append("headimgurl=@headimgurl");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@password", SqlDbType.NVarChar,50),
					new SqlParameter("@usercard", SqlDbType.NVarChar,50),
					new SqlParameter("@openid", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,50),
					new SqlParameter("@useraddress", SqlDbType.NVarChar,150),
					new SqlParameter("@birthday", SqlDbType.Date,3),
					new SqlParameter("@marryday", SqlDbType.Date,3),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@shopname", SqlDbType.VarChar,250),
                    new SqlParameter("@shopcode", SqlDbType.VarChar,250),
					new SqlParameter("@userlevel", SqlDbType.NChar,10),
					new SqlParameter("@allbuy", SqlDbType.Money,8),
					new SqlParameter("@buytimes", SqlDbType.Int,4),
                    new SqlParameter("@userallscore", SqlDbType.Int,4),
					new SqlParameter("@userscore", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@isSign", SqlDbType.Int,4),
					new SqlParameter("@isbind", SqlDbType.Int,4),
					new SqlParameter("@latitude", SqlDbType.NVarChar,50),
					new SqlParameter("@longitude", SqlDbType.NVarChar,50),
					new SqlParameter("@userMoney", SqlDbType.Money,8),
                    new SqlParameter("@userYesScore", SqlDbType.Int,4),
                    new SqlParameter("@headimgurl", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.password;
			parameters[1].Value = model.usercard;
			parameters[2].Value = model.openid;
			parameters[3].Value = model.username;
			parameters[4].Value = model.sex;
			parameters[5].Value = model.useraddress;
			parameters[6].Value = model.birthday;
			parameters[7].Value = model.marryday;
			parameters[8].Value = model.telphone;
			parameters[9].Value = model.shopname;
            parameters[10].Value = model.shopcode;
			parameters[11].Value = model.userlevel;
			parameters[12].Value = model.allbuy;
			parameters[13].Value = model.buytimes;
            parameters[14].Value = model.userallscore;
			parameters[15].Value = model.userscore;
			parameters[16].Value = model.updatetime;
			parameters[17].Value = model.isSign;
			parameters[18].Value = model.isbind;
			parameters[19].Value = model.latitude;
			parameters[20].Value = model.longitude;
			parameters[21].Value = model.userMoney;
            parameters[22].Value = model.userYesScore;
            parameters[23].Value = model.headimgurl;
			parameters[24].Value = model.id;

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
			strSql.Append("delete from C_user ");
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
			strSql.Append("delete from C_user ");
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
		public Cms.Model.C_user GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,password,usercard,openid,username,sex,useraddress,birthday,marryday,telphone,shopname,shopcode,userlevel,allbuy,buytimes,userallscore,userscore,updatetime,isSign,isbind,latitude,longitude,userMoney,userYesScore,headimgurl from C_user ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_user model=new Cms.Model.C_user();
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
		public Cms.Model.C_user DataRowToModel(DataRow row)
		{
			Cms.Model.C_user model=new Cms.Model.C_user();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["usercard"]!=null)
				{
					model.usercard=row["usercard"].ToString();
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["sex"]!=null)
				{
					model.sex=row["sex"].ToString();
				}
				if(row["useraddress"]!=null)
				{
					model.useraddress=row["useraddress"].ToString();
				}
				if(row["birthday"]!=null && row["birthday"].ToString()!="")
				{
					model.birthday=DateTime.Parse(row["birthday"].ToString());
				}
				if(row["marryday"]!=null && row["marryday"].ToString()!="")
				{
					model.marryday=DateTime.Parse(row["marryday"].ToString());
				}
				if(row["telphone"]!=null)
				{
					model.telphone=row["telphone"].ToString();
				}
				if(row["shopname"]!=null)
				{
					model.shopname=row["shopname"].ToString();
				}
                if (row["shopcode"] != null)
                {
                    model.shopcode = row["shopcode"].ToString();
                }
				if(row["userlevel"]!=null)
				{
					model.userlevel=row["userlevel"].ToString();
				}
				if(row["allbuy"]!=null && row["allbuy"].ToString()!="")
				{
					model.allbuy=decimal.Parse(row["allbuy"].ToString());
				}
				if(row["buytimes"]!=null && row["buytimes"].ToString()!="")
				{
					model.buytimes=int.Parse(row["buytimes"].ToString());
				}
                if (row["userallscore"] != null && row["userallscore"].ToString() != "")
                {
                    model.userallscore = int.Parse(row["userallscore"].ToString());
                }
				if(row["userscore"]!=null && row["userscore"].ToString()!="")
				{
					model.userscore=int.Parse(row["userscore"].ToString());
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
				}
				if(row["isSign"]!=null && row["isSign"].ToString()!="")
				{
					model.isSign=int.Parse(row["isSign"].ToString());
				}
				if(row["isbind"]!=null && row["isbind"].ToString()!="")
				{
					model.isbind=int.Parse(row["isbind"].ToString());
				}
				if(row["latitude"]!=null)
				{
					model.latitude=row["latitude"].ToString();
				}
				if(row["longitude"]!=null)
				{
					model.longitude=row["longitude"].ToString();
				}
				if(row["userMoney"]!=null && row["userMoney"].ToString()!="")
				{
					model.userMoney=decimal.Parse(row["userMoney"].ToString());
				}
                if (row["userYesScore"] != null && row["userYesScore"].ToString() != "")
				{
                    model.userYesScore = int.Parse(row["userYesScore"].ToString());
				}
                if (row["headimgurl"] != null)
                {
                    model.headimgurl = row["headimgurl"].ToString();
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
            strSql.Append("select id,password,usercard,openid,username,sex,useraddress,birthday,marryday,telphone,shopname,shopcode,userlevel,allbuy,buytimes,userallscore,userscore,updatetime,isSign,isbind,latitude,longitude,userMoney,userYesScore,headimgurl ");
			strSql.Append(" FROM C_user ");
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
            strSql.Append(" id,password,usercard,openid,username,sex,useraddress,birthday,marryday,telphone,shopname,shopcode,userlevel,allbuy,buytimes,userallscore,userscore,updatetime,isSign,isbind,latitude,longitude,userMoney,userYesScore,headimgurl ");
			strSql.Append(" FROM C_user ");
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
			strSql.Append("select count(1) FROM C_user ");
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
			strSql.Append(")AS Row, T.*  from C_user T ");
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
			parameters[0].Value = "C_user";
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

