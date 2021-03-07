using Common.Exceptions;
using Common.LogResources;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetCourseById;
using DAL.Queries.GetStudentById;
using DAL.Queries.GetTeacherById;
using Microsoft.Extensions.Logging;
using Services.Models.GradeModels.RequestModels;
using Services.Models.StudentModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class PostGradeRequestModelValidator : IValidation<PostGradeRequestModel>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetStudentByIdQuery, Student> _getStudentByIdQueryHandler;
        private readonly IQueryHandler<GetTeacherByIdQuery, Teacher> _getTeacherByIdQueryHandler;
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQueryHandler;

        public PostGradeRequestModelValidator(
            ILogger<PostGradeRequestModelValidator> logger,
            IQueryHandler<GetStudentByIdQuery, Student> getStudentByIdQueryHandler,
            IQueryHandler<GetTeacherByIdQuery, Teacher> getTeacherByIdQueryHandler,
            IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQueryHandler)
        {
            _logger = logger;
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            _getTeacherByIdQueryHandler = getTeacherByIdQueryHandler;
            _getCourseByIdQueryHandler = getCourseByIdQueryHandler;
        }

        public async Task Validate(PostGradeRequestModel model, CancellationToken cancellationToken = default)
        {
            List<string> errorMessages = new List<string>();

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.StudentId)));
            Student student = await _getStudentByIdQueryHandler.HandleAsync(new GetStudentByIdQuery(model.StudentId), cancellationToken);
            if (student == null)
            {
                string message = $"{nameof(Student)} with id {model.StudentId} not found";
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.StudentId), message));
                errorMessages.Add(message);
            }

            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.StudentId)));

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.TeacherId)));
            Teacher teacher = await _getTeacherByIdQueryHandler.HandleAsync(new GetTeacherByIdQuery(model.TeacherId), cancellationToken);
            if (teacher == null)
            {
                string message = $"{nameof(Teacher)} with id {model.TeacherId} not found";
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.TeacherId), message));
                errorMessages.Add(message);
            }

            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.TeacherId)));

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.CourseId)));
            Course course = await _getCourseByIdQueryHandler.HandleAsync(new GetCourseByIdQuery(model.CourseId), cancellationToken);
            if (course == null)
            {
                string message = $"{nameof(Course)} with id {model.CourseId} not found";
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.CourseId), message));
                errorMessages.Add(message);
            }

            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.CourseId)));

            _logger.LogInformation(LogEvents.ValidatingItem, string.Format(LogMessageResources.ValidatingItem, nameof(model.Grade)));
            if (model.Grade < 0 || model.Grade > 100)
            {
                string message = $"{nameof(model.Grade)} must be between 0 and 100";
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(model.Grade), message));
                errorMessages.Add(message);
            }

            _logger.LogInformation(LogEvents.ValidatedItem, string.Format(LogMessageResources.ValidatedItem, nameof(model.Grade)));

            if (errorMessages.Any())
            {
                string message = string.Join(Environment.NewLine, errorMessages);
                _logger.LogWarning(LogEvents.ValidationFailed, string.Format(LogMessageResources.ValidationFailed, nameof(GetStudentByIdRequestModel), message));
                throw new NotFoundException(message);
            }
        }
    }
}
