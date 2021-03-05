using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.ResponseModels
{
    public class StudentResponseModel
    {
        public StudentResponseModel(Student student)
        {
            if (student != null)
            {
                Id = student.Id;
                FirstName = student.FirstName;
                LastName = student.LastName;
                BirthDate = student.BirthDate;
                CourseGrades = student?.Grades?.Select(g => new StudentGradeResponseModel(g))?.ToList();
            }
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public IList<StudentGradeResponseModel> CourseGrades { get; set; }
    }
}
