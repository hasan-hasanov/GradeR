using Core.Command;
using Core.Entities;

namespace DAL.Commands.EvaluateStudent
{
    public class EvaluateStudentCommand : ICommand
    {
        public EvaluateStudentCommand(short grade, Student student, Teacher teacher)
        {
            Grade = grade;
            Student = student;
            Teacher = teacher;
        }

        public short Grade { get; }

        public Student Student { get; }

        public Teacher Teacher { get; }
    }
}
