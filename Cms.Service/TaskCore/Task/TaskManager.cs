using System;
using System.Collections.Generic;
using System.Text;
using Cms.Service.Config;
using Cms.Common;

namespace Cms.Service.Task
{
    public class TaskManager
    {
        private readonly static List<TaskBase> _allTasks = new List<TaskBase>();


        /// <summary>
        /// 初始化加载所有任务
        /// </summary>
        public static void Init()
        {
            if (_allTasks.Count<=0)
            {
                List<TaskConfigInfo> configList = TaskConfigs.Instance().GetConfig().ConfigList;
                //Log4Helper.Info(configList.Count + "个任务将被执行，等待执行中...");
                Cms.Common.FileHelper.Write("E:\\win_services\\DBE\\log.txt", configList.Count + "个任务将被执行，等待执行中...");
                foreach (TaskConfigInfo taskConfig in configList)
                {
                    Type type = Type.GetType(taskConfig.TypeName);
                    if (type == null)
                    {
                        //Log4Helper.Error(string.Format("任务 {0} 无法被正确识别", taskConfig.TypeName));
                    }
                    else
                    {
                        TaskBase taskbase = (TaskBase)Activator.CreateInstance(type);
                        taskbase.Init(taskConfig);
                        if (taskbase == null)
                        {
                            //Log4Helper.Error(string.Format("任务 {0} 无法被正确加载", taskConfig.TypeName));
                        }
                        else
                        {
                            _allTasks.Add(taskbase);
                        }
                    }
                }
            }

            StartTaskThread();
        }

        /// <summary>
        /// 开始线程执行所有任务
        /// </summary>
        private static void StartTaskThread()
        {
           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(InThreadTaskWorker));

          //   System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(ExecuteInThreadTasks));
            thread.Start();
            //Log4Helper.Debug(string.Format("后台任务线程开始启动,{0}", DateTime.Now.ToString()));
            thread.IsBackground = true;
        }

