using MediatR;
using Services.Models.StudentModels.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.StudentModels.RequestModels
{
    public class GetStudentsRequestModel : IRequest<IList<StudentResponseModel>>
    {
    }
}
