using System.Collections.Generic;

namespace LinqLearn.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<string> Genres { get; set; }

        public decimal Price { get; set; }
    }
}
