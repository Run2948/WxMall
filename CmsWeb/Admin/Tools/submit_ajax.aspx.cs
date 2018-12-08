using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Tools_submit_ajax : System.Web.UI.Page
{
    public string _Pro_Id;
    DataTable CartTable = new DataTable();  //声明一个DataTable对象
    DataRow dr;
    public Double dTotal = 0.00;            //总计款额
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           
            if (Session["CartShop"] == null)                                       //判断是否为第一次添加购物车否则创建DataTable
            {
                CartTable.Columns.Add(new DataColumn("Pro_Id", typeof(string)));//产品id
                CartTable.Columns.Add(new DataColumn("Pro_Name", typeof(string)));//产品名称
                CartTable.Columns.Add(new DataColumn("Pro_Quantity", typeof(int)));//产品数量
                CartTable.Columns.Add(new DataColumn("Pro_Price", typeof(decimal)));//产品单价
                CartTable.Columns.Add(new DataColumn("Pro_SubTotal", typeof(decimal)));//产品合计
                CartTable.Columns.Add(new DataColumn("Pro_note", typeof(string)));//产品备注
                Session["CartShop"] = CartTable;
                Session.Timeout = 1440;
            }
            else
            {
                CartTable = (DataTable)Session["CartShop"];
            }
        }
        string action = Request["action"];
        switch (action)
        {
            case "cart_goods_add": cart_goods_add(); break;//购物车加入商品
            case "cart_goods_update": cart_goods_update(); break;//购物车修改商品
            case "cart_goods_delete": cart_goods_delete(); break;//购物车删除商品
            case "order_save": order_save(); break;//保存订单
            case "order_cancel": order_cancel(); break;//用户取消订单
            case "view_cart_count": view_cart_count(); break;//输出当前购物车总数

        }
    }
    #region 购物车加入商品OK===============================
    private void cart_goods_add()
    {
        int iPro_Quantity = 1;
        bool IsSame = false;                                 //表示是否为同一种商品
        Cms.BLL.C_article bPro = new Cms.BLL.C_article();   //这是购物车的逻辑层
        string sPro_Id = Request.QueryString["articleId"].ToString();
        string sPro_note = "颜色:" + Request.QueryString["note"].ToString();
        foreach (DataRow dr in CartTable.Rows)                   //遍历DataTable
        {
            if (dr[0].ToString() == sPro_Id)
            {
                iPro_Quantity = Convert.ToInt32(dr[2].ToString());
                iPro_Quantity++;
                dr[2] = iPro_Quantity;
                dr[4] = iPro_Quantity * Convert.ToDecimal(dr[3].ToString());
                dr[5] = dr[5].ToString();
                IsSame = true;
            }
        }
        if (!IsSame)                                              //DataTable里没有，则创建一行该商品
        {
            dr = CartTable.NewRow();
            dr[0] = sPro_Id;
            dr[1] = bPro.GetModel(Convert.ToInt32(sPro_Id)).title;
            dr[2] = iPro_Quantity;
            dr[3] = Convert.ToDecimal("1");
            dr[4] = iPro_Quantity * Convert.ToDecimal(dr[3].ToString());
            dr[5] = sPro_note;
            CartTable.Rows.Add(dr);
        }
        Session["CartShop"] = CartTable;                          //添加到Session中
        Session.Timeout=1440;
        //DataSet ds = new DataSet();
        //ds.Tables.Add(CartTable);
        string result = Cms.DBUtility.ToJosn.ToJson(CartTable);
        Response.Write(result);
        Response.End();

        
    }
    #endregion

    #region 修改购物车商品OK===============================
    private void cart_goods_update()
    {
       
    }
    #endregion

    #region 删除购物车商品OK===============================
    private void cart_goods_delete()
    {
     
    }
    #endregion

    #region 保存用户订单OK=================================
    private void order_save()
    {
       
    }
    #endregion

    #region 用户取消订单OK=================================
    private void order_cancel()
    {
        
    }
    #endregion

    #region 输出购物车总数OK===============================
    private void view_cart_count()
    {
       
    }
    #endregion


}