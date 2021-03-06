using MediatR;
using Services.Models.GradeModels.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.GradeModels.RequestModels
{
    public class GetAllGradesRequestModel : IRequest<IList<GradeResponseModel>>
    {
    }
}
