namespace Services.Models.ResponseModels
{
    public class GradeResponseModel
    {
        public int Id { get; set; }

        public short Grade { get; set; }

        public TeacherResponseModel Teacher { get; set; }
    }
}
