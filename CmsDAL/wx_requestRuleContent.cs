using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;
using System.Collections.Generic;
using Cms.Common;//Please add references
namespace Cms.DAL
{
	/// <summary>
	/// 数据访问类:wx_requestRuleContent
	/// </summary>
	public partial class wx_requestRuleContent
	{
		public wx_requestRuleContent()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_requestRuleContent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_requestRuleContent");
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
		public int Add(Cms.Model.wx_requestRuleContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_requestRuleContent(");
			strSql.Append("uId,rId,rContent,rContent2,detailUrl,picUrl,mediaUrl,meidaHDUrl,remark,seq,createDate,extInt,extInt2,extStr,extStr2,extstr3)");
			strSql.Append(" values (");
			strSql.Append("@uId,@rId,@rContent,@rContent2,@detailUrl,@picUrl,@mediaUrl,@meidaHDUrl,@remark,@seq,@createDate,@extInt,@extInt2,@extStr,@extStr2,@extstr3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.Int,4),
					new SqlParameter("@rId", SqlDbType.Int,4),
					new SqlParameter("@rContent", SqlDbType.Text),
					new SqlParameter("@rContent2", SqlDbType.VarChar,2000),
					new SqlParameter("@detailUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@picUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@mediaUrl", SqlDbType.VarChar,1500),
					new SqlParameter("@meidaHDUrl", SqlDbType.VarChar,1500),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extInt2", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,800),
					new SqlParameter("@extStr2", SqlDbType.VarChar,1000),
					new SqlParameter("@extstr3", SqlDbType.VarChar,1500)};
			parameters[0].Value = model.uId;
			parameters[1].Value = model.rId;
			parameters[2].Value = model.rContent;
			parameters[3].Value = model.rContent2;
			parameters[4].Value = model.detailUrl;
			parameters[5].Value = model.picUrl;
			parameters[6].Value = model.mediaUrl;
			parameters[7].Value = model.meidaHDUrl;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.seq;
			parameters[10].Value = model.createDate;
			parameters[11].Value = model.extInt;
			parameters[12].Value = model.extInt2;
			parameters[13].Value = model.extStr;
			parameters[14].Value = model.extStr2;
			parameters[15].Value = model.extstr3;

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
		public bool Update(Cms.Model.wx_requestRuleContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_requestRuleContent set ");
			strSql.Append("uId=@uId,");
			strSql.Append("rId=@rId,");
			strSql.Append("rContent=@rContent,");
			strSql.Append("rContent2=@rContent2,");
			strSql.Append("detailUrl=@detailUrl,");
			strSql.Append("picUrl=@picUrl,");
			strSql.Append("mediaUrl=@mediaUrl,");
			strSql.Append("meidaHDUrl=@meidaHDUrl,");
			strSql.Append("remark=@remark,");
			strSql.Append("seq=@seq,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extInt2=@extInt2,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2,");
			strSql.Append("extstr3=@extstr3");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@uId", SqlDbType.Int,4),
					new SqlParameter("@rId", SqlDbType.Int,4),
					new SqlParameter("@rContent", SqlDbType.Text),
					new SqlParameter("@rContent2", SqlDbType.VarChar,2000),
					new SqlParameter("@detailUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@picUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@mediaUrl", SqlDbType.VarChar,1500),
					new SqlParameter("@meidaHDUrl", SqlDbType.VarChar,1500),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extInt2", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,800),
					new SqlParameter("@extStr2", SqlDbType.VarChar,1000),
					new SqlParameter("@extstr3", SqlDbType.VarChar,1500),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.uId;
			parameters[1].Value = model.rId;
			parameters[2].Value = model.rContent;
			parameters[3].Value = model.rContent2;
			parameters[4].Value = model.detailUrl;
			parameters[5].Value = model.picUrl;
			parameters[6].Value = model.mediaUrl;
			parameters[7].Value = model.meidaHDUrl;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.seq;
			parameters[10].Value = model.createDate;
			parameters[11].Value = model.extInt;
			parameters[12].Value = model.extInt2;
			parameters[13].Value = model.extStr;
			parameters[14].Value = model.extStr2;
			parameters[15].Value = model.extstr3;
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
			strSql.Append("delete from wx_requestRuleContent ");
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
			strSql.Append("delete from wx_requestRuleContent ");
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
		public Cms.Model.wx_requestRuleContent GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,uId,rId,rContent,rContent2,detailUrl,picUrl,mediaUrl,meidaHDUrl,remark,seq,createDate,extInt,extInt2,extStr,extStr2,extstr3 from wx_requestRuleContent ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.wx_requestRuleContent model=new Cms.Model.wx_requestRuleContent();
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
		public Cms.Model.wx_requestRuleContent DataRowToModel(DataRow row)
		{
			Cms.Model.wx_requestRuleContent model=new Cms.Model.wx_requestRuleContent();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["uId"]!=null && row["uId"].ToString()!="")
				{
					model.uId=int.Parse(row["uId"].ToString());
				}
				if(row["rId"]!=null && row["rId"].ToString()!="")
				{
					model.rId=int.Parse(row["rId"].ToString());
				}
				if(row["rContent"]!=null)
				{
					model.rContent=row["rContent"].ToString();
				}
				if(row["rContent2"]!=null)
				{
					model.rContent2=row["rContent2"].ToString();
				}
				if(row["detailUrl"]!=null)
				{
					model.detailUrl=row["detailUrl"].ToString();
				}
				if(row["picUrl"]!=null)
				{
					model.picUrl=row["picUrl"].ToString();
				}
				if(row["mediaUrl"]!=null)
				{
					model.mediaUrl=row["mediaUrl"].ToString();
				}
				if(row["meidaHDUrl"]!=null)
				{
					model.meidaHDUrl=row["meidaHDUrl"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["extInt"]!=null && row["extInt"].ToString()!="")
				{
					model.extInt=int.Parse(row["extInt"].ToString());
				}
				if(row["extInt2"]!=null && row["extInt2"].ToString()!="")
				{
					model.extInt2=int.Parse(row["extInt2"].ToString());
				}
				if(row["extStr"]!=null)
				{
					model.extStr=row["extStr"].ToString();
				}
				if(row["extStr2"]!=null)
				{
					model.extStr2=row["extStr2"].ToString();
				}
				if(row["extstr3"]!=null)
				{
					model.extstr3=row["extstr3"].ToString();
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
			strSql.Append("select id,uId,rId,rContent,rContent2,detailUrl,picUrl,mediaUrl,meidaHDUrl,remark,seq,createDate,extInt,extInt2,extStr,extStr2,extstr3 ");
			strSql.Append(" FROM wx_requestRuleContent ");
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
			strSql.Append(" id,uId,rId,rContent,rContent2,detailUrl,picUrl,mediaUrl,meidaHDUrl,remark,seq,createDate,extInt,extInt2,extStr,extStr2,extstr3 ");
			strSql.Append(" FROM wx_requestRuleContent ");
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
			strSql.Append("select count(1) FROM wx_requestRuleContent ");
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
			strSql.Append(")AS Row, T.*  from wx_requestRuleContent T ");
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
			parameters[0].Value = "wx_requestRuleContent";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
	 

        #region 微信端获取数据，需要提升效率

        /// <summary>
        /// 得到回复规则的纯文本信息
        /// </summary>
        /// <param name="rid">规则主键Id</param>
        /// <returns></returns>
        public string  GetTxtContent(int rid)
        {
            string  ret = "";
          
            string sql="select  top 1 rContent from wx_requestRuleContent where rid="+rid;
            
            SqlDataReader sr = DbHelperSQL.ExecuteReader(sql);

            while (sr.Read())
            {
                ret = sr["rContent"].ToString();
            }
            sr.Close();

            return ret;
        }

        /// <summary>
        /// 2014-9-18新增抽奖功能
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public string GetTxtContent(string openid)
        {
            int ret = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@open_id", SqlDbType.VarChar,50),
                    new SqlParameter("@id",SqlDbType.Int,4),
			};
            parameters[0].Value = openid;
            parameters[1].Value = 0;
            parameters[1].Direction = ParameterDirection.Output;

            SqlDataReader sr = DbHelperSQL.RunProcedure("[saveOpenid_queryName]", parameters);
   
            sr.Close();
            ret = MyCommFun.Obj2Int(parameters[1].Value);
           
            return ret.ToString();
        }
        /// <summary>
        /// 得到回复规则的语音信息
        /// </summary>
        /// <param name="rid">规则主键Id</param>
        /// <returns></returns>
        public Cms.Model.wx_requestRuleContent GetMusicContent(int rid)
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  rContent,rContent2 ,mediaUrl from wx_requestRuleContent ");
            strSql.Append(" where rid=@rid");
            SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4)
			};
            parameters[0].Value = rid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(),parameters);
            Cms.Model.wx_requestRuleContent model = new Cms.Model.wx_requestRuleContent();
            while (sr.Read())
            {
                model.rContent = sr["rContent"].ToString();
                model.rContent2 = sr["rContent2"].ToString();
                model.mediaUrl = sr["mediaUrl"].ToString();
            }
            sr.Close();

            return model;
        }

        /// <summary>
        /// 得到回复规则的【图文】信息
        /// </summary>
        /// <param name="rid">规则主键Id</param>
        /// <returns></returns>
        public IList<Cms.Model.wx_requestRuleContent> GetTuWenContent(int rid)
        {
            IList<Cms.Model.wx_requestRuleContent> rcList = new List<Model.wx_requestRuleContent>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 10  rContent,rContent2 ,picUrl,detailUrl from wx_requestRuleContent ");
            strSql.Append(" where rid=@rid order by seq asc");
            SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4)
			};
            
            parameters[0].Value = rid;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            Cms.Model.wx_requestRuleContent model = new Cms.Model.wx_requestRuleContent();
            while (sr.Read())
            {
                model = new Cms.Model.wx_requestRuleContent();
                model.rContent = sr["rContent"].ToString();
                model.rContent2 = sr["rContent2"].ToString();
                model.picUrl = sr["picUrl"].ToString();
                model.detailUrl = sr["detailUrl"].ToString();
                rcList.Add(model);
            }
            sr.Close();

            return rcList;
        }



        #endregion


       
    }
}

