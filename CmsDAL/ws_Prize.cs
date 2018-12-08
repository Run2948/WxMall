using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:ws_Prize
	/// </summary>
	public partial class ws_Prize
	{
		public ws_Prize()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "ws_Prize"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ws_Prize");
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
		public int Add(Cms.Model.ws_Prize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ws_Prize(");
			strSql.Append("pid,pname,prize,quantity,probability,orderNumber,updatetime)");
			strSql.Append(" values (");
			strSql.Append("@pid,@pname,@prize,@quantity,@probability,@orderNumber,@updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,100),
					new SqlParameter("@prize", SqlDbType.NVarChar,50),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@probability", SqlDbType.Int,4),
					new SqlParameter("@orderNumber", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.pname;
			parameters[2].Value = model.prize;
			parameters[3].Value = model.quantity;
			parameters[4].Value = model.probability;
			parameters[5].Value = model.orderNumber;
			parameters[6].Value = model.updatetime;

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
		public bool Update(Cms.Model.ws_Prize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ws_Prize set ");
			strSql.Append("pid=@pid,");
			strSql.Append("pname=@pname,");
			strSql.Append("prize=@prize,");
			strSql.Append("quantity=@quantity,");
			strSql.Append("probability=@probability,");
			strSql.Append("orderNumber=@orderNumber,");
			strSql.Append("updatetime=@updatetime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,100),
					new SqlParameter("@prize", SqlDbType.NVarChar,50),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@probability", SqlDbType.Int,4),
					new SqlParameter("@orderNumber", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.pname;
			parameters[2].Value = model.prize;
			parameters[3].Value = model.quantity;
			parameters[4].Value = model.probability;
			parameters[5].Value = model.orderNumber;
			parameters[6].Value = model.updatetime;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from ws_Prize ");
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
			strSql.Append("delete from ws_Prize ");
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
		public Cms.Model.ws_Prize GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pid,pname,prize,quantity,probability,orderNumber,updatetime from ws_Prize ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.ws_Prize model=new Cms.Model.ws_Prize();
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
		public Cms.Model.ws_Prize DataRowToModel(DataRow row)
		{
			Cms.Model.ws_Prize model=new Cms.Model.ws_Prize();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["pid"]!=null && row["pid"].ToString()!="")
				{
					model.pid=int.Parse(row["pid"].ToString());
				}
				if(row["pname"]!=null)
				{
					model.pname=row["pname"].ToString();
				}
				if(row["prize"]!=null)
				{
					model.prize=row["prize"].ToString();
				}
				if(row["quantity"]!=null && row["quantity"].ToString()!="")
				{
					model.quantity=int.Parse(row["quantity"].ToString());
				}
				if(row["probability"]!=null && row["probability"].ToString()!="")
				{
					model.probability=int.Parse(row["probability"].ToString());
				}
				if(row["orderNumber"]!=null && row["orderNumber"].ToString()!="")
				{
					model.orderNumber=int.Parse(row["orderNumber"].ToString());
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
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
			strSql.Append("select id,pid,pname,prize,quantity,probability,orderNumber,updatetime ");
			strSql.Append(" FROM ws_Prize ");
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
			strSql.Append(" id,pid,pname,prize,quantity,probability,orderNumber,updatetime ");
			strSql.Append(" FROM ws_Prize ");
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
			strSql.Append("select count(1) FROM ws_Prize ");
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
			strSql.Append(")AS Row, T.*  from ws_Prize T ");
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
			parameters[0].Value = "ws_Prize";
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

