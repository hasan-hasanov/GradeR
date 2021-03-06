using Common.Log;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllCourses;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CourseHandlers
{
    public class GetCourseGradesHandler : IRequestHandler<GetCourseGradesRequestModel, IList<CourseGradeResponseModel>>
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

        public async Task<IList<CourseGradeResponseModel>> Handle(GetCourseGradesRequestModel request, CancellationToken cancellationToken)
        {
            IList<Course> studentGrades = await _getAllCoursesQueryHandler.HandleAsync(new GetAllCoursesQuery(), cancellationToken);

            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogResources.AssemblingResponse, nameof(IList<CourseGradeResponseModel>)));
            IList<CourseGradeResponseModel> studentGradesResponse = studentGrades.Select(s => new CourseGradeResponseModel(s)).ToList();
            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogResources.AssembledResponse, nameof(IList<CourseGradeResponseModel>)));

            return studentGradesResponse;
        }
    }
}
