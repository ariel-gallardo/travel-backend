namespace Models.Output
{
    public class Viaje
    {
        public string PaisOrigen { get; set; }
        public string PaisDestino { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; } = null;
        public Vehiculo VehiculoAsignado { get; set; }
        public string EstadoViaje { get; set; }
    }
}
