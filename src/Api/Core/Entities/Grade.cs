namespace Core.Entities
{
    public class Grade
    {
        public long Id { get; set; }

        public short StudentGrade { get; set; }

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

        public Course Course { get; set; }
    }
}
