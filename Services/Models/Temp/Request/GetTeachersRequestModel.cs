using MediatR;
using Services.Models.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.Temp.RequestModels
{
    public class GetTeachersRequestModel : IRequest<IList<TeacherResponseModel>>
    {
    }
}
