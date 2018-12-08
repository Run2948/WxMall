/**  版本信息模板在安装目录下，可自行修改。
* C_article_attribute_field.cs
*
* 功 能： N/A
* 类 名： C_article_attribute_field
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/5 17:08:16   N/A    初版
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
using System.Collections.Generic;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:C_article_attribute_field
	/// </summary>
	public partial class C_article_attribute_field
	{
		public C_article_attribute_field()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_article_attribute_field"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_article_attribute_field");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 查询是否存在列
        /// </summary>
        public bool Exists(string column_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_article_attribute_field");
            strSql.Append(" where name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100)};
            parameters[0].Value = column_name;

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select count(0) from syscolumns");
            strSql2.Append(" where id=object_id('C_article') and name=@name ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@name", SqlDbType.NVarChar,100)};
            parameters2[0].Value = column_name;

            if (DbHelperSQL.Exists(strSql.ToString(), parameters) || DbHelperSQL.Exists(strSql2.ToString(), parameters2))
            {
                return true;
            }
            return false;
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_article_attribute_field model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_article_attribute_field(");
			strSql.Append("name,title,control_type,data_type,data_length,data_place,item_option,default_value,is_required,is_password,is_html,editor_type,valid_tip_msg,valid_error_msg,valid_pattern,sort_id,is_sys)");
			strSql.Append(" values (");
			strSql.Append("@name,@title,@control_type,@data_type,@data_length,@data_place,@item_option,@default_value,@is_required,@is_password,@is_html,@editor_type,@valid_tip_msg,@valid_error_msg,@valid_pattern,@sort_id,@is_sys)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@control_type", SqlDbType.NVarChar,50),
					new SqlParameter("@data_type", SqlDbType.NVarChar,50),
					new SqlParameter("@data_length", SqlDbType.Int,4),
					new SqlParameter("@data_place", SqlDbType.TinyInt,1),
					new SqlParameter("@item_option", SqlDbType.NText),
					new SqlParameter("@default_value", SqlDbType.NText),
					new SqlParameter("@is_required", SqlDbType.TinyInt,1),
					new SqlParameter("@is_password", SqlDbType.TinyInt,1),
					new SqlParameter("@is_html", SqlDbType.TinyInt,1),
					new SqlParameter("@editor_type", SqlDbType.TinyInt,1),
					new SqlParameter("@valid_tip_msg", SqlDbType.NVarChar,255),
					new SqlParameter("@valid_error_msg", SqlDbType.NVarChar,255),
					new SqlParameter("@valid_pattern", SqlDbType.NVarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
            new SqlParameter("@ReturnValue",SqlDbType.Int)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.title;
			parameters[2].Value = model.control_type;
			parameters[3].Value = model.data_type;
			parameters[4].Value = model.data_length;
			parameters[5].Value = model.data_place;
			parameters[6].Value = model.item_option;
			parameters[7].Value = model.default_value;
			parameters[8].Value = model.is_required;
			parameters[9].Value = model.is_password;
			parameters[10].Value = model.is_html;
			parameters[11].Value = model.editor_type;
			parameters[12].Value = model.valid_tip_msg;
			parameters[13].Value = model.valid_error_msg;
			parameters[14].Value = model.valid_pattern;
			parameters[15].Value = model.sort_id;
			parameters[16].Value = model.is_sys;

            parameters[17].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //增加扩展字段表中一列
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("alter table C_article_attribute_value add " + model.name + " " + model.data_type);
            SqlParameter[] parameters2 = { };
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[17].Value;

		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Cms.Model.C_article_attribute_field model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_article_attribute_field set ");
			strSql.Append("name=@name,");
			strSql.Append("title=@title,");
			strSql.Append("control_type=@control_type,");
			strSql.Append("data_type=@data_type,");
			strSql.Append("data_length=@data_length,");
			strSql.Append("data_place=@data_place,");
			strSql.Append("item_option=@item_option,");
			strSql.Append("default_value=@default_value,");
			strSql.Append("is_required=@is_required,");
			strSql.Append("is_password=@is_password,");
			strSql.Append("is_html=@is_html,");
			strSql.Append("editor_type=@editor_type,");
			strSql.Append("valid_tip_msg=@valid_tip_msg,");
			strSql.Append("valid_error_msg=@valid_error_msg,");
			strSql.Append("valid_pattern=@valid_pattern,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("is_sys=@is_sys");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@control_type", SqlDbType.NVarChar,50),
					new SqlParameter("@data_type", SqlDbType.NVarChar,50),
					new SqlParameter("@data_length", SqlDbType.Int,4),
					new SqlParameter("@data_place", SqlDbType.TinyInt,1),
					new SqlParameter("@item_option", SqlDbType.NText),
					new SqlParameter("@default_value", SqlDbType.NText),
					new SqlParameter("@is_required", SqlDbType.TinyInt,1),
					new SqlParameter("@is_password", SqlDbType.TinyInt,1),
					new SqlParameter("@is_html", SqlDbType.TinyInt,1),
					new SqlParameter("@editor_type", SqlDbType.TinyInt,1),
					new SqlParameter("@valid_tip_msg", SqlDbType.NVarChar,255),
					new SqlParameter("@valid_error_msg", SqlDbType.NVarChar,255),
					new SqlParameter("@valid_pattern", SqlDbType.NVarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.title;
			parameters[2].Value = model.control_type;
			parameters[3].Value = model.data_type;
			parameters[4].Value = model.data_length;
			parameters[5].Value = model.data_place;
			parameters[6].Value = model.item_option;
			parameters[7].Value = model.default_value;
			parameters[8].Value = model.is_required;
			parameters[9].Value = model.is_password;
			parameters[10].Value = model.is_html;
			parameters[11].Value = model.editor_type;
			parameters[12].Value = model.valid_tip_msg;
			parameters[13].Value = model.valid_error_msg;
			parameters[14].Value = model.valid_pattern;
			parameters[15].Value = model.sort_id;
			parameters[16].Value = model.is_sys;
			parameters[17].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

            //修改扩展字段表中一列
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("alter table C_article_attribute_value alter column " + model.name + " " + model.data_type);
            DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString());
            //没有错误确认事务
            trans.Commit();
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
			
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
            //StringBuilder strSql=new StringBuilder();
            //strSql.Append("delete from C_article_attribute_field ");
            //strSql.Append(" where id=@id");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@id", SqlDbType.Int,4)
            //};
            //parameters[0].Value = id;

            //int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            //取得Model信息
            Model.C_article_attribute_field model = GetModel(id);
            //开始删除
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //查找关联的频道ID，得到后以备使用
                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append("select channel_id,field_id from C_Column_field");
                        strSql1.Append(" where field_id=@field_id");
                        SqlParameter[] parameters1 = {
					            new SqlParameter("@field_id", SqlDbType.Int,4)};
                        parameters1[0].Value = id;
                        DataTable dt = DbHelperSQL.Query(conn, trans, strSql1.ToString(), parameters1).Tables[0];

                        //删除频道关联的字段表
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("delete from C_Column_field");
                        strSql2.Append(" where field_id=@field_id");
                        SqlParameter[] parameters2 = {
					            new SqlParameter("@field_id", SqlDbType.Int,4)};
                        parameters2[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);

                        //重建对应频道的视图
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Model.C_Column modelt = new SQLServerDAL .C_Column().GetModel(conn, trans, int.Parse(dr["channel_id"].ToString()));
                                if (modelt != null)
                                {
                                    new SQLServerDAL.C_Column().RehabChannelViews(conn, trans, modelt, modelt.name);
                                }
                            }
                        }

                        //删除主表
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("delete from C_article_attribute_field ");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除扩展字段表中一列
                        DbHelperSQL.ExecuteSql(conn, trans, "alter table C_article_attribute_value drop column " + model.name);

                        //没有错误确认事务
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_article_attribute_field ");
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
		public Cms.Model.C_article_attribute_field GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,title,control_type,data_type,data_length,data_place,item_option,default_value,is_required,is_password,is_html,editor_type,valid_tip_msg,valid_error_msg,valid_pattern,sort_id,is_sys from C_article_attribute_field ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_article_attribute_field model=new Cms.Model.C_article_attribute_field();
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
		public Cms.Model.C_article_attribute_field DataRowToModel(DataRow row)
		{
			Cms.Model.C_article_attribute_field model=new Cms.Model.C_article_attribute_field();
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
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["control_type"]!=null)
				{
					model.control_type=row["control_type"].ToString();
				}
				if(row["data_type"]!=null)
				{
					model.data_type=row["data_type"].ToString();
				}
				if(row["data_length"]!=null && row["data_length"].ToString()!="")
				{
					model.data_length=int.Parse(row["data_length"].ToString());
				}
				if(row["data_place"]!=null && row["data_place"].ToString()!="")
				{
					model.data_place=int.Parse(row["data_place"].ToString());
				}
				if(row["item_option"]!=null)
				{
					model.item_option=row["item_option"].ToString();
				}
				if(row["default_value"]!=null)
				{
					model.default_value=row["default_value"].ToString();
				}
				if(row["is_required"]!=null && row["is_required"].ToString()!="")
				{
					model.is_required=int.Parse(row["is_required"].ToString());
				}
				if(row["is_password"]!=null && row["is_password"].ToString()!="")
				{
					model.is_password=int.Parse(row["is_password"].ToString());
				}
				if(row["is_html"]!=null && row["is_html"].ToString()!="")
				{
					model.is_html=int.Parse(row["is_html"].ToString());
				}
				if(row["editor_type"]!=null && row["editor_type"].ToString()!="")
				{
					model.editor_type=int.Parse(row["editor_type"].ToString());
				}
				if(row["valid_tip_msg"]!=null)
				{
					model.valid_tip_msg=row["valid_tip_msg"].ToString();
				}
				if(row["valid_error_msg"]!=null)
				{
					model.valid_error_msg=row["valid_error_msg"].ToString();
				}
				if(row["valid_pattern"]!=null)
				{
					model.valid_pattern=row["valid_pattern"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["is_sys"]!=null && row["is_sys"].ToString()!="")
				{
					model.is_sys=int.Parse(row["is_sys"].ToString());
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
			strSql.Append("select id,name,title,control_type,data_type,data_length,data_place,item_option,default_value,is_required,is_password,is_html,editor_type,valid_tip_msg,valid_error_msg,valid_pattern,sort_id,is_sys ");
			strSql.Append(" FROM C_article_attribute_field ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        #region 获得频道对应的数据=====================
        /// <summary>
        /// 获得频道对应的数据
        /// </summary>
        public DataSet GetList(int channel_id, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_article_attribute_field.* ");
            strSql.Append(" FROM C_article_attribute_field INNER JOIN C_Column_field ON C_article_attribute_field.id = C_Column_field.field_id");
            strSql.Append(" where channel_id=" + channel_id);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by sort_id desc,C_article_attribute_field.id desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

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
			strSql.Append(" id,name,title,control_type,data_type,data_length,data_place,item_option,default_value,is_required,is_password,is_html,editor_type,valid_tip_msg,valid_error_msg,valid_pattern,sort_id,is_sys ");
			strSql.Append(" FROM C_article_attribute_field ");
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
			strSql.Append("select count(1) FROM C_article_attribute_field ");
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
			strSql.Append(")AS Row, T.*  from C_article_attribute_field T ");
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
			parameters[0].Value = "C_article_attribute_field";
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

