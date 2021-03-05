using Common.Log;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IQueryHandler<GetAllStudentsQuery, IList<Student>>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public GetAllStudentsQueryHandler(ILogger<GetAllStudentsQueryHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Student>> HandleAsync(GetAllStudentsQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.ListingItems, string.Format(LogResources.ListingItems, nameof(Student)));
            List<Student> students = await _context.Students
                .Include(g => g.Grades)
                .ThenInclude(t => t.Teacher)
                .Include(g => g.Grades)
                .ThenInclude(c => c.Course)
                .ToListAsync(cancellationToken);
            _logger.LogInformation(LogEvents.ListedItems, string.Format(LogResources.ListedItems, students.Count, nameof(Student)));

            return students;
        }
    }
}
