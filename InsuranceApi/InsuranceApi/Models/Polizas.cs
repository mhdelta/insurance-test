using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class Polizas
    {
        public Polizas()
        {
            PolizasCliente = new HashSet<PolizasCliente>();
        }

        public int PoliId { get; set; }
        public string PoliNombre { get; set; }
        public string PoliDescripcion { get; set; }
        public DateTime? PoliInicioVigencia { get; set; }
        public int? PoliMesesCobertura { get; set; }
        public double? PoliPrecio { get; set; }
        public int? PoliTipoRiesgo { get; set; }
        public int? PoliTipoCubrimiento { get; set; }

        public virtual TiposCubrimiento PoliTipoCubrimientoNavigation { get; set; }
        public virtual TiposRiesgo PoliTipoRiesgoNavigation { get; set; }
        public virtual ICollection<PolizasCliente> PolizasCliente { get; set; }
    }
}
