using Cms.Service.Task;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Service
{
    public partial class CmsService : ServiceBase
    {
        public CmsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServicesStart();
        }

        protected override void OnStop()
        {
        }

        #region 服务启动事件
        /// <summary>
        /// 服务启动事件
        /// </summary>
        public void ServicesStart()
        {
            //Log4Helper.Info("程序已启动");

            //#region 缓存池初始化，禁用服务列表
            //CacheInit.InitCache();
            //#endregion

            #region 执行定时任务
            try
            {
                Cms.Common.FileHelper.Write("E:\\win_services\\DBE\\log.txt", "服务启动");
                TaskManager.Init();
            }
            catch (Exception e)
            {
               // Log4Helper.Error("运行定时任务出错：", e);
            }
            #endregion
        }
        #endregion
    }
}
