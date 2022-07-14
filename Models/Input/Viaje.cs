﻿using Services.Helpers.Models.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Input
{

    public class Viaje
    {

        [Required(ErrorMessage = "Debe asignar una ciudad de origen.")]
        public long CiudadOrigenId { get; set; }

        [Required(ErrorMessage = "Debe asignar una ciudad de origen.")]
        public long CiudadDestinoId { get; set; }

        [Required(ErrorMessage = "Debe asignar un vehiculo.")]
        public long VehiculoId { get; set; }

        [Required(ErrorMessage = "Debe asignar una fecha de inicio.")]
        [CustomDate(ErrorMessage = "El viaje debe estar entre la fecha actual y a 10 dias como maximo.")]
        public DateTime FechaInicio { get; set; }
    }
}