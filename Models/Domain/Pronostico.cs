namespace Models.Domain
{
    public class Pronostico : Entity
    {
        public Ciudad Ciudad { get; set; }
        public DateTime DiaSolicitado { get; set; }
        public string Descripcion { get; set; }
    }
}
