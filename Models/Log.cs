using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class Log
    {
        public int IdLog { get; set; }
        public int NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Descripcion { get; set; }
        public int? IdTercero { get; set; }

        public virtual Tercero IdTerceroNavigation { get; set; }
    }
}
