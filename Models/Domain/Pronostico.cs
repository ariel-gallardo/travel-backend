using System;

namespace Models.Domain
{
    public class Pronostico : Entity
    {
        public long CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public DateTime DiaSolicitado { get; set; }
        public string Descripcion { get; set; }
    }
}
