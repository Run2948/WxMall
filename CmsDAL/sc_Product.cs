using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:sc_Product
	/// </summary>
	public partial class sc_Product
	{
		public sc_Product()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "sc_Product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sc_Product");
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
		public int Add(Cms.Model.sc_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sc_Product(");
			strSql.Append("pid,pname,picurl,Price,marketpice,Material,Property,integral,stock,content,updatetime,isjf)");
			strSql.Append(" values (");
			strSql.Append("@pid,@pname,@picurl,@Price,@marketpice,@Material,@Property,@integral,@stock,@content,@updatetime,@isjf)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,100),
					new SqlParameter("@picurl", SqlDbType.NVarChar,100),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@marketpice", SqlDbType.Money,8),
					new SqlParameter("@Material", SqlDbType.NVarChar,50),
					new SqlParameter("@Property", SqlDbType.NVarChar,50),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@isjf", SqlDbType.Int,4)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.pname;
			parameters[2].Value = model.picurl;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.marketpice;
			parameters[5].Value = model.Material;
			parameters[6].Value = model.Property;
			parameters[7].Value = model.integral;
			parameters[8].Value = model.stock;
			parameters[9].Value = model.content;
			parameters[10].Value = model.updatetime;
			parameters[11].Value = model.isjf;

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
		public bool Update(Cms.Model.sc_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sc_Product set ");
			strSql.Append("pid=@pid,");
			strSql.Append("pname=@pname,");
			strSql.Append("picurl=@picurl,");
			strSql.Append("Price=@Price,");
			strSql.Append("marketpice=@marketpice,");
			strSql.Append("Material=@Material,");
			strSql.Append("Property=@Property,");
			strSql.Append("integral=@integral,");
			strSql.Append("stock=@stock,");
			strSql.Append("content=@content,");
			strSql.Append("updatetime=@updatetime,");
			strSql.Append("isjf=@isjf");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,100),
					new SqlParameter("@picurl", SqlDbType.NVarChar,100),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@marketpice", SqlDbType.Money,8),
					new SqlParameter("@Material", SqlDbType.NVarChar,50),
					new SqlParameter("@Property", SqlDbType.NVarChar,50),
					new SqlParameter("@integral", SqlDbType.Int,4),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@isjf", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.pname;
			parameters[2].Value = model.picurl;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.marketpice;
			parameters[5].Value = model.Material;
			parameters[6].Value = model.Property;
			parameters[7].Value = model.integral;
			parameters[8].Value = model.stock;
			parameters[9].Value = model.content;
			parameters[10].Value = model.updatetime;
			parameters[11].Value = model.isjf;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from sc_Product ");
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
			strSql.Append("delete from sc_Product ");
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
		public Cms.Model.sc_Product GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pid,pname,picurl,Price,marketpice,Material,Property,integral,stock,content,updatetime,isjf from sc_Product ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.sc_Product model=new Cms.Model.sc_Product();
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
		public Cms.Model.sc_Product DataRowToModel(DataRow row)
		{
			Cms.Model.sc_Product model=new Cms.Model.sc_Product();
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
				if(row["picurl"]!=null)
				{
					model.picurl=row["picurl"].ToString();
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["marketpice"]!=null && row["marketpice"].ToString()!="")
				{
					model.marketpice=decimal.Parse(row["marketpice"].ToString());
				}
				if(row["Material"]!=null)
				{
					model.Material=row["Material"].ToString();
				}
				if(row["Property"]!=null)
				{
					model.Property=row["Property"].ToString();
				}
				if(row["integral"]!=null && row["integral"].ToString()!="")
				{
					model.integral=int.Parse(row["integral"].ToString());
				}
				if(row["stock"]!=null && row["stock"].ToString()!="")
				{
					model.stock=int.Parse(row["stock"].ToString());
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["updatetime"]!=null && row["updatetime"].ToString()!="")
				{
					model.updatetime=DateTime.Parse(row["updatetime"].ToString());
				}
				if(row["isjf"]!=null && row["isjf"].ToString()!="")
				{
					model.isjf=int.Parse(row["isjf"].ToString());
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
			strSql.Append("select id,pid,pname,picurl,Price,marketpice,Material,Property,integral,stock,content,updatetime,isjf ");
			strSql.Append(" FROM sc_Product ");
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
			strSql.Append(" id,pid,pname,picurl,Price,marketpice,Material,Property,integral,stock,content,updatetime,isjf ");
			strSql.Append(" FROM sc_Product ");
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
			strSql.Append("select count(1) FROM sc_Product ");
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
			strSql.Append(")AS Row, T.*  from sc_Product T ");
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
			parameters[0].Value = "sc_Product";
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

