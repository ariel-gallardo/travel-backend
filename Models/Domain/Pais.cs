namespace Models.Domain
{
    public class Pais : Entity
    {
        public string Nombre { get; set; }
        public IList<Ciudad> Ciudades { get; set; } = new List<Ciudad>();
    }
}
