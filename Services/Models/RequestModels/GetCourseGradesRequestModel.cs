using MediatR;
using Services.Models.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.RequestModels
{
    public class GetCourseGradesRequestModel : IRequest<IList<CourseGradeResponseModel>>
    {
    }
}
