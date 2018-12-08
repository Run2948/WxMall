using Cms.API.Payment.wxpay;
using Cms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_payment_wxpay_payResult : System.Web.UI.Page
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

            openid = MyCommFun.RequestOpenid();
            otid = MyCommFun.RequestInt("otid");
            int wid = MyCommFun.RequestWid();
            if (openid == "" || otid == 0 || wid == 0)
            {
                return;
            }

            //WeiXinCRMComm wxComm = new WeiXinCRMComm();
            //string err = "";
            //token = wxComm.getAccessToken(wid, out err);

            Cms.BLL.C_order otBll = new Cms.BLL.C_order();
            ordertmp = otBll.GetModel(otid);

        }
    }


}