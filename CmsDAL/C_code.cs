using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cms.DBUtility;//Please add references
namespace Cms.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:C_code
	/// </summary>
	public partial class C_code
	{
		public C_code()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "C_code"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_code");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


        public string newcode(string sphone)
        {
            string code = "";
            Random newRandom = new Random();
            for (int i = 0; i < 4; i++)
            {
                code = code + newRandom.Next(1,9).ToString();
            }
            Cms.Model.C_code cm = new Model.C_code();
            cm.vphone = sphone;
            cm.vcode = code;
            cm.isare = 1;
            cm.updatetime = DateTime.Now;
            Add(cm);
            return code;
        }

        public bool setcode(string sphone)
        {
            bool bl = false;

            string strSql = "select top 1 * from C_code where DateDiff(dd,updatetime,getdate())=0 and vphone='" + sphone + "' and isare=1 order by id desc";
            DataTable dt=DbHelperSQL.Query(strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Cms.Model.C_code cm = new Model.C_code();
                cm = GetModel(int.Parse(dt.Rows[0]["id"].ToString()));
                cm.isare = 0;
                Update(cm);
                bl = true;
            }

            return bl;
        }

        public bool getcode(string sphone,string code)
        {
            bool bl = false;

            string strSql = "select top 1 * from C_code where DateDiff(dd,updatetime,getdate())=0 and vphone='" + sphone + "' and vcode='"+code+"' and isare=1 order by id desc";
            DataTable dt = DbHelperSQL.Query(strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                bl = true;
            }

            return bl;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Cms.Model.C_code model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_code(");
			strSql.Append("vcode,vphone,isare,updatetime)");
			strSql.Append(" values (");
			strSql.Append("@vcode,@vphone,@isare,@updatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@vcode", SqlDbType.NVarChar,50),
					new SqlParameter("@vphone", SqlDbType.NVarChar,50),
					new SqlParameter("@isare", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.vcode;
			parameters[1].Value = model.vphone;
			parameters[2].Value = model.isare;
			parameters[3].Value = model.updatetime;

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
		public bool Update(Cms.Model.C_code model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_code set ");
			strSql.Append("vcode=@vcode,");
			strSql.Append("vphone=@vphone,");
			strSql.Append("isare=@isare,");
			strSql.Append("updatetime=@updatetime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@vcode", SqlDbType.NVarChar,50),
					new SqlParameter("@vphone", SqlDbType.NVarChar,50),
					new SqlParameter("@isare", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.vcode;
			parameters[1].Value = model.vphone;
			parameters[2].Value = model.isare;
			parameters[3].Value = model.updatetime;
			parameters[4].Value = model.id;

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
			strSql.Append("delete from C_code ");
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
			strSql.Append("delete from C_code ");
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
		public Cms.Model.C_code GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,vcode,vphone,isare,updatetime from C_code ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Cms.Model.C_code model=new Cms.Model.C_code();
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
		public Cms.Model.C_code DataRowToModel(DataRow row)
		{
			Cms.Model.C_code model=new Cms.Model.C_code();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["vcode"]!=null)
				{
					model.vcode=row["vcode"].ToString();
				}
				if(row["vphone"]!=null)
				{
					model.vphone=row["vphone"].ToString();
				}
				if(row["isare"]!=null && row["isare"].ToString()!="")
				{
					model.isare=int.Parse(row["isare"].ToString());
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
			strSql.Append("select id,vcode,vphone,isare,updatetime ");
			strSql.Append(" FROM C_code ");
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
			strSql.Append(" id,vcode,vphone,isare,updatetime ");
			strSql.Append(" FROM C_code ");
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
			strSql.Append("select count(1) FROM C_code ");
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
			strSql.Append(")AS Row, T.*  from C_code T ");
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
			parameters[0].Value = "C_code";
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

