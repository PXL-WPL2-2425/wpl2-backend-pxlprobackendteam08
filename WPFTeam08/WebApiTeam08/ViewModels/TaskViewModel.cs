namespace WebApiTeam08.ViewModels
{
    public class TaskViewModel
    {
        int _groupid;
        string _taskname;
        string _taskdescription;
        int _taskstatus;
        string _tasktype;

        public int Groupid { get => _groupid; set => _groupid = value; }
        public string Taskname { get => _taskname; set => _taskname = value; }
        public string Taskdescription { get => _taskdescription; set => _taskdescription = value; }
        public int Taskstatus { get => _taskstatus; set => _taskstatus = value; }
        public string Tasktype { get => _tasktype; set => _tasktype = value; }
    }
}
