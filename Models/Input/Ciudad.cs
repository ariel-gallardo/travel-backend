using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.Input
{
    public class Ciudad
    {
        [JsonIgnore]
        public long? Id { get; set; }
        public string Nombre { get; set; }
        [Required]
        public long PaisId { get; set; }
    }
}
