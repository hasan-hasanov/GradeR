using Common.LogResources;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllStudents;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.StudentModels.RequestModels;
using Services.Models.StudentModels.ResponseModels;
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
            IList<Student> students = await _getAllStudentsQueryHandler.HandleAsync(new GetAllStudentsQuery(), cancellationToken);

            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(IList<StudentResponseModel>)));
            IList<StudentResponseModel> studentResponse = students.Select(s => new StudentResponseModel(s)).ToList();
            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssembledResponse, nameof(IList<StudentResponseModel>)));

            return studentResponse;
        }
    }
}
