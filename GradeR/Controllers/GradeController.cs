using Common.Log;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
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
