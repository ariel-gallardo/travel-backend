namespace Models.Output
{
    public class Vehiculo
    {
        public long Id { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string TipoVehiculo { get; set; }
        public bool ItsBusy { get; set; }
        public long TipoVehiculoId { get; set; }
    }
}
