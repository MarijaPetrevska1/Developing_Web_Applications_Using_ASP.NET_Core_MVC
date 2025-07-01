using Homework1.Database;
using Homework1.Models.DtoModels;
using Homework1.Models.Entities;

namespace Homework1.Services
{
    // This is the Service class that handles Business Logic related to Courses
    public class CourseService
    {
        // => Returns a list of All course names using DTO
        public List<ListAllCoursesDto> GetAllCourses()
        {
            return InMemoryDb.Courses.Select(c => new ListAllCoursesDto
            {
                Name = c.Name
            }).ToList();
        }

        // => Returns a full course DTO by its ID, or null if not found
        public CourseDto GetCourseById(int id)
        {
            Course course = InMemoryDb.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null) return null;

            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                NumberOfClasses = course.NumberOfClasses
            };
        }
    }
}
