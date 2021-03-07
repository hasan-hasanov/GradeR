using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.GetAllGrades
{
    public class GetAllGradesQueryHandler : IQueryHandler<GetAllGradesQuery, IList<Grade>>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public GetAllGradesQueryHandler(ILogger<GetAllGradesQueryHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Grade>> HandleAsync(GetAllGradesQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.ListingItems, string.Format(LogMessageResources.ListingItems, nameof(Grade)));
            List<Grade> grades = await _context.Grades
                .Include(t => t.Teacher)
                .ThenInclude(r => r.Rank)
                .Include(s => s.Student)
                .Include(c => c.Course)
                .ToListAsync(cancellationToken);
            _logger.LogInformation(LogEvents.ListedItems, string.Format(LogMessageResources.ListedItems, grades.Count, nameof(Grade)));

            return grades;
        }
    }
}
