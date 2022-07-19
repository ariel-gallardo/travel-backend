using System.ComponentModel.DataAnnotations;

namespace Models.Input
{
    public class Vehiculo
    {
        public long? Id { get; set; }
        [Required(ErrorMessage ="Falta la patente."),RegularExpression("[aA-zZ]{3}-[0-9]{3}",ErrorMessage = "Formato. debe ser AAA-000")]
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }

        [Required(ErrorMessage = "Falta el tipo de vehiculo.")]
        public long TipoVehiculoId { get; set; }
    }
}
