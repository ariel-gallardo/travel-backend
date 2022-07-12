using System.Collections.Generic;

namespace Models.Output
{
    public class Pagination<T>
    {
        public long TotalPages { get; set; }
        public long TotalItems { get; set; }
        public long Count { get; set; }
        public long Page { get; set; }
        public bool NextPage { get; set; }
        public bool BackPage { get; set; }
        public ICollection<T> List { get; set; }
    }
}
