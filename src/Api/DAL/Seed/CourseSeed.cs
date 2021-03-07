using Core.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Seed
{
    public class CourseSeed
    {
        public CourseSeed()
        {
            Courses = new List<Course>()
            {
                new Course() { Id = 1, Name = "C# Programming Basics", StartDate = new DateTime(2020, 03, 11), EndDate = new DateTime(2020, 08, 11), },
                new Course() { Id = 2, Name = "C# Programming Advanced", StartDate = new DateTime(2020, 03, 11), EndDate = new DateTime(2020, 08, 11), },
                new Course() { Id = 3, Name = "Java Programming Basics", StartDate = new DateTime(2021, 03, 11), EndDate = new DateTime(2021, 08, 11), },
                new Course() { Id = 4, Name = "Java Programming Advanced", StartDate = new DateTime(2021, 03, 11), EndDate = new DateTime(2021, 08, 11), },
            };
        }

        public List<Course> Courses { get; }
    }
}
