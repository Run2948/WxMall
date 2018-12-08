using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///Exception 的摘要说明
/// </summary>
public class WxPayException : Exception
{
    public WxPayException(string msg)
        : base(msg)
    {

    }
}