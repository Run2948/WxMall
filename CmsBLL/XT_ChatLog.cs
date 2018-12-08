using System;
using System.Data;
using System.Collections.Generic;
using Cms.Common;
using Cms.Model;
namespace Cms.BLL
{
	/// <summary>
	/// XT_ChatLog
	/// </summary>
	public partial class XT_ChatLog
	{
        private readonly SQLServerDAL.XT_ChatLog dal=new SQLServerDAL.XT_ChatLog();
		public XT_ChatLog()
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
		public bool Exists(int Chatid)
		{
			return dal.Exists(Chatid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Cms.Model.XT_ChatLog model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Cms.Model.XT_ChatLog model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Chatid)
		{
			
			return dal.Delete(Chatid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Chatidlist )
		{
			return dal.DeleteList(Chatidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Cms.Model.XT_ChatLog GetModel(int Chatid)
		{
			
			return dal.GetModel(Chatid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Cms.Model.XT_ChatLog GetModelByCache(int Chatid)
		{
			
			string CacheKey = "XT_ChatLogModel-" + Chatid;
            object objModel = Cms.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Chatid);
					if (objModel != null)
					{
                        int ModelCache = Cms.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Cms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Cms.Model.XT_ChatLog)objModel;
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
		public List<Cms.Model.XT_ChatLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Cms.Model.XT_ChatLog> DataTableToList(DataTable dt)
		{
			List<Cms.Model.XT_ChatLog> modelList = new List<Cms.Model.XT_ChatLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Cms.Model.XT_ChatLog model;
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
        public Cms.Model.XT_ChatLog[] GetChatLogList(string FromUserName, string SendUserName)
        {
            return dal.GetChatLogList(FromUserName,SendUserName);
        }

        public Cms.Model.XT_ChatLog[] GetUserList()
        {
            return dal.GetUserList();
        }
        public int GetNotReadCount(string FromUserName, string SendUserName)
        {
            return dal.GetNotReadCount(FromUserName,SendUserName);
        }
        public bool UpdateMsgStatus(string FromUserName, string SendUserName)
        {
            return dal.UpdateMsgStatus(FromUserName, SendUserName);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

