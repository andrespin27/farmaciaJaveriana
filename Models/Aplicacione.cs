using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class Aplicacione
    {
        public int IdAplicacion { get; set; }
        public int IdRow { get; set; }
        public int IdDespacho { get; set; }
        public DateTime FechaAplicacion { get; set; }

        public virtual DespachoEnc IdDespachoNavigation { get; set; }
        public virtual SolicitudDespachoTercero IdRowNavigation { get; set; }
    }
}
