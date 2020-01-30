using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class Poliza
    {
        public Poliza()
        {
            PolizasCliente = new HashSet<PolizaCliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? InicioVigencia { get; set; }
        public int? MesesCobertura { get; set; }
        public double? Precio { get; set; }
        public int? TipoRiesgo { get; set; }
        public int? TipoCubrimiento { get; set; }

        public virtual TipoCubrimiento TipoCubrimientoNavigation { get; set; }
        public virtual TipoRiesgo TipoRiesgoNavigation { get; set; }
        public virtual ICollection<PolizaCliente> PolizasCliente { get; set; }
    }
}
