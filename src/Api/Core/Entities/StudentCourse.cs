namespace Core.Entities
{
    public class StudentCourse
    {
        public int Id { get; set; }

        public long StudentId { get; set; }

        public long CourseId { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
