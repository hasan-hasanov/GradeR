using Core.Entities;
using System;

namespace Services.Models.CourseModels.ResponseModels
{
    public class CourseTeacherResponseModel
    {
        public CourseTeacherResponseModel(Teacher teacher)
        {
            Id = teacher.Id;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            BirthDate = teacher.BirthDate;
            Rank = teacher?.Rank?.Name;
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Rank { get; set; }
    }
}
