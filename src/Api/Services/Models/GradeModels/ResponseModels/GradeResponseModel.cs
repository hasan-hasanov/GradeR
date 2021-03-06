using Core.Entities;

namespace Services.Models.GradeModels.ResponseModels
{
    public class GradeResponseModel
    {
        public GradeResponseModel(Grade grade)
        {
            Id = grade.Id;
            Grade = grade.StudentGrade;
            Student = $"{grade.Student.FirstName} {grade.Student.LastName}";
            Teacher = $"{grade.Teacher.FirstName} {grade.Teacher.LastName}";
            Course = new GradeCourseResponseModel(grade.Course);
        }

        public long Id { get; set; }

        public short Grade { get; set; }

        public string Student { get; set; }

        public string Teacher { get; set; }

        public GradeCourseResponseModel Course { get; set; }
    }
}
