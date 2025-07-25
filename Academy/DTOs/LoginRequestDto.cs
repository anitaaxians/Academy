using System.ComponentModel.DataAnnotations;

namespace Academy.DTOs
{
    public class LoginRequestDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
