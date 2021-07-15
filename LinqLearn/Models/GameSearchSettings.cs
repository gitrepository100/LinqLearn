using System.Collections.Generic;

namespace LinqLearn.Models
{
    public class GameSearchSettings
    {
        public string Name { get; set; }

        public ICollection<string> Genres { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }
    }
}
