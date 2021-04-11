using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class Ciudade
    {
        public Ciudade()
        {
            Catalogos = new HashSet<Catalogo>();
            Distancia = new HashSet<Distancia>();
        }

        public string IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public string IdDepto { get; set; }
        public string NombreDepto { get; set; }

        public virtual ICollection<Catalogo> Catalogos { get; set; }
        public virtual ICollection<Distancia> Distancia { get; set; }
    }
}
