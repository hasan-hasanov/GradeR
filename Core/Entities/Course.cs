using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Course
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<StudentCourse> Students { get; set; }

        public ICollection<TeacherCourse> Teachers { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
