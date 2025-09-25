namespace task1.model
{


    public enum TaskStatus
    {
        Todo,
        InProgress,
        Done
    }
    public class TaskItem
    {

        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Todo;
        public int UserId { get; set; }
        public user? User { get; set; }
    }




}

