using MediatR;
using Services.Models.CourseModels.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.CourseModels.RequestModels
{
    public class GetCourseRequestModel : IRequest<IList<CourseResponseModel>>
    {
    }
}
