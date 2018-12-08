/**  版本信息模板在安装目录下，可自行修改。
* C_Province.cs
*
* 功 能： N/A
* 类 名： C_Province
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/2/28 14:12:43   N/A    初版
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
	/// C_Province
	/// </summary>
	public partial class C_Province
	{
        private readonly SQLServerDAL.C_Province dal=new SQLServerDAL.C_Province();
		public C_Province()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ProvinceID)
		{
			return dal.Exists(ProvinceID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Cms.Model.C_Province model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Cms.Model.C_Province model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ProvinceID)
		{
			
			return dal.Delete(ProvinceID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProvinceIDlist )
		{
			return dal.DeleteList(ProvinceIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.C_Province GetModel(long ProvinceID)
		{
			
			return dal.GetModel(ProvinceID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Cms.Model.C_Province GetModelByCache(long ProvinceID)
		{
			
			string CacheKey = "C_ProvinceModel-" + ProvinceID;
            object objModel = Cms.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProvinceID);
					if (objModel != null)
					{
                        int ModelCache = Cms.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Cms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Cms.Model.C_Province)objModel;
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
		public List<Cms.Model.C_Province> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Cms.Model.C_Province> DataTableToList(DataTable dt)
		{
			List<Cms.Model.C_Province> modelList = new List<Cms.Model.C_Province>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Cms.Model.C_Province model;
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

