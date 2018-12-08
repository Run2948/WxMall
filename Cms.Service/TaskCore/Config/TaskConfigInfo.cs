using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service.Config
{
    /// <summary>
    /// 单个任务配置实体
    /// </summary>
    [Serializable]
    public class TaskConfigInfo
    {
        private string _typename;
        /// <summary>
        /// 完整类型名
        /// </summary>
        public string TypeName
        {
            get { return _typename; }
            set { _typename = value; }
        }
        private string _taskname;
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName
        {
            get { return _taskname; }
            set { _taskname = value; }
        }

        private TaskTimeType _timetype;
        /// <summary>
        /// 任务执行的时间类型
        /// </summary>
        public TaskTimeType Timetype
        {
            get { return _timetype; }
            set { _timetype = value; }
        }

        private long _interval;
        /// <summary>
        /// 间隔时间类型执行
        /// </summary>
        public long Interval
        {
            get
            {
                if (_interval <= 0)
                    return 1;

                return _interval;
            }
            set { _interval = value; }
        }


        private XmlTimeSpan _executeTime;
        /// <summary>
        /// 执行时间
        /// </summary>
        public XmlTimeSpan ExecuteTime
        {
            get { return _executeTime; }
            set { _executeTime = value; }
        }

        private bool _enabled;
        /// <summary>
        /// 是否启用此任务
        /// </summary>
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        private DateTime _lastExecuteTime;
        /// <summary>
        /// 任务的最后执行时间
        /// </summary>
        public DateTime LastExecuteTime
        {
            get { return _lastExecuteTime; }
            set { _lastExecuteTime = value; }
        }


    }
}
