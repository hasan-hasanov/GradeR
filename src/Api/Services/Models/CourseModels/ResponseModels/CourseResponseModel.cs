using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.CourseModels.ResponseModels
{
    public class CourseResponseModel
    {
        public CourseResponseModel(Course course)
        {
            if (course != null)
            {
                Id = course.Id;
                Name = course.Name;
                StartDate = course.StartDate;
                EndDate = course.EndDate;
                Teachers = course.Teachers.Select(t => new CourseTeacherResponseModel(t.Teacher)).ToList();
            }
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IList<CourseTeacherResponseModel> Teachers { get; set; }
    }
}
