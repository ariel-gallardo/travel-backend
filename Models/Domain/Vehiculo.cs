﻿namespace Models.Domain
{
    public class Vehiculo : Entity
    {
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public virtual TipoVehiculo Tipo { get; set; }
        public long TipoVehiculoId { get; set; }
    }
}