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
using System.Collections.Generic;
using Cms.Common;
using Cms.Model;
namespace Cms.BLL
{
	/// <summary>
	/// C_article_attribute_field
	/// </summary>
	public partial class C_article_attribute_field
	{
        private readonly SQLServerDAL.C_article_attribute_field dal=new SQLServerDAL.C_article_attribute_field();
		public C_article_attribute_field()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}
        #region MyRegion===============================================
        /// <summary>
        /// 查询是否存在列
        /// </summary>
        public bool Exists(string column_name)
        {
            return dal.Exists(column_name);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Cms.Model.C_article_attribute_field model)
        {
            switch (model.control_type)
            {
                case "single-text": //单行文本
                    if (model.data_length > 0 && model.data_length <= 4000)
                    {
                        model.data_type = "nvarchar(" + model.data_length + ")";
                    }
                    else if (model.data_length > 4000)
                    {
                        model.data_type = "ntext";
                    }
                    else
                    {
                        model.data_length = 50;
                        model.data_type = "nvarchar(50)";
                    }
                    break;
                case "multi-text": //多行文本
                    goto case "single-text";
                case "editor": //编辑器
                    model.data_type = "ntext";
                    break;
                case "images": //图片
                    model.data_type = "nvarchar(255)";
                    break;
                case "number": //数字
                    if (model.data_place > 0)
                    {
                        model.data_type = "decimal(9," + model.data_place + ")";
                    }
                    else
                    {
                        model.data_type = "int";
                    }
                    break;
                case "checkbox": //复选框
                    model.data_type = "tinyint";
                    break;
                case "multi-radio": //多项单选
                    if (model.data_type == "int")
                    {
                        model.data_length = 4;
                        model.data_type = "int";
                    }
                    else
                    {
                        if (model.data_length > 0 && model.data_length <= 4000)
                        {
                            model.data_type = "nvarchar(" + model.data_length + ")";
                        }
                        else if (model.data_length > 4000)
                        {
                            model.data_type = "ntext";
                        }
                        else
                        {
                            model.data_length = 50;
                            model.data_type = "nvarchar(50)";
                        }
                    }

                    break;
                case "multi-checkbox": //多项多选
                    goto case "single-text";
            }
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Cms.Model.C_article_attribute_field model)
        {
            switch (model.control_type)
            {
                case "single-text": //单行文本
                    if (model.data_length > 0 && model.data_length <= 4000)
                    {
                        model.data_type = "nvarchar(" + model.data_length + ")";
                    }
                    else if (model.data_length > 4000)
                    {
                        model.data_type = "ntext";
                    }
                    else
                    {
                        model.data_length = 50;
                        model.data_type = "nvarchar(50)";
                    }
                    break;
                case "multi-text": //多行文本
                    goto case "single-text";
                case "editor": //编辑器
                    model.data_type = "ntext";
                    break;
                case "images": //图片
                    model.data_type = "nvarchar(255)";
                    break;
                case "number": //数字
                    if (model.data_place > 0)
                    {
                        model.data_type = "decimal(9," + model.data_place + ")";
                    }
                    else
                    {
                        model.data_type = "int";
                    }
                    break;
                case "checkbox": //复选框
                    model.data_type = "tinyint";
                    break;
                case "multi-radio": //多项单选
                    if (model.data_type == "int")
                    {
                        model.data_length = 4;
                        model.data_type = "int";
                    }
                    else
                    {
                        if (model.data_length > 0 && model.data_length <= 4000)
                        {
                            model.data_type = "nvarchar(" + model.data_length + ")";
                        }
                        else if (model.data_length > 4000)
                        {
                            model.data_type = "ntext";
                        }
                        else
                        {
                            model.data_length = 50;
                            model.data_type = "nvarchar(50)";
                        }
                    }

                    break;
                case "multi-checkbox": //多项多选
                    goto case "single-text";
            }
            return dal.Update(model);
        }
        /// <summary>
        /// 获得频道对应的数据
        /// </summary>
        public DataSet GetList(int channel_id, string strWhere)
        {
            return dal.GetList(channel_id, strWhere);
        }
        #endregion
		

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.C_article_attribute_field GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Cms.Model.C_article_attribute_field GetModelByCache(int id)
		{
			
			string CacheKey = "C_article_attribute_fieldModel-" + id;
            object objModel = Cms.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
                        int ModelCache = Cms.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Cms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Cms.Model.C_article_attribute_field)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Cms.Model.C_article_attribute_field> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        #region 获得数据列表=======================
         /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.C_article_attribute_field> GetModelList(int channel_id, string strWhere)
        {
            DataSet ds = dal.GetList(channel_id, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Cms.Model.C_article_attribute_field> DataTableToList(DataTable dt)
		{
			List<Cms.Model.C_article_attribute_field> modelList = new List<Cms.Model.C_article_attribute_field>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Cms.Model.C_article_attribute_field model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

