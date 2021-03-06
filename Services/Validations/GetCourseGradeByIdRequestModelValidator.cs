using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetCourseById;
using Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class GetCourseGradeByIdRequestModelValidator : IValidation<GetCourseGradeByIdRequestModel>
    {
        private readonly IQueryHandler<GetCourseByIdQuery, Course> _getCourseByIdQuery;

        public GetCourseGradeByIdRequestModelValidator(IQueryHandler<GetCourseByIdQuery, Course> getCourseByIdQuery)
        {
            _getCourseByIdQuery = getCourseByIdQuery;
        }

        public async Task Validate(GetCourseGradeByIdRequestModel model, CancellationToken cancellationToken = default)
        {
            List<string> errorMessages = new List<string>();

            Course course = await _getCourseByIdQuery.HandleAsync(new GetCourseByIdQuery(model.Id), cancellationToken);
            if (course == null)
            {
                errorMessages.Add($"{nameof(Course)} with id {model.Id} not found");
            }

            if (errorMessages.Any())
            {
                throw new NotFoundException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
