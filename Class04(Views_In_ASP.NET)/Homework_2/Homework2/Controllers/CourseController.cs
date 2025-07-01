using Homework2.Models.DtoModel;
using Homework2.Models.ViewModels;
using Homework2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController()
        {
            _courseService = new CourseService();
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
                return RedirectToAction("Error", "Home");

            return View(course);
        }

        [HttpGet("createCourse")]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost("createCourse")]
        public IActionResult CreateCourse(CreateCourseVM vm)
        {
            _courseService.CreateCourse(vm);
            return RedirectToAction("GetAllCourses");
        }
    }
}
