using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Drawing;
/// <summary>
///Excel 的摘要说明
/// </summary>
public class Excel
{
	public Excel()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static void ReportToExcel(System.Web.UI.Control ctl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();
        ctl.EnableViewState = false;
        page.EnableEventValidation = false;
        page.DesignerInitialize();
        page.Controls.Add(form);
        form.Controls.Add(ctl);
        page.RenderControl(htw);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("OrderData.xls", Encoding.UTF8).ToString());
        HttpContext.Current.Response.Charset = "UTF-8";
        HttpContext.Current.Response.ContentEncoding = Encoding.Default;
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }

    public static void ReportToExcel(System.Web.UI.Control ctl, string fileName)
    {
        //HttpContext.Current.Response.Clear();
        //HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Charset = "gb2312";

        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName + ".xls", Encoding.UTF8).ToString());
        ClearChildControls(ctl);
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        ctl.RenderControl(htw);
        HttpContext.Current.Response.Write(sw.ToString());
        HttpContext.Current.Response.End();
    }
    private static void RecursiveClear(Control control)
    {

        for (int i = control.Controls.Count - 1; i >= 0; i--)
        {
            RecursiveClear(control.Controls[i]);
        }

        if (control is Repeater)
        {
            control.Parent.Controls.Remove(control);//
        }
        else if (control is LinkButton)
        {
            LiteralControl literal = new LiteralControl();
            control.Parent.Controls.Add(literal);
            literal.Text = ((LinkButton)control).Text;
            control.Parent.Controls.Remove(control);
        }
        else if (control is Button)
        {
            control.Parent.Controls.Remove(control);
        }

        else if (control is System.Web.UI.WebControls.Image)
        {
            if (((System.Web.UI.WebControls.Image)control).Visible)
            {
                control.Parent.Controls.Add(new LiteralControl("<span style='font-size:8px;'>o</span>"));
            }
            control.Parent.Controls.Remove(control);
        }
        else if (control is ListControl)
        {
            LiteralControl literal = new LiteralControl();
            control.Parent.Controls.Add(literal);
            try
            {
                literal.Text = ((ListControl)control).SelectedItem.Text;
            }
            catch
            {
            }
            control.Parent.Controls.Remove(control);

        }

        return;
    }
    protected static void ClearChildControls(Control dg1)
    {
        if (dg1 is GridView)
        {
            GridView dg = (GridView)dg1;
            for (int i = dg.Columns.Count - 1; i >= 0; i--)
            {
                if (dg.Columns[i].GetType().Name == "ButtonColumn"
                    || dg.Columns[i].GetType().Name == "CheckBoxField"
                    || dg.Columns[i].GetType().Name == "CommandField")
                {
                    dg.Columns[i].Visible = false;
                }
            }
            RecursiveClear(dg1);
        }
        else
        {
            RecursiveClear(dg1);
        }
    }
}