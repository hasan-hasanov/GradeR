using Core.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Seed
{
    public class TeacherSeed
    {
        public TeacherSeed()
        {
            Teachers = new List<Teacher>()
            {
                new Teacher() { Id = 1, FirstName = "George", LastName = "Withrow", BirthDate = new DateTime(1963, 10, 16), RankId = 1 },
                new Teacher() { Id = 2, FirstName = "Teresa", LastName = "Reel", BirthDate = new DateTime(1980, 03, 31), RankId = 4 },
                new Teacher() { Id = 3, FirstName = "Nancy", LastName = "Flinn", BirthDate = new DateTime(1985, 09, 04), RankId = 2 },
                new Teacher() { Id = 4, FirstName = "Tara", LastName = "Stanley", BirthDate = new DateTime(1957, 11, 19), RankId = 4 },
            };
        }

        public List<Teacher> Teachers { get; set; }
    }
}
