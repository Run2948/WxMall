using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cms.Service.Task;
using Cms.BLL;
using Cms.Common;
using System.Data;

namespace Cms.Service.TaskNode
{
    /// <summary>
    /// 操作定时任务信息管理
    /// </summary>
    public class BirthdayReminder : TaskBase, ITask
    {
        public override void Execute(object state)
        {
            C_user bll = new C_user();
            DataSet ds = bll.GetList("CAST(datepart(month,birthday) as varchar(4))+'月'+CAST(datepart(day,birthday) as varchar(4))+'日' = CAST(datepart(month,getdate()) as varchar(4))+'月'+CAST(datepart(day,getdate()) as varchar(4))+'日'");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["telphone"] != null)
                    {
                        string mobile = ds.Tables[0].Rows[i]["telphone"].ToString();
                        if (!string.IsNullOrEmpty(mobile) && Commons.IsMobile(mobile))
                        {
                            string url = string.Format("http://sms.zhiqiyun.com/interface.api?sn=ZQY-HN-TEST&key=test123456&mobile={0}&content={1}", mobile, "你的生日到了");
                            try
                            {
                                System.Net.WebClient client = new System.Net.WebClient();
                                string reply = Cms.Common.Utils.HttpGet(url);
                                //Person p = Cms.Common.Utils.JsonDeserialize<Person>(reply);

                                //if (p.rescode == "0")
                                //{
                                //    Cms.BLL.C_sms bll = new Cms.BLL.C_sms();
                                //    Cms.Model.C_sms model = new Cms.Model.C_sms();
                                //    model.name = this.Title.Text.Trim();//名字
                                //    model.telphone = this.englishtitle.Text;//手机号码
                                //    model.content = this.seoDescription.Text.Trim();//内容
                                //    model.state = 0;
                                //    model.updateTime = Convert.ToDateTime(Cms.Common.ManagementInfo.GetTime());//时间
                                //    int result = bll.Add(model);
                                //}
                            }
                            catch (Exception ex) { throw ex; }
                        }
                    }
                }
            }
        }
    }

    public class Person
    {

        public string rescode { get; set; }

        public string message { get; set; }

    }
}
