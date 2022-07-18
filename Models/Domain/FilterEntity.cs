namespace Models.Domain
{
    public class FilterEntity<Q,F>
    {
        public Q Query { get; set; }
        public F Filter { get; set; }
    }
}
