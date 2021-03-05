using MediatR;
using Services.Models.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.RequestModels
{
    public class GetStudentsRequestModel : IRequest<IList<StudentResponseModel>>
    {
    }
}
