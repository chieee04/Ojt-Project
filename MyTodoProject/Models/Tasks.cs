namespace MyTodoProject.Models
{
    public class Tasks
    {
        public int taskID { get; set; }
        public int userID { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
    }
}
