using Common.Exceptions;
using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetStudentById;
using Microsoft.Extensions.Logging;
using Services.Models.StudentModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class GetStudentByIdRequestModelValidator : IValidation<GetStudentByIdRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetStudentByIdQuery, Student> _getStudentByIdQueryHandler;

        public GetStudentByIdRequestModelValidator(
            ILogger<GetStudentByIdRequestModelValidator> logger,
            IQueryHandler<GetStudentByIdQuery, Student> getStudentByIdQueryHandler)
        {
            _logger = logger;
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        }

        public async Task Validate(GetStudentByIdRequestModel model, CancellationToken cancellationToken = default)
        {
            List<string> errorMessages = new List<string>();

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.Id)));
            Student student = await _getStudentByIdQueryHandler.HandleAsync(new GetStudentByIdQuery(model.Id), cancellationToken);
            if (student == null)
            {
                string message = $"{nameof(Student)} with id {model.Id} not found";
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.Id), message));
                errorMessages.Add(message);
            }

            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.Id)));

            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(GetStudentByIdRequestModel), message));
                throw new NotFoundException(message);
            }
        }
    }
}
