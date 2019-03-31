using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Admin_dialog_dialog_Column : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Admin_dialog_dialog_Column));//注册Ajax可调用的类的名称
        if (!IsPostBack)
        {
            adminUser.GetLoginState();//登录验证========================================================

            DropList_Bind();//读取栏目======================================
        }
    }

    #region 读取栏目=========================================================
    public void getcolumn()
    {
       Cms.BLL.C_Column bll = new Cms.BLL.C_Column();
        DataTable dt = bll.GetList(26, Cms.Common.Enums.NavigationEnum.WebSite.ToString());
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem myitem = new ListItem();
                myitem.Value = dt.Rows[i]["classId"].ToString();
                myitem.Text = dt.Rows[i]["className"].ToString();
                cblItem.Items.Add(myitem);
            }
        }
    }
    #region 绑定栏目===================================
    public void DropList_Bind()
    {
        cblItem.Items.Clear();
        //parentId.Items.Add(new ListItem("作为一级分类", "0"));
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet ds = bllcolumn.GetList("parentId=26");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ListItem item = new ListItem();
                item.Text = "" + dr["className"].ToString();
                item.Value = dr["classId"].ToString();
                cblItem.Items.Add(item);
                ChileNodeBind(dr, cblItem, 2);
            }
        }
    }
    private void ChileNodeBind(DataRow drr, RadioButtonList parentId, int m)
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet dss = bllcolumn.GetList("parentId=" + drr["classId"] + "");
        if (dss.Tables[0].Rows.Count > 0)
        {
            string s = System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
            for (int j = 1; j <= m; j++)
            {
                s += System.Web.HttpContext.Current.Server.HtmlDecode("&nbsp;");
            }
            for (int k = 0; k < dss.Tables[0].Rows.Count; k++)
            {
                DataRow dro = dss.Tables[0].Rows[k];
                string flag = "├";
                if (dss.Tables[0].Rows.Count == 1)
                {
                    flag = "├";
                }
                else
                {
                    if (k == 0)
                    {
                        flag = "├";
                    }
                    if (k == dss.Tables[0].Rows.Count - 1)
                    {
                        flag = "├";
                    }
                }
                ListItem item = new ListItem();
                item.Text = s + flag + dro["className"].ToString();
                item.Value = dro["classId"].ToString();
                parentId.Items.Add(item);
                ChileNodeBind(dro, parentId, m + 5);
            }
        }
    }
    #endregion
    #endregion


    #region 提交配置的关联栏目===============================================
    [AjaxPro.AjaxMethod]
    public string submitcolumn(string id)
    {
        string result = "";
        StringBuilder strbuder = new StringBuilder();
        //RadioButtonList cblItem = new RadioButtonList();
        result = this.cblItem.SelectedValue;
        return result.ToString();
        //Response.Write("<script>parent.ImgTemp['" + nameid + "']='" + OperatorID + "'</script>");
    }
    #endregion

    #region 确认===============================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string txtcolumn = this.cblItem.SelectedValue;
        //Response.Write("<script>alert(" + txtcolumn + ");parent.Dialog.close();</script>");
        Response.Write("<script>parent.parent.ColumnTemp['columnchose']='" + txtcolumn + "';parent.traverseTemp() </script>");
        Page.ClientScript.RegisterStartupScript(this.GetType(), " ", "<script>parent.Dialog.close();</script>");
    }
    #endregion

    #region 取消=========================================
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Write("<script>parent.Dialog.close();</script>");
    }
    #endregion

}