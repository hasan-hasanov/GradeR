using MediatR;
using Services.Models.StudentModels.ResponseModels;

namespace Services.Models.StudentModels.RequestModels
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
