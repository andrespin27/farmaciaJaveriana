using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class SolicitudDespachoTercero
    {
        public SolicitudDespachoTercero()
        {
            Aplicaciones = new HashSet<Aplicacione>();
        }

        public int IdRow { get; set; }
        public int IdTercero { get; set; }
        public int IdDespacho { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public bool Estado { get; set; }

        public virtual DespachoEnc IdDespachoNavigation { get; set; }
        public virtual Tercero IdTerceroNavigation { get; set; }
        public virtual ICollection<Aplicacione> Aplicaciones { get; set; }
    }
}
