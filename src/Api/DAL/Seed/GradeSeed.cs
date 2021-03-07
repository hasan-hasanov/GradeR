using Core.Entities;
using System.Collections.Generic;

namespace DAL.Seed
{
    public class GradeSeed
    {
        public GradeSeed()
        {
            Grades = new List<Grade>()
            {
                new Grade() { Id = 1, StudentGrade = 78, StudentId = 1, TeacherId = 1, CourseId = 1 },
                new Grade() { Id = 2, StudentGrade = 99, StudentId = 2, TeacherId = 1, CourseId = 1 },
                new Grade() { Id = 3, StudentGrade = 37, StudentId = 3, TeacherId = 1, CourseId = 1 },
                new Grade() { Id = 4, StudentGrade = 87, StudentId = 4, TeacherId = 1, CourseId = 1 },
                new Grade() { Id = 5, StudentGrade = 68, StudentId = 5, TeacherId = 1, CourseId = 1 },
                new Grade() { Id = 6, StudentGrade = 78, StudentId = 1, TeacherId = 2, CourseId = 2 },
                new Grade() { Id = 7, StudentGrade = 98, StudentId = 2, TeacherId = 2, CourseId = 2 },
                new Grade() { Id = 8, StudentGrade = 77, StudentId = 6, TeacherId = 2, CourseId = 2 },
                new Grade() { Id = 9, StudentGrade = 43, StudentId = 7, TeacherId = 2, CourseId = 2 },
                new Grade() { Id = 10, StudentGrade = 17, StudentId = 8, TeacherId = 2, CourseId = 2 },
            };
        }

        public List<Grade> Grades { get; set; }
    }
}
