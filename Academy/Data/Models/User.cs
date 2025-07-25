namespace Academy.Data.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }
        public string Role { get; set; } = "Student";

        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
