using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service.Config
{
    /// <summary>
    /// 任务执行时间类型
    /// </summary>
    [Serializable]
    public enum TaskTimeType
    {
        /// <summary>
        /// 间隔一定时间执行
        /// </summary>
        Interval = 0,
        /// <summary>
        /// 分钟
        /// </summary>
        Seconds=6,

        /// <summary>
        /// 每个小时里的固定时间执行
        /// </summary>
        Hour = 1,

        /// <summary>
        /// 每天固定时间执行
        /// </summary>
        Day = 2,

        /// <summary>
        /// 每周的固定时间执行
        /// </summary>
        Week = 3,

        /// <summary>
        /// 每月的固定时间执行
        /// </summary>
        Month = 4,

        /// <summary>
        /// 每年的固定时间执行
        /// </summary>
        Year = 5,


    }
}
