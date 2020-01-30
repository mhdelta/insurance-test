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
    }
}
