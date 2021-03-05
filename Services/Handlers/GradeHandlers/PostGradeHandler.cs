using Core.Commands;
using Core.Entities;
using Core.Queries;
using DAL.Commands.EvaluateStudent;
using DAL.Queries.GetCourseById;
using DAL.Queries.GetStudentById;
using DAL.Queries.GetTeacherById;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.GradeHandlers
{
    public class PostGradeHandler : AsyncRequestHandler<PostGradeRequestModel>
    {
        private readonly ILogger _logger;
        private readonly ICommandHandler<EvaluateStudentCommand> _evaluateStudentCommandHandler;
        private readonly IQueryHandler<GetStudentByIdQuery, Student> _getStudentByIdQueryHandler;
        private readonly IQueryHandler<GetTeacherByIdQuery, Teacher> _getTeacherByIdQueryHandler;
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQueryHandler;

        public PostGradeHandler(
            ILogger<PostGradeHandler> logger,
            ICommandHandler<EvaluateStudentCommand> evaluateStudentCommandHandler,
            IQueryHandler<GetStudentByIdQuery, Student> getStudentByIdQueryHandler,
            IQueryHandler<GetTeacherByIdQuery, Teacher> getTeacherByIdQueryHandler,
            IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQueryHandler)
        {
            _logger = logger;
            _evaluateStudentCommandHandler = evaluateStudentCommandHandler;
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            _getTeacherByIdQueryHandler = getTeacherByIdQueryHandler;
            _getCourseByIdQueryHandler = getCourseByIdQueryHandler;
        }

        protected override async Task Handle(PostGradeRequestModel request, CancellationToken cancellationToken)
        {
            // TODO: Add validation

            Student student = await _getStudentByIdQueryHandler.HandleAsync(new GetStudentByIdQuery(request.StudentId));
            Teacher teacher = await _getTeacherByIdQueryHandler.HandleAsync(new GetTeacherByIdQuery(request.TeacherId));
            Course course = await _getCourseByIdQueryHandler.HandleAsync(new GetCourseByIdQuery(request.CourseId));

            await _evaluateStudentCommandHandler.HandleAsync(new EvaluateStudentCommand(request.Grade, student, teacher, course));
        }
    }
}
