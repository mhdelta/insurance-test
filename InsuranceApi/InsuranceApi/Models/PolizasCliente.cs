using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class PolizasCliente
    {
        public int PoclIdCliente { get; set; }
        public int PoclIdPoliza { get; set; }

        public virtual Clientes PoclIdClienteNavigation { get; set; }
        public virtual Polizas PoclIdPolizaNavigation { get; set; }
    }
}
