namespace Models.Output
{
    public class Pais
    {
        public string Nombre { get; set; }
        public virtual Pagination<Ciudad> Ciudades { get; set; }
    }
}
