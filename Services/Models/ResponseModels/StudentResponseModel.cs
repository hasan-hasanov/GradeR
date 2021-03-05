using System;
using System.Collections.Generic;

namespace Services.Models.ResponseModels
{
    public class StudentResponseModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public IList<GradeResponseModel> Grades { get; set; }

        public IList<CourseResponseModel> Courses { get; set; }
    }
}
