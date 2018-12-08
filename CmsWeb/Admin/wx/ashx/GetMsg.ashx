<%@ WebHandler Language="C#" Class="GetMsg" %>

using System;
using System.Web;
using System.Data;
using System.Text;

public class GetMsg : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string type = context.Request.QueryString["type"];
        string SendUserName = context.Request.QueryString["SendUserName"];
        string Msg = context.Request.QueryString["Msg"];
        string Openid = context.Request.QueryString["Openid"];
        Cms.BLL.XT_ChatLog chatlog = new Cms.BLL.XT_ChatLog();
        Cms.Model.XT_ChatLog chatloginfo = new Cms.Model.XT_ChatLog();
        Cms.BLL.wx_info info = new Cms.BLL.wx_info();
       
        string wxid = info.GetModel(1).wxid;



        Cms.Model.XT_ChatLog[] cl = chatlog.GetChatLogList(wxid, SendUserName);
        Cms.Model.XT_ChatLog[] cllist = chatlog.GetUserList();
       
        string str = "";

        switch (type)
        {
            case "GetMsg":              //获取聊天记录

                for (int i = 0; i < cl.Length; i++)
                {
                    if (cl[i].SendUserName != null)
                    {
                        string NickName = "";

                        if (cl[i].SendUserName == wxid)
                        {
                            NickName = "系统";
                        }
                        else
                        {
                            NickName = wxuser.getwxuserinfo(cl[i].SendUserName).nickname.ToString();
                            if (NickName == "")
                            {
                                NickName = "未知";
                            }
                        }

                        str += "<div><span style=\"font-size:10px;\">" + NickName + "<span/>&nbsp;&nbsp;&nbsp;&nbsp;" + Convert.ToDateTime(cl[i].CreateTime).ToString("yyyy/MM/dd  hh:mm:ss") + "<br/><br/>";
                        str += "<span style=\"font-size:16px;\">" + cl[i].MsgContent + "<span/><br/><br/><div/>";

                    }
                }

                break;

            case "GetUser":             //获取粉丝列表
                str += "<div style=\"text-align:center;padding-top:10px;\"><b>粉丝列表<b/><div/><br/>";
                for (int i = 0; i < cllist.Length; i++)
                {
                    if (cllist[i].SendUserName != null)
                    {
                        string NickName = "";
                        string openid = cllist[i].SendUserName;
                        if (cllist[i].SendUserName == wxid)
                        {
                            NickName = "系统";
                        }
                        else
                        {
                            NickName = wxuser.getwxuserinfo(cllist[i].SendUserName).nickname.ToString();
                            if (NickName == "")
                            {
                                NickName = "未知";
                            }
                        }

                        str += "<table border=\"0\">";
                        str += "<tr id=\"divtest" + openid + "\" onclick=\"GetChat('" + openid + "')\" >";
                        str += " <td style=\"cursor:pointer;padding-left:5px;\"   ><img style=\"width: 48px;height: 48px;\" src=\"" + wxuser.getwxuserinfo(cllist[i].SendUserName).headimgurl + "\"></td>";
                        str += " <td style=\"cursor:pointer;padding-left:5px;padding-bottom:25px;width:100%;\" colspan=\"10\" style=\"width:120px;text-align:left;padding-left:5px;\">" + NickName + "</td>";
                        int NotReadCount = chatlog.GetNotReadCount(wxid, openid);
                        if (NotReadCount != 0)
                        {
                            str += " <td style=\"float:right;\"><img style=\"width: 18px;height: 18px;float:right;\" src=\"images/news.png\"></td>";
                        }
                        str += "</tr>";
                        str += "</table>";

                    }
                }

                break;

            case "SendMsg":           //发送消息

                //string accessToken = WeiXinAccessToken.GetAccessToken();
                chatloginfo.FromUserName = wxid;
                chatloginfo.ToUserName = Openid;
                chatloginfo.SendUserName = wxid;
                chatloginfo.MsgContent = System.Web.HttpUtility.UrlDecode(Msg);
                chatloginfo.Worker = "0";
                //Send(accessToken, Msg, Openid);
                chatlog.Add(chatloginfo);
                //Utils.WriteLogEx("消息"+Msg+"|"+Openid); 

                break;

            case "UpdateMsgStatus":  //修改已读消息
                chatlog.UpdateMsgStatus(wxid, Openid);
                break;
            default:
                break;
        }

        context.Response.Write(str);

    }



    //private string Send(string accessToken, string msgContent, string openid)
    //{
    //    string jsonResult = HttpWebRequestUtils.Request(@"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + accessToken, "POST", SendJson(msgContent, openid), Encoding.UTF8);
    //    if (jsonResult == "")
    //    {
    //        jsonResult = "";
    //    }
    //    Utils.WriteLogEx(jsonResult);
    //    return jsonResult;
    //}

    private string SendJson(string msgContent, string openid)
    {
        //string openid = "ogdzEtxRh3Q-KkM5p7JopXyqzLUM";
        string content = msgContent;
        string msgtype = "text";
        string result = "{";
        result += "\"touser\" :\"" + openid + "\",";
        result += "\"msgtype\" :\"" + msgtype + "\",";
        result += "\"text\" :";
        result += "{";

        result += "\"content\":\"" + content + "\"";

        result += "}";
        result += "}";
        return result;
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}