        private static void InThreadTaskWorker()
        {
            while (true)
            {
                try
                {
                    ExecuteInThreadTasks();
                }
                catch (Exception ex)
                {
                    //Log4Helper.Error(ex.Message);
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 执行所有任务
        /// </summary>
        private static void ExecuteInThreadTasks()
        {
            foreach (TaskBase task in _allTasks)
            {
                if (!task.Enabled)
                    continue;

                if (IsExecuteTime(task))
                    ExecuteTask(task);
            }
        }

        /// <summary>
        /// 执行单个任务
        /// </summary>
        /// <param name="task"></param>
        private static void ExecuteTask(TaskBase task)
        {
            //设置最后一次执行时间
            task.LastExecuteTime = DateTime.Now;
            RecordExecuteTime(task.Type, DateTime.Now);

            //Log4Helper.Info("task:" + task.TaskName + ",type:" + task.Type + ",time:" + DateTime.Now.ToString());
            ManagedThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(task.Execute));

            //  task.Execute(null);
        }

        /// <summary>
        /// 检查任务是否到了可以执行的时间
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        private static bool IsExecuteTime(TaskBase task)
        {
            DateTime executeTime;
            switch (task.TimeType)
            {
                case TaskTimeType.Interval:
                   if (task.LastExecuteTime.AddSeconds(task.ExecuteTime.TimeSinceLastEvent.TotalSeconds) <= DateTime.Now)
                    //Log4Helper.Info("预计执行时间：" + task.LastExecuteTime.AddSeconds(task.Interval).ToString());
                    // if (task.LastExecuteTime.AddTicks(task.Interval) <= DateTime.Now)
                        return true;
                    break;
                case TaskTimeType.Seconds:
                    if (task.LastExecuteTime.AddSeconds(task.Interval) <= DateTime.Now)
                        //Log4Helper.Info("预计执行时间：" + task.LastExecuteTime.AddSeconds(task.Interval).ToString());
                        // if (task.LastExecuteTime.AddTicks(task.Interval) <= DateTime.Now)
                        return true;
                    break;
                case TaskTimeType.Hour:  
                   // executeTime = new DateTime(task.LastExecuteTime.Year, task.LastExecuteTime.Month,task.LastExecuteTime.Day, task.LastExecuteTime.Hour, task.ExecuteTime.TimeSinceLastEvent.Minutes, task.ExecuteTime.TimeSinceLastEvent.Seconds);
                    executeTime = task.LastExecuteTime;
                   // Log4Helper.Info("按小时间隔执行任务“"+task.TaskName+"”，预计下次执行时间：" + executeTime.AddHours(Convert.ToInt32(task.Interval)).ToString());
                   if (executeTime.AddHours(Convert.ToInt32(task.Interval)) <= DateTime.Now)
                        return true;
                    break;
                case TaskTimeType.Day:
                    //executeTime = new DateTime(task.LastExecuteTime.Year, task.LastExecuteTime.Month, task.LastExecuteTime.Day, task.ExecuteTime.TimeSinceLastEvent.Hours, task.ExecuteTime.TimeSinceLastEvent.Minutes, task.ExecuteTime.TimeSinceLastEvent.Seconds);
                    executeTime = task.LastExecuteTime;
                   // Log4Helper.Info("按天间隔执行任务“" + task.TaskName + "”，预计下次执行时间：" + executeTime.AddDays(Convert.ToInt32(task.Interval)).ToString());
                    if (executeTime.AddDays(Convert.ToInt32(task.Interval)) < DateTime.Now)
                        return true;
                    break;
                case TaskTimeType.Week:
                    if (DateTime.Now.DayOfWeek == task.DayOfWeek)
                    {
                        if (task.LastExecuteTime.Year == DateTime.Now.Year && task.LastExecuteTime.Month == DateTime.Now.Month && task.LastExecuteTime.Day == DateTime.Now.Day)
                        { }
                        else
                        {
                           // executeTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, task.ExecuteTime.TimeSinceLastEvent.Hours, task.ExecuteTime.TimeSinceLastEvent.Minutes, task.ExecuteTime.TimeSinceLastEvent.Seconds);
                            executeTime = task.LastExecuteTime;
                            if (executeTime.AddDays(Convert.ToInt32(task.Interval) * 7) <= DateTime.Now)
                                return true;
                        }
                    }
                    break;
                case TaskTimeType.Month:
                   // executeTime = new DateTime(task.LastExecuteTime.Year, task.LastExecuteTime.Month, task.ExecuteTime.TimeSinceLastEvent.Days, task.ExecuteTime.TimeSinceLastEvent.Hours, task.ExecuteTime.TimeSinceLastEvent.Minutes, task.ExecuteTime.TimeSinceLastEvent.Seconds);
                    executeTime = task.LastExecuteTime;
                   if (executeTime.AddMonths(Convert.ToInt32(task.Interval)) < DateTime.Now)
                        return true;
                    break;
                case TaskTimeType.Year:
                    //executeTime = new DateTime(task.LastExecuteTime.Year, task.Month, task.ExecuteTime.TimeSinceLastEvent.Days, task.ExecuteTime.TimeSinceLastEvent.Hours, task.ExecuteTime.TimeSinceLastEvent.Minutes, task.ExecuteTime.TimeSinceLastEvent.Seconds);
                    executeTime = task.LastExecuteTime;
                    if (executeTime.AddYears(Convert.ToInt32(task.Interval)) < DateTime.Now)
                        return true;
                    break;
            }
            return false;
        }

       
        /// <summary>
        /// 记录任务最后一次执行的时间
        /// </summary>
        /// <param name="taskType"></param>
        /// <param name="time"></param>
        private static void RecordExecuteTime(string taskType, DateTime time)
        {
            try
            {
                TaskConfigInfo task = TaskConfigs.Instance().GetConfig().FindConfig(taskType);
                //设置最后一次执行时间
                /*if (task.Timetype == TaskTimeType.Day)
                {

                    task.LastExecuteTime = task.LastExecuteTime.AddDays(task.Interval);
                }
                else
                {

                    task.LastExecuteTime = DateTime.Now;
                }*/

                task.LastExecuteTime = DateTime.Now;
                TaskConfigs.Instance().Save(TaskConfigs.Instance().GetConfig());
            }
            catch (Exception ex)
            {
                //Log4Helper.Error(ex.Message);
            }
        }
    }
}
