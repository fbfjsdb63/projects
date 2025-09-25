namespace task1.model
{
    public class user
    {

        public int Id { get; set; }           // مفتاح أساسي
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";

        // Navigation property
        public List<TaskItem> Tasks { get; set; } = new();




    }
}
