using System.Collections.Generic;

namespace Models.Output
{
    public class TipoVehiculo
    {
        public long Id { get; set; }
        public string Denominacion { get; set; }
        public virtual IList<Vehiculo> Vehiculos { get; set; }
    }
}
