using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cms.Common;

namespace Cms.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:站点配置
    /// </summary>
    public partial class siteconfig
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.siteconfig loadConfig(string configFilePath)
        {
            return (Model.siteconfig)SerializationHelper.Load(typeof(Model.siteconfig), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.siteconfig saveConifg(Model.siteconfig model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }

    }
}
