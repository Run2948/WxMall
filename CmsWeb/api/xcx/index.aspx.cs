using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Cms.Common;
using System.Web.Script.Serialization;
using System.Net;

public partial class api_xcx_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string opt = Request["opt"];
        switch (opt)
        {
            
            case "onLogin": onLogin(); break;//登录
            case "addUser": addUser(); break;//创建会员
            case "updateUser": updateUser(); break;//修改会员信息
            case "getListUser":getListUser(); break;//分页查询会员
            case "getListUserCount": getListUserCount(); break;//统计会员
            case "getUser": getUser(); break;//读取会员信息
            case "getListUserIntegral": getListUserIntegral(); break;//会员积分排序
            case "getWebSite": getWebSite(); break;//站点信息
            case "getColumnList": getColumnList(); break;//栏目列表
            case "getArticlePage": getArticlePage(); break;//分页查询内容
            case "getArticleInfo": getArticleInfo(); break;//内容详情
            case "getBanner": getBanner(); break;//获取banner
            case "getProductPageList": getProductPageList(); break;//获取产品列表
            case "getProductInfo": getProductInfo(); break;//获取产品列表
            case "getType": getType(); break;//读取分类
            case "getHotType": getHotType(); break;//读取热门分类
            case "getTypeModel": getTypeModel(); break;//读取分类详细信息
            case "setCartIsChecked": setCartIsChecked(); break;//设置购物车默认不选择
            case "addCart": addCart(); break;//插入购物车
            case "getCartList": getCartList(); break;//读取购物车
            case "dTotal": dTotal(); break;//购物车计算金额
            case "updateCart": updateCart(); break;//购物车加减
            case "deleteCart": deleteCart(); break;//购物车删除
            case "choice": choice(); break;//购物车选择
            case "selection": selection(); break;//购物车全选
            case "getCountChecked": getCountChecked(); break;//购物车是否选中获取全选
            case "addOrder": addOrder(); break;//提交订单
            case "canalOrder": canalOrder(); break;//取消订单
            case "getAddressList": getAddressList(); break;//获取地址
            case "addAddress": addAddress(); break;//更新地址
            case "getAddress": getAddress(); break;//查询地址详细
            case "deleteAddress": deleteAddress(); break;//删除地址
            case "defaultAddress": defaultAddress(); break;//设置默认地址
            case "getOrderList": getOrderList(); break;//查询订单列表
            case "getOrder": getOrder(); break;//查看订单详细
            case "getOrderSubList": getOrderSubList(); break;//查看订单购物明细
            case "getOrderSate": getOrderSate(); break;//查看订单状态
            case "getOrderRed": getOrderRed(); break;//计算订单红点状态
            case "GetUnifiedOrderResult": GetUnifiedOrderResult(); break;//微信支付统一下单
            case "getUserRechargeList": getUserRechargeList(); break; //获取充值记录
            case "getUserIntegralList": getUserIntegralList(); break; //获取积分记录
            case "addUserRecharge": addUserRecharge(); break;//充值
            case "getIntegralProductPageList": getIntegralProductPageList(); break;//获取积分产品列表
            case "getIntegralProductInfo": getIntegralProductInfo(); break;//获取积分产品
        }
    }
   

    #region 通过code获取用户的openid=======================
    public void onLogin()
    {
        string code = Request["code"];
        string Str = GetJson("https://api.weixin.qq.com/sns/jscode2session?appid=wxf82d5ec0210f7c73&secret=4eb475d2059f9744c706fe49ebec805b&js_code=" + code + "&grant_type=authorization_code");
        if (Str != null)
        {
            Response.Write(Str);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    /// <summary>
    /// 接受信息
    /// </summary>
    /// <param name="url">目标连接地址</param>
    /// <returns></returns>
    public static string GetJson(string url)
    {
        WebClient wc = new WebClient();
        wc.Credentials = CredentialCache.DefaultCredentials;
        wc.Encoding = Encoding.UTF8;
        string returnText = wc.DownloadString(url);
        if (returnText.Contains("errcode"))
        {
            //可能发生错误  
        }
        return returnText;
    }
    #endregion

    #region 创建会员=======================
    public void getUser()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        Cms.Model.C_user modelUpdate = new Cms.BLL.C_user().GetModel(userId);
        string strJson = this.LocalSerialize(modelUpdate);
        Response.Write(strJson);
        Response.End();


    }
    public void getListUser()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int page = Convert.ToInt32(Request["page"] ?? "0");
        int size = Convert.ToInt32(Request["size"] ?? "3");
        int start = (page - 1) * size + 1;
        int end = page * size;
        DataSet ds = new Cms.BLL.C_user().GetListByPage("", "id desc", start, end);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_user> list = new Cms.BLL.C_user().DataTableToList(ds.Tables[0]);
            string strJson = this.LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    public void getListUserCount()
    {
        int result = new Cms.BLL.C_user().GetRecordCount("");
        string strJson = "{\"userCount\":" + result + "}";
        Response.Write(strJson);
        Response.End();
    }
    public void getListUserIntegral()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int page = Convert.ToInt32(Request["page"] ?? "0");
        int size = Convert.ToInt32(Request["size"] ?? "3");
        int start = (page - 1) * size + 1;
        int end = page * size;
        DataSet ds = new Cms.BLL.C_user().GetListByPage("", "userscore desc", start, end);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_user> list = new Cms.BLL.C_user().DataTableToList(ds.Tables[0]);
            string strJson = this.LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }


    }
    public void updateUser()
    {
        string mobile = Request["mobile"]??"";
        string address = Request["address"] ?? "";
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        Cms.Model.C_user modelUpdate = new Cms.BLL.C_user().GetModel(userId);
        modelUpdate.telphone = mobile;
        modelUpdate.useraddress = address;
        new Cms.BLL.C_user().Update(modelUpdate);
        string strJson = "{\"state\":1}";
        Response.Write(strJson);
        Response.End();
        

    }
    public void addUser()
    {

        string openid = Request["openid"];
        string nickName = Request["nickName"];
        string avatarUrl = Request["avatarUrl"];
        int gender = Convert.ToInt32(Request["gender"] ?? "0");
        Cms.Model.C_user model = new Cms.Model.C_user();
        model.username = nickName;
        model.openid = openid;
        model.headimgurl = avatarUrl;
        model.sex = gender == 1 ? "男" : "女";
        model.userscore = 0;
        model.userMoney = 0;
        model.updatetime = DateTime.Now;
        model.password = "123456";
        DataSet ds = new Cms.BLL.C_user().GetList("openid='" + openid + "'");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Cms.Model.C_user modelUpdate = new Cms.BLL.C_user().GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()));
            modelUpdate.username = model.username;
            modelUpdate.headimgurl = model.headimgurl;
            new Cms.BLL.C_user().Update(modelUpdate);
            string strJson = "{\"userId\":" + ds.Tables[0].Rows[0]["id"].ToString() + "}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            int result = new Cms.BLL.C_user().Add(model);
            if (result > 0)
            {
                string strJson = "{\"userId\":" + result + "}";
                Response.Write(strJson);
                Response.End();
            }
        }

    }
    #endregion

    #region 站点信息=======================
    public void getWebSite()
    {
        Cms.Model.C_WebSiteconfig model = new Cms.BLL.C_WebSiteconfig().GetModel(1);
        if (model != null)
        {
            string strJson = LocalSerialize(model);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 分页查询内容列表=======================
    public void getColumnList()
    {
        int classId = Convert.ToInt32(Request["classId"] ?? "0");
        int top = Convert.ToInt32(Request["top"] ?? "0");
        DataSet ds = new Cms.BLL.C_Column().GetList(top, "parentId=" + classId + " and isShowChannel=1 ", "orderNumber desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_Column> list = new Cms.BLL.C_Column().DataTableToList(ds.Tables[0]);
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    public void getArticlePage()
    {
        int classId = Convert.ToInt32(Request["classId"] ?? "0");
        int page = Convert.ToInt32(Request["page"] ?? "0");
        int size = Convert.ToInt32(Request["size"] ?? "3");
        int start = (page - 1) * size + 1;
        int end = page * size;
        DataSet ds = new Cms.BLL.C_article().GetListByPage("parentId=" + classId + "", "ordernumber asc,articleId desc", start, end);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_article> list = new Cms.BLL.C_article().DataTableToList(ds.Tables[0]);
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    public void getArticleInfo()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        Cms.Model.C_article model = new Cms.BLL.C_article().GetModel(id);
        if (model != null)
        {
            string strJson = LocalSerialize(model);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  获取banner===========================
    public void getBanner()
    {
        int adtype = Convert.ToInt32(Request["typeId"] ?? "0");
        DataSet ds = new Cms.BLL.C_ad().GetList(6, "adtype=" + adtype, "ordernum asc,id desc");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_ad> list = new Cms.BLL.C_ad().DataTableToList(ds.Tables[0]);
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 获取产品列表=======================
    public void getProductPageList()
    {
       
        string where = Request["where"] ?? "";
        string orderBy = Request["orderBy"] ?? "";
        int page = Convert.ToInt32(Request["page"] ?? "0");
        int size = Convert.ToInt32(Request["size"] ?? "3");
        int start = (page - 1) * size + 1;
        int end = page * size;
        DataSet ds = new Cms.BLL.C_product().GetListByPage(where, orderBy + "sortId asc,id desc", start, end);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_product> list = new Cms.BLL.C_product().DataTableToList(ds.Tables[0]);
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    public void getProductInfo()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        Cms.Model.C_product model = new Cms.BLL.C_product().GetModel(id);
        if (model != null)
        {
            string strJson = LocalSerialize(model);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 读取分类================
    public void getType()
    {
        string parentId = Request["parentId"];
        List<Cms.Model.C_type> list = new Cms.BLL.C_type().GetModelList("parent_id=" + parentId + " order by sort_id asc");
        if (list != null && list.Count > 0)
        {
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 读取热门分类================
    public void getHotType()
    {
        string parentId = Request["parentId"];
        List<Cms.Model.C_type> list = new Cms.BLL.C_type().GetModelList("parent_id=" + parentId + " and isHot=1 order by id desc,sort_id asc");
        if (list != null && list.Count > 0)
        {
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 读取分类详细信息=======================
    public void getTypeModel()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        Cms.Model.C_type model = new Cms.BLL.C_type().GetModel(id);
        if (model != null)
        {
            string strJson = LocalSerialize(model);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 购物车=======================
    public void setCartIsChecked() {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int result = Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_cart set is_checked=1  where user_id=" + userId);//设置购物车的默认选中状态1
        if (result > 0)
        {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = "{\"status\":1}";
            Response.Write(strJson);
            Response.End();
        }
    }
    public void addCart()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int quantity = Convert.ToInt32(Request["quantity"] ?? "0");
        string unit = Request["unit"] ?? "";
        int isChecked = Convert.ToInt32(Request["isChecked"] ?? "1");
        int typeId = Convert.ToInt32(Request["typeId"] ?? "1");
        Cms.Model.C_user_cart model = new Cms.Model.C_user_cart();
        model.article_id = id;
        if (isChecked == 2) {
           Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_cart set is_checked=1  where user_id=" + userId + " and typeId=" + typeId);//设置购物车的默认选中状态1
        }
        if (typeId == 1)
        {
            Cms.Model.C_product product = new Cms.BLL.C_product().GetModel(id);
            model.title = product.name.ToString();
            model.price = product.price;
            model.integral = product.integral;
        }
        else {
            Cms.Model.C_integral_product product = new Cms.BLL.C_integral_product().GetModel(id);
            model.title = product.name.ToString();
            model.price = product.price;
            model.integral = product.integral;
        }

        model.quantity = quantity;
        model.user_id = userId;
        model.is_checked = isChecked;
        model.property_value = unit;
        model.note = "";
        model.typeId = typeId;
        model.updateTime = DateTime.Now;
        int result = 0;
        if (new Cms.BLL.C_user_cart().Exists(id, userId,typeId))
        {
            result = Cms.DBUtility.DbHelperSQL.ExecuteSql("update C_user_cart set is_checked=" + isChecked + ",quantity=quantity+" + quantity + ",updateTime='" + DateTime.Now + "' where article_id=" + id + " and user_id=" + userId + " and typeId=" + typeId);

        }
        else
        {
            result = new Cms.BLL.C_user_cart().Add(model);
        }
        if (result > 0)
        {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = "{\"status\":1}";
            Response.Write(strJson);
            Response.End();
        }
    }

    public void getCartList()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int typeId = Convert.ToInt32(Request["typeId"] ?? "1");
        string where = Request["where"] ?? "";
        List<Cms.Model.C_user_cart> list = new Cms.BLL.C_user_cart().GetModelList("user_id=" + userId + " and typeId=" + typeId + where);
        if (list != null && list.Count > 0)
        {
            List<Dictionary<string, object>> listNew = new List<Dictionary<string, object>>();
            foreach (Cms.Model.C_user_cart record in list)
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("id", record.id);
                map.Add("user_id", record.user_id);
                if (typeId == 1)
                {
                    if (new Cms.BLL.C_product().Exists(Convert.ToInt32(record.article_id)))
                    {
                        map.Add("litpic", new Cms.BLL.C_product().GetModel(Convert.ToInt32(record.article_id)).litpic.ToString());
                        map.Add("marketPrice", new Cms.BLL.C_product().GetModel(Convert.ToInt32(record.article_id)).marketPrice);
                    }
                }
                else {
                    if (new Cms.BLL.C_integral_product().Exists(Convert.ToInt32(record.article_id)))
                    {
                        map.Add("litpic", new Cms.BLL.C_integral_product().GetModel(Convert.ToInt32(record.article_id)).litpic.ToString());
                        map.Add("marketPrice", new Cms.BLL.C_integral_product().GetModel(Convert.ToInt32(record.article_id)).marketPrice);
                    }
                }
                map.Add("title", record.title);
                map.Add("price", record.price);
                map.Add("quantity", record.quantity);
                map.Add("integral", record.integral);
                map.Add("property_value", record.property_value);
                map.Add("note", record.note);
                map.Add("is_checked", record.is_checked);
                map.Add("checked", record.is_checked==2? "true":"false");
                listNew.Add(map);
            }
            string strJson = this.LocalSerialize(listNew);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }

    #region 选择============================
    public void choice()
    {
        string id = Request.QueryString["id"];
        string checkId = Request.QueryString["checkId"];
        if (checkId == "1")
        {
            int count = Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_cart set is_checked=2  where id=" + id);
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            int count = Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_cart set is_checked=1  where id=" + id);
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }

    }
    #endregion

    #region 全选============================
    public void selection()
    {

        string checkId = Request.QueryString["checkId"];
        string userId = Request.QueryString["userId"];
        int typeId = Convert.ToInt32(Request["typeId"] ?? "1");
        if (checkId == "1")
        {
            int count = Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_cart set is_checked=2  where user_id=" + Convert.ToInt32(userId) + " and typeId=" + typeId);
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            int count = Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_cart set is_checked=1  where user_id=" + Convert.ToInt32(userId) + " and typeId=" + typeId);//设置购物车的默认选中状态1
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }

    }
    public void getCountChecked()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int typeId = Convert.ToInt32(Request["typeId"] ?? "1");
        List<Cms.Model.C_user_cart> listCount = new Cms.BLL.C_user_cart().GetModelList("user_id=" + userId + " and typeId=" + typeId);
        List<Cms.Model.C_user_cart> list = new Cms.BLL.C_user_cart().GetModelList("user_id=" + userId + " and is_checked=2" + " and typeId=" + typeId);
        if (list != null && list.Count > 0)
        {
            if (listCount.Count == list.Count) {
                string strJson = "{\"status\":2}";
                Response.Write(strJson);
                Response.End();
            } else { 
            string strJson = "{\"status\":1}";
            Response.Write(strJson);
            Response.End();
            }
        }
        else
        {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
    }
    #endregion

    #region 计算选中的金额============================
    public void dTotal()
    {
        Double dTotal = 0.00;//总计款额
        Double marketPriceTotal = 0.00;//总计款额
        int integralTotal = 0;
        int quantity = 0;
        string userId = Request.QueryString["userId"];
        int typeId = Convert.ToInt32(Request["typeId"] ?? "1");
        System.Data.DataSet ds = new Cms.BLL.C_user_cart().GetList("user_id=" + userId+" and typeId="+typeId);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["is_checked"].ToString() == "2")
                {
                    integralTotal += Convert.ToInt32(ds.Tables[0].Rows[i]["integral"]) * Convert.ToInt32(ds.Tables[0].Rows[i]["quantity"]);
                    dTotal += Convert.ToDouble(ds.Tables[0].Rows[i]["price"]) * Convert.ToInt32(ds.Tables[0].Rows[i]["quantity"]);
                    marketPriceTotal += Convert.ToDouble(new Cms.BLL.C_product().GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["article_id"])).marketPrice* Convert.ToInt32(ds.Tables[0].Rows[i]["quantity"]));
                    quantity += Convert.ToInt32(ds.Tables[0].Rows[i]["quantity"]);
                }
            }
            marketPriceTotal = marketPriceTotal - dTotal;
            Response.Write("{\"dTotal\":" + dTotal + ",\"marketPriceTotal\":" + marketPriceTotal + ",\"quantity\":" + quantity + ",\"integralTotal\":" + integralTotal + "}");
            Response.End();
        }
        else
        {
            Response.Write("{\"dTotal\":" + dTotal + ",\"marketPriceTotal\":" + marketPriceTotal + ",\"quantity\":" + quantity + ",\"integralTotal\":" + integralTotal + "}");
            Response.End();
        }

    }
    #endregion

    #region 加减============================
    public void updateCart()
    {
        string id = Request.QueryString["id"];
        string type = Request.QueryString["type"];
        if (type == "1")
        {
            int count = Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_cart set quantity=quantity+1 where id=" + id);
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            int count = Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_cart set quantity=quantity-1 where id=" + id);
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }

    }
    #endregion

    #region 删除============================
    public void deleteCart()
    {
        string id = Request.QueryString["id"];
        new Cms.BLL.C_user_cart().Delete(Convert.ToInt32(id));
        string strJson = "{\"status\":0}";
        Response.Write(strJson);
        Response.End();

    }
    #endregion
    #endregion

    #region 提交订单=======================
    public void addOrder()
    {
        Cms.Model.C_order modelOrder = new Cms.Model.C_order();
        Cms.Model.C_ordersub modelOrderSub = new Cms.Model.C_ordersub();
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int addressId = Convert.ToInt32(Request["addressId"]=="" ? "0":Request["addressId"]);
        int quantity_sum = Convert.ToInt32(Request["quantity_sum"] ?? "0");
        string price_sum = Request["price_sum"] ?? "0";
        string shipping_method = Request["shipping_method"] ?? "0";
        string recommended_code = Request["recommended_code"] ?? "0";
        string note = Request["note"] ?? "0";
        modelOrder.order_num = Cms.Common.Utils.GetOrderNumber();//生成订单号
        modelOrder.user_id = userId;
        modelOrder.adress_id = addressId;//收货地址id
        modelOrder.quantity_sum = quantity_sum;
        modelOrder.price_sum = Convert.ToDecimal(price_sum);
        modelOrder.integral_sum = 0;
        modelOrder.is_payment = 0;//0表示未支付
        modelOrder.order_status = 0;//订单状态
        modelOrder.is_delivery = 0;//订单是否发货
        modelOrder.is_receiving = 0;//是否收货
        modelOrder.is_transaction = 0;//订单是否交易完成
        modelOrder.is_sms = 0;//是否发送短信
        modelOrder.shipping_method = shipping_method;//配送方式
        modelOrder.pay_method = "微信支付";
        modelOrder.note = note;//留言
        modelOrder.recommended_code = recommended_code;//推荐码
        modelOrder.updateTime = DateTime.Now;
        int result = new Cms.BLL.C_order().Add(modelOrder);
        if (result > 0)
        {
            DataTable dt = new Cms.BLL.C_user_cart().GetList("is_checked=2 and user_id=" + userId).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelOrderSub.order_id = result;
                    modelOrderSub.order_num = modelOrder.order_num;
                    modelOrderSub.user_id = userId;
                    modelOrderSub.article_id = Convert.ToInt32(dt.Rows[i]["article_id"]);
                    modelOrderSub.title = dt.Rows[i]["title"].ToString();
                    modelOrderSub.price = Convert.ToDecimal(dt.Rows[i]["price"].ToString());
                    modelOrderSub.quantity = Convert.ToInt32(dt.Rows[i]["quantity"]);
                    modelOrderSub.integral = Convert.ToInt32(dt.Rows[i]["integral"]);
                    modelOrderSub.property_value = dt.Rows[i]["property_value"].ToString();
                    modelOrderSub.note = dt.Rows[i]["note"].ToString();
                    modelOrderSub.updateTime = modelOrder.updateTime;
                    new Cms.BLL.C_ordersub().Add(modelOrderSub);
                    new Cms.BLL.C_user_cart().Delete(Convert.ToInt32(dt.Rows[i]["id"]));
                }
            }
            string strJson = "{\"status\":" + result + "}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
    }

    public void canalOrder() {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        Cms.Model.C_order orderEntity = new Cms.BLL.C_order().GetModel(id);
        orderEntity.order_status = 1;
        if (new Cms.BLL.C_order().Update(orderEntity))
        {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = "{\"status\":1}";
            Response.Write(strJson);
            Response.End();
        }
    }
    //查询地址
    public void getAddressList()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        string where = Request["where"] ?? "0";
        List<Cms.Model.c_user_address> list = new Cms.BLL.c_user_address().GetModelList("user_id=" + userId + where);
        if (list != null && list.Count > 0)
        {
            string strJson = this.LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = this.LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
    }
    public void getAddress()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        Cms.Model.c_user_address model = new Cms.BLL.c_user_address().GetModel(id);
        if (model != null)
        {
            string strJson = LocalSerialize(model);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    public void deleteAddress()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
      
        if (new Cms.BLL.c_user_address().Delete(id))
        {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = "{\"status\":1}";
            Response.Write(strJson);
            Response.End();
        }
    }
    public void defaultAddress()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int id = Convert.ToInt32(Request["id"] ?? "0");
        Cms.DBUtility.DbHelperSQL.ExecuteSql("update c_user_address set is_default=0 where user_id=" + userId);
        Cms.Model.c_user_address model = new Cms.BLL.c_user_address().GetModel(id);
        model.is_default=1;
        if (new Cms.BLL.c_user_address().Update(model))
        {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = "{\"status\":1}";
            Response.Write(strJson);
            Response.End();
        }
    }
    public void addAddress()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int id = Convert.ToInt32(Request["id"] ?? "0");
        string consignee = Request["consignee"] ?? "0";
        string cellphone = Request["cellphone"] ?? "0";
        string code = Request["code"] ?? "0";
        string Province = Request["Province"] ?? "0";
        string City = Request["City"] ?? "0";
        string District = Request["District"] ?? "0";
        string address = Request["address"] ?? "0";
        string is_default = Request["is_default"] ?? "0";
        Cms.Model.c_user_address model = new Cms.Model.c_user_address();
        model.user_id = userId;
        model.consignee = consignee;
        model.cellphone = cellphone;
        model.code = code;
        model.location = Province;
        model.city = City;
        model.county = District;
        //model.street = this.street.Value;
        model.address = address;
        model.is_default = Convert.ToInt32(is_default);
        if (id > 0)
        {
            model.id = id;
            if (new Cms.BLL.c_user_address().Update(model))
            {
                string strJson = "{\"status\":0}";
                Response.Write(strJson);
                Response.End();
            }
            else
            {
                string strJson = "{\"status\":1}";
                Response.Write(strJson);
                Response.End();
            }
        }
        else
        {
            
            int result = new Cms.BLL.c_user_address().Add(model);
            if (result > 0)
            {
                string strJson = "{\"status\":0}";
                Response.Write(strJson);
                Response.End();
            }
            else
            {
                string strJson = "{\"status\":1}";
                Response.Write(strJson);
                Response.End();
            }
        }
       
    }
    #endregion

    #region 读取订单信息=======================
    public void getOrderList()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        string where = Request["where"] ?? "0";
        List<Cms.Model.C_order> list = new Cms.BLL.C_order().GetModelList(where + " user_id=" + userId + "and order_status=0 order by id desc");
        if (list != null && list.Count > 0)
        {
            List<Dictionary<string, object>> listNew = new List<Dictionary<string, object>>();
            foreach (Cms.Model.C_order record in list)
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("id", record.id);
                map.Add("user_id", record.user_id);
                List<Cms.Model.C_ordersub> listSub = new Cms.BLL.C_ordersub().GetModelList("order_id=" + record.id);
                if (listSub != null && listSub.Count > 0)
                {
                    List<Dictionary<string, object>> listSubNew = new List<Dictionary<string, object>>();
                    foreach (Cms.Model.C_ordersub recordSub in listSub)
                    {
                        Dictionary<string, object> mapSub = new Dictionary<string, object>();
                        mapSub.Add("id",recordSub.id);
                        mapSub.Add("title", recordSub.title);
                        mapSub.Add("quantity", recordSub.quantity);
                        mapSub.Add("price", recordSub.price);
                        mapSub.Add("property_value", recordSub.property_value);
                        if (new Cms.BLL.C_product().Exists(Convert.ToInt32(recordSub.article_id)))
                        {
                            mapSub.Add("litpic", new Cms.BLL.C_product().GetModel(Convert.ToInt32(recordSub.article_id)).litpic.ToString());
                            mapSub.Add("marketPrice", new Cms.BLL.C_product().GetModel(Convert.ToInt32(recordSub.article_id)).marketPrice);
                        }
                        listSubNew.Add(mapSub);
                    }
                    map.Add("orderSub", listSubNew);
                }
                map.Add("order_num", record.order_num);
                map.Add("price_sum", record.price_sum);
                map.Add("quantity_sum", record.quantity_sum);
                map.Add("is_payment", record.is_payment);
                map.Add("is_transaction", record.is_transaction);
                map.Add("order_status", getOrderStatus(record.id));
                map.Add("updateTime", record.updateTime);
                listNew.Add(map);
            }
            string strJson = this.LocalSerialize(listNew);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = this.LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
    }

    public void getOrder()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        Cms.Model.C_order model = new Cms.BLL.C_order().GetModel(id);
        if (model != null)
        {
            string strJson = LocalSerialize(model);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }

    public void getOrderSate()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        string result=   getOrderStatus(id);
        string strJson = "{\"status\":\""+ result + "\"}";
        Response.Write(strJson);
        Response.End();
    }

    public void getOrderSubList()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        string where = Request["where"] ?? "0";
        List<Cms.Model.C_ordersub> list = new Cms.BLL.C_ordersub().GetModelList("order_id=" + id);
        if (list != null && list.Count > 0)
        {
            List<Dictionary<string, object>> listSubNew = new List<Dictionary<string, object>>();
            foreach (Cms.Model.C_ordersub recordSub in list)
            {
                Dictionary<string, object> mapSub = new Dictionary<string, object>();
                mapSub.Add("id", recordSub.id);
                mapSub.Add("title", recordSub.title);
                mapSub.Add("quantity", recordSub.quantity);
                mapSub.Add("price", recordSub.price);
                mapSub.Add("property_value", recordSub.property_value);
                if (new Cms.BLL.C_product().Exists(Convert.ToInt32(recordSub.article_id)))
                {
                    mapSub.Add("litpic", new Cms.BLL.C_product().GetModel(Convert.ToInt32(recordSub.article_id)).litpic.ToString());
                    mapSub.Add("marketPrice", new Cms.BLL.C_product().GetModel(Convert.ToInt32(recordSub.article_id)).marketPrice);
                }
                listSubNew.Add(mapSub);
            }
            string strJson = this.LocalSerialize(listSubNew);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            string strJson = this.LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
    }

    public string getOrderStatus(int orderId)
    {
        string result = "";
        Cms.Model.C_order model = new Cms.BLL.C_order().GetModel(orderId);
        if (model.order_status == 1)
        {
            result = "订单取消";
        }
        else
        {
            if (model.is_payment == 0)
            {
                result = "待付款";
            }
            if (model.is_payment == 1 && model.is_delivery == 0)
            {
                result = "待发货";
            }
            if (model.is_payment == 1 && model.is_delivery == 1 && model.is_receiving == 0)
            {
                result = "待收货";
            }
            if (model.is_payment == 1 && model.is_delivery == 1 && model.is_receiving == 1 && model.is_transaction == 0)
            {
                result = "待评价";
            }
            if (model.is_payment == 1 && model.is_delivery == 1 && model.is_receiving == 1 && model.is_transaction == 1)
            {
                result = "交易完成";
            }
        }
        return result;
    }
    #endregion

    #region 获取订单红点==============================
    public void getOrderRed()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int type = Convert.ToInt32(Request["type"] ?? "0");
        int count = 0;
        switch (type)
        {
            case 1:
                count = new Cms.BLL.C_order().GetRecordCount("is_payment=0 and order_status=0 and user_id=" + userId);
                if (count > 0)
                {
                    string strJson = "{\"status\":" + count + "}";
                    Response.Write(strJson);
                    Response.End();
                }
                break;
            case 2:
                count = new Cms.BLL.C_order().GetRecordCount("is_payment=1 and order_status=0 and is_delivery=0 and user_id=" + userId);
                if (count > 0)
                {
                    string strJson = "{\"status\":" + count + "}";
                    Response.Write(strJson);
                    Response.End();
                }
                break;
            case 3:
                count = new Cms.BLL.C_order().GetRecordCount("is_payment=1 and order_status=0 and is_delivery=1 and is_receiving=0 and user_id=" + userId);
                if (count > 0)
                {
                    string strJson = "{\"status\":" + count + "}";
                    Response.Write(strJson);
                    Response.End();
                }
                break;
            case 4:
                count = new Cms.BLL.C_order().GetRecordCount("is_payment=1 and is_delivery=1 and is_receiving=1 and is_transaction=0 and user_id=" + userId);
                if (count > 0)
                {
                    string strJson = "{\"status\":" + count + "}";
                    Response.Write(strJson);
                    Response.End();
                }
                break;
        }
    }
    #endregion

    #region 微信支付统一下单==============================
    public void GetUnifiedOrderResult()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int typeId = Convert.ToInt32(Request["typeId"] ?? "1");
        Cms.Model.C_user userModel = new Cms.BLL.C_user().GetModel(userId);
        JsApiPay jsApiPay = new JsApiPay(this);
        string openid = userModel.openid.ToString();
        string total_fee = "0";
        if (typeId==1)//购物
        {
            Cms.Model.C_order orderEntity = new Cms.BLL.C_order().GetModel(id);
            total_fee = ((int)(Convert.ToDecimal(orderEntity.price_sum) * 100)).ToString();
            jsApiPay.openid = openid;
            jsApiPay.orderid = orderEntity.order_num;
            jsApiPay.productName = "链鲜社区生活馆";
            jsApiPay.total_fee = int.Parse(total_fee);
        }
        else {//充值
            Cms.Model.C_user_recharge orderEntity = new Cms.BLL.C_user_recharge().GetModel(id);
            total_fee = ((int)(Convert.ToDecimal(orderEntity.price) * 100)).ToString();
            jsApiPay.openid = openid;
            jsApiPay.orderid = orderEntity.orderNumber;
            jsApiPay.productName = "链鲜社区生活馆";
            jsApiPay.total_fee = int.Parse(total_fee);
        }
        //JSAPI支付预处理
        WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult();
        string wxJsApiParam = jsApiPay.GetJsApiParameters();
        Response.Write(wxJsApiParam);
        Response.End();
    }
    #endregion

    #region 获取充值记录=======================
    public void getUserRechargeList()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int page = Convert.ToInt32(Request["page"] ?? "0");
        int size = Convert.ToInt32(Request["size"] ?? "3");
        int start = (page - 1) * size + 1;
        int end = page * size;
        DataSet ds = new Cms.BLL.C_user_recharge().GetListByPage("userId=" + userId + " and isPay=1", "id desc", start, end);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_user_recharge> list = new Cms.BLL.C_user_recharge().DataTableToList(ds.Tables[0]);
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }

    public void addUserRecharge() {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        Decimal price = Convert.ToDecimal(Request["price"] ?? "0.1");
        Cms.Model.C_user_recharge model = new Cms.Model.C_user_recharge();
        model.isPay = 0;
        model.userId = userId;
        model.price = price;
        model.typeId = 1;
        model.createdTime = DateTime.Now;
        model.note = "微信充值";
        model.orderNumber ="95"+ Cms.Common.Utils.GetOrderNumber();
        int result = new Cms.BLL.C_user_recharge().Add(model);
        if (result > 0)
        {
            string strJson = "{\"status\":" + result + "}";
            Response.Write(strJson);
            Response.End();
        }
        else {
            string strJson = "{\"status\":0}";
            Response.Write(strJson);
            Response.End();
        }
    }
    #endregion

    #region 获取积分记录=======================
    public void getUserIntegralList()
    {
        int userId = Convert.ToInt32(Request["userId"] ?? "0");
        int page = Convert.ToInt32(Request["page"] ?? "0");
        int size = Convert.ToInt32(Request["size"] ?? "3");
        int start = (page - 1) * size + 1;
        int end = page * size;
        DataSet ds = new Cms.BLL.C_user_integral().GetListByPage("userId=" + userId + " ", "id desc", start, end);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_user_integral> list = new Cms.BLL.C_user_integral().DataTableToList(ds.Tables[0]);
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region 获取积分产品列表=======================
    public void getIntegralProductPageList()
    {

        string where = Request["where"] ?? "";
        string orderBy = Request["orderBy"] ?? "";
        int page = Convert.ToInt32(Request["page"] ?? "0");
        int size = Convert.ToInt32(Request["size"] ?? "3");
        int start = (page - 1) * size + 1;
        int end = page * size;
        DataSet ds = new Cms.BLL.C_integral_product().GetListByPage(where, orderBy + "sortId asc,id desc", start, end);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            List<Cms.Model.C_integral_product> list = new Cms.BLL.C_integral_product().DataTableToList(ds.Tables[0]);
            string strJson = LocalSerialize(list);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    public void getIntegralProductInfo()
    {
        int id = Convert.ToInt32(Request["id"] ?? "0");
        Cms.Model.C_integral_product model = new Cms.BLL.C_integral_product().GetModel(id);
        if (model != null)
        {
            string strJson = LocalSerialize(model);
            Response.Write(strJson);
            Response.End();
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }
    #endregion

    #region  DataSet Datatable转换为Json======================
    public string LocalSerialize(object obj)
    {
        var jser = new System.Web.Script.Serialization.JavaScriptSerializer();
        var json = jser.Serialize(obj);
        //将时间格式转换为适合阅读习惯的格式
        json = System.Text.RegularExpressions.Regex.Replace(json, @"\\/Date\((\d+)\)\\/", match =>
        {
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
            dt = dt.ToLocalTime(); //本地时间
            return dt.ToString(); ;
        });
        return json;
    }

    public static class ConvertJson
    {
        #region  DataSet转换为Json

        /// <summary>           
        /// DataSet转换为Json     
        /// </summary>       
        /// <param name="dataSet">DataSet对象</param>
        /// <returns>Json字符串</returns>  
        public static string ToJson(DataSet dataSet)
        {
            string jsonString = "{\"status\":0,";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + ToJson(table) + ",";
            }
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }
        #endregion

        #region Datatable转换为Json

        /// <summary>   
        /// Datatable转换为Json 
        /// </summary>      
        /// <param name="table">Datatable对象</param>
        /// <returns>Json字符串</returns>    
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }

        /// <summary>  
        /// DataTable转换为Json 
        /// </summary>    
        public static string ToJson(DataTable dt, string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
                jsonName = dt.TableName;
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type type = dt.Rows[i][j].GetType();
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + StringFormat(dt.Rows[i][j].ToString(), type));
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }

        #endregion

        /// <summary>     
        /// 格式化字符型、日期型、布尔型 
        /// </summary>     
        /// <param name="str"></param>   
        /// <param name="type"></param> 
        /// <returns></returns>     
        private static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            return str;
        }

        #region 私有方法
        /// <summary>     
        /// 过滤特殊字符    
        /// </summary>    
        /// <param name="s">字符串</param> 
        /// <returns>json字符串</returns> 
        private static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
        #endregion
    }
    #endregion
}