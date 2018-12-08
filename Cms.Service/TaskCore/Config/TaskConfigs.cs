using System;
using System.Collections.Generic;
using System.Text;
using Cms.Common;

namespace Cms.Service.Config
{
    /// <summary>
    /// 系统任务配置序列化操作类
    /// </summary>
    public class TaskConfigs : ConfigsBase
    {
        private static TaskConfigs _instance;
        public static TaskConfigs Instance()
        {
            if (_instance == null)
            {
                _instance = new TaskConfigs();
            }
            return _instance;
        }

        private string _configFilePath;
        protected override string ConfigFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_configFilePath))
                {
                    _configFilePath = Commons.GetMapPath("config/task.config");
                  //  Log4Helper.Info("定时任务配置文件路径："+_configFilePath);
                }
                return _configFilePath;
            }
        }

        

        protected override Type ConfigInfoType
        {
            get { return typeof(TaskConfig); }
        }


        public TaskConfigs()
        {
            Load();
        }

        private TaskConfig _config;

        public TaskConfig GetConfig()
        {
            return _config;
        }
        /// <summary>
        /// 从配置文件载入
        /// </summary>
        protected void Load()
        {
            try
            {
                _config = (TaskConfig)LoadConfig();
            }
            catch (Exception)
            {
                _config = new TaskConfig(new List<TaskConfigInfo>());
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="config"></param>
        public void Save(TaskConfig config)
        {
            try
            {
                SaveConfig(config);
                Load();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
