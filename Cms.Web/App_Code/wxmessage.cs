using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///wxmessage 的摘要说明
/// </summary>
public class wxmessage
{
    public wxmessage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private string _ToUserName;
    private string _FromUserName;
    private string _MsgType;
    private string _Content;
    private string _Location_X;
    private string _Location_Y;
    private string _Scale;
    private string _EventName;
    private string _EventKey;
    private string _Recognition;
    private string _MsgId;
    private string _Label;
    public string ToUserName
    {
        set { _ToUserName = value; }
        get { return _ToUserName; }
    }
    public string FromUserName
    {
        set { _FromUserName = value; }
        get { return _FromUserName; }
    }
    public string MsgType
    {
        set { _MsgType = value; }
        get { return _MsgType; }
    }
    public string Content
    {
        set { _Content = value; }
        get { return _Content; }
    }
    public string Location_X
    {
        set { _Location_X = value; }
        get { return _Location_X; }
    }
    public string Location_Y
    {
        set { _Location_Y = value; }
        get { return _Location_Y; }
    }
    public string Scale
    {
        set { _Scale = value; }
        get { return _Scale; }
    }
    public string EventName
    {
        set { _EventName = value; }
        get { return _EventName; }
    }
    public string EventKey
    {
        set { _EventKey = value; }
        get { return _EventKey; }
    }
    public string Recognition
    {
        set { _Recognition = value; }
        get { return _Recognition; }
    }
    public string MsgId
    {
        set { _MsgId = value; }
        get { return _MsgId; }
    }
    public string Label
    {
        set { _Label = value; }
        get { return _Label; }
    }
}