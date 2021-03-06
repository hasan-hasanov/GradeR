using Common.Log;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models.CourseModels.RequestModels;
using Services.Models.CourseModels.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeR.Controllers
{
    [ODataRoutePrefix("course")]
    public class CourseController : ODataController
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CourseController(ILogger<CourseController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute]
        public async Task<IList<CourseResponseModel>> Get()
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogResources.ControllerFound, nameof(CourseController), nameof(Get)));

            IList<CourseResponseModel> courseGradeResponse = await _mediator.Send(new GetCourseRequestModel());
            return courseGradeResponse;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("({id})")]
        public async Task<CourseResponseModel> GetCourse([FromODataUri] long id)
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogResources.ControllerFound, nameof(CourseController), nameof(GetCourse)));

            CourseResponseModel courseGradeResponse = await _mediator.Send(new GetCourseByIdRequestModel(id));
            return courseGradeResponse;
        }
    }
}
