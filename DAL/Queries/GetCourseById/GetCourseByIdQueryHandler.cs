using Common.Log;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IQueryHandler<GetCourseByIdQuery, Course>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public GetCourseByIdQueryHandler(ILogger<GetCourseByIdQueryHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Course> HandleAsync(GetCourseByIdQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogResources.GettingItem, nameof(Course), query.Id));
            Course course = await _context.Courses
                .Include(g => g.Grades)
                .ThenInclude(g => g.Student)
                .Include(g => g.Grades)
                .ThenInclude(s => s.Teacher)
                .FirstOrDefaultAsync(s => s.Id == query.Id, cancellationToken);

            if (course == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogResources.GetItemNotFound, nameof(Course), query.Id));

                // TODO: Handle ungracefull exit here.
            }

            _logger.LogInformation(LogEvents.GotItem, string.Format(LogResources.GotItem, nameof(Course)));
            return course;
        }
    }
}
