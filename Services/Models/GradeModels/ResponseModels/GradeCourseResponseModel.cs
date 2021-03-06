using Core.Entities;
using System;

namespace Services.Models.GradeModels.ResponseModels
{
    public class GradeCourseResponseModel
    {
        public GradeCourseResponseModel(Course course)
        {
            Name = course.Name;
            StartDate = course.StartDate;
            EndDate = course.EndDate;
        }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
