using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Cms.Common;

namespace Cms.Service.Config
{
    /// <summary>
    /// 配置抽象基类
    /// </summary>
    public abstract class ConfigsBase
    {

        protected abstract string ConfigFilePath
        {
            get;
        }



        protected abstract System.Type ConfigInfoType
        {
            get;
        }
        /// <summary>
        /// 锁对象
        /// </summary>
        protected object lockHelper = new object();

        /// <summary>
        /// 从文件中加载配置
        /// </summary>
        /// <returns></returns>
        protected IConfigInfo LoadConfig()
        {
            lock (lockHelper)
            {
                if (!File.Exists(ConfigFilePath)) 
                    throw new Exception("文件:" + ConfigFilePath + " 不存在");

                return (IConfigInfo)SerializationHelper.Load(ConfigInfoType, ConfigFilePath);
            }
        }

        /// <summary>
        /// 保存配置到文件中 
        /// </summary>
        /// <param name="configinfo"></param>
        /// <returns></returns>
        protected bool SaveConfig(IConfigInfo configinfo)
        {
            lock (lockHelper)
            {
                return SerializationHelper.SaveSuccess(configinfo, ConfigFilePath);
            }
        }
    }
}
