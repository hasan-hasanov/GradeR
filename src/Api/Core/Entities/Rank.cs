using System.Collections.Generic;

namespace Core.Entities
{
    public class Rank
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}
