using Common.Log;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IQueryHandler<GetAllCoursesQuery, IList<Course>>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public GetAllCoursesQueryHandler(ILogger<GetAllCoursesQueryHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Course>> HandleAsync(GetAllCoursesQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.ListingItems, string.Format(LogResources.ListingItems, nameof(Course)));
            List<Course> courses = await _context.Courses
                .Include(s => s.Students)
                .Include(t => t.Teachers)
                .ThenInclude(r => r.Teacher)
                .ThenInclude(r => r.Rank)
                .ToListAsync(cancellationToken);
            _logger.LogInformation(LogEvents.ListedItems, string.Format(LogResources.ListedItems, courses.Count, nameof(Course)));

            return courses;
        }
    }
}
