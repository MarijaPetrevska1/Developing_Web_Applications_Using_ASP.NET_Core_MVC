using Homework2.Database;
using Homework2.Models.DtoModel;
using Homework2.Models.Entities;
using Homework2.Models.ViewModels;

namespace Homework2.Services
{
    public class CourseService
    {
        public List<CourseWithDetailsDto> GetAllCourses()
        {
            return InMemoryDb.Courses
                .Select(c => new CourseWithDetailsDto(c.Id, c.Name, c.NumberOfClasses))
                .ToList();
        }

        public CourseWithDetailsDto GetCourseById(int id)
        {
            Course course = InMemoryDb.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null) return null;

            return new CourseWithDetailsDto(course.Id, course.Name, course.NumberOfClasses);
        }

        public void CreateCourse(CreateCourseVM vm)
        {
            Course course = new Course
            {
                Id = InMemoryDb.Courses.Count + 1,
                Name = vm.Name,
                NumberOfClasses = vm.NumberOfClasses
            };

            InMemoryDb.Courses.Add(course);
        }
    }
}
