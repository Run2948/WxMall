using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Admin_wx_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //XmlDocument xmls = new XmlDocument();

        //xmls.Load(Server.MapPath("store.xml"));
        //XmlElement roots = xmls.DocumentElement;

        //int i = 0;
        //foreach (XmlElement x in roots)
        //{

        //    double d_Location_X = double.Parse(wx.Location_X);
        //    double d_Location_Y = double.Parse(wx.Location_Y);
        //    double d2_Location_X = double.Parse(x.Attributes["latitude"].InnerText);
        //    double d2_Location_Y = double.Parse(x.Attributes["longitude"].InnerText);

        //    i++;
        //    sb.Append("<item>");
        //    sb.Append("<Title><![CDATA[" +x.Attributes["storename"].InnerText + "]]></Title> ");
        //    sb.Append("<Description><![CDATA[距离该门店大约" + i + "米]]></Description>");
        //    sb.Append("<PicUrl><![CDATA[" + x.Attributes["picurl"].InnerText + "]]></PicUrl>");
        //    sb.Append("<Url><![CDATA[" + x.Attributes["linkurl"].InnerText + "]]></Url>");
        //    sb.Append("</item>");
        //}
    }
}