using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeR.Controllers
{
    [ODataRoutePrefix("course")]
    public class CourseController : ODataController
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute]
        public async Task<IList<CourseGradeResponseModel>> Get()
        {
            IList<CourseGradeResponseModel> courseGradeResponse = await _mediator.Send(new GetCourseGradesRequestModel());
            return courseGradeResponse;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("({id})")]
        public async Task<CourseGradeResponseModel> GetCourse([FromODataUri] long id)
        {
            CourseGradeResponseModel courseGradeResponse = await _mediator.Send(new GetCourseGradeByIdRequestModel(id));
            return courseGradeResponse;
        }
    }
}
