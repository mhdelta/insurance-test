using InsuranceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Repositories
{
    public class TipoRiesgoRepository: RepositoryBase<TipoRiesgo>, ITipoRiesgoRepository
    {
        public TipoRiesgoRepository(masterContext masterContext) : base(masterContext)
        {

        }
    }
}
