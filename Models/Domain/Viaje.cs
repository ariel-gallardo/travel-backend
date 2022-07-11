namespace Models.Domain
{
    public class Viaje
    {
        public Pais PaisOrigen { get; set; }
        public Pais PaisDestino { get; set; }
        public Ciudad CiudadOrigen { get; set; }
        public Ciudad CiudadDestino { get; set; }
        public Vehiculo VehiculoAsignado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoViaje Estado { get; set; }
    }
}
