using Microsoft.EntityFrameworkCore;

namespace Models.Domain
{
    [Index(nameof(Patente), IsUnique = true)]
    public class Vehiculo : Entity
    {
        public bool ItsBusy { get; set; } = false;
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public virtual TipoVehiculo Tipo { get; set; } = null;
        public long TipoVehiculoId { get; set; }
    }
}
