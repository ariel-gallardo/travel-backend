using System.ComponentModel.DataAnnotations;

namespace Models.Input
{
    public class TipoVehiculo
    {
        public long? Id { get; set; }
        [Required(ErrorMessage ="Falta la denominacion.")]
        public string Denominacion { get; set; }
    }
}
