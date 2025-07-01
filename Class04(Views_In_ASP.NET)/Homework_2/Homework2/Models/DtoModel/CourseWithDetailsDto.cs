namespace Homework2.Models.DtoModel
{
    public class CourseWithDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfClasses { get; set; }

        public CourseWithDetailsDto(int id, string name, int numberOfClasses)
        {
            Id = id;
            Name = name;
            NumberOfClasses = numberOfClasses;
        }
    }
}
