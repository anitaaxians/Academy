using Academy.DTOs;
using Academy.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Academy.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseService.GetAllCoursesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllById(Guid id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCourse(CourseDto dto)
        {
            var course = await _courseService.CreateAsync(dto);

            return Ok(course);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateCourse(Guid id, CourseDto dto)
        {
            var course = await _courseService.UpdateAsync(id, dto);
            return Ok(course);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            await _courseService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("my-courses")]
        [Authorize]
        public async Task<IActionResult> GetMyCourses()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized("User ID not found in token");

            Guid userId = Guid.Parse(userIdClaim.Value);

            var courses = await _courseService.GetMyCoursesAsync(userId); 

            return Ok(courses);
        }


        [HttpPost("enroll")]
        [Authorize]
        public async Task<IActionResult> Enroll([FromBody] EnrollRequestDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User ID not found in token");

            var userId = Guid.Parse(userIdClaim.Value);

            await _courseService.EnrollAsync(dto.CourseId, userId);

            return Ok(new { message = "User enrolled successfully!" });
        }

    }
}
