using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;

public partial class api_wxpay_success : System.Web.UI.Page
{
    protected Cms.Model.C_order ordertmp = new Cms.Model.C_order();
    protected string openid = "";
    protected int otid = 0;
    protected string fahuoInfo = "";
    protected string token = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            otid = MyCommFun.RequestInt("otid");
            if (otid == 0)
            {
                return;
            }
            Cms.BLL.C_order otBll = new Cms.BLL.C_order();
            ordertmp = otBll.GetModel(otid);

        }
    }
}