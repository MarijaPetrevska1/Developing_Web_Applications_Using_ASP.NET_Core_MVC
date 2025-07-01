using Homework2.Models.DtoModel;
using Homework2.Models.ViewModels;
using Homework2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("[Controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        //[HttpGet("getAllStudents")]
        public IActionResult GetAllStudents()
        {
            List<StudentWithCourseDto> students = _studentService.GetAllStudents();

            return View(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            StudentWithCourseDto student = _studentService.GetStudentById(id);

            if (student == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(student);
        }

        [HttpGet("createStudent")]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost("createStudent")]
        public IActionResult CreateStudent(CreateStudentVM createStudentVM)
        {
            _studentService.CreateStudent(createStudentVM);
            return RedirectToAction("GetAllStudents");
        }
    }
}
