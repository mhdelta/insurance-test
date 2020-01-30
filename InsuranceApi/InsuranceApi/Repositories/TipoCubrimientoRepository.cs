using InsuranceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Repositories
{
    public class TipoCubrimientoRepository: RepositoryBase<TipoCubrimiento>, ITipoCubrimientoRepository
    {
        public TipoCubrimientoRepository(masterContext masterContext) : base(masterContext)
        {

        }
    }
}
