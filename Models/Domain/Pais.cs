using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Models.Domain
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Pais : Entity
    {
        public string Nombre { get; set; }
        public virtual ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();
    }
}
