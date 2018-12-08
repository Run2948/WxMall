using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Xml;
/// <summary>
///ExportExcel 的摘要说明
/// </summary>
public class ExportExcel
{
    private StringBuilder s = new StringBuilder();

    /// <summary>
    /// Export Excel use GridView data
    /// </summary>
    /// <param name="Typename"></param>
    /// <param name="TempGrid"></param>
    public static void GenerateByGridView(string Typename, GridView TempGrid)
    {
        HttpContext.Current.Response.Clear();
        //HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Charset = "utf-8";
        string Filename = Typename + ".xls";
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "online;filename=" + Filename);
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        //this.EnableViewState = false;
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        TempGrid.RenderControl(oHtmlTextWriter);
        HttpContext.Current.Response.Write(oStringWriter.ToString());
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// Export Excel use Html string data
    /// </summary>
    /// <param name="Typename"></param>
    /// <param name="TempHtml"></param>
    public static void GenerateByHtmlString(string Typename, string TempHtml)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Charset = "utf-8";
        string Filename = Typename + ".xls";
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "online;filename=" + Filename);
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        //this.EnableViewState = false;
        HttpContext.Current.Response.Write(TempHtml);
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Typename"></param>
    /// <param name="TempHtml"></param>
    public void CreateExcelWithMode(int TableRows, int TableColumns, string FileName)
    {
        string TableString = "";
        TableString += TableStart(TableRows, TableColumns);
        TableString += s.ToString();
        TableString += TableEnd();
        string ModePath = HttpContext.Current.Server.MapPath("~/bin/ExcelMode.xml");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(ModePath);
        string ExcelXmlStr = xmlDoc.InnerXml;
        ExcelXmlStr = ExcelXmlStr.Insert(ExcelXmlStr.IndexOf("</Worksheet>"), TableString);
        GenerateByHtmlString(FileName, ExcelXmlStr);
    }

    #region Draw Excel Table Methods
    private string TableStart(int rows, int columns)
    {
        string TableString = "";
        TableString += "<Table ss:ExpandedRowCount=\"" + rows + "\" ss:ExpandedColumnCount=\"" + columns + "\" x:FullColumns=\"1\"\n";
        TableString += "x:FullRows=\"1\" ss:DefaultColumnWidth=\"70\" ss:DefaultRowHeight=\"14.25\">\n";
        return TableString;
    }
    private string TableEnd()
    {
        string TableString = "";
        TableString += "</Table>\n";
        return TableString;
    }
    public void RowStart()
    {
        s.Append("<Row ss:AutoFitHeight=\"0\">\n");
    }
    public void RowEnd()
    {
        s.Append("</Row>\n");
    }
    public void CellWithoutFormula(string DataType, string Data)
    {
        s.Append("<Cell><Data ss:Type=\"" + DataType + "\">" + Data + "</Data></Cell>\n");
    }
    public void CellWithFormula(string DataType, string Formula)
    {
        s.Append("<Cell ss:Formula=\"=" + Formula + "\"><Data ss:Type=\"" + DataType + "\"></Data></Cell>\n");
    }
    #endregion
}