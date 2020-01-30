using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class PolizaCliente
    {
        public int IdCliente { get; set; }
        public int IdPoliza { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Poliza IdPolizaNavigation { get; set; }
    }
}
