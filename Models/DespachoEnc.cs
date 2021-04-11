using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class DespachoEnc
    {
        public DespachoEnc()
        {
            Aplicaciones = new HashSet<Aplicacione>();
            DespachoDets = new HashSet<DespachoDet>();
            SolicitudDespachoTerceros = new HashSet<SolicitudDespachoTercero>();
        }

        public int IdDespacho { get; set; }
        public int IdTercero { get; set; }
        public DateTime FechaOrden { get; set; }
        public string Estado { get; set; }
        public DateTime FechaDescarga { get; set; }
        public decimal ValorAsegurable { get; set; }
        public decimal PesoTotal { get; set; }
        public int? IdCiudadDestino { get; set; }
        public string DirDestino { get; set; }

        public virtual Tercero IdTerceroNavigation { get; set; }
        public virtual ICollection<Aplicacione> Aplicaciones { get; set; }
        public virtual ICollection<DespachoDet> DespachoDets { get; set; }
        public virtual ICollection<SolicitudDespachoTercero> SolicitudDespachoTerceros { get; set; }
    }
}
