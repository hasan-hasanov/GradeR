using Common.Log;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.GetTeacherById
{
    public class GetTeacherByIdQueryHandler : IQueryHandler<GetTeacherByIdQuery, Teacher>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public GetTeacherByIdQueryHandler(ILogger<GetTeacherByIdQueryHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Teacher> HandleAsync(GetTeacherByIdQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogResources.GettingItem, nameof(Teacher), query.Id));
            Teacher teacher = await _context.Teachers
                .Include(c => c.Courses)
                .FirstOrDefaultAsync(t => t.Id == query.Id, cancellationToken);

            if (teacher == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogResources.GetItemNotFound, nameof(Teacher), query.Id));

                // TODO: Handle ungracefull exit
            }

            _logger.LogInformation(LogEvents.GotItem, string.Format(LogResources.GotItem, nameof(Teacher)));
            return teacher;
        }
    }
}
