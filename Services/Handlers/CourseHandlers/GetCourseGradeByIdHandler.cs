using Common.Log;
using Core.Entities;
using Core.Queries;
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
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQuery;

        public GetCourseGradeByIdHandler(
            ILogger<GetCourseGradeByIdHandler> logger,
            IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQuery)
        {
            _logger = logger;
            _getCourseByIdQuery = getCourseByIdQuery;
        }

        public async Task<CourseGradeResponseModel> Handle(GetCourseGradeByIdRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogResources.GettingItem, nameof(CourseGradeResponseModel), request.Id));
            Course course = await _getCourseByIdQuery.HandleAsync(new GetCourseByIdQuery(request.Id));
            CourseGradeResponseModel courseResponse = new CourseGradeResponseModel(course);
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogResources.GotItem, nameof(CourseGradeResponseModel)));

            return courseResponse;
        }
    }
}
