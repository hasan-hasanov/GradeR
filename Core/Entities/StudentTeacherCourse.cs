namespace Core.Entities
{
    public class StudentTeacherCourse
    {
        public int Id { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }

        public Teacher Teacher { get; set; }
    }
}
