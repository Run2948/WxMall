/**  版本信息模板在安装目录下，可自行修改。
* C_Column.cs
*
* 功 能： N/A
* 类 名： C_Column
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/10 10:58:57   N/A    初版
*
└──────────────────────────────────┘
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
	/// 数据访问类:C_Column
	/// </summary>
	public partial class C_Column
	{
		public C_Column()
		{}
		#region  BasicMethod

        #region 私有方法================================
        /// <summary>
        /// 取得所有类别列表(已经排序好)
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM C_Column");
            strSql.Append("");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parent_id);
            return newData;
        }


        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parent_id)
        {
            DataRow[] dr = oldData.Select("parentId=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["classId"] = int.Parse(dr[i]["classId"].ToString());
                row["className"] = dr[i]["className"].ToString();
                row["className"] = dr[i]["className"].ToString();
                row["sub_title"] = dr[i]["sub_title"].ToString();
                row["linkUrl"] = dr[i]["linkUrl"].ToString();
                row["modelId"] = dr[i]["modelId"].ToString();
                row["ordernumber"] = dr[i]["ordernumber"].ToString();
                row["isShowChannel"] = dr[i]["isShowChannel"].ToString();
                row["isHidden"] = dr[i]["isHidden"].ToString();
                row["parentId"] = int.Parse(dr[i]["parentId"].ToString());
                row["class_list"] = dr[i]["class_list"].ToString();
                row["class_layer"] = int.Parse(dr[i]["class_layer"].ToString());
                row["channel_id"] = int.Parse(dr[i]["channel_id"].ToString());
                row["action_type"] = dr[i]["action_type"].ToString();
                row["is_sys"] = int.Parse(dr[i]["is_sys"].ToString());
                row["tpl_channel"] = dr[i]["tpl_channel"].ToString();
                row["tpl_content"] = dr[i]["tpl_content"].ToString();
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["classId"].ToString()));
            }
        }


        /// <summary>
        /// 取得所有类别列表(没有排序好，只有数据)
        /// </summary>
        /// <param name="parent_id">父ID，0为所有类别</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataList(int parent_id, string nav_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM C_Column");
            strSql.Append(" where nav_type='" + nav_type + "' order by classid asc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// 取得所有类别列表(已经排序好)
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(int parent_id, string nav_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM C_Column");
            strSql.Append(" where nav_type='" + nav_type + "' order by ordernumber desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parent_id);
            return newData;
        }
        #endregion

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("classId", "C_Column"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int classId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Column");
			strSql.Append(" where classId=@classId");
			SqlParameter[] parameters = {
					new SqlParameter("@classId", SqlDbType.Int,4)
			};
			parameters[0].Value = classId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_Column model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into C_Column(");
                        strSql.Append("parentId,modelId,className,engName,orderNumber,photoUrl,photoUrlone,photoUrltwo,isShowChannel,isShowNext,isBlank,isHidden,intro,content,linkUrl,seoTitle,seoKeyword,seoDescription,expandClass,name,related,listinfopath,isaddsub,action_type,class_list,class_layer,channel_id,sub_title,is_sys,nav_type,w_intro,w_content,w_isShowChannel,w_seoTitle,w_seoKeyword,w_seoDescription,w_expandClass,w_linkUrl,e_intro,e_content,e_isShowChannel,e_seoTitle,e_seoKeyword,e_seoDescription,e_expandClass,e_linkUrl,is_albums,is_attach,page_size,tpl_content,tpl_channel)");
                        strSql.Append(" values (");
                        strSql.Append("@parentId,@modelId,@className,@engName,@orderNumber,@photoUrl,@photoUrlone,@photoUrltwo,@isShowChannel,@isShowNext,@isBlank,@isHidden,@intro,@content,@linkUrl,@seoTitle,@seoKeyword,@seoDescription,@expandClass,@name,@related,@listinfopath,@isaddsub,@action_type,@class_list,@class_layer,@channel_id,@sub_title,@is_sys,@nav_type,@w_intro,@w_content,@w_isShowChannel,@w_seoTitle,@w_seoKeyword,@w_seoDescription,@w_expandClass,@w_linkUrl,@e_intro,@e_content,@e_isShowChannel,@e_seoTitle,@e_seoKeyword,@e_seoDescription,@e_expandClass,@e_linkUrl,@is_albums,@is_attach,@page_size,@tpl_content,@tpl_channel)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@modelId", SqlDbType.Int,4),
					new SqlParameter("@className", SqlDbType.VarChar,130),
					new SqlParameter("@engName", SqlDbType.VarChar,130),
					new SqlParameter("@orderNumber", SqlDbType.Int,4),
					new SqlParameter("@photoUrl", SqlDbType.VarChar,200),
					new SqlParameter("@photoUrlone", SqlDbType.VarChar,200),
					new SqlParameter("@photoUrltwo", SqlDbType.VarChar,200),
					new SqlParameter("@isShowChannel", SqlDbType.Int,4),
					new SqlParameter("@isShowNext", SqlDbType.Int,4),
					new SqlParameter("@isBlank", SqlDbType.Int,4),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@intro", SqlDbType.VarChar,500),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@linkUrl", SqlDbType.VarChar,200),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@expandClass", SqlDbType.VarChar,255),
					new SqlParameter("@name", SqlDbType.VarChar,255),
					new SqlParameter("@related", SqlDbType.VarChar,-1),
					new SqlParameter("@listinfopath", SqlDbType.VarChar,350),
					new SqlParameter("@isaddsub", SqlDbType.Int,4),
					new SqlParameter("@action_type", SqlDbType.VarChar,-1),
					new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					new SqlParameter("@class_layer", SqlDbType.Int,4),
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@sub_title", SqlDbType.NVarChar,100),
					new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
					new SqlParameter("@nav_type", SqlDbType.NVarChar,50),
					new SqlParameter("@w_intro", SqlDbType.VarChar,500),
					new SqlParameter("@w_content", SqlDbType.Text),
					new SqlParameter("@w_isShowChannel", SqlDbType.Int,4),
					new SqlParameter("@w_seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@w_seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@w_seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@w_expandClass", SqlDbType.VarChar,255),
					new SqlParameter("@w_linkUrl", SqlDbType.VarChar,255),
					new SqlParameter("@e_intro", SqlDbType.VarChar,500),
					new SqlParameter("@e_content", SqlDbType.Text),
					new SqlParameter("@e_isShowChannel", SqlDbType.Int,4),
					new SqlParameter("@e_seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@e_seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@e_seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@e_expandClass", SqlDbType.VarChar,255),
					new SqlParameter("@e_linkUrl", SqlDbType.VarChar,255),
					new SqlParameter("@is_albums", SqlDbType.TinyInt,1),
					new SqlParameter("@is_attach", SqlDbType.TinyInt,1),
					new SqlParameter("@page_size", SqlDbType.Int,4),
                                                    new SqlParameter("@tpl_content", SqlDbType.VarChar,500),
                                                    new SqlParameter("@tpl_channel", SqlDbType.VarChar,500)};

                        parameters[0].Value = model.parentId;
                        parameters[1].Value = model.modelId;
                        parameters[2].Value = model.className;
                        parameters[3].Value = model.engName;
                        parameters[4].Value = model.orderNumber;
                        parameters[5].Value = model.photoUrl;
                        parameters[6].Value = model.photoUrlone;
                        parameters[7].Value = model.photoUrltwo;
                        parameters[8].Value = model.isShowChannel;
                        parameters[9].Value = model.isShowNext;
                        parameters[10].Value = model.isBlank;
                        parameters[11].Value = model.isHidden;
                        parameters[12].Value = model.intro;
                        parameters[13].Value = model.content;
                        parameters[14].Value = model.linkUrl;
                        parameters[15].Value = model.seoTitle;
                        parameters[16].Value = model.seoKeyword;
                        parameters[17].Value = model.seoDescription;
                        parameters[18].Value = model.expandClass;
                        parameters[19].Value = model.name;
                        parameters[20].Value = model.related;
                        parameters[21].Value = model.listinfopath;
                        parameters[22].Value = model.isaddsub;
                        parameters[23].Value = model.action_type;
                        parameters[24].Value = model.class_list;
                        parameters[25].Value = model.class_layer;
                        parameters[26].Value = model.channel_id;
                        parameters[27].Value = model.sub_title;
                        parameters[28].Value = model.is_sys;
                        parameters[29].Value = model.nav_type;
                        parameters[30].Value = model.w_intro;
                        parameters[31].Value = model.w_content;
                        parameters[32].Value = model.w_isShowChannel;
                        parameters[33].Value = model.w_seoTitle;
                        parameters[34].Value = model.w_seoKeyword;
                        parameters[35].Value = model.w_seoDescription;
                        parameters[36].Value = model.w_expandClass;
                        parameters[37].Value = model.w_linkUrl;
                        parameters[38].Value = model.e_intro;
                        parameters[39].Value = model.e_content;
                        parameters[40].Value = model.e_isShowChannel;
                        parameters[41].Value = model.e_seoTitle;
                        parameters[42].Value = model.e_seoKeyword;
                        parameters[43].Value = model.e_seoDescription;
                        parameters[44].Value = model.e_expandClass;
                        parameters[45].Value = model.e_linkUrl;
                        parameters[46].Value = model.is_albums;
                        parameters[47].Value = model.is_attach;
                        parameters[48].Value = model.page_size;
                        parameters[49].Value = model.tplContent;
                        parameters[50].Value = model.tplChannel;


                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.classId = Convert.ToInt32(obj);

                        //扩展字段
                        if (model.channel_fields != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.C_Column_field modelt in model.channel_fields)
                            {
                                strSql2 = new StringBuilder();
                                strSql2.Append("insert into C_Column_field(");
                                strSql2.Append("channel_id,field_id)");
                                strSql2.Append(" values (");
                                strSql2.Append("@channel_id,@field_id)");
                                SqlParameter[] parameters2 = {
					                    new SqlParameter("@channel_id", SqlDbType.Int,4),
					                    new SqlParameter("@field_id", SqlDbType.Int,4)};
                                parameters2[0].Value = model.classId;
                                parameters2[1].Value = modelt.field_id;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                            }
                        }

                        //添加视图
                        StringBuilder strSql3 = new StringBuilder();
                        strSql3.Append("CREATE VIEW view_channel_" + model.name + " as");
                        strSql3.Append(" SELECT C_article.*");
                        if (model.channel_fields != null)
                        {
                            foreach (Model.C_Column_field modelt in model.channel_fields)
                            {
                                Model.C_article_attribute_field fieldModel = new SQLServerDAL.C_article_attribute_field().GetModel(modelt.field_id);
                                if (fieldModel != null)
                                {
                                    strSql3.Append(",article_attribute_value." + fieldModel.name);
                                }
                            }
                        }
                        strSql3.Append(" FROM C_article_attribute_value INNER JOIN");
                        strSql3.Append(" C_article ON C_article_attribute_value.article_id = C_article.articleId");
                        strSql3.Append(" WHERE C_article.parentId=" + model.classId);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString());
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
           return model.classId;
		}

        #region 更新一条数据===========================
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Cms.Model.C_Column model)
		{
            Cms.Model.C_Column oldModel = GetModel(model.classId); //旧的数据
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update C_Column set ");
                        strSql.Append("parentId=@parentId,");
                        strSql.Append("modelId=@modelId,");
                        strSql.Append("className=@className,");
                        strSql.Append("engName=@engName,");
                        strSql.Append("orderNumber=@orderNumber,");
                        strSql.Append("photoUrl=@photoUrl,");
                        strSql.Append("photoUrlone=@photoUrlone,");
                        strSql.Append("photoUrltwo=@photoUrltwo,");
                        strSql.Append("isShowChannel=@isShowChannel,");
                        strSql.Append("isShowNext=@isShowNext,");
                        strSql.Append("isBlank=@isBlank,");
                        strSql.Append("isHidden=@isHidden,");
                        strSql.Append("intro=@intro,");
                        strSql.Append("content=@content,");
                        strSql.Append("linkUrl=@linkUrl,");
                        strSql.Append("seoTitle=@seoTitle,");
                        strSql.Append("seoKeyword=@seoKeyword,");
                        strSql.Append("seoDescription=@seoDescription,");
                        strSql.Append("expandClass=@expandClass,");
                        strSql.Append("name=@name,");
                        strSql.Append("related=@related,");
                        strSql.Append("listinfopath=@listinfopath,");
                        strSql.Append("isaddsub=@isaddsub,");
                        strSql.Append("action_type=@action_type,");
                        strSql.Append("class_list=@class_list,");
                        strSql.Append("class_layer=@class_layer,");
                        strSql.Append("channel_id=@channel_id,");
                        strSql.Append("sub_title=@sub_title,");
                        strSql.Append("is_sys=@is_sys,");
                        strSql.Append("nav_type=@nav_type,");
                        strSql.Append("w_intro=@w_intro,");
                        strSql.Append("w_content=@w_content,");
                        strSql.Append("w_isShowChannel=@w_isShowChannel,");
                        strSql.Append("w_seoTitle=@w_seoTitle,");
                        strSql.Append("w_seoKeyword=@w_seoKeyword,");
                        strSql.Append("w_seoDescription=@w_seoDescription,");
                        strSql.Append("w_expandClass=@w_expandClass,");
                        strSql.Append("w_linkUrl=@w_linkUrl,");
                        strSql.Append("e_intro=@e_intro,");
                        strSql.Append("e_content=@e_content,");
                        strSql.Append("e_isShowChannel=@e_isShowChannel,");
                        strSql.Append("e_seoTitle=@e_seoTitle,");
                        strSql.Append("e_seoKeyword=@e_seoKeyword,");
                        strSql.Append("e_seoDescription=@e_seoDescription,");
                        strSql.Append("e_expandClass=@e_expandClass,");
                        strSql.Append("e_linkUrl=@e_linkUrl,");
                        strSql.Append("is_albums=@is_albums,");
                        strSql.Append("is_attach=@is_attach,");
                        strSql.Append("page_size=@page_size,");
                       
                        strSql.Append("tpl_content=@tpl_content,");
                        strSql.Append("tpl_channel=@tpl_channel");
      
                        strSql.Append(" where classId=@classId");
                        SqlParameter[] parameters = {
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@modelId", SqlDbType.Int,4),
					new SqlParameter("@className", SqlDbType.VarChar,130),
					new SqlParameter("@engName", SqlDbType.VarChar,130),
					new SqlParameter("@orderNumber", SqlDbType.Int,4),
					new SqlParameter("@photoUrl", SqlDbType.VarChar,200),
					new SqlParameter("@photoUrlone", SqlDbType.VarChar,200),
					new SqlParameter("@photoUrltwo", SqlDbType.VarChar,200),
					new SqlParameter("@isShowChannel", SqlDbType.Int,4),
					new SqlParameter("@isShowNext", SqlDbType.Int,4),
					new SqlParameter("@isBlank", SqlDbType.Int,4),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@intro", SqlDbType.VarChar,500),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@linkUrl", SqlDbType.VarChar,200),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@expandClass", SqlDbType.VarChar,255),
					new SqlParameter("@name", SqlDbType.VarChar,255),
					new SqlParameter("@related", SqlDbType.VarChar,-1),
					new SqlParameter("@listinfopath", SqlDbType.VarChar,350),
					new SqlParameter("@isaddsub", SqlDbType.Int,4),
					new SqlParameter("@action_type", SqlDbType.VarChar,-1),
					new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					new SqlParameter("@class_layer", SqlDbType.Int,4),
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@sub_title", SqlDbType.NVarChar,100),
					new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
					new SqlParameter("@nav_type", SqlDbType.NVarChar,50),
					new SqlParameter("@w_intro", SqlDbType.VarChar,500),
					new SqlParameter("@w_content", SqlDbType.Text),
					new SqlParameter("@w_isShowChannel", SqlDbType.Int,4),
					new SqlParameter("@w_seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@w_seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@w_seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@w_expandClass", SqlDbType.VarChar,255),
					new SqlParameter("@w_linkUrl", SqlDbType.VarChar,255),
					new SqlParameter("@e_intro", SqlDbType.VarChar,500),
					new SqlParameter("@e_content", SqlDbType.Text),
					new SqlParameter("@e_isShowChannel", SqlDbType.Int,4),
					new SqlParameter("@e_seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@e_seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@e_seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@e_expandClass", SqlDbType.VarChar,255),
					new SqlParameter("@e_linkUrl", SqlDbType.VarChar,255),
					new SqlParameter("@is_albums", SqlDbType.TinyInt,1),
					new SqlParameter("@is_attach", SqlDbType.TinyInt,1),
					new SqlParameter("@page_size", SqlDbType.Int,4),
                    new SqlParameter("@tpl_content", SqlDbType.VarChar,500),
                    new SqlParameter("@tpl_channel", SqlDbType.VarChar,500),

					new SqlParameter("@classId", SqlDbType.Int,4)};
                        parameters[0].Value = model.parentId;
                        parameters[1].Value = model.modelId;
                        parameters[2].Value = model.className;
                        parameters[3].Value = model.engName;
                        parameters[4].Value = model.orderNumber;
                        parameters[5].Value = model.photoUrl;
                        parameters[6].Value = model.photoUrlone;
                        parameters[7].Value = model.photoUrltwo;
                        parameters[8].Value = model.isShowChannel;
                        parameters[9].Value = model.isShowNext;
                        parameters[10].Value = model.isBlank;
                        parameters[11].Value = model.isHidden;
                        parameters[12].Value = model.intro;
                        parameters[13].Value = model.content;
                        parameters[14].Value = model.linkUrl;
                        parameters[15].Value = model.seoTitle;
                        parameters[16].Value = model.seoKeyword;
                        parameters[17].Value = model.seoDescription;
                        parameters[18].Value = model.expandClass;
                        parameters[19].Value = model.name;
                        parameters[20].Value = model.related;
                        parameters[21].Value = model.listinfopath;
                        parameters[22].Value = model.isaddsub;
                        parameters[23].Value = model.action_type;
                        parameters[24].Value = model.class_list;
                        parameters[25].Value = model.class_layer;
                        parameters[26].Value = model.channel_id;
                        parameters[27].Value = model.sub_title;
                        parameters[28].Value = model.is_sys;
                        parameters[29].Value = model.nav_type;
                        parameters[30].Value = model.w_intro;
                        parameters[31].Value = model.w_content;
                        parameters[32].Value = model.w_isShowChannel;
                        parameters[33].Value = model.w_seoTitle;
                        parameters[34].Value = model.w_seoKeyword;
                        parameters[35].Value = model.w_seoDescription;
                        parameters[36].Value = model.w_expandClass;
                        parameters[37].Value = model.w_linkUrl;
                        parameters[38].Value = model.e_intro;
                        parameters[39].Value = model.e_content;
                        parameters[40].Value = model.e_isShowChannel;
                        parameters[41].Value = model.e_seoTitle;
                        parameters[42].Value = model.e_seoKeyword;
                        parameters[43].Value = model.e_seoDescription;
                        parameters[44].Value = model.e_expandClass;
                        parameters[45].Value = model.e_linkUrl;
                        parameters[46].Value = model.is_albums;
                        parameters[47].Value = model.is_attach;
                        parameters[48].Value = model.page_size;
                        parameters[49].Value = model.tplContent;
                        parameters[50].Value = model.tplChannel;
                        parameters[51].Value = model.classId;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                       
                        #region MyRegion
                        //删除已移除的扩展字段
                        FieldDelete(conn, trans, model.channel_fields, model.classId);
                        //添加扩展字段
                        if (model.channel_fields != null)
                        {
                            StringBuilder strSql2;
                            foreach (Cms.Model.C_Column_field modelt in model.channel_fields)
                            {
                                strSql2 = new StringBuilder();
                                Cms.Model.C_Column_field fieldModel = null;
                                if (oldModel.channel_fields != null)
                                {
                                    fieldModel = oldModel.channel_fields.Find(p => p.field_id == modelt.field_id); //查找是否已经存在
                                }
                                if (fieldModel == null) //如果不存在则添加
                                {
                                    strSql2.Append("insert into C_Column_field(");
                                    strSql2.Append("channel_id,field_id)");
                                    strSql2.Append(" values (");
                                    strSql2.Append("@channel_id,@field_id)");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@channel_id", SqlDbType.Int,4),
					                        new SqlParameter("@field_id", SqlDbType.Int,4)};
                                    parameters2[0].Value = modelt.channel_id;
                                    parameters2[1].Value = modelt.field_id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                            }
                        }
                        //删除旧视图重建新视图
                        RehabChannelViews(conn, trans, model, oldModel.name);
                        trans.Commit();
                        #endregion
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
        /// 删除已移除的频道扩展字段
        /// </summary>
        public void FieldDelete(SqlConnection conn, SqlTransaction trans, List<Cms.Model.C_Column_field> models, int channel_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,field_id from C_Column_field");
            strSql.Append(" where channel_id=" + channel_id);
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Cms.Model.C_Column_field model = models.Find(p => p.field_id == int.Parse(dr["field_id"].ToString())); //查找对应的字段ID
                if (model == null)
                {
                   int count= DbHelperSQL.ExecuteSql(conn, trans, "delete from C_Column_field where channel_id=" + channel_id + " and field_id=" + dr["field_id"].ToString()); //删除该字段
                }
            }
            
        }
        /// <summary>
        /// 删除及重建该频道视图
        /// </summary>
        public void RehabChannelViews(SqlConnection conn, SqlTransaction trans, Model.C_Column model, string old_name)
        {
            //删除旧的视图
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("if exists (select 1 from sysobjects where id = object_id('view_channel_" + old_name + "') and type = 'V')");
            strSql1.Append("drop view view_channel_" + old_name);
            DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString());
            //添加视图
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("CREATE VIEW view_channel_" + model.name + " as");
            strSql2.Append(" SELECT C_article.*");
            if (model.channel_fields != null)
            {
                foreach (Model.C_Column_field modelt in model.channel_fields)
                {
                    Model.C_article_attribute_field fieldModel = new  SQLServerDAL.C_article_attribute_field().GetModel(modelt.field_id);
                    if (fieldModel != null)
                    {
                        strSql2.Append(",C_article_attribute_value." + fieldModel.name);
                    }
                }
            }
            strSql2.Append(" FROM C_article_attribute_value INNER JOIN");
            strSql2.Append(" C_article ON C_article_attribute_value.article_id = C_article.articleId");
            strSql2.Append(" WHERE C_article.parentId=" + model.classId);
            DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString());
        }
        #endregion
        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int classId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Column ");
			strSql.Append(" where classId=@classId");
			SqlParameter[] parameters = {
					new SqlParameter("@classId", SqlDbType.Int,4)
			};
			parameters[0].Value = classId;

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
		public bool DeleteList(string classIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Column ");
			strSql.Append(" where classId in ("+classIdlist + ")  ");
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

        #region 得到一个对象实体========================
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.C_Column GetModel(int classId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from C_Column ");
			strSql.Append(" where classId=@classId");
			SqlParameter[] parameters = {
					new SqlParameter("@classId", SqlDbType.Int,4)
			};
			parameters[0].Value = classId;

			Cms.Model.C_Column model=new Cms.Model.C_Column();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
                #region  父表信息
                if (ds.Tables[0].Rows[0]["classId"].ToString() != "")
                {
                    model.classId = int.Parse(ds.Tables[0].Rows[0]["classId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parentId"].ToString() != "")
                {
                    model.parentId = int.Parse(ds.Tables[0].Rows[0]["parentId"].ToString());
                }
                model.modelId = int.Parse(ds.Tables[0].Rows[0]["modelId"].ToString());
                model.className = ds.Tables[0].Rows[0]["className"].ToString();
                model.engName = ds.Tables[0].Rows[0]["engName"].ToString();
                if (ds.Tables[0].Rows[0]["orderNumber"].ToString() != "")
                {
                    model.orderNumber = int.Parse(ds.Tables[0].Rows[0]["orderNumber"].ToString());
                }
                model.photoUrl = ds.Tables[0].Rows[0]["photoUrl"].ToString();
                model.photoUrlone = ds.Tables[0].Rows[0]["photoUrlone"].ToString();
                model.photoUrltwo = ds.Tables[0].Rows[0]["photoUrltwo"].ToString();
                if (ds.Tables[0].Rows[0]["isShowChannel"].ToString() != "")
                {
                    model.isShowChannel = int.Parse(ds.Tables[0].Rows[0]["isShowChannel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isShowNext"].ToString() != "")
                {
                    model.isShowNext = int.Parse(ds.Tables[0].Rows[0]["isShowNext"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isBlank"].ToString() != "")
                {
                    model.isBlank = int.Parse(ds.Tables[0].Rows[0]["isBlank"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isHidden"].ToString() != "")
                {
                    model.isHidden = int.Parse(ds.Tables[0].Rows[0]["isHidden"].ToString());
                }
                model.intro = ds.Tables[0].Rows[0]["intro"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                model.linkUrl = ds.Tables[0].Rows[0]["linkUrl"].ToString();
                model.seoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                model.seoKeyword = ds.Tables[0].Rows[0]["seoKeyword"].ToString();
                model.seoDescription = ds.Tables[0].Rows[0]["seoDescription"].ToString();
                model.expandClass = ds.Tables[0].Rows[0]["expandClass"].ToString();
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.related = ds.Tables[0].Rows[0]["related"].ToString();
                model.tplChannel = ds.Tables[0].Rows[0]["tpl_channel"].ToString();
                model.tplContent = ds.Tables[0].Rows[0]["tpl_content"].ToString();
                
                model.listinfopath = ds.Tables[0].Rows[0]["listinfopath"].ToString();
                
                if (ds.Tables[0].Rows[0]["isaddsub"].ToString() != "")
                {
                    model.isaddsub = int.Parse(ds.Tables[0].Rows[0]["isaddsub"].ToString());
                }
                model.action_type = ds.Tables[0].Rows[0]["action_type"].ToString();
                model.class_list = ds.Tables[0].Rows[0]["class_list"].ToString();
                if (ds.Tables[0].Rows[0]["class_layer"].ToString() != "")
                {
                    model.class_layer = int.Parse(ds.Tables[0].Rows[0]["class_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }

                model.sub_title = ds.Tables[0].Rows[0]["sub_title"].ToString();
                if (ds.Tables[0].Rows[0]["is_sys"].ToString() != "")
                {
                    model.is_sys = int.Parse(ds.Tables[0].Rows[0]["is_sys"].ToString());
                }

                model.nav_type = ds.Tables[0].Rows[0]["nav_type"].ToString();
                model.w_intro = ds.Tables[0].Rows[0]["w_intro"].ToString();
                model.w_content = ds.Tables[0].Rows[0]["w_content"].ToString();
                if (ds.Tables[0].Rows[0]["w_isShowChannel"].ToString() != "")
                {
                    model.w_isShowChannel = int.Parse(ds.Tables[0].Rows[0]["w_isShowChannel"].ToString());
                }

                model.w_seoTitle = ds.Tables[0].Rows[0]["w_seoTitle"].ToString();
                model.w_seoKeyword = ds.Tables[0].Rows[0]["w_seoKeyword"].ToString();
                model.w_seoDescription = ds.Tables[0].Rows[0]["w_seoDescription"].ToString();
                model.w_expandClass = ds.Tables[0].Rows[0]["w_expandClass"].ToString();
                model.w_linkUrl = ds.Tables[0].Rows[0]["w_linkUrl"].ToString();
                model.e_intro = ds.Tables[0].Rows[0]["e_intro"].ToString();
                model.e_content = ds.Tables[0].Rows[0]["e_content"].ToString();
                if (ds.Tables[0].Rows[0]["e_isShowChannel"].ToString() != "")
                {
                    model.e_isShowChannel = int.Parse(ds.Tables[0].Rows[0]["e_isShowChannel"].ToString());
                }

                model.e_seoTitle = ds.Tables[0].Rows[0]["e_seoTitle"].ToString();
                model.e_seoKeyword = ds.Tables[0].Rows[0]["e_seoKeyword"].ToString();
                model.e_seoDescription = ds.Tables[0].Rows[0]["e_seoDescription"].ToString();
                model.e_expandClass = ds.Tables[0].Rows[0]["e_expandClass"].ToString();
                model.e_linkUrl = ds.Tables[0].Rows[0]["e_linkUrl"].ToString();
                if (ds.Tables[0].Rows[0]["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(ds.Tables[0].Rows[0]["is_albums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(ds.Tables[0].Rows[0]["is_attach"].ToString());
                }
                if (ds.Tables[0].Rows[0]["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(ds.Tables[0].Rows[0]["page_size"].ToString());
                }

               

                #endregion  父表信息end

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,channel_id,field_id from C_Column_field ");
                strSql2.Append(" where channel_id=@channel_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4)};
                parameters2[0].Value = classId;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Cms.Model.C_Column_field> models = new List<Cms.Model.C_Column_field>();
                    Cms.Model.C_Column_field modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Cms.Model.C_Column_field();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["channel_id"].ToString() != "")
                        {
                            modelt.channel_id = int.Parse(ds2.Tables[0].Rows[n]["channel_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["field_id"].ToString() != "")
                        {
                            modelt.field_id = int.Parse(ds2.Tables[0].Rows[n]["field_id"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.channel_fields = models;
                }
                #endregion  子表信息end
                return model;
			}
			else
			{
				return null;
			}
		}

        #endregion
        #region 得到一个对象实体========================
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Cms.Model.C_Column GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from C_Column ");
            strSql.Append(" where classId=@classId");
            SqlParameter[] parameters = {
					new SqlParameter("@classId", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Cms.Model.C_Column model = new Cms.Model.C_Column();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["classId"].ToString() != "")
                {
                    model.classId = int.Parse(ds.Tables[0].Rows[0]["classId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parentId"].ToString() != "")
                {
                    model.parentId = int.Parse(ds.Tables[0].Rows[0]["parentId"].ToString());
                }
                model.modelId = int.Parse(ds.Tables[0].Rows[0]["modelId"].ToString());
                model.className = ds.Tables[0].Rows[0]["className"].ToString();
                model.engName = ds.Tables[0].Rows[0]["engName"].ToString();
                if (ds.Tables[0].Rows[0]["orderNumber"].ToString() != "")
                {
                    model.orderNumber = int.Parse(ds.Tables[0].Rows[0]["orderNumber"].ToString());
                }
                model.photoUrl = ds.Tables[0].Rows[0]["photoUrl"].ToString();
                model.photoUrlone = ds.Tables[0].Rows[0]["photoUrlone"].ToString();
                model.photoUrltwo = ds.Tables[0].Rows[0]["photoUrltwo"].ToString();
                if (ds.Tables[0].Rows[0]["isShowChannel"].ToString() != "")
                {
                    model.isShowChannel = int.Parse(ds.Tables[0].Rows[0]["isShowChannel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isShowNext"].ToString() != "")
                {
                    model.isShowNext = int.Parse(ds.Tables[0].Rows[0]["isShowNext"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isBlank"].ToString() != "")
                {
                    model.isBlank = int.Parse(ds.Tables[0].Rows[0]["isBlank"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isHidden"].ToString() != "")
                {
                    model.isHidden = int.Parse(ds.Tables[0].Rows[0]["isHidden"].ToString());
                }
                model.intro = ds.Tables[0].Rows[0]["intro"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                model.linkUrl = ds.Tables[0].Rows[0]["linkUrl"].ToString();
                model.seoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                model.seoKeyword = ds.Tables[0].Rows[0]["seoKeyword"].ToString();
                model.seoDescription = ds.Tables[0].Rows[0]["seoDescription"].ToString();
                model.expandClass = ds.Tables[0].Rows[0]["expandClass"].ToString();
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.related = ds.Tables[0].Rows[0]["related"].ToString();
                model.tplChannel = ds.Tables[0].Rows[0]["tpl_channel"].ToString();
                model.tplContent = ds.Tables[0].Rows[0]["tpl_content"].ToString();
              
                model.listinfopath = ds.Tables[0].Rows[0]["listinfopath"].ToString();
               
                if (ds.Tables[0].Rows[0]["isaddsub"].ToString() != "")
                {
                    model.isaddsub = int.Parse(ds.Tables[0].Rows[0]["isaddsub"].ToString());
                }
                model.action_type = ds.Tables[0].Rows[0]["action_type"].ToString();
                model.class_list = ds.Tables[0].Rows[0]["class_list"].ToString();
                if (ds.Tables[0].Rows[0]["class_layer"].ToString() != "")
                {
                    model.class_layer = int.Parse(ds.Tables[0].Rows[0]["class_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }

                model.sub_title = ds.Tables[0].Rows[0]["sub_title"].ToString();
                if (ds.Tables[0].Rows[0]["is_sys"].ToString() != "")
                {
                    model.is_sys = int.Parse(ds.Tables[0].Rows[0]["is_sys"].ToString());
                }

                model.nav_type = ds.Tables[0].Rows[0]["nav_type"].ToString();
                model.w_intro = ds.Tables[0].Rows[0]["w_intro"].ToString();
                model.w_content = ds.Tables[0].Rows[0]["w_content"].ToString();
                if (ds.Tables[0].Rows[0]["w_isShowChannel"].ToString() != "")
                {
                    model.w_isShowChannel = int.Parse(ds.Tables[0].Rows[0]["w_isShowChannel"].ToString());
                }

                model.w_seoTitle = ds.Tables[0].Rows[0]["w_seoTitle"].ToString();
                model.w_seoKeyword = ds.Tables[0].Rows[0]["w_seoKeyword"].ToString();
                model.w_seoDescription = ds.Tables[0].Rows[0]["w_seoDescription"].ToString();
                model.w_expandClass = ds.Tables[0].Rows[0]["w_expandClass"].ToString();
                model.w_linkUrl = ds.Tables[0].Rows[0]["w_linkUrl"].ToString();
                model.e_intro = ds.Tables[0].Rows[0]["e_intro"].ToString();
                model.e_content = ds.Tables[0].Rows[0]["e_content"].ToString();
                if (ds.Tables[0].Rows[0]["e_isShowChannel"].ToString() != "")
                {
                    model.e_isShowChannel = int.Parse(ds.Tables[0].Rows[0]["e_isShowChannel"].ToString());
                }

                model.e_seoTitle = ds.Tables[0].Rows[0]["e_seoTitle"].ToString();
                model.e_seoKeyword = ds.Tables[0].Rows[0]["e_seoKeyword"].ToString();
                model.e_seoDescription = ds.Tables[0].Rows[0]["e_seoDescription"].ToString();
                model.e_expandClass = ds.Tables[0].Rows[0]["e_expandClass"].ToString();
                model.e_linkUrl = ds.Tables[0].Rows[0]["e_linkUrl"].ToString();
                if (ds.Tables[0].Rows[0]["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(ds.Tables[0].Rows[0]["is_albums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(ds.Tables[0].Rows[0]["is_attach"].ToString());
                }
                if (ds.Tables[0].Rows[0]["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(ds.Tables[0].Rows[0]["page_size"].ToString());
                }



                #endregion  父表信息end

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,channel_id,field_id from C_Column_field ");
                strSql2.Append(" where channel_id=@channel_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(conn, trans, strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Cms.Model.C_Column_field> models = new List<Cms.Model.C_Column_field>();
                    Cms.Model.C_Column_field modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Cms.Model.C_Column_field();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["channel_id"].ToString() != "")
                        {
                            modelt.channel_id = int.Parse(ds2.Tables[0].Rows[n]["channel_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["field_id"].ToString() != "")
                        {
                            modelt.field_id = int.Parse(ds2.Tables[0].Rows[n]["field_id"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.channel_fields = models;
                }
                #endregion  子表信息end
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.C_Column DataRowToModel(DataRow row)
		{
			Cms.Model.C_Column model=new Cms.Model.C_Column();
			if (row != null)
			{
				if(row["classId"]!=null && row["classId"].ToString()!="")
				{
					model.classId=int.Parse(row["classId"].ToString());
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
				}
				if(row["modelId"]!=null && row["modelId"].ToString()!="")
				{
					model.modelId=int.Parse(row["modelId"].ToString());
				}
				if(row["className"]!=null)
				{
					model.className=row["className"].ToString();
				}
				if(row["engName"]!=null)
				{
					model.engName=row["engName"].ToString();
				}
				if(row["orderNumber"]!=null && row["orderNumber"].ToString()!="")
				{
					model.orderNumber=int.Parse(row["orderNumber"].ToString());
				}
				if(row["photoUrl"]!=null)
				{
					model.photoUrl=row["photoUrl"].ToString();
				}
				if(row["photoUrlone"]!=null)
				{
					model.photoUrlone=row["photoUrlone"].ToString();
				}
				if(row["photoUrltwo"]!=null)
				{
					model.photoUrltwo=row["photoUrltwo"].ToString();
				}
				if(row["isShowChannel"]!=null && row["isShowChannel"].ToString()!="")
				{
					model.isShowChannel=int.Parse(row["isShowChannel"].ToString());
				}
				if(row["isShowNext"]!=null && row["isShowNext"].ToString()!="")
				{
					model.isShowNext=int.Parse(row["isShowNext"].ToString());
				}
				if(row["isBlank"]!=null && row["isBlank"].ToString()!="")
				{
					model.isBlank=int.Parse(row["isBlank"].ToString());
				}
				if(row["isHidden"]!=null && row["isHidden"].ToString()!="")
				{
					model.isHidden=int.Parse(row["isHidden"].ToString());
				}
				if(row["intro"]!=null)
				{
					model.intro=row["intro"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["linkUrl"]!=null)
				{
					model.linkUrl=row["linkUrl"].ToString();
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
				if(row["expandClass"]!=null)
				{
					model.expandClass=row["expandClass"].ToString();
				}
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["related"] != null)
                {
                    model.related = row["related"].ToString();
                }
				
				if(row["listinfopath"]!=null)
				{
					model.listinfopath=row["listinfopath"].ToString();
				}
				
				if(row["isaddsub"]!=null && row["isaddsub"].ToString()!="")
				{
					model.isaddsub=int.Parse(row["isaddsub"].ToString());
				}
				if(row["action_type"]!=null)
				{
					model.action_type=row["action_type"].ToString();
				}
				if(row["class_list"]!=null)
				{
					model.class_list=row["class_list"].ToString();
				}
				if(row["class_layer"]!=null && row["class_layer"].ToString()!="")
				{
					model.class_layer=int.Parse(row["class_layer"].ToString());
				}
				if(row["channel_id"]!=null && row["channel_id"].ToString()!="")
				{
					model.channel_id=int.Parse(row["channel_id"].ToString());
				}
				if(row["sub_title"]!=null)
				{
					model.sub_title=row["sub_title"].ToString();
				}
				if(row["is_sys"]!=null && row["is_sys"].ToString()!="")
				{
					model.is_sys=int.Parse(row["is_sys"].ToString());
				}
				if(row["nav_type"]!=null)
				{
					model.nav_type=row["nav_type"].ToString();
				}
				if(row["w_intro"]!=null)
				{
					model.w_intro=row["w_intro"].ToString();
				}
				if(row["w_content"]!=null)
				{
					model.w_content=row["w_content"].ToString();
				}
				if(row["w_isShowChannel"]!=null && row["w_isShowChannel"].ToString()!="")
				{
					model.w_isShowChannel=int.Parse(row["w_isShowChannel"].ToString());
				}
				if(row["w_seoTitle"]!=null)
				{
					model.w_seoTitle=row["w_seoTitle"].ToString();
				}
				if(row["w_seoKeyword"]!=null)
				{
					model.w_seoKeyword=row["w_seoKeyword"].ToString();
				}
				if(row["w_seoDescription"]!=null)
				{
					model.w_seoDescription=row["w_seoDescription"].ToString();
				}
				if(row["w_expandClass"]!=null)
				{
					model.w_expandClass=row["w_expandClass"].ToString();
				}
				if(row["w_linkUrl"]!=null)
				{
					model.w_linkUrl=row["w_linkUrl"].ToString();
				}
				if(row["e_intro"]!=null)
				{
					model.e_intro=row["e_intro"].ToString();
				}
				if(row["e_content"]!=null)
				{
					model.e_content=row["e_content"].ToString();
				}
				if(row["e_isShowChannel"]!=null && row["e_isShowChannel"].ToString()!="")
				{
					model.e_isShowChannel=int.Parse(row["e_isShowChannel"].ToString());
				}
				if(row["e_seoTitle"]!=null)
				{
					model.e_seoTitle=row["e_seoTitle"].ToString();
				}
				if(row["e_seoKeyword"]!=null)
				{
					model.e_seoKeyword=row["e_seoKeyword"].ToString();
				}
				if(row["e_seoDescription"]!=null)
				{
					model.e_seoDescription=row["e_seoDescription"].ToString();
				}
				if(row["e_expandClass"]!=null)
				{
					model.e_expandClass=row["e_expandClass"].ToString();
				}
				if(row["e_linkUrl"]!=null)
				{
					model.e_linkUrl=row["e_linkUrl"].ToString();
				}
                if (row["is_albums"] != null && row["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(row["is_albums"].ToString());
                }
                if (row["is_attach"] != null && row["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(row["is_attach"].ToString());
                }
                if (row["page_size"] != null && row["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(row["page_size"].ToString());
                }
                if (row["tpl_content"] != null && row["tpl_content"].ToString() != "")
                {
                    model.tplContent =row["tpl_content"].ToString();
                }
                if (row["tpl_channel"] != null && row["tpl_channel"].ToString() != "")
                {
                    model.tplChannel = row["tpl_channel"].ToString();
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
			strSql.Append("select * ");
			strSql.Append(" FROM C_Column ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM C_Column ");
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
			strSql.Append("select count(1) FROM C_Column ");
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
				strSql.Append("order by T.classId desc");
			}
			strSql.Append(")AS Row, T.*  from C_Column T ");
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
			parameters[0].Value = "C_Column";
			parameters[1].Value = "classId";
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

