using Common.Log;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models.StudentModels.RequestModels;
using Services.Models.StudentModels.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeR.Controllers
{
    [ODataRoutePrefix("student")]
    public class StudentController : ODataController
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public StudentController(ILogger<StudentController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute]
        public async Task<IList<StudentResponseModel>> Get()
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogResources.ControllerFound, nameof(StudentController), nameof(Get)));

            IList<StudentResponseModel> studentsResponse = await _mediator.Send(new GetStudentsRequestModel());
            return studentsResponse;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("({id})")]
        public async Task<StudentResponseModel> GetStudent([FromODataUri] long id)
        {
            _logger.LogInformation(LogEvents.ControllerFound, string.Format(LogResources.ControllerFound, nameof(StudentController), nameof(GetStudent)));

            StudentResponseModel courseGradeResponse = await _mediator.Send(new GetStudentByIdRequestModel(id));
            return courseGradeResponse;
        }
    }
}
