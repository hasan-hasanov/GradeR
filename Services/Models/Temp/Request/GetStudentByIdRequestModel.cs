using MediatR;
using Services.Models.ResponseModels;

namespace Services.Models.Temp.RequestModels
{
    public class GetStudentByIdRequestModel : IRequest<StudentResponseModel>
    {
        public int Id { get; set; }
    }
}
