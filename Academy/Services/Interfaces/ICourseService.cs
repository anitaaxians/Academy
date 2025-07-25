using Academy.Data.Models;
using Academy.DTOs;

namespace Academy.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetByIdAsync(Guid id);
        Task<Course> CreateAsync(CourseDto dto);
        Task<Course> UpdateAsync(Guid id, CourseDto dto);
        Task DeleteAsync(Guid id);
        Task EnrollAsync(Guid courseId, Guid userId);
        Task<List<CourseDto>> GetMyCoursesAsync(Guid userId);

    }
}
