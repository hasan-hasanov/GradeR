using Common.Log;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.GetAllTeachers
{
    public class GetAllTeachersQueryHandler : IQueryHandler<GetAllTeachersQuery, IList<Teacher>>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public GetAllTeachersQueryHandler(ILogger<GetAllTeachersQueryHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Teacher>> HandleAsync(GetAllTeachersQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.ListingItems, string.Format(LogResources.ListingItems, nameof(Teacher)));
            List<Teacher> teachers = await _context.Teachers
                .Include(t => t.Courses)
                .ToListAsync(cancellationToken);
            _logger.LogInformation(LogEvents.ListedItems, string.Format(LogResources.ListedItems, teachers.Count, nameof(Teacher)));

            return teachers;
        }
    }
}
