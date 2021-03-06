using Core.Commands;
using Core.Entities;

namespace DAL.Commands.EvaluateStudent
{
    public class EvaluateStudentCommand : ICommand
    {
        public EvaluateStudentCommand(
            short grade,
            Student student,
            Teacher teacher,
            Course course)
        {
            Grade = grade;
            Student = student;
            Teacher = teacher;
            Course = course;
        }

        public short Grade { get; }

        public Student Student { get; }

        public Teacher Teacher { get; }

        public Course Course { get; }
    }
}
