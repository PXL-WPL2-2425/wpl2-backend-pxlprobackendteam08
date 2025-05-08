using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Business.Entities
{
    public class Task
    {
        private int _taskId;
        private int _groupId;
        private string _taskName;
        private string _taskDescription;
        private int _taskStatus;
        private string _taskType;

        public int TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public string TaskName 
        { 
            get { return _taskName; } 
            set { _taskName = value; } 
        }

        public string TaskDescription
        {
            get { return _taskDescription; }
            set { _taskDescription = value; }
        }

        public int TaskStatus
        {
            get { return _taskStatus; }
            set { _taskStatus = value; }
        }

        public string TaskType
        {
            get { return _taskType; }
            set { _taskType = value; }
        }

        public Task(int taskId, int groupId, string taskName, string taskDescription, int taskStatus, string taskType)
        {
            TaskId = taskId;
            GroupId = groupId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStatus = taskStatus;
            TaskType = taskType;
        }

        public override string ToString()
        {
            return $"{TaskId} - {TaskName} - {TaskStatus}";
        }
    }
}
