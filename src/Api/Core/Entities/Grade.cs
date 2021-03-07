namespace Core.Entities
{
    public class Grade
    {
        public long Id { get; set; }

        public short StudentGrade { get; set; }

        public long StudentId { get; set; }

        public long TeacherId { get; set; }

        public long CourseId { get; set; }

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

        public Course Course { get; set; }
    }
}
