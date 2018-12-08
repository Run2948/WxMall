using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Common;

public partial class Admin_message_comment_edit : System.Web.UI.Page
{
    private int id = 0;
    private string channel_name = string.Empty; //频道名称
    protected Cms.Model.C_article_comment model = new Cms.Model.C_article_comment();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.id = 0;
        id =Convert.ToInt32(Request.QueryString["id"]);
        if (!new Cms.BLL.C_article_comment().Exists(this.id))
        {
            JscriptMsg("记录不存在或已删除！", "back", "Error");
            return;
        }
        if (!Page.IsPostBack)
        {
            ShowInfo(this.id);
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        Cms.BLL.C_article_comment bll = new Cms.BLL.C_article_comment();
        model = bll.GetModel(_id);
        txtReContent.Text = Utils.ToTxt(model.reply_content);
        rblIsLock.SelectedValue = model.is_lock.ToString();
        this.channel_name = "";//new BLL.channel().GetChannelName(model.channel_id); //取得频道名称
    }
    #endregion

    #region 保存========================================================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Cms.BLL.C_article_comment bll = new Cms.BLL.C_article_comment();
        model = bll.GetModel(this.id);
        model.is_reply = 1;
        model.reply_content = Utils.ToHtml(txtReContent.Text);
        model.is_lock = int.Parse(rblIsLock.SelectedValue);
        model.reply_time = DateTime.Now;
        bll.Update(model);
        adminUser.AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), model.reply_content); //记录日志
        JscriptMsg("评论回复成功！", "comment_list.aspx?channel_id=" + model.channel_id, "Success");
    }
    #endregion

    #region 提示框=========================================
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion
}