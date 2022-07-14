using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Models.Domain
{
    [Index(nameof(Denominacion), IsUnique = true)]
    public class TipoVehiculo : Entity
    {
        public string Denominacion { get; set; }
        public virtual IList<Vehiculo> Vehiculos { get; set; }
    }
}
