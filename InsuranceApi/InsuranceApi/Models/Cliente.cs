using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            PolizasCliente = new HashSet<PolizaCliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PolizaCliente> PolizasCliente { get; set; }
    }
}
