using Core.Entities;
using System.Collections.Generic;

namespace DAL.Seed
{
    public class TeacherCourseSeed
    {
        public TeacherCourseSeed()
        {
            TeacherCourses = new List<TeacherCourse>()
            {
                new TeacherCourse() { Id = 1, TeacherId = 1, CourseId = 1 },
                new TeacherCourse() { Id = 2, TeacherId = 2, CourseId = 2 },
                new TeacherCourse() { Id = 3, TeacherId = 3, CourseId = 3 },
                new TeacherCourse() { Id = 4, TeacherId = 4, CourseId = 4 },
            };
        }

        public List<TeacherCourse> TeacherCourses { get; set; }
    }
}
