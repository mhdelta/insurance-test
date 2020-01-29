using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class TiposCubrimiento
    {
        public TiposCubrimiento()
        {
            Polizas = new HashSet<Polizas>();
        }

        public int TicoId { get; set; }
        public string TicoNombre { get; set; }
        public string TicoDescripcion { get; set; }
        public int? TicoPorcentaje { get; set; }

        public virtual ICollection<Polizas> Polizas { get; set; }
    }
}
