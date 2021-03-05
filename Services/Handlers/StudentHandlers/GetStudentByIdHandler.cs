using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetStudentById;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.StudentHandlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdRequestModel, StudentResponseModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<GetStudentByIdRequestModel> _validator;
        private readonly IQueryHandler<GetStudentByIdQuery, Student> _getStudentByIdQueryHandler;

        public GetStudentByIdHandler(
            ILogger<GetStudentByIdHandler> logger,
            IValidation<GetStudentByIdRequestModel> validator,
            IQueryHandler<GetStudentByIdQuery, Student> getStudentByIdQueryHandler)
        {
            _logger = logger;
            _validator = validator;
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        }

        public async Task<StudentResponseModel> Handle(GetStudentByIdRequestModel request, CancellationToken cancellationToken)
        {
            await _validator.Validate(request);

            Student student = await _getStudentByIdQueryHandler.HandleAsync(new GetStudentByIdQuery(request.Id));
            StudentResponseModel studentResponse = new StudentResponseModel(student);

            return studentResponse;
        }
    }
}
