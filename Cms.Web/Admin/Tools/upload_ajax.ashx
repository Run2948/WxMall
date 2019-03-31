<%@ WebHandler Language="C#" Class="upload_ajax" %>

using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using System.Text.RegularExpressions;
using Cms.Common;
using LitJson;

public class upload_ajax : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //取得处事类型
        string action = DTRequest.GetQueryString("action");

        switch (action)
        {
            case "EditorFile": //编辑器文件
                EditorFile(context);
                break;
            case "ManagerFile": //管理文件
                ManagerFile(context);
                break;
            default: //普通上传
                UpLoadFile(context);
                break;
        }

    }

    #region 上传文件处理===================================
    private void UpLoadFile(HttpContext context)
    {
        string _delfile = DTRequest.GetString("DelFilePath");
        HttpPostedFile _upfile = context.Request.Files["Filedata"];
        bool _iswater = false; //默认不打水印
        bool _isthumbnail = false; //默认不生成缩略图

        if (DTRequest.GetQueryString("IsWater") == "1")
            _iswater = true;
        if (DTRequest.GetQueryString("IsThumbnail") == "1")
            _isthumbnail = true;
        if (_upfile == null)
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
            return;
        }
        UpLoad upFiles = new UpLoad();
        string msg = upFiles.fileSaveAs(_upfile, _isthumbnail, _iswater);
        //删除已存在的旧文件
        if (!string.IsNullOrEmpty(_delfile))
        {
            Utils.DeleteUpFile(_delfile);
        }
        //返回成功信息
        context.Response.Write(msg);
        context.Response.End();
    }
    #endregion

    #region 编辑器上传处理===================================
    private void EditorFile(HttpContext context)
    {
        bool _iswater = false; //默认不打水印
        if (context.Request.QueryString["IsWater"] == "1")
            _iswater = true;
        HttpPostedFile imgFile = context.Request.Files["imgFile"];
        if (imgFile == null)
        {
            showError(context, "请选择要上传文件！");
            return;
        }
        UpLoad upFiles = new UpLoad();
        string remsg = upFiles.fileSaveAs(imgFile, false, _iswater);
        JsonData jd = JsonMapper.ToObject(remsg);
        string status = jd["status"].ToString();
        string msg = jd["msg"].ToString();
        if (status == "0")
        {
            showError(context, msg);
            return;
        }
        string filePath = jd["path"].ToString(); //取得上传后的路径
        Hashtable hash = new Hashtable();
        hash["error"] = 0;
        hash["url"] = filePath;
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(hash));
        context.Response.End();
    }
    //显示错误
    private void showError(HttpContext context, string message)
    {
        Hashtable hash = new Hashtable();
        hash["error"] = 1;
        hash["message"] = message;
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(hash));
        context.Response.End();
    }
    #endregion

    #region 浏览文件处理=====================================
    private void ManagerFile(HttpContext context)
    {
        //Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        //String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

        //根目录路径，相对路径
        String rootPath = "/Upload/image/"; //站点目录+上传目录
        //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
        String rootUrl = "/Upload/image/";
        //图片扩展名
        String fileTypes = "gif,jpg,jpeg,png,bmp";

        String currentPath = "";
        String currentUrl = "";
        String currentDirPath = "";
        String moveupDirPath = "";

        String dirPath = Utils.GetMapPath(rootPath);
        String dirName = context.Request.QueryString["dir"];

        //根据path参数，设置各路径和URL
        String path = context.Request.QueryString["path"];
        path = String.IsNullOrEmpty(path) ? "" : path;
        if (path == "")
        {
            currentPath = dirPath;
            currentUrl = rootUrl;
            currentDirPath = "";
            moveupDirPath = "";
        }
        else
        {
            currentPath = dirPath + path;
            currentUrl = rootUrl + path;
            currentDirPath = path;
            moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
        }

        //排序形式，name or size or type
        String order = context.Request.QueryString["order"];
        order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

        //不允许使用..移动到上一级目录
        if (Regex.IsMatch(path, @"\.\."))
        {
            context.Response.Write("Access is not allowed.");
            context.Response.End();
        }
        //最后一个字符不是/
        if (path != "" && !path.EndsWith("/"))
        {
            context.Response.Write("Parameter is not valid.");
            context.Response.End();
        }
        //目录不存在或不是目录
        if (!Directory.Exists(currentPath))
        {
            context.Response.Write("Directory does not exist.");
            context.Response.End();
        }

        //遍历目录取得文件信息
        string[] dirList = Directory.GetDirectories(currentPath);
        string[] fileList = Directory.GetFiles(currentPath);

        switch (order)
        {
            case "size":
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new SizeSorter());
                break;
            case "type":
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new TypeSorter());
                break;
            case "name":
            default:
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new NameSorter());
                break;
        }

        Hashtable result = new Hashtable();
        result["moveup_dir_path"] = moveupDirPath;
        result["current_dir_path"] = currentDirPath;
        result["current_url"] = currentUrl;
        result["total_count"] = dirList.Length + fileList.Length;
        List<Hashtable> dirFileList = new List<Hashtable>();
        result["file_list"] = dirFileList;
        for (int i = 0; i < dirList.Length; i++)
        {
            DirectoryInfo dir = new DirectoryInfo(dirList[i]);
            Hashtable hash = new Hashtable();
            hash["is_dir"] = true;
            hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
            hash["filesize"] = 0;
            hash["is_photo"] = false;
            hash["filetype"] = "";
            hash["filename"] = dir.Name;
            hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            dirFileList.Add(hash);
        }
        for (int i = 0; i < fileList.Length; i++)
        {
            FileInfo file = new FileInfo(fileList[i]);
            Hashtable hash = new Hashtable();
            hash["is_dir"] = false;
            hash["has_file"] = false;
            hash["filesize"] = file.Length;
            hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
            hash["filetype"] = file.Extension.Substring(1);
            hash["filename"] = file.Name;
            hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            dirFileList.Add(hash);
        }
        context.Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(result));
        context.Response.End();
    }

    #region Helper
    public class NameSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.FullName.CompareTo(yInfo.FullName);
        }
    }

    public class SizeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.Length.CompareTo(yInfo.Length);
        }
    }

    public class TypeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.Extension.CompareTo(yInfo.Extension);
        }
    }
    #endregion
    #endregion
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}