using System.Collections.Generic;

namespace LinqLearn.Models
{
    public class SearchResult<T>
    {
        public int TotalResults { get; set; }

        public int Offset { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
