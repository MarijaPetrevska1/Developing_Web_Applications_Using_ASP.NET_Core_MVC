using Homework1.Models.Entities;
using Homework1.Models.DtoModels;
using Homework1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        // => Constructor initializes the course service
        public CourseController()
        {
            _courseService = new CourseService();
        }

        // GET: /courses/getAllCourses 
        // =>  It returns a list of course names only 
        [HttpGet("getAllCourses")]
        public IActionResult GetAllCourses()
        {
            List<ListAllCoursesDto> courses = _courseService.GetAllCourses();
            return Json(courses);
        }

        // GET: /courses/{id}
        // =>  Returns full course data (Id, Name, NumberOfClasses) by ID
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id) 
        {
            CourseDto course = _courseService.GetCourseById(id);

            if (course == null) return Content("Course not found");

            return Json(course);
        }
    }
}
