using System;
using System.Collections.Generic;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class DespachoDet
    {
        public int IdDespachoDet { get; set; }
        public int IdDespachoEnc { get; set; }
        public string NombreProducto { get; set; }
        public decimal PesoProducto { get; set; }

        public virtual DespachoEnc IdDespachoEncNavigation { get; set; }
    }
}
