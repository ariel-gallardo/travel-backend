using System;

namespace Models.Filter
{
    public class ViajesFilter
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string TipoVehiculo { get; set; } = "";
        public string Destino { get; set; } = "";
        public bool IsRango { get; set; } = false;
        public bool IsTipo {get;set;} = false;
        public bool IsDestino {get;set;} = false;
    }
}
