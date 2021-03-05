using Common.Log;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllStudents;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.StudentHandlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsRequestModel, IList<StudentResponseModel>>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetAllStudentsQuery, IList<Student>> _getAllStudentsQueryHandler;

        public GetStudentsHandler(
            ILogger<GetStudentsHandler> logger,
            IQueryHandler<GetAllStudentsQuery, IList<Student>> getAllStudentsQueryHandler)
        {
            _logger = logger;
            _getAllStudentsQueryHandler = getAllStudentsQueryHandler;
        }

        public async Task<IList<StudentResponseModel>> Handle(GetStudentsRequestModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(LogEvents.ListingItems, string.Format(LogResources.ListingItems, nameof(StudentResponseModel)));
            IList<Student> students = await _getAllStudentsQueryHandler.HandleAsync(new GetAllStudentsQuery(), cancellationToken);
            IList<StudentResponseModel> studentResponse = students.Select(s => new StudentResponseModel(s)).ToList();
            _logger.LogInformation(LogEvents.ListedItems, string.Format(LogResources.ListedItems, studentResponse.Count, nameof(StudentResponseModel)));

            return studentResponse;
        }
    }
}
