using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Common;
public partial class Admin_manager_role_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RoleTypeBind();
           //ListControl_Bind(0);//绑定栏目列表
            NavBind(); //绑定导航
            int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//信息id
            string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
            if (action == "edit") //修改
            {
                ShowInfo(id);
            }
        }
    }

    #region 角色类型=================================
    private void RoleTypeBind()
    {
       
        ddlRoleType.Items.Clear();
        ddlRoleType.Items.Add(new ListItem("请选择类型...", ""));
        ddlRoleType.Items.Add(new ListItem("超级用户", "1"));
        ddlRoleType.Items.Add(new ListItem("系统用户", "2"));
        ddlRoleType.Items.Add(new ListItem("普通用户", "3"));
    }
    #endregion

    #region 导航菜单=================================
    private void NavBind()
    {
        Cms.BLL.C_Column bll = new Cms.BLL.C_Column();
        DataTable ds = bll.GetList(0);
        this.rptList.DataSource = ds;
        this.rptList.DataBind();
    }
    #endregion

    #region 绑定栏目列表递归Generate
   
    /// <summary>
    /// 递归栏目信息
    /// </summary>
    /// <param name="n"></param>
    public void ListControl_Bind(int n)
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet dt = bllcolumn.GetList("parentId=" + n + "");

        dt.Tables[0].Columns.Add("Operate", typeof(string));//操作
        dt.Tables[0].Columns.Add("Colum", typeof(String));//在dt中增加字段名为Colum的列
        if (dt.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.Tables[0].Rows[i];
                string strchar = "";
                strchar += "<td style='white-space:nowrap;word-break:break-all;overflow:hidden;' >";
                strchar += "<input id='rptList_ctl00_hidName' type='hidden' name='rptList$ctl00$hidName' Value='" + dr["className"].ToString() + "' runat='server' />";
                strchar += "<input id=='rptList_ctl00_hidActionType' type='hidden' name='rptList$ctl00$hidActionType' Value='" + dr["action_type"].ToString() + "' runat='server' />";
                strchar += "<input id='rptList_ctl00_hidLayer' type='hidden' name='rptList$ctl00$hidLayer' Value='" + dr["class_layer"].ToString() + "' runat='server' />";
                strchar += "<span class='folder-open'></span>";
                strchar += dr["className"].ToString();
                strchar += "</td>";
                strchar = InitChild(dr, strchar, 2);
                dr["Colum"] = strchar;
            }
        }
        this.rptList.DataSource = dt;
        this.rptList.DataBind();
    }

    private string InitChild(DataRow dr, string strchar, int n)
    {
        Cms.BLL.C_Column bllcolumn = new Cms.BLL.C_Column();
        Cms.Model.C_Column modelcolumn = new Cms.Model.C_Column();
        DataSet dtt = bllcolumn.GetList("parentId=" + dr["classid"] + "");

        dtt.Tables[0].Columns.Add("Operate", typeof(string));
        dtt.Tables[0].Columns.Add("Colum", typeof(String));
        if (dtt.Tables[0].Rows.Count > 0)
        {
            string s = "&nbsp;";
            for (int j = 1; j <= n; j++)
            {
                s += "&nbsp;";
            }
            for (int k = 0; k < dtt.Tables[0].Rows.Count; k++)
            {
                DataRow dro = dtt.Tables[0].Rows[k];
                string flag = "├";
                if (dtt.Tables[0].Rows.Count == 1)
                {
                    flag = "├";
                }
                else
                {
                    if (k == 0)
                    {
                        flag = "├";
                    }
                    if (k == dtt.Tables[0].Rows.Count - 1)
                    {
                        flag = "├";
                    }
                }
                strchar += "<td style='white-space:nowrap;word-break:break-all;overflow:hidden;' >";
                strchar += "<input id='rptList_ctl00_hidName' type='hidden' name='rptList$ctl00$hidName' Value='" + dro["className"].ToString() + "' runat='server' />";
                strchar += "<input id=='rptList_ctl00_hidActionType' type='hidden' name='rptList$ctl00$hidActionType' Value='" + dro["action_type"].ToString() + "' runat='server' />";
                strchar += "<input id='rptList_ctl00_hidLayer' type='hidden' name='rptList$ctl00$hidLayer' Value='" + dro["class_layer"].ToString() + "' runat='server' />";
                strchar += "<span class='folder-open'></span>";
                strchar += dro["className"].ToString();
                strchar += "</td>";
                strchar = InitChild(dro, strchar, n + 8);
            }

        }
        return strchar;
    }
    #endregion

    #region //美化列表=================================
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //美化导航树结构
            Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
            HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
            string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            string LitImg1 = "<span class=\"folder-open\"></span>";
            string LitImg2 = "<span class=\"folder-line\"></span>";
            Repeater rck = (Repeater)e.Item.FindControl("rck");
            int classLayer = Convert.ToInt32(hidLayer.Value);
            if (classLayer == 1)
            {
                LitFirst.Text = LitImg1;
            }
            else
            {
                LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
            }
            //绑定导航权限资源
            string[] actionTypeArr = ((HiddenField)e.Item.FindControl("hidActionType")).Value.Split(',');
            //CheckBoxList cblActionType = (CheckBoxList)e.Item.FindControl("cblActionType");
            Label lbshow = (Label)e.Item.FindControl("lbshow");
            Label lbshow2 = (Label)e.Item.FindControl("lbshow2");
            Label lbshow3 = (Label)e.Item.FindControl("lbshow3");
            Label lbshow4 = (Label)e.Item.FindControl("lbshow4");
            Label lbshow5 = (Label)e.Item.FindControl("lbshow5");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox1 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("checkbox1");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox2 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("checkbox2");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox3 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("checkbox3");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox4 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("checkbox4");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox5 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("checkbox5");

            checkbox1.Visible = false;
            checkbox2.Visible = false;
            checkbox3.Visible = false;
            checkbox4.Visible = false;
            checkbox5.Visible = false;
            //cblActionType.Items.Clear();
            for (int i = 0; i < actionTypeArr.Length; i++)
            {
                //if (Utils.ActionType().ContainsKey(actionTypeArr[i]))
                //{
                //    cblActionType.Items.Add(new ListItem(" " + Utils.ActionType()[actionTypeArr[i]] + " ", actionTypeArr[i]));
                //}
                if (i == 0)
                {
                    lbshow.Text = Utils.ActionType()[actionTypeArr[0]];
                    checkbox1.Visible = true;
                }
                if (i == 1)
                {
                    lbshow2.Text = Utils.ActionType()[actionTypeArr[1]];
                    checkbox2.Visible = true;
                }
                if (i == 2)
                {
                    lbshow3.Text = Utils.ActionType()[actionTypeArr[2]];
                    checkbox3.Visible = true;
                }
                if (i == 3)
                {
                    lbshow4.Text = Utils.ActionType()[actionTypeArr[3]];
                    checkbox4.Visible = true;
                }
                if (i == 4)
                {
                    lbshow5.Text = Utils.ActionType()[actionTypeArr[4]];
                    checkbox5.Visible = true;
                }
            }
        }
    }
    #endregion

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        Cms.BLL.C_admin_role bll = new Cms.BLL.C_admin_role();
        Cms.Model.C_admin_role model = bll.GetModel(_id);
        txtRoleName.Text = model.role_name;
        ddlRoleType.SelectedValue = model.role_type.ToString();
        //管理权限
       
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
               // CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox1 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox1");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox2 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox2");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox3 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox3");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox4 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox4");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox5 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox5"); 

               // for (int n = 0; n < cblActionType.Items.Count; n++)
                {
                    Cms.BLL.C_admin_role_value bllrole_value = new Cms.BLL.C_admin_role_value();
                    DataSet ds = bllrole_value.GetList("nav_name='" + navName + "' and role_id=" + _id);
                    if(ds!=null&&ds.Tables[0].Rows.Count>0)
                    {
                        string[] actionTypeArr = ds.Tables[0].Rows[0]["action_type"].ToString().Split(',');
                        for (int j = 0; j < actionTypeArr.Length; j++)
                        {
                            if (j == 0)
                            {
                                checkbox1.Checked = true;
                            }
                            if (j == 1)
                            {
                                checkbox2.Checked = true;
                            }
                            if (j == 2)
                            {
                                checkbox3.Checked = true;
                            }
                            if (j == 3)
                            {
                                checkbox4.Checked = true;
                            }
                            if (j == 4)
                            {
                                checkbox5.Checked = true;
                            }
                        }
                        //cblActionType.Items[n].Selected = true;
                    }
                    
                }
                
                
            }
        
        
    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        bool result = false;
        Cms.Model.C_admin_role model = new Cms.Model.C_admin_role();
        Cms.BLL.C_admin_role bll = new Cms.BLL.C_admin_role();

        model.role_name = txtRoleName.Text.Trim();
        model.role_type = int.Parse(ddlRoleType.SelectedValue);

        int count=bll.Add(model);

        if (count > 0)
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Add.ToString(), model.role_name); //记录日志
            //管理权限
            Cms.BLL.C_admin_role_value bllrole_value = new Cms.BLL.C_admin_role_value();
            Cms.Model.C_admin_role_value modelrole_value = new Cms.Model.C_admin_role_value();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string[] actionTypeArr = ((HiddenField)rptList.Items[i].FindControl("hidActionType")).Value.Split(',');
                string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
               // CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox1 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox1");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox2 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox2");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox3 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox3");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox4 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox4");
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox5 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox5");
                //for (int n = 0; n < cblActionType.Items.Count; n++)
                //{
                //    if (cblActionType.Items[n].Selected == true)
                //    {
                //        modelrole_value.role_id = count;
                //        modelrole_value.nav_name = navName;
                //        modelrole_value.action_type = cblActionType.Items[n].Value;
                //        bllrole_value.Add(modelrole_value);
                //    }
                //}
               
                string str = "";
                if (checkbox1.Checked == true)
                {
                    str += actionTypeArr[0]+",";
                }
                if (checkbox2.Checked == true)
                {
                    str += actionTypeArr[1] + ",";  
                }
                if (checkbox3.Checked == true)
                {
                    str += actionTypeArr[2] + ",";
                }
                if (checkbox4.Checked == true)
                {
                    str += actionTypeArr[3] + ",";
                }
                if (checkbox5.Checked == true)
                {
                    str += actionTypeArr[4]+",";
                }
                if (str.Length > 0)
                {
                    str = str.Substring(0,str.Length-1);
                    modelrole_value.role_id = count;
                    modelrole_value.nav_name = navName;
                    modelrole_value.action_type = str;
                    bllrole_value.Add(modelrole_value);
                }
               
            }

            result = true;
        }
        return result;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;
        Cms.BLL.C_admin_role bll = new Cms.BLL.C_admin_role();
        Cms.Model.C_admin_role model = bll.GetModel(_id);

        model.role_name = txtRoleName.Text.Trim();
        model.role_type = int.Parse(ddlRoleType.SelectedValue);

        //管理权限
        Cms.BLL.C_admin_role_value bllrole_value = new Cms.BLL.C_admin_role_value();
        Cms.Model.C_admin_role_value modelrole_value = new Cms.Model.C_admin_role_value();
        bllrole_value.DeleteList("role_id=" + _id);
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
            //CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
            //for (int n = 0; n < cblActionType.Items.Count; n++)
            //{
            //    if (cblActionType.Items[n].Selected == true)
            //    {
            //        modelrole_value.role_id = _id;
            //        modelrole_value.nav_name = navName;
            //        modelrole_value.action_type = cblActionType.Items[n].Value;
            //        bllrole_value.Add(modelrole_value);
            //    }
            //}
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox1 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox1");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox2 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox2");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox3 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox3");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox4 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox4");
            System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox5 = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptList.Items[i].FindControl("checkbox5");
            string[] actionTypeArr = ((HiddenField)rptList.Items[i].FindControl("hidActionType")).Value.Split(',');


            string str = "";
            if (checkbox1.Checked == true)
            {
                str += actionTypeArr[0] + ",";
            }
            if (checkbox2.Checked == true)
            {
                str += actionTypeArr[1] + ",";
            }
            if (checkbox3.Checked == true)
            {
                str += actionTypeArr[2] + ",";
            }
            if (checkbox4.Checked == true)
            {
                str += actionTypeArr[3] + ",";
            }
            if (checkbox5.Checked == true)
            {
                str += actionTypeArr[4] + ",";
            }
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
                modelrole_value.role_id = _id;
                modelrole_value.nav_name = navName;
                modelrole_value.action_type = str;
                bllrole_value.Add(modelrole_value);
            }
        }
       

        if (bll.Update(model))
        {
            adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.role_name); //记录日志
            result = true;
        }
        return result;
    }
    #endregion

    #region 提示框=================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

    #region 提交操作=================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.Request.QueryString["id"] ?? "0");//信息id
        string action = this.Request.QueryString["action"] ?? "";//编辑：edit 添加：add
        if (action == "edit") //修改
        {
            
            if (!DoEdit(id))
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("提交信息成功！", "role_list.aspx", "Success");
        }
        else //添加
        {
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("提交信息成功！", "role_list.aspx", "Success");
        }
    }
    #endregion
}