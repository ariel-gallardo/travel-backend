using System;
using System.Collections.Generic;

namespace Models.Domain
{
    public class Viaje : Entity
    {
        public virtual Ciudad CiudadOrigen { get; set; }
        public virtual Ciudad CiudadDestino { get; set; }
        public virtual Vehiculo VehiculoAsignado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public virtual ICollection<EstadoViaje> EstadoViaje { get; set; } = new List<EstadoViaje>();

        #region ForeingKeys
            public long CiudadOrigenId { get; set; }
            public long CiudadDestinoId { get; set; }
            public long VehiculoId { get; set; }
        #endregion
    }
}
