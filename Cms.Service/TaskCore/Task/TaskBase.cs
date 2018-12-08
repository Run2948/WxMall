using System;
using System.Collections.Generic;
using System.Text;
using Cms.Service.Config;

namespace Cms.Service.Task
{
    /// <summary>
    /// 任务基类
    /// </summary>
    public abstract class TaskBase : ITask
    {

        public abstract void Execute(object state);

      

        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get { return this.GetType().FullName; }
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

        private DateTime? _LastExecuteTime;
        /// <summary>
        /// 获取或设置 上次执行时间
        /// </summary>
        public DateTime LastExecuteTime
        {
            get
            {
                if (_LastExecuteTime == null)
                    _LastExecuteTime = DateTime.MinValue;
                return _LastExecuteTime.Value;
            }
            set { _LastExecuteTime = value; }
        }

        private XmlTimeSpan _executeTime;
        /// <summary>
        /// 执行时间
        /// </summary>
        public XmlTimeSpan ExecuteTime
        {
            get
            {
                if (_executeTime == null)
                    return new XmlTimeSpan();

                return _executeTime;
            }


        }



        private bool enabled;
        /// <summary>
        /// 获取或设置任务十分启用
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        private TaskTimeType _timetype;
        /// <summary>
        /// 获取 或设置 执行时间类型
        /// </summary>
        public TaskTimeType TimeType
        {
            get
            {
                return _timetype;
            }
            set
            {
                _timetype = value;
            }
        }

        private long? interval;
        public long Interval
        {
            get
            {
                if (interval != null)
                    return interval.Value;
                else
                    return 1;
            }
        }


        private DayOfWeek? m_DayOfWeek;
        /// <summary>
        /// 周中的星期
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get
            {
                if (m_DayOfWeek == null)
                {
                    if (TimeType == TaskTimeType.Week)
                        m_DayOfWeek = DayOfWeek.Monday;
                }
                return m_DayOfWeek.Value;
            }
        }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="config"></param>
        internal void Init(TaskConfigInfo config)
        {
            if (config == null)
                throw new Exception(this.Type + " 任务配置文件失效");

            if (config.TypeName.IndexOf(this.Type) == -1)
                throw new Exception(this.Type + " 任务配置文件不匹配");

            this.TaskName = config.TaskName;
            this._executeTime = config.ExecuteTime;
            this.Enabled = config.Enabled;
            this.interval = config.Interval;
            this.TimeType = config.Timetype;
            this.LastExecuteTime = config.LastExecuteTime;
        }

        ///// <summary>
        ///// TimeType为Interval时 在SetTime()中请调用此方法 设置执行时间,只支持一个月的时间
        ///// </summary>
        ///// <param name="seconds"></param>
        //protected void SetIntervalExecuteTime(long seconds)
        //{
        //    if (seconds <= 60)
        //    {
        //        _executeTime = new XmlTimeSpan(0, 0, (int)seconds);
        //    }
        //    else if (seconds <= 60 * 60) //小于等于60分钟
        //    {
        //        SetHourExecuteTime((int)(seconds / 60), (int)(seconds % 60));
        //    }
        //    else if (seconds <= 24 * 60 * 60) //一天
        //    { 
        //        SetDayExecuteTime((int)(seconds / 60*60), (int)(seconds % 60*60, (int)(seconds % 60));
        //    }
        //    else if( seconds <= 31*24*60*60) //一个月
        //    {
        //        SetMonthExecuteTime((int)(seconds / 24*60*60) ,(int)(seconds / 60*60), (int)(seconds % 60*60, (int)(seconds % 60));
        //    }
        //    else
        //        _executeTime=new XmlTimeSpan();
        //}

        ///// <summary>
        ///// TimeType为Hour时 在SetTime()中请调用此方法 设置执行时间
        ///// </summary>
        //protected void SetHourExecuteTime(int minutes, int seconds)
        //{
        //    if (minutes > 59)
        //        minutes = 59;
        //    if (seconds > 59)
        //        seconds = 59;

        //    _executeTime = new XmlTimeSpan(0, minutes, seconds);
        //}

        ///// <summary>
        ///// TimeType为Day时 在SetTime()中请调用此方法 设置执行时间
        ///// </summary>
        //protected void SetDayExecuteTime(int hours, int minutes, int seconds)
        //{
        //    if (hours > 23)
        //        hours = 23;
        //    if (minutes > 59)
        //        minutes = 59;
        //    if (seconds > 59)
        //        seconds = 59;

        //    _executeTime = new XmlTimeSpan(hours, minutes, seconds);
        //}

        ///// <summary>
        ///// TimeType为Week时 在SetTime()中请调用此方法 设置执行时间
        ///// </summary>
        //protected void SetWeekExecuteTime(DayOfWeek dayOfWeek, int hours, int minutes, int seconds)
        //{
        //    m_DayOfWeek = dayOfWeek;
        //    SetDayExecuteTime(hours, minutes, seconds);
        //}

        ///// <summary>
        ///// TimeType为Month时 在SetTime()中请调用此方法 设置执行时间
        ///// </summary>
        //protected void SetMonthExecuteTime(int day, int hours, int minutes, int seconds)
        //{
        //    if (day > 31)
        //        day = 31;
        //    if (hours > 23)
        //        hours = 23;
        //    if (minutes > 59)
        //        minutes = 59;
        //    if (seconds > 59)
        //        seconds = 59;

        //    _executeTime = new XmlTimeSpan(day, hours, minutes, seconds);
        //}

        ///// <summary>
        ///// TimeType为Year时 在SetTime()中请调用此方法 设置执行时间
        ///// </summary>
        //protected void SetYearExecuteTime(int month, int day, int hours, int minutes, int seconds)
        //{
        //    if (month > 12)
        //        month = 12;
        //    if (day > 31)
        //        day = 31;
        //    if (hours > 23)
        //        hours = 23;
        //    if (minutes > 59)
        //        minutes = 59;
        //    if (seconds > 59)
        //        seconds = 59;
        //    m_Month = month;
        //    _executeTime = new XmlTimeSpan(day, hours, minutes, seconds);
        //}

    }
}
