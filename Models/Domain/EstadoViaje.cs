namespace Models.Domain
{
    public class EstadoViaje
    {
        public DateTime Fecha { get; set; }
        public virtual Viaje Viaje { get; set; }
        public long ViajeId { get; set; }
    }
}
