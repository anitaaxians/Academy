namespace Academy.Data.Models
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
