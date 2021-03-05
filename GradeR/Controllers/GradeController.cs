using Core.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeR.Controllers
{
    [ODataRoutePrefix("grade")]
    public class GradeController : ODataController
    {
        private readonly StudentService studentService;

        public GradeController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute]
        public async Task<List<Student>> Get()
        {
            IList<Student> test = await this.studentService.GetAllStudents();
            return new List<Student>(test);
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("({id})")]
        public async Task<List<Student>> GetGrade([FromODataUri] long id)
        {
            IList<Student> test = await this.studentService.GetAllStudents();
            return new List<Student>(test);
        }

        [HttpPost]
        [EnableQuery]
        [ODataRoute]
        public async Task<List<Student>> PostGrade([FromODataUri] long id)
        {
            IList<Student> test = await this.studentService.GetAllStudents();
            return new List<Student>(test);
        }
    }
}
