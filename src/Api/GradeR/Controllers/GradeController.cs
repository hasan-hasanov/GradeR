using Common.Log;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models.GradeModels.RequestModels;
using Services.Models.GradeModels.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeR.Controllers
{
    [ODataRoutePrefix("grade")]
    public class GradeController : ODataController
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public GradeController(ILogger<GradeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute]
        public async Task<IList<GradeResponseModel>> Get()
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogResources.ControllerFound, nameof(GradeController), nameof(Get)));

            IList<GradeResponseModel> gradeResponse = await _mediator.Send(new GetAllGradesRequestModel());
            return gradeResponse;
        }

        [HttpPost]
        [ODataRoute]
        public async Task<IActionResult> Post([FromBody] PostGradeRequestModel model)
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogResources.ControllerFound, nameof(GradeController), nameof(Post)));

            await _mediator.Send(model);
            return NoContent();
        }
    }
}
