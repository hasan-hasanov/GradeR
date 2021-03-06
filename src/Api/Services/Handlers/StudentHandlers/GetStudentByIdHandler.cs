using Common.Log;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetStudentById;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.StudentModels.RequestModels;
using Services.Models.StudentModels.ResponseModels;
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
            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogResources.ValidatingItem, nameof(GetStudentByIdRequestModel)));
            await _validator.Validate(request);
            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogResources.ValidatedItem, nameof(GetStudentByIdRequestModel)));

            Student student = await _getStudentByIdQueryHandler.HandleAsync(new GetStudentByIdQuery(request.Id));

            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogResources.AssemblingResponse, nameof(StudentResponseModel)));
            StudentResponseModel studentResponse = new StudentResponseModel(student);
            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogResources.AssembledResponse, nameof(StudentResponseModel)));

            return studentResponse;
        }
    }
}
