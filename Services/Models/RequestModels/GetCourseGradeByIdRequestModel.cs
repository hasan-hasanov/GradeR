using MediatR;
using Services.Models.ResponseModels;

namespace Services.Models.RequestModels
{
    public class GetCourseGradeByIdRequestModel : IRequest<CourseGradeResponseModel>
    {
        public GetCourseGradeByIdRequestModel(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
