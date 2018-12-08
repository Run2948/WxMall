/**  版本信息模板在安装目录下，可自行修改。
* C_type.cs
*
* 功 能： N/A
* 类 名： C_type
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/4 16:54:24   N/A    初版
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
	/// 数据访问类:C_type
	/// </summary>
	public partial class C_type
	{
		public C_type()
		{}
		#region  BasicMethod
        #region 取得所有类别列表==============================================
        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetList(int parent_id, int channel_id, string Where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  C_type");
            strSql.Append(" " + Where + " order by sort_id asc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parent_id, channel_id);
            return newData;
        }


        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parent_id, int channel_id)
        {
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = int.Parse(dr[i]["id"].ToString());
                row["channel_id"] = int.Parse(dr[i]["channel_id"].ToString());
                row["title"] = dr[i]["title"].ToString();
                row["call_index"] = dr[i]["call_index"].ToString();
                row["parent_id"] = int.Parse(dr[i]["parent_id"].ToString());
                row["class_list"] = dr[i]["class_list"].ToString();
                row["class_layer"] = int.Parse(dr[i]["class_layer"].ToString());
                row["sort_id"] = int.Parse(dr[i]["sort_id"].ToString());
                row["link_url"] = dr[i]["link_url"].ToString();
                row["img_url"] = dr[i]["img_url"].ToString();
                row["content"] = dr[i]["content"].ToString();
               
                row["isRecommend"] = dr[i]["isRecommend"].ToString();
                row["isChannel"] = dr[i]["isChannel"].ToString();
                row["isHidden"] = dr[i]["isHidden"].ToString();
                row["isCheck"] = dr[i]["isCheck"].ToString();
                row["isHot"] = dr[i]["isHot"].ToString();
                row["isTop"] = dr[i]["isTop"].ToString();
                row["is_msg"] = dr[i]["is_msg"].ToString();
                row["is_slide"] = dr[i]["is_slide"].ToString();
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()), channel_id);
            }
        }
        #endregion
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_type"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_type");
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
		public int Add(Cms.Model.C_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_type(");
			strSql.Append("channel_id,title,call_index,parent_id,class_list,class_layer,sort_id,link_url,img_url,content,isRecommend,isChannel,isHidden,isCheck,isHot,isTop,is_msg,is_slide)");
			strSql.Append(" values (");
			strSql.Append("@channel_id,@title,@call_index,@parent_id,@class_list,@class_layer,@sort_id,@link_url,@img_url,@content,@isRecommend,@isChannel,@isHidden,@isCheck,@isHot,@isTop,@is_msg,@is_slide)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@call_index", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					new SqlParameter("@class_layer", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@isRecommend", SqlDbType.Int,4),
					new SqlParameter("@isChannel", SqlDbType.VarChar,350),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isTop", SqlDbType.Int,4),
					new SqlParameter("@is_msg", SqlDbType.Int,4),
					new SqlParameter("@is_slide", SqlDbType.Int,4)};
			parameters[0].Value = model.channel_id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.call_index;
			parameters[3].Value = model.parent_id;
			parameters[4].Value = model.class_list;
			parameters[5].Value = model.class_layer;
			parameters[6].Value = model.sort_id;
			parameters[7].Value = model.link_url;
			parameters[8].Value = model.img_url;
			parameters[9].Value = model.content;
			parameters[10].Value = model.isRecommend;
			parameters[11].Value = model.isChannel;
			parameters[12].Value = model.isHidden;
			parameters[13].Value = model.isCheck;
			parameters[14].Value = model.isHot;
			parameters[15].Value = model.isTop;
			parameters[16].Value = model.is_msg;
			parameters[17].Value = model.is_slide;

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
		public bool Update(Cms.Model.C_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_type set ");
			strSql.Append("channel_id=@channel_id,");
			strSql.Append("title=@title,");
			strSql.Append("call_index=@call_index,");
			strSql.Append("parent_id=@parent_id,");
			strSql.Append("class_list=@class_list,");
			strSql.Append("class_layer=@class_layer,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("link_url=@link_url,");
			strSql.Append("img_url=@img_url,");
			strSql.Append("content=@content,");
			strSql.Append("isRecommend=@isRecommend,");
			strSql.Append("isChannel=@isChannel,");
			strSql.Append("isHidden=@isHidden,");
			strSql.Append("isCheck=@isCheck,");
			strSql.Append("isHot=@isHot,");
			strSql.Append("isTop=@isTop,");
			strSql.Append("is_msg=@is_msg,");
			strSql.Append("is_slide=@is_slide");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@call_index", SqlDbType.NVarChar,50),
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					new SqlParameter("@class_layer", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@isRecommend", SqlDbType.Int,4),
					new SqlParameter("@isChannel", SqlDbType.VarChar,350),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isTop", SqlDbType.Int,4),
					new SqlParameter("@is_msg", SqlDbType.Int,4),
					new SqlParameter("@is_slide", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.channel_id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.call_index;
			parameters[3].Value = model.parent_id;
			parameters[4].Value = model.class_list;
			parameters[5].Value = model.class_layer;
			parameters[6].Value = model.sort_id;
			parameters[7].Value = model.link_url;
			parameters[8].Value = model.img_url;
			parameters[9].Value = model.content;
			parameters[10].Value = model.isRecommend;
			parameters[11].Value = model.isChannel;
			parameters[12].Value = model.isHidden;
			parameters[13].Value = model.isCheck;
			parameters[14].Value = model.isHot;
			parameters[15].Value = model.isTop;
			parameters[16].Value = model.is_msg;
			parameters[17].Value = model.is_slide;
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
			strSql.Append("delete from C_type ");
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
			strSql.Append("delete from C_type ");
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
		public Cms.Model.C_type GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,channel_id,title,call_index,parent_id,class_list,class_layer,sort_id,link_url,img_url,content,isRecommend,isChannel,isHidden,isCheck,isHot,isTop,is_msg,is_slide from C_type ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_type model=new Cms.Model.C_type();
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
		public Cms.Model.C_type DataRowToModel(DataRow row)
		{
			Cms.Model.C_type model=new Cms.Model.C_type();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["channel_id"]!=null && row["channel_id"].ToString()!="")
				{
					model.channel_id=int.Parse(row["channel_id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["call_index"]!=null)
				{
					model.call_index=row["call_index"].ToString();
				}
				if(row["parent_id"]!=null && row["parent_id"].ToString()!="")
				{
					model.parent_id=int.Parse(row["parent_id"].ToString());
				}
				if(row["class_list"]!=null)
				{
					model.class_list=row["class_list"].ToString();
				}
				if(row["class_layer"]!=null && row["class_layer"].ToString()!="")
				{
					model.class_layer=int.Parse(row["class_layer"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["link_url"]!=null)
				{
					model.link_url=row["link_url"].ToString();
				}
				if(row["img_url"]!=null)
				{
					model.img_url=row["img_url"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["isRecommend"]!=null && row["isRecommend"].ToString()!="")
				{
					model.isRecommend=int.Parse(row["isRecommend"].ToString());
				}
				if(row["isChannel"]!=null)
				{
					model.isChannel=row["isChannel"].ToString();
				}
				if(row["isHidden"]!=null && row["isHidden"].ToString()!="")
				{
					model.isHidden=int.Parse(row["isHidden"].ToString());
				}
				if(row["isCheck"]!=null && row["isCheck"].ToString()!="")
				{
					model.isCheck=int.Parse(row["isCheck"].ToString());
				}
				if(row["isHot"]!=null && row["isHot"].ToString()!="")
				{
					model.isHot=int.Parse(row["isHot"].ToString());
				}
				if(row["isTop"]!=null && row["isTop"].ToString()!="")
				{
					model.isTop=int.Parse(row["isTop"].ToString());
				}
				if(row["is_msg"]!=null && row["is_msg"].ToString()!="")
				{
					model.is_msg=int.Parse(row["is_msg"].ToString());
				}
				if(row["is_slide"]!=null && row["is_slide"].ToString()!="")
				{
					model.is_slide=int.Parse(row["is_slide"].ToString());
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
			strSql.Append("select id,channel_id,title,call_index,parent_id,class_list,class_layer,sort_id,link_url,img_url,content,isRecommend,isChannel,isHidden,isCheck,isHot,isTop,is_msg,is_slide ");
			strSql.Append(" FROM C_type ");
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
			strSql.Append(" id,channel_id,title,call_index,parent_id,class_list,class_layer,sort_id,link_url,img_url,content,isRecommend,isChannel,isHidden,isCheck,isHot,isTop,is_msg,is_slide ");
			strSql.Append(" FROM C_type ");
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
			strSql.Append("select count(1) FROM C_type ");
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
			strSql.Append(")AS Row, T.*  from C_type T ");
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
			parameters[0].Value = "C_type";
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

