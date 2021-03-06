using MediatR;
using Services.Models.CourseModels.ResponseModels;

namespace Services.Models.CourseModels.RequestModels
{
    public class GetCourseByIdRequestModel : IRequest<CourseResponseModel>
    {
        public GetCourseByIdRequestModel(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
