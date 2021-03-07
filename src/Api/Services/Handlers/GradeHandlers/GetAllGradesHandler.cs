using Common.LogResources;
using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllGrades;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.GradeModels.RequestModels;
using Services.Models.GradeModels.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.GradeHandlers
{
    public class GetAllGradesHandler : IRequestHandler<GetAllGradesRequestModel, IList<GradeResponseModel>>
    {
        private readonly ILogger _logger;
        private readonly IQueryHandler<GetAllGradesQuery, IList<Grade>> _getAllGradesQueryHandler;

        public GetAllGradesHandler(
            ILogger<GetAllGradesHandler> logger,
            IQueryHandler<GetAllGradesQuery, IList<Grade>> getAllGradesQueryHandler)
        {
            _logger = logger;
            _getAllGradesQueryHandler = getAllGradesQueryHandler;
        }

        public async Task<IList<GradeResponseModel>> Handle(GetAllGradesRequestModel request, CancellationToken cancellationToken)
        {
            IList<Grade> grades = await _getAllGradesQueryHandler.HandleAsync(new GetAllGradesQuery(), cancellationToken);

            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssemblingResponse, nameof(IList<GradeResponseModel>)));
            IList<GradeResponseModel> gradesResponse = grades.Select(g => new GradeResponseModel(g)).ToList();
            _logger.LogInformation(LogEvents.AssemblingResponse, string.Format(LogMessageResources.AssembledResponse, nameof(IList<GradeResponseModel>)));

            return gradesResponse;
        }
    }
}
