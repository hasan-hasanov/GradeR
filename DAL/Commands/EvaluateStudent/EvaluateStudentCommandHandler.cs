using Common.Log;
using Core.Commands;
using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Commands.EvaluateStudent
{
    public class EvaluateStudentCommandHandler : ICommandHandler<EvaluateStudentCommand>
    {
        private readonly ILogger _logger;
        private readonly GradeRContext _context;

        public EvaluateStudentCommandHandler(ILogger<EvaluateStudentCommandHandler> logger, GradeRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Handle(EvaluateStudentCommand command, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(LogEvents.InsertingItem, string.Format(LogResources.InsertingItem, nameof(Grade)));
            Grade grade = new Grade()
            {
                Student = command.Student,
                Teacher = command.Teacher,
                StudentGrade = command.Grade,
            };

            await _context.AddAsync(grade, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LogEvents.InsertedItem, string.Format(LogResources.InsertedItem, nameof(Grade)));
        }
    }
}
