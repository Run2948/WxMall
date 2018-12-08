using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Cms.DBUtility;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using Cms.Common;

public partial class Admin_order_orderlist : System.Web.UI.Page
{
    public string classid = "";
    Cms.BLL.C_order bllorder = new Cms.BLL.C_order();
    public DataSet ds;
    public SqlDataAdapter dr;
    private ExportExcel excel = new ExportExcel();
    private int excelRows = 0;
    private int excelColumns;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //登录验证
            Cms.Model.C_admin admin = adminUser.GetLoginState();
            Application["adminname"] = admin.user_name;

            string where = "select * from C_order  order by id desc";
            this.AspNetPager1.AlwaysShow = true;
            this.AspNetPager1.PageSize = 10;
            this.AspNetPager1.RecordCount = bllorder.GetRecordCount("");
            this.RepeaterDataBind(where);

            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//订单ID
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            switch (action)
            {
                case "Updateorder":
                    this.Updateorder(id);// 赋值操作信息
                    break;
                case "UpdateRefund":
                    this.UpdateRefund(id);
                    break;

            }

        }
    }
    #region 提示框================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 数据读取================================
    public void RepeaterDataBind(string whereStr)
    {
        dr = new SqlDataAdapter(whereStr, DbHelperSQL.connectionString);
        ds = new DataSet();
        dr.Fill(ds, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "C_order");
        this.rptList.DataSource = ds.Tables["C_order"];
        this.rptList.DataBind();


    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int classid = Convert.ToInt32(this.Request.QueryString["parentId"] ?? "0");//栏目ID
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string where = "select * from C_order order by id desc";
        this.RepeaterDataBind(where.ToString());

    }
    #endregion

    #region 删除=================================
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptList.Items)
        {
            //获取选择框
            CheckBox check = item.FindControl("Check_Select") as CheckBox;
            if (check.Checked)
            {
                HiddenField field = item.FindControl("Fielddocid") as HiddenField;
                int id = int.Parse(field.Value);
                //删除文档的同时删除静态文档
               
                Cms.DBUtility.DbHelperSQL.ExecuteSql("delete from C_ordersub where order_id=" + id);
                adminUser.AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), bllorder.GetModel(id).order_num); //记录日志
                bllorder.Delete(id);
            }
        }
        JscriptMsg("删除信息成功！", "orderlist.aspx", "Success");
    }
    #endregion

    #region 搜索=============================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strparentId = this.Request.QueryString["parentId"] ?? "";//上级栏目ID
        classid = strparentId;//
        string Keywords = this.txtKeywords.Text.Trim();
        string whereStr = "select * from C_order where ordernum='" + Keywords + "' order by orderid desc";
        this.RepeaterDataBind(whereStr);
    }
    #endregion

    #region 导出Excel===============================
    private void ExcelTitle()
    {
        excel.RowStart();
        excel.CellWithoutFormula("String", "订单号");
        excel.CellWithoutFormula("String", "会员名");
        excel.CellWithoutFormula("String", "总数量");
        excel.CellWithoutFormula("String", "总金额");
        excel.CellWithoutFormula("String", "总积分");
        excel.CellWithoutFormula("String", "支付状态");
        excel.CellWithoutFormula("String", "备注");
        excel.CellWithoutFormula("String", "下单时间");
        excel.RowEnd();
        excelRows++;
        excelColumns = 8;
    }
    private void InitExcelData()
    {
        try
        {
            DataSet ds;
            DataTable dt = new DataTable();

            string startime = Request.Form["startime"];// this.startime.Text;
            string endtime = Request.Form["endtime"]; //this.endtime.Text;
            string str ="";
            if (startime != ""|| endtime != "")
            {
                str = "updateTime between '" + startime + "' and '" + endtime + "'  order by id desc";
            }
           else
            {
                str ="";
            }

            ds = bllorder.GetList(str);
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    excel.RowStart();
                    excel.CellWithoutFormula("String", dt.Rows[i]["order_num"].ToString());
                    excel.CellWithoutFormula("String", getUserName(Convert.ToInt32(dt.Rows[i]["user_id"].ToString())));
                    excel.CellWithoutFormula("String", dt.Rows[i]["quantity_sum"].ToString());
                    excel.CellWithoutFormula("String", Convert.ToDecimal(dt.Rows[i]["price_sum"]).ToString("0.00"));
                    excel.CellWithoutFormula("String", dt.Rows[i]["integral_sum"].ToString());
                    excel.CellWithoutFormula("String", dt.Rows[i]["is_payment"].ToString() == "0" ? "未支付" : "已支付");
                    excel.CellWithoutFormula("String", dt.Rows[i]["note"].ToString());
                    excel.CellWithoutFormula("String", dt.Rows[i]["updateTime"].ToString());
                    excel.RowEnd();
                    excelRows++;
                }
                excel.CreateExcelWithMode(excelRows, excelColumns, DateTime.Now.ToShortDateString() + "-DBE购物订单报表");
            }
            else
            {
                JscriptMsg("没有符合的数据信息！", "orderlist.aspx", "Error");
            }

        }
        catch
        { 
        }
    }
    protected void ToExcel_Click(object sender, EventArgs e)
    {
        //Excel.ReportToExcel(rptList);
        ExcelTitle();
        InitExcelData();
    }
    #endregion

    #region 更新订单状态======================
    public void Updateorder(int orderid)
    {
        string UpdateSql = "update C_order set is_transaction=1 where id=" + orderid;
        DataSet ds = bllorder.GetList("id=" + orderid);
        if (ds.Tables[0].Rows[0]["is_payment"].ToString() == "1")
        {
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql(UpdateSql);//修改订单支付状态

            if (counts > 0)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), bllorder.GetModel(orderid).order_num); //记录日志
                JscriptMsg("完单成功！", "orderlist.aspx", "Success");
            }
            else
            {
                JscriptMsg("完单失败！", "orderlist.aspx", "Error");
            }
        }
        else
        {
            JscriptMsg("该订单未支付！", "orderlist.aspx", "Error");
        }

    }
    public void UpdateRefund(int orderid)
    {
        string UpdateSql = "update C_order set is_refund=2 where id=" + orderid;
        DataSet ds = bllorder.GetList("id=" + orderid);
        if (ds.Tables[0].Rows[0]["is_payment"].ToString() == "1")
        {
            int counts = Cms.DBUtility.DbHelperSQL.ExecuteSql(UpdateSql);//修改订单支付状态

            if (counts > 0)
            {
                adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), bllorder.GetModel(orderid).order_num); //记录日志
                JscriptMsg("审批退款成功！", "orderlist.aspx", "Success");
            }
            else
            {
                JscriptMsg("审批退款失败！", "orderlist.aspx", "Error");
            }
        }
        else
        {
            JscriptMsg("该订单未支付！", "orderlist.aspx", "Error");
        }

    }
    #endregion

    #region 获取用户名=======
    public string getUserName(int user_id)
    {
        string result = "匿名预定人";
        if( new Cms.BLL.C_user().Exists(user_id))
        {
            result = new Cms.BLL.C_user().GetModel(Convert.ToInt32(user_id)).username.ToString();
        }
        
        return result;
    }

    public string getIsRefund(string IsRefund)
    {
        string result = "";
        if (IsRefund == "0")
        {
            result = "未申请退款";
        }
        else if (IsRefund == "1")
        {
            result = "申请退款中";
        }
        else if (IsRefund == "2")
        {
            result = "已审核退款";
        }
        else if (IsRefund == "3")
        {
            result = "退款成功";
        }

        return result;
    }
    #endregion
}