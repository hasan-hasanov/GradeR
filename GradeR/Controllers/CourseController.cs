using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Services.Models.ResponseModels;
using System.Collections.Generic;

namespace GradeR.Controllers
{
    public class CourseController : ControllerBase
    {
        [HttpGet]
        [EnableQuery]
        [ODataRoute("Course")]
        public List<CourseGradeResponseModel> Get()
        {
            return new List<CourseGradeResponseModel>();
        }
    }
}
