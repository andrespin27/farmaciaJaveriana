using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class Distancia
    {
        public int IdDistancia { get; set; }
        public string IdCiudad { get; set; }
        public decimal CantidadKm { get; set; }

        public virtual Ciudade IdCiudadNavigation { get; set; }
    }
}
