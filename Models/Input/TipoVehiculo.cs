using System.ComponentModel.DataAnnotations;

namespace Models.Input
{
    public class TipoVehiculo
    {
        [Required(ErrorMessage ="Falta la denominacion.")]
        public string Denominacion { get; set; }
    }
}
