using Common.LogResources;
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
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogMessageResources.GettingItem, nameof(Course), query.Id));
            Course course = await _context.Courses
                .Include(s => s.Students)
                .Include(t => t.Teachers)
                .ThenInclude(r => r.Teacher)
                .ThenInclude(r => r.Rank)
                .FirstOrDefaultAsync(s => s.Id == query.Id, cancellationToken);

            if (course == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogMessageResources.GetItemNotFound, nameof(Course), query.Id));
            }

            _logger.LogInformation(LogEvents.GotItem, string.Format(LogMessageResources.GotItem, nameof(Course)));
            return course;
        }
    }
}
