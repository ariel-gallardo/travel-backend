using System;

namespace Models.Domain
{
    public class ReprogramacionViaje : Entity
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public virtual Viaje Viaje { get; set; }
        public long ViajeId { get; set; }
    }
}
