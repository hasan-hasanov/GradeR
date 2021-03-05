using Core.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeR.Controllers
{
    public class GradeController : ControllerBase
    {
        private readonly StudentService studentService;

        public GradeController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("grade")]
        public async Task<List<Student>> GetGrade()
        {
            IList<Student> test = await this.studentService.GetAllStudents();
            return new List<Student>(test);
        }
    }
}
