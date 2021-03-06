namespace Core.Entities
{
    public class TeacherCourse
    {
        public int Id { get; set; }

        public Teacher Teacher { get; set; }

        public Course Course { get; set; }
    }
}
