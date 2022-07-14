using System.Collections.Generic;

namespace Models.Domain
{
    public class Weather
    {
        public string Main { get; set; }
    }

    public class ExternalPronostico
    {
        public List<Weather> Weather { get; set; }
        public string Name { get; set; }
    }
}
