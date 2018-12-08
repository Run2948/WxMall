using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;
using Cms.Common;//Please add references
namespace Cms.DAL
{
    /// <summary>
    /// 数据访问类:wx_requestRule
    /// </summary>
    public partial class wx_requestRule
    {
        public wx_requestRule()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_requestRule");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_requestRule");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Cms.Model.wx_requestRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_requestRule(");
            strSql.Append("wId,uId,ruleName,reqKeywords,reqestType,responseType,isDefault,modelFunctionName,modelFunctionId,seq,createDate,agentUrl,agentToken,isLikeSearch,extInt,extInt2,extStr,extStr2,extStr3,extStr4)");
            strSql.Append(" values (");
            strSql.Append("@wId,@uId,@ruleName,@reqKeywords,@reqestType,@responseType,@isDefault,@modelFunctionName,@modelFunctionId,@seq,@createDate,@agentUrl,@agentToken,@isLikeSearch,@extInt,@extInt2,@extStr,@extStr2,@extStr3,@extStr4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4),
					new SqlParameter("@uId", SqlDbType.Int,4),
					new SqlParameter("@ruleName", SqlDbType.VarChar,200),
					new SqlParameter("@reqKeywords", SqlDbType.VarChar,2000),
					new SqlParameter("@reqestType", SqlDbType.Int,4),
					new SqlParameter("@responseType", SqlDbType.Int,4),
					new SqlParameter("@isDefault", SqlDbType.Bit,1),
					new SqlParameter("@modelFunctionName", SqlDbType.VarChar,200),
					new SqlParameter("@modelFunctionId", SqlDbType.Int,4),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@agentUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@agentToken", SqlDbType.VarChar,200),
					new SqlParameter("@isLikeSearch", SqlDbType.Bit,1),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extInt2", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,200),
					new SqlParameter("@extStr2", SqlDbType.VarChar,500),
					new SqlParameter("@extStr3", SqlDbType.VarChar,800),
					new SqlParameter("@extStr4", SqlDbType.VarChar,1000)};
            parameters[0].Value = model.wId;
            parameters[1].Value = model.uId;
            parameters[2].Value = model.ruleName;
            parameters[3].Value = model.reqKeywords;
            parameters[4].Value = model.reqestType;
            parameters[5].Value = model.responseType;
            parameters[6].Value = model.isDefault;
            parameters[7].Value = model.modelFunctionName;
            parameters[8].Value = model.modelFunctionId;
            parameters[9].Value = model.seq;
            parameters[10].Value = model.createDate;
            parameters[11].Value = model.agentUrl;
            parameters[12].Value = model.agentToken;
            parameters[13].Value = model.isLikeSearch;
            parameters[14].Value = model.extInt;
            parameters[15].Value = model.extInt2;
            parameters[16].Value = model.extStr;
            parameters[17].Value = model.extStr2;
            parameters[18].Value = model.extStr3;
            parameters[19].Value = model.extStr4;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Cms.Model.wx_requestRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_requestRule set ");
            strSql.Append("wId=@wId,");
            strSql.Append("uId=@uId,");
            strSql.Append("ruleName=@ruleName,");
            strSql.Append("reqKeywords=@reqKeywords,");
            strSql.Append("reqestType=@reqestType,");
            strSql.Append("responseType=@responseType,");
            strSql.Append("isDefault=@isDefault,");
            strSql.Append("modelFunctionName=@modelFunctionName,");
            strSql.Append("modelFunctionId=@modelFunctionId,");
            strSql.Append("seq=@seq,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("agentUrl=@agentUrl,");
            strSql.Append("agentToken=@agentToken,");
            strSql.Append("isLikeSearch=@isLikeSearch,");
            strSql.Append("extInt=@extInt,");
            strSql.Append("extInt2=@extInt2,");
            strSql.Append("extStr=@extStr,");
            strSql.Append("extStr2=@extStr2,");
            strSql.Append("extStr3=@extStr3,");
            strSql.Append("extStr4=@extStr4");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4),
					new SqlParameter("@uId", SqlDbType.Int,4),
					new SqlParameter("@ruleName", SqlDbType.VarChar,200),
					new SqlParameter("@reqKeywords", SqlDbType.VarChar,2000),
					new SqlParameter("@reqestType", SqlDbType.Int,4),
					new SqlParameter("@responseType", SqlDbType.Int,4),
					new SqlParameter("@isDefault", SqlDbType.Bit,1),
					new SqlParameter("@modelFunctionName", SqlDbType.VarChar,200),
					new SqlParameter("@modelFunctionId", SqlDbType.Int,4),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@agentUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@agentToken", SqlDbType.VarChar,200),
					new SqlParameter("@isLikeSearch", SqlDbType.Bit,1),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extInt2", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,200),
					new SqlParameter("@extStr2", SqlDbType.VarChar,500),
					new SqlParameter("@extStr3", SqlDbType.VarChar,800),
					new SqlParameter("@extStr4", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wId;
            parameters[1].Value = model.uId;
            parameters[2].Value = model.ruleName;
            parameters[3].Value = model.reqKeywords;
            parameters[4].Value = model.reqestType;
            parameters[5].Value = model.responseType;
            parameters[6].Value = model.isDefault;
            parameters[7].Value = model.modelFunctionName;
            parameters[8].Value = model.modelFunctionId;
            parameters[9].Value = model.seq;
            parameters[10].Value = model.createDate;
            parameters[11].Value = model.agentUrl;
            parameters[12].Value = model.agentToken;
            parameters[13].Value = model.isLikeSearch;
            parameters[14].Value = model.extInt;
            parameters[15].Value = model.extInt2;
            parameters[16].Value = model.extStr;
            parameters[17].Value = model.extStr2;
            parameters[18].Value = model.extStr3;
            parameters[19].Value = model.extStr4;
            parameters[20].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_requestRule ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_requestRule ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Cms.Model.wx_requestRule GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wId,uId,ruleName,reqKeywords,reqestType,responseType,isDefault,modelFunctionName,modelFunctionId,seq,createDate,agentUrl,agentToken,isLikeSearch,extInt,extInt2,extStr,extStr2,extStr3,extStr4 from wx_requestRule ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Cms.Model.wx_requestRule model = new Cms.Model.wx_requestRule();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Cms.Model.wx_requestRule DataRowToModel(DataRow row)
        {
            Cms.Model.wx_requestRule model = new Cms.Model.wx_requestRule();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["wId"] != null && row["wId"].ToString() != "")
                {
                    model.wId = int.Parse(row["wId"].ToString());
                }

                if (row["uId"] != null && row["uId"].ToString() != "")
                {
                    model.uId = int.Parse(row["uId"].ToString());
                }
                if (row["ruleName"] != null)
                {
                    model.ruleName = row["ruleName"].ToString();
                }
                if (row["reqKeywords"] != null)
                {
                    model.reqKeywords = row["reqKeywords"].ToString();
                }
                if (row["reqestType"] != null && row["reqestType"].ToString() != "")
                {
                    model.reqestType = int.Parse(row["reqestType"].ToString());
                }
                if (row["responseType"] != null && row["responseType"].ToString() != "")
                {
                    model.responseType = int.Parse(row["responseType"].ToString());
                }
                if (row["isDefault"] != null && row["isDefault"].ToString() != "")
                {
                    if ((row["isDefault"].ToString() == "1") || (row["isDefault"].ToString().ToLower() == "true"))
                    {
                        model.isDefault = true;
                    }
                    else
                    {
                        model.isDefault = false;
                    }
                }
                if (row["modelFunctionName"] != null)
                {
                    model.modelFunctionName = row["modelFunctionName"].ToString();
                }
                if (row["modelFunctionId"] != null && row["modelFunctionId"].ToString() != "")
                {
                    model.modelFunctionId = int.Parse(row["modelFunctionId"].ToString());
                }
                if (row["seq"] != null && row["seq"].ToString() != "")
                {
                    model.seq = int.Parse(row["seq"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["agentUrl"] != null)
                {
                    model.agentUrl = row["agentUrl"].ToString();
                }
                if (row["agentToken"] != null)
                {
                    model.agentToken = row["agentToken"].ToString();
                }
                if (row["isLikeSearch"] != null && row["isLikeSearch"].ToString() != "")
                {
                    if ((row["isLikeSearch"].ToString() == "1") || (row["isLikeSearch"].ToString().ToLower() == "true"))
                    {
                        model.isLikeSearch = true;
                    }
                    else
                    {
                        model.isLikeSearch = false;
                    }
                }
                if (row["extInt"] != null && row["extInt"].ToString() != "")
                {
                    model.extInt = int.Parse(row["extInt"].ToString());
                }
                if (row["extInt2"] != null && row["extInt2"].ToString() != "")
                {
                    model.extInt2 = int.Parse(row["extInt2"].ToString());
                }
                if (row["extStr"] != null)
                {
                    model.extStr = row["extStr"].ToString();
                }
                if (row["extStr2"] != null)
                {
                    model.extStr2 = row["extStr2"].ToString();
                }
                if (row["extStr3"] != null)
                {
                    model.extStr3 = row["extStr3"].ToString();
                }
                if (row["extStr4"] != null)
                {
                    model.extStr4 = row["extStr4"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wId,uId,ruleName,reqKeywords,reqestType,responseType,isDefault,modelFunctionName,modelFunctionId,seq,createDate,agentUrl,agentToken,isLikeSearch,extInt,extInt2,extStr,extStr2,extStr3,extStr4 ");
            strSql.Append(" FROM wx_requestRule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,wId,uId,ruleName,reqKeywords,reqestType,responseType,isDefault,modelFunctionName,modelFunctionId,seq,createDate,agentUrl,agentToken,isLikeSearch,extInt,extInt2,extStr,extStr2,extStr3,extStr4 ");
            strSql.Append(" FROM wx_requestRule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wx_requestRule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_requestRule T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        public Cms.Model.wx_requestRule GetSubscricModel(int wid)
        {
            return GetTop1Model(wid, "reqestType=6");
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="wid">微帐号主键Id</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public Cms.Model.wx_requestRule GetTop1Model(int wid, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wId,uId,ruleName,reqKeywords,reqestType,responseType,isDefault,modelFunctionName,modelFunctionId,seq,createDate,agentUrl,agentToken,isLikeSearch,extInt,extInt2,extStr,extStr2,extStr3,extStr4 from wx_requestRule ");
            strSql.Append(" where wId=" + wid);
            if (strWhere != null && strWhere.Length > 0)
            {
                strSql.Append(" and " + strWhere);
            }

            Cms.Model.wx_requestRule model = new Cms.Model.wx_requestRule();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select r.*,c.id as cid,c.rContent,c.rContent2,c.detailUrl,c.picUrl,c.mediaUrl,c.remark from wx_requestRule r left join wx_requestRuleContent  c on r.id=c.rId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetTWKeyWordList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from wx_requestRule   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }




        /// <summary>
        /// 删除一条微信回复的规则，并且将其对应的内容删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRule(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_requestRule  where id=" + id + ";");
            strSql.Append("delete from wx_requestRuleContent where rId=" + id + "");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 通过试图获得回复规则以及规则对应的内容
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRuleContent(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM v_wxRuleContent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 通过试图获得回复规则以及规则对应的内容
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRuleContent(int top,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top "+top+" * FROM v_wxRuleContent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  ExtensionMethod

        #region 微信前端使用，需要高效率

        /// <summary>
        /// 得到回复规则的主键Id
        /// </summary>
        /// <param name="wid">微帐号主键Id</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRuleId(int wid, string strWhere)
        {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id from wx_requestRule ");
            strSql.Append(" where wId=" + wid);
            if (strWhere != null && strWhere.Length > 0)
            {
                strSql.Append(" and " + strWhere);
            }
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString());

            while (sr.Read())
            {
                ret = int.Parse(sr["id"].ToString());
            }
            sr.Close();

            return ret;
        }

        /// <summary>
        /// 得到回复规则的主键Id以及回复的类型
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="strWhere"></param>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public int GetRuleIdAndResponseType(int wid, string strWhere, out int responseType)
        {
            int ret = 0;
            responseType = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,responseType from wx_requestRule ");
            strSql.Append(" where wId=" + wid);
            if (strWhere != null && strWhere.Length > 0)
            {
                strSql.Append(" and " + strWhere);
            }
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString());

            while (sr.Read())
            {
                ret = int.Parse(sr["id"].ToString());
                responseType = int.Parse(sr["responseType"].ToString());
            }
            sr.Close();

            return ret;
        }

        
        /// <summary>
        /// 关键词查询，找到该规则对应的主键ID,使用存储过程
        /// </summary>
        /// <param name="wid">微帐号主键Id</param>
        /// <param name="keywords">关键词</param>
        /// <param name="responseType">回复类型</param>
        /// <param name="modelFunctionName">模块名称</param>
        /// <param name="modelFunctionId">模块Id</param>
        /// <returns></returns>
        public int GetRuleIdByKeyWords(int wid, string keywords, out int responseType, out string modelFunctionName, out int modelFunctionId)
        {
            int ret = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
                    new SqlParameter("@keywords",SqlDbType.VarChar,500),
                    new SqlParameter("@id",SqlDbType.Int,4),
                    new SqlParameter("@responseType",SqlDbType.Int,4),
                    new SqlParameter("@modelFunctionName",SqlDbType.VarChar,200),
                    new SqlParameter("@modelFunctionId",SqlDbType.Int,4)
			};
            parameters[0].Value = wid;
            parameters[1].Value = keywords;
            parameters[2].Value = 0;
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3].Value = 0;
            parameters[3].Direction = ParameterDirection.Output;

            parameters[4].Value ="";
            parameters[4].Direction = ParameterDirection.Output;

            parameters[5].Value = 0;
            parameters[5].Direction = ParameterDirection.Output;


            SqlDataReader sr = DbHelperSQL.RunProcedure("p_query_keywords", parameters);
            //while (sr.Read())
            //{
            //    ret = int.Parse(sr["id"].ToString());
            //}
            sr.Close();
            ret =MyCommFun.Obj2Int(parameters[2].Value);
            responseType = MyCommFun.Obj2Int(parameters[3].Value);
            modelFunctionName = MyCommFun.ObjToStr (parameters[4].Value);
            modelFunctionId = MyCommFun.Obj2Int(parameters[5].Value);

            return ret;
        }

        #endregion

    }
}

