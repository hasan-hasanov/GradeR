using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace GradeR.Controllers
{
    [Route("grade")]
    public class GradeController : ControllerBase
    {
        private readonly StudentService studentService;

        public GradeController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentGrades()
        {
            var test = await this.studentService.GetAllStudents();
            return Ok(test);
        }
    }
}
