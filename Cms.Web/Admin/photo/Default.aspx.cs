
using System;

using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.Services;
using System.Configuration;

using Tryine.FileManager;
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {


                BindGrid();
            }
            catch (Exception er)
            {
               // ErrHandler.WriteError(er);
            }

        }
    }

    #region BindGrid()
    private void BindGrid()
    {
        List<FileSystemItem> list = FileSystemManager.GetItems();
        GridView1.DataSource = list;
        GridView1.DataBind();
        lblCurrentPath.Text = FileSystemManager.GetRootPath();
    }

    private void BindGrid(string path)
    {
        List<FileSystemItem> list = FileSystemManager.GetItems(path);
        GridView1.DataSource = list;
        GridView1.DataBind();
        lblCurrentPath.Text = path;
    }
    #endregion

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lb = (LinkButton)e.Row.Cells[1].FindControl("LinkButton1");
            string s = lb.CommandArgument.ToString();

            //lb.Attributes["rel"] =  s;
            if (lb.Text != "Root" && lb.Text != "Superior")
            {
                if (Directory.Exists(lb.CommandArgument.ToString()))
                {
                    lb.Text = string.Format("<img src=\"images/file/folder.gif\" style=\"border:none; vertical-align:middle;\" /> {0}", lb.Text);
                    
                }
                else
                {
                    string ext = lb.CommandArgument.ToString().Substring(lb.CommandArgument.LastIndexOf(".") + 1);
                    if (File.Exists(Server.MapPath(string.Format("images/file/{0}.gif", ext))))
                    {
                        lb.Text = string.Format("<img src=\"images/file/{0}.gif\" style=\"border:none; vertical-align:middle;\" /> {1}", ext, lb.Text);
                        
                    }
                    else
                    {
                        lb.Text = string.Format("<img src=\"images/file/other.gif\" style=\"border:none; vertical-align:middle;\" /> {0}", lb.Text);
                        
                    }
                }
            }
            else
            {
                e.Row.Cells[0].Controls.Clear();
            }
        }
    }

    /// <summary>
    /// 下载图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Directory.Exists(e.CommandArgument.ToString()))
        {
            BindGrid(e.CommandArgument.ToString());
        }
        else
        {
            string s = e.CommandArgument.ToString();
            string strs = s.Substring(s.LastIndexOf("\\Upload"));
            strs = strs.Replace("\\", "/");
            Response.Redirect("../Download.aspx?url=" + strs, true);
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("CheckBox1");
                if (cb.Checked)
                {
                    LinkButton lb = (LinkButton)row.Cells[1].FindControl("LinkButton1");
                    if (Directory.Exists(lb.CommandArgument))
                    {
                        FileSystemManager.DeleteFolder(lb.CommandArgument);
                    }
                    else
                    {
                        FileSystemManager.DeleteFile(lb.CommandArgument);
                    }
                }
            }
        }
        BindGrid(lblCurrentPath.Text);
    }

    

    

    /// <summary>
    /// 上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            String ymd = DateTime.Now.ToString("yyyyMMdd");
            String path = Server.MapPath("~/Upload/image/");
            path += ymd + "/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
           // path +=Path.GetFileName(FileUpload1.FileName);
            String fileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = path + newFileName;
            FileUpload1.PostedFile.SaveAs(filePath);
            BindGrid(lblCurrentPath.Text);
        }
    }






    /// <summary>
    /// 下载图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btndownload_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("CheckBox1");
                if (cb.Checked)
                {
                    LinkButton lb = (LinkButton)row.Cells[1].FindControl("LinkButton1");
                    string s=lb.CommandArgument;
                    string strs = s.Substring(s.LastIndexOf("\\Upload"));
                    strs = strs.Replace("\\", "/");
                    string fileName = lb.Text;//客户端保存的文件名 
                    string filePath = Server.MapPath(strs);//路径

                    //以字符流的形式下载文件 
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    byte[] bytes = new byte[(int)fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();
                    Response.ContentType = "application/octet-stream";
                    //通知浏览器下载文件而不是打开 
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    //Response.End();
                    //Response.Redirect("../Download.aspx?url="+strs,true);

                }
            }
        }
        BindGrid(lblCurrentPath.Text);
    }
}