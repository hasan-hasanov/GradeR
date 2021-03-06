using Common.Log;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllCourses;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.CourseModels.RequestModels;
using Services.Models.CourseModels.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CourseHandlers
{
    public class GetCourseGradesHandler : IRequestHandler<GetCourseRequestModel, IList<CourseResponseModel>>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetAllCoursesQuery, IList<Course>> _getAllCoursesQueryHandler;

        public GetCourseGradesHandler(
            ILogger<GetCourseGradesHandler> logger,
            IQueryHandler<GetAllCoursesQuery, IList<Course>> getAllCoursesQueryHandler)
        {
            _logger = logger;
            _getAllCoursesQueryHandler = getAllCoursesQueryHandler;
        }

        public async Task<IList<CourseResponseModel>> Handle(GetCourseRequestModel request, CancellationToken cancellationToken)
        {
            IList<Course> studentGrades = await _getAllCoursesQueryHandler.HandleAsync(new GetAllCoursesQuery(), cancellationToken);

            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogResources.AssemblingResponse, nameof(IList<CourseResponseModel>)));
            IList<CourseResponseModel> studentGradesResponse = studentGrades.Select(s => new CourseResponseModel(s)).ToList();
            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogResources.AssembledResponse, nameof(IList<CourseResponseModel>)));

            return studentGradesResponse;
        }
    }
}
