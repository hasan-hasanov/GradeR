using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Services.Models.RequestModels;
using System.Threading.Tasks;

namespace GradeR.Controllers
{
    [ODataRoutePrefix("grade")]
    public class GradeController : ODataController
    {
        private readonly IMediator _mediator;

        public GradeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ODataRoute]
        public async Task<IActionResult> Post([FromBody] PostGradeRequestModel model)
        {
            await _mediator.Send(model);
            return NoContent();
        }
    }
}
