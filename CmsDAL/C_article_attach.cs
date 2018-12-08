/**  版本信息模板在安装目录下，可自行修改。
* C_article_attach.cs
*
* 功 能： N/A
* 类 名： C_article_attach
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/11 15:23:01   N/A    初版
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
using Cms.DBUtility;
using System.Collections.Generic;
using Cms.Common;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:C_article_attach
	/// </summary>
	public partial class C_article_attach
	{
		public C_article_attach()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_article_attach"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_article_attach");
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
		public int Add(Cms.Model.C_article_attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_article_attach(");
			strSql.Append("article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time)");
			strSql.Append(" values (");
			strSql.Append("@article_id,@file_name,@file_path,@file_size,@file_ext,@down_num,@point,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@file_name", SqlDbType.NVarChar,100),
					new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					new SqlParameter("@file_size", SqlDbType.Int,4),
					new SqlParameter("@file_ext", SqlDbType.NVarChar,20),
					new SqlParameter("@down_num", SqlDbType.Int,4),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
			parameters[0].Value = model.article_id;
			parameters[1].Value = model.file_name;
			parameters[2].Value = model.file_path;
			parameters[3].Value = model.file_size;
			parameters[4].Value = model.file_ext;
			parameters[5].Value = model.down_num;
			parameters[6].Value = model.point;
			parameters[7].Value = model.add_time;

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
		public bool Update(Cms.Model.C_article_attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_article_attach set ");
			strSql.Append("article_id=@article_id,");
			strSql.Append("file_name=@file_name,");
			strSql.Append("file_path=@file_path,");
			strSql.Append("file_size=@file_size,");
			strSql.Append("file_ext=@file_ext,");
			strSql.Append("down_num=@down_num,");
			strSql.Append("point=@point,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@file_name", SqlDbType.NVarChar,100),
					new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					new SqlParameter("@file_size", SqlDbType.Int,4),
					new SqlParameter("@file_ext", SqlDbType.NVarChar,20),
					new SqlParameter("@down_num", SqlDbType.Int,4),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.article_id;
			parameters[1].Value = model.file_name;
			parameters[2].Value = model.file_path;
			parameters[3].Value = model.file_size;
			parameters[4].Value = model.file_ext;
			parameters[5].Value = model.down_num;
			parameters[6].Value = model.point;
			parameters[7].Value = model.add_time;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from C_article_attach ");
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
        /// 获得数据列表
        /// </summary>
        public List<Model.C_article_attach> GetList(int article_id)
        {
            List<Model.C_article_attach> modelList = new List<Model.C_article_attach>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time ");
            strSql.Append(" FROM C_article_attach ");
            strSql.Append(" where article_id=" + article_id);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.C_article_attach model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.C_article_attach();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["article_id"] != null && dt.Rows[n]["article_id"].ToString() != "")
                    {
                        model.article_id = int.Parse(dt.Rows[n]["article_id"].ToString());
                    }
                    if (dt.Rows[n]["file_name"] != null && dt.Rows[n]["file_name"].ToString() != "")
                    {
                        model.file_name = dt.Rows[n]["file_name"].ToString();
                    }
                    if (dt.Rows[n]["file_path"] != null && dt.Rows[n]["file_path"].ToString() != "")
                    {
                        model.file_path = dt.Rows[n]["file_path"].ToString();
                    }
                    if (dt.Rows[n]["file_ext"] != null && dt.Rows[n]["file_ext"].ToString() != "")
                    {
                        model.file_ext = dt.Rows[n]["file_ext"].ToString();
                    }
                    if (dt.Rows[n]["file_size"] != null && dt.Rows[n]["file_size"].ToString() != "")
                    {
                        model.file_size = int.Parse(dt.Rows[n]["file_size"].ToString());
                    }
                    if (dt.Rows[n]["down_num"] != null && dt.Rows[n]["down_num"].ToString() != "")
                    {
                        model.down_num = int.Parse(dt.Rows[n]["down_num"].ToString());
                    }
                    if (dt.Rows[n]["point"] != null && dt.Rows[n]["point"].ToString() != "")
                    {
                        model.point = int.Parse(dt.Rows[n]["point"].ToString());
                    }
                    if (dt.Rows[0]["add_time"].ToString() != "")
                    {
                        model.add_time = DateTime.Parse(dt.Rows[0]["add_time"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 查找不存在的文件并删除已删除的附件及数据
        /// </summary>
        public void DeleteList(SqlConnection conn, SqlTransaction trans, List<Cms.Model.C_article_attach> models, int article_id)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.C_article_attach modelt in models)
                {
                    if (modelt.id > 0)
                    {
                        idList.Append(modelt.id + ",");
                    }
                }
            }
            string id_list = Utils.DelLastChar(idList.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,file_path from C_article_attach where article_id=" + article_id);
            if (!string.IsNullOrEmpty(id_list))
            {
                strSql.Append(" and id not in(" + id_list + ")");
            }
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int rows = DbHelperSQL.ExecuteSql(conn, trans, "delete from C_article_attach where id=" + dr["id"].ToString()); //删除数据库
                if (rows > 0)
                {
                    Utils.DeleteFile(dr["file_path"].ToString()); //删除文件
                }
            }
        }

		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_article_attach ");
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
		public Cms.Model.C_article_attach GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time from C_article_attach ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_article_attach model=new Cms.Model.C_article_attach();
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
		public Cms.Model.C_article_attach DataRowToModel(DataRow row)
		{
			Cms.Model.C_article_attach model=new Cms.Model.C_article_attach();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["file_name"]!=null)
				{
					model.file_name=row["file_name"].ToString();
				}
				if(row["file_path"]!=null)
				{
					model.file_path=row["file_path"].ToString();
				}
				if(row["file_size"]!=null && row["file_size"].ToString()!="")
				{
					model.file_size=int.Parse(row["file_size"].ToString());
				}
				if(row["file_ext"]!=null)
				{
					model.file_ext=row["file_ext"].ToString();
				}
				if(row["down_num"]!=null && row["down_num"].ToString()!="")
				{
					model.down_num=int.Parse(row["down_num"].ToString());
				}
				if(row["point"]!=null && row["point"].ToString()!="")
				{
					model.point=int.Parse(row["point"].ToString());
				}
				if(row["add_time"]!=null && row["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(row["add_time"].ToString());
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
			strSql.Append("select id,article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time ");
			strSql.Append(" FROM C_article_attach ");
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
			strSql.Append(" id,article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time ");
			strSql.Append(" FROM C_article_attach ");
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
			strSql.Append("select count(1) FROM C_article_attach ");
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
			strSql.Append(")AS Row, T.*  from C_article_attach T ");
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
			parameters[0].Value = "C_article_attach";
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

