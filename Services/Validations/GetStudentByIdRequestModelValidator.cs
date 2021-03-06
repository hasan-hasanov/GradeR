using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL.Queries.GetStudentById;
using Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class GetStudentByIdRequestModelValidator : IValidation<GetStudentByIdRequestModel>
    {
        private readonly IQueryHandler<GetStudentByIdQuery, Student> _getStudentByIdQueryHandler;

        public GetStudentByIdRequestModelValidator(IQueryHandler<GetStudentByIdQuery, Student> getStudentByIdQueryHandler)
        {
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        }

        public async Task Validate(GetStudentByIdRequestModel model, CancellationToken cancellationToken = default)
        {
            List<string> errorMessages = new List<string>();

            Student student = await _getStudentByIdQueryHandler.HandleAsync(new GetStudentByIdQuery(model.Id));
            if (student == null)
            {
                errorMessages.Add($"{nameof(Student)} with id {model.Id} not found");
            }

            if (errorMessages.Any())
            {
                throw new NotFoundException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
