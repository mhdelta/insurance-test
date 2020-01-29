using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            PolizasCliente = new HashSet<PolizasCliente>();
        }

        public int ClieId { get; set; }
        public string ClieNombre { get; set; }

        public virtual ICollection<PolizasCliente> PolizasCliente { get; set; }
    }
}
