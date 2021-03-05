using Core.Commands;
using Core.Entities;
using Core.Queries;
using Core.Validation;
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
        private readonly IValidation<PostGradeRequestModel> _validator;
        private readonly ICommandHandler<EvaluateStudentCommand> _evaluateStudentCommandHandler;
        private readonly IQueryHandler<GetStudentByIdQuery, Student> _getStudentByIdQueryHandler;
        private readonly IQueryHandler<GetTeacherByIdQuery, Teacher> _getTeacherByIdQueryHandler;
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQueryHandler;

        public PostGradeHandler(
            ILogger<PostGradeHandler> logger,
            IValidation<PostGradeRequestModel> validator,
            ICommandHandler<EvaluateStudentCommand> evaluateStudentCommandHandler,
            IQueryHandler<GetStudentByIdQuery, Student> getStudentByIdQueryHandler,
            IQueryHandler<GetTeacherByIdQuery, Teacher> getTeacherByIdQueryHandler,
            IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQueryHandler)
        {
            _logger = logger;
            _validator = validator;
            _evaluateStudentCommandHandler = evaluateStudentCommandHandler;
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            _getTeacherByIdQueryHandler = getTeacherByIdQueryHandler;
            _getCourseByIdQueryHandler = getCourseByIdQueryHandler;
        }

        protected override async Task Handle(PostGradeRequestModel request, CancellationToken cancellationToken)
        {
            await _validator.Validate(request);

            Student student = await _getStudentByIdQueryHandler.HandleAsync(new GetStudentByIdQuery(request.StudentId), cancellationToken);
            Teacher teacher = await _getTeacherByIdQueryHandler.HandleAsync(new GetTeacherByIdQuery(request.TeacherId), cancellationToken);
            Course course = await _getCourseByIdQueryHandler.HandleAsync(new GetCourseByIdQuery(request.CourseId), cancellationToken);

            await _evaluateStudentCommandHandler.HandleAsync(new EvaluateStudentCommand(request.Grade, student, teacher, course), cancellationToken);
        }
    }
}
