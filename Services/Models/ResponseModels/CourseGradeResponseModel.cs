using System;

namespace Services.Models.ResponseModels
{
    public class CourseGradeResponseModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
