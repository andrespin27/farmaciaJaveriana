using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class Catalogo
    {
        public int IdCatalogo { get; set; }
        public int IdTercero { get; set; }
        public string IdCiudad { get; set; }
        public string Categoria { get; set; }
        public decimal PesoIni { get; set; }
        public decimal PesoFin { get; set; }
        public decimal DistanciaIni { get; set; }
        public decimal DistaciaFin { get; set; }
        public int Valor { get; set; }
        public DateTime FechaCargue { get; set; }
        public bool Estado { get; set; }
        public int DiasEntrega { get; set; }

        public virtual Ciudade IdCiudadNavigation { get; set; }
        public virtual Tercero IdTerceroNavigation { get; set; }
    }
}
