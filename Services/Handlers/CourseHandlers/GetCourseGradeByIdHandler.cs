using Common.Log;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetCourseById;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CourseHandlers
{
    public class GetCourseGradeByIdHandler : IRequestHandler<GetCourseGradeByIdRequestModel, CourseGradeResponseModel>
    {
        private readonly ILogger _logger;
        private readonly IValidation<GetCourseGradeByIdRequestModel> _validator;
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQuery;

        public GetCourseGradeByIdHandler(
            ILogger<GetCourseGradeByIdHandler> logger,
            IValidation<GetCourseGradeByIdRequestModel> validator,
            IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQuery)
        {
            _logger = logger;
            _validator = validator;
            _getCourseByIdQuery = getCourseByIdQuery;
        }

        public async Task<CourseGradeResponseModel> Handle(GetCourseGradeByIdRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogResources.ValidatingItem, nameof(GetCourseGradeByIdRequestModel)));
            await _validator.Validate(request, cancellationToken);
            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogResources.ValidatedItem, nameof(GetCourseGradeByIdRequestModel)));

            Course course = await _getCourseByIdQuery.HandleAsync(new GetCourseByIdQuery(request.Id), cancellationToken);

            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogResources.AssemblingResponse, nameof(CourseGradeResponseModel)));
            CourseGradeResponseModel courseResponse = new CourseGradeResponseModel(course);
            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogResources.AssembledResponse, nameof(CourseGradeResponseModel)));

            return courseResponse;
        }
    }
}
