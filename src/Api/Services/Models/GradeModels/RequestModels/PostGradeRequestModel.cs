using MediatR;

namespace Services.Models.GradeModels.RequestModels
{
    public class PostGradeRequestModel : IRequest
    {
        public long TeacherId { get; set; }

        public long StudentId { get; set; }

        public long CourseId { get; set; }

        public short Grade { get; set; }
    }
}
