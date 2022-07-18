using System;

namespace Models.Filter
{
    public class ViajesFilter
    {
        public DateTime? FechaInicial { get; set; } = null;
        public DateTime? FechaFinal { get; set; } = null;
        public string TipoVehiculo { get; set; } = "";
        public string Destino { get; set; } = "";
        public bool IsRango { get; set; } = false;
        public bool IsTipo {get;set;} = false;
        public bool IsDestino {get;set;} = false;
    }
}
