using System.ComponentModel.DataAnnotations;

namespace task1.NewFolder
{
    public class TaskDto
    {
         public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Range(0, 2, ErrorMessage = "Status must be between 0 and 2")]
        public int Status { get; set; }

    }
}
