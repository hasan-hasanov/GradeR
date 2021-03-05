using MediatR;
using Services.Models.ResponseModels;

namespace Services.Models.Temp.RequestModels
{
    public class GetTeacherByIdRequestModel : IRequest<TeacherResponseModel>
    {
    }
}
