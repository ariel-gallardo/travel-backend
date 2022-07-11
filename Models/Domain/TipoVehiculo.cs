namespace Models.Domain
{
    public class TipoVehiculo
    {
        public string Denominacion { get; set; }
        public virtual IList<Vehiculo> Vehiculos { get; set; }
    }
}
