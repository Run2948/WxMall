using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service.Task
{
    /// <summary>
    /// 任务执行接口
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// 执行任务的方法
        /// </summary>
        /// <param name="state"></param>
        void Execute(object state);
    }
}
