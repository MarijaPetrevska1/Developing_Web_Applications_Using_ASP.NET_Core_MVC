namespace Homework3.Models.ViewModels
{
    public class EditStudentVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ActiveCourseId { get; set; }
        public List<CourseOptionVM> Courses { get; set; }
    }
}

