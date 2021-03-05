using MediatR;
using Services.Models.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.Temp.RequestModels
{
    public class GetStudentsRequestModel : IRequest<IList<StudentResponseModel>>
    {
    }
}
