using InsuranceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Repositories
{
    public class PolizaRepository: RepositoryBase<Poliza>, IPolizaRepository
    {
        public PolizaRepository(masterContext masterContext) : base(masterContext)
        {

        }
        public IQueryable<Poliza> FindAll()
        {
            return this.RepositoryContext.Set<Poliza>().AsNoTracking()
                .Include(x => x.TipoCubrimientoNavigation)
                .Include(x => x.TipoRiesgoNavigation);
        }

        public void Create(Poliza poliza) {
            try {
                var risk = RepositoryContext.Set<TipoRiesgo>().Find(poliza.TipoRiesgo);
                var cover = RepositoryContext.Set<TipoCubrimiento>().Find(poliza.TipoCubrimiento);

                if (risk.Descripcion == "Alto" && cover.Porcentaje > 50) {
                    throw new Exception("Cuando una póliza de seguro, contiene una línea de riesgo alto, el porcentaje de cubrimiento no puede ser superior al 50%.");
                }

                this.RepositoryContext.Set<Poliza>().Add(poliza);
                this.RepositoryContext.SaveChanges();
            } catch (Exception e) {
                throw new Exception("Error al crear la poliza", e.InnerException);
            }
        }
    }
}
