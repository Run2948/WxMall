using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;
using System.Data;


public partial class api_wxpay_ResultNotifyPage : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        ResultNotify resultNotify = new ResultNotify(this);
        resultNotify.ProcessNotify();
    }

}