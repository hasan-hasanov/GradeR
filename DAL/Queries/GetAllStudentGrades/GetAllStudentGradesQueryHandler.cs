using Common.Log;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.GetAllStudentGrades
{
    public class GetAllStudentGradesQueryHandler : IQueryHandler<GetAllStudentGradesQuery, IList<Grade>>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public GetAllStudentGradesQueryHandler(ILogger<GetAllStudentGradesQueryHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Grade>> HandleAsync(GetAllStudentGradesQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.ListingItems, string.Format(LogResources.ListingItems, nameof(Grade)));
            List<Grade> grades = await _context.Grades
                .Include(s => s.Student)
                .Include(t => t.Teacher)
                .ToListAsync(cancellationToken);
            _logger.LogInformation(LogEvents.ListedItems, string.Format(LogResources.ListedItems, grades.Count, nameof(Grade)));

            return grades;
        }
    }
}
