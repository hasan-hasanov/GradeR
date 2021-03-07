using Common.LogResources;
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
            _logger.LogInformation(LogEvents.GettingItem, string.Format(LogMessageResources.GettingItem, nameof(Teacher), query.Id));
            Teacher teacher = await _context.Teachers
                .FirstOrDefaultAsync(t => t.Id == query.Id, cancellationToken);

            if (teacher == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, string.Format(LogMessageResources.GetItemNotFound, nameof(Teacher), query.Id));
            }

            _logger.LogInformation(LogEvents.GotItem, string.Format(LogMessageResources.GotItem, nameof(Teacher)));
            return teacher;
        }
    }
}
