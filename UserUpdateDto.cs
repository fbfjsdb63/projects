using System.ComponentModel.DataAnnotations;

namespace task1.DTOs
{
    public class UserUpdateDto
    {
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        public string TaskTitle { get; set; } = string.Empty;
        public string TaskDescription { get; set; } = string.Empty;
        public int TaskStatus { get; set; }

    }
}
