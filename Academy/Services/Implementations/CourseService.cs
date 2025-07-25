using Academy.Data;
using Academy.Data.Models;
using Academy.DTOs;
using Academy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CourseService : ICourseService
{
    private readonly AppDbContext _context;

    public CourseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync() =>
        await _context.Courses.ToListAsync();

    public async Task<Course> GetByIdAsync(Guid id) =>
        await _context.Courses.FindAsync(id);

    public async Task<Course> CreateAsync(CourseDto dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Description = dto.Description
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<Course> UpdateAsync(Guid id, CourseDto dto)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            throw new Exception("Course not found");
        }

        course.Title = dto.Title;
        course.Description = dto.Description;
        await _context.SaveChangesAsync();

        return course;
    }

    public async Task DeleteAsync(Guid id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            throw new Exception("Course not found");
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CourseDto>> GetMyCoursesAsync(Guid userId)
    {
        var enrollments = await _context.UserCourses
            .Where(e => e.UserId == userId)
            .Include(e => e.Course)
            .ToListAsync();

        return enrollments.Select(e => new CourseDto
        {
            Id = e.Course.Id,
            Title = e.Course.Title,
            Description = e.Course.Description
        }).ToList();
    }


    public async Task EnrollAsync(Guid userId, Guid courseId)
    {
        var exists = await _context.UserCourses
            .AnyAsync(uc => uc.UserId == userId && uc.CourseId == courseId);

        if (exists)
            throw new Exception("User is already enrolled in this course.");

        var userCourse = new UserCourse
        {
            UserId = userId,
            CourseId = courseId
        };

        _context.UserCourses.Add(userCourse);
        await _context.SaveChangesAsync();
    }

}
