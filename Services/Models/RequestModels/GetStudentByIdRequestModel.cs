using MediatR;
using Services.Models.ResponseModels;

namespace Services.Models.RequestModels
{
    public class GetStudentByIdRequestModel : IRequest<StudentResponseModel>
    {
        public int Id { get; set; }
    }
}
