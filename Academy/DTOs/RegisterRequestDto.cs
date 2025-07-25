using System.ComponentModel.DataAnnotations;

namespace Academy.DTOs
{
    public class RegisterRequestDto
    {
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
    }
}
