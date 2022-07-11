namespace Models.Domain
{
    public class Entity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime? UptatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
