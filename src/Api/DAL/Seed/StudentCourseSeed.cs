using Core.Entities;
using System.Collections.Generic;

namespace DAL.Seed
{
    public class StudentCourseSeed
    {
        public StudentCourseSeed()
        {
            StudentCourses = new List<StudentCourse>()
            {
                new StudentCourse() { Id = 1, StudentId = 1, CourseId = 1 },
                new StudentCourse() { Id = 2, StudentId = 2, CourseId = 1 },
                new StudentCourse() { Id = 3, StudentId = 3, CourseId = 1 },
                new StudentCourse() { Id = 4, StudentId = 4, CourseId = 1 },
                new StudentCourse() { Id = 5, StudentId = 5, CourseId = 1 },
                new StudentCourse() { Id = 6, StudentId = 1, CourseId = 2 },
                new StudentCourse() { Id = 7, StudentId = 2, CourseId = 2 },
                new StudentCourse() { Id = 8, StudentId = 6, CourseId = 2 },
                new StudentCourse() { Id = 9, StudentId = 7, CourseId = 2 },
                new StudentCourse() { Id = 10, StudentId = 8, CourseId = 2 },
                new StudentCourse() { Id = 11, StudentId = 9, CourseId = 3 },
                new StudentCourse() { Id = 12, StudentId = 10, CourseId = 3 },
                new StudentCourse() { Id = 13, StudentId = 11, CourseId = 3 },
                new StudentCourse() { Id = 14, StudentId = 12, CourseId = 3 },
                new StudentCourse() { Id = 15, StudentId = 13, CourseId = 3 },
                new StudentCourse() { Id = 16, StudentId = 14, CourseId = 4 },
                new StudentCourse() { Id = 17, StudentId = 15, CourseId = 4 },
                new StudentCourse() { Id = 18, StudentId = 10, CourseId = 4 },
                new StudentCourse() { Id = 19, StudentId = 11, CourseId = 4 },
                new StudentCourse() { Id = 20, StudentId = 12, CourseId = 4 },
            };
        }

        public List<StudentCourse> StudentCourses { get; set; }
    }
}
