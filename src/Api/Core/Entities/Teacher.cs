using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Teacher
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Rank Rank { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public ICollection<TeacherCourse> Courses { get; set; }
    }
}
