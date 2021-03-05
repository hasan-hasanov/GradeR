using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.ResponseModels
{
    public class CourseGradeResponseModel
    {
        public CourseGradeResponseModel(Course course)
        {
            if (course != null)
            {
                Id = course.Id;
                Name = course.Name;
                StartDate = course.StartDate;
                EndDate = course.EndDate;
                Grades = course?.Grades.Select(g => new GradeResponseModel(g)).ToList();
            }
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IList<GradeResponseModel> Grades { get; set; }
    }
}
