using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;

public partial class api_weixin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string opt = Request["opt"];
        switch (opt)
        {
            case "getBanner": getBanner(); break;//获取banner
            case "getAbout": getAbout(); break;//获取公司简介

            case "getCply": getCply(); break;//获取产品来源
            case "getUserCase": getUserCase(); break;//读取用户案例
            case "getCaseVideo": getCaseVideo(); break;//读取案例视频
            case "getProxy": getProxy(); break;//读取地区代理

            case "postMessage": postMessage(); break;//提交表单
            case "getProduct": getProduct(); break;//读取产品列表            
            case "getArticle": getArticle(); break;//读取文章列表
            case "getArticleLitpic": getArticleLitpic(); break;//读取文章的组图
            case "getArticleDe": getArticleDe(); break;//读取文章详情
            case "getProductDe": getProductDe(); break;//读取产品详情
            case "getPre": getPre(); break;//获取上一篇文章
            case "getNext": getNext(); break;//获取下一篇文章

        }
    }

    #region  获取上一篇文章
    public void getPre()
    {
        string id = Request["id"];
        int parentId = new Cms.BLL.C_article().GetModel(Convert.ToInt32(id)).parentId.Value;
        DataSet ds = new Cms.BLL.C_article().GetList(1, "parentId='" + parentId + "' and articleId>" + id, "articleId asc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  获取下一篇文章
    public void getNext()
    {
        string id = Request["id"];
        int parentId = new Cms.BLL.C_article().GetModel(Convert.ToInt32(id)).parentId.Value;
        DataSet ds = new Cms.BLL.C_article().GetList(1, "parentId='" + parentId + "' and articleId<" + id, "articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  获取banner
    public void getBanner()
    {
        DataSet ds = new Cms.BLL.C_ad().GetList(3, "adtype=1", "id desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  获取公司简介
    public void getAbout()
    {
        string cloumnId = Request["cloumnId"];
        string cloumnName = Request["cloumnName"];
        Cms.Model.C_Column model = new Cms.BLL.C_Column().GetModel(Convert.ToInt32(cloumnId));
        if (model != null)
        {
            string strJson = GetJson(model).Replace("{", "{\"" + cloumnName + "\":[{");
            strJson = strJson.Replace("}", "}]}");
            
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  获取产品来源
    public void getCply()
    {
        DataSet dsCply = new Cms.BLL.C_article().GetList(2, "parentId=125", "orderNumber desc,articleId desc");
        if (dsCply != null && dsCply.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(dsCply);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  提交表单
    public void postMessage()
    {
        string name = Request["txtname"];
        string mobile = Request["mobile"];
        string desc = Request["desc"];
        string email = Request["email"];
        Cms.Model.C_message model = new Cms.Model.C_message();
        model.Name = name;
        model.PhoneNum = mobile;
        model.telNum = mobile;
        model.content = desc;
        model.email = email;
        model.updateTime = DateTime.Now;
        int result = new Cms.BLL.C_message().Add(model);
        if (result>0)
        {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = "{\"status\":1}";
            Response.Write(strJson);
            Response.End();
        }
    }
    #endregion

    #region 读取产品列表
    public void getProduct()
    {
        string parentId = Request["parentId"]??"0";
        int pagenow = Convert.ToInt32(Request["page"] ?? "0");
        int pageSize = Convert.ToInt32(Request["pageSize"] ?? "3");
        int start = (pagenow - 1) * pageSize + 1;
        int end = pagenow * pageSize;
        if (pagenow == 0)
        {
            end = 3;
        }
        string str = "SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by T.orderNumber desc, T.articleId desc )AS Row, T.*  from View_product T WHERE parentId=" + parentId + "  ) TT WHERE TT.Row between " + start + " and " + end + "  order by orderNumber desc,articleId desc";
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query(str);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("{\"status\":1}");
            Response.End();
        }
    }
    #endregion

    #region 读取文章列表
    public void getArticle()
    {
        string parentId = Request["parentId"];
        int pagenow = Convert.ToInt32(Request["page"] ?? "0");
        int pageSize = Convert.ToInt32(Request["pageSize"] ?? "3");
        int start = (pagenow - 1) * pageSize + 1;
        int end = pagenow * pageSize;
        if (pagenow == 0)
        {
            end = 3;
        }
        string tearname = new Cms.BLL.C_Column().GetModel(Convert.ToInt32(parentId)).name.ToString();
        string str = "SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by T.orderNumber desc, T.articleId desc )AS Row, T.*  from view_channel_" + tearname + " T WHERE parentId=" + parentId + "  ) TT WHERE TT.Row between " + start + " and " + end + "  order by orderNumber desc,articleId desc";
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query(str);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("{\"status\":1}");
            Response.End();
        }
    }
    #endregion

    #region 读取用户案例
    public void getUserCase()
    {
        string tearname = new Cms.BLL.C_Column().GetModel(122).name.ToString();
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by T.orderNumber desc, T.articleId desc )AS Row, T.*  from view_channel_" + tearname + " T WHERE parentId=122  ) TT WHERE TT.Row between 0 and 3 order by orderNumber desc,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 读取案例视频
    public void getCaseVideo()
    {
        string tearname = new Cms.BLL.C_Column().GetModel(103).name.ToString();
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by T.orderNumber desc, T.articleId desc )AS Row, T.*  from view_channel_" + tearname + " T WHERE parentId=103  ) TT WHERE TT.Row between 0 and 3 order by orderNumber desc,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 读取地区代理
    public void getProxy()
    {
        string tearname = new Cms.BLL.C_Column().GetModel(103).name.ToString();
        DataSet ds = Cms.DBUtility.DbHelperSQL.Query("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by T.orderNumber desc, T.articleId desc )AS Row, T.*  from C_article T WHERE parentId in (97,117,118,119,120,121)  ) TT WHERE TT.Row between 0 and 3 order by orderNumber desc,articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 读取文章的组图
    public void getArticleLitpic()
    {
        string id = Request["id"];
        DataSet ds = new Cms.BLL.C_article_albums().GetList(10, "article_id=" + id, "id desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  读取文章详情
    public void getArticleDe()
    {
        string id = Request["id"];

        DataSet ds = new Cms.BLL.C_article().GetList(1, "articleId=" + id, "articleId desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  读取产品详情
    public void getProductDe()
    {
        string id = Request["id"];
        DataSet ds = new Cms.BLL.C_article_product().GetList(1, "article_id=" + id, "id desc"); 
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            string strJson = ConvertJson.ToJson(ds);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion


    #region  把对象序列化 JSON 字符串
    /// <summary>
    /// 把对象序列化 JSON 字符串 
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="obj">对象实体</param>
    /// <returns>JSON字符串</returns>
    public static string GetJson<T>(T obj)
    {
        //记住 添加引用 System.ServiceModel.Web 
        /**
         * 如果不添加上面的引用,System.Runtime.Serialization.Json; Json是出不来的哦
         * */
        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream())
        {
            json.WriteObject(ms, obj);
            string szJson = Encoding.UTF8.GetString(ms.ToArray());
            return szJson;

        }

    }
    #endregion


    #region  DataSet Datatable转换为Json
    
    public static class ConvertJson
    {
        #region  DataSet转换为Json

        /// <summary>           
        /// DataSet转换为Json     
        /// </summary>       
        /// <param name="dataSet">DataSet对象</param>
        /// <returns>Json字符串</returns>  
        public static string ToJson(DataSet dataSet)
        {
            string jsonString = "{\"status\":0,";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + ToJson(table) + ",";
            }
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }
        #endregion

        #region Datatable转换为Json

        /// <summary>   
        /// Datatable转换为Json 
        /// </summary>      
        /// <param name="table">Datatable对象</param>
        /// <returns>Json字符串</returns>    
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }

        /// <summary>  
        /// DataTable转换为Json 
        /// </summary>    
        public static string ToJson(DataTable dt, string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
                jsonName = dt.TableName;
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type type = dt.Rows[i][j].GetType();
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + StringFormat(dt.Rows[i][j].ToString(), type));
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }

        #endregion

        /// <summary>     
        /// 格式化字符型、日期型、布尔型 
        /// </summary>     
        /// <param name="str"></param>   
        /// <param name="type"></param> 
        /// <returns></returns>     
        private static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            return str;
        }

        #region 私有方法
        /// <summary>     
        /// 过滤特殊字符    
        /// </summary>    
        /// <param name="s">字符串</param> 
        /// <returns>json字符串</returns> 
        private static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
        #endregion
    }
    #endregion 
}