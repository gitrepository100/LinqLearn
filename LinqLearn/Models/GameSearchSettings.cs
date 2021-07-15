using System.Collections.Generic;

namespace LinqLearn.Models
{
    public class GameSearchSettings
    {
        public string Name { get; set; }

        public ICollection<GameGenre> Genres { get; set; }

        public decimal? MinimalCost { get; set; }

        public decimal? MaximalCost { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }
    }
}
