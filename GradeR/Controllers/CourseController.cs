using Common.Log;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
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
        public async Task<IList<CourseGradeResponseModel>> Get()
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogResources.ControllerFound, nameof(CourseController), nameof(Get)));

            IList<CourseGradeResponseModel> courseGradeResponse = await _mediator.Send(new GetCourseGradesRequestModel());
            return courseGradeResponse;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("({id})")]
        public async Task<CourseGradeResponseModel> GetCourse([FromODataUri] long id)
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogResources.ControllerFound, nameof(CourseController), nameof(GetCourse)));

            CourseGradeResponseModel courseGradeResponse = await _mediator.Send(new GetCourseGradeByIdRequestModel(id));
            return courseGradeResponse;
        }
    }
}
