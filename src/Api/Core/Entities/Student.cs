using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Student
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }
    }
}
