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
    [ODataRoutePrefix("student")]
    public class StudentController : ODataController
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute]
        public async Task<IList<StudentResponseModel>> Get()
        {
            IList<StudentResponseModel> studentsResponse = await _mediator.Send(new GetStudentsRequestModel());
            return studentsResponse;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("({id})")]
        public async Task<StudentResponseModel> GetStudent([FromODataUri] long id)
        {
            StudentResponseModel courseGradeResponse = await _mediator.Send(new GetStudentByIdRequestModel(id));
            return courseGradeResponse;
        }
    }
}
