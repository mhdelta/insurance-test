using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class TipoCubrimiento
    {
        public TipoCubrimiento()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Porcentaje { get; set; }

        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}
