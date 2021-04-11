using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class Tercero
    {
        public Tercero()
        {
            Catalogos = new HashSet<Catalogo>();
            DespachoEncs = new HashSet<DespachoEnc>();
            Logs = new HashSet<Log>();
            SolicitudDespachoTerceros = new HashSet<SolicitudDespachoTercero>();
        }

        public int IdTercero { get; set; }
        public string NombreTercero { get; set; }
        public string NitTercero { get; set; }
        public string Email { get; set; }
        public string TipoTercero { get; set; }
        public string Password { get; set; }
        public int NumCelular { get; set; }

        public virtual ICollection<Catalogo> Catalogos { get; set; }
        public virtual ICollection<DespachoEnc> DespachoEncs { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<SolicitudDespachoTercero> SolicitudDespachoTerceros { get; set; }
    }
}
