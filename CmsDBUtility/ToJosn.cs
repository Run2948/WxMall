using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Web.Script.Serialization;


namespace Cms.DBUtility
{
    public class ToJosn
    {
        #region dataTable转换成Json格式
        /// <summary>      
        /// dataTable转换成Json格式      
        /// </summary>      
        /// <param name="dt"></param>      
        /// <returns></returns>      
        public static string ToJson(ArrayList aliJson)
        {
            StringBuilder sbuBuilder = new StringBuilder();
            sbuBuilder.Append("{\"Value\":[");
            for (int i = 0; i < aliJson.Count; i++)
            {
                sbuBuilder.Append("\"");
                sbuBuilder.Append(aliJson[i].ToString().Replace("\"", "\\\""));
                sbuBuilder.Append("\",");
            }
            if (aliJson.Count > 0)
            {
                sbuBuilder.Remove(sbuBuilder.Length - 1, 1);
            }
            sbuBuilder.Append("]}");
            string strJson = sbuBuilder.ToString();
            strJson = strJson.Replace("\n", "<br />");
            strJson = strJson.Replace("\r", "<br />");
            return strJson;//sbuBuilder.ToString();
        }
        public static string ToJson(DataTable dtaJson)
        {
            StringBuilder sbuBuilder = new StringBuilder();
            sbuBuilder.Append("{\"Rows\":[");
            for (int i = 0; i < dtaJson.Rows.Count; i++)
            {
                sbuBuilder.Append("[");
                for (int j = 0; j < dtaJson.Columns.Count; j++)
                {
                    sbuBuilder.Append("\"");
                    sbuBuilder.Append(dtaJson.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r\n", "<br>"));
                    sbuBuilder.Append("\",");
                }
                sbuBuilder.Remove(sbuBuilder.Length - 1, 1);
                sbuBuilder.Append("],");
            }
            if (dtaJson.Rows.Count > 0)
            {
                sbuBuilder.Remove(sbuBuilder.Length - 1, 1);
            }
            sbuBuilder.Append("]}");

            string strJson = sbuBuilder.ToString();
            strJson = strJson.Replace("\n", "<br />");
            strJson = strJson.Replace("\r", "<br />");

            return strJson;//sbuBuilder.ToString();
        }

        #endregion dataTable转换成Json格式

        #region DataSet转换成Json格式
        /// <summary>      
        /// DataSet转换成Json格式      
        /// </summary>      
        /// <param name="ds">DataSet</param>      
        /// <returns></returns>      
        public static string ToJson(DataSet dseJson)
        {
            StringBuilder sbuBuilder = new StringBuilder();
            sbuBuilder.Append("{\"Tables\":[");
            foreach (DataTable dtJson in dseJson.Tables)
            {
                sbuBuilder.Append(ToJson(dtJson) + ",");
            }
            sbuBuilder.Remove(sbuBuilder.Length - 1, 1);
            sbuBuilder.Append("]}");

            string strJson = sbuBuilder.ToString();
            strJson = strJson.Replace("\n", "<br />");
            strJson = strJson.Replace("\r", "<br />");
            return strJson;//sbuBuilder.ToString();
        }
        #endregion



        /// <summary>
        /// 带表头的
        /// </summary>
        /// <param name="dtaJson"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string ToJson(DataTable dtaJson, bool b)
        {
            StringBuilder sbuBuilder = new StringBuilder();
            sbuBuilder.Append("Rows\":[");
            for (int i = 0; i < dtaJson.Rows.Count; i++)
            {
                sbuBuilder.Append("{");
                for (int j = 0; j < dtaJson.Columns.Count; j++)
                {

                    sbuBuilder.Append("\"" + dtaJson.Columns[j].ColumnName + "\":");
                    sbuBuilder.Append("\"");
                    sbuBuilder.Append(dtaJson.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r\n", "<br>"));
                    sbuBuilder.Append("\",");
                }
                sbuBuilder.Remove(sbuBuilder.Length - 1, 1);
                sbuBuilder.Append("},");
            }
            if (dtaJson.Rows.Count > 0)
            {
                sbuBuilder.Remove(sbuBuilder.Length - 1, 1);
            }
            sbuBuilder.Append("]");

            string strJson = sbuBuilder.ToString();
            strJson = strJson.Replace("\n", "<br />");
            strJson = strJson.Replace("\r", "<br />");

            return strJson;//sbuBuilder.ToString();
        }

        /// <summary>
        /// 带表头的
        /// </summary>
        /// <param name="dseJson"></param>
        /// <returns></returns>
        public static string ToJson(DataSet dseJson, bool b)
        {
            StringBuilder sbuBuilder = new StringBuilder();
            //sbuBuilder.Append("{\"Tables\":[");
            foreach (DataTable dtJson in dseJson.Tables)
            {
                sbuBuilder.Append(ToJson(dtJson, true) + ",");
            }
            sbuBuilder.Remove(sbuBuilder.Length - 1, 1);
            //sbuBuilder.Append("]}");


            string strJson = sbuBuilder.ToString();
            strJson = strJson.Replace("\n", "<br />");
            strJson = strJson.Replace("\r", "<br />");
            return strJson;//sbuBuilder.ToString();
        }



        /// <summary>
        /// 将JSON解析成DataSet只限标准的JSON数据
        /// 例如：Json＝{t1:[{name:'数据name',type:'数据type'}]} 
        /// 或 Json＝{t1:[{name:'数据name',type:'数据type'}],t2:[{id:'数据id',gx:'数据gx',val:'数据val'}]}
        /// </summary>
        /// <param name="Json">Json字符串</param>
        /// <returns>DataSet</returns>
        public static DataSet JsonToDataSet(string Json)
        {
            try
            {
                DataSet ds = new DataSet();
                JavaScriptSerializer JSS = new JavaScriptSerializer();


                object obj = JSS.DeserializeObject(Json);
                Dictionary<string, object> datajson = (Dictionary<string, object>)obj;


                foreach (var item in datajson)
                {
                    DataTable dt = new DataTable(item.Key);
                    object[] rows = (object[])item.Value;
                    foreach (var row in rows)
                    {
                        Dictionary<string, object> val = (Dictionary<string, object>)row;
                        DataRow dr = dt.NewRow();
                        foreach (KeyValuePair<string, object> sss in val)
                        {
                            if (!dt.Columns.Contains(sss.Key))
                            {
                                dt.Columns.Add(sss.Key.ToString());
                                dr[sss.Key] = sss.Value;
                            }
                            else
                                dr[sss.Key] = sss.Value;
                        }
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);
                }
                return ds;
            }
            catch
            {
                return null;
            }
        }




       
    }
}
