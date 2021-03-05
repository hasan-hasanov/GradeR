using Core.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GradeR.Controllers
{
    [ODataRoutePrefix("teacher")]
    public class TeacherController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        [ODataRoute]
        public List<Student> Get()
        {
            return new List<Student>();
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("({id})")]
        public List<Student> GetStudent([FromODataUri] long id)
        {
            return new List<Student>();
        }
    }
}
