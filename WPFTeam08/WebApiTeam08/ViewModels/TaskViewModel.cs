namespace WebApiTeam08.ViewModels
{
    public class TaskViewModel
    {
        int _groupID;
        int _taskId;
        string _taskName;
        string _taskDescription;
        int _taskStatus;
        string _taskType;
        string _deadLine;
        string _reminder;
        string _assigned;


        public int GroupID { get => _groupID; set => _groupID = value; }
        public string TaskName { get => _taskName; set => _taskName = value; }
        public string TaskDescription { get => _taskDescription; set => _taskDescription = value; }
        public int TaskStatus { get => _taskStatus; set => _taskStatus = value; }
        public string TaskType { get => _taskType; set => _taskType = value; }
        public string DeadLine { get => _deadLine; set => _deadLine = value; }
        public string Reminder { get => _reminder; set => _reminder = value; }
        public string Assigned { get => _assigned; set => _assigned = value; }
        public int TaskId { get => _taskId; set => _taskId = value; }
    }
}
