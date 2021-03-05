using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetCourseById;
using DAL.Queries.GetStudentById;
using DAL.Queries.GetTeacherById;
using Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class PostGradeRequestModelValidator : IValidation<PostGradeRequestModel>
    {
        private readonly IQueryHandler<GetStudentByIdQuery, Student> _getStudentByIdQueryHandler;
        private readonly IQueryHandler<GetTeacherByIdQuery, Teacher> _getTeacherByIdQueryHandler;
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQueryHandler;

        public PostGradeRequestModelValidator(
            IQueryHandler<GetStudentByIdQuery, Student> getStudentByIdQueryHandler,
            IQueryHandler<GetTeacherByIdQuery, Teacher> getTeacherByIdQueryHandler,
            IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQueryHandler)
        {
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            _getTeacherByIdQueryHandler = getTeacherByIdQueryHandler;
            _getCourseByIdQueryHandler = getCourseByIdQueryHandler;
        }

        public async Task Validate(PostGradeRequestModel model, CancellationToken cancellationToken = default)
        {
            List<string> errorMessages = new List<string>();

            Student student = await _getStudentByIdQueryHandler.HandleAsync(new GetStudentByIdQuery(model.StudentId), cancellationToken);
            if (student == null)
            {
                errorMessages.Add($"{nameof(Student)} with id {model.StudentId} not found");
            }

            Teacher teacher = await _getTeacherByIdQueryHandler.HandleAsync(new GetTeacherByIdQuery(model.TeacherId), cancellationToken);
            if (teacher == null)
            {
                errorMessages.Add($"{nameof(Teacher)} with id {model.TeacherId} not found");
            }

            Course course = await _getCourseByIdQueryHandler.HandleAsync(new GetCourseByIdQuery(model.CourseId), cancellationToken);
            if (course == null)
            {
                errorMessages.Add($"{nameof(Course)} with id {model.CourseId} not found");
            }

            if (errorMessages.Any())
            {
                throw new BadRequestException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
