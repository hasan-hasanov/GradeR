using Core.Entities;
using System.Collections.Generic;

namespace DAL.Seed
{
    public class RankSeed
    {
        public RankSeed()
        {
            Ranks = new List<Rank>()
            {
                new Rank() { Id = 1, Name = "Assistant Professor", },
                new Rank() { Id = 2, Name = "Senior Assistant Professor", },
                new Rank() { Id = 3, Name = "Associate Professor", },
                new Rank() { Id = 4, Name = "Professor", },
            };
        }

        public List<Rank> Ranks { get; }
    }
}
