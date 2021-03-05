using Common.Log;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, Student>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public GetStudentByIdQueryHandler(ILogger<GetStudentByIdQueryHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Student> HandleAsync(GetStudentByIdQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogResources.GettingItem, nameof(Student), query.Id));
            Student student = await _context.Students
                .Include(g => g.Grades)
                .ThenInclude(t => t.Teacher)
                .Include(g => g.Grades)
                .ThenInclude(c => c.Course)
                .FirstOrDefaultAsync(s => s.Id == query.Id, cancellationToken);

            if (student == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogResources.GetItemNotFound, nameof(Student), query.Id));
            }

            _logger.LogInformation(LogEvents.GotItem, string.Format(LogResources.GotItem, nameof(Student)));
            return student;
        }
    }
}
