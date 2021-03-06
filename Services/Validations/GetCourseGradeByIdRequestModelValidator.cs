using Common.Exceptions;
using Common.Log;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetCourseById;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class GetCourseGradeByIdRequestModelValidator : IValidation<GetCourseGradeByIdRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQuery;

        public GetCourseGradeByIdRequestModelValidator(
            ILogger<GetCourseGradeByIdRequestModelValidator> logger,
            IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQuery)
        {
            _logger = logger;
            _getCourseByIdQuery = getCourseByIdQuery;
        }

        public async Task Validate(GetCourseGradeByIdRequestModel model, CancellationToken cancellationToken = default)
        {
            List<string> errorMessages = new List<string>();

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogResources.ValidatingItem, nameof(model.Id)));
            Course course = await _getCourseByIdQuery.HandleAsync(new GetCourseByIdQuery(model.Id), cancellationToken);
            if (course == null)
            {
                string message = $"{nameof(Course)} with id {model.Id} not found";
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogResources.ValidationFailed, nameof(model.Id), message));
                errorMessages.Add(message);
            }

            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogResources.ValidatedItem, nameof(model.Id)));

            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogResources.ValidationFailed, nameof(GetCourseGradeByIdRequestModel), message));
                throw new NotFoundException(message);
            }
        }
    }
}
