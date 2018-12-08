/**  版本信息模板在安装目录下，可自行修改。
* C_article.cs
*
* 功 能： N/A
* 类 名： C_article
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/2 16:26:07   N/A    初版
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
	/// 数据访问类:C_article
	/// </summary>
	public partial class C_article
	{
		public C_article()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("articleId", "C_article"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int articleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_article");
            strSql.Append(" where articleId=@articleId");
			SqlParameter[] parameters = {
					new SqlParameter("@articleId", SqlDbType.Int,4)
			};
			parameters[0].Value = articleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_article(");
            strSql.Append("parentId,title,englishtitle,orderNumber,photoUrl,intro,content,seoTitle,seoKeyword,seoDescription,isRecommend,isChannel,isHidden,isCheck,isHot,isTop,is_msg,is_slide,hits,Attachment,expClass,editTime,updateTime,txtLinkUrl,contentUrl,txtsource,txtauthor,w_LinkUrl,w_contentUrl,w_intro,w_content,e_LinkUrl,e_contentUrl,e_source,e_author,e_intro,e_content,e_seoTitle,e_seoKeyword,e_seoDescription)");
			strSql.Append(" values (");
            strSql.Append("@parentId,@title,@englishtitle,@orderNumber,@photoUrl,@intro,@content,@seoTitle,@seoKeyword,@seoDescription,@isRecommend,@isChannel,@isHidden,@isCheck,@isHot,@isTop,@is_msg,@is_slide,@hits,@Attachment,@expClass,@editTime,@updateTime,@txtLinkUrl,@contentUrl,@txtsource,@txtauthor,@w_LinkUrl,@w_contentUrl,@w_intro,@w_content,@e_LinkUrl,@e_contentUrl,@e_source,@e_author,@e_intro,@e_content,@e_seoTitle,@e_seoKeyword,@e_seoDescription)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,150),
					new SqlParameter("@englishtitle", SqlDbType.VarChar,150),
					new SqlParameter("@orderNumber", SqlDbType.Int,4),
					new SqlParameter("@photoUrl", SqlDbType.VarChar,250),
					new SqlParameter("@intro", SqlDbType.Text),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@isRecommend", SqlDbType.Int,4),
					new SqlParameter("@isChannel", SqlDbType.VarChar,350),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isTop", SqlDbType.Int,4),
					new SqlParameter("@is_msg", SqlDbType.Int,4),
					new SqlParameter("@is_slide", SqlDbType.Int,4),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@Attachment", SqlDbType.VarChar,350),
					new SqlParameter("@expClass", SqlDbType.VarChar,350),
					new SqlParameter("@editTime", SqlDbType.DateTime),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@txtLinkUrl", SqlDbType.VarChar,350),
					new SqlParameter("@contentUrl", SqlDbType.VarChar,350),
					new SqlParameter("@txtsource", SqlDbType.VarChar,250),
					new SqlParameter("@txtauthor", SqlDbType.VarChar,250),
					new SqlParameter("@w_LinkUrl", SqlDbType.VarChar,350),
					new SqlParameter("@w_contentUrl", SqlDbType.VarChar,350),
					new SqlParameter("@w_intro", SqlDbType.Text),
					new SqlParameter("@w_content", SqlDbType.Text),
					new SqlParameter("@e_LinkUrl", SqlDbType.VarChar,350),
					new SqlParameter("@e_contentUrl", SqlDbType.VarChar,350),
					new SqlParameter("@e_source", SqlDbType.VarChar,250),
					new SqlParameter("@e_author", SqlDbType.VarChar,250),
					new SqlParameter("@e_intro", SqlDbType.Text),
					new SqlParameter("@e_content", SqlDbType.Text),
					new SqlParameter("@e_seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@e_seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@e_seoDescription", SqlDbType.VarChar,-1),
               new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.parentId;
			parameters[1].Value = model.title;
			parameters[2].Value = model.englishtitle;
			parameters[3].Value = model.orderNumber;
			parameters[4].Value = model.photoUrl;
			parameters[5].Value = model.intro;
			parameters[6].Value = model.content;
			parameters[7].Value = model.seoTitle;
			parameters[8].Value = model.seoKeyword;
			parameters[9].Value = model.seoDescription;
			parameters[10].Value = model.isRecommend;
			parameters[11].Value = model.isChannel;
			parameters[12].Value = model.isHidden;
			parameters[13].Value = model.isCheck;
			parameters[14].Value = model.isHot;
			parameters[15].Value = model.isTop;
			parameters[16].Value = model.is_msg;
			parameters[17].Value = model.is_slide;
			parameters[18].Value = model.hits;
			parameters[19].Value = model.Attachment;
			parameters[20].Value = model.expClass;
			parameters[21].Value = model.editTime;
			parameters[22].Value = model.updateTime;
			parameters[23].Value = model.txtLinkUrl;
			parameters[24].Value = model.contentUrl;
			parameters[25].Value = model.txtsource;
			parameters[26].Value = model.txtauthor;
			parameters[27].Value = model.w_LinkUrl;
			parameters[28].Value = model.w_contentUrl;
			parameters[29].Value = model.w_intro;
			parameters[30].Value = model.w_content;
			parameters[31].Value = model.e_LinkUrl;
			parameters[32].Value = model.e_contentUrl;
			parameters[33].Value = model.e_source;
			parameters[34].Value = model.e_author;
			parameters[35].Value = model.e_intro;
			parameters[36].Value = model.e_content;
			parameters[37].Value = model.e_seoTitle;
			parameters[38].Value = model.e_seoKeyword;
			parameters[39].Value = model.e_seoDescription;
            parameters[40].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //添加扩展字段
            StringBuilder strSql2 = new StringBuilder();
            StringBuilder strFieldName = new StringBuilder(); //字段列表
            StringBuilder strFieldVar = new StringBuilder(); //字段声明
            SqlParameter[] parameters2 = new SqlParameter[model.fields.Count + 1];
            int i = 1;
            strFieldName.Append("article_id");
            strFieldVar.Append("@article_id");
            parameters2[0] = new SqlParameter("@article_id", SqlDbType.Int, 4);
            parameters2[0].Direction = ParameterDirection.InputOutput;
            foreach (KeyValuePair<string, string> kvp in model.fields)
            {
                strFieldName.Append("," + kvp.Key);
                strFieldVar.Append(",@" + kvp.Key);
                if (kvp.Value.Length <= 4000)
                {
                    parameters2[i] = new SqlParameter("@" + kvp.Key, SqlDbType.NVarChar, kvp.Value.Length);
                }
                else
                {
                    parameters2[i] = new SqlParameter("@" + kvp.Key, SqlDbType.NText);
                }

                parameters2[i].Value = kvp.Value;
                i++;
            }
            strSql2.Append("insert into C_article_attribute_value(");
            strSql2.Append(strFieldName.ToString() + ")");
            strSql2.Append(" values (");
            strSql2.Append(strFieldVar.ToString() + ")");
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //图片相册
            if (model.albums != null)
            {
                StringBuilder strSql3;
                foreach (Cms.Model.C_article_albums modelt in model.albums)
                {
                    strSql3 = new StringBuilder();
                    strSql3.Append("insert into C_article_albums(");
                    strSql3.Append("article_id,thumb_path,original_path,remark)");
                    strSql3.Append(" values (");
                    strSql3.Append("@article_id,@thumb_path,@original_path,@remark)");
                    SqlParameter[] parameters3 = {
					    new SqlParameter("@article_id", SqlDbType.Int,4),
					    new SqlParameter("@thumb_path", SqlDbType.NVarChar,255),
					    new SqlParameter("@original_path", SqlDbType.NVarChar,255),
					    new SqlParameter("@remark", SqlDbType.NVarChar,500)};
                    parameters3[0].Direction = ParameterDirection.InputOutput;
                    parameters3[1].Value = modelt.thumb_path;
                    parameters3[2].Value = modelt.original_path;
                    parameters3[3].Value = modelt.remark;
                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }

            //文章附件
            if (model.attach != null)
            {
                StringBuilder strSql4;
                foreach (Cms.Model.C_article_attach modelt in model.attach)
                {
                    strSql4 = new StringBuilder();
                    strSql4.Append("insert into C_article_attach(");
                    strSql4.Append("article_id,file_name,file_path,file_size,file_ext,down_num,point)");
                    strSql4.Append(" values (");
                    strSql4.Append("@article_id,@file_name,@file_path,@file_size,@file_ext,@down_num,@point)");
                    SqlParameter[] parameters4 = {
					        new SqlParameter("@article_id", SqlDbType.Int,4),
					        new SqlParameter("@file_name", SqlDbType.NVarChar,100),
					        new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					        new SqlParameter("@file_size", SqlDbType.Int,4),
					        new SqlParameter("@file_ext", SqlDbType.NVarChar,20),
					        new SqlParameter("@down_num", SqlDbType.Int,4),
					        new SqlParameter("@point", SqlDbType.Int,4)};
                    parameters4[0].Direction = ParameterDirection.InputOutput;
                    parameters4[1].Value = modelt.file_name;
                    parameters4[2].Value = modelt.file_path;
                    parameters4[3].Value = modelt.file_size;
                    parameters4[4].Value = modelt.file_ext;
                    parameters4[5].Value = modelt.down_num;
                    parameters4[6].Value = modelt.point;
                    cmd = new CommandInfo(strSql4.ToString(), parameters4);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[40].Value;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Cms.Model.C_article model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update C_article set ");
                        strSql.Append("parentId=@parentId,");
                        strSql.Append("title=@title,");
                        strSql.Append("englishtitle=@englishtitle,");
                        strSql.Append("orderNumber=@orderNumber,");
                        strSql.Append("photoUrl=@photoUrl,");
                        strSql.Append("intro=@intro,");
                        strSql.Append("content=@content,");
                        strSql.Append("seoTitle=@seoTitle,");
                        strSql.Append("seoKeyword=@seoKeyword,");
                        strSql.Append("seoDescription=@seoDescription,");
                        strSql.Append("isRecommend=@isRecommend,");
                        strSql.Append("isChannel=@isChannel,");
                        strSql.Append("isHidden=@isHidden,");
                        strSql.Append("isCheck=@isCheck,");
                        strSql.Append("isHot=@isHot,");
                        strSql.Append("isTop=@isTop,");
                        strSql.Append("is_msg=@is_msg,");
                        strSql.Append("is_slide=@is_slide,");
                        strSql.Append("hits=@hits,");
                        strSql.Append("Attachment=@Attachment,");
                        strSql.Append("expClass=@expClass,");
                        strSql.Append("editTime=@editTime,");
                        strSql.Append("updateTime=@updateTime,");
                        strSql.Append("txtLinkUrl=@txtLinkUrl,");
                        strSql.Append("contentUrl=@contentUrl,");
                        strSql.Append("txtsource=@txtsource,");
                        strSql.Append("txtauthor=@txtauthor,");
                        strSql.Append("w_LinkUrl=@w_LinkUrl,");
                        strSql.Append("w_contentUrl=@w_contentUrl,");
                        strSql.Append("w_intro=@w_intro,");
                        strSql.Append("w_content=@w_content,");
                        strSql.Append("e_LinkUrl=@e_LinkUrl,");
                        strSql.Append("e_contentUrl=@e_contentUrl,");
                        strSql.Append("e_source=@e_source,");
                        strSql.Append("e_author=@e_author,");
                        strSql.Append("e_intro=@e_intro,");
                        strSql.Append("e_content=@e_content,");
                        strSql.Append("e_seoTitle=@e_seoTitle,");
                        strSql.Append("e_seoKeyword=@e_seoKeyword,");
                        strSql.Append("e_seoDescription=@e_seoDescription");
                        strSql.Append(" where articleId=@articleId");
                        SqlParameter[] parameters = {
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,150),
					new SqlParameter("@englishtitle", SqlDbType.VarChar,150),
					new SqlParameter("@orderNumber", SqlDbType.Int,4),
					new SqlParameter("@photoUrl", SqlDbType.VarChar,250),
					new SqlParameter("@intro", SqlDbType.Text),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@isRecommend", SqlDbType.Int,4),
					new SqlParameter("@isChannel", SqlDbType.VarChar,350),
					new SqlParameter("@isHidden", SqlDbType.Int,4),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isTop", SqlDbType.Int,4),
					new SqlParameter("@is_msg", SqlDbType.Int,4),
					new SqlParameter("@is_slide", SqlDbType.Int,4),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@Attachment", SqlDbType.VarChar,350),
					new SqlParameter("@expClass", SqlDbType.VarChar,350),
					new SqlParameter("@editTime", SqlDbType.DateTime),
					new SqlParameter("@updateTime", SqlDbType.DateTime),
					new SqlParameter("@txtLinkUrl", SqlDbType.VarChar,350),
					new SqlParameter("@contentUrl", SqlDbType.VarChar,350),
					new SqlParameter("@txtsource", SqlDbType.VarChar,250),
					new SqlParameter("@txtauthor", SqlDbType.VarChar,250),
					new SqlParameter("@w_LinkUrl", SqlDbType.VarChar,350),
					new SqlParameter("@w_contentUrl", SqlDbType.VarChar,350),
					new SqlParameter("@w_intro", SqlDbType.Text),
					new SqlParameter("@w_content", SqlDbType.Text),
					new SqlParameter("@e_LinkUrl", SqlDbType.VarChar,350),
					new SqlParameter("@e_contentUrl", SqlDbType.VarChar,350),
					new SqlParameter("@e_source", SqlDbType.VarChar,250),
					new SqlParameter("@e_author", SqlDbType.VarChar,250),
					new SqlParameter("@e_intro", SqlDbType.Text),
					new SqlParameter("@e_content", SqlDbType.Text),
					new SqlParameter("@e_seoTitle", SqlDbType.VarChar,300),
					new SqlParameter("@e_seoKeyword", SqlDbType.VarChar,300),
					new SqlParameter("@e_seoDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@articleId", SqlDbType.Int,4)};
                        parameters[0].Value = model.parentId;
                        parameters[1].Value = model.title;
                        parameters[2].Value = model.englishtitle;
                        parameters[3].Value = model.orderNumber;
                        parameters[4].Value = model.photoUrl;
                        parameters[5].Value = model.intro;
                        parameters[6].Value = model.content;
                        parameters[7].Value = model.seoTitle;
                        parameters[8].Value = model.seoKeyword;
                        parameters[9].Value = model.seoDescription;
                        parameters[10].Value = model.isRecommend;
                        parameters[11].Value = model.isChannel;
                        parameters[12].Value = model.isHidden;
                        parameters[13].Value = model.isCheck;
                        parameters[14].Value = model.isHot;
                        parameters[15].Value = model.isTop;
                        parameters[16].Value = model.is_msg;
                        parameters[17].Value = model.is_slide;
                        parameters[18].Value = model.hits;
                        parameters[19].Value = model.Attachment;
                        parameters[20].Value = model.expClass;
                        parameters[21].Value = model.editTime;
                        parameters[22].Value = model.updateTime;
                        parameters[23].Value = model.txtLinkUrl;
                        parameters[24].Value = model.contentUrl;
                        parameters[25].Value = model.txtsource;
                        parameters[26].Value = model.txtauthor;
                        parameters[27].Value = model.w_LinkUrl;
                        parameters[28].Value = model.w_contentUrl;
                        parameters[29].Value = model.w_intro;
                        parameters[30].Value = model.w_content;
                        parameters[31].Value = model.e_LinkUrl;
                        parameters[32].Value = model.e_contentUrl;
                        parameters[33].Value = model.e_source;
                        parameters[34].Value = model.e_author;
                        parameters[35].Value = model.e_intro;
                        parameters[36].Value = model.e_content;
                        parameters[37].Value = model.e_seoTitle;
                        parameters[38].Value = model.e_seoKeyword;
                        parameters[39].Value = model.e_seoDescription;
                        parameters[40].Value = model.articleId;

                        int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

                        //修改扩展字段
                        if (model.fields.Count > 0)
                        {
                            StringBuilder strSql2 = new StringBuilder();
                            StringBuilder strFieldName = new StringBuilder(); //字段列表
                            SqlParameter[] parameters2 = new SqlParameter[model.fields.Count + 1];
                            int i = 0;
                            foreach (KeyValuePair<string, string> kvp in model.fields)
                            {
                                strFieldName.Append(kvp.Key + "=@" + kvp.Key + ",");
                                if (kvp.Value.Length <= 4000)
                                {
                                    parameters2[i] = new SqlParameter("@" + kvp.Key, SqlDbType.NVarChar, kvp.Value.Length);
                                }
                                else
                                {
                                    parameters2[i] = new SqlParameter("@" + kvp.Key, SqlDbType.NText);
                                }
                                parameters2[i].Value = kvp.Value;
                                i++;
                            }
                            strSql2.Append("update C_article_attribute_value set ");
                            strSql2.Append(Utils.DelLastComma(strFieldName.ToString()));
                            strSql2.Append(" where article_id=@article_id");
                            parameters2[i] = new SqlParameter("@article_id", SqlDbType.Int, 4);
                            parameters2[i].Value = model.articleId;
                            DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                        }

                        //删除已删除的图片
                        new C_article_albums().DeleteList(conn, trans, model.albums, model.articleId);
                        //添加/修改相册
                        if (model.albums != null)
                        {
                            StringBuilder strSql3;
                            foreach (Cms.Model.C_article_albums modelt in model.albums)
                            {
                                strSql3 = new StringBuilder();
                                if (modelt.id > 0)
                                {
                                    strSql3.Append("update C_article_albums set ");
                                    strSql3.Append("article_id=@article_id,");
                                    strSql3.Append("thumb_path=@thumb_path,");
                                    strSql3.Append("original_path=@original_path,");
                                    strSql3.Append("remark=@remark");
                                    strSql3.Append(" where id=@id");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@article_id", SqlDbType.Int,4),
					                        new SqlParameter("@thumb_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@original_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@remark", SqlDbType.NVarChar,500),
                                            new SqlParameter("@id", SqlDbType.Int,4)};
                                    parameters3[0].Value = modelt.article_id;
                                    parameters3[1].Value = modelt.thumb_path;
                                    parameters3[2].Value = modelt.original_path;
                                    parameters3[3].Value = modelt.remark;
                                    parameters3[4].Value = modelt.id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                                else
                                {
                                    strSql3.Append("insert into C_article_albums(");
                                    strSql3.Append("article_id,thumb_path,original_path,remark)");
                                    strSql3.Append(" values (");
                                    strSql3.Append("@article_id,@thumb_path,@original_path,@remark)");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@article_id", SqlDbType.Int,4),
					                        new SqlParameter("@thumb_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@original_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@remark", SqlDbType.NVarChar,500)};
                                    parameters3[0].Value = modelt.article_id;
                                    parameters3[1].Value = modelt.thumb_path;
                                    parameters3[2].Value = modelt.original_path;
                                    parameters3[3].Value = modelt.remark;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                            }
                        }

                        //删除已删除的附件
                        new C_article_attach().DeleteList(conn, trans, model.attach, model.articleId);
                        // 添加/修改附件
                        if (model.attach != null)
                        {
                            StringBuilder strSql4;
                            foreach (Cms.Model.C_article_attach modelt in model.attach)
                            {
                                strSql4 = new StringBuilder();
                                if (modelt.id > 0)
                                {
                                    strSql4.Append("update C_article_attach set ");
                                    strSql4.Append("article_id=@article_id,");
                                    strSql4.Append("file_name=@file_name,");
                                    strSql4.Append("file_path=@file_path,");
                                    strSql4.Append("file_size=@file_size,");
                                    strSql4.Append("file_ext=@file_ext,");
                                    strSql4.Append("point=@point");
                                    strSql4.Append(" where id=@id");
                                    SqlParameter[] parameters4 = {
					                        new SqlParameter("@article_id", SqlDbType.Int,4),
					                        new SqlParameter("@file_name", SqlDbType.NVarChar,100),
					                        new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@file_size", SqlDbType.Int,4),
					                        new SqlParameter("@file_ext", SqlDbType.NVarChar,20),
					                        new SqlParameter("@point", SqlDbType.Int,4),
					                        new SqlParameter("@id", SqlDbType.Int,4)};
                                    parameters4[0].Value = modelt.article_id;
                                    parameters4[1].Value = modelt.file_name;
                                    parameters4[2].Value = modelt.file_path;
                                    parameters4[3].Value = modelt.file_size;
                                    parameters4[4].Value = modelt.file_ext;
                                    parameters4[5].Value = modelt.point;
                                    parameters4[6].Value = modelt.id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql4.ToString(), parameters4);
                                }
                                else
                                {
                                    strSql4.Append("insert into C_article_attach(");
                                    strSql4.Append("article_id,file_name,file_path,file_size,file_ext,down_num,point)");
                                    strSql4.Append(" values (");
                                    strSql4.Append("@article_id,@file_name,@file_path,@file_size,@file_ext,@down_num,@point)");
                                    SqlParameter[] parameters4 = {
					                        new SqlParameter("@article_id", SqlDbType.Int,4),
					                        new SqlParameter("@file_name", SqlDbType.NVarChar,100),
					                        new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@file_size", SqlDbType.Int,4),
					                        new SqlParameter("@file_ext", SqlDbType.NVarChar,20),
					                        new SqlParameter("@down_num", SqlDbType.Int,4),
					                        new SqlParameter("@point", SqlDbType.Int,4)};
                                    parameters4[0].Value = modelt.article_id;
                                    parameters4[1].Value = modelt.file_name;
                                    parameters4[2].Value = modelt.file_path;
                                    parameters4[3].Value = modelt.file_size;
                                    parameters4[4].Value = modelt.file_ext;
                                    parameters4[5].Value = modelt.down_num;
                                    parameters4[6].Value = modelt.point;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql4.ToString(), parameters4);
                                }
                            }
                        }

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
		public bool Delete(int articleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_article ");
			strSql.Append(" where articleId=@articleId");
			SqlParameter[] parameters = {
					new SqlParameter("@articleId", SqlDbType.Int,4)
			};
			parameters[0].Value = articleId;

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
		public bool DeleteList(string articleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_article ");
			strSql.Append(" where articleId in ("+articleIdlist + ")  ");
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
		public Cms.Model.C_article GetModel(int articleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from C_article ");
			strSql.Append(" where articleId=@articleId");
			SqlParameter[] parameters = {
					new SqlParameter("@articleId", SqlDbType.Int,4)
			};
			parameters[0].Value = articleId;

			Cms.Model.C_article model=new Cms.Model.C_article();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
                #region 主表信息======================
                if (ds.Tables[0].Rows[0]["articleId"].ToString() != "")
                {
                    model.articleId = int.Parse(ds.Tables[0].Rows[0]["articleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parentId"].ToString() != "")
                {
                    model.parentId = int.Parse(ds.Tables[0].Rows[0]["parentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderNumber"].ToString() != "")
                {
                    model.orderNumber = int.Parse(ds.Tables[0].Rows[0]["orderNumber"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.englishtitle = ds.Tables[0].Rows[0]["englishtitle"].ToString();
                model.photoUrl = ds.Tables[0].Rows[0]["photoUrl"].ToString();
                model.intro = ds.Tables[0].Rows[0]["intro"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                model.seoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                model.seoKeyword = ds.Tables[0].Rows[0]["seoKeyword"].ToString();
                model.seoDescription = ds.Tables[0].Rows[0]["seoDescription"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["isRecommend"].ToString() != "")
                {
                    model.isRecommend = int.Parse(ds.Tables[0].Rows[0]["isRecommend"].ToString());
                }
                model.isChannel = ds.Tables[0].Rows[0]["isChannel"].ToString();
              
                if (ds.Tables[0].Rows[0]["isHidden"].ToString() != "")
                {
                    model.isHidden = int.Parse(ds.Tables[0].Rows[0]["isHidden"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isCheck"].ToString() != "")
                {
                    model.isCheck = int.Parse(ds.Tables[0].Rows[0]["isCheck"].ToString());
                }
                
                if (ds.Tables[0].Rows[0]["isHot"].ToString() != "")
                {
                    model.isHot = int.Parse(ds.Tables[0].Rows[0]["isHot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isTop"].ToString() != "")
                {
                    model.isTop = int.Parse(ds.Tables[0].Rows[0]["isTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_msg"].ToString() != "")
                {
                    model.is_msg = int.Parse(ds.Tables[0].Rows[0]["is_msg"].ToString());
                }
                
                if (ds.Tables[0].Rows[0]["is_slide"].ToString() != "")
                {
                    model.is_slide = int.Parse(ds.Tables[0].Rows[0]["is_slide"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hits"].ToString() != "")
                {
                    model.hits = int.Parse(ds.Tables[0].Rows[0]["hits"].ToString());
                }

                model.Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                model.expClass = ds.Tables[0].Rows[0]["expClass"].ToString();
                if (ds.Tables[0].Rows[0]["editTime"].ToString() != "")
                {
                    model.editTime = DateTime.Parse(ds.Tables[0].Rows[0]["editTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["updateTime"].ToString() != "")
                {
                    model.updateTime = DateTime.Parse(ds.Tables[0].Rows[0]["updateTime"].ToString());
                }
                
                model.txtLinkUrl = ds.Tables[0].Rows[0]["txtLinkUrl"].ToString();
                model.contentUrl = ds.Tables[0].Rows[0]["contentUrl"].ToString();
                model.txtsource = ds.Tables[0].Rows[0]["txtsource"].ToString();
                model.txtauthor = ds.Tables[0].Rows[0]["txtauthor"].ToString();
                model.w_LinkUrl = ds.Tables[0].Rows[0]["w_LinkUrl"].ToString();
                model.w_contentUrl = ds.Tables[0].Rows[0]["w_contentUrl"].ToString();
                model.w_intro = ds.Tables[0].Rows[0]["w_intro"].ToString();
                model.w_content = ds.Tables[0].Rows[0]["w_content"].ToString();
                model.e_LinkUrl = ds.Tables[0].Rows[0]["e_LinkUrl"].ToString();

                model.e_contentUrl = ds.Tables[0].Rows[0]["e_contentUrl"].ToString();
                model.e_source = ds.Tables[0].Rows[0]["e_source"].ToString();
                model.e_author = ds.Tables[0].Rows[0]["e_author"].ToString();
                model.e_intro = ds.Tables[0].Rows[0]["e_intro"].ToString();
                model.e_content = ds.Tables[0].Rows[0]["e_content"].ToString();
                model.e_seoTitle = ds.Tables[0].Rows[0]["e_seoTitle"].ToString();
                model.e_seoKeyword = ds.Tables[0].Rows[0]["e_seoKeyword"].ToString();
                model.e_seoDescription = ds.Tables[0].Rows[0]["e_seoDescription"].ToString();
               

                #endregion

                #region 扩展字段信息==================
                //查询该频道的扩展字段名称
                DataTable dt = new C_article_attribute_field().GetList(Convert.ToInt32(model.parentId), "").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow dr in dt.Rows)
                    {
                        sb.Append(dr["name"].ToString() + ",");
                    }
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("select top 1 " + Utils.DelLastComma(sb.ToString()) + " from C_article_attribute_value ");
                    strSql2.Append(" where article_id=@article_id ");
                    SqlParameter[] parameters2 = {
					    new SqlParameter("@article_id", SqlDbType.Int,4)};
                    parameters2[0].Value = articleId;

                    DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (ds2.Tables[0].Rows[0][dr["name"].ToString()] != null)
                            {
                                dic.Add(dr["name"].ToString(), ds2.Tables[0].Rows[0][dr["name"].ToString()].ToString());
                            }
                            else
                            {
                                dic.Add(dr["name"].ToString(), "");
                            }
                        }
                        model.fields = dic;
                    }
                }

                #endregion
                //相册信息
                model.albums = new C_article_albums().GetList(articleId);
                //附件信息
                model.attach = new C_article_attach().GetList(articleId);

                return model;
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.C_article DataRowToModel(DataRow row)
		{
			Cms.Model.C_article model=new Cms.Model.C_article();
			if (row != null)
			{
				if(row["articleId"]!=null && row["articleId"].ToString()!="")
				{
					model.articleId=int.Parse(row["articleId"].ToString());
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["englishtitle"]!=null)
				{
					model.englishtitle=row["englishtitle"].ToString();
				}
				if(row["orderNumber"]!=null && row["orderNumber"].ToString()!="")
				{
					model.orderNumber=int.Parse(row["orderNumber"].ToString());
				}
				if(row["photoUrl"]!=null)
				{
					model.photoUrl=row["photoUrl"].ToString();
				}
				if(row["intro"]!=null)
				{
					model.intro=row["intro"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
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
				if(row["hits"]!=null && row["hits"].ToString()!="")
				{
					model.hits=int.Parse(row["hits"].ToString());
				}
				if(row["Attachment"]!=null)
				{
					model.Attachment=row["Attachment"].ToString();
				}
				if(row["expClass"]!=null)
				{
					model.expClass=row["expClass"].ToString();
				}
				if(row["editTime"]!=null && row["editTime"].ToString()!="")
				{
					model.editTime=DateTime.Parse(row["editTime"].ToString());
				}
				if(row["updateTime"]!=null && row["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(row["updateTime"].ToString());
				}
				if(row["txtLinkUrl"]!=null)
				{
					model.txtLinkUrl=row["txtLinkUrl"].ToString();
				}
				if(row["contentUrl"]!=null)
				{
					model.contentUrl=row["contentUrl"].ToString();
				}
				if(row["txtsource"]!=null)
				{
					model.txtsource=row["txtsource"].ToString();
				}
				if(row["txtauthor"]!=null)
				{
					model.txtauthor=row["txtauthor"].ToString();
				}
				if(row["w_LinkUrl"]!=null)
				{
					model.w_LinkUrl=row["w_LinkUrl"].ToString();
				}
				if(row["w_contentUrl"]!=null)
				{
					model.w_contentUrl=row["w_contentUrl"].ToString();
				}
				if(row["w_intro"]!=null)
				{
					model.w_intro=row["w_intro"].ToString();
				}
				if(row["w_content"]!=null)
				{
					model.w_content=row["w_content"].ToString();
				}
				if(row["e_LinkUrl"]!=null)
				{
					model.e_LinkUrl=row["e_LinkUrl"].ToString();
				}
				if(row["e_contentUrl"]!=null)
				{
					model.e_contentUrl=row["e_contentUrl"].ToString();
				}
				if(row["e_source"]!=null)
				{
					model.e_source=row["e_source"].ToString();
				}
				if(row["e_author"]!=null)
				{
					model.e_author=row["e_author"].ToString();
				}
				if(row["e_intro"]!=null)
				{
					model.e_intro=row["e_intro"].ToString();
				}
				if(row["e_content"]!=null)
				{
					model.e_content=row["e_content"].ToString();
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
			strSql.Append(" FROM C_article ");
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
			strSql.Append(" FROM C_article ");
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
			strSql.Append("select count(1) FROM C_article ");
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
				strSql.Append("order by T.articleId desc");
			}
			strSql.Append(")AS Row, T.*  from C_article T ");
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
			parameters[0].Value = "C_article";
			parameters[1].Value = "articleId";
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

