using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class TiposRiesgo
    {
        public TiposRiesgo()
        {
            Polizas = new HashSet<Polizas>();
        }

        public int TiriId { get; set; }
        public string TiriDescripcion { get; set; }

        public virtual ICollection<Polizas> Polizas { get; set; }
    }
}
