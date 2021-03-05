using MediatR;
using Services.Models.ResponseModels;

namespace Services.Models.RequestModels
{
    public class GetTeacherByIdRequestModel : IRequest<TeacherResponseModel>
    {
    }
}
