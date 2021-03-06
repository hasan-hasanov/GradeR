using Core.Entities;

namespace Services.Models.StudentModels.ResponseModels
{
    public class StudentGradeResponseModel
    {
        public StudentGradeResponseModel(Grade grade)
        {
            Id = grade.Id;
            Grade = grade.StudentGrade;
            Teacher = $"{grade.Teacher.FirstName} {grade.Teacher.LastName}";
            Course = grade?.Course?.Name;
        }

        public long Id { get; set; }

        public short Grade { get; set; }

        public string Teacher { get; set; }

        public string Course { get; set; }
    }
}
