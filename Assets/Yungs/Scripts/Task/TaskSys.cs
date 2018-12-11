using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yungs.D305
{
    public class TaskSys
    {
        public TaskSys()
        {
            taskItems = new List<TaskItem>();
        }

        private List<TaskItem> taskItems;

        /// <summary>
        /// 接受任务
        /// </summary>
        /// <param name="taskItem"></param>
        /// <returns></returns>
        public YungsResult Accept(TaskItem taskItem)
        {
            var log = new YungsResult();
            if (!Contain(taskItem.ID))
            {
                taskItems.Add(taskItem);
                log = new YungsResult(0,"接受任务成功");
            }
            else
            {
                log = new YungsResult(1, "你已经领取该任务了");
            }
            return log;
        }

        /// <summary>
        /// 是否已经接受了此任务
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns></returns>
        bool Contain(string taskID)
        {
            for (int i = 0; i < taskItems.Count; i++)
            {
                if (taskItems[i].ID.Trim().Equals(taskID.Trim()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}