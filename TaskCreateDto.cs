using System.ComponentModel.DataAnnotations;

namespace task1.DTOs
{
    public class TaskCreateDto
    {

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;

        public int Status { get; set; } = 0; // default
    }
}
