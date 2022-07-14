using Microsoft.EntityFrameworkCore;
using System;

namespace Models.Domain
{
    public class EstadoViaje : Entity
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public virtual Viaje Viaje { get; set; }
        public long ViajeId { get; set; }
    }
}
