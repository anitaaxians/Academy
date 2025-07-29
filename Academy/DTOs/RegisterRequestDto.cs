using System.ComponentModel.DataAnnotations;

namespace Academy.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        public string Fullname { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
