using System.ComponentModel.DataAnnotations;

namespace task1.NewFolder
{
    public class UserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        public List<TaskDto> Tasks { get; set; } = new List<TaskDto>();
        public int Id { get; internal set; }
    }
}
