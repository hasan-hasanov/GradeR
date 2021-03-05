using MediatR;
using Services.Models.ResponseModels;

namespace Services.Models.RequestModels
{
    public class GetStudentByIdRequestModel : IRequest<StudentResponseModel>
    {
        public GetStudentByIdRequestModel(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
