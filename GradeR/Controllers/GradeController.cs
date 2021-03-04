using Microsoft.AspNetCore.Mvc;

namespace GradeR.Controllers
{
    public class GradeController : ControllerBase
    {
        public IActionResult GetStudentGrades()
        {
            return Ok();
        }
    }
}
