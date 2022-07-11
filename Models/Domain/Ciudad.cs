namespace Models.Domain
{
    public class Ciudad : Entity
    {
        public string Nombre { get; set; }
        public long PaisId { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
