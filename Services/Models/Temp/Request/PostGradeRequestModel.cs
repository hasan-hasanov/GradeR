using MediatR;

namespace Services.Models.RequestModels
{
    public class PostGradeRequestModel : IRequest
    {
        public long TeacherId { get; set; }

        public long StudentId { get; set; }

        public long CourseId { get; set; }

        public short Grade { get; set; }
    }
}
