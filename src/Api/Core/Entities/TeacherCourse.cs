namespace Core.Entities
{
    public class TeacherCourse
    {
        public int Id { get; set; }

        public long TeacherId { get; set; }

        public long CourseId { get; set; }

        public Teacher Teacher { get; set; }

        public Course Course { get; set; }
    }
}
