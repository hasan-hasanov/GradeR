using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetCourseById;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.CourseModels.RequestModels;
using Services.Models.CourseModels.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CourseHandlers
{
    public class GetCourseGradeByIdHandler : IRequestHandler<GetCourseByIdRequestModel, CourseResponseModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<GetCourseByIdRequestModel> _validator;
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQuery;

        public GetCourseGradeByIdHandler(
            ILogger<GetCourseGradeByIdHandler> logger,
            IValidation<GetCourseByIdRequestModel> validator,
            IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQuery)
        {
            _logger = logger;
            _validator = validator;
            _getCourseByIdQuery = getCourseByIdQuery;
        }

        public async Task<CourseResponseModel> Handle(GetCourseByIdRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(GetCourseByIdRequestModel)));
            await _validator.Validate(request, cancellationToken);
            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(GetCourseByIdRequestModel)));

            Course course = await _getCourseByIdQuery.HandleAsync(new GetCourseByIdQuery(request.Id), cancellationToken);

            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(CourseResponseModel)));
            CourseResponseModel courseResponse = new CourseResponseModel(course);
            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssembledResponse, nameof(CourseResponseModel)));

            return courseResponse;
        }
    }
}
