using Core.Entities;
using System;

namespace Services.Models.StudentModels.ResponseModels
{
    public class StudentCourseResponseModel
    {
        public StudentCourseResponseModel(Course course)
        {
            Id = course.Id;
            Name = course.Name;
            StartDate = course.StartDate;
            EndDate = course.EndDate;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
