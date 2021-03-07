using Core.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Seed
{
    public class StudentSeed
    {
        public StudentSeed()
        {
            Students = new List<Student>()
            {
                new Student() { Id = 1, FirstName = "Hasan", LastName = "Hasanov", BirthDate = new DateTime(1993, 09, 22), },
                new Student() { Id = 2, FirstName = "Krasimir", LastName = "Atanasov", BirthDate = new DateTime(1990, 10, 12), },
                new Student() { Id = 3, FirstName = "Martin", LastName = "Bozhilov", BirthDate = new DateTime(1989, 12, 11), },
                new Student() { Id = 4, FirstName = "Tonicha", LastName = "Medina", BirthDate = new DateTime(1985, 05, 06), },
                new Student() { Id = 5, FirstName = "Juno", LastName = "Thompson", BirthDate = new DateTime(1958, 09, 18), },
                new Student() { Id = 6, FirstName = "Elizabeth", LastName = "Riojas", BirthDate = new DateTime(1994, 10, 14), },
                new Student() { Id = 7, FirstName = "Carla", LastName = "Duffin", BirthDate = new DateTime(1993, 01, 09), },
                new Student() { Id = 8, FirstName = "Eric", LastName = "Whelchel", BirthDate = new DateTime(1963, 11, 13), },
                new Student() { Id = 9, FirstName = "Mareen", LastName = "Braun", BirthDate = new DateTime(1987, 04, 07), },
                new Student() { Id = 10, FirstName = "Linda", LastName = "Payne", BirthDate = new DateTime(1979, 09, 03), },
                new Student() { Id = 11, FirstName = "Steve", LastName = "Crawford", BirthDate = new DateTime(1960, 02, 10), },
                new Student() { Id = 12, FirstName = "Angelo", LastName = "Kurtz", BirthDate = new DateTime(1961, 04, 08), },
                new Student() { Id = 13, FirstName = "Michael", LastName = "Franklin", BirthDate = new DateTime(1974, 12, 22), },
                new Student() { Id = 14, FirstName = "Toni", LastName = "Goodson", BirthDate = new DateTime(1993, 09, 20), },
                new Student() { Id = 15, FirstName = "Wilma", LastName = "Madden", BirthDate = new DateTime(1989, 02, 23), },
            };
        }

        public List<Student> Students { get; }
    }
}
