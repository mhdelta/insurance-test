using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class TipoRiesgo
    {
        public TipoRiesgo()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}
