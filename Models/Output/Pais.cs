using System.Collections.Generic;

namespace Models.Output
{
    public class Pais
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Ciudad> Ciudades { get; set; }
    }
}
