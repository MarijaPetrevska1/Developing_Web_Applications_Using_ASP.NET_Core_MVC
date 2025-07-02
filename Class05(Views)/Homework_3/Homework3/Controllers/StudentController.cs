using Homework3.Database;
using Homework3.Models.Entites;
using Homework3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Homework3.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult GetAllStudents()
        {
            List<StudentVM> students = InMemoryDb.Students.Select(x => new StudentVM
            {
                Id = x.Id,
                FullName = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Year - x.DateOfBirth.Year,
                ActiveCourseName = x.ActiveCourse.Name
            }).ToList();
            return View(students);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            CreateStudentVM createStudentVM = new();
            createStudentVM.Courses = InMemoryDb.Courses.Select(x => new CourseOptionVM
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return View(createStudentVM);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentVM createStudentVM)
        {
            Student student = new Student
            {
                Id = InMemoryDb.Students.Count + 1,
                FirstName = createStudentVM.FirstName,
                LastName = createStudentVM.LastName,
                DateOfBirth = createStudentVM.DateOfBirth,
                ActiveCourse = InMemoryDb.Courses.FirstOrDefault(x => x.Id == createStudentVM.ActiveCourseId)
            };

            InMemoryDb.Students.Add(student);
            return RedirectToAction("GetAllStudents");
        }

        [HttpGet("{id}")]

        public IActionResult Details(int id)
        {
            Student student = InMemoryDb.Students.SingleOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            StudentVM studentVM = new StudentVM
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                ActiveCourseName = student.ActiveCourse.Name

            };

            return View(studentVM);
        }

        [HttpGet("edit/{id}")]

        public IActionResult Edit(int id)
        {
            Student student = InMemoryDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            EditStudentVM vm = new EditStudentVM
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                ActiveCourseId = student.ActiveCourse.Id,
                Courses = InMemoryDb.Courses.Select(c => new CourseOptionVM
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            };

            return View("Edit", vm); 
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, EditStudentVM model)
        {
            Student student = InMemoryDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.DateOfBirth = model.DateOfBirth;
            student.ActiveCourse = InMemoryDb.Courses.FirstOrDefault(c => c.Id == model.ActiveCourseId);

            return RedirectToAction("GetAllStudents");
        }

    }
}
