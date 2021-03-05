using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GradeR.Controllers
{
    public class GradeController : ControllerBase
    {
        [HttpGet]
        [EnableQuery]
        [ODataRoute("StudentA")]
        public IEnumerable<StudentA> GetStudentA()
        {
            return new List<StudentA>
            {
                CreateNewStudent("Cody Allen", 130),
                CreateNewStudent("Todd Ostermeier", 160),
                CreateNewStudent("Viral Pandya", 140),
            };
        }

        private static StudentA CreateNewStudent(string name, int score)
        {
            return new StudentA
            {
                Id = Guid.NewGuid(),
                Name = name,
                Score = score,
            };
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class StudentA
#pragma warning restore SA1402 // File may only contain a single type
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }
    }
}
