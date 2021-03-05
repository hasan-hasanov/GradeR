using Core.Entities;

namespace Services.Models.ResponseModels
{
    public class GradeResponseModel
    {
        public GradeResponseModel(Grade grade)
        {
            Id = grade.Id;
            Grade = grade.StudentGrade;
            Teacher = new TeacherResponseModel(grade.Teacher);
        }

        public long Id { get; set; }

        public short Grade { get; set; }

        public TeacherResponseModel Teacher { get; set; }
    }
}
