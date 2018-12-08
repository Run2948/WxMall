using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service.Config
{
    /// <summary>
    /// 系统任务配置序列化类
    /// </summary>
    [Serializable]
    public class TaskConfig : IConfigInfo
    {
        private List<TaskConfigInfo> _configlist;
        /// <summary>
        /// 所有上传配置列表
        /// </summary>
        public List<TaskConfigInfo> ConfigList
        {
            get { return _configlist; }
            set { _configlist = value; }
        }

        public TaskConfig(List<TaskConfigInfo> configlist)
        {
            _configlist = configlist;
        }
        public TaskConfig()
        {
            _configlist = new List<TaskConfigInfo>();
        }

        /// <summary>
        /// 超找某个模块配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TaskConfigInfo FindConfig(string typeName)
        {
            if (ConfigList == null || ConfigList.Count == 0)
                return null;
            TaskConfigFilter filter = new TaskConfigFilter(typeName);
            List<TaskConfigInfo> list = ConfigList.FindAll(new Predicate<TaskConfigInfo>(filter.Match));

            if (list.Count == 0)
                return null;
            else
                return list[0];
        }
    }

    /// <summary>
    /// 配置过滤器
    /// </summary>
    public class TaskConfigFilter
    {
        private string _typename;

        public TaskConfigFilter(string typeName)
        {
            _typename = typeName;
        }

        public bool Match(TaskConfigInfo item)
        {
            if (item.TypeName == _typename)
                return true;
            else
                return false;
        }
    }
}